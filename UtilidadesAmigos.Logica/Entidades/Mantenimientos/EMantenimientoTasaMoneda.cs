using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
	public class EMantenimientoTasaMoneda
    {
		public System.Nullable<int> Codigo {get;set;}

		public string Descripcion {get;set;}

		public string Siglas {get;set;}

		public System.Nullable<decimal> Prima {get;set;}

		public string Cuenta {get;set;}

		public string AuxiliarCuenta {get;set;}

		public string CuentaIngreso {get;set;}

		public string AuxiliarIngreso {get;set;}

		public string CuentaEgreso {get;set;}

		public string AuxiliarEgreso {get;set;}

		public string UsuarioAdiciona {get;set;}

		public System.Nullable<System.DateTime> FechaAdiciona {get;set;}

		public string UsuarioModifica {get;set;}

		public System.Nullable<System.DateTime> FechaModifica {get;set;}

		public System.Nullable<int> TipoCompromiso {get;set;}

		public System.Nullable<int> TipoCompromisoEgreso {get;set;}

		public System.Nullable<int> TipoCompromisoIngreso {get;set;}

		public string Origen {get;set;}

		public System.Nullable<byte> MonedaBase {get;set;}

		public string CuentaCobrar {get;set;}

		public System.Nullable<int> AuxiliarCobrar {get;set;}

		public System.Nullable<decimal> PrimaCobrar {get;set;}
	}
}
