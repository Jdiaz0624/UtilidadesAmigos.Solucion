using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Logica.LogicaReportes
{
    public class ProduccionPorUsuarioResumido
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDConexionReportesDataContext ObjData = new Data.Conexiones.LINQ.BDConexionReportesDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

        #region GUARDAR DATOS REPORTE PRODUCCION POR USUARIOS
        //GUARDA R LOS DATOS DE PRODUCCION POR USUARIO RESUMIDO
        public UtilidadesAmigos.Logica.Entidades.Reportes.EProduccionPorusuarioResumido GuardarDatosProduccionPorUsuarioResumido(UtilidadesAmigos.Logica.Entidades.Reportes.EProduccionPorusuarioResumido Item, string Accion) {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Reportes.EProduccionPorusuarioResumido Guardar = null;

            var Produccion = ObjData.SP_GUARDAR_DATOS_REPORTE_POR_USUARIO_RESUMIDO(
              Item.IdUsuario,
              Item.Sucursal,
              Item.Oficina,
              Item.Departaemnto,
              Item.Usuario,
              Item.Concepto,
              Item.Cantidad,
              Item.Total,
              Item.TipoMovimiento,
              Item.TotalRegistros,
              Item.TotalPrima,
              Item.FechaDesde,
              Item.FechaHasta,
              Accion);
            if (Produccion != null) {
                Guardar = (from n in Produccion
                           select new UtilidadesAmigos.Logica.Entidades.Reportes.EProduccionPorusuarioResumido
                           {
                               IdUsuario = n.IdUsuario,
                               Sucursal = n.Sucursal,
                               Oficina = n.Oficina,
                               Departaemnto = n.Departaemnto,
                               Usuario = n.Usuario,
                               Concepto = n.Concepto,
                               Cantidad = n.Cantidad,
                               Total = n.Total,
                               TipoMovimiento = n.TipoMovimiento,
                               TotalRegistros = n.TotalRegistros,
                               TotalPrima = n.TotalPrima,
                               FechaDesde = n.FechaDesde,
                               FechaHasta = n.FechaHasta
                           }).FirstOrDefault();
            }
            return Guardar;


        }
        #endregion
        #region GUARDAR DATOS REPORTE PRODUCCION POR USUARIOS DETALLE
        public UtilidadesAmigos.Logica.Entidades.Reportes.EProduccionPorUsuarioDetalle DataProduccionusuarioDetalle(UtilidadesAmigos.Logica.Entidades.Reportes.EProduccionPorUsuarioDetalle Item, string Accion) {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Reportes.EProduccionPorUsuarioDetalle Guardar = null;

            var ProduccionUsuarioDetalle = ObjData.SP_GUARDAR_DATOS_PRODUCCION_USUARIO_DETALLE(
                Item.IdUsuario,
                Item.FechaDesde,
                Item.FechaHasta,
                Item.Sucursal,
                Item.Oficina,
                Item.Departamento,
                Item.Usuario,
                Item.Concepto,
                Item.Poliza,
                Item.Monto,
                Item.TotalRegistros,
                Item.TotalValor,
                Accion);
            if (ProduccionUsuarioDetalle != null) {
                Guardar = (from n in ProduccionUsuarioDetalle
                           select new UtilidadesAmigos.Logica.Entidades.Reportes.EProduccionPorUsuarioDetalle
                           {
                               IdUsuario = n.IdUsuario,
                               FechaDesde = n.FechaDesde,
                               FechaHasta = n.FechaHasta,
                               Sucursal = n.Sucursal,
                               Oficina = n.Oficina,
                               Departamento = n.Departamento,
                               Usuario = n.Usuario,
                               Concepto = n.Concepto,
                               Poliza = n.Poliza,
                               Monto = n.Monto,
                               TotalRegistros = n.TotalRegistros,
                               TotalValor = n.TotalValor
                           }).FirstOrDefault();
            }
            return Guardar;
        }
        #endregion
        #region REPORTE DE PRODUCCION
        //MOSTRAR EL ORIGEN DE LOS DATOS DEL REPORTE DE PRODUCCION
        /// <summary>
        /// Este Metodo muestra el orien de los datos del reporte de producción, a partir de estos datos se puede generar cualquier tipo de reporte de este.
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="Tasa"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Reportes.EReporteProduccionOrigen> BuscaReporteProduccionOrigen(DateTime? FechaDesde = null, DateTime? FechaHasta = null, decimal? Tasa = null) {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCAR_PRODUCCION_ORIGEN(FechaDesde, FechaHasta, Tasa)
                           select new UtilidadesAmigos.Logica.Entidades.Reportes.EReporteProduccionOrigen
                           {
                               CodRamo = n.CodRamo,
                               Ramo = n.Ramo,
                               NumeroFactura = n.NumeroFactura,
                               NumeroFacturaFormateado = n.NumeroFacturaFormateado,
                               Poliza = n.Poliza,
                               Asegurado = n.Asegurado,
                               Items = n.Items,
                               Supervisor = n.Supervisor,
                               CodIntermediario = n.CodIntermediario,
                               CodSupervisor = n.CodSupervisor,
                               Intermediario = n.Intermediario,
                               Fecha = n.Fecha,
                               FechaFormateada = n.FechaFormateada,
                               FechaInicioVigencia = n.FechaInicioVigencia,
                               FechaFinVigencia = n.FechaFinVigencia,
                               InicioVigencia = n.InicioVigencia,
                               FinVigencia = n.FinVigencia,
                               SumaAsegurada = n.SumaAsegurada,
                               Estatus = n.Estatus,
                               CodOficina = n.CodOficina,
                               Oficina = n.Oficina,
                               Concepto = n.Concepto,
                               Ncf = n.Ncf,
                               Tipo = n.Tipo,
                               DescripcionTipo = n.DescripcionTipo,
                               Bruto = n.Bruto,
                               Impuesto = n.Impuesto,
                               Neto = n.Neto,
                               Tasa = n.Tasa,
                               Cobrado = n.Cobrado,
                               CodMoneda = n.CodMoneda,
                               Moneda = n.Moneda,
                               TasaUsada = n.TasaUsada,
                               MontoPesos = n.MontoPesos,
                               Mes = n.Mes,
                               Usuario = n.Usuario,
                               CantidadRegistros = n.CantidadRegistros,
                               TotalFacturado = n.TotalFacturado,
                               TotalFActuradoPesos = n.TotalFActuradoPesos,
                               TotalFActuradoDollar = n.TotalFActuradoDollar,
                               TotalFacturadoGeneral = n.TotalFacturadoGeneral
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo es para guardar los datos del reporte del origen para poder generar cualquier tipo de reporte de produccion
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionDatosProduccion ProcesarInformacionDatosProduccion(UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionDatosProduccion Item, string Accion) {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionDatosProduccion Procesar = null;

            var InformacionDatosProduccin = ObjData.SP_PROCESAR_INFORMACION_DATOS_PRODUCCION(
                Item.IdUsuario,
                Item.CodRamo,
                Item.Ramo,
                Item.NumeroFactura,
                Item.NumeroFacturaFormateado,
                Item.Poliza,
                Item.Asegurado,
                Item.Items,
                Item.Supervisor,
                Item.CodIntermediario,
                Item.CodSupervisor,
                Item.Intermediario,
                Item.Fecha,
                Item.FechaFormateada,
                Item.FechaInicioVigencia,
                Item.FechaFinVigencia,
                Item.InicioVigencia,
                Item.FinVigencia,
                Item.SumaAsegurada,
                Item.Estatus,
                Item.CodOficina,
                Item.Oficina,
                Item.Concepto,
                Item.Ncf,
                Item.Tipo,
                Item.DescripcionTipo,
                Item.Bruto,
                Item.Impuesto,
                Item.Neto,
                Item.Tasa,
                Item.Cobrado,
                Item.CodMoneda,
                Item.Moneda,
                Item.TasaUsada,
                Item.MontoPesos,
                Item.Mes,
                Item.Usuario,
                Accion);
            if (InformacionDatosProduccin != null) {
                Procesar = (from n in InformacionDatosProduccin
                            select new UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionDatosProduccion
                            {
                                IdUsuario = n.IdUsuario,
                                CodRamo = n.CodRamo,
                                Ramo = n.Ramo,
                                NumeroFactura = n.NumeroFactura,
                                NumeroFacturaFormateado = n.NumeroFacturaFormateado,
                                Poliza = n.Poliza,
                                Asegurado = n.Asegurado,
                                Items = n.Items,
                                Supervisor = n.Supervisor,
                                CodIntermediario = n.CodIntermediario,
                                CodSupervisor = n.CodSupervisor,
                                Intermediario = n.Intermediario,
                                Fecha = n.Fecha,
                                FechaFormateada = n.FechaFormateada,
                                FechaInicioVigencia = n.FechaInicioVigencia,
                                FechaFinVigencia = n.FechaFinVigencia,
                                InicioVigencia = n.InicioVigencia,
                                FinVigencia = n.FinVigencia,
                                SumaAsegurada = n.SumaAsegurada,
                                Estatus = n.Estatus,
                                CodOficina = n.CodOficina,
                                Oficina = n.Oficina,
                                Concepto = n.Concepto,
                                Ncf = n.Ncf,
                                Tipo = n.Tipo,
                                DescripcionTipo = n.DescripcionTipo,
                                Bruto = n.Bruto,
                                Impuesto = n.Impuesto,
                                Neto = n.Neto,
                                Tasa = n.Tasa,
                                Cobrado = n.Cobrado,
                                CodMoneda = n.CodMoneda,
                                Moneda = n.Moneda,
                                TasaUsada = n.TasaUsada,
                                MontoPesos = n.MontoPesos,
                                Mes = n.Mes,
                                Usuario = n.Usuario
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        /// <summary>
        /// Este metodo es para busca la informacion no agrupada de la produccion
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="Estatus"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="CodigoSupervisor"></param>
        /// <param name="CodigoIntermediario"></param>
        /// <param name="Oficina"></param>
        /// <param name="Ramo"></param>
        /// <param name="CodMoneda"></param>
        /// <param name="Concepto"></param>
        /// <param name="Mes"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaDatosProducionNoAgrupadoDetalle> BuscaDatosProduccionNoAgrupadoDetalle(decimal? IdUsuario = null, string Estatus = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, string CodigoSupervisor = null, string CodigoIntermediario = null, int? Oficina = null, int? Ramo = null, int? CodMoneda = null, string Concepto = null, string Mes = null) {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_DATOS_PRODUCCION_NO_AGRUPADO_DETALLE(IdUsuario, Estatus, FechaDesde, FechaHasta, CodigoSupervisor, CodigoIntermediario, Oficina, Ramo, CodMoneda, Concepto, Mes)
                           select new UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaDatosProducionNoAgrupadoDetalle
                           {
                               IdUsuario=n.IdUsuario,
                               CodRamo=n.CodRamo,
                               Ramo=n.Ramo,
                               NumeroFactura=n.NumeroFactura,
                               NumeroFacturaFormateado=n.NumeroFacturaFormateado,
                               Poliza=n.Poliza,
                               Asegurado=n.Asegurado,
                               Items=n.Items,
                               Supervisor=n.Supervisor,
                               CodIntermediario=n.CodIntermediario,
                               CodSupervisor=n.CodSupervisor,
                               Intermediario=n.Intermediario,
                               Fecha=n.Fecha,
                               FechaFormateada=n.FechaFormateada,
                               FechaInicioVigencia=n.FechaInicioVigencia,
                               FechaFinVigencia=n.FechaFinVigencia,
                               InicioVigencia=n.InicioVigencia,
                               FinVigencia=n.FinVigencia,
                               SumaAsegurada=n.SumaAsegurada,
                               Estatus=n.Estatus,
                               CodOficina=n.CodOficina,
                               Oficina=n.Oficina,
                               Concepto=n.Concepto,
                               Ncf=n.Ncf,
                               Tipo=n.Tipo,
                               DescripcionTipo=n.DescripcionTipo,
                               Bruto=n.Bruto,
                               Impuesto=n.Impuesto,
                               Neto=n.Neto,
                               Tasa=n.Tasa,
                               Cobrado=n.Cobrado,
                               CodMoneda=n.CodMoneda,
                               Moneda=n.Moneda,
                               TasaUsada=n.TasaUsada,
                               MontoPesos=n.MontoPesos,
                               Mes=n.Mes,
                               Usuario=n.Usuario,
                               CantidadRegistros=n.CantidadRegistros,
                               TotalFacturado=n.TotalFacturado,
                               TotalFActuradoPesos=n.TotalFActuradoPesos,
                               TotalDollar=n.TotalDollar,
                               TotalFacturadoGeneral=n.TotalFacturadoGeneral
                           }).ToList();
            return Listado;
        }

        public List<UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaDatosProduccionNoAgrupadoResumen> BuscaDatosProduccionNoAgrupadoResumen(decimal? IdUsuario = null, string Estatus = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, string CodigoSupervisor = null, string CodigoIntermediario = null, int? Oficina = null, int? Ramo = null, int? CodMoneda = null, string Concepto = null, string Mes = null) {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_DATOS_PRODUCCION_NO_AGRUPADO_RESUMEN(IdUsuario, Estatus, FechaDesde, FechaHasta, CodigoSupervisor, CodigoIntermediario, Oficina, Ramo, CodMoneda, Concepto, Mes)
                           select new UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaDatosProduccionNoAgrupadoResumen
                           {
                               IdUsuario=n.IdUsuario,
                               CodRamo=n.CodRamo,
                               Ramo=n.Ramo,
                               Supervisor=n.Supervisor,
                               CodIntermediario=n.CodIntermediario,
                               CodSupervisor=n.CodSupervisor,
                               Intermediario=n.Intermediario,
                               CodOficina=n.CodOficina,
                               Oficina=n.Oficina,
                               Tipo=n.Tipo,
                               DescripcionTipo=n.DescripcionTipo,
                               Bruto=n.Bruto,
                               Impuesto=n.Impuesto,
                               Neto=n.Neto,
                               Cobrado=n.Cobrado,
                               CodMoneda=n.CodMoneda,
                               Moneda=n.Moneda,
                               TasaUsada=n.TasaUsada,
                               MontoPesos=n.MontoPesos
                           }).ToList();
            return Listado;
        
        }
        #endregion
        #region PROCESAR INFORMACION GRAFICO
        public UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionDatosGraficos ProcesarInformacionDatoGrafico(UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionDatosGraficos Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionDatosGraficos Procesar = null;

            var InformacionDatosGraficos = ObjData.SP_PROCESAR_INFORMACION_DATOS_GRAFICOS(
                Item.IdUsuario,
                Item.EntidadRamo,
                Item.ValorEnteroRamo,
                Item.ValorDecimalRamo,
                Item.EntidadAsegurado,
                Item.ValorEnteroAsegurado,
                Item.ValorDecimalAsegurado,
                Item.EntidadSupervisor,
                Item.ValorEnteroSupervisor,
                Item.ValorDecimalSupervisor,
                Item.EntidadIntermediario,
                Item.ValorEnteroIntermediario,
                Item.ValorDecimalIntermediario,
                Item.EntidadEstatus,
                Item.ValorEnteroEstatus,
                Item.ValorDecimalEstatus,
                Item.EntidadOficina,
                Item.ValorEnteroOficina,
                Item.ValorDecimalOficina,
                Item.EntidadConcepto,
                Item.ValorEnteroConcepto,
                Item.ValorDecimalConcepto,
                Item.EntidadDescripcionTipo,
                Item.ValorEnteroDescripcionTipo,
                Item.ValorDecimalDescripcionTipo,
                Item.EntidadMoneda,
                Item.ValorEnteroMoneda,
                Item.ValorDecimalMoneda,
                Accion);
            if (InformacionDatosGraficos != null) {
                Procesar = (from n in InformacionDatosGraficos
                            select new UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionDatosGraficos
                            {
                                IdUsuario = n.IdUsuario,
                                EntidadRamo = n.EntidadRamo,
                                ValorEnteroRamo = n.ValorEnteroRamo,
                                ValorDecimalRamo = n.ValorDecimalRamo,
                                EntidadAsegurado = n.EntidadAsegurado,
                                ValorEnteroAsegurado = n.ValorEnteroAsegurado,
                                ValorDecimalAsegurado = n.ValorDecimalAsegurado,
                                EntidadSupervisor = n.EntidadSupervisor,
                                ValorEnteroSupervisor = n.ValorEnteroSupervisor,
                                ValorDecimalSupervisor = n.ValorDecimalSupervisor,
                                EntidadIntermediario = n.EntidadIntermediario,
                                ValorEnteroIntermediario = n.ValorEnteroIntermediario,
                                ValorDecimalIntermediario = n.ValorDecimalIntermediario,
                                EntidadEstatus = n.EntidadEstatus,
                                ValorEnteroEstatus = n.ValorEnteroEstatus,
                                ValorDecimalEstatus = n.ValorDecimalEstatus,
                                EntidadOficina = n.EntidadOficina,
                                ValorEnteroOficina = n.ValorEnteroOficina,
                                ValorDecimalOficina = n.ValorDecimalOficina,
                                EntidadConcepto = n.EntidadConcepto,
                                ValorEnteroConcepto = n.ValorEnteroConcepto,
                                ValorDecimalConcepto = n.ValorDecimalConcepto,
                                EntidadDescripcionTipo = n.EntidadDescripcionTipo,
                                ValorEnteroDescripcionTipo = n.ValorEnteroDescripcionTipo,
                                ValorDecimalDescripcionTipo = n.ValorDecimalDescripcionTipo,
                                EntidadMoneda = n.EntidadMoneda,
                                ValorEnteroMoneda = n.ValorEnteroMoneda,
                                ValorDecimalMoneda = n.ValorDecimalMoneda
                            }).FirstOrDefault();
            }
            return Procesar;
        }

        #endregion

        #region PROCESAR INFORMACION PARA LOS DATOS DEL REPORTE
        public UtilidadesAmigos.Logica.Entidades.Reportes.EDatosProduccionReporte ProcesarInformacionDatosReporte(UtilidadesAmigos.Logica.Entidades.Reportes.EDatosProduccionReporte Item, string Accion) {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Reportes.EDatosProduccionReporte Procesar = null;

            var DatoPolizaReporte = ObjData.SP_BUSCA_DATO_POLIZA_PRODUCCION_REPORTE(
                Item.IdUsuario,
                Item.CodRamo,
                Item.Ramo,
                Item.NumeroFactura,
                Item.NumeroFacturaFormateado,
                Item.Poliza,
                Item.Asegurado,
                Item.Items,
                Item.Supervisor,
                Item.CodIntermediario,
                Item.CodSupervisor,
                Item.Intermediario,
                Item.Fecha,
                Item.FechaFormateada,
                Item.FechaInicioVigencia,
                Item.FechaFinVigencia,
                Item.InicioVigencia,
                Item.FinVigencia,
                Item.SumaAsegurada,
                Item.Estatus,
                Item.CodOficina,
                Item.Oficina,
                Item.Concepto,
                Item.Ncf,
                Item.Tipo,
                Item.DescripcionTipo,
                Item.Bruto,
                Item.Impuesto,
                Item.Neto,
                Item.Tasa,
                Item.Cobrado,
                Item.CodMoneda,
                Item.Moneda,
                Item.TasaUsada,
                Item.MontoPesos,
                Item.Mes,
                Item.Usuario,
                Accion);
            if (DatoPolizaReporte != null) {
                Procesar = (from n in DatoPolizaReporte
                            select new UtilidadesAmigos.Logica.Entidades.Reportes.EDatosProduccionReporte
                            {
                                IdUsuario = n.IdUsuario,
                                CodRamo = n.CodRamo,
                                Ramo = n.Ramo,
                                NumeroFactura = n.NumeroFactura,
                                NumeroFacturaFormateado = n.NumeroFacturaFormateado,
                                Poliza = n.Poliza,
                                Asegurado = n.Asegurado,
                                Items = n.Items,
                                Supervisor = n.Supervisor,
                                CodIntermediario = n.CodIntermediario,
                                CodSupervisor = n.CodSupervisor,
                                Intermediario = n.Intermediario,
                                Fecha = n.Fecha,
                                FechaFormateada = n.FechaFormateada,
                                FechaInicioVigencia = n.FechaInicioVigencia,
                                FechaFinVigencia = n.FechaFinVigencia,
                                InicioVigencia = n.InicioVigencia,
                                FinVigencia = n.FinVigencia,
                                SumaAsegurada = n.SumaAsegurada,
                                Estatus = n.Estatus,
                                CodOficina = n.CodOficina,
                                Oficina = n.Oficina,
                                Concepto = n.Concepto,
                                Ncf = n.Ncf,
                                Tipo = n.Tipo,
                                DescripcionTipo = n.DescripcionTipo,
                                Bruto = n.Bruto,
                                Impuesto = n.Impuesto,
                                Neto = n.Neto,
                                Tasa = n.Tasa,
                                Cobrado = n.Cobrado,
                                CodMoneda = n.CodMoneda,
                                Moneda = n.Moneda,
                                TasaUsada = n.TasaUsada,
                                MontoPesos = n.MontoPesos,
                                Mes = n.Mes,
                                Usuario = n.Usuario
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion

        #region PROCESAR INFORMACION DATOS DEL REPORTE DE INTERMEDIARIO INTERNO
        public UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarDatosReporteIntermediairoInterno ProcesarInformacionDatosProduccionReporte(UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarDatosReporteIntermediairoInterno Item, string Accion) {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarDatosReporteIntermediairoInterno Procesar = null;

            var DatosComsionIntermediarioInterno = ObjData.SP_PROCESAR_DATOS_REPORTE_INTERMEDIARIO_INTERNO(
                Item.IdUsuario,
                Item.Ramo,
                Item.Oficina,
                Item.Intermediario,
                Item.PorcientoComision,
                Item.RNC,
                Item.Cuenta,
                Item.Tipo,
                Item.Banco,
                Item.Bruto,
                Item.Neto,
                Item.Comision,
                Item.Retencion,
                Item.Avance,
                Item.APagar,
                Item.FechaDesde,
                Item.FechaHasta,
                Accion);
            if (DatosComsionIntermediarioInterno != null) {
                Procesar = (from n in DatosComsionIntermediarioInterno
                            select new UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarDatosReporteIntermediairoInterno
                            {
                                IdUsuario=n.IdUsuario,
                                Ramo=n.Ramo,
                                Oficina=n.Oficina,
                                Intermediario=n.Intermediario,
                                PorcientoComision=n.PorcientoComision,
                                RNC=n.RNC,
                                Cuenta=n.Cuenta,
                                Tipo=n.Tipo,
                                Banco=n.Banco,
                                Bruto=n.Bruto,
                                Neto=n.Neto,
                                Comision=n.Comision,
                                Retencion=n.Retencion,
                                Avance=n.Avance,
                                APagar=n.APagar,
                                FechaDesde=n.FechaDesde,
                                FechaHasta=n.FechaHasta
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion

        #region GENERAR REPORTE DE PRODUCCION AGRUPADOS 
        /// <summary>
        /// Este metodo es para mostrar el listado de produccion agrupado por concepto.
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaReporteProduccionAgrupadoPorConcepto> ReporreProduccionAgrupadoConcepto(decimal? IdUsuario = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, string Concepto = null) {
            ObjData.CommandTimeout = 999999999;

            var Reporte = (from n in ObjData.SP_BUSCA_REPORTE_PRODUCCION_AGRUPADO_POR_CONCEPTO(
                IdUsuario,
                FechaDesde,
                FechaHasta,
                Concepto)
                           select new UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaReporteProduccionAgrupadoPorConcepto
                           {
                               Concepto=n.Concepto,
                               Cantidad=n.Cantidad,
                               Bruto =n.Bruto,
                               Impuesto=n.Impuesto,
                               Neto=n.Neto,
                               Cobrado=n.Cobrado,
                               Moneda=n.Moneda,
                               TasaUsada=n.TasaUsada,
                               MontoPesos=n.MontoPesos,
                               ValidadoDesde=n.ValidadoDesde,
                               ValidadoHasta=n.ValidadoHasta,
                               IdUsuario=n.IdUsuario,
                               GeneradoPor=n.GeneradoPor 
                           }).ToList();
            return Reporte;
        }


        /// <summary>
        /// Este metodo es para mostrar el listado de produccion agrupado por usuario.
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaReporteAgrupadoPorUsuario> ReporteProduccionAgrupadoPorUsuario(decimal? IdUsuario = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null,string Concepto = null) {
            ObjData.CommandTimeout = 999999999;

            var Reporte = (from n in ObjData.SP_BUSCA_REPORTE_PRODUCCION_AGRUPADO_POR_USUARIO(IdUsuario, FechaDesde, FechaHasta,Concepto)
                           select new UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaReporteAgrupadoPorUsuario
                           {
                               Usuario=n.Usuario,
                               Cantidad=n.Cantidad,
                               Bruto=n.Bruto,
                               Impuesto=n.Impuesto,
                               Neto=n.Neto,
                               Cobrado=n.Cobrado,
                               Moneda=n.Moneda,
                               TasaUsada=n.TasaUsada,
                               MontoPesos=n.MontoPesos,
                               ValidadoDesde=n.ValidadoDesde,
                               ValidadoHasta=n.ValidadoHasta,
                               IdUsuario=n.IdUsuario,
                               GeneradoPor=n.GeneradoPor
                           }).ToList();
            return Reporte;

        }

        /// <summary>
        /// Este metodo es para buscar el listado de produccion agrupado por oficina.
        /// </summary>
        /// <param name="Idusuario"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaReporteProduccionAgrupadoOficina> ReporteProduccionAgeruadoPorOficina(decimal? Idusuario = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null,string Concepto = null) {
            ObjData.CommandTimeout = 999999999;

            var Reporte = (from n in ObjData.SP_BUSCA_REPORTE_PRODUCCION_AGRUPADO_POR_OFICINA(Idusuario, FechaDesde, FechaHasta, Concepto)
                           select new UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaReporteProduccionAgrupadoOficina
                           {
                               Oficina=n.Oficina,
                               Bruto=n.Bruto,
                               Impuesto=n.Impuesto,
                               Neto=n.Neto,
                               Cobrado=n.Cobrado,
                               Moneda=n.Moneda,
                               TasaUsada=n.TasaUsada,
                               MontoPesos=n.MontoPesos,
                               ValidadoDesde=n.ValidadoDesde,
                               ValidadoHasta=n.ValidadoHasta
                           }).ToList();
            return Reporte;
        }

        /// <summary>
        /// Este reporte muestra el  listado de la produccion agrupada por ramo.
        /// </summary>
        /// <param name="Idusuario"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaReporteProduccionAgrupadoRamo> ReporteProduccionAgeruadoPorRamo(decimal? Idusuario = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Reporte = (from n in ObjData.SP_BUSCA_REPORTE_PRODUCCION_AGRUPADO_POR_RAMO(Idusuario, FechaDesde, FechaHasta)
                           select new UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaReporteProduccionAgrupadoRamo
                           {
                               Ramo = n.Ramo,
                               Bruto = n.Bruto,
                               Impuesto = n.Impuesto,
                               Neto = n.Neto,
                               Cobrado = n.Cobrado,
                               Moneda = n.Moneda,
                               TasaUsada = n.TasaUsada,
                               MontoPesos = n.MontoPesos,
                               ValidadoDesde = n.ValidadoDesde,
                               ValidadoHasta = n.ValidadoHasta
                           }).ToList();
            return Reporte;
        }

        /// <summary>
        /// Este metodo es para buscar la produccion agrupada por intermediario.
        /// </summary>
        /// <param name="Idusuario"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaReporteProduccionAgrupadoPorIntermediario> ReporteProduccionAgeruadoPorIntermediario(decimal? Idusuario = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Reporte = (from n in ObjData.SP_BUSCA_REPORTE_PRODUCCION_AGRUPADO_POR_INTERMEDIARIO(Idusuario, FechaDesde, FechaHasta)
                           select new UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaReporteProduccionAgrupadoPorIntermediario
                           {
                               Intermediario = n.Intermediario,
                               Bruto = n.Bruto,
                               Impuesto = n.Impuesto,
                               Neto = n.Neto,
                               Cobrado = n.Cobrado,
                               Moneda = n.Moneda,
                               TasaUsada = n.TasaUsada,
                               MontoPesos = n.MontoPesos,
                               ValidadoDesde = n.ValidadoDesde,
                               ValidadoHasta = n.ValidadoHasta
                           }).ToList();
            return Reporte;
        }

        /// <summary>
        /// Este metodo es para buscar la producción agrupada por supervisor.
        /// </summary>
        /// <param name="Idusuario"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaReporteProduccionAgrupadaSupervisor> ReporteProduccionAgeruadoPorSupervisor(decimal? Idusuario = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Reporte = (from n in ObjData.SP_BUSCA_REPORTE_PRODUCCION_AGRUPADO_POR_SUPERVISOR(Idusuario, FechaDesde, FechaHasta)
                           select new UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaReporteProduccionAgrupadaSupervisor
                           {
                               Supervisor = n.Supervisor,
                               Bruto = n.Bruto,
                               Impuesto = n.Impuesto,
                               Neto = n.Neto,
                               Cobrado = n.Cobrado,
                               Moneda = n.Moneda,
                               TasaUsada = n.TasaUsada,
                               MontoPesos = n.MontoPesos,
                               ValidadoDesde = n.ValidadoDesde,
                               ValidadoHasta = n.ValidadoHasta
                           }).ToList();
            return Reporte;
        }
        #endregion

        #region REPORTE DE COBROS
        public List<UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaDataCobradoDetalle> BuscarDataReporteCobrosDetalle(string Poliza = null, string Numero = null, string Anulado = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, string TipoPago = null, string CodigoCliente = null, string CodigoIntermediario = null, string CodigoSupervisor = null, int? CodigoOficina = null, int? CodigoRamo = null, string Usuario = null, int? CodigoMoneda = null, string Concepto = null, decimal? Tasa = null,decimal? IdUsuarioProcesa = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_DATA_COBRADO_DETALLE(Poliza, Numero, Anulado, FechaDesde, FechaHasta, TipoPago, CodigoCliente, CodigoIntermediario, CodigoSupervisor, CodigoOficina, CodigoRamo, Usuario, CodigoMoneda, Concepto, Tasa,IdUsuarioProcesa)
                           select new UtilidadesAmigos.Logica.Entidades.Reportes.EBuscaDataCobradoDetalle
                           {
                               Poliza=n.Poliza,
                               Numero=n.Numero,
                               Concepto=n.Concepto,
                               NumeroFormateado=n.NumeroFormateado,
                               Anulado=n.Anulado,
                               Fecha=n.Fecha,
                               FechaFormateada=n.FechaFormateada,
                               TipoPago=n.TipoPago,
                               CodigoCliente=n.CodigoCliente,
                               Cliente=n.Cliente,
                               CodigoIntermediario=n.CodigoIntermediario,
                               Intermediario=n.Intermediario,
                               CodSupervisor=n.CodSupervisor,
                               NombreSupervisor=n.NombreSupervisor,
                               CodigoOficina=n.CodigoOficina,
                               Oficina=n.Oficina,
                               Usuario=n.Usuario,
                               CodigoRamo=n.CodigoRamo,
                               Ramo=n.Ramo,
                               CodMoneda=n.CodMoneda,
                               Moneda=n.Moneda,
                               Bruto=n.Bruto,
                               Impuesto=n.Impuesto,
                               Neto=n.Neto,
                               Tasa=n.Tasa,
                               MontoPesos=n.MontoPesos,
                               CantidadRegistros=n.CantidadRegistros,
                               TotalCobradoPesos=n.TotalCobradoPesos,
                               TotalCobradoDolar=n.TotalCobradoDolar,
                               UsuarioGenera=n.UsuarioGenera
                           }).ToList();
            return Listado;
        }
        #endregion

        #region MOSTRAR EL LISTADO DE LOS CHEQUES
        public List<UtilidadesAmigos.Logica.Entidades.Reportes.EBuscarInformacionCheque> GenerarInformacionCheque(string NumeroCheque = null, string Beneficiario = null, DateTime? FechaChqeueDesde = null, DateTime? FechaChequeHasta = null, decimal? NumeroChequeDesde = null, decimal? NumeroChequeHasta = null, decimal? RangoValorDesde = null, decimal? RangoValorHasta = null, int? Banco = null, string Anulado = null) {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCAR_INFORMACION_CHEQUE(NumeroCheque, Beneficiario, FechaChqeueDesde, FechaChequeHasta, NumeroChequeDesde, NumeroChequeHasta, RangoValorDesde, RangoValorHasta, Banco, Anulado)
                           select new UtilidadesAmigos.Logica.Entidades.Reportes.EBuscarInformacionCheque
                           {
                               Compania=n.Compania,
                               Anulado0=n.Anulado0,
                               Anulado=n.Anulado,
                               Sistema=n.Sistema,
                               Sistema1=n.Sistema1,
                               Solicitud=n.Solicitud,
                               TipoSolicitud=n.TipoSolicitud,
                               DescTipoSolicitud=n.DescTipoSolicitud,
                               FechaSolicitud0=n.FechaSolicitud0,
                               FechaSolicitud=n.FechaSolicitud,
                               Sucursal=n.Sucursal,
                               DescSucursal=n.DescSucursal,
                               Departamento=n.Departamento,
                               DescDepto=n.DescDepto,
                               Seccion=n.Seccion,
                               DescSeccion=n.DescSeccion,
                               RNCTipo=n.RNCTipo,
                               RNC=n.RNC,
                               CodigoBeneficiario=n.CodigoBeneficiario,
                               Beneficiario1=n.Beneficiario1,
                               Beneficiario2=n.Beneficiario2,
                               Endosable=n.Endosable,
                               CtaBanco=n.CtaBanco,
                               Banco=n.Banco,
                               CuentaBanco=n.CuentaBanco,
                               Valor=n.Valor,
                               Concepto1=n.Concepto1,
                               Concepto2=n.Concepto2,
                               NumeroCheque=n.NumeroCheque,
                               FechaCheque0=n.FechaCheque0,
                               FechaCheque=n.FechaCheque,
                               AnoMesConciliado=n.AnoMesConciliado,
                               FechaConciliado0=n.FechaConciliado0,
                               FechaConciliado=n.FechaConciliado,
                               UsuarioDigita=n.UsuarioDigita,
                               UsuarioModifica=n.UsuarioModifica,
                               FechaDigita0=n.FechaDigita0,
                               FechaDigita=n.FechaDigita,
                               FechaModifica0=n.FechaModifica0,
                               FechaModifica=n.FechaModifica,
                               Aprobado=n.Aprobado,
                               FechaAprobado0=n.FechaAprobado0,
                               FechaAprobado=n.FechaAprobado,
                               UsuarioCheque=n.UsuarioCheque,
                               PrimeraFirma=n.PrimeraFirma,
                               SegundaFirma=n.SegundaFirma,
                               UsuarioCancel=n.UsuarioCancel,
                               Estatus=n.Estatus,
                               Impresion=n.Impresion,
                               TipoDoc=n.TipoDoc,
                               DiaCheque=n.DiaCheque,
                               MesCheque=n.MesCheque,
                               AnoCheque=n.AnoCheque
                           }).ToList();
            return Listado;
        }

        public UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarChequesInformacionImprimir ProcesarDatosCheques(UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarChequesInformacionImprimir Item, string Accion) {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarChequesInformacionImprimir Procesar = null;

            var InformacionCheque = ObjData.SP_PROCESAR_INFORMACION_CHEQUES_IMPRIMIR(
                Item.IdUsuarioProcesa,
                Item.NumeroCheque,
                Item.FechaCheque,
                Item.ConceptoCheque,
                Item.ValorCheque,
                Item.Beneficiario,
                Item.MontoChqeueLetras,
                Item.DiaCheque,
                Item.MesCheque,
                Item.AnoCheque,
                Accion);
            if (InformacionCheque != null) {
                Procesar = (from n in InformacionCheque
                            select new UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarChequesInformacionImprimir
                            {
                                IdUsuarioProcesa=n.IdUsuarioProcesa,
                                NumeroCheque=n.NumeroCheque,
                                FechaCheque=n.FechaCheque,
                                ConceptoCheque=n.ConceptoCheque,
                                ValorCheque=n.ValorCheque,
                                Beneficiario=n.Beneficiario,
                                MontoChqeueLetras=n.MontoChqeueLetras,
                                DiaCheque=n.DiaCheque,
                                MesCheque=n.MesCheque,
                                AnoCheque=n.AnoCheque
                            }).FirstOrDefault();
                
            }
            return Procesar;
        }
        #endregion


        #region COMISIONES DE SUPERVISORES
        /// <summary>
        /// Este metodo es para procesar la informacion correspondiente a los pagos de cada supervisor
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionComisionesSupervisores ProcesaComisionesSupervisores(UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionComisionesSupervisores Item, string Accion) {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionComisionesSupervisores Procesar = null;

            var ComisionesSupervisores = ObjData.SP_PROCESAR_INFORMACION_COMISIONES_SUPERVISORES(
                Item.IdUsuario,
                Item.Poliza,
                Item.Recibo,
                Item.ConceptoPago,
                Item.ReciboFormateado,
                Item.Anulado,
                Item.FechaPago,
                Item.FechaPagoFormateado,
                Item.TipoPago,
                Item.CodigoCliente,
                Item.NombreCliente,
                Item.CodigoIntermediario,
                Item.NombreIntermediario,
                Item.CodigoSupervisor,
                Item.NombreSupervisor,
                Item.CodigoOficina,
                Item.NombreOficina,
                Item.Usuario,
                Item.CodigoRamo,
                Item.DescripcionRamo,
                Item.CodigoMoneda,
                Item.DescripcionMoneda,
                Item.Bruto,
                Item.Impuesto,
                Item.Neto,
                Item.Tasa,
                Item.Pesos,
                Item.ConceptoFactura,
                Item.PorcientoComisionIntermediario,
                Item.ValidadoDesde,
                Item.ValidadoHasta,
                Accion);
            if (ComisionesSupervisores != null) {
                Procesar = (from n in ComisionesSupervisores
                            select new UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionComisionesSupervisores
                            {
                                IdUsuario = n.IdUsuario,
                                Poliza = n.Poliza,
                                Recibo = n.Recibo,
                                ConceptoPago = n.ConceptoPago,
                                ReciboFormateado = n.ReciboFormateado,
                                Anulado = n.Anulado,
                                FechaPago = n.FechaPago,
                                FechaPagoFormateado = n.FechaPagoFormateado,
                                TipoPago = n.TipoPago,
                                CodigoCliente = n.CodigoCliente,
                                NombreCliente = n.NombreCliente,
                                CodigoIntermediario = n.CodigoIntermediario,
                                NombreIntermediario = n.NombreIntermediario,
                                CodigoSupervisor = n.CodigoSupervisor,
                                NombreSupervisor = n.NombreSupervisor,
                                CodigoOficina = n.CodigoOficina,
                                NombreOficina = n.NombreOficina,
                                Usuario = n.Usuario,
                                CodigoRamo = n.CodigoRamo,
                                DescripcionRamo = n.DescripcionRamo,
                                CodigoMoneda = n.CodigoMoneda,
                                DescripcionMoneda = n.DescripcionMoneda,
                                Bruto = n.Bruto,
                                Impuesto = n.Impuesto,
                                Neto = n.Neto,
                                Tasa = n.Tasa,
                                Pesos = n.Pesos,
                                ConceptoFactura=n.ConceptoFactura,
                                PorcientoComisionIntermediario=n.PorcientoComisionIntermediario,
                                ValidadoDesde=n.ValidadoDesde,
                                ValidadoHasta=n.ValidadoHasta
                            }).FirstOrDefault();
            }
            return Procesar;
        }

        /// <summary>
        /// Este metodo es para sacar el concepto del pago realizado
        /// </summary>
        /// <param name="Poliza"></param>
        /// <param name="NumeroRecibo"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Reportes.ESacarConceptoMediantePAgo> SacarConceptoMediantePago(string Poliza = null, decimal? NumeroRecibo = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Concepto = (from n in ObjData.SP_SACAR_CONCEPTO_FACTURA_MEDIANTE_PAGO(Poliza, NumeroRecibo)
                            select new UtilidadesAmigos.Logica.Entidades.Reportes.ESacarConceptoMediantePAgo
                            {
                                CONCEPTO=n.CONCEPTO
                            }).ToList();
            return Concepto;

        }

        /// <summary>
        /// Este metodo es para sacar el porciento de comision que tiene el supervisor mediante el concepto consultado
        /// </summary>
        /// <param name="Concepto"></param>
        /// <param name="CodigoSupervisor"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Reportes.ESacarPorcientoComisionesSupervisores> SacarPorcientoComisionSupervisor(string Concepto = null, decimal? CodigoSupervisor = null) {
            ObjData.CommandTimeout = 999999999;

            var Porciento = (from n in ObjData.SP_SACAR_PORCIENTO_COMISION_SUPERVISORES(Concepto, CodigoSupervisor)
                             select new UtilidadesAmigos.Logica.Entidades.Reportes.ESacarPorcientoComisionesSupervisores
                             {
                                 PorcientoComision=n.PorcientoComision
                             }).ToList();
            return Porciento;
        }

        #endregion
    }
}
