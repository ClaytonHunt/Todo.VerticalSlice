using ToDo.Mobile.ViewModels;
using ToDo.Shared;
using Xamarin.Forms;

namespace ToDo.Mobile.Views
{
    public partial class NewItemPage : ContentPage
    {
        public ToDoItem Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}