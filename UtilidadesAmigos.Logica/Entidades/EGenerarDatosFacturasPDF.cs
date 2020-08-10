using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EGenerarDatosFacturasPDF
    {
        public System.Nullable<decimal> IdComprobante {get;set;}

        public string Comprobante {get;set;}

        public string ComprobanteAfectado {get;set;}

        public string DescripcionComprobante {get;set;}

        public System.DateTime FechaVencimiento0 {get;set;}

        public string FechaVencimiento {get;set;}

        public decimal NumeroFactura {get;set;}

        public string Oficina {get;set;}

        public string Deudor {get;set;}

        public string Direccion {get;set;}

        public string Asegurado {get;set;}

        public string Comunicacion {get;set;}

        public string Cedula {get;set;}

        public string Intermediario {get;set;}

        public string DireccionIntermediario {get;set;}

        public string ComunicacionIntermediario {get;set;}

        public string Supervisor {get;set;}

        public string Concepto {get;set;}

        public string InicioVigencia {get;set;}

        public string FinVigencia {get;set;}

        public string FechaProceso {get;set;}

        public string Poliza {get;set;}

        public System.Nullable<decimal> SumaAsegurada {get;set;}

        public System.Nullable<decimal> SubTotal {get;set;}

        public System.Nullable<decimal> ISC {get;set;}

        public System.Nullable<decimal> Total {get;set;}

        public System.Nullable<decimal> Tasa {get;set;}

        public string PieNota {get;set;}

        public string DireccionCompania {get;set;}
        public System.Nullable<int> CantidadRegistros { get; set; }
    }
}
