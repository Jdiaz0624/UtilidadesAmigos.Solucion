using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Suministro
{
    public class ESuministroEspejo
    {
		public System.Nullable<decimal> IdUsuario {get;set;}

		public System.Nullable<decimal> CodigoArticulo {get;set;}

		public string Descripcion {get;set;}

		public System.Nullable<int> IdMedida {get;set;}

		public System.Nullable<int> Cantidad {get;set;}
	}
}
