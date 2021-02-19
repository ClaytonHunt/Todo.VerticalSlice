using System;
using ToDo.Shared;
using Xamarin.Forms;

namespace ToDo.Mobile.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string _task;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(_task);
        }

        public string Task
        {
            get => _task;
            set => SetProperty(ref _task, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            var newItem = new ToDoItem
            {
                Id = Guid.NewGuid().ToString(),
                Task = Task
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
