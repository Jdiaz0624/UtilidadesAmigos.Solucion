using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EProcesarDatosReporteIntermediairoInterno
    {
        public System.Nullable<decimal> IdUsuario { get; set; }

        public string Ramo { get; set; }

        public string Oficina { get; set; }

        public string Intermediario { get; set; }

        public System.Nullable<decimal> PorcientoComision { get; set; }

        public string RNC { get; set; }

        public string Cuenta { get; set; }

        public string Tipo { get; set; }

        public string Banco { get; set; }

        public System.Nullable<decimal> Bruto { get; set; }

        public System.Nullable<decimal> Neto { get; set; }

        public System.Nullable<decimal> Comision { get; set; }

        public System.Nullable<decimal> Retencion { get; set; }

        public System.Nullable<decimal> Avance { get; set; }

        public System.Nullable<decimal> APagar { get; set; }

        public System.Nullable<System.DateTime> FechaDesde { get; set; }

        public System.Nullable<System.DateTime> FechaHasta { get; set; }
    }
}
