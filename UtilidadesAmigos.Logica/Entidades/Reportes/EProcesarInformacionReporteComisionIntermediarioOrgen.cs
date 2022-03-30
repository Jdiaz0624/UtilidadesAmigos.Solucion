using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EProcesarInformacionReporteComisionIntermediarioOrgen
    {
		public System.Nullable<decimal> IdUSuario {get;set;}

		public System.Nullable<int> CodigoSupervisor {get;set;}

		public string Supervisor {get;set;}

		public System.Nullable<int> CodigoIntermediario {get;set;}

		public string Intermediario {get;set;}

		public System.Nullable<int> Oficina {get;set;}

		public string NombreOficina {get;set;}

		public string NumeroIdentificacion {get;set;}

		public string NumeroCuenta {get;set;}

		public string TipoCuentaBanco {get;set;}

		public System.Nullable<int> Banco {get;set;}

		public string NombreBanco {get;set;}

		public System.Nullable<decimal> NumeroRecibo {get;set;}

		public System.Nullable<System.DateTime> FechaRecibo0 {get;set;}

		public string FechaRecibo {get;set;}

		public string HoraRecibo {get;set;}

		public string NumeroReciboFormateado {get;set;}

		public System.Nullable<decimal> NumeroFactura {get;set;}

		public string NumeroFacturaFormateada {get;set;}

		public System.Nullable<System.DateTime> FechaFactura0 {get;set;}

		public string FechaFactura {get;set;}

		public string HoraFactura {get;set;}

		public System.Nullable<int> CodMoneda {get;set;}

		public string NoPoliza {get;set;}

		public System.Nullable<int> Ramo {get;set;}

		public string NombreRamo {get;set;}

		public System.Nullable<decimal> TasaPesos {get;set;}

		public System.Nullable<decimal> TasaDollar {get;set;}

		public System.Nullable<decimal> TasaEuro {get;set;}

		public System.Nullable<decimal> ValorRecibo {get;set;}

		public System.Nullable<decimal> PorcientoComision {get;set;}

		public System.Nullable<decimal> Bruto {get;set;}

		public System.Nullable<decimal> Neto {get;set;}

		public System.Nullable<decimal> Comision {get;set;}

		public System.Nullable<decimal> Retencion {get;set;}

		public System.Nullable<decimal> AvanceComision {get;set;}

		public System.Nullable<decimal> Aliquidar {get;set;}

		public string GeneradoPor {get;set;}

		public System.Nullable<decimal> CodigoUsuario {get;set;}

		public string ValidadoDesde {get;set;}

		public string ValidadoHasta {get;set;}
	}
}
