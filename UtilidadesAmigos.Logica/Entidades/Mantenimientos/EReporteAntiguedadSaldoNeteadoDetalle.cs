using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class EReporteAntiguedadSaldoNeteadoDetalle
    {
        public System.Nullable<decimal> IdUsuario { get; set; }

        public string GeneradoPor { get; set; }

        public System.Nullable<System.DateTime> FechaCorte { get; set; }

        public string FechaCorteFormateado { get; set; }

        public string Asegurado { get; set; }

        public string Asegurado1 { get; set; }

        public System.Nullable<decimal> CodCliente { get; set; }

        public string Intermediario { get; set; }

        public System.Nullable<decimal> CodIntermediario { get; set; }

        public string Poliza { get; set; }

        public System.Nullable<int> CodMoneda { get; set; }

        public string DescripcionMoneda { get; set; }

        public string Estatus { get; set; }

        public System.Nullable<int> CodRamo { get; set; }

        public string Ramo { get; set; }

        public string InicioVigencia { get; set; }

        public System.Nullable<System.DateTime> Inicio { get; set; }

        public string FinVigencia { get; set; }

        public System.Nullable<System.DateTime> Fin { get; set; }

        public System.Nullable<decimal> Facturado { get; set; }

        public System.Nullable<decimal> Cobrado { get; set; }

        public System.Nullable<decimal> Balance { get; set; }

        public System.Nullable<decimal> Impuesto { get; set; }

        public System.Nullable<decimal> ValorComision { get; set; }

        public System.Nullable<decimal> ComisionPendiente { get; set; }

        public System.Nullable<decimal> @__0_30 { get; set; }

        public System.Nullable<decimal> @__31_60 { get; set; }

        public System.Nullable<decimal> @__61_90 { get; set; }

        public System.Nullable<decimal> @__91_120 { get; set; }

        public System.Nullable<decimal> @__121_150 { get; set; }

        public System.Nullable<decimal> @__151_mas { get; set; }

        public System.Nullable<decimal> Total { get; set; }

        public System.Nullable<decimal> TotalPesos { get; set; }

        public System.Nullable<decimal> TasaDollar { get; set; }

        public System.Nullable<decimal> Diferencia { get; set; }
    }
}
