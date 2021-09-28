using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Procesos
{
    public class EModificarFormaPago
    {
		public System.Nullable<int> Compania {get;set;}

		public string TipoFactura {get;set;}

		public string Anulado {get;set;}

		public System.Nullable<int> sistema {get;set;}

		public System.Nullable<int> tipodocumento {get;set;}

		public System.Nullable<decimal> NumeroRecibo {get;set;}

		public System.Nullable<System.DateTime> Fechapago {get;set;}

		public string Tipo {get;set;}

		public System.Nullable<decimal> Monto {get;set;}

		public string NoDocumento {get;set;}

		public string NoAprobacion {get;set;}

		public string FechaVencimiento {get;set;}

		public string CodBanco {get;set;}

		public string TipoTarjeta {get;set;}
	}
}
