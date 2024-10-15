using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace WinForms.Client
{
    public static class DataServiceClient
    {
        public class BearerTokenHandler : DelegatingHandler
        {
            public BearerTokenHandler()
            {
                InnerHandler = new HttpClientHandler();
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (!String.IsNullOrWhiteSpace(accessToken))
                {
                    if (!String.IsNullOrWhiteSpace(refreshToken) &&
                        lastRefreshed.HasValue &&
                        expiresIn.HasValue &&
                        DateTime.Now - lastRefreshed > TimeSpan.FromSeconds((int)(expiresIn - 60)))
                    {
                        if (string.IsNullOrEmpty(authUrl))
                            throw new InvalidOperationException("The 'authUrl' configuration setting is missing.");
                        if (string.IsNullOrEmpty(realm))
                            throw new InvalidOperationException("The 'realm' configuration setting is missing.");
                        if (string.IsNullOrEmpty(clientId))
                            throw new InvalidOperationException("The 'clientId' configuration setting is missing.");

                        var content = new FormUrlEncodedContent(new Dictionary<string, string>
                        {
                            {"grant_type", "refresh_token"},
                            {"client_id", clientId},
                            {"refresh_token", refreshToken}
                        });

                        var url = $"{authUrl}/realms/{realm}/protocol/openid-connect/token";
                        var response = await bareHttpClient.PostAsync(url, content);
                        response.EnsureSuccessStatusCode();
                        var responseString = await response.Content.ReadAsStringAsync();
                        (accessToken, refreshToken, expiresIn) = GetTokens(responseString);
                        if (accessToken != null)
                        {
                            lastRefreshed = DateTime.Now;
                            (name, realmRoles) = GetUserDetails(accessToken);
                        }
                    }
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                return await base.SendAsync(request, cancellationToken);
            }
        }

        static DataServiceClient()
        {
            if (string.IsNullOrEmpty(baseUrl))
                throw new InvalidOperationException("The 'baseUrl' configuration setting is missing.");
        }

        static string? baseUrl = System.Configuration.ConfigurationManager.AppSettings["baseUrl"];

        static string? accessToken;
        public static bool LoggedIn => accessToken != null;
        static string? refreshToken;
        static int? expiresIn;
        static DateTime? lastRefreshed;
        static string? name;
        public static string? Name => name;
        static string?[]? realmRoles;
        public static bool UserHasRole(string role) => realmRoles != null && realmRoles.Contains(role);
        static string? clientId = System.Configuration.ConfigurationManager.AppSettings["clientId"];
        static string? realm = System.Configuration.ConfigurationManager.AppSettings["realm"];
        static string? authUrl = System.Configuration.ConfigurationManager.AppSettings["authUrl"];

        static HttpClient bareHttpClient = new HttpClient();

        static (string? access_token, string? refresh_token, int? expires_in) GetTokens(string jsonString)
        {
            var node = JsonNode.Parse(jsonString);
            if (node == null)
                return (null, null, null);
            else
                return (node["access_token"]?.GetValue<string>(),
                    node["refresh_token"]?.GetValue<string>(),
                    node["expires_in"]?.GetValue<int>());
        }

        static (string? name, string?[] realmRoles) GetUserDetails(string? accessToken)
        {
            if (String.IsNullOrEmpty(accessToken))
                return (null, []);
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(accessToken);

            var claim = (string claimType) => token.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;
            var name = claim("name");
            var realmAccess = claim("realm_access");
            var node = JsonNode.Parse(realmAccess);
            if (node == null || node["roles"] == null) return (name, []);
            var array = node["roles"]!.AsArray();
            var realmRoles = array.Select(r => r?.GetValue<string>()).ToArray();

            return (name, realmRoles);
        }

        public static async Task<bool> LogIn(string username, string password)
        {
            if (string.IsNullOrEmpty(authUrl))
                throw new InvalidOperationException("The 'authUrl' configuration setting is missing.");
            if (string.IsNullOrEmpty(realm))
                throw new InvalidOperationException("The 'realm' configuration setting is missing.");
            if (string.IsNullOrEmpty(clientId))
                throw new InvalidOperationException("The 'clientId' configuration setting is missing.");

            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"client_id", clientId},
                {"username", username},
                {"password", password},
                {"grant_type", "password"}
            });
            var url = $"{authUrl}/realms/{realm}/protocol/openid-connect/token";
            var response = await bareHttpClient.PostAsync(url, content);
            try
            {
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                (accessToken, refreshToken, expiresIn) = GetTokens(responseString);
                if (accessToken != null)
                {
                    lastRefreshed = DateTime.Now;
                    (name, realmRoles) = GetUserDetails(accessToken);
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public static void LogOut()
        {
            accessToken = null;
            refreshToken = null;
            expiresIn = null;
            lastRefreshed = null;
            name = null;
            realmRoles = null;
        }

        static HttpClient authorizedHttpClient = new HttpClient(new BearerTokenHandler());

        public static async Task<DataFetchResult?> GetOrderItemsAsync(int skip, int take, string sortField, bool sortAscending)
        {
            var response = await authorizedHttpClient.GetAsync(
                $"{baseUrl}/data/OrderItems?skip={skip}&take={take}&sortField={sortField}&sortAscending={sortAscending}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            var dataFetchResult = JsonSerializer.Deserialize<DataFetchResult>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return dataFetchResult;
        }

        static OrderItem? AsOrderItem(this string responseBody)
        {
            return JsonSerializer.Deserialize<OrderItem>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public static async Task<OrderItem?> GetOrderItemAsync(int id)
        {
            var response = await authorizedHttpClient.GetAsync($"{baseUrl}/data/OrderItem/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody.AsOrderItem();
        }

        public static async Task<OrderItem?> CreateOrderItemAsync(OrderItem orderItem)
        {
            var response = await authorizedHttpClient.PostAsync($"{baseUrl}/data/OrderItem",
                new StringContent(JsonSerializer.Serialize(orderItem), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody.AsOrderItem();
        }

        public static async Task UpdateOrderItemAsync(OrderItem orderItem)
        {
            var response = await authorizedHttpClient.PutAsync($"{baseUrl}/data/OrderItem/{orderItem.Id}",
                new StringContent(JsonSerializer.Serialize(orderItem), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public static async Task<bool> DeleteOrderItemAsync(int id)
        {
            try
            {
                var response = await authorizedHttpClient.DeleteAsync($"{baseUrl}/data/OrderItem/{id}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
    }
}
