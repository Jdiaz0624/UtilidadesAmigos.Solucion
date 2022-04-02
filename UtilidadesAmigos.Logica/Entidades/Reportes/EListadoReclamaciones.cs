using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EListadoReclamaciones
    {
		public decimal? Reclamacion {get;set;}

		public string Poliza {get;set;}

		public int? Item {get;set;}

		public int? Ramo {get;set;}

		public string NombreRamo {get;set;}

		public int? SubRamo {get;set;}

		public string NombreSubramo {get;set;}

		public string Oficina {get;set;}

		public System.Nullable<int> Intermediario {get;set;}

		public string NombreIntermediario {get;set;}

		public int? CodigoSupervisor {get;set;}

		public string NombreSupervisor {get;set;}

		public System.Nullable<System.DateTime> FechaApertura0 {get;set;}

		public string FechaSiniestro {get;set;}

		public System.Nullable<System.DateTime> FechaSiniestro0 {get;set;}

		public string FechaApertura {get;set;}

		public System.Nullable<decimal> MontoReclamado {get;set;}

		public System.Nullable<decimal> MontoAjustado {get;set;}

		public string Comentario {get;set;}

		public System.Nullable<System.DateTime> InicioVigencia0 {get;set;}

		public string InicioVigencia {get;set;}

		public System.Nullable<System.DateTime> FinVigencia0 {get;set;}

		public string FinVigencia {get;set;}

		public System.Nullable<int> Estatus {get;set;}

		public string EstatusReclamacion {get;set;}

		public int? IdTipoReclamacion {get;set;}

		public string TipoReclamacion {get;set;}

		public string IdReclamante {get;set;}

		public string Reclamante {get;set;}

		public string GeneradoPor {get;set;}

		public string MotivoReclamo {get;set;}

		public string SegundoEstatus {get;set;}

		public string Campo1 {get;set;}

		public string Campo2 {get;set;}

		public string Campo3 {get;set;}

		public string Campo4 {get;set;}

		public string Campo5 {get;set;}
	}
}
