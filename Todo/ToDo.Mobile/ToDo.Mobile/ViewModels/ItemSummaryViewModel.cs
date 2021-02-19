using System.Threading.Tasks;
using ToDo.Shared;
using Xamarin.Forms;

namespace ToDo.Mobile.ViewModels
{
    public class ItemSummaryViewModel : BaseViewModel
    {
        private ToDoItem _item;

        public ToDoItem Item
        {
            get => _item;
            set => SetProperty(ref _item, value);
        }

        public string Task => Item?.Task;

        public Command<ToDoItem> CompleteItem { get; set; }

    }
}
