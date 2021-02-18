using System.ComponentModel;
using ToDo.Mobile.ViewModels;
using Xamarin.Forms;

namespace ToDo.Mobile.Views
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