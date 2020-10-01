using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EComisionIntermediarioResumido
    {
        public System.Nullable<decimal> IdUsuario { get; set; }

        public string GeneradoPor { get; set; }

        public string Supervisor { get; set; }

        public System.Nullable<int> CodigoIntermediario { get; set; }

        public string Intermediario { get; set; }

        public string Oficina { get; set; }

        public string NumeroIdentificacion { get; set; }

        public string CuentaBanco { get; set; }

        public string TipoCuenta { get; set; }

        public string Banco { get; set; }

        public string Producto { get; set; }

        public System.Nullable<decimal> MontoBruto { get; set; }

        public System.Nullable<decimal> MontoNeto { get; set; }

        public System.Nullable<decimal> Comision { get; set; }

        public System.Nullable<decimal> Retencion { get; set; }

        public System.Nullable<decimal> AvanceComision { get; set; }

        public System.Nullable<decimal> ALiquidar { get; set; }

        public System.Nullable<System.DateTime> ValidadoDesde { get; set; }

        public string FechaDesde { get; set; }

        public string FechaHasta { get; set; }
    }
}
