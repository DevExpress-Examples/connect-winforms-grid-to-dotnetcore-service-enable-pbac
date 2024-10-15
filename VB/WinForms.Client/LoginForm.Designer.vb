Namespace WinForms.Client

    Partial Class LoginForm

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WinForms.Client.LoginForm))
            Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
            Me.loginButton = New DevExpress.XtraEditors.SimpleButton()
            Me.cancelButton = New DevExpress.XtraEditors.SimpleButton()
            Me.svgImageBox1 = New DevExpress.XtraEditors.SvgImageBox()
            Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.layoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.layoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.emptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
            Me.emptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
            Me.userNameEdit = New DevExpress.XtraEditors.TextEdit()
            Me.layoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.passwordEdit = New DevExpress.XtraEditors.TextEdit()
            Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
            CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.layoutControl1.SuspendLayout()
            CType(Me.svgImageBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.layoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.userNameEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.layoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.passwordEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            SuspendLayout()
            ' 
            ' layoutControl1
            ' 
            Me.layoutControl1.Controls.Add(Me.passwordEdit)
            Me.layoutControl1.Controls.Add(Me.userNameEdit)
            Me.layoutControl1.Controls.Add(Me.loginButton)
            Me.layoutControl1.Controls.Add(Me.cancelButton)
            Me.layoutControl1.Controls.Add(Me.svgImageBox1)
            Me.layoutControl1.Dock = DockStyle.Fill
            Me.layoutControl1.Location = New Point(0, 0)
            Me.layoutControl1.Name = "layoutControl1"
            Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New Rectangle(746, 209, 650, 662)
            Me.layoutControl1.Root = Me.Root
            Me.layoutControl1.Size = New Size(436, 235)
            Me.layoutControl1.TabIndex = 0
            Me.layoutControl1.Text = "layoutControl1"
            ' 
            ' loginButton
            ' 
            Me.loginButton.Location = New Point(179, 201)
            Me.loginButton.Name = "loginButton"
            Me.loginButton.Size = New Size(120, 22)
            Me.loginButton.StyleController = Me.layoutControl1
            Me.loginButton.TabIndex = 2
            Me.loginButton.Text = "Log In"
            Me.loginButton.Click += AddressOf loginButton_Click
            ' 
            ' cancelButton
            ' 
            Me.cancelButton.DialogResult = DialogResult.Cancel
            Me.cancelButton.Location = New Point(303, 201)
            Me.cancelButton.Name = "cancelButton"
            Me.cancelButton.Size = New Size(121, 22)
            Me.cancelButton.StyleController = Me.layoutControl1
            Me.cancelButton.TabIndex = 3
            Me.cancelButton.Text = "Cancel"
            ' 
            ' svgImageBox1
            ' 
            Me.svgImageBox1.Location = New Point(12, 12)
            Me.svgImageBox1.Name = "svgImageBox1"
            Me.svgImageBox1.Size = New Size(112, 109)
            Me.svgImageBox1.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Zoom
            Me.svgImageBox1.SvgImage = CType(resources.GetObject("svgImageBox1.SvgImage"), DevExpress.Utils.Svg.SvgImage)
            Me.svgImageBox1.TabIndex = 4
            Me.svgImageBox1.Text = "svgImageBox1"
            ' 
            ' Root
            ' 
            Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
            Me.Root.GroupBordersVisible = False
            Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutControlItem1, Me.layoutControlItem4, Me.layoutControlItem5, Me.layoutControlGroup1, Me.emptySpaceItem1, Me.emptySpaceItem2})
            Me.Root.Name = "Root"
            Me.Root.Size = New Size(436, 235)
            Me.Root.TextVisible = False
            ' 
            ' layoutControlItem1
            ' 
            Me.layoutControlItem1.Control = Me.svgImageBox1
            Me.layoutControlItem1.Location = New Point(0, 0)
            Me.layoutControlItem1.Name = "layoutControlItem1"
            Me.layoutControlItem1.Size = New Size(116, 113)
            Me.layoutControlItem1.TextSize = New Size(0, 0)
            Me.layoutControlItem1.TextVisible = False
            ' 
            ' layoutControlItem4
            ' 
            Me.layoutControlItem4.Control = Me.cancelButton
            Me.layoutControlItem4.Location = New Point(291, 189)
            Me.layoutControlItem4.Name = "layoutControlItem4"
            Me.layoutControlItem4.Size = New Size(125, 26)
            Me.layoutControlItem4.TextSize = New Size(0, 0)
            Me.layoutControlItem4.TextVisible = False
            ' 
            ' layoutControlItem5
            ' 
            Me.layoutControlItem5.Control = Me.loginButton
            Me.layoutControlItem5.Location = New Point(167, 189)
            Me.layoutControlItem5.Name = "layoutControlItem5"
            Me.layoutControlItem5.Size = New Size(124, 26)
            Me.layoutControlItem5.TextSize = New Size(0, 0)
            Me.layoutControlItem5.TextVisible = False
            ' 
            ' layoutControlGroup1
            ' 
            Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutControlItem6, Me.layoutControlItem2})
            Me.layoutControlGroup1.Location = New Point(116, 0)
            Me.layoutControlGroup1.Name = "layoutControlGroup1"
            Me.layoutControlGroup1.Size = New Size(300, 113)
            Me.layoutControlGroup1.TextVisible = False
            ' 
            ' emptySpaceItem1
            ' 
            Me.emptySpaceItem1.AllowHotTrack = False
            Me.emptySpaceItem1.Location = New Point(0, 189)
            Me.emptySpaceItem1.Name = "emptySpaceItem1"
            Me.emptySpaceItem1.Size = New Size(167, 26)
            Me.emptySpaceItem1.TextSize = New Size(0, 0)
            ' 
            ' emptySpaceItem2
            ' 
            Me.emptySpaceItem2.AllowHotTrack = False
            Me.emptySpaceItem2.Location = New Point(0, 113)
            Me.emptySpaceItem2.Name = "emptySpaceItem2"
            Me.emptySpaceItem2.Size = New Size(416, 76)
            Me.emptySpaceItem2.TextSize = New Size(0, 0)
            ' 
            ' userNameEdit
            ' 
            Me.userNameEdit.Location = New Point(140, 40)
            Me.userNameEdit.Name = "userNameEdit"
            Me.userNameEdit.Size = New Size(272, 20)
            Me.userNameEdit.StyleController = Me.layoutControl1
            Me.userNameEdit.TabIndex = 5
            ' 
            ' layoutControlItem6
            ' 
            Me.layoutControlItem6.Control = Me.userNameEdit
            Me.layoutControlItem6.Location = New Point(0, 0)
            Me.layoutControlItem6.Name = "layoutControlItem6"
            Me.layoutControlItem6.Size = New Size(276, 40)
            Me.layoutControlItem6.Text = "User Name"
            Me.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
            Me.layoutControlItem6.TextSize = New Size(52, 13)
            ' 
            ' passwordEdit
            ' 
            Me.passwordEdit.Location = New Point(140, 89)
            Me.passwordEdit.Name = "passwordEdit"
            Me.passwordEdit.Properties.UseSystemPasswordChar = True
            Me.passwordEdit.Size = New Size(272, 20)
            Me.passwordEdit.StyleController = Me.layoutControl1
            Me.passwordEdit.TabIndex = 6
            ' 
            ' layoutControlItem2
            ' 
            Me.layoutControlItem2.Control = Me.passwordEdit
            Me.layoutControlItem2.Location = New Point(0, 40)
            Me.layoutControlItem2.Name = "layoutControlItem2"
            Me.layoutControlItem2.Size = New Size(276, 49)
            Me.layoutControlItem2.Text = "Password"
            Me.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
            Me.layoutControlItem2.TextSize = New Size(52, 13)
            ' 
            ' LoginForm
            ' 
            AcceptButton = Me.loginButton
            AutoScaleDimensions = New SizeF(6F, 13F)
            AutoScaleMode = AutoScaleMode.Font
            CancelButton = Me.cancelButton
            ClientSize = New Size(436, 235)
            Controls.Add(Me.layoutControl1)
            FormBorderStyle = FormBorderStyle.FixedDialog
            Name = "LoginForm"
            StartPosition = FormStartPosition.CenterParent
            Me.Text = "Log In"
            CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.layoutControl1.ResumeLayout(False)
            CType(Me.svgImageBox1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.layoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.userNameEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.layoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.passwordEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
            ResumeLayout(False)
        End Sub

#End Region
        Private layoutControl1 As DevExpress.XtraLayout.LayoutControl

        Private Root As DevExpress.XtraLayout.LayoutControlGroup

        Private svgImageBox1 As DevExpress.XtraEditors.SvgImageBox

        Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem

        Private loginButton As DevExpress.XtraEditors.SimpleButton

        Private cancelButton As DevExpress.XtraEditors.SimpleButton

        Private layoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem

        Private layoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem

        Private emptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem

        Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup

        Private emptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem

        Private passwordEdit As DevExpress.XtraEditors.TextEdit

        Private userNameEdit As DevExpress.XtraEditors.TextEdit

        Private layoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem

        Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    End Class
End Namespace
