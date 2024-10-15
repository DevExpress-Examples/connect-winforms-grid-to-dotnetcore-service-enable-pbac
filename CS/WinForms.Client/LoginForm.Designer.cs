namespace WinForms.Client
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            loginButton = new DevExpress.XtraEditors.SimpleButton();
            cancelButton = new DevExpress.XtraEditors.SimpleButton();
            svgImageBox1 = new DevExpress.XtraEditors.SvgImageBox();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            userNameEdit = new DevExpress.XtraEditors.TextEdit();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            passwordEdit = new DevExpress.XtraEditors.TextEdit();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgImageBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userNameEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)passwordEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(passwordEdit);
            layoutControl1.Controls.Add(userNameEdit);
            layoutControl1.Controls.Add(loginButton);
            layoutControl1.Controls.Add(cancelButton);
            layoutControl1.Controls.Add(svgImageBox1);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(746, 209, 650, 662);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(436, 235);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(179, 201);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(120, 22);
            loginButton.StyleController = layoutControl1;
            loginButton.TabIndex = 2;
            loginButton.Text = "Log In";
            loginButton.Click += loginButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(303, 201);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(121, 22);
            cancelButton.StyleController = layoutControl1;
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancel";
            // 
            // svgImageBox1
            // 
            svgImageBox1.Location = new Point(12, 12);
            svgImageBox1.Name = "svgImageBox1";
            svgImageBox1.Size = new Size(112, 109);
            svgImageBox1.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Zoom;
            svgImageBox1.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageBox1.SvgImage");
            svgImageBox1.TabIndex = 4;
            svgImageBox1.Text = "svgImageBox1";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem4, layoutControlItem5, layoutControlGroup1, emptySpaceItem1, emptySpaceItem2 });
            Root.Name = "Root";
            Root.Size = new Size(436, 235);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = svgImageBox1;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(116, 113);
            layoutControlItem1.TextSize = new Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = cancelButton;
            layoutControlItem4.Location = new Point(291, 189);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(125, 26);
            layoutControlItem4.TextSize = new Size(0, 0);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = loginButton;
            layoutControlItem5.Location = new Point(167, 189);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(124, 26);
            layoutControlItem5.TextSize = new Size(0, 0);
            layoutControlItem5.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem6, layoutControlItem2 });
            layoutControlGroup1.Location = new Point(116, 0);
            layoutControlGroup1.Name = "layoutControlGroup1";
            layoutControlGroup1.Size = new Size(300, 113);
            layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new Point(0, 189);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(167, 26);
            emptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.AllowHotTrack = false;
            emptySpaceItem2.Location = new Point(0, 113);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(416, 76);
            emptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // userNameEdit
            // 
            userNameEdit.Location = new Point(140, 40);
            userNameEdit.Name = "userNameEdit";
            userNameEdit.Size = new Size(272, 20);
            userNameEdit.StyleController = layoutControl1;
            userNameEdit.TabIndex = 5;
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = userNameEdit;
            layoutControlItem6.Location = new Point(0, 0);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new Size(276, 40);
            layoutControlItem6.Text = "User Name";
            layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem6.TextSize = new Size(52, 13);
            // 
            // passwordEdit
            // 
            passwordEdit.Location = new Point(140, 89);
            passwordEdit.Name = "passwordEdit";
            passwordEdit.Properties.UseSystemPasswordChar = true;
            passwordEdit.Size = new Size(272, 20);
            passwordEdit.StyleController = layoutControl1;
            passwordEdit.TabIndex = 6;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = passwordEdit;
            layoutControlItem2.Location = new Point(0, 40);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(276, 49);
            layoutControlItem2.Text = "Password";
            layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem2.TextSize = new Size(52, 13);
            // 
            // LoginForm
            // 
            AcceptButton = loginButton;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(436, 235);
            Controls.Add(layoutControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Log In";
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)svgImageBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)userNameEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)passwordEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton loginButton;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.TextEdit passwordEdit;
        private DevExpress.XtraEditors.TextEdit userNameEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}