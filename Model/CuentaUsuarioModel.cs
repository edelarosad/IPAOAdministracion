using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAO.Administracion.Model
{
    public class CuentaUsuarioModel
    {
        public string NombreUsuario { get; set; }
        public string DisplayName { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool CapturaDatos { get; set; }
        public bool Contabilidad { get; set; }
        public bool Configuracion { get; set; }
    }
}
