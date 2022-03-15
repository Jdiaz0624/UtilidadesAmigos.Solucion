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
        /// Este metodo muestra los registros guardados en la base de datos para manupular el inventario de suministro
        /// </summary>
        /// <param name="CodigoArticulo"></param>
        /// <param name="Articulo"></param>
        /// <param name="IdMedida"></param>
        /// <param name="Estatus"></param>
        /// <param name="GeneradoPor"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroInventario> BuscaInventarioSuministro(decimal? CodigoArticulo = null, string Articulo = null, int? IdMedida = null, string Estatus = null, decimal? GeneradoPor = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_SUMINISTRO_INVENTARIO(CodigoArticulo, Articulo, IdMedida, Estatus, GeneradoPor)
                           select new UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroInventario
                           {
                               CodigoArticulo=n.CodigoArticulo,
                               Articulo=n.Articulo,
                               IdMedida=n.IdMedida,
                               Medida=n.Medida,
                               Stock=n.Stock,
                               Estatus=n.Estatus,
                               UsuarioCrea=n.UsuarioCrea,
                               CreadoPor=n.CreadoPor,
                               FechaCrea0=n.FechaCrea0,
                               FechaCreado=n.FechaCreado,
                               HoraCreado=n.HoraCreado,
                               UsuarioModifica=n.UsuarioModifica,
                               ModificadoPor=n.ModificadoPor,
                               FechaModifica0=n.FechaModifica0,
                               FechaModificado=n.FechaModificado,
                               HoraModificado=n.HoraModificado,
                               GeneradoPor=n.GeneradoPor

                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo procesa la informaición del inventario de suministro
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroInventario ProcesarSuministroInventario(UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroInventario Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroInventario Procesar = null;

            var Inventario = ObjData.SP_PROCESAR_INFORMACION_SUMINISTRO_INVENTARIO(
                Item.CodigoArticulo,
                Item.Articulo,
                Item.IdMedida,
                Item.Stock,
                Item.UsuarioCrea,
                Accion);
            if (Inventario != null) {

                Procesar = (from n in Inventario
                            select new UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroInventario
                            {
                                CodigoArticulo=n.CodigoArticulo,
                                Articulo=n.Articulo,
                                IdMedida=n.IdMedida,
                                Stock=n.Stock,
                                UsuarioCrea=n.UsuarioCrea,
                                FechaCrea0=n.FechaCrea,
                                UsuarioModifica=n.UsuarioModifica,
                                FechaModifica0=n.FechaModifica
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
