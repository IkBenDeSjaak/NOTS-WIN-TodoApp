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
        int id;
        string title;
        string description;
        bool isComplete;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Text { get => description; set => description = value; }
        public bool IsCompleted { get => isComplete; set => isComplete = value; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public TodoItem(int id, string title, string description, bool isComplete)
        {
            this.Id = id;
            this.Title = title;
            this.Text = description;
            this.IsCompleted = isComplete;
        }
    }
}
