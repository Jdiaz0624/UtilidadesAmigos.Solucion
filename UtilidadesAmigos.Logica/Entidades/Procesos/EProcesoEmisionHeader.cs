using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Procesos
{
    public class EProcesoEmisionHeader
    {
		public System.Nullable<decimal> NumeroRegistro {get;set;}

		public string NumeroConector {get;set;}

		public System.Nullable<bool> ClienteCreado {get;set;}

		public System.Nullable<decimal> CodigoCliente {get;set;}

		public System.Nullable<bool> DocumentosEntregadoATecnico {get;set;}

		public System.Nullable<bool> PolizaEmitida {get;set;}

		public string NumeroPoliza {get;set;}

		public System.Nullable<bool> SegundaRevision {get;set;}

		public System.Nullable<bool> ImpresionMarbete {get;set;}

		public System.Nullable<bool> Despachada {get;set;}
	}
}
