using Logic;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace AttendanceSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin(new LogicSystem()));
        }
    }
}
