using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPAO.Administracion.Model;
using IPAO.Administracion.Repositories;

namespace IPAO.Administracion.ViewModel
{
    public class DataCaptureViewModel : ViewModelBase
    {
        #region Propiedades
        private int _CapturaDatosId;
        private int _ClienteId;
        private string _NombreCliente;
        private bool _ServFoliosDigitales;
        private bool _ServContabilidad;
        private bool _ServMicrosip;
        private string _UsuarioFolioDigital;
        private string _PasswordFolioDigital;
        private string _PasswordCiec;
        private string _PasswordFirmaElectronica;
        private DateTime _FechaVigenciaFirmaElectronica;
        private string _PasswordSelloDigital;
        private DateTime _FechaVigenciaSelloDigital;
        private string _TipoUsuario;
        private string _TipoLicencia;
        private string _Version;
        private string _TipoCandado;
        private string _Candado;
        private string _CapacidadPaquete;
        private int _Capacidad;
        private bool _bBancos;
        private int _BancosLicencias;
        private bool _bCompras;
        private int _ComprasLicencias;
        private bool _bContabilidad;
        private int _ContabilidadLicencias;
        private bool _bCuentasCobrar;
        private int _CuentasCobrarLicencias;
        private bool _bCuentasPagar;
        private int _CuentasPagarLicencias;
        private bool _bInventarios;
        private int _InventariosLicencias;
        private bool _bNominas;
        private int _NominasLicencias;
        private bool _bPuntoVenta;
        private int _PuntoVentaLicencias;
        private bool _bVentas;
        private int _VentasLicencias;
        private bool _bAdministra;
        private int _AdministraLicencias;
        private bool _bReplix;
        private int _ReplixLicencias;

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

        public bool ServFoliosDigitales
        {
            get
            {
                return _ServFoliosDigitales;
            }
            set
            {
                _ServFoliosDigitales = value;
                OnPropertyChanged(nameof(ServFoliosDigitales));
            }
        }

        public bool ServContabilidad
        {
            get
            {
                return _ServContabilidad;
            }
            set
            {
                _ServContabilidad = value;
                OnPropertyChanged(nameof(ServContabilidad));
            }
        }
        public bool ServMicrosip
        {
            get
            {
                return _ServMicrosip;
            }
            set
            {
                _ServMicrosip = value;
                OnPropertyChanged(nameof(ServMicrosip));
            }
        }

