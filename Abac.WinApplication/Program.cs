using System;
using System.Windows.Forms;
using Abac.Business;

namespace Abac.WinApplication
{
    internal static class Program
    {
        private static readonly AbacValue ValueExample = new AbacValue(new AbacObject
        {
            {"firstName", new AbacValue("John")},
            {"lastName", new AbacValue("Smith")},
            {"isAlive", new AbacValue(true)},
            {"age", new AbacValue(25)},
            {
                "address", new AbacValue(new AbacObject
                {
                    {"streetAddress", new AbacValue("21 Jump Street")},
                    {"city", new AbacValue("New York")}
                })
            },
            {
                "an array",
                new AbacValue(new AbacArray {new AbacValue("unu"), new AbacValue("doi"), new AbacValue("trei")})
            },
            {
                "phoneNumbers", new AbacValue(new AbacArray
                {
                    new AbacValue(new AbacObject
                    {
                        {"type", new AbacValue("home")},
                        {"number", new AbacValue(555)}
                    }),
                    new AbacValue(new AbacObject
                    {
                        {"type", new AbacValue("office")},
                        {"number", new AbacValue("555")}
                    })
                })
            },
            {"children", new AbacValue(new AbacArray())},
            {"spouse", new AbacValue()}
        });
        
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(ValueExample));
        }
    }
}