using IPAO.Administracion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPAO.Administracion.Repositories;

namespace IPAO.Administracion.ViewModel
{
    public class DataCaptureAccountingViewModel : ViewModelBase
    {
        #region Propiedades
        private int _CapturaDatosId;
        private int _ClienteId;
        private string _NombreCliente;
        private string _PasswordCiec;
        private string _PasswordFirmaElectronica;
        private DateTime _FechaVigenciaFirmaElectronica;
        private string _PasswordSelloDigital;
        private DateTime _FechaVigenciaSelloDigital;
        private string _RegistroPatronal;
        private string _UsuarioIDSE;
        private string _PasswordIDSE;
        private string _UsuarioSIPARE;
        private string _PasswordSIPARE;
        private string _EmailISN;
        private string _UsuarioISN;
        private string _PasswordISN;
        private string _EmailINFONAVIT;
        private string _UsuarioINFONAVIT;
        private string _PasswordINFONAVIT;

        public int CapturaDatosId
        {
            get { return _CapturaDatosId; }
            set
            {
                _CapturaDatosId = value;
                OnPropertyChanged(nameof(CapturaDatosId));

            }
        }
        public int ClienteId
        {
            get
            {
                return _ClienteId;
            }
            set
            {
                _ClienteId = value;
                OnPropertyChanged(nameof(ClienteId));
            }
        }
        public string NombreCliente
        {
            get
            {
                return _NombreCliente;
            }
            set
            {
                _NombreCliente = value;
                OnPropertyChanged(nameof(NombreCliente));
            }
        }

        public string PasswordCiec
        {
            get
            {
                return _PasswordCiec;
            }
            set
            {
                _PasswordCiec = value;
                OnPropertyChanged(nameof(PasswordCiec));
            }
        }
        public string PasswordFirmaElectronica
        {
            get
            {
                return _PasswordFirmaElectronica;
            }
            set
            {
                _PasswordFirmaElectronica = value;
                OnPropertyChanged(nameof(PasswordFirmaElectronica));
            }
        }
        public DateTime FechaVigenciaFirmaElectronica
        {
            get
            {
                return _FechaVigenciaFirmaElectronica;
            }
            set
            {
                _FechaVigenciaFirmaElectronica = value;
                OnPropertyChanged(nameof(FechaVigenciaFirmaElectronica));
            }
        }
        public string PasswordSelloDigital
        {
            get
            {
                return _PasswordSelloDigital;
            }
            set
            {
                _PasswordSelloDigital = value;
                OnPropertyChanged(nameof(PasswordSelloDigital));
            }
        }
        public DateTime FechaVigenciaSelloDigital
        {
            get
            {
                return _FechaVigenciaSelloDigital;
            }
            set
            {
                _FechaVigenciaSelloDigital = value;
                OnPropertyChanged(nameof(FechaVigenciaSelloDigital));
            }
        }
        public string RegistroPatronal
        {
            get
            {
                return _RegistroPatronal;
            }
            set
            {
                _RegistroPatronal = value;
                OnPropertyChanged(nameof(RegistroPatronal));
            }
        }
        public string UsuarioIDSE
        {
            get
            {
                return _UsuarioIDSE;
            }
            set
            {
                _UsuarioIDSE = value;
                OnPropertyChanged(nameof(UsuarioIDSE));
            }
        }
        public string PasswordIDSE
        {
            get
            {
                return _PasswordIDSE;
            }
            set
            {
                _PasswordIDSE = value;
                OnPropertyChanged(nameof(PasswordIDSE));
            }
        }
        public string UsuarioSIPARE
        {
            get
            {
                return _UsuarioSIPARE;
            }
            set
            {
                _UsuarioSIPARE = value;
                OnPropertyChanged(nameof(UsuarioSIPARE));
            }
        }
        public string PasswordSIPARE
        {
            get
            {
                return _PasswordSIPARE;
            }
            set
            {
                _PasswordSIPARE = value;
                OnPropertyChanged(nameof(PasswordSIPARE));
            }
        }
        public string EmailISN
        {
            get
            {
                return _EmailISN;
            }
            set
            {
                _EmailISN = value;
                OnPropertyChanged(nameof(EmailISN));
            }
        }
        public string UsuarioISN
        {
            get
            {
                return _UsuarioISN;
            }
            set
            {
                _UsuarioISN = value;
                OnPropertyChanged(nameof(UsuarioISN));
            }
        }
        public string PasswordISN
        {
            get
            {
                return _PasswordISN;
            }
            set
            {
                _PasswordISN = value;
                OnPropertyChanged(nameof(PasswordISN));
            }
        }
        public string EmailINFONAVIT
        {
            get
            {
                return _EmailINFONAVIT;
            }
            set
            {
                _EmailINFONAVIT = value;
                OnPropertyChanged(nameof(EmailINFONAVIT));
            }
        }
        public string UsuarioINFONAVIT
        {
            get
            {
                return _UsuarioINFONAVIT;
            }
            set
            {
                _UsuarioINFONAVIT = value;
                OnPropertyChanged(nameof(UsuarioINFONAVIT));
            }
        }
        public string PasswordINFONAVIT
        {
            get
            {
                return _PasswordINFONAVIT;
            }
            set
            {
                _PasswordINFONAVIT = value;
                OnPropertyChanged(nameof(PasswordINFONAVIT));
            }
        }
        #endregion

        private IGenericRepository genericRepository;

        public DataCaptureAccountingViewModel()
        {
            genericRepository = new GenericRepository();
        }

        public List<string> GetAllClientsCombobox()
        {
            var lstClients = genericRepository.GetAllClientsCombobox();
            return lstClients;
        }

        public DataCaptureAccountingViewModel GetClientByNameAccounting(string name)
        {
            DataCaptureAccountingViewModel cliente = new DataCaptureAccountingViewModel();
            cliente = genericRepository.GetClientByNameAccounting(name);

            return cliente;
        }
    }
}
