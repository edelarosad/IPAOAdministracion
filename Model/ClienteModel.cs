using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAO.Administracion.Model
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Rfc { get; set; }
        public string TipoPersona { get; set; }
        public string RegimenFiscal { get; set; }
        public bool ServFoliosDigitales { get; set; }
        public bool ServContabilidad { get; set; }
        public bool ServMicrosip { get; set; }
        public string NombreContacto { get; set; }
        public string EmailContacto { get; set; }
        public string TelefonoContacto { get; set; }
        public bool bActivo { get; set; }
    }
}
