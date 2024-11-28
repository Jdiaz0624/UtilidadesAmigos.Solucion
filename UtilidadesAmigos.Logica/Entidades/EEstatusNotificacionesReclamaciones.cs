using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EEstatusNotificacionesReclamaciones
    {
        public int? IdRegistro { get; set; }

        public System.Nullable<int> IdEstatus { get; set; }

        public string NombreEstatus { get; set; }

        public System.Nullable<int> DiasNotificacion { get; set; }

        public System.Nullable<bool> Estatus0 { get; set; }

        public string Estatus { get; set; }

        public System.Nullable<int> CantidadPolias { get; set; }

        public System.Nullable<int> ANotificar { get; set; }
    }
}
