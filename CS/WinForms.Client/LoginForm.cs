using DevExpress.XtraEditors;

namespace WinForms.Client
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userNameEdit.Text) || string.IsNullOrEmpty(passwordEdit.Text))
            {
                XtraMessageBox.Show("Please enter username and password", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (await DataServiceClient.LogIn(userNameEdit.Text, passwordEdit.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Username or password are invalid, or a technical error occurred.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}