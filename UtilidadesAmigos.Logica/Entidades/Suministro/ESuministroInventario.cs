using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Suministro
{
    public class ESuministroInventario
    {
		public System.Nullable<decimal> CodigoArticulo {get;set;}

		public string Articulo {get;set;}

		public System.Nullable<int> IdMedida {get;set;}

		public string Medida {get;set;}

		public System.Nullable<int> Stock {get;set;}

		public string Estatus {get;set;}

		public System.Nullable<decimal> UsuarioCrea {get;set;}

		public string CreadoPor {get;set;}

		public System.Nullable<System.DateTime> FechaCrea0 {get;set;}

		public string FechaCreado {get;set;}

		public string HoraCreado {get;set;}

		public System.Nullable<decimal> UsuarioModifica {get;set;}

		public string ModificadoPor {get;set;}

		public System.Nullable<System.DateTime> FechaModifica0 {get;set;}

		public string FechaModificado {get;set;}

		public string HoraModificado {get;set;}

		public string GeneradoPor {get;set;}
	}
}
