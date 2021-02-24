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
        private TodoItem _selectedItem;

        public ObservableCollection<ItemSummaryViewModel> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<TodoItem> ItemTapped { get; }
        public Command<TodoItem> CompleteItem { get;set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<ItemSummaryViewModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<TodoItem>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
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
                    Items.Add(new ItemSummaryViewModel(
                        new TodoItem
                        {
                            Id = item.Id, 
                            IsCompleted = item.IsCompleted, 
                            Text = item.Text
                        }));
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

        public TodoItem SelectedItem
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

        async void OnItemSelected(TodoItem item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}