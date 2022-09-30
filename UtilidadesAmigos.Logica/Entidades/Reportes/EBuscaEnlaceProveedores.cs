using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EBuscaEnlaceProveedores
    {
		public System.Nullable<int> IdProveedor {get;set;}

		public System.Nullable<byte> TipoRnc {get;set;}

		public string RNC {get;set;}

		public string Proveedor {get;set;}

		public System.Nullable<int> TipoProveedor {get;set;}

		public string Tipo {get;set;}

		public System.Nullable<int> CodigoDia {get;set;}

		public string Dia {get;set;}
		public string GeneradoPor { get; set; }
	}
}
