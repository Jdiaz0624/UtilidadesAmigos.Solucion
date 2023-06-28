using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Correcciones
{
    public class EBuscaInformacionPolizasFianzas
    {
        public string Poliza {get;set;}

        public string Estatus {get;set;}

        public System.Nullable<decimal> SumaAsegurada {get;set;}

        public System.Nullable<decimal> Prima {get;set;}

        public System.Nullable<int> Intermediario {get;set;}

        public string NombreVendedor {get;set;}

        public System.Nullable<decimal> Cliente {get;set;}

        public string NombreCliente {get;set;}

        public string Deudor {get;set;}

        public int Ramo {get;set;}

        public string NombreRamo {get;set;}

        public int SubRamo {get;set;}

        public string NombreSubramo {get;set;}

        public string InicioVigencia {get;set;}

        public string FinVigencia {get;set;}

        public System.Nullable<decimal> Facturado {get;set;}

        public System.Nullable<decimal> Cobrado {get;set;}

        public System.Nullable<decimal> Balance {get;set;}
    }
}
