using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                Cantidad=n.Cantidad
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion
    }
}
