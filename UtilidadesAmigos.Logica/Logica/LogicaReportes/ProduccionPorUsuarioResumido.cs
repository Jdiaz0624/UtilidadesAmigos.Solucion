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
    }
}
