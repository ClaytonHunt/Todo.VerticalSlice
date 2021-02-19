using ToDo.Mobile.ViewModels;
using ToDo.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemSummaryView : ContentView
    {
        private readonly ItemSummaryViewModel _viewModel;
        
        public ItemSummaryView()
        {
            InitializeComponent();

            BindingContext = BindingContext;
        }        
    }
}