using System;
using System.Windows.Forms;
using Res = JsonWinEdit.Properties.Resources;

namespace JsonWinEdit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                MainForm frm = new MainForm();

                if (args == null || args.Length == 0)
                    frm.EditorControl = EditorControl.CreateFromData(Res.schema);
                else
                    frm.EditorControl = EditorControl.CreateFromFile(args[0]);

                Application.Run(frm);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        internal static void ShowError(string message)
        {
            MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
