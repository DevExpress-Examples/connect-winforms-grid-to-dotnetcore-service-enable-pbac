using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;

namespace WinForms.Client
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WindowsFormsSettings.SetPerMonitorDpiAware();
            WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle(SkinStyle.WXI);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm());
        }
    }
}