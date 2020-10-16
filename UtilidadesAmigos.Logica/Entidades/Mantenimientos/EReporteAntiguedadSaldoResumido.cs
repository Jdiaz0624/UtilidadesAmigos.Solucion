using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class EReporteAntiguedadSaldoResumido
    {
        public System.Nullable<int> CodMoneda { get; set; }
        public string FechaCorte { get; set; }

        public string DescripcionMoneda { get; set; }

        public string Ramo { get; set; }

        public System.Nullable<int> CodRamo { get; set; }

        public System.Nullable<int> CantidadFactura { get; set; }

        public System.Nullable<int> CantidadCreditos { get; set; }

        public System.Nullable<int> CantidadPrimaDeposito { get; set; }

        public System.Nullable<int> CantidadRegistros { get; set; }

        public System.Nullable<decimal> Balance { get; set; }

        public System.Nullable<decimal> @__0_30 { get; set; }

        public System.Nullable<decimal> @__31_60 { get; set; }

        public System.Nullable<decimal> @__61_90 { get; set; }

        public System.Nullable<decimal> @__91_120 { get; set; }

        public System.Nullable<decimal> @__121_150 { get; set; }

        public System.Nullable<decimal> @__151_Mas { get; set; }

        public System.Nullable<decimal> Total { get; set; }

        public string GeneradoPor { get; set; }

        public System.Nullable<decimal> TotalPesos { get; set; }
    }
}
