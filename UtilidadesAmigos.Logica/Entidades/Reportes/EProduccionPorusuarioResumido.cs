using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EProduccionPorusuarioResumido
    {
        public System.Nullable<decimal> IdUsuario { get; set; }

        public string Sucursal { get; set; }

        public string Oficina { get; set; }

        public string Departaemnto { get; set; }

        public string Usuario { get; set; }

        public string Concepto { get; set; }

        public System.Nullable<decimal> Cantidad { get; set; }

        public System.Nullable<decimal> Total { get; set; }

        public System.Nullable<int> TipoMovimiento { get; set; }

        public System.Nullable<decimal> TotalRegistros { get; set; }

        public System.Nullable<decimal> TotalPrima { get; set; }

        public System.Nullable<System.DateTime> FechaDesde { get; set; }

        public System.Nullable<System.DateTime> FechaHasta { get; set; }
    }
}
