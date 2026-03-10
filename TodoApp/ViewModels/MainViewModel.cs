using System.Windows.Input;
using System.Collections.ObjectModel;
using TodoApp.Commands;
using TodoApp.Classes;

namespace TodoApp.ViewModels
{
    public class MainViewModel
    {
        //переменные для хранения элементов завершённых и незавершённых списков
        public ObservableCollection<ListItem> UncompletedListItems { get; set; } = new ObservableCollection<ListItem>();
        public ObservableCollection<ListItem> CompletedListItems { get; set; } = new ObservableCollection<ListItem>();

        public ICommand AddNewListItemCommand { get; }
        public ICommand CompleteListItemCommand { get; }


        public MainViewModel()
        {
            AddNewListItemCommand = new RelayCommand(AddNewListItemAsync);
            CompleteListItemCommand = new RelayCommand(CompleteListItem);
        }

        private async void AddNewListItemAsync(object parameter)
        {
            string? listItemText = (parameter as string)?.Trim();
            if (string.IsNullOrWhiteSpace(listItemText))
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Введите текст задачи!", "OK");
                return;
            }

            UncompletedListItems.Insert(0, new ListItem(listItemText));
        }

        private void CompleteListItem(object parameter)
        {
            //проверка на то, что параметр, переданный в метод является объектом типа ListItem и если так, то создаётся объект task
            if (parameter is ListItem task)
            {
                UncompletedListItems.Remove(task);
                CompletedListItems.Insert(0, task);
            }
        }
    }
}
