using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRW.Apps.RandomCharacterGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RandomCharacterGenerator());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // log and gracefully attempt to close - this event is fired before/during a crash
            if(e.IsTerminating)
            {
                if(e.ExceptionObject is Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine(exception.StackTrace);
                }
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            // handle unhandled exceptions
            MessageBox.Show(e.Exception.Message);
            Console.WriteLine($"Unhandled Exception from {sender}: {e.Exception.Message}");
            Console.WriteLine(e.Exception.StackTrace);
        }
    }
}
