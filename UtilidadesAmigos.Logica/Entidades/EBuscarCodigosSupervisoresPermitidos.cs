using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EBuscarCodigosSupervisoresPermitidos
    {
        public decimal? IdRegistro { get; set; }

        public System.Nullable<decimal> CodigoSupervisor { get; set; }

        public string Nombre { get; set; }

        public System.Nullable<int> CodigoOficina { get; set; }

        public string Oficina { get; set; }

        public System.Nullable<System.DateTime> FechaAgregado0 { get; set; }

        public string FechaAgregado { get; set; }

        public System.Nullable<decimal> IdUsuario { get; set; }

        public string CreadoPor { get; set; }
    }
}
