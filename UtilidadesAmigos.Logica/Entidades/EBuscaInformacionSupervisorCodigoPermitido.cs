using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EBuscaInformacionSupervisorCodigoPermitido
    {
        public int? Codigo { get; set; }

        public string Nombre { get; set; }

        public string Estatus { get; set; }

        public System.Nullable<int> CodigoOficina { get; set; }

        public string Oficina { get; set; }
    }
}
