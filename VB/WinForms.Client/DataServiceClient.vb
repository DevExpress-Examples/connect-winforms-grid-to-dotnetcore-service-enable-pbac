Imports System.Diagnostics
Imports System.IdentityModel.Tokens.Jwt
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text.Json
Imports System.Text.Json.Nodes

Namespace WinForms.Client

    Public Module DataServiceClient

        Public Class BearerTokenHandler
            Inherits DelegatingHandler

            Public Sub New()
                InnerHandler = New HttpClientHandler()
            End Sub

            Protected Overrides Async Function SendAsync(ByVal request As HttpRequestMessage, ByVal cancellationToken As CancellationToken) As Task(Of HttpResponseMessage)
                If Not [String].IsNullOrWhiteSpace(accessToken) Then
                    If Not [String].IsNullOrWhiteSpace(refreshToken) AndAlso lastRefreshed.HasValue AndAlso expiresIn.HasValue AndAlso DateTime.Now - lastRefreshed > TimeSpan.FromSeconds(CInt(expiresIn - 60)) Then
                        If String.IsNullOrEmpty(authUrl) Then Throw New InvalidOperationException("The 'authUrl' configuration setting is missing.")
                        If String.IsNullOrEmpty(realm) Then Throw New InvalidOperationException("The 'realm' configuration setting is missing.")
                        If String.IsNullOrEmpty(clientId) Then Throw New InvalidOperationException("The 'clientId' configuration setting is missing.")
                        Dim content = New FormUrlEncodedContent(New Dictionary(Of String, String) From {{"grant_type", "refresh_token"}, {"client_id", clientId}, {"refresh_token", refreshToken}})
                        Dim url = $"{authUrl}/realms/{realm}/protocol/openid-connect/token"
                        Dim response = Await bareHttpClient.PostAsync(url, content)
                        response.EnsureSuccessStatusCode()
                        Dim responseString = Await response.Content.ReadAsStringAsync()
                        (accessToken, refreshToken, expiresIn) = GetTokens(responseString)
                        If accessToken IsNot Nothing Then
                            lastRefreshed = DateTime.Now
                            (nameField, DataServiceClient.realmRoles) = DataServiceClient.GetUserDetails(accessToken)
                        End If
                    End If

                    request.Headers.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)
                End If

                Return Await MyBase.SendAsync(request, cancellationToken)
            End Function
        End Class

        Sub New()
            If String.IsNullOrEmpty(baseUrl) Then Throw New InvalidOperationException("The 'baseUrl' configuration setting is missing.")
        End Sub

        Private baseUrl As String? = System.Configuration.ConfigurationManager.AppSettings("baseUrl")

        Private accessToken As String?

        Public ReadOnly Property LoggedIn As Boolean
            Get
                Return accessToken IsNot Nothing
            End Get
        End Property

        Private refreshToken As String?

        Private expiresIn As Integer?

        Private lastRefreshed As DateTime?

        Private nameField As String?

        Public ReadOnly Property Name As String?
            Get
                Return nameField
            End Get
        End Property

         ''' Cannot convert FieldDeclarationSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.TypeSyntax'.
'''    at ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration)
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitFieldDeclaration(FieldDeclarationSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''         static string?[]? realmRoles;
''' 
'''  Public Function UserHasRole(ByVal role As String) As Boolean
            Return DataServiceClient.realmRoles IsNot Nothing AndAlso DataServiceClient.realmRoles.Contains(role)
        End Function

        Private clientId As String? = System.Configuration.ConfigurationManager.AppSettings("clientId")

        Private realm As String? = System.Configuration.ConfigurationManager.AppSettings("realm")

        Private authUrl As String? = System.Configuration.ConfigurationManager.AppSettings("authUrl")

        Private bareHttpClient As HttpClient = New HttpClient()

        Private Function GetTokens(ByVal jsonString As String) As(String?, String?, Integer?)
            Dim node = JsonNode.Parse(jsonString)
            If node Is Nothing Then
                Return(Nothing, Nothing, Nothing)
            Else
                Return(node("access_token")?.GetValue(Of String)(), node("refresh_token")?.GetValue(Of String)(), node("expires_in")?.GetValue(Of Integer)())
            End If
        End Function

        Private Function GetUserDetails(ByVal accessToken As String?) As(String?, String?())
            If [String].IsNullOrEmpty(accessToken) Then Return(Nothing, _(_))
            Dim handler = New JwtSecurityTokenHandler()
            Dim token = handler.ReadJwtToken(accessToken)
            Dim claim = Function(ByVal claimType As String) token.Claims.FirstOrDefault(Function(c) c.Type Is claimType)?.Value
            Dim name = claim("name")
            Dim realmAccess = claim("realm_access")
            Dim node = JsonNode.Parse(realmAccess)
            If node Is Nothing OrElse node("roles") Is Nothing Then Return(name, _(_))
             ''' Cannot convert LocalDeclarationStatementSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax'.
'''    at ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration)
'''    at ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
''' 
''' Input:
'''             var array = node["roles"]!.AsArray();
''' 
'''  Dim realmRoles = array.[Select](Function(r) r?.GetValue(Of String)()).ToArray()
            Return(name, realmRoles)
        End Function

        Public Async Function LogIn(ByVal username As String, ByVal password As String) As Task(Of Boolean)
            If String.IsNullOrEmpty(authUrl) Then Throw New InvalidOperationException("The 'authUrl' configuration setting is missing.")
            If String.IsNullOrEmpty(realm) Then Throw New InvalidOperationException("The 'realm' configuration setting is missing.")
            If String.IsNullOrEmpty(clientId) Then Throw New InvalidOperationException("The 'clientId' configuration setting is missing.")
            Dim content = New FormUrlEncodedContent(New Dictionary(Of String, String) From {{"client_id", clientId}, {"username", username}, {"password", password}, {"grant_type", "password"}})
            Dim url = $"{authUrl}/realms/{realm}/protocol/openid-connect/token"
            Dim response = Await bareHttpClient.PostAsync(url, content)
            Try
                response.EnsureSuccessStatusCode()
                Dim responseString = Await response.Content.ReadAsStringAsync()
                (accessToken, refreshToken, expiresIn) = GetTokens(responseString)
                If accessToken IsNot Nothing Then
                    lastRefreshed = DateTime.Now
                    (nameField, DataServiceClient.realmRoles) = DataServiceClient.GetUserDetails(accessToken)
                End If

                Return True
            Catch ex As Exception
                Debug.WriteLine(ex)
                Return False
            End Try
        End Function

        Public Sub LogOut()
            WinForms.Client.DataServiceClient.accessToken = Nothing
            WinForms.Client.DataServiceClient.refreshToken = Nothing
            WinForms.Client.DataServiceClient.expiresIn = Nothing
            WinForms.Client.DataServiceClient.lastRefreshed = Nothing
            WinForms.Client.DataServiceClient.nameField = Nothing
            WinForms.Client.DataServiceClient.realmRoles = Nothing
        End Sub

        Private authorizedHttpClient As HttpClient = New HttpClient(New BearerTokenHandler())

        Public Async Function GetOrderItemsAsync(ByVal skip As Integer, ByVal take As Integer, ByVal sortField As String, ByVal sortAscending As Boolean) As Task(Of DataFetchResult?)
            Dim response = Await authorizedHttpClient.GetAsync($"{baseUrl}/data/OrderItems?skip={skip}&take={take}&sortField={sortField}&sortAscending={sortAscending}")
            response.EnsureSuccessStatusCode()
            Dim responseBody = Await response.Content.ReadAsStringAsync()
            Dim dataFetchResult = JsonSerializer.Deserialize(Of DataFetchResult)(responseBody, New JsonSerializerOptions With {.PropertyNameCaseInsensitive = True})
            Return dataFetchResult
        End Function

        <Extension()>
        Private Function AsOrderItem(ByVal responseBody As String) As OrderItem?
            Return JsonSerializer.Deserialize(Of OrderItem)(responseBody, New JsonSerializerOptions With {.PropertyNameCaseInsensitive = True})
        End Function

        Public Async Function GetOrderItemAsync(ByVal id As Integer) As Task(Of OrderItem?)
            Dim response = Await authorizedHttpClient.GetAsync($"{baseUrl}/data/OrderItem/{id}")
            response.EnsureSuccessStatusCode()
            Dim responseBody = Await response.Content.ReadAsStringAsync()
            Return responseBody.AsOrderItem()
        End Function

        Public Async Function CreateOrderItemAsync(ByVal orderItem As OrderItem) As Task(Of OrderItem?)
            Dim response = Await authorizedHttpClient.PostAsync($"{baseUrl}/data/OrderItem", New StringContent(JsonSerializer.Serialize(orderItem), Encoding.UTF8, "application/json"))
            response.EnsureSuccessStatusCode()
            Dim responseBody = Await response.Content.ReadAsStringAsync()
            Return responseBody.AsOrderItem()
        End Function

        Public Async Function UpdateOrderItemAsync(ByVal orderItem As OrderItem) As Task
            Dim response = Await authorizedHttpClient.PutAsync($"{baseUrl}/data/OrderItem/{orderItem.Id}", New StringContent(JsonSerializer.Serialize(orderItem), Encoding.UTF8, "application/json"))
            response.EnsureSuccessStatusCode()
        End Function

        Public Async Function DeleteOrderItemAsync(ByVal id As Integer) As Task(Of Boolean)
            Try
                Dim response = Await authorizedHttpClient.DeleteAsync($"{baseUrl}/data/OrderItem/{id}")
                response.EnsureSuccessStatusCode()
                Return True
            Catch ex As Exception
                Debug.WriteLine(ex)
                Return False
            End Try
        End Function
    End Module
End Namespace
