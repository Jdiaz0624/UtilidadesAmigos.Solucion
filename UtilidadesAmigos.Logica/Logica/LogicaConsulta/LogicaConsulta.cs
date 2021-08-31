using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Logica.LogicaConsulta
{
    public class LogicaConsulta
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDConexionConsultaDataContext ObjData = new Data.Conexiones.LINQ.BDConexionConsultaDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

        #region MANTENIMIENTO DE GESTION DE COBROS
        /// <summary>
        /// Este metodo es buscar los registros mediante la poliza y el codigo del cliente
        /// </summary>
        /// <param name="Poliza"></param>
        /// <param name="CodigoCliente"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EBuscarInformacionPolizasGestionCobros> BuscaPolizaGestionCobros(string Poliza = null, decimal? CodigoCliente = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCAR_INFORMACION_POLIZA_GESTION_COBRO(Poliza, CodigoCliente)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.EBuscarInformacionPolizasGestionCobros
                           {
                               Poliza=n.Poliza,
                               Ramo=n.Ramo,
                               Subramo=n.Subramo,
                               CodigoRamo=n.CodigoRamo,
                               CodigoSubRamo=n.CodigoSubRamo,
                               Estatus=n.Estatus,
                               SumaAsegurada=n.SumaAsegurada,
                               Cliente=n.Cliente,
                               NombreCliente=n.NombreCliente,
                               Direccion=n.Direccion,
                               Telefonos=n.Telefonos,
                               CodigoIntermediario=n.CodigoIntermediario,
                               Intermediario=n.Intermediario,
                               LicenciaSeguro=n.LicenciaSeguro,
                               CodigoSupervisor=n.CodigoSupervisor,
                               Supervisor=n.Supervisor,
                               FechaAdiciona=n.FechaAdiciona,
                               FechaCreada=n.FechaCreada,
                               FechaInicioVigencia=n.FechaInicioVigencia,
                               InicioVigencia=n.InicioVigencia,
                               FechaFinVigencia=n.FechaFinVigencia,
                               FinVigencia=n.FinVigencia,
                               Facturado=n.Facturado,
                               Cobrado=n.Cobrado,
                               Balance=n.Balance,
                               TotalFacturas=n.TotalFacturas,
                               TotalRecibos=n.TotalRecibos,
                               TotalReclamaciones=n.TotalReclamaciones


                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo muestra el listado de comentarios asignados a una poliza
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Poliza"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EComentarioGestionCobro> BuscarComentariosAgregadosPoliza(decimal? ID = null, string Poliza = null,DateTime? FechaDesde = null, DateTime? FechaHasta = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_GESTION_COBROS_COMENTARIO_POLIZA(ID, Poliza,FechaDesde,FechaHasta)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.EComentarioGestionCobro
                           {
                               ID=n.ID,
                               Poliza=n.Poliza,
                               Comentario=n.Comentario,
                               IdUsuario=n.IdUsuario,
                               Usuario=n.Usuario,
                               FechaProceso=n.FechaProceso,
                               Fecha=n.Fecha,
                               Hora=n.Hora,
                               CantidadRegistros=n.CantidadRegistros
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo es para procesar la información de los comentarios de la gestion de cobros
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Consulta.EComentarioGestionCobro ProcesarComentarioPolizaGestionCObro(UtilidadesAmigos.Logica.Entidades.Consulta.EComentarioGestionCobro Item, string Accion) {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Consulta.EComentarioGestionCobro Procesar = null;

            var ComentarioPoliza = ObjData.SP_PROCESAR_COMENTARIO_POLIZA(
                Item.ID,
                Item.Poliza,
                Item.Comentario,
                Item.IdUsuario,
                Accion);
            if (ComentarioPoliza != null) {
                Procesar = (from n in ComentarioPoliza
                            select new UtilidadesAmigos.Logica.Entidades.Consulta.EComentarioGestionCobro
                            {
                                ID=n.ID,
                                Poliza=n.Poliza,
                                Comentario=n.Comentario,
                                IdUsuario=n.IdUsuario,
                                FechaProceso=n.FechaProceso
                            }).FirstOrDefault();
            }
            return Procesar;
        }

        /// <summary>
        /// Este metodo es para procesar informacion para generar el reporte
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarInformacionReporteComentarioGestionCobro ProcesarComentarioGestionCobro(UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarInformacionReporteComentarioGestionCobro Item, string Accion) {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarInformacionReporteComentarioGestionCobro Procesar = null;

            var ReporteComentarioGestionCobro = ObjData.SP_PROCESAR_INFORMACON_REPORTE_COMENTARIO_GESTION_COBRO(
                Item.NumeroRegistro,
                Item.Poliza,
                Item.Comentario,
                Item.IdUsuario,
                Item.Usuario,
                Item.FechaProceso,
                Item.Fecha,
                Item.Hora,
                Item.CantidadRegistros,
                Item.IdUsuarioGenera,
                Accion);
            if (ReporteComentarioGestionCobro != null) {
                Procesar = (from n in ReporteComentarioGestionCobro
                            select new UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarInformacionReporteComentarioGestionCobro
                            {
                                NumeroRegistro=n.NumeroRegistro,
                                Poliza=n.Poliza,
                                Comentario=n.Comentario,
                                IdUsuario=n.IdUsuario,
                                Usuario=n.Usuario,
                                FechaProceso=n.FechaProceso,
                                Fecha=n.Fecha,
                                Hora=n.Hora,
                                CantidadRegistros=n.CantidadRegistros,
                                IdUsuarioGenera=n.IdUsuarioGenera
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion

    }
}
