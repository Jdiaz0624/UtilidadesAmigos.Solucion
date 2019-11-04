using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
   public  class EValidarPolizasCanceladasCoberturas
    {
        public string Poliza {get;set;}

        public string Estatus {get;set;}

        public string InicioVigencia {get;set;}

        public string FinVigencia {get;set;}

        public string Concepto {get;set;}

        public string FechaMovimiento {get;set;}

        public System.Nullable<int> DiasConsumidos {get;set;}

        public System.Nullable<decimal> Total {get;set;}

        public string Cobertura {get;set;}
        public string Comentario { get; set; }

    }
}
