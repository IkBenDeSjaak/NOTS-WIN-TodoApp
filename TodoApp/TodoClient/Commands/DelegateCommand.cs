using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoClient.Commands
{
    internal class DelegateCommand : IDelegateCommand
    {
        Action<object> execute;
        Func<object, bool> canExecute;

        public event EventHandler? CanExecuteChanged;

        public DelegateCommand(Action<object> execute)
        {
            this.execute = execute;
            this.canExecute = AlwaysCanExecute;
        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        bool AlwaysCanExecute(object parameter)
        {
            return true;
        }
    }
}
