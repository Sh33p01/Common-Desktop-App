using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library_Application.ViewModels
{
    internal class ViewModelCommand : ICommand
    {

        private readonly Action<object> _executeAction; //encapsulate a method, i.e pass a method as a parameter
        private readonly Predicate<object> _canExecuteAction; //determine if the action can be executed or not.

        //Constructors
        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }
        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }


        //Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        //Methods
        public bool CanExecute(object parameter)
        {
            return _canExecuteAction == null ? true : _canExecuteAction(parameter);
        }
         
        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
