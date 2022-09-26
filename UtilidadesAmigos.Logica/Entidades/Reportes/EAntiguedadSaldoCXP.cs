using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EAntiguedadSaldoCXP
    {
		public System.Nullable<int> Proveedor {get;set;}

		public string NombreProveedor {get;set;}

		public int? CodigoDia {get;set;}

		public string DescripcionDias {get;set;}

		public int? Tipo {get;set;}

		public string Siglas {get;set;}

		public string Descripcion {get;set;}

		public int? Factura {get;set;}

		public System.Nullable<System.DateTime> Fecha0 {get;set;}

		public string Fecha {get;set;}

		public System.Nullable<int> Dias {get;set;}

		public string FacturaProveedor {get;set;}

		public string Ncf {get;set;}

		public System.Nullable<decimal> Reclamacion {get;set;}

		public System.Nullable<decimal> TotalDeuda {get;set;}

		public System.Nullable<decimal> Valor {get;set;}

		public System.Nullable<int> Proveedor1 {get;set;}

		public int NumeroQuePaga {get;set;}

		public System.Nullable<int> NumeroCheque {get;set;}

		public System.Nullable<decimal> CXP_0_30 {get;set;}

		public System.Nullable<decimal> CXP_31_60 {get;set;}

		public System.Nullable<decimal> CXP_61_90 {get;set;}

		public System.Nullable<decimal> CXP_91_120 {get;set;}

		public System.Nullable<decimal> CXP_121_MAS {get;set;}

		public string GeneradoPor {get;set;}
	}
}
