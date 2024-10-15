Imports DevExpress.XtraEditors

Namespace WinForms.Client

    Public Partial Class LoginForm
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Async Sub loginButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            If String.IsNullOrEmpty(userNameEdit.Text) OrElse String.IsNullOrEmpty(passwordEdit.Text) Then
                XtraMessageBox.Show("Please enter username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return
            End If

            If Await DataServiceClient.LogIn(userNameEdit.Text, passwordEdit.Text) Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                XtraMessageBox.Show("Username or password are invalid, or a technical error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End If
        End Sub
    End Class
End Namespace
