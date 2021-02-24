using System;
using System.Threading.Tasks;
using ToDo.Shared;
using Xamarin.Forms;

namespace ToDo.Mobile.ViewModels
{
    public class ItemSummaryViewModel : BaseViewModel
    {
        private TodoItem _item;
        private bool _isCompleted;

        public string Text => Item?.Text;
        public bool IsCompleted
        {
            get => _isCompleted;
            set => SetProperty(ref _isCompleted, value);
        }
        public Command CompleteItem { get; set; }

        public TodoItem Item
        {
            get => _item;
            set => SetProperty(ref _item, value);
        }

        public TextDecorations LabelDecoration => 
            IsCompleted ? TextDecorations.Strikethrough : TextDecorations.None;

        public ItemSummaryViewModel(TodoItem item)
        {
            CompleteItem = new Command(OnCompleteItem);
            
            IsCompleted = (_item = item)?.IsCompleted ?? false;
        }

        public async void OnCompleteItem()
        {
            Item.IsCompleted = IsCompleted;

            await DataStore.UpdateItemAsync(Item);
            
            Console.WriteLine("Modified Text: {0}", Text);

            OnPropertyChanged(nameof(Item));
            OnPropertyChanged(nameof(LabelDecoration));
        }
    }
}
