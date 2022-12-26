using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPAO.Administracion.Model;
using IPAO.Administracion.Repositories;
using System.Collections;
using System.Windows.Input;
using FontAwesome.Sharp;

namespace IPAO.Administracion.ViewModel
{
    public class ClienteViewModel : ViewModelBase
    {
        #region Propiedades
        private int _clienteId;
        private string _nombrecliente;
        private string _direccion;
        private string _telefono;
        private string _email;
        private string _rfc;
        private string _tipopersona;
        private string _regimenfiscal;
        private string _foliosdigitales;
        private string _contabilidad;
        private string _microsip;
        private string _informacioncontacto;

        private IGenericRepository genericRepository;

        public int ClienteId
        {
            get
            {
                return _clienteId;
            }

            set
            {
                _clienteId = value;
                OnPropertyChanged(nameof(ClienteId));
            }
        }
        public string Nombrecliente
        {
            get
            {
                return _nombrecliente;
            }

            set
            {
                _nombrecliente = value;
                OnPropertyChanged(nameof(Nombrecliente));
            }
        }
        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                _direccion = value;
                OnPropertyChanged(nameof(Direccion));
            }
        }
        public string Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
                OnPropertyChanged(nameof(Telefono));
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Rfc
        {
            get
            {
                return _rfc;
            }
            set
            {
                _rfc = value;
                OnPropertyChanged(nameof(Rfc));
            }
        }
        public string Tipopersona
        {
            get
            {
                return _tipopersona;
            }

            set
            {
                _tipopersona = value;
                OnPropertyChanged(nameof(Tipopersona));
            }
        }
        public string Regimenfiscal
        {
            get
            {
                return _regimenfiscal;
            }

            set
            {
                _regimenfiscal = value;
                OnPropertyChanged(nameof(Regimenfiscal));
            }
        }
        public string Foliosdigitales
        {
            get
            {
                return _foliosdigitales;
            }
            set
            {
                _foliosdigitales = value;
                OnPropertyChanged(nameof(Foliosdigitales));
            }
        }
        public string Contabilidad
        {
            get
            {
                return _contabilidad;
            }
            set
            {
                _contabilidad = value;
                OnPropertyChanged(nameof(Contabilidad));
            }
        }
        public string Microsip
        {
            get
            {
                return _microsip;
            }
            set
            {
                _microsip = value;
                OnPropertyChanged(nameof(Microsip));
            }
        }
        public string Informacioncontacto
        {
            get
            {
                return _informacioncontacto;
            }

            set
            {
                _informacioncontacto = value;
                OnPropertyChanged(nameof(Informacioncontacto));
            }
        }

        #endregion

        public ClienteViewModel()
        {
            genericRepository = new GenericRepository();
        }


        public List<ClienteViewModel> GetAllClients()
        {
            genericRepository = new GenericRepository();
            List<ClienteViewModel> lstClientes = new List<ClienteViewModel>();
            lstClientes = genericRepository.GetAllClients();

            return lstClientes;
        }

        public bool DeleteClientById(int id)
        {
            genericRepository = new GenericRepository();
            var delete = genericRepository.RemoveClient(id);

            return delete;
        }

        public ClienteModel GetClientByName(string name)
        {
            ClienteModel cliente = new ClienteModel();
            cliente = genericRepository.GetClientByName(name);

            return cliente;
        }
    }
}
