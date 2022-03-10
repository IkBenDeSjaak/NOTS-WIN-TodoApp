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
using TodoClient.Commands;
using TodoClient.ViewModels;

namespace TodoClient
{
    public class TodoItems : ViewModelBase
    {
        ObservableCollection<TodoItem> todos = new();
        TodoItem newTodoItem = new();
        string errorMessage = string.Empty;

        // IDelegateCommand implementation
        public IDelegateCommand CreateTodoCommand { protected set; get; }
        public IDelegateCommand DeleteTodoCommand { protected set; get; }
        public IDelegateCommand MarkAsCompleteCommand { protected set; get; }

        public TodoItems()
        {
            CreateTodoCommand = new DelegateCommand(ExecuteCreateTodo);
            MarkAsCompleteCommand = new DelegateCommand(ExecuteMarkTodoAsComplete);
            DeleteTodoCommand = new DelegateCommand(ExecuteDeleteTodo);

            LoadTodos();
        }

        public ObservableCollection<TodoItem> Todos
        {
            get { return todos; }
            set { SetProperty(ref todos, value); }
        }

        public TodoItem NewTodoItem
        {
            get { return newTodoItem; }
            set { SetProperty(ref newTodoItem, value); }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private async void LoadTodos()
        {
            string url = "https://localhost:7275/api/todoitems";

            HttpClient client = new();

            try
            {
                var response = await client.GetFromJsonAsync<List<TodoItem>>(url);

                if (response != null)
                {
                    foreach (var item in response)
                    {
                        todos.Add(item);
                    }
                }
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("dsdasd");
                ErrorMessage = "Something went wrong while loading todos.";
            }
        }

        async void ExecuteCreateTodo(object parameter)
        {
            string url = "https://localhost:7275/api/todoitems";

            HttpClient client = new();

            try
            {
                var response = await client.PostAsJsonAsync(url, newTodoItem);

                if (response.IsSuccessStatusCode)
                {
                    newTodoItem.Title = "";
                    newTodoItem.Description = "";

                    var newTodo = await client.GetFromJsonAsync<TodoItem>(response.Headers.Location);

                    if (newTodo != null)
                    {
                        todos.Add(newTodo);
                    }
                }
            }
            catch (HttpRequestException)
            {
                ErrorMessage = "Something went wrong while adding new todo to the database.";
            }
        }

        async void ExecuteMarkTodoAsComplete(object parameter)
        {

            string url = "https://localhost:7275/api/todoitems/" + (int)parameter;

            TodoItem todoItem = todos.First((item) => item.Id == (int)parameter);
            todoItem.IsComplete = true;

            HttpClient client = new();

            try
            {
                var response = await client.PutAsJsonAsync(url, todoItem);
            }
            catch (HttpRequestException)
            {
                ErrorMessage = "Something went wrong while changing true to false.";
            }
        }

        async void ExecuteDeleteTodo(object parameter)
        {
            string url = "https://localhost:7275/api/todoitems/" + (int)parameter;

            HttpClient client = new HttpClient();

            try
            {
                var response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    TodoItem todoItem = todos.First((item) => item.Id == (int)parameter);

                    todos.Remove(todoItem);
                }
            }
            catch (HttpRequestException)
            {
                ErrorMessage = "Something went wrong while trying to delete todo.";
            }
        }
    }
}
