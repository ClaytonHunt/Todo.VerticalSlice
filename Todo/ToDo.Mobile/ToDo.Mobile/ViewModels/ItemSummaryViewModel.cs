using System.Threading.Tasks;
using ToDo.Shared;

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

        public async void CompleteItem()
        {
            await Task.CompletedTask;
        }
    }
}
