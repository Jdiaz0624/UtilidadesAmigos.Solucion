using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EClientesSinPoliza
    {
		public decimal? Codigo {get;set;}

		public string TipoIdentificacion {get;set;}

		public string RNC {get;set;}

		public string Cliente {get;set;}

		public string Direccion {get;set;}

		public System.Nullable<int> CodigoSupervisor {get;set;}

		public System.Nullable<int> CodigoIntermediario {get;set;}

		public string Supervisor {get;set;}

		public string Intermediario {get;set;}

		public string Cobrador {get;set;}

		public string UsuarioAdiciona {get;set;}

		public System.Nullable<System.DateTime> fecha0 {get;set;}

		public string Fecha {get;set;}

		public string TelefonoResidencia {get;set;}

		public string TelefonoOficina {get;set;}

		public string Celular {get;set;}

		public string fax {get;set;}

		public string Beeper {get;set;}

		public string Comprobante {get;set;}

		public string Nacionalidad {get;set;}

		public string ClaseCliente {get;set;}

		public System.Nullable<int> CantidadPolizas { get; set; }

		public string SiglaEstatus { get; set; }

		public string Estatus { get; set; }

		public System.Nullable<int> CodigoEstatus { get; set; }
	}
}
