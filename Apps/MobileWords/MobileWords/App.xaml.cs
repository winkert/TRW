using MobileWords.Services;
using MobileWords.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("cour.ttf", Alias = "Courier")]
[assembly: ExportFont("courbd.ttf", Alias = "Courier-Bold")]
[assembly: ExportFont("courbi.ttf", Alias = "Courier-BoldItalic")]
[assembly: ExportFont("couri.ttf", Alias = "Courier-Italic")]
[assembly: ExportFont("PAPYRUS.TTF", Alias = "Papyrus")]

namespace MobileWords
{
    public partial class App : Application
    {
        static object _padLock = new object();
        private static TRW.AppLibraries.GuiWords.GuiWordsTable _table;
        internal static TRW.AppLibraries.GuiWords.GuiWordsTable Table
        {
            get
            {
                lock (_padLock)
                {
                    if (_table == null)
                    {
                        _table = TRW.AppLibraries.GuiWords.GuiWordsTable.GetGuiWordsResource();
                    }
                    return _table;
                }
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<WordsDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            Task task = BackgroundLoadTable();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private async Task BackgroundLoadTable()
        {
            await Task.Run(() =>
            {
                if (!Table.First())
                {
                    System.Diagnostics.Debug.WriteLine("There was a problem getting the first row of the GuiWords table!");
                }
            });
        }
    }
}
