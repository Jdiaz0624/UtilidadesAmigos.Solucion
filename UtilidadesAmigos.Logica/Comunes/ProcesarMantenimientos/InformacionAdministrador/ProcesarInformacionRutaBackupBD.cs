using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionAdministrador
{
    public class ProcesarInformacionRutaBackupBD
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaOpcionesAdministrador.LogicaOpcionesdministrador ObjData = new Logica.LogicaOpcionesAdministrador.LogicaOpcionesdministrador();

        private int IdRutaArchivoBakup = 0;
        private string RutaBackup = "";
        private string ExtencionBackup = "";
        private string Accion = "";

        public ProcesarInformacionRutaBackupBD(
            int IdRutaArchivoBakupCON,
        string RutaBackupCON,
        string ExtencionBackupCON,
        string AccionCON)
        {
            IdRutaArchivoBakup = IdRutaArchivoBakupCON;
            RutaBackup = RutaBackupCON;
            ExtencionBackup = ExtencionBackupCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.ERutaArchivoBakup Ruta = new Entidades.OpcionesAdministrador.ERutaArchivoBakup();

            Ruta.IdRutaArchivoBakup = IdRutaArchivoBakup;
            Ruta.RutaBackup = RutaBackup;
            Ruta.ExtencionBackup = ExtencionBackup;

            var MAN = ObjData.MantenimientoRutaArchivoBackup(Ruta, Accion);
        }
    }
}
