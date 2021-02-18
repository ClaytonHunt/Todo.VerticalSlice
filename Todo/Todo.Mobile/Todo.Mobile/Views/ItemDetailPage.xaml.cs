using System.ComponentModel;
using Todo.Mobile.ViewModels;
using Xamarin.Forms;

namespace Todo.Mobile.Views
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