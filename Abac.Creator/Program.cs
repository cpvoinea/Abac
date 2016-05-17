using System;
using App = System.Windows.Forms.Application;

namespace Abac.Creator
{
    static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            App.EnableVisualStyles();
            App.SetCompatibleTextRenderingDefault(false);
            App.Run(new MainForm());
        }
    }
}
