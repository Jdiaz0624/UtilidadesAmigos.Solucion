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
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EComentarioGestionCobro> BuscarComentariosAgregadosPoliza(decimal? ID = null, string Poliza = null,DateTime? FechaDesde = null, DateTime? FechaHasta = null,decimal? IdUsuario = null,string FechaFinVigencia = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_GESTION_COBROS_COMENTARIO_POLIZA(ID, Poliza,FechaDesde,FechaHasta, IdUsuario, FechaFinVigencia)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.EComentarioGestionCobro
                           {
                               ID=n.ID,
                               Poliza=n.Poliza,
                               Comentario=n.Comentario,
                               IdUsuario=n.IdUsuario,
                               Usuario=n.Usuario,
                               FechaProceso=n.FechaProceso,
                               Fecha=n.Fecha,
                               HoraLLamada=n.Hora1,
                               IdEstatusLlamada=n.IdEstatusLlamada,
                               EstatusLlamada=n.EstatusLlamada,
                               IdConceptoLlamada=n.IdConceptoLlamada,
                               ConceptoLlamada=n.ConceptoLlamada,
                               FechaFinVigencia=n.FechaFinVigencia,
                               NumeroSeguimiento=n.NumeroSeguimiento,
                               FechaNuevaLlamada0=n.FechaNuevaLlamada0,
                               FechaLlamada=n.FechaLlamada,
                               //HoraLLamada=n.HoraLLamada,
                               //NuevaLLamada=n.NuevaLLamada,
                               CantidadRegistros =n.CantidadRegistros
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
                Item.IdEstatusLlamada,
                Item.IdConceptoLlamada,
                Item.FechaFinVigencia,
                Item.NumeroSeguimiento,
                Item.FechaNuevaLlamada0,
                Item.HoraLLamada,
                Accion);
            if (ComentarioPoliza != null) {
                Procesar = (from n in ComentarioPoliza
                            select new UtilidadesAmigos.Logica.Entidades.Consulta.EComentarioGestionCobro
                            {
                                ID=n.ID,
                                Poliza=n.Poliza,
                                Comentario=n.Comentario,
                                IdUsuario=n.IdUsuario,
                                FechaProceso=n.FechaProceso,
                                IdEstatusLlamada=n.IdEstatusLlamada,
                                IdConceptoLlamada=n.IdConceptoLlamada,
                                FechaFinVigencia=n.FechaFinVigencia,
                                NumeroSeguimiento=n.NumeroSeguimiento,
                                FechaNuevaLlamada0=n.FechaNuevaLlamada,
                                HoraLLamada=n.Hora
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

        #region VALIDACIOND DE LA DATA DE COBERTURA
        public UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarInformacionValidacionArchivo ProcesarValidacionCoberturaArchivo(UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarInformacionValidacionArchivo Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarInformacionValidacionArchivo Procesar = null;

            var ValidarcionCoberturaArchivo = ObjData.SP_PROCESAR_INFORMACION_COBERTURA_VALIDACION_ARCHIVO(
                Item.NumeroRegistro,
                Item.IdUaurioProceso,
                Item.Poliza,
                Item.Chasis,
                Item.Placa,
                Item.Cobertura,
                Accion);
            if (ValidarcionCoberturaArchivo != null) {
                Procesar = (from n in ValidarcionCoberturaArchivo
                            select new UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarInformacionValidacionArchivo
                            {
                                NumeroRegistro=n.NumeroRegistro,
                                IdUaurioProceso=n.IdUaurioProceso,
                                Poliza=n.Poliza,
                                Chasis=n.Chasis,
                                Placa=n.Placa,
                                Cobertura=n.Cobertura
                            }).FirstOrDefault();
            }
            return Procesar;
        }

        public UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarInformacionValidacionCoberturaSistema ProcesarValidacionCoberturaArchivo(UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarInformacionValidacionCoberturaSistema Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarInformacionValidacionCoberturaSistema Procesar = null;

            var Coberturas = ObjData.SP_PROCESAR_INFORMACION_VALIDACION_COBERTURA_SISTEMA(
                Item.NumeroRegistro,
                Item.IdUsuario,
                Item.Poliza,
                Item.Items,
                Item.Estatus,
                Item.Concepto,
                Item.Cliente,
                Item.NombreCliente,
                Item.ApellidoCliente,
                Item.Ciudad,
                Item.DireccionCliente,
                Item.Telefono,
                Item.TipoIdentificacion,
                Item.NumeroIdentificacion,
                Item.Intermediario,
                Item.FechaInicioVigencia,
                Item.FechaFinVigencia,
                Item.InicioVigencia,
                Item.FinVigencia,
                Item.FechaProceso,
                Item.FechaProcesoBruto,
                Item.MesValidado,
                Item.TipoVehiculo,
                Item.Marca,
                Item.Modelo,
                Item.Capacidad,
                Item.Ano,
                Item.Color,
                Item.Chasis,
                Item.Placa,
                Item.ValorAsegurado,
                Item.Cobertura,
                Item.TipoMovimiento,
                Item.CantidadRegistros,
                Item.ValidadoDesde,
                Item.ValidadoHasta,
                Item.GeneradoPor,
                Item.Oficina,
                Accion);
            if (Coberturas != null) {
                Procesar = (from n in Coberturas
                            select new UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarInformacionValidacionCoberturaSistema
                            {
                                NumeroRegistro = n.NumeroRegistro,
                                IdUsuario = n.IdUsuario,
                                Poliza = n.Poliza,
                                Items = n.Items,
                                Estatus = n.Estatus,
                                Concepto = n.Concepto,
                                Cliente = n.Cliente,
                                NombreCliente = n.NombreCliente,
                                ApellidoCliente = n.ApellidoCliente,
                                Ciudad = n.Ciudad,
                                DireccionCliente = n.DireccionCliente,
                                Telefono = n.Telefono,
                                TipoIdentificacion = n.TipoIdentificacion,
                                NumeroIdentificacion = n.NumeroIdentificacion,
                                Intermediario = n.Intermediario,
                                FechaInicioVigencia = n.FechaInicioVigencia,
                                FechaFinVigencia = n.FechaFinVigencia,
                                InicioVigencia = n.InicioVigencia,
                                FinVigencia = n.FinVigencia,
                                FechaProceso = n.FechaProceso,
                                FechaProcesoBruto = n.FechaProcesoBruto,
                                MesValidado = n.MesValidado,
                                TipoVehiculo = n.TipoVehiculo,
                                Marca = n.Marca,
                                Modelo = n.Modelo,
                                Capacidad = n.Capacidad,
                                Ano = n.Ano,
                                Color = n.Color,
                                Chasis = n.Chasis,
                                Placa = n.Placa,
                                ValorAsegurado = n.ValorAsegurado,
                                Cobertura = n.Cobertura,
                                TipoMovimiento = n.TipoMovimiento,
                                CantidadRegistros = n.CantidadRegistros,
                                ValidadoDesde = n.ValidadoDesde,
                                ValidadoHasta = n.ValidadoHasta,
                                GeneradoPor = n.GeneradoPor,
                                Oficina = n.Oficina
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion


        #region MOSTRAR EL CONCEPTO DE LLAMADAS
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EConceptoLLamadas> BuscaCOnceptoLLamadas(int? IdConceptoLlamada = null, int? IdEstatusLlamada = null, string Descripcion = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_CONCEPTO_LLAMADA(IdConceptoLlamada, IdEstatusLlamada, Descripcion)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.EConceptoLLamadas
                           {
                               IdConceptoLlamada=n.IdConceptoLlamada,
                               IdEstatusLlamada=n.IdEstatusLlamada,
                               EstatusLLamada=n.EstatusLLamada,
                               ConceptoLLamada=n.ConceptoLLamada,
                               Estatus0=n.Estatus0,
                               Estatus=n.Estatus,
                               AplicaParaAviso0=n.AplicaParaAviso0,
                               AplicaParaAviso=n.AplicaParaAviso,

                           }).ToList();
            return Listado;
        }
        #endregion

        #region MANTENIMIENTO DE POLIZA PARA AVISO DE GESTION DE COBROS
        /// <summary>
        /// LISTADO DE POLIZAS PARA LA GESTION DE COBROS
        /// </summary>
        /// <param name="NumeroRegistro"></param>
        /// <param name="Poliza"></param>
        /// <param name="IdEstatusLlamada"></param>
        /// <param name="IdConceptoLlamada"></param>
        /// <param name="IdUsuario"></param>
        /// <param name="FechaGuardadoDesde"></param>
        /// <param name="FechaGuardadoHasta"></param>
        /// <param name="Estatus"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EPolizasAvisoGestionCobros> BuscaPolizaAvisoGestionCobro(decimal? NumeroRegistro = null, string Poliza = null, int? IdEstatusLlamada = null, int? IdConceptoLlamada = null, decimal? IdUsuario = null, DateTime? FechaGuardadoDesde = null, DateTime? FechaGuardadoHasta = null, bool? Estatus = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_POLIZAS_PARA_AVISO_GESTION_COBROS(NumeroRegistro, Poliza, IdEstatusLlamada, IdConceptoLlamada, IdUsuario, FechaGuardadoDesde, FechaGuardadoHasta, Estatus)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.EPolizasAvisoGestionCobros
                           {
                               NumeroRegistro=n.NumeroRegistro,
                               Poliza=n.Poliza,
                               IdEstatusLlamada=n.IdEstatusLlamada,
                               EstatusLlamada=n.EstatusLlamada,
                               IdConceptoLlamada=n.IdConceptoLlamada,
                               ConceptoLlamada=n.ConceptoLlamada,
                               Comentario=n.Comentario,
                               IdUsuario=n.IdUsuario,
                               Usuario=n.Usuario,
                               FechaGuardado=n.FechaGuardado,
                               Fecha=n.Fecha,
                               Hora=n.Hora,
                               InicioVigencia=n.InicioVigencia,
                               FinVigencia=n.FinVigencia,
                               Estatus0=n.Estatus0,
                               Estatus=n.Estatus,
                               FechaNuevaLLamada0=n.FechaNuevaLLamada0,
                               FechaNuevaLlamada=n.FechaNuevaLlamada,
                               HoraNuevaLLamada=n.HoraNuevaLLamada,
                               NuevaLlamada=n.NuevaLlamada,
                               CantidadRegistrosNoProcesados=n.CantidadRegistrosNoProcesados,
                               CantidadRegistrosProcesados=n.CantidadRegistrosProcesados,
                               CantidadRegistrosNoProcesadosParametros=n.CantidadRegistrosNoProcesadosParametros,
                               CantidadRegistrosProcesadosParametros=n.CantidadRegistrosProcesadosParametros
                           }).ToList();
            return Listado;
        }


        /// <summary>
        /// Mantenimiento para procesar las informaciones de las polizas para aviso en gestion de cobros
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Consulta.EPolizasAvisoGestionCobros ProcesarPolizasGestionCobros(UtilidadesAmigos.Logica.Entidades.Consulta.EPolizasAvisoGestionCobros Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Consulta.EPolizasAvisoGestionCobros Procesar = null;

            var PolizasAvisoGestionCobros = ObjData.SP_PROCESAR_INFORMACION_POLIZAS_AVISO_GESTION_COBROS(
                Item.NumeroRegistro,
                Item.Poliza,
                Item.IdEstatusLlamada,
                Item.IdConceptoLlamada,
                Item.Comentario,
                Item.IdUsuario,
                Item.InicioVigencia,
                Item.FinVigencia,
                Item.Estatus0,
                Item.FechaNuevaLLamada0,
                Item.HoraNuevaLLamada,
                Accion);
            if (PolizasAvisoGestionCobros != null) {
                Procesar = (from n in PolizasAvisoGestionCobros
                            select new UtilidadesAmigos.Logica.Entidades.Consulta.EPolizasAvisoGestionCobros
                            {
                                NumeroRegistro=n.NumeroRegistro,
                                Poliza=n.Poliza,
                                IdEstatusLlamada=n.IdEstatusLlamada,
                                IdConceptoLlamada=n.IdConceptoLlamada,
                                Comentario=n.Comentario,
                                IdUsuario=n.IdUsuario,
                                FechaGuardado=n.FechaGuardado,
                                InicioVigencia=n.InicioVigencia,
                                FinVigencia=n.FinVigencia,
                                Estatus0=n.Estatus,
                                FechaNuevaLLamada0=n.FechaNuevaLlamada,
                                HoraNuevaLLamada=n.HoraNuevaLlamada,
                            }).FirstOrDefault();
            }
            return Procesar;
        }

        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EBuscaDatosVehiculoGestionCobros> BuscaDatosVehiculoGestion(string Poliza = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_DATOS_VEHICULO_GESTION_COBRO(Poliza)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.EBuscaDatosVehiculoGestionCobros
                           {
                               Poliza=n.Poliza,
                               Item=n.Item,
                               Tipo=n.Tipo,
                               Marca=n.Marca,
                               Modelo=n.Modelo,
                               Ano=n.Ano,
                               Color=n.Color,
                               Chasis=n.Chasis,
                               Placa=n.Placa
                           }).ToList();
            return Listado;
        }

        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EGenerarReporteCobroFinal> ReporteGestionCObroPlano(string Poliza = null, decimal? IdUsuarioCreo = null, DateTime? FechaProcesoDesde = null, DateTime? FechaProcesoHasta = null, decimal? UsuarioGenera = null, bool? NOLLevaRangoFecha = null) {

            ObjData.CommandTimeout = 999999999;

            var ExcelPlano = (from n in ObjData.SP_GENERAR_REPORTE_GESTION_COBROS_FINAL(Poliza, IdUsuarioCreo, FechaProcesoDesde, FechaProcesoHasta, UsuarioGenera, NOLLevaRangoFecha)
                              select new UtilidadesAmigos.Logica.Entidades.Consulta.EGenerarReporteCobroFinal
                              {
                                  ID=n.ID,
                                  Poliza=n.Poliza,
                                  Comentario=n.Comentario,
                                  IdUsuario=n.IdUsuario,
                                  CreadoPor=n.CreadoPor,
                                  FechaProceso=n.FechaProceso,
                                  Fecha=n.Fecha,
                                  Hora=n.Hora,
                                  IdEstatusLlamada=n.IdEstatusLlamada,
                                  EstatusLlamada=n.EstatusLlamada,
                                  IdConceptoLlamada=n.IdConceptoLlamada,
                                  ConceptoLlamada=n.ConceptoLlamada,
                                  FechaFinVigencia=n.FechaFinVigencia,
                                  NumeroSeguimiento=n.NumeroSeguimiento,
                                  ValidadoDesde=n.ValidadoDesde,
                                  ValidadoHAsta=n.ValidadoHAsta,
                                  NoLLevaRangoFecha0=n.NoLLevaRangoFecha0,
                                  NoLlevaRangoFecha=n.NoLlevaRangoFecha,
                                  GeneradoPor=n.GeneradoPor
                              }).ToList();
            return ExcelPlano;
        }
        #endregion

        #region CARTERA
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.ECarteraIntermediarios> SacarCarteraIntermeiario(int? Intermediario = null, string EstatusPoliza = null) {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_SACAR_CARTERA_INTERMEDIARIOS(Intermediario, EstatusPoliza)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.ECarteraIntermediarios
                           {
                               Poliza=n.Poliza,
                               EstatusPoliza=n.EstatusPoliza,
                               SumaAsegurada=n.SumaAsegurada,
                               CodigoCliente=n.CodigoCliente,
                               Cliente=n.Cliente,
                               Intermediario=n.Intermediario,
                               NombreVendedor=n.NombreVendedor,
                               Estatus=n.Estatus,
                               EstatusIntermediario=n.EstatusIntermediario,
                               Facturado=n.Facturado,
                               Cobrado=n.Cobrado,
                               Balance=n.Balance,
                               PolizasActivas=n.PolizasActivas,
                               PolizasCanceladas=n.PolizasCanceladas,
                               PolizasTransito=n.PolizasTransito,
                               PolizasExclusion=n.PolizasExclusion
                           }).ToList();
            return Listado;
        }

        public List<UtilidadesAmigos.Logica.Entidades.Consulta.ECarteraEjecutivos> SacarCarteraEjecutivos(int? CodigoSupervisor = null, int? CodigoIntermediario = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_SACAR_CARTERA_EJECUTIVOS(CodigoSupervisor, CodigoIntermediario)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.ECarteraEjecutivos
                           {
                               IdIntermediarioSupervisa=n.IdIntermediarioSupervisa,
                               NombreSupervisor=n.NombreSupervisor,
                               IdIntermediario=n.IdIntermediario,
                               NombreIntermediario=n.NombreIntermediario,
                               Estatus=n.Estatus,
                               EstatusVendedor=n.EstatusVendedor,
                               TotalIntermediarios=n.TotalIntermediarios
                           }).ToList();
            return Listado;
        }
        #endregion

        #region ESTADISTICA DE RENOVACION
        /// <summary>
        /// Este metodo es para buscar el origen de las polizas que estan por renovar segun los rapametros o filtros suministrados
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="Oficina"></param>
        /// <param name="Ramo"></param>
        /// <param name="SubRamo"></param>
        /// <param name="Poliza"></param>
        /// <param name="Intermediario"></param>
        /// <param name="Supervisor"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EEstadisticaRenovacionOrigen> BuscaEstadisticaRenovacionOrigen(DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? Oficina = null, int? Ramo = null, int? SubRamo=null, string Poliza = null, int? Intermediario = null, int? Supervisor = null,bool? ExcluirMotores = null) {


            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_ESTADISTICA_RENOVACION_ORIGEN(FechaDesde, FechaHasta, Oficina, Ramo,SubRamo, Poliza, Intermediario, Supervisor, ExcluirMotores)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.EEstadisticaRenovacionOrigen
                           {
                               Cotizacion=n.Cotizacion,
                               Poliza=n.Poliza,
                               Estatus=n.Estatus,
                               CodigoOficina=n.CodigoOficina,
                               Ramo=n.Ramo,
                               Bruto=n.Bruto,
                               CodigoIntermediario=n.CodigoIntermediario,
                               CodigoSupervisor=n.CodigoSupervisor,
                               ValidadoDesde=n.ValidadoDesde,
                               ValidadoHasta=n.ValidadoHasta,
                               ExcluirMotores=n.ExcluirMotores
                           }).ToList();
            return Listado;
          
        }

        /// <summary>
        /// Este metodo es para guardar y eliminar registros enn la tabla de estadistica de renovacion
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarDatosEstadistocaRenovacion ProcesarDatosEstadisticaRenovacion(UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarDatosEstadistocaRenovacion Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarDatosEstadistocaRenovacion Procesar = null;

            var EstadisticaRenovacion = ObjData.SP_PROCESAR_DATA_ESTADISTICA_RENOVACION(
                Item.IdUsuario,
                Item.Cotizacion,
                Item.Poliza,
                Item.Estatus,
                Item.CodigoOficina,
                Item.Ramo,
                Item.Prima,
                Item.CodigoIntermediario,
                Item.CodigoSupervisor,
                Item.ValidadoDesde,
                Item.ValidadoHasta,
                Item.ExcluirMotores,
                Accion);
            if (EstadisticaRenovacion != null) {

                Procesar = (from n in EstadisticaRenovacion
                            select new UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarDatosEstadistocaRenovacion
                            {
                                IdUsuario = n.IdUsuario,
                                Cotizacion = n.Cotizacion,
                                Poliza = n.Poliza,
                                Estatus=n.Estatus,
                                CodigoOficina = n.CodigoOficina,
                                Ramo = n.Ramo,
                                Prima = n.Prima,
                                CodigoIntermediario = n.CodigoIntermediario,
                                CodigoSupervisor = n.CodigoSupervisor,
                                ValidadoDesde = n.ValidadoDesde,
                                ValidadoHasta = n.ValidadoHasta,
                                ExcluirMotores=n.ExcluirMotores

                            }).FirstOrDefault();
            }
            return Procesar;

        }

        /// <summary>
        /// Este metodo muestra la data cargada
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EMostrarDataCargadaEstadisticaRenovacion> MostrarDataCargadaEstadisticaRenovacion(decimal? IdUsuario = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_MOSTRAR_DATA_CARGADA_ESTADISTICA_RENOVACION(IdUsuario)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.EMostrarDataCargadaEstadisticaRenovacion
                           {
                               IdUsuario=n.IdUsuario,
                               GeneradoPor=n.GeneradoPor,
                               Cotizacion=n.Cotizacion,
                               Poliza=n.Poliza,
                               Estatus=n.Estatus,
                               CodigoOficina=n.CodigoOficina,
                               Oficina=n.Oficina,
                               Ramo=n.Ramo,
                               NombreRamo=n.NombreRamo,
                               Prima=n.Prima,
                               CodigoIntermediario=n.CodigoIntermediario,
                               Intermediario=n.Intermediario,
                               CodigoSupervisor=n.CodigoSupervisor,
                               Supervisor=n.Supervisor,
                               ValidadoDesde0=n.ValidadoHasta0,
                               ValidadoHasta0=n.ValidadoHasta0,
                               ValidadoDesde=n.ValidadoDesde,
                               ValidadoHasta=n.ValidadoHasta,
                               CantidadRenovadas=n.CantidadRenovadas,
                               MontoRenovado=n.MontoRenovado,
                               CantidadCanceladas=n.CantidadCanceladas,
                               MontoCancelado=n.MontoCancelado,
                               Cobrado=n.Cobrado
                           }).ToList();
            return Listado;
        }


        /// <summary>
        /// Este metodo muestra la estadistica de renovacion segun la data cargarda y sus filtros
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EMostrarDetalleEstadisticaRenovacion> DetalleEstadisticaRenovacion(decimal? IdUsuario = null) {

            ObjData.CommandTimeout = 999999999;

            var Detalle = (from n in ObjData.SP_MOSTRAR_DETALLE_ESTADISTICA_RENOVACION(IdUsuario)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.EMostrarDetalleEstadisticaRenovacion
                           {
                               IdUsuario=n.IdUsuario,
                               GeneradoPor=n.GeneradoPor,
                               Cotizacion=n.Cotizacion,
                               InicioVigencia=n.InicioVigencia,
                               FinVigencia=n.FinVigencia,
                               Poliza=n.Poliza,
                               Estatus=n.Estatus,
                               Cliente=n.Cliente,
                               TelefonoResidencia=n.TelefonoResidencia,
                               TelefonoOficina=n.TelefonoOficina,
                               Celular=n.Celular,
                               fax=n.fax,
                               CodigoOficina=n.CodigoOficina,
                               Oficina=n.Oficina,
                               Ramo=n.Ramo,
                               NombreRamo=n.NombreRamo,
                               Prima=n.Prima,
                               CodigoIntermediario=n.CodigoIntermediario,
                               Intermediario=n.Intermediario,
                               CodigoSupervisor=n.CodigoSupervisor,
                               Supervisor=n.Supervisor,
                               ValidadoDesde0=n.ValidadoDesde0,
                               ValidadoHasta0=n.ValidadoHasta0,
                               ValidadoDesde=n.ValidadoDesde,
                               ValidadoHasta=n.ValidadoHasta,
                               ExcluirMotores0=n.ExcluirMotores0,
                               ExcluirMotores=n.ExcluirMotores,
                               CantidadRenovadas=n.CantidadRenovadas,
                               Renovada=n.Renovada,
                               MontoRenovado=n.MontoRenovado,
                               CantidadCanceladas=n.CantidadCanceladas,
                               Cancelada=n.Cancelada,
                               MontoCancelado=n.MontoCancelado,
                               Cobrado=n.Cobrado
                           }).ToList();
            return Detalle;
        }


        /// <summary>
        /// Este Metodo Muestra la cantidad agrupada
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="TipoAgrupacion"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EEstadisticaRenovacionAgrupada> BuscaEstadisticaRenovacionAgrupada(decimal? IdUsuario = null, int? TipoAgrupacion = null) {

            ObjData.CommandTimeout = 999999999;

            var Informacion = (from n in ObjData.SP_MOSTRAR_ESTADISTICA_RENOVACION_AGRUPADA(IdUsuario, TipoAgrupacion)
                               select new UtilidadesAmigos.Logica.Entidades.Consulta.EEstadisticaRenovacionAgrupada
                               {
                                  Entidad=n.Entidad,
                                   Codigo=n.Codigo,
                                   ExcluirMotores=n.ExcluirMotores,
                                   ValidadoDesde=n.ValidadoDesde,
                                   ValidadoHasta=n.ValidadoHasta,
                                   GeneradoPor=n.GeneradoPor,
                                   CantidadARenovar=n.CantidadARenovar,
                                   MontoARenovar=n.MontoARenovar,
                                   CantidadRenovadas=n.CantidadRenovadas,
                                   MontoRenovado=n.MontoRenovado,
                                   CantidadCanceladas=n.CantidadCanceladas,
                                   MontoCancelado=n.MontoCancelado,
                                   Cobrado=n.Cobrado,
                                   CantidadPendiente=n.CantidadPendiente,
                                   MontoPendienteRenovar=n.MontoPendienteRenovar
                                   
                               }).ToList();
            return Informacion;
        }

        /// <summary>
        /// Este metodo muestra el detalle de la estadistica de renovacion
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EDetalleEstadisticaRenovacion> GenerarDetalleEstadisticaRenovacion(decimal? IdUsuario = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_GENERAR_DETALLE_ESTADISTICA_RENOVACION(IdUsuario)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.EDetalleEstadisticaRenovacion
                           {
                               IdUsuario=n.IdUsuario,
                               GeneradoPor=n.GeneradoPor,
                               Cotizacion=n.Cotizacion,
                               Secuencia=n.Secuencia,
                               Poliza=n.Poliza,
                               CodigoOficina=n.CodigoOficina,
                               Oficina=n.Oficina,
                               CodigoRamo=n.CodigoRamo,
                               NombreRamo=n.NombreRamo,
                               CodigoSubRamo=n.CodigoSubRamo,
                               NombreSubramo=n.NombreSubramo,
                               Prima=n.Prima,
                               FechaInicioVigencia = n.FechaInicioVigencia,
                               FechaFinVigencia1=n.FechaFinVigencia,
                               InicioVigencia=n.InicioVigencia,
                               FinVigencia=n.FinVigencia,
                               CodigoIntermediario=n.CodigoIntermediario,
                               Intermediario=n.Intermediario,
                               CodigoSupervisor=n.CodigoSupervisor,
                               Supervisor=n.Supervisor,
                               CodigoCliente=n.CodigoCliente,
                               Cliente=n.Cliente,
                               TelefonoResidencia=n.TelefonoResidencia,
                               TelefonoOficina=n.TelefonoOficina,
                               Celular=n.Celular,
                               fax=n.fax,
                               Renovada=n.Renovada,
                               MontoRenovado=n.MontoRenovado,
                               Cancelada=n.Cancelada,
                               MontoCancelado=n.MontoCancelado,
                               Cobrado=n.Cobrado,
                               ValidadoDesde=n.ValidadoDesde,
                               ValidadoHasta=n.ValidadoHasta
                           }).ToList();
            return Listado;
        }
        #endregion


        #region MANTENIMIENTO DE REGISTROS IMCOMPLETOS
        /// <summary>
        /// Este Metodo es para buscar la información de los clientes que esta registrados sin polizas asignadas.
        /// </summary>
        /// <param name="CodigoCliente"></param>
        /// <param name="Numeroidentificacion"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="Supervisor"></param>
        /// <param name="Intermediario"></param>
        /// <param name="NombreCliente"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EClientesSinPoliza> BuscaClientesSinPolizas(decimal? CodigoCliente = null, string Numeroidentificacion = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? Supervisor = null, int? Intermediario = null, string NombreCliente = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_CLIENTE_SIN_POLIZAS(CodigoCliente, Numeroidentificacion, FechaDesde, FechaHasta, Supervisor, Intermediario, NombreCliente)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.EClientesSinPoliza
                           {
                               Codigo=n.Codigo,
                               TipoIdentificacion=n.TipoIdentificacion,
                               RNC=n.RNC,
                               Cliente=n.Cliente,
                               Direccion=n.Direccion,
                               CodigoSupervisor=n.CodigoSupervisor,
                               CodigoIntermediario=n.CodigoIntermediario,
                               Supervisor=n.Supervisor,
                               Intermediario=n.Intermediario,
                               Cobrador=n.Cobrador,
                               UsuarioAdiciona=n.UsuarioAdiciona,
                               fecha0=n.fecha0,
                               Fecha=n.Fecha,
                               TelefonoResidencia=n.TelefonoResidencia,
                               TelefonoOficina=n.TelefonoOficina,
                               Celular=n.Celular,
                               fax=n.fax,
                               Beeper=n.Beeper,
                               Comprobante=n.Comprobante,
                               Nacionalidad=n.Nacionalidad,
                               ClaseCliente=n.ClaseCliente,
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo muestra le listado de los clientes sin polizas asignadas de manera detallada
        /// </summary>
        /// <param name="CodigoCliente"></param>
        /// <param name="Numeroidentificacion"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="Supervisor"></param>
        /// <param name="Intermediario"></param>
        /// <param name="NombreCliente"></param>
        /// <param name="CodigoOficina"></param>
        /// <param name="GeneradoPor"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EClientesSinPolizaDetallado> BuscaClientesSinPolizasDetallado(decimal? CodigoCliente = null, string Numeroidentificacion = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? Supervisor = null, int? Intermediario = null, string NombreCliente = null, int? CodigoOficina = null, decimal? GeneradoPor = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_CLIENTES_SIN_POLIZA_DETALLADO(CodigoCliente, Numeroidentificacion, FechaDesde, FechaHasta, Supervisor, Intermediario, NombreCliente, CodigoOficina, GeneradoPor)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.EClientesSinPolizaDetallado
                           {
                               Codigo = n.Codigo,
                               TipoIdentificacion = n.TipoIdentificacion,
                               RNC = n.RNC,
                               Cliente = n.Cliente,
                               Direccion = n.Direccion,
                               CodigoSupervisor = n.CodigoSupervisor,
                               CodigoIntermediario = n.CodigoIntermediario,
                               Supervisor = n.Supervisor,
                               Intermediario = n.Intermediario,
                               Cobrador = n.Cobrador,
                               UsuarioAdiciona = n.UsuarioAdiciona,
                               fecha0 = n.fecha0,
                               Fecha = n.Fecha,
                               Hora = n.Hora,
                               CodigoMes = n.CodigoMes,
                               CodigoAno = n.CodigoAno,
                               Mes = n.Mes,
                               TelefonoResidencia = n.TelefonoResidencia,
                               TelefonoOficina = n.TelefonoOficina,
                               Celular = n.Celular,
                               fax = n.fax,
                               Beeper = n.Beeper,
                               Comprobante = n.Comprobante,
                               Nacionalidad = n.Nacionalidad,
                               ClaseCliente = n.ClaseCliente,
                               CantidadPolizas = n.CantidadPolizas,
                               CodigoOficina = n.CodigoOficina,
                               Oficina = n.Oficina,
                               GeneradoPor=n.GeneradoPor
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo muestra la cantidad de los clientes sin poliza de manera resumida
        /// </summary>
        /// <param name="CodigoCliente"></param>
        /// <param name="Numeroidentificacion"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="Supervisor"></param>
        /// <param name="Intermediario"></param>
        /// <param name="NombreCliente"></param>
        /// <param name="CodigoOficina"></param>
        /// <param name="GeneradoPor"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EClienteSinPolizaResumido> BuscaClientesSinPolizaResumido(decimal? CodigoCliente = null, string Numeroidentificacion = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? Supervisor = null, int? Intermediario = null, string NombreCliente = null, int? CodigoOficina = null, decimal? GeneradoPor = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_CLIENTES_SIN_POLIZA_RESUMIDO(CodigoCliente, Numeroidentificacion, FechaDesde, FechaHasta, Supervisor, Intermediario, NombreCliente, CodigoOficina, GeneradoPor)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.EClienteSinPolizaResumido
                           {
                               Mes = n.Mes,
                               CodigoMes=n.CodigoMes,
                               CodigoAno=n.CodigoAno,
                               CodigoOficina=n.CodigoOficina,
                               Oficina=n.Oficina,
                               Cantidad=n.Cantidad,
                               GeneradoPor=n.GeneradoPor
                           }).ToList();
            return Listado;
        }
        /// <summary>
        /// Este metodo es para mostrar el listado de las polizas que no se le ha impreso marbetes
        /// </summary>
        /// <param name="Poliza"></param>
        /// <param name="Supervisor"></param>
        /// <param name="Intermediario"></param>
        /// <param name="Oficina"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="Ramo"></param>
        /// <param name="SubRamo"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EPolizasSinImpresionMarbete> BuscaPolziasSinMarbete(string Poliza = null, int? Supervisor = null, int? Intermediario = null, int? Oficina = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? Ramo = null, int? SubRamo = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_MOSTRAR_POLIZAS_SIN_IMPRESION_MARBETE(Poliza, Supervisor, Intermediario, Oficina, FechaDesde, FechaHasta, Ramo, SubRamo)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.EPolizasSinImpresionMarbete
                           {
                               Poliza=n.Poliza,
                               Cotizacion=n.Cotizacion,
                               Prima=n.Prima,
                               Estatus=n.Estatus,
                               InicioVigencia=n.InicioVigencia,
                               FinVigencia=n.FinVigencia,
                               CodigoSupervisor=n.CodigoSupervisor,
                               CodigoIntermediario=n.CodigoIntermediario,
                               Supervisor=n.Supervisor,
                               Intermediario=n.Intermediario,
                               CodigoOficina=n.CodigoOficina,
                               Oficina=n.Oficina,
                               UsuarioAdiciona=n.UsuarioAdiciona,
                               FechaCreado=n.FechaCreado,
                               FechaCreadoFormateada=n.FechaCreadoFormateada,
                               CodigoRamo=n.CodigoRamo,
                               Ramo=n.Ramo,
                               CodigoSubramo=n.CodigoSubramo,
                               SubRamo=n.SubRamo
                           }).ToList();
            return Listado;
        }


        /// <summary>
        /// Este metodo es para mostrar las polizas sin marbete de manera detallada
        /// </summary>
        /// <param name="Poliza"></param>
        /// <param name="Supervisor"></param>
        /// <param name="Intermediario"></param>
        /// <param name="Oficina"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="Ramo"></param>
        /// <param name="SubRamo"></param>
        /// <param name="GeneradoPor"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EPolizasSInMarbeteDetallado> BuscaPolziasSinMarbeteDetallado(string Poliza = null, int? Supervisor = null, int? Intermediario = null, int? Oficina = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? Ramo = null, int? SubRamo = null, decimal? GeneradoPor = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_POLIZAS_SIN_IMPRESION_MARBETES_DETALLADO(Poliza, Supervisor, Intermediario, Oficina, FechaDesde, FechaHasta, Ramo, SubRamo, GeneradoPor)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.EPolizasSInMarbeteDetallado
                           {
                               Poliza = n.Poliza,
                               Cotizacion = n.Cotizacion,
                               Prima = n.Prima,
                               Estatus = n.Estatus,
                               InicioVigencia = n.InicioVigencia,
                               FinVigencia = n.FinVigencia,
                               CodigoSupervisor = n.CodigoSupervisor,
                               CodigoIntermediario = n.CodigoIntermediario,
                               Supervisor = n.Supervisor,
                               Intermediario = n.Intermediario,
                               CodigoOficina = n.CodigoOficina,
                               Oficina = n.Oficina,
                               UsuarioAdiciona = n.UsuarioAdiciona,
                                FechaCreado = n.FechaCreado,
                               FechaCreadoFormateada = n.FechaCreadoFormateada,
                               HoraCreadoFormateada = n.HoraCreadoFormateada,
                               CodigoAno = n.CodigoAno,
                               CodigoMes = n.CodigoMes,
                               Mes = n.Mes,
                               CodigoRamo = n.CodigoRamo,
                               Ramo = n.Ramo,
                               CodigoSubramo = n.CodigoSubramo,
                               SubRamo = n.SubRamo,
                               GeneradoPor=n.GeneradoPor
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo es para mostrar las polizas sin marbetes de manera resumida
        /// </summary>
        /// <param name="Poliza"></param>
        /// <param name="Supervisor"></param>
        /// <param name="Intermediario"></param>
        /// <param name="Oficina"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="Ramo"></param>
        /// <param name="SubRamo"></param>
        /// <param name="GeneradoPor"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Consulta.EPolizasSinMarbeteResumido> BuscaPolizasSinMarbetesResumido(string Poliza = null, int? Supervisor = null, int? Intermediario = null, int? Oficina = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? Ramo = null, int? SubRamo = null, decimal? GeneradoPor = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_POLIZAS_SIN_IMPRESION_MARBETES_RESUMIDO(Poliza, Supervisor, Intermediario, Oficina, FechaDesde, FechaHasta, Ramo, SubRamo, GeneradoPor)
                           select new UtilidadesAmigos.Logica.Entidades.Consulta.EPolizasSinMarbeteResumido
                           {
                               Mes = n.Mes,
                               CodigoRamo = n.CodigoRamo,
                               CodigoSubramo = n.CodigoSubramo,
                               Ramo = n.Ramo,
                               SubRamo = n.SubRamo,
                               CodigoOficina = n.CodigoOficina,
                               Oficina = n.Oficina,
                               Cantidad=n.Cantidad,
                               GeneradoPor=n.GeneradoPor
                           }).ToList();
            return Listado;
        }
        #endregion

    }
}
