using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Correcciones
{
    public class EInformacionPolizasEquiposElectrinicos
    {
        public int? Compania {get;set;}

        public decimal? Cotizacion {get;set;}

        public int? Secuencia {get;set;}

        public int? IdEquipo {get;set;}

        public string Descripcion {get;set;}

        public string Marca {get;set;}

        public string Modelo {get;set;}

        public string Serie {get;set;}

        public System.Nullable<decimal> ValorAsegurado {get;set;}

        public System.Nullable<decimal> ValorReposicion {get;set;}

        public System.Nullable<decimal> PorcDeducible {get;set;}

        public string BaseDeducible {get;set;}

        public System.Nullable<decimal> MinimoDeducible {get;set;}

        public System.Nullable<decimal> PorcPrima {get;set;}

        public System.Nullable<System.DateTime> FechaAdiciona0 {get;set;}

        public string FechaAdiciona {get;set;}
        public System.Nullable<int> TotalItems { get; set; }
    }
}
