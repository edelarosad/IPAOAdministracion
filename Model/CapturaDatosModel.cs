using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAO.Administracion.Model
{
    public class CapturaDatosModel
    {
        public int CapturaDatosId { get; set; }
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public string UsuarioFolioDigital { get; set; }
        public string PasswordFolioDigital { get; set; }
        public string PasswordCiec { get; set; }
        public string PasswordFirmaElectronica { get; set; }
        public DateTime FechaVigenciaFirmaElectronica { get; set; }
        public string PasswordSelloDigital { get; set; }
        public DateTime FechaVigenciaSelloDigital { get; set; }
        public string TipoUsuario { get; set; }
        public string TipoLicencia { get; set; }
        public string Version { get; set; }
        public string TipoCandado { get; set; }
        public string Candado { get; set; }
        public string CapacidadPaquete { get; set; }
        public int Capacidad { get; set; }
        public bool bBancos { get; set; }
        public int BancosLicencias { get; set; }
        public bool bCompras { get; set; }
        public int ComprasLicencias { get; set; }
        public bool bContabilidad { get; set; }
        public int ContabilidadLicencias { get; set; }
        public bool bCuentasCobrar { get; set; }
        public int CuentasCobrarLicencias { get; set; }
        public bool bCuentasPagar { get; set; }
        public int CuentasPagarLicencias { get; set; }
        public bool bInvetarios { get; set; }
        public int InventariosLicencias { get; set; }
        public bool bNominas { get; set; }
        public int NominasLicencias { get; set; }
        public bool bPuntoVenta { get; set; }
        public int PuntoVentaLicencias { get; set; }
        public bool bVentas { get; set; }
        public int VentasLicencias { get; set; }
        public bool bAdministra { get; set; }
        public int AdministraLicencias { get; set; }
        public bool bReplix { get; set; }
        public int ReplixLicencias { get; set; }
    }
}
