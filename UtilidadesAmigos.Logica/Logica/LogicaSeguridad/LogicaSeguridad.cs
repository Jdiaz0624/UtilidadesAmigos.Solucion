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
        UtilidadesAmigos.Data.Conexiones.LINQ.BDConexionSeguridadDataContext ObjDataSeguridad = new Data.Conexiones.LINQ.BDConexionSeguridadDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

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

        #region MANTENIMIENTO DE MODULOS
        /// <summary>
        /// Este metodo muestra el listado de los modulos registrados en la base de datos
        /// </summary>
        /// <param name="IdModulo"></param>
        /// <param name="Modulo"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Seguridad.EModulos> Buscamodulos(int? IdModulo = null, string Modulo = null)
        {
            ObjDataSeguridad.CommandTimeout = 999999999;

            var Listado = (from n in ObjDataSeguridad.SP_BUSCA_MODULOS(IdModulo, Modulo)
                           select new UtilidadesAmigos.Logica.Entidades.Seguridad.EModulos
                           {
                               IdModulo=n.IdModulo,
                               Modulo=n.Modulo,
                               Estatus0=n.Estatus0,
                               Estatus=n.Estatus
                           }).ToList();
            return Listado;
        }
        /// <summary>
        /// Este metodo procesa los modulos
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Seguridad.EModulos ProcesarModulos(UtilidadesAmigos.Logica.Entidades.Seguridad.EModulos Item, string Accion) {

            ObjDataSeguridad.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Seguridad.EModulos Procesar = null;

            var Modulos = ObjDataSeguridad.SP_PROCESAR_MODULOS(
                Item.IdModulo,
                Item.Modulo,
                Item.Estatus0,
                Accion);
            if (Modulos != null) {

                Procesar = (from n in Modulos
                            select new UtilidadesAmigos.Logica.Entidades.Seguridad.EModulos
                            {
                                IdModulo=n.IdModulo,
                                Modulo=n.Descripcion,
                                Estatus0=n.Estatus
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion
        #region MANTENIMIENTO DE PANTALLAS
        /// <summary>
        /// Este metodo muestra el listado de las pantallas registradas en el sistema
        /// </summary>
        /// <param name="IdModulo"></param>
        /// <param name="IdPantalla"></param>
        /// <param name="Pantalla"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Seguridad.EPantallas> BuscaPantallas(int? IdModulo = null, int? IdPantalla = null, string Pantalla = null) {

            ObjDataSeguridad.CommandTimeout = 999999999;

            var Listado = (from n in ObjDataSeguridad.SP_BUSCA_MODULOS_PANTALLA(IdModulo, IdPantalla, Pantalla)
                           select new UtilidadesAmigos.Logica.Entidades.Seguridad.EPantallas
                           {
                               IdModulo=n.IdModulo,
                               Modulo=n.Modulo,
                               IdPantalla=n.IdPantalla,
                               Pantalla=n.Pantalla,
                               Estatus0=n.Estatus0,
                               Estatus=n.Estatus
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo procesa las pantallas
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Seguridad.EPantallas ProcesarPantallas(UtilidadesAmigos.Logica.Entidades.Seguridad.EPantallas Item, string Accion) {

            ObjDataSeguridad.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Seguridad.EPantallas Procesar = null;

            var Pantallas = ObjDataSeguridad.SP_PROCESAR_PANTALLAS(
                Item.IdModulo,
                Item.IdPantalla,
                Item.Pantalla,
                Item.Estatus0,
                Accion);
            if (Pantallas != null) {

                Procesar = (from n in Pantallas
                            select new UtilidadesAmigos.Logica.Entidades.Seguridad.EPantallas
                            {
                                IdModulo=n.IdModulo,
                                IdPantalla=n.IdPantalla,
                                Pantalla=n.Descripcion,
                                Estatus0=n.Estatus
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion
        #region MANTENIMIENTO DE OPCIONES DE PANTALLAS
        /// <summary>
        /// Este metodo es para Buscar las ociones de las pantallas
        /// </summary>
        /// <param name="IdModulo"></param>
        /// <param name="IdPantalla"></param>
        /// <param name="IdOpcionPantalla"></param>
        /// <param name="Descripcion"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Seguridad.EOpcionPantalla> BuscaOpcionesPantalla(int? IdModulo = null, int? IdPantalla = null, int? IdOpcionPantalla = null, string Descripcion = null) {

            ObjDataSeguridad.CommandTimeout = 999999999;

            var Listado = (from n in ObjDataSeguridad.SP_BUSCA_OPCION_PANTALLA(IdModulo, IdPantalla, IdOpcionPantalla, Descripcion)
                           select new UtilidadesAmigos.Logica.Entidades.Seguridad.EOpcionPantalla
                           {
                               IdModulo=n.IdModulo,
                               Modulo=n.Modulo,
                               IdPantalla=n.IdPantalla,
                               Pantalla=n.Pantalla,
                               IdOpcion=n.IdOpcion,
                               Opcion=n.Opcion,
                               Estatus0=n.Estatus0,
                               Estatus=n.Estatus
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo es para procesar la informacion de la opciones
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Seguridad.EOpcionPantalla ProcesarOpcionesPantalla(UtilidadesAmigos.Logica.Entidades.Seguridad.EOpcionPantalla Item, string Accion) {

            ObjDataSeguridad.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Seguridad.EOpcionPantalla Procesar = null;

            var Opciones = ObjDataSeguridad.SP_PROCESAR_OPCION_SISTEMA(
                Item.IdModulo,
                Item.IdPantalla,
                Item.IdOpcion,
                Item.Opcion,
                Item.Estatus0,
                Accion);
            if (Opciones != null) {

                Procesar = (from n in Opciones
                            select new UtilidadesAmigos.Logica.Entidades.Seguridad.EOpcionPantalla
                            {
                                IdModulo=n.IdModulo,
                                IdPantalla=n.IdPantalla,
                                IdOpcion=n.IdOpcion,
                                Opcion=n.Descripcion,
                                Estatus0=n.Estatus
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion
        #region MANTENIMIENTO DE CREDENCIALES DE BASE DE DATOS
        /// <summary>
        /// Mostrar la informacion de la clave de seguridad
        /// </summary>
        /// <param name="IdCredencial"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Seguridad.ECredencialesBD> BuscaCredencialesBD(int? IdCredencial = null) {

            ObjDataSeguridad.CommandTimeout = 999999999;

            var Listado = (from n in ObjDataSeguridad.SP_BUSCA_CREDENCIALES_BD(IdCredencial)
                           select new UtilidadesAmigos.Logica.Entidades.Seguridad.ECredencialesBD
                           {
                               IdCredencial=n.IdCredencial,
                               UsuarioBD=n.UsuarioBD,
                               Clave=n.Clave
                           }).ToList();
            return Listado;
        }
        /// <summary>
        /// Procesar la informacion de las credenciales de base de datos
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Seguridad.ECredencialesBD ProcesarClaveSeguridad(UtilidadesAmigos.Logica.Entidades.Seguridad.ECredencialesBD Item, string Accion) {

            ObjDataSeguridad.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Seguridad.ECredencialesBD Procesar = null;

            var Credenciales = ObjDataSeguridad.SP_PROCESAR_INFORMACION_CREDENCIALES_BD(
                Item.IdCredencial,
                Item.UsuarioBD,
                Item.Clave,
                Accion);
            if (Credenciales != null) {

                Procesar = (from n in Credenciales
                            select new UtilidadesAmigos.Logica.Entidades.Seguridad.ECredencialesBD
                            {
                                IdCredencial=n.IdCredencial,
                                UsuarioBD=n.UsuarioBD,
                                Clave=n.Clave
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion
    }
}
