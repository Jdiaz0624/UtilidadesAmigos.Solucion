using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EProduccionPorUsuarioDetalle
    {
        public System.Nullable<decimal> IdUsuario { get; set; }

        public System.Nullable<System.DateTime> FechaDesde { get; set; }

        public System.Nullable<System.DateTime> FechaHasta { get; set; }

        public string Sucursal { get; set; }

        public string Oficina { get; set; }

        public string Departamento { get; set; }

        public string Usuario { get; set; }

        public string Concepto { get; set; }

        public string Poliza { get; set; }

        public System.Nullable<decimal> Monto { get; set; }

        public System.Nullable<decimal> TotalRegistros { get; set; }

        public System.Nullable<decimal> TotalValor { get; set; }
    }
}
