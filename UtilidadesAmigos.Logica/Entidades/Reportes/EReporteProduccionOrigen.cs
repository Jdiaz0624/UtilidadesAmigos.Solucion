using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EReporteProduccionOrigen
    {
		public System.Nullable<int> CodRamo {get;set;}

		public string Ramo {get;set;}

		public decimal NumeroFactura {get;set;}

		public string NumeroFacturaFormateado {get;set;}

		public string Poliza {get;set;}

		public string Asegurado {get;set;}

		public System.Nullable<int> Items {get;set;}

		public string Supervisor {get;set;}

		public int? CodIntermediario {get;set;}

		public System.Nullable<int> CodSupervisor {get;set;}

		public string Intermediario {get;set;}

		public System.Nullable<System.DateTime> Fecha {get;set;}

		public string FechaFormateada {get;set;}

		public System.Nullable<System.DateTime> FechaInicioVigencia {get;set;}

		public System.Nullable<System.DateTime> FechaFinVigencia {get;set;}

		public string InicioVigencia {get;set;}

		public string FinVigencia {get;set;}

		public System.Nullable<decimal> SumaAsegurada {get;set;}

		public string Estatus {get;set;}

		public System.Nullable<int> CodOficina {get;set;}

		public string Oficina {get;set;}

		public string Concepto {get;set;}

		public string Ncf {get;set;}

		public int? Tipo {get;set;}

		public string DescripcionTipo {get;set;}

		public System.Nullable<decimal> Bruto {get;set;}

		public System.Nullable<decimal> Impuesto {get;set;}

		public System.Nullable<decimal> Neto {get;set;}

		public System.Nullable<decimal> Tasa {get;set;}

		public System.Nullable<decimal> Cobrado {get;set;}

		public System.Nullable<int> CodMoneda {get;set;}

		public string Moneda {get;set;}

		public System.Nullable<decimal> TasaUsada {get;set;}

		public System.Nullable<decimal> MontoPesos {get;set;}

		public string Mes {get;set;}

		public string Usuario {get;set;}

		public System.Nullable<int> CantidadRegistros {get;set;}

		public System.Nullable<decimal> TotalFacturado {get;set;}

		public System.Nullable<decimal> TotalFActuradoPesos {get;set;}

		public System.Nullable<decimal> TotalFActuradoDollar {get;set;}

		public System.Nullable<decimal> TotalFacturadoGeneral {get;set;}
	}
}
