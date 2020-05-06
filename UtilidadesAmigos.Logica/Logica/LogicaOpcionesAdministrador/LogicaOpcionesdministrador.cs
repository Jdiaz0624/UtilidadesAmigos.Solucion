using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Logica.LogicaOpcionesAdministrador
{
    public class LogicaOpcionesdministrador
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDOpcionesAdministradorDataContext ObdataConexion = new Data.Conexiones.LINQ.BDOpcionesAdministradorDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

        #region MANTENIMIENTO DE RUTA DE ARCHIVO
        //BUSCAR EL LISTADO DE LA RUTA DE ARCHIVO
        public List<UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.ERutaArchivoBakup> BuscaRutaArchivoBakup(int? IdRutaArchivoBackup = null)
        {
            ObdataConexion.CommandTimeout = 999999999;
            var Buscar = (from n in ObdataConexion.SP_BUSCA_RUTA_ARCHIVO_BAKUP(IdRutaArchivoBackup)
                          select new UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.ERutaArchivoBakup
                          {
                              IdRutaArchivoBakup=n.IdRutaArchivoBakup,
                              RutaBackup=n.RutaBackup,
                              ExtencionBackup=n.ExtencionBackup
                          }).ToList();
            return Buscar;
        }

        //MANTENIMIENTO DE RUTA DE ARCHIVO
        public UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.ERutaArchivoBakup MantenimientoRutaArchivoBackup(UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.ERutaArchivoBakup Item, string Accion)
        {
            ObdataConexion.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.ERutaArchivoBakup Mantenimiento = null;

            var RutaArchivoBackup = ObdataConexion.SP_MANTENIMIENTO_RUTA_ARCHIVO_BACKUP(
                Item.IdRutaArchivoBakup,
                Item.RutaBackup,
                Item.ExtencionBackup,
                Accion);
            if (RutaArchivoBackup != null)
            {
                Mantenimiento = (from n in RutaArchivoBackup
                                 select new UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.ERutaArchivoBakup
                                 {
                                     IdRutaArchivoBakup=n.IdRutaArchivoBakup,
                                     RutaBackup=n.RutaBackup,
                                     ExtencionBackup=n.ExtencionBackup
                                 }).FirstOrDefault();
                                 

            }
            return Mantenimiento;
        }
        #endregion

        #region GENERAR BAKUP
        public UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.GenerarBakupBD GenerarBackupDatabase(UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.GenerarBakupBD Item, string Accion)
        {
            ObdataConexion.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.GenerarBakupBD Generar = null;

            var Backup = ObdataConexion.SP_GENERARBAKUP_DATABASE(
                Item.RutaArchivo,
                Accion);
            if (Backup != null)
            {
                Generar = (from n in Backup
                           select new UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.GenerarBakupBD
                           {
                               RutaArchivo=n.RutaArchivo
                           }).FirstOrDefault();
            }
            return Generar;
        }
        #endregion

        #region MANTENIMEINTO DE HISTORIAL DE BAKUP DE DATABASE
        //LISTADO DE BAKUPDATABASE
        public List<UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.EMantenimientoBackupDatabase> BuscaHistorialBakupDatabase(decimal? IdHistorialBakup = null, string NumeroBackup = null, DateTime? Fechadesde = null, DateTime? FechaHasta = null, bool? IdEstatus = null)
        {
            ObdataConexion.CommandTimeout = 999999999;

            var Historial = (from n in ObdataConexion.SP_BUSCA_HISTORIAL_BAKUP_DATABASE(IdHistorialBakup, NumeroBackup, Fechadesde, FechaHasta, IdEstatus)
                             select new UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.EMantenimientoBackupDatabase
                             {
                                 IdHistorialBakupDatabase=n.IdHistorialBakupDatabase,
                                 NumeroBackup=n.NumeroBackup,
                                 IdUsuario=n.IdUsuario,
                                 Usuario=n.Usuario,
                                 NombreArchivo=n.NombreArchivo,
                                 Descripcion=n.Descripcion,
                                 FechaCreado=n.FechaCreado,
                                 Fecha=n.Fecha,
                                 Hora=n.Hora,
                                 IdEstatus=n.IdEstatus,
                                 Estatus=n.Estatus,
                                 Comentario=n.Comentario,
                                 CantidadRegistros=n.CantidadRegistros
                             }).ToList();
            return Historial;
        }

        //MANTENIMIENTO DE HISTORIAL DE BAKUP
        public UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.EMantenimientoBackupDatabase MantenimientoHistorialDatabase(UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.EMantenimientoBackupDatabase Item, string Accion)
        {
            ObdataConexion.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.EMantenimientoBackupDatabase Mantenimiento = null;

            var HistorialBakupDatabase = ObdataConexion.SP_MANTENIMIENTO_HISTORIAL_BACKUP_DATABASE(
                Item.IdHistorialBakupDatabase,
                Item.NumeroBackup,
                Item.IdUsuario,
                Item.NombreArchivo,
                Item.Descripcion,
                Item.Hora,
                Item.IdEstatus,
                Item.Comentario,
                Accion);
            if (HistorialBakupDatabase != null)
            {
                Mantenimiento = (from n in HistorialBakupDatabase
                                 select new UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.EMantenimientoBackupDatabase
                                 {
                                     IdHistorialBakupDatabase=n.IdHistorialBakupDatabase,
                                     NumeroBackup=n.NumeroBackup,
                                     IdUsuario=n.IdUsuario,
                                     NombreArchivo=n.NombreArchivo,
                                     Descripcion=n.Descripcion,
                                     FechaCreado=n.Fecha,
                                     Hora=n.Hora,
                                     IdEstatus=n.IdEstatus
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion
    }
}
