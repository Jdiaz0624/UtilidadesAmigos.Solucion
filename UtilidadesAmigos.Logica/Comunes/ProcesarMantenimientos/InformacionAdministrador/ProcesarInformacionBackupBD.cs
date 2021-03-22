using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionAdministrador
{
    public class ProcesarInformacionBackupBD
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaOpcionesAdministrador.LogicaOpcionesdministrador ObjData = new Logica.LogicaOpcionesAdministrador.LogicaOpcionesdministrador();

        private decimal IdHistorialBakupDatabase = 0;
        private string NumeroBackup = "";
        private decimal IdUsuario = 0;
        private string NombreArchivo = "";
        private string Descripcion = "";
        private DateTime Fecha = DateTime.Now;
        private DateTime Hora = DateTime.Now;
        private bool IdEstatus = false;
        private string Comentario = "";
        private string Accion = "";

            public ProcesarInformacionBackupBD(
            decimal IdHistorialBakupDatabaseCON,
            string NumeroBackupCON,
            decimal IdUsuarioCON,
            string NombreArchivoCON,
            string DescripcionCON,
            DateTime FechaCON,
            DateTime HoraCON,
            bool IdEstatusCON,
            string ComentarioCON,
            string AccionCON)
        {
            IdHistorialBakupDatabase = IdHistorialBakupDatabaseCON;
            NumeroBackup = NumeroBackupCON;
            IdUsuario = IdUsuarioCON;
            NombreArchivo = NombreArchivoCON;
            Descripcion = DescripcionCON;
            Fecha = FechaCON;
            Hora = HoraCON;
            IdEstatus = IdEstatusCON;
            Comentario = ComentarioCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            // UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.EMantenimientoBackupDatabase Guardar = new Logica.Entidades.OpcionesAdministrador.EMantenimientoBackupDatabase();

            UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.EMantenimientoBackupDatabase Procesar = new Entidades.OpcionesAdministrador.EMantenimientoBackupDatabase();

            Procesar.IdHistorialBakupDatabase = IdHistorialBakupDatabase;
            Procesar.NumeroBackup = NumeroBackup;
            Procesar.IdUsuario = IdUsuario;
            Procesar.NombreArchivo = NombreArchivo;
            Procesar.Descripcion = Descripcion;
            Procesar.FechaCreado = Fecha;
            Procesar.Hora0 = Hora;
            Procesar.IdEstatus = IdEstatus;
            Procesar.Comentario = Comentario;

            var MAN = ObjData.MantenimientoHistorialDatabase(Procesar, Accion);
        }
    }
}
