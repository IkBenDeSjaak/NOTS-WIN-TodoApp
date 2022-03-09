using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TodoClient
{
    internal class TodoItems : INotifyPropertyChanged
    {
        ObservableCollection<TodoItem> todos = new ObservableCollection<TodoItem>();

        public event PropertyChangedEventHandler? PropertyChanged;

        public TodoItems()
        {
            LoadTodos();
        }

        private void LoadTodos()
        {
            for(int i = 0; i < 5; i++)
            {
                TodoItem item = new TodoItem(i, "aaaa", "bbbbbbb" + i, false);
                todos.Add(item);
            }
        }

        public ObservableCollection<TodoItem> Todos
        {
            set { SetProperty<ObservableCollection<TodoItem>>(ref todos, value); }
            get { return todos; }
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private System.Collections.IEnumerable items1;

        public System.Collections.IEnumerable items { get => items1; set => SetProperty(ref items1, value); }
    }
}
