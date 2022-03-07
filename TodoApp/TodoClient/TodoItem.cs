using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoClient
{
    internal class TodoItem : INotifyPropertyChanged
    {
        string title;
        string text;
        bool isCompleted;

        public string Title { get => title; set => title = value; }
        public string Text { get => text; set => text = value; }
        public bool IsCompleted { get => isCompleted; set => isCompleted = value; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public TodoItem(string title, string text, bool isCompleted)
        {
            this.Title = title;
            this.Text = text;
            this.IsCompleted = isCompleted;
        }
    }
}
