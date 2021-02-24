using ToDo.Mobile.ViewModels;
using ToDo.Shared;
using Xamarin.Forms;

namespace ToDo.Mobile.Views
{
    public partial class NewItemPage : ContentPage
    {
        public TodoItem Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}