using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EBuscarInformacionPolizasGestionCobros
    {
		public string Poliza {get;set;}

		public string Ramo {get;set;}

		public string Subramo {get;set;}

		public int? CodigoRamo {get;set;}

		public int? CodigoSubRamo {get;set;}

		public string Estatus {get;set;}

		public System.Nullable<decimal> SumaAsegurada {get;set;}

		public System.Nullable<decimal> Cliente {get;set;}

		public string NombreCliente {get;set;}
		public string Direccion { get; set; }

		public string Telefonos {get;set;}

		public System.Nullable<int> CodigoIntermediario {get;set;}

		public string Intermediario {get;set;}

		public string LicenciaSeguro {get;set;}

		public int? CodigoSupervisor {get;set;}

		public string Supervisor {get;set;}

		public System.Nullable<System.DateTime> FechaAdiciona {get;set;}

		public string FechaCreada {get;set;}

		public System.Nullable<System.DateTime> FechaInicioVigencia {get;set;}

		public string InicioVigencia {get;set;}

		public System.Nullable<System.DateTime> FechaFinVigencia {get;set;}

		public string FinVigencia {get;set;}

		public System.Nullable<decimal> Facturado {get;set;}

		public System.Nullable<decimal> Cobrado {get;set;}

		public System.Nullable<decimal> Balance {get;set;}

		public System.Nullable<int> TotalFacturas {get;set;}

		public System.Nullable<int> TotalRecibos {get;set;}

		public System.Nullable<int> TotalReclamaciones {get;set;}
	}
}
