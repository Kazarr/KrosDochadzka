using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Generator;
using System.Configuration;
using Logic;

namespace AttendanceTermianal
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
            Application.Run(new TerminalView(new LogicTerminal()));

        }


    }
}
