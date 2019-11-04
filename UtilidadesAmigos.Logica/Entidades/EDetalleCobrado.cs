using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EDetalleCobrado
    {
        public string Usuario {get;set;}

        public decimal? Numerorecibo {get;set;}

        public System.Nullable<decimal> Valor {get;set;}

        public string Poliza {get;set;}

        public string FechaPago {get;set;}

        public System.Nullable<decimal> Balance {get;set;}

        public string Concepto {get;set;}

        public string Anulado {get;set;}
    }
}
