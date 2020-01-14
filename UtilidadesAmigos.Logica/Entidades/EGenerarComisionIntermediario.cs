using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EGenerarComisionIntermediario
    {
        public string Supervisor {get;set;}

        public string Intermediario {get;set;}

        public string Cliente {get;set;}

        public string Recibo {get;set;}

        public string Fecha {get;set;}

        public string Factura {get;set;}

        public string FechaFactura {get;set;}

        public string Moneda {get;set;}

        public string Poliza {get;set;}

        public string Producto {get;set;}

        public System.Nullable<decimal> Bruto {get;set;}

        public System.Nullable<decimal> Neto {get;set;}

        public System.Nullable<decimal> PorcientoComision {get;set;}

        public System.Nullable<decimal> Comision {get;set;}

        public System.Nullable<decimal> Retencion {get;set;}

        public System.Nullable<decimal> AvanceComision {get;set;}

        public System.Nullable<decimal> ALiquidar {get;set;}
    }
}
