using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilidadesAmigos.Logica.Entidades.Mantenimientos;

namespace UtilidadesAmigos.Logica.Logica.LogicaSuministro
{
    public class LogicaSuministro
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDConexionSuministroDataContext ObjData = new Data.Conexiones.LINQ.BDConexionSuministroDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

        #region MANTENIMIENTO DE SUMINISTRO INVENTARIO
        /// <summary>
        /// Muestra el listado de Inventario
        /// </summary>
        /// <param name="IdRegistro"></param>
        /// <param name="IdSucursal"></param>
        /// <param name="Idoficina"></param>
        /// <param name="IdCategoria"></param>
        /// <param name="IdUnidadMedida"></param>
        /// <param name="Descripcion"></param>
        /// <param name="Stock"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="GeneradoPor"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroInventarioFinal> BuscaInventario(decimal? IdRegistro = null, int? IdSucursal = null, int? Idoficina = null, int? IdCategoria = null, int? IdUnidadMedida = null, string Descripcion = null, int? Stock = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, decimal? GeneradoPor = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_SUMINISTRO_INVENTARIO_FINAL(IdRegistro, IdSucursal, Idoficina, IdCategoria, IdUnidadMedida, Descripcion, Stock, FechaDesde, FechaHasta, GeneradoPor)
                           select new UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroInventarioFinal
                           {
                               IdRegistro=n.IdRegistro,
                               IdSucursal=n.IdSucursal,
                               Sucursal=n.Sucursal,
                               IdOficina=n.IdOficina,
                               Oficina=n.Oficina,
                               IdCategoria=n.IdCategoria,
                               Categoria=n.Categoria,
                               IdUnidadMedida=n.IdUnidadMedida,
                               UnidadMedida=n.UnidadMedida,
                               Articulo=n.Articulo,
                               Stock=n.Stock,
                               StockMinimo=n.StockMinimo,
                               FechaIngreso0=n.FechaIngreso0,
                               Fecha=n.Fecha,
                               Hora=n.Hora,
                               GeneradoPor=n.GeneradoPor,
                               CantidadRegistros=n.CantidadRegistros,
                               CantidadRegistrosAgotadosAgotados=n.CantidadRegistrosAgotadosAgotados

                           }).ToList();
            return Listado;
        }


        /// <summary>
        /// Procesar la Informacion del Inventario
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroInventarioFinal ProcesarInventario(UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroInventarioFinal Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroInventarioFinal Procesar = null;

            var Inventario = ObjData.SP_PROCESAR_INFORMACION_SUMINISTROS_INVENTARIO(
                Item.IdRegistro,
                Item.IdSucursal,
                Item.IdOficina,
                Item.IdCategoria,
                Item.IdUnidadMedida,
                Item.Articulo,
                Item.Stock,
                Item.StockMinimo,
                Accion);
            if (Inventario != null) {

                Procesar = (from n in Inventario
                            select new UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroInventarioFinal
                            {
                                IdRegistro=n.IdRegistro,
                                IdSucursal=n.IdSucursal,
                                IdOficina=n.IdOficina,
                                IdCategoria=n.IdCategoria,
                                IdUnidadMedida=n.IdUnidadMedida,
                                Articulo=n.Descripcion,
                                Stock=n.Stock,
                                StockMinimo=n.StockMinimo,
                                FechaIngreso0=n.FechaIngreso,
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion

        #region MANTENIMIENTO DE SUMINISTRO ESPEJO
        /// <summary>
        /// Este metodo es para mostrar los registro que el usuario va a solicitar para los materiales gastables
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="CodigoArticulo"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroEspejo> BuscaSuministroEspejo(decimal? IdUsuario = null, decimal? CodigoArticulo = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_SUMINISTRO_SOLICITUD_ESPEJO(IdUsuario, CodigoArticulo)
                           select new UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroEspejo
                           {
                               IdUsuario=n.IdUsuario,
                               CodigoArticulo=n.CodigoArticulo,
                               Descripcion=n.Descripcion,
                               IdMedida=n.IdMedida,
                               Medida=n.Medida,
                               Cantidad=n.Cantidad
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo es para procesar la información del suministro espejo.
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroEspejo ProcesarSolicitudEspejo(UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroEspejo Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroEspejo Procesar = null;

            var SuministroEspejo = ObjData.SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_ESPEJO(
                Item.IdUsuario,
                Item.CodigoArticulo,
                Item.Descripcion,
                Item.IdMedida,
                Item.Cantidad,
                Accion);
            if (SuministroEspejo != null) {

                Procesar = (from n in SuministroEspejo
                            select new UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroEspejo
                            {
                                IdUsuario=n.IdUsuario,
                                CodigoArticulo=n.CodigoArticulo,
                                Descripcion=n.Descripcion,
                                IdMedida=n.IdMedida,
                                Cantidad=n.Cantidad
                            }).FirstOrDefault();
            }
            return Procesar;
        
        }
        #endregion

        #region MANTENIMIENTO DE SUMINISTRO HEADER
        /// <summary>
        /// Este metodo es para procesar la informacion de los suministros header
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroHeader ProcesarSuministroHeader(UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroHeader Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroHeader Procesar = null;

            var Header = ObjData.SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_HEADER(
                Item.NumeroSolicitud,
                Item.NumeroConector,
                Item.IdUsuario,
                Item.EstatusSolicitud,
                Accion);
            if (Header != null) {
                Procesar = (from n in Header
                            select new UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroHeader
                            {
                                NumeroSolicitud=n.NumeroSolicitud,
                                NumeroConector=n.NumeroConector,
                                IdUsuario=n.IdUsuario,
                                FechaSolicitud=n.FechaSolicitud,
                                EstatusSolicitud=n.EstatusSolicitud
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion

        #region MANTENIMIENTO DE SUMINISTRO DETALLE
        /// <summary>
        /// Este metodo procesa la informacion de los suministros dne detalle la solicitud
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroDetalle ProcesarSuministroDetalle(UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroDetalle Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroDetalle Procesar = null;

            var Detail = ObjData.SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_DETALLE(
                Item.SecuenciaDetalle,
                Item.NumeroConector,
                Item.CodigoArticulo,
                Item.Descripcion,
                Item.IdMedida,
                Item.Cantidad,
                Item.IdSucursal,
                Item.IdOficina,
                Item.IdCategoria,
                Item.StockMinimo,
                Item.Despachado,
                Accion);
            if (Detail != null) {

                Procesar = (from n in Detail
                            select new UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroDetalle
                            {
                                SecuenciaDetalle=n.SecuenciaDetalle,
                                NumeroConector=n.NumeroConector,
                                CodigoArticulo=n.CodigoArticulo,
                                Descripcion=n.Descripcion,
                                IdMedida=n.IdMedida,
                                Cantidad=n.Cantidad,
                                IdSucursal=n.IdSucursal,
                                IdOficina=n.IdOficina,
                                IdCategoria=n.IdCategoria,
                                StockMinimo=n.StockMinimo,
                                Despachado=n.Despachado
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion

        #region MANTENIMIENTO DE SUMINISTRO SOLICITUD
        /// <summary>
        /// Muestra el listado de las solicitudes
        /// </summary>
        /// <param name="NumeroSolicitud"></param>
        /// <param name="IdSucursal"></param>
        /// <param name="IdOficina"></param>
        /// <param name="IdDepartamento"></param>
        /// <param name="IdUsuario"></param>
        /// <param name="CodigoArticulo"></param>
        /// <param name="DescripcionArticulo"></param>
        /// <param name="IdCategoria"></param>
        /// <param name="IdUnidadMedida"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="IdEstatusSolicitud"></param>
        /// <param name="GeneradoPor"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroSolicitud> BuscaSuministroSulicitud(decimal? NumeroSolicitud = null, int? IdSucursal = null, int? IdOficina = null, int? IdDepartamento = null, decimal? IdUsuario = null, int? CodigoArticulo = null, string DescripcionArticulo = null, int? IdCategoria = null, int? IdUnidadMedida = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? IdEstatusSolicitud = null, decimal? GeneradoPor = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_SUMINISTRO_SOLICITUDES(NumeroSolicitud, IdSucursal, IdOficina, IdDepartamento, IdUsuario, CodigoArticulo, DescripcionArticulo, IdCategoria, IdUnidadMedida, FechaDesde, FechaHasta, IdEstatusSolicitud, GeneradoPor)
                           select new UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroSolicitud
                           {
                               NumeroSolicitud=n.NumeroSolicitud,
                               IdSucursal=n.IdSucursal,
                               Sucursal=n.Sucursal,
                               IdOficina=n.IdOficina,
                               Oficina=n.Oficina,
                               IdDepartamento=n.IdDepartamento,
                               Departamento=n.Departamento,
                               IdUsuario=n.IdUsuario,
                               Usuario=n.Usuario,
                               CodigoArticulo=n.CodigoArticulo,
                               DescripcionArticulo=n.DescripcionArticulo,
                               IdCategoria=n.IdCategoria,
                               Categoria=n.Categoria,
                               IdUnidadMedida=n.IdUnidadMedida,
                               UnidadMedida=n.UnidadMedida,
                               Cantidad=n.Cantidad,
                               Fecha0=n.Fecha0,
                               Fecha=n.Fecha,
                               Hora=n.Hora,
                               IdEstatusSolicitud=n.IdEstatusSolicitud,
                               Estatus=n.Estatus,
                               GeneradoPor=n.GeneradoPor,
                               CantidadSolicitudes=n.CantidadSolicitudes,
                               SolicitudesActivas=n.SolicitudesActivas,
                               SolicitudesProcesadas=n.SolicitudesProcesadas,
                               SolicitudesCanceladas=n.SolicitudesCanceladas,
                               SolicitudesRechazadas=n.SolicitudesRechazadas
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Procesar la Informacion de las solicitudes de inventario
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroSolicitud ProcesarSuministroSolicitudes(UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroSolicitud Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroSolicitud Procesar = null;

            var SuministroSolicitud = ObjData.SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUDES(
                Item.NumeroSolicitud,
                Item.IdSucursal,
                Item.IdOficina,
                Item.IdDepartamento,
                Item.IdUsuario,
                Item.CodigoArticulo,
                Item.DescripcionArticulo,
                Item.IdCategoria,
                Item.IdUnidadMedida,
                Item.Cantidad,
                Item.IdEstatusSolicitud,
                Accion);
            if (SuministroSolicitud != null) {

                Procesar = (from n in SuministroSolicitud
                            select new UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroSolicitud
                            {
                                  NumeroSolicitud =n.NumeroSolicitud,
                                  IdSucursal = n.IdSucursal,
                                  IdOficina = n.IdOficina,
                                  IdDepartamento = n.IdDepartamento,
                                  IdUsuario = n.IdUsuario,
                                  CodigoArticulo = n.CodigoArticulo,
                                  DescripcionArticulo = n.DescripcionArticulo,
                                  IdCategoria = n.IdCategoria,
                                  IdUnidadMedida = n.IdUnidadMedida,
                                  Cantidad = n.Cantidad,
                                  Fecha0 = n.Fecha,
                                  IdEstatusSolicitud = n.IdEstatusSolicitud
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion

        #region MANTENIMIENTO DE LAS SOLICITUDES ESPEJO
        /// <summary>
        /// Este metodo muestra el listado de los registros que se van a crear para la solicitud
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="Secuencial"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroSolicitudesEspejo> BuscaSuministroSolicitudesEspejo(decimal? IdUsuario = null, int? Secuencial = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_SUMINISTRO_SOLICITUDES_ESPEJO(IdUsuario, Secuencial)
                           select new UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroSolicitudesEspejo
                           {
                               Secuencial =n.Secuencial,
                               IdSucursal=n.IdSucursal,
                               Sucursal=n.Sucursal,
                               IdOficina=n.IdOficina,
                               Oficina=n.Oficina,
                               IdDepartamento=n.IdDepartamento,
                               Departamento=n.Departamento,
                               IdUsuario=n.IdUsuario,
                               Usuario=n.Usuario,
                               CodigoArticulo=n.CodigoArticulo,
                               DescripcionArticulo=n.DescripcionArticulo,
                               IdCategoria=n.IdCategoria,
                               Categoria=n.Categoria,
                               IdUnidadMedida=n.IdUnidadMedida,
                               UnidadMedida=n.UnidadMedida,
                               Cantidad=n.Cantidad,
                               Fecha0=n.Fecha0,
                               Fecha=n.Fecha,
                               Hora=n.Hora,
                               IdEstatusSolicitud=n.IdEstatusSolicitud,
                               Estatus=n.Estatus,
                               CantidadRegistros=n.CantidadRegistros
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este Metodo procesa la informacion de las solicitudes espejos
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroSolicitudesEspejo ProcesarSolicitudesEspepejo(UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroSolicitudesEspejo Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroSolicitudesEspejo Procesar = null;

            var SilicitudesEspejo = ObjData.SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUDES_ESPEJO(
                Item.Secuencial,
                Item.IdSucursal,
                Item.IdOficina,
                Item.IdDepartamento,
                Item.IdUsuario,
                Item.CodigoArticulo,
                Item.DescripcionArticulo,
                Item.IdCategoria,
                Item.IdUnidadMedida,
                Item.Cantidad,
                Item.IdEstatusSolicitud,
                Accion);
            if (SilicitudesEspejo != null) {

                Procesar = (from n in SilicitudesEspejo
                            select new UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroSolicitudesEspejo
                            {
                                  Secuencial =n.Secuencial,
                                  IdSucursal = n.IdSucursal,
                                  IdOficina = n.IdOficina,
                                  IdDepartamento = n.IdDepartamento,
                                  IdUsuario = n.IdUsuario,
                                  CodigoArticulo = n.CodigoArticulo,
                                  DescripcionArticulo = n.DescripcionArticulo,
                                  IdCategoria = n.IdCategoria,
                                  IdUnidadMedida = n.IdUnidadMedida,
                                  Cantidad = n.Cantidad,
                                  Fecha0 = n.Fecha,
                                  IdEstatusSolicitud = n.IdEstatusSolicitud
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion

        #region LISTADO DE SOLICITUDES
        /// <summary>
        /// Este metodo muestra las solicitudes creadas por los usuarios
        /// </summary>
        /// <param name="CodigoSucursal"></param>
        /// <param name="CodigoOficina"></param>
        /// <param name="CodigoDepartamento"></param>
        /// <param name="CodigoUsuario"></param>
        /// <param name="NumeroSocilitud"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="EstatusSolicitud"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Suministro.EListadoSolicitudesHeader> BuscaListadoSolicitudesHeader(int? CodigoSucursal = null, int? CodigoOficina = null, int? CodigoDepartamento = null, decimal? CodigoUsuario = null, decimal? NumeroSocilitud = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? EstatusSolicitud = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_LISTADO_SOLICITUDES_HEADER(CodigoSucursal, CodigoOficina, CodigoDepartamento, CodigoUsuario, NumeroSocilitud, FechaDesde, FechaHasta, EstatusSolicitud)
                           select new UtilidadesAmigos.Logica.Entidades.Suministro.EListadoSolicitudesHeader
                           {
                               NumeroSolicitud=n.NumeroSolicitud,
                               NumeroConector=n.NumeroConector,
                               IdUsuario=n.IdUsuario,
                               Persona=n.Persona,
                               IdSucursal=n.IdSucursal,
                               Sucursal=n.Sucursal,
                               IdOficina=n.IdOficina,
                               Oficina=n.Oficina,
                               IdDepartamento=n.IdDepartamento,
                               Departamento=n.Departamento,
                               FechaSolicitud0=n.FechaSolicitud0,
                               Fecha=n.Fecha,
                               Hora=n.Hora,
                               EstatusSolicitud=n.EstatusSolicitud,
                               Estatus=n.Estatus,
                               CantidadItems=n.CantidadItems,
                               CantidadSolicitudes=n.CantidadSolicitudes,
                               CantidadSolicitudes_Activas=n.CantidadSolicitudes_Activas,
                               CantidadSolicitudes_Procesadas=n.CantidadSolicitudes_Procesadas,
                               CantidadSolicitudes_Canceladas=n.CantidadSolicitudes_Canceladas,
                               CantidadSolicitudes_Rechazadas=n.CantidadSolicitudes_Rechazadas
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo busca el detalle de una solicitud seleccionda
        /// </summary>
        /// <param name="NumeroConector"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Suministro.EBuscaDetallesSolicitud> BuscaDetalleSolicitud(string NumeroConector = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_DETALLE_SOLICITUD(NumeroConector)
                           select new UtilidadesAmigos.Logica.Entidades.Suministro.EBuscaDetallesSolicitud
                           {
                               SecuenciaDetalle = n.SecuenciaDetalle,
                               NumeroConector = n.NumeroConector,
                               CodigoArticulo = n.CodigoArticulo,
                               Descripcion = n.Descripcion,
                               IdMedida = n.IdMedida,
                               UnidadMedida = n.UnidadMedida,
                               Cantidad = n.Cantidad,
                               IdSucursal = n.IdSucursal,
                               IdOficina = n.IdOficina,
                               IdCategoria = n.IdCategoria,
                               Categoria = n.Categoria,
                               StockMinimo = n.StockMinimo,
                               Disponible = n.Disponible,
                               Estatus = n.Estatus,
                               Despachado0 = n.Despachado0,
                               Despachado = n.Despachado
                           }).ToList();
            return Listado;
        }
        #endregion
    }
}
