using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BindingLibrary
{
    public class RelayCommand : ICommand
    {
        private Action<object> _executeHandler;
        private Func<object, bool> _canExecuteHandler;

        public event EventHandler CanExecuteChanged;

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        public RelayCommand(Action<object> executeHandler, Func<object, bool> canExecuteHandler)
        {
            _executeHandler = executeHandler ?? throw new ArgumentNullException("execute handler can not be null");
            _canExecuteHandler = canExecuteHandler ?? throw new ArgumentNullException("canExecute handler can not be null");
        }

        public RelayCommand(Action<object> execute) : this(execute, (x) => true)
        { }

        public bool CanExecute(object parameter)
        {
            return _canExecuteHandler(parameter);
        }

        public void Execute(object parameter)
        {
            _executeHandler(parameter);
        }

        public void RaiseCommand()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
