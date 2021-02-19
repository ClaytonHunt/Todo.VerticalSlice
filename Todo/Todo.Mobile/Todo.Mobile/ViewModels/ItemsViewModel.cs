using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using ToDo.Mobile.Views;
using ToDo.Shared;
using Xamarin.Forms;

namespace ToDo.Mobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private ToDoItem _selectedItem;

        public ObservableCollection<ToDoItem> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<ToDoItem> ItemTapped { get; }
        public Command<ToDoItem> CompleteItem { get;set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<ToDoItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<ToDoItem>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);

            CompleteItem = new Command<ToDoItem>(OnCompleteItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public ToDoItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        private async void OnCompleteItem(ToDoItem todo)
        {
            // todo.IsCompleted = true;
            await Task.Run(() => { });
        }

        async void OnItemSelected(ToDoItem item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}