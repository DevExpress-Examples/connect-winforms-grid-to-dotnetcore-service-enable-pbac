Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors

Namespace WinForms.Client

    Friend Module Program

        ''' <summary>
        '''  The main entry point for the application.
        ''' </summary>
        <STAThread>
        Sub Main()
            Call WindowsFormsSettings.SetPerMonitorDpiAware()
            WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle(SkinStyle.WXI)
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New MainForm())
        End Sub
    End Module
End Namespace
