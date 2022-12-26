using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FontAwesome.Sharp;
using IPAO.Administracion.Model;
using IPAO.Administracion.Repositories;

namespace IPAO.Administracion.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private CuentaUsuarioModel _cuentaActualUsuario;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        private IUsuarioRepository usuarioRepository;

        public CuentaUsuarioModel CuentaActualUsuario
        {
            get
            {
                return _cuentaActualUsuario;
            }

            set
            {
                _cuentaActualUsuario = value;
                OnPropertyChanged(nameof(CuentaActualUsuario));
            }
        }

        public ViewModelBase CurrentChildView 
        {
            get
            {
                return _currentChildView;
            }

            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }

            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        //--> Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowClienteViewCommand { get; }
        public ICommand ShowDataCaptureViewCommand { get; }

        public MainViewModel()
        {
            usuarioRepository = new UsuarioRepository();
            CuentaActualUsuario = new CuentaUsuarioModel();

            //Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowClienteViewCommand = new ViewModelCommand(ExecuteShowClienteViewCommand);
            ShowDataCaptureViewCommand = new ViewModelCommand(ExecuteShowDataCaptureViewCommand);

            //Default view
            ExecuteShowHomeViewCommand(null);

            LoadCurrentUserData();

        }

        private void ExecuteShowDataCaptureViewCommand(object obj)
        {
            CurrentChildView = new DataCaptureViewModel();
            Caption = "Captura de datos";
            Icon = IconChar.Keyboard;
        }

        public void ExecuteShowClienteViewCommand(object obj)
        {
            CurrentChildView = new ClienteViewModel();
            Caption = "Clientes";
            Icon = IconChar.User;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private void LoadCurrentUserData()
        {
            var user = usuarioRepository.GetByUserName(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {

                CuentaActualUsuario.NombreUsuario = user.NombreUsuario;
                CuentaActualUsuario.DisplayName = $"Bienvenido {user.Nombre}";
                CuentaActualUsuario.ProfilePicture = null;
            }
            else
            {
                CuentaActualUsuario.DisplayName = "Usuario invalido, no se ha logeado";
            }
        }

    }
}
