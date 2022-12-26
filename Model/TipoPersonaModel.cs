using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAO.Administracion.Model
{
    public class TipoPersonaModel
    {
        public int TipoPersonaId { get; set; }
        public string Descripcion { get; set; }
        public bool bActivo { get; set; }
    }
}
