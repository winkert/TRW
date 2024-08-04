using MobileWords.ViewModels;
using MobileWords.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileWords
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {

            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
        }

    }
}
