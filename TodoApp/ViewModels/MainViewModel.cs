using System.Windows.Input;
using System.Collections.ObjectModel;
using TodoApp.Commands;
using TodoApp.Classes;

namespace TodoApp.ViewModels
{
    public class MainViewModel
    {
        //переменные для хранения элементов завершённых и незавершённых списков
        public ObservableCollection<ListItem> uncompletedListItems = new ObservableCollection<ListItem>();
        public ObservableCollection<ListItem> completedListItems = new ObservableCollection<ListItem>();

        public ICommand AddNewListItemCommand { get; }

        public MainViewModel()
        {
            AddNewListItemCommand = new RelayCommand(AddNewListItem);
        }

        private void AddNewListItem(object parameter)
        {
            string textListItem = parameter.ToString() ?? throw new ArgumentException("Ошибка! Значение для поля текста не может быть пустым!");

            uncompletedListItems.Add(new ListItem(textListItem));
        }

        private void CompleteListItem(object parameter)
        {
            //проверка на то, что параметр, переданный в метод является объектом типа ListItem и если так, то создаётся объект task
            if (parameter is ListItem task)
            {
                uncompletedListItems.Remove(task);
                completedListItems.Add(task);
            }
        }
    }
}
