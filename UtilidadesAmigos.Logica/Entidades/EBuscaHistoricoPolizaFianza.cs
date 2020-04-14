using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EBuscaHistoricoPolizaFianza
    {
        public string Poliza {get;set;}

        public string Estatus {get;set;}

        public string Cliente {get;set;}

        public string Intermediario {get;set;}

        public System.Nullable<decimal> Prima {get;set;}

        public System.Nullable<decimal> SumaAsegurada {get;set;}

        public string Ramo {get;set;}

        public string Subramo {get;set;}

        public string Concepto {get;set;}

        public string Fecha {get;set;}

        public System.Nullable<System.DateTime> Fecha0 {get;set;}

        public string Usuario {get;set;}

        public System.Nullable<decimal> Valor {get;set;}

        public System.Nullable<decimal> TotalFacturado {get;set;}

        public System.Nullable<decimal> TotalCobrado {get;set;}

        public System.Nullable<decimal> Balance {get;set;}

        public System.Nullable<int> CantidadRegistros { get; set; }
    }
}
