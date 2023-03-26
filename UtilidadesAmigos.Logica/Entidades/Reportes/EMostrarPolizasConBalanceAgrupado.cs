using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EMostrarPolizasConBalanceAgrupado
    {
        public System.Nullable<decimal> IdUsuario { get; set; }

        public System.Nullable<int> CodigoAgrupacion { get; set; }

        public string NombreAgrupacion { get; set; }

        public string OficinaFiltro { get; set; }

        public string Motores { get; set; }

        public string CortadoA { get; set; }

        public string GeneradoPor { get; set; }

        public string TipoReporteGenerado { get; set; }

        public System.Nullable<int> TipoReporteGenerar { get; set; }

        public string TituloReporte { get; set; }

        public string NombreColumna { get; set; }

        public System.Nullable<decimal> Facturado { get; set; }

        public System.Nullable<decimal> Cobrado { get; set; }

        public System.Nullable<decimal> Balance { get; set; }
    }
}
