using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EReclamacionesPagadas
    {
		public System.Nullable<int> CodigoBeneficiario {get;set;}

		public string Beneficiario1 {get;set;}

		public System.Nullable<byte> RNCTipo {get;set;}

		public string TipoIdentificacion {get;set;}

		public string NumeroIdentificacion {get;set;}

		public System.Nullable<decimal> Valor {get;set;}

		public string Concepto1 {get;set;}

		public string Concepto2 {get;set;}

		public System.Nullable<int> NumeroCheque {get;set;}

		public System.Nullable<System.DateTime> FechaCheque0 {get;set;}

		public string FechaCheque {get;set;}

		public System.Nullable<byte> Sucursal {get;set;}

		public string DescSucursal {get;set;}

		public System.Nullable<int> CantidadRegistros {get;set;}
	}
}
