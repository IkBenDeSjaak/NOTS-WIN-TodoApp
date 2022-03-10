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
        private int _id;
        private string _title;
        private string _description;
        private bool _isComplete;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                SetProperty(ref _id, value);
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                SetProperty(ref _description, value);
            }
        }

        public bool IsComplete
        {
            get
            {
                return _isComplete;
            }
            set
            {
                SetProperty(ref _isComplete, value);
            }
        }
    }
}
