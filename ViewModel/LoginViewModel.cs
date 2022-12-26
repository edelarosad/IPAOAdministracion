using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Windows.Input;
using IPAO.Administracion.Model;
using IPAO.Administracion.Repositories;
using System.Threading;
using System.Security.Principal;

namespace IPAO.Administracion.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _nombreusuario;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUsuarioRepository usuarioRepository;

        public string Nombreusuario
        {
            get
            {
                return _nombreusuario;
            }

            set
            {
                _nombreusuario = value;
                OnPropertyChanged(nameof(Nombreusuario));
            }
        }
        public SecureString Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
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
        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }

            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        // -> Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        public LoginViewModel()
        {
            usuarioRepository = new UsuarioRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("",""));
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if(string.IsNullOrWhiteSpace(Nombreusuario) || Nombreusuario.Length < 3 || Password == null || Password.Length < 3)
            {
                validData = false;
            }
            else
            {
                validData = true;
            }

            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = usuarioRepository.AuthenticateUser(new System.Net.NetworkCredential(Nombreusuario, Password));
            if(isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Nombreusuario), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Usuario o Password invalido.";
            }
        }

        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}
