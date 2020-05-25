using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
using App = System.Windows.Forms.Application;

namespace Abac.Creator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string lang = ConfigurationManager.AppSettings["Language"];
            if (!string.IsNullOrEmpty(lang))
                try { Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang); }
                catch { }
            App.EnableVisualStyles();
            App.SetCompatibleTextRenderingDefault(false);
            App.Run(new MainFormOld());
        }
    }
}
