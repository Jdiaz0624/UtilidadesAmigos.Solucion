using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class EConsultarAntiguedadSaldos
    {
        public string Documento { get; set; }

        public decimal? NumeroFacturaFiltro { get; set; }

        public int? Tipo { get; set; }

        public string DescripcionTipo { get; set; }

        public string Asegurado { get; set; }

        public System.Nullable<decimal> ClienteFiltro { get; set; }

        public string Fecha { get; set; }

        public string Intermediario { get; set; }

        public System.Nullable<int> VendedorFiltro { get; set; }

        public string Poliza { get; set; }

        public System.Nullable<int> CodMoneda { get; set; }

        public string DescripcionMoneda { get; set; }

        public string Estatus { get; set; }

        public System.Nullable<int> CodRamo { get; set; }

        public string DescripcionRamo { get; set; }

        public string InicioVigencia { get; set; }

        public System.Nullable<System.DateTime> Inicio { get; set; }

        public string FinVigencia { get; set; }

        public System.Nullable<System.DateTime> Fin { get; set; }

        public System.Nullable<int> CodOficina { get; set; }

        public string Oficina { get; set; }

        public System.Nullable<int> Dias { get; set; }

        public System.Nullable<decimal> Facturado { get; set; }

        public System.Nullable<decimal> Cobrado { get; set; }

        public System.Nullable<decimal> Balance { get; set; }

        public System.Nullable<decimal> Impuesto { get; set; }

        public System.Nullable<decimal> PorcComision { get; set; }

        public System.Nullable<decimal> ValorComision { get; set; }

        public System.Nullable<decimal> ComisionPendiente { get; set; }

        public System.Nullable<decimal> @__0_10 { get; set; }

        public System.Nullable<decimal> @__0_30 { get; set; }

        public System.Nullable<decimal> @__31_60 { get; set; }

        public System.Nullable<decimal> @__61_90 { get; set; }

        public System.Nullable<decimal> @__91_120 { get; set; }

        public System.Nullable<decimal> @__121_150 { get; set; }

        public System.Nullable<decimal> @__151_MAS { get; set; }

        public System.Nullable<decimal> Total { get; set; }

        public System.Nullable<decimal> Diferencia { get; set; }

        public System.Nullable<int> OrdenTipo { get; set; }
    }
}
