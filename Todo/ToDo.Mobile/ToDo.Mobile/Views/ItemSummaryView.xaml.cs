using ToDo.Mobile.ViewModels;
using ToDo.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemSummaryView : ContentView
    {
        private ItemSummaryViewModel _viewModel;

        public ToDoItem Source { get; set; }

        public ItemSummaryView()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemSummaryViewModel();

            _viewModel.Item = Source;
        }
    }
}