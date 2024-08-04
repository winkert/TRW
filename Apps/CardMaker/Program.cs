using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRW.Apps.CardMaker
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                HandleArguments(args);
            }
            else
            {
                Application.Run(new DeckBuilder());
            }
        }

        static void HandleArguments(string[] args)
        {
            if (args.Length > 1)
            {
                switch (args[0])
                {
                    case "V":
                    case "v":
                    case "-V":
                    case "-v":
                    case "/V":
                    case "/v":
                        Application.Run(new DeckBuilder(args[0], true));
                        break;
                }
            }
            else if (args.Length > 0)
            {
                Application.Run(new DeckBuilder(args[0], false));
            }
        }
    }
}
