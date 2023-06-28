using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Correcciones
{
    public class EBitacoraMontoAfianzado
    {
        public decimal? IdRegistro {get;set;}

        public string Poliza {get;set;}

        public System.Nullable<decimal> Anterior {get;set;}

        public System.Nullable<decimal> Cambio {get;set;}

        public System.Nullable<decimal> Usuario {get;set;}

        public string CreadoPor {get;set;}

        public System.Nullable<System.DateTime> Fecha0 {get;set;}

        public string Fecha {get;set;}

        public string Hora {get;set;}

        public string Concepto {get;set;}
    }
}
