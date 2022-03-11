using TodoClient.Models;
using TodoClient.ViewModels;

namespace TodoClient
{
    public class TodoItemViewModel : ViewModelBase
    {
        private TodoItem _todoItem;

        public TodoItemViewModel()
        {
            _todoItem = new TodoItem();
        }

        public TodoItemViewModel(TodoItem todoItem)
        {
            _todoItem = todoItem;
        }

        public TodoItemViewModel(TodoItemViewModel todoItemViewModel)
        {
            _todoItem = new TodoItem { Id = todoItemViewModel.Id, Title = todoItemViewModel.Title, Description = todoItemViewModel.Description, IsComplete = todoItemViewModel.IsComplete };
        }

        public TodoItemViewModel(int id, string title, string description, bool isComplete)
        {
            _todoItem = new TodoItem { Id = id, Title = title, Description = description, IsComplete = isComplete };
        }

        public int Id
        {
            get
            {
                return _todoItem.Id;
            }
            set
            {
                _todoItem.Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Title
        {
            get
            {
                return _todoItem.Title;
            }
            set
            {
                _todoItem.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Description
        {
            get
            {
                return _todoItem.Description;
            }
            set
            {
                _todoItem.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public bool IsComplete
        {
            get
            {
                return _todoItem.IsComplete;
            }
            set
            {
                _todoItem.IsComplete = value;
                OnPropertyChanged(nameof(IsComplete));
            }
        }
    }
}
