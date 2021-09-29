using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Procesos
{
    public class AgregarEditarEliminarItemsReclamos
    {
		public System.Nullable<int> Compania {get;set;}

		public System.Nullable<decimal> Reclamacion {get;set;}

		public System.Nullable<int> Secuencia {get;set;}

		public System.Nullable<int> IdTipoReclamacion {get;set;}

		public string IdReclamante {get;set;}

		public System.Nullable<decimal> MontoReclamado {get;set;}

		public System.Nullable<decimal> MontoAjustado {get;set;}

		public System.Nullable<decimal> MontoReserva {get;set;}

		public System.Nullable<decimal> MontoDeducible {get;set;}

		public string UsuarioAdiciona {get;set;}

		public System.Nullable<System.DateTime> FechaAdiciona {get;set;}

		public string UsuarioModifica {get;set;}

		public System.Nullable<System.DateTime> FechaModifica {get;set;}

		public System.Nullable<int> Estatus {get;set;}

		public System.Nullable<int> IdEjecutivoReclamacion {get;set;}
	}
}
