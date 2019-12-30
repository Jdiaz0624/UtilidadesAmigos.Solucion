using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class ESacarDataCedensa
    {
        public string Poliza {get;set;}
		
		public string Cobertura {get;set;}
		
		public string Parentezco {get;set;}
		
		public string Nombre {get;set;}
		
		public decimal? Cotizacion {get;set;}
		
		public int? CodRamo {get;set;}
        public string Ramo { get; set; }

        public string Estatus {get;set;}
		
		public string Concepto {get;set;}
		
		public string Cliente {get;set;}
		
		public string TipoIdentificacion {get;set;}
		
		public string NumeroIdentificacion {get;set;}
		
		public string Intermediario {get;set;}
		
		public System.Nullable<System.DateTime> FechaInicioVigencia {get;set;}
		
		public System.Nullable<System.DateTime> FechaFinVigencia {get;set;}
		
		public string InicioVigencia {get;set;}
		
		public string FinVigencia {get;set;}
		
		public System.Nullable<System.DateTime> FechaProcesoBruto {get;set;}
		
		public string FechaProceso {get;set;}
		
		public string MesValidado {get;set;}
		
		public string Provincia {get;set;}
		
		public string Direccion {get;set;}
		
		public string Telefono {get;set;}
		
		public string Cedula {get;set;}
		
		public string FechadeNacimiento {get;set;}
		
		public string Edad {get;set;}
		
		public System.Nullable<decimal> Prima {get;set;}
		
		public string TipoMovimiento {get;set;}
    }
}
