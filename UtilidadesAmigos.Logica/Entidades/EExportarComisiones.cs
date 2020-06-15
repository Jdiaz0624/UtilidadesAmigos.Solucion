using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EExportarComisiones
    {
        public System.Nullable<decimal> CodigoIntermediario {get;set;}

        public System.Nullable<System.DateTime> FechaDesde0 {get;set;}

        public System.Nullable<System.DateTime> FechaHasta0 {get;set;}

        public string FechaDesde {get;set;}

        public string FechaHasta {get;set;}

        public string Intermediario {get;set;}

        public string Oficina {get;set;}

        public string NumeroIdentificacion {get;set;}

        public string CuentaBanco {get;set;}

        public string TipoCuenta {get;set;}

        public string Banco {get;set;}

        public System.Nullable<int> Cantidad {get;set;}

        public System.Nullable<decimal> Bruto {get;set;}

        public System.Nullable<decimal> Neto {get;set;}

        public System.Nullable<decimal> ComisionBruta {get;set;}

        public System.Nullable<decimal> Retencion {get;set;}

        public System.Nullable<decimal> AvanceComision {get;set;}

        public System.Nullable<decimal> ALiquidar {get;set;}
    }
}
