using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Seguridad
{
    public class EControlTarjetasAcceso
    {
		public decimal? IdRegistro {get;set;}

		public System.Nullable<decimal> IdOficina {get;set;}

		public string Oficina {get;set;}

		public System.Nullable<decimal> IdDepartamento {get;set;}

		public string Departamento {get;set;}

		public string Empleado {get;set;}

		public string NumeroTarjeta {get;set;}

		public string SecuenciaInterna {get;set;}

		public System.Nullable<System.DateTime> FechaEntrega0 {get;set;}

		public string FechaEntrada {get;set;}

		public string HoraEntrada {get;set;}

		public System.Nullable<decimal> IdEstatus {get;set;}

		public string Estatus {get;set;}

		public System.Nullable<decimal> IdUsuarioAdiciona {get;set;}

		public string CreadoPor {get;set;}

		public System.Nullable<System.DateTime> FechaAdiciona0 {get;set;}

		public string FechaCreado {get;set;}

		public string HoraCreado {get;set;}

		public System.Nullable<decimal> IdUsuarioModifica {get;set;}

		public string ModificadoPor {get;set;}

		public System.Nullable<System.DateTime> FechaModifica0 {get;set;}

		public string FechaModificado {get;set;}

		public string HoraModificado {get;set;}
	}
}
