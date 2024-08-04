using MobileWords.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MobileWords.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}