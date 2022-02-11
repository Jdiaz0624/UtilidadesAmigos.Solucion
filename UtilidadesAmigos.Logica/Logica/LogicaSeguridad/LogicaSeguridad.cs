using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Logica.LogicaSeguridad
{
    public class LogicaSeguridad
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDConexionDataContext ObjData = new Data.Conexiones.LINQ.BDConexionDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

        #region MANTENIMEINTO DE PERFILES
        //LISTADO DE PERFILES
        public List<UtilidadesAmigos.Logica.Entidades.Seguridad.EPerfiles> ListadoPerfiles(decimal? IdPerfil = null, string Perfil = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_PERFILES(IdPerfil, Perfil)
                           select new UtilidadesAmigos.Logica.Entidades.Seguridad.EPerfiles
                           {
                               IdPerfil=n.IdPerfil,
                               perfil=n.perfil,
                               Estatus0=n.Estatus0,
                               Estatus=n.Estatus
                           }).ToList();
            return Listado;
        }
        //MANTENIMIENTO DE PERFILES
        public UtilidadesAmigos.Logica.Entidades.Seguridad.EPerfiles MantenimientoPerfiles(UtilidadesAmigos.Logica.Entidades.Seguridad.EPerfiles Item, string Accion)
        {
            UtilidadesAmigos.Logica.Entidades.Seguridad.EPerfiles Mantenimiento = null;

            var Perfil = ObjData.SP_MANTENIMIENTO_PERFILES(
                Item.IdPerfil,
                Item.perfil,
                Item.Estatus0,
                Accion);
            if (Perfil != null)
            {
                Mantenimiento = (from n in Perfil
                                 select new UtilidadesAmigos.Logica.Entidades.Seguridad.EPerfiles
                                 {
                                     IdPerfil=n.IdPerfil,
                                     perfil=n.Perfil,
                                     Estatus0=n.Estatus
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion
        #region MANTENIMIENTO DE CLAVE DE SEGURIDAD
        public UtilidadesAmigos.Logica.Entidades.Seguridad.EMantenimientoClaveSeguridad MAntenimientoClaveSeguridad(UtilidadesAmigos.Logica.Entidades.Seguridad.EMantenimientoClaveSeguridad Item, string Accion)
        {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Seguridad.EMantenimientoClaveSeguridad Mantenimeinto = null;

            var ClaveSeguridad = ObjData.SP_MANTENIMIENTO_CLAVE_SEGURIDAD(
                Item.IdClaveSeguridad,
                Item.IdUsuario,
                Item.Clave,
                Item.Estatus,
                Accion);
            if (ClaveSeguridad != null)
            {
                Mantenimeinto = (from n in ClaveSeguridad
                                 select new Entidades.Seguridad.EMantenimientoClaveSeguridad
                                 {
                                     IdClaveSeguridad=n.IdClaveSeguridad,
                                     IdUsuario=n.IdUsuario,
                                     Clave=n.Clave,
                                     Estatus=n.Estatus
                                 }).FirstOrDefault();
            }
            return Mantenimeinto;
        }
        #endregion
        #region CONTROL DE TARJETAS DE ACCESOS
        /// <summary>
        /// Este metodo es para buscar el listado de las tarjetas de accesos registradas en el sistema
        /// </summary>
        /// <param name="IdRegistro"></param>
        /// <param name="IdOficina"></param>
        /// <param name="IdDepartamento"></param>
        /// <param name="IdEstatus"></param>
        /// <param name="Empleado"></param>
        /// <param name="NumeroTarjeta"></param>
        /// <param name="Secuencia"></param>
        /// <param name="FechaEntradaDesde"></param>
        /// <param name="FechaEntradaHasta"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Seguridad.EControlTarjetasAcceso> BuscaListadoTarjetasAcceso(decimal? IdRegistro = null, decimal? IdOficina = null, decimal? IdDepartamento = null, decimal? IdEstatus = null, string Empleado = null, string NumeroTarjeta = null, string Secuencia = null, DateTime? FechaEntradaDesde = null, DateTime? FechaEntradaHasta = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_LISTADO_CONTROL_TARJETA_ACCESO(IdRegistro, IdOficina, IdDepartamento, IdEstatus, Empleado, NumeroTarjeta, Secuencia, FechaEntradaDesde, FechaEntradaHasta)
                           select new UtilidadesAmigos.Logica.Entidades.Seguridad.EControlTarjetasAcceso
                           {
                               IdRegistro=n.IdRegistro,
                               IdOficina=n.IdOficina,
                               Oficina=n.Oficina,
                               IdDepartamento=n.IdDepartamento,
                               Departamento=n.Departamento,
                               Empleado=n.Empleado,
                               NumeroTarjeta=n.NumeroTarjeta,
                               SecuenciaInterna=n.SecuenciaInterna,
                               FechaEntrega0=n.FechaEntrega0,
                               FechaEntrada =n.FechaEntrada,
                               HoraEntrada=n.HoraEntrada,
                               IdEstatus=n.IdEstatus,
                               Estatus=n.Estatus,
                               IdUsuarioAdiciona=n.IdUsuarioAdiciona,
                               CreadoPor=n.CreadoPor,
                               FechaAdiciona0=n.FechaAdiciona0,
                               FechaCreado=n.FechaCreado,
                               HoraCreado=n.HoraCreado,
                               IdUsuarioModifica=n.IdUsuarioModifica,
                               ModificadoPor=n.ModificadoPor,
                               FechaModifica0=n.FechaModifica0,
                               FechaModificado=n.FechaModificado,
                               HoraModificado=n.HoraModificado
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo es para procesar los registros para el control de las tarjetas de acceso
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Seguridad.EControlTarjetasAcceso ProcesarTarjetasAccesp(UtilidadesAmigos.Logica.Entidades.Seguridad.EControlTarjetasAcceso Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Seguridad.EControlTarjetasAcceso Procesar = null;

            var TarjetasAcceso = ObjData.SP_PROCESAR_INFORMACION_TARJETAS_ACCESO(
                Item.IdRegistro,
                Item.IdOficina,
                Item.IdDepartamento,
                Item.Empleado,
                Item.NumeroTarjeta,
                Item.SecuenciaInterna,
                Item.IdEstatus,
                Item.IdUsuarioAdiciona,
                Accion);
            if (TarjetasAcceso != null) {

                Procesar = (from n in TarjetasAcceso
                            select new UtilidadesAmigos.Logica.Entidades.Seguridad.EControlTarjetasAcceso
                            {
                                IdRegistro=n.IdRegistro,
                                IdOficina=n.IdOficina,
                                IdDepartamento=n.IdDepartamento,
                                Empleado=n.Empleado,
                                NumeroTarjeta=n.NumeroTarjeta,
                                SecuenciaInterna=n.SecuenciaInterna,
                                FechaEntrega0=n.FechaEntrega,
                                IdEstatus=n.IdEstatus,
                                IdUsuarioAdiciona=n.IdUsuarioAdiciona,
                                FechaAdiciona0=n.FechaAdiciona,
                                IdUsuarioModifica=n.IdUsuarioModifica,
                                FechaModifica0=n.FechaModifica
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion
    }
}
