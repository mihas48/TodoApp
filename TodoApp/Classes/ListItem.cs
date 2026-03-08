namespace TodoApp.Classes
{
    public class ListItem
    {
        private string _text;
        private bool _isComplete;

        public string Text 
        {
            get => _text;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Ошибка! Значение для поля текста не может быть пустым!");
                }

                _text = value;
            }
        }

        public ListItem(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Ошибка! Значение для поля текста не может быть пустым!");
            else
                _text = text;

            _isComplete = false;
        }

        public void ToComplete()
        {
            _isComplete = true;
        }
    }
}
