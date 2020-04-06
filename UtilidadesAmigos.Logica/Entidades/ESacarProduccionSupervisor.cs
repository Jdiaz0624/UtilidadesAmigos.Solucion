using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class ESacarProduccionSupervisor
    {
        public string Poliza { get; set; }

        public string Estatus { get; set; }

        public System.Nullable<decimal> Prima { get; set; }

        public System.Nullable<decimal> SumaAsegurada { get; set; }

        public string InicioVigencia { get; set; }

        public string FinVigencia { get; set; }

        public int? CodRamo { get; set; }

        public string Ramo { get; set; }

        public int? CodSubRamo { get; set; }

        public string Subramo { get; set; }

        public decimal? CodCliente { get; set; }

        public string Cliente { get; set; }

        public int? CodSupervisor { get; set; }

        public string Supervisor { get; set; }

        public int? CodIntermediario { get; set; }

        public string Intermediario { get; set; }

        public string Fecha { get; set; }

        public System.Nullable<decimal> Valor { get; set; }

        public decimal? Numero { get; set; }

        public string Concepto { get; set; }

        public string CreadoPor { get; set; }

        public System.Nullable<decimal> Facturado { get; set; }

        public System.Nullable<decimal> Cobrado { get; set; }

        public System.Nullable<decimal> Balance { get; set; }

        public System.Nullable<decimal> TotalFacturado { get; set; }
    }
}