        public string UsuarioFolioDigital
        {
            get
            {
                return _UsuarioFolioDigital;
            }
            set
            {
                _UsuarioFolioDigital = value;
                OnPropertyChanged(nameof(UsuarioFolioDigital));
            }
        }
        public string PasswordFolioDigital
        {
            get
            {
                return _PasswordFolioDigital;
            }
            set
            {
                _PasswordFolioDigital = value;
                OnPropertyChanged(nameof(PasswordFolioDigital));
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
        public string TipoUsuario
        {
            get
            {
                return _TipoUsuario;
            }
            set
            {
                _TipoUsuario = value;
                OnPropertyChanged(nameof(TipoUsuario));
            }
        }
        public string TipoLicencia 
        {
            get
            {
                return _TipoLicencia;
            }
            set
            {
                _TipoLicencia = value;
                OnPropertyChanged(nameof(TipoLicencia));
            }
        }
        public string Version
        {
            get
            {
                return _Version;
            }
            set
            {
                _Version = value;
                OnPropertyChanged(nameof(Version));
            }
        }
        public string TipoCandado
        {
            get
            {
                return _TipoCandado;
            }
            set
            {
                _TipoCandado = value;
                OnPropertyChanged(nameof(TipoCandado));
            }
        }
        public string Candado 
        {
            get
            {
                return _Candado;
            }
            set
            {
                _Candado = value;
                OnPropertyChanged(nameof(Candado));
            }
        }
        public string CapacidadPaquete
        {
            get
            {
                return _CapacidadPaquete;
            }
            set
            {
                _CapacidadPaquete = value;
                OnPropertyChanged(nameof(CapacidadPaquete));
            }
        }
        public int Capacidad 
        {
            get
            {
                return _Capacidad;
            }
            set
            {
                _Capacidad = value;
                OnPropertyChanged(nameof(Capacidad));
            }
        }
        public bool bBancos 
        {
            get
            {
                return _bBancos;
            }
            set
            {
                _bBancos = value;
                OnPropertyChanged(nameof(bBancos));
            }
        }
        public int BancosLicencias 
        {
            get
            {
                return _BancosLicencias;
            }
            set
            {
                _BancosLicencias = value;
                OnPropertyChanged(nameof(BancosLicencias));
            }
        }
        public bool bCompras 
        {
            get
            {
                return _bCompras;
            }
            set
            {
                _bCompras = value;
                OnPropertyChanged(nameof(bCompras));
            }
        }
        public int ComprasLicencias 
        {
            get
            {
                return _ComprasLicencias;
            }
            set
            {
                _ComprasLicencias = value;
                OnPropertyChanged(nameof(ComprasLicencias));
            }
        }
        public bool bContabilidad
        {
            get
            {
                return _bContabilidad;
            }
            set
            {
                _bContabilidad = value;
                OnPropertyChanged(nameof(bContabilidad));
            }
        }
        public int ContabilidadLicencias
        {
            get
            {
                return _ContabilidadLicencias;
            }
            set
            {
                _ContabilidadLicencias = value;
                OnPropertyChanged(nameof(ContabilidadLicencias));
            }
        }
        public bool bCuentasCobrar
        {
            get
            {
                return _bCuentasCobrar;
            }
            set
            {
                _bCuentasCobrar = value;
                OnPropertyChanged(nameof(bCuentasCobrar));
            }
        }
        public int CuentasCobrarLicencias 
        {
            get
            {
                return _CuentasCobrarLicencias;
            }
            set
            {
                _CuentasCobrarLicencias = value;
                OnPropertyChanged(nameof(CuentasCobrarLicencias));
            }
        }
        public bool bCuentasPagar
        {
            get
            {
                return _bCuentasPagar;
            }
            set
            {
                _bCuentasPagar = value;
                OnPropertyChanged(nameof(bCuentasPagar));
            }
        }
        public int CuentasPagarLicencias
        {
            get
            {
                return _CuentasPagarLicencias;
            }
            set
            {
                _CuentasPagarLicencias = value;
                OnPropertyChanged(nameof(CuentasPagarLicencias));
            }
        }
        public bool bInventarios 
        {
            get
            {
                return _bInventarios;
            }
            set
            {
                _bInventarios = value;
                OnPropertyChanged(nameof(bInventarios));
            }
        }
        public int InventariosLicencias 
        {
            get
            {
                return _InventariosLicencias;
            }
            set
            {
                _InventariosLicencias = value;
                OnPropertyChanged(nameof(InventariosLicencias));
            }
        }
        public bool bNominas
        {
            get
            {
                return _bNominas;
            }
            set
            {
                _bNominas = value;
                OnPropertyChanged(nameof(bNominas));
            }
        }
        public int NominasLicencias 
        {
            get
            {
                return _NominasLicencias;
            }
            set
            {
                _NominasLicencias = value;
                OnPropertyChanged(nameof(NominasLicencias));
            }
        }
        public bool bPuntoVenta 
        {
            get
            {
                return _bPuntoVenta;
            }
            set
            {
                _bPuntoVenta = value;
                OnPropertyChanged(nameof(bPuntoVenta));
            }
        }
        public int PuntoVentaLicencias 
        {
            get
            {
                return _PuntoVentaLicencias;
            }
            set
            {
                _PuntoVentaLicencias = value;
                OnPropertyChanged(nameof(PuntoVentaLicencias));
            }
        }
        public bool bVentas 
        {
            get
            {
                return _bVentas;
            }
            set
            {
                _bVentas = value;
                OnPropertyChanged(nameof(bVentas));
            }
        }
        public int VentasLicencias
        {
            get
            {
                return _VentasLicencias;
            }
            set
            {
                _VentasLicencias = value;
                OnPropertyChanged(nameof(VentasLicencias));
            }
        }
        public bool bAdministra
        {
            get
            {
                return _bAdministra;
            }
            set
            {
                _bAdministra = value;
                OnPropertyChanged(nameof(bAdministra));
            }
        }
        public int AdministraLicencias
        {
            get
            {
                return _AdministraLicencias;
            }
            set
            {
                _AdministraLicencias = value;
                OnPropertyChanged(nameof(AdministraLicencias));
            }
        }
        public bool bReplix
        {
            get
            {
                return _bReplix;
            }
            set
            {
                _bReplix = value;
                OnPropertyChanged(nameof(bReplix));
            }
        }
        public int ReplixLicencias
        {
            get
            {
                return _ReplixLicencias;
            }
            set
            {
                _ReplixLicencias = value;
                OnPropertyChanged(nameof(ReplixLicencias));
            }
        }
        #endregion

        private IGenericRepository genericRepository;
        public DataCaptureViewModel()
        {
            genericRepository = new GenericRepository();
        }

        public List<string> GetAllClientsCombobox()
        {
            var lstClients = genericRepository.GetAllClientsCombobox();
            return lstClients;
        }

        public DataCaptureViewModel GetClientByName(string name)
        {
            DataCaptureViewModel cliente = new DataCaptureViewModel();
            cliente = genericRepository.GetClientByName(name);

            return cliente;
        }
    }
}
