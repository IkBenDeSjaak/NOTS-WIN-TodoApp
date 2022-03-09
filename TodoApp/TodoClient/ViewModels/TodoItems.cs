using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TodoClient.ViewModels;

namespace TodoClient
{
    public class TodoItems : ViewModelBase
    {
        ObservableCollection<TodoItem> todos = new ObservableCollection<TodoItem>();

        public TodoItems()
        {
            LoadTodos();
        }

        private async void LoadTodos()
        {
            string url = "https://localhost:7275/api/todoitems";

            HttpClient client = new HttpClient();

            var response = await client.GetFromJsonAsync<List<TodoItem>>(url);

            foreach (var item in response)
            {
                todos.Add(item);
            }

            //for (int i = 0; i < 5; i++)
            //{
            //    TodoItem item = new TodoItem(i, "aaaa", "bbbbbbb" + i, false);
            //    todos.Add(item);
            //}
        }

        public ObservableCollection<TodoItem> Todos
        {
            set { SetProperty(ref todos, value); }
            get { return todos; }
        }

        //protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        //{
        //    if (!Equals(field, newValue))
        //    {
        //        field = newValue;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //        return true;
        //    }

        //    return false;
        //}
    }
}
