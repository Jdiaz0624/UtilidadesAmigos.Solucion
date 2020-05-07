using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador
{
    public class ECorreosEnviar
    {
        public System.Nullable<decimal> IdCorreoEnviar { get; set; }

        public System.Nullable<decimal> IdProceso { get; set; }

        public string ProcesoCorreo { get; set; }

        public string Correo { get; set; }

        public System.Nullable<bool> Estatus0 { get; set; }

        public string Estatus { get; set; }
    }
}
