using MobileWords.Models;
using MobileWords.ViewModels;
using MobileWords.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileWords.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
            _viewModel.ReportProgressEvent += Search_ReportProgressEvent;
        }

        private void Search_ReportProgressEvent(double progress)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                uxSearchProgress.Progress = progress/100d;
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            uxSearchEntry.Text = string.Empty;
            _viewModel.OnAppearing();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Task t = _viewModel.SearchAsync(uxSearchEntry.Text);
            t.Wait();
        }
    }
}