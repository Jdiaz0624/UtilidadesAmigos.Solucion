using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class ECadenaIntermediarioDetalle
    {
        public System.Nullable<int> Compania { get; set; }

        public System.Nullable<int> IdIntermediario { get; set; }

        public System.Nullable<int> IdIntermediarioSupervisa { get; set; }

        public string UsuarioAdiciona { get; set; }

        public System.Nullable<System.DateTime> FechaAdiciona { get; set; }
    }
}
