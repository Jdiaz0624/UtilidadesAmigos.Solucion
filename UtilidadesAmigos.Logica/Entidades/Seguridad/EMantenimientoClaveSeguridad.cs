using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Seguridad
{
    public class EMantenimientoClaveSeguridad
    {
        public System.Nullable<decimal> IdClaveSeguridad { get; set; }

        public System.Nullable<decimal> IdUsuario { get; set; }

        public string Clave { get; set; }

        public System.Nullable<bool> Estatus { get; set; }
    }
}
