using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador
{
    public class EMantenimientoBackupDatabase
    {
		public decimal? IdHistorialBakupDatabase { get; set; }

		public string NumeroBackup { get; set; }

		public System.Nullable<decimal> IdUsuario { get; set; }

		public string Usuario { get; set; }

		public string NombreArchivo { get; set; }

		public string Descripcion { get; set; }

		public System.Nullable<System.DateTime> FechaCreado { get; set; }

		public string Fecha { get; set; }

		public System.Nullable<System.DateTime> Hora0 { get; set; }

		public string Hora { get; set; }

		public System.Nullable<bool> IdEstatus { get; set; }

		public string Estatus { get; set; }

		public string Comentario { get; set; }
	}
}
