using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library_Application.ViewModels
{
    internal class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisable = true;

        //Properties
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(password));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisable
        {
            get
            {
                return IsViewVisable;
            }
            set
            {
                _isViewVisable = value;
                OnPropertyChanged(nameof(IsViewVisable));
            }
        }

        //-> Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }
        

        //Constructors
        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
        }


        private bool CanExecuteLoginCommand(object obj)
        {
            bool validDate;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || password == null || password.Length < 3)
                validDate = false;    //if the username or password field is null, has blank spaces or charater length is less than 3
            else                     // we throw an error message saying the data entered is not valid and the command should not be executed
                validDate = true;
            return validDate;     
        }

        private void ExecuteLoginCommand(object obj)
        {
            
        }

        private void ExecuteRecoverPassCommand( string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}
