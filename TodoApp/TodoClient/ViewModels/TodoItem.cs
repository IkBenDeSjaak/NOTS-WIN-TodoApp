using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoClient.ViewModels;

namespace TodoClient
{
    public class TodoItem : ViewModelBase
    {
        int id;
        string title;
        string description;
        bool isComplete;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public bool IsCompleted { get => isComplete; set => isComplete = value; }
    }
}
