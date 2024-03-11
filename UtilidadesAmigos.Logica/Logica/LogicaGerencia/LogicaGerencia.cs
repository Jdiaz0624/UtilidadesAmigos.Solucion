using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Logica.LogicaGerencia
{
    public class LogicaGerencia
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDCOnexionGerenciaDataContext ObjData = new Data.Conexiones.LINQ.BDCOnexionGerenciaDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

        #region BUSCA ACUERDO DE PAGO
        /// <summary>
        /// Reporte de Acuerdo de Pago
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="Supervisor"></param>
        /// <param name="Intermediario"></param>
        /// <param name="Poliza"></param>
        /// <param name="generadoPor"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Gerencia.EBuscaAcuerdoPago> BuscaAcuerdoPago(DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? Supervisor = null, int? Intermediario = null, string Poliza = null, decimal? generadoPor = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_ACUERDO_PAGO(FechaDesde, FechaHasta, Supervisor, Intermediario, Poliza, generadoPor)
                           select new UtilidadesAmigos.Logica.Entidades.Gerencia.EBuscaAcuerdoPago
                           {
                               Poliza=n.Poliza,
                               ValorPoliza=n.ValorPoliza,
                               Concepto=n.Concepto,
                               FechaFacturacion=n.FechaFacturacion,
                               TipoAcuerdo=n.TipoAcuerdo,
                               Frecuencia=n.Frecuencia,
                               Supervisor=n.Supervisor,
                               Intermediario=n.Intermediario,
                               NombreSupervisor=n.NombreSupervisor,
                               NombreIntermediario=n.NombreIntermediario,
                               FrecuenciaPagos=n.FrecuenciaPagos,
                               CantidadCuotas=n.CantidadCuotas,
                               Inicial=n.Inicial,
                               Cuota=n.Cuota,
                               FechaC1=n.FechaC1,
                               DiasC1=n.DiasC1,
                               PagoC1=n.PagoC1,
                               EstatusC1=n.EstatusC1,
                               FechaC2=n.FechaC2,
                               DiasC2=n.DiasC2,
                               PagoC2=n.PagoC2,
                               EstatusC2=n.EstatusC2,
                               Fecha3=n.Fecha3,
                               DiasC3=n.DiasC3,
                               Pago3=n.Pago3,
                               EstatusC3=n.EstatusC3,
                               FechaC4=n.FechaC4,
                               DiasC4=n.DiasC4,
                               Pago4=n.Pago4,
                               EstatusC4=n.EstatusC4,
                               FechaC5=n.FechaC5,
                               DiasC5=n.DiasC5,
                               PagoC5=n.PagoC5,
                               EstatusC5=n.EstatusC5,
                               FechaC6=n.FechaC6,
                               DiasC6=n.DiasC6,
                               PagoC6=n.PagoC6,
                               EstatusC6=n.EstatusC6,
                               PagadoTotal=n.PagadoTotal,
                               Pendiente=n.Pendiente,
                               ValidadoDesde=n.ValidadoDesde,
                               ValidadoHasta=n.ValidadoHasta,
                               GeneradoPor=n.GeneradoPor
                           }).ToList();
            return Listado;
        }
        #endregion
        #region REPORTE DE ANTIGUEDAD POR ATRASO
        public List<UtilidadesAmigos.Logica.Entidades.Gerencia.EReporteAntiguedadPorAtras> ReporteAntiguedadPorAtraso(string Poliza = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? Ramo = null, int? SubRamo = null,int? Supervisor = null, int? Intermediario=null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_REPORTE_ANTIGUEDAD_POR_ATRASO(Poliza, FechaDesde, FechaHasta, Ramo, SubRamo,Supervisor,Intermediario)
                           select new UtilidadesAmigos.Logica.Entidades.Gerencia.EReporteAntiguedadPorAtras
                           {
                               Poliza=n.Poliza,
                               Codigo_Intermediario=n.Codigo_Intermediario,
                               Intermediario=n.Intermediario,
                               Codigo_Supervisor=n.Codigo_Supervisor,
                               Supervisor=n.Supervisor,
                               Codigo=n.Codigo,
                               Cliente=n.Cliente,
                               Direccion=n.Direccion,
                               Telefonos=n.Telefonos,
                               Concepto=n.Concepto,
                               Fecha_Facturacion=n.Fecha_Facturacion,
                               Inicio_Vigencia=n.Inicio_Vigencia,
                               Fin_Vigencia=n.Fin_Vigencia,
                               Fecha_Ultimo_Pago=n.Fecha_Ultimo_Pago,
                               DiasTranscurridos=n.DiasTranscurridos,
                               Dias_Transcurridos_Pago=n.Dias_Transcurridos_Pago,
                               Valor_Poliza=n.Valor_Poliza,
                               Total_Pagado=n.Total_Pagado,
                               TotalDescuento=n.TotalDescuento,
                               Balance_Pendiente=n.Balance_Pendiente,
                               Ramo=n.Ramo,
                               SubRamo=n.SubRamo,
                               NombreRamo=n.NombreRamo,
                               NombreSubRamo=n.NombreSubRamo,
                               Inicial=n.Inicial,
                               Inicial_Pagado=n.Inicial_Pagado,
                               Cuota=n.Cuota,
                               C1_Pagada=n.C1_Pagada,
                               C1=n.C1,
                               C2_Pagada=n.C2_Pagada,
                               C2=n.C2,
                               C3_Pagada=n.C3_Pagada,
                               C3=n.C3,
                               C4_Pagada=n.C4_Pagada,
                               C4=n.C4,
                               C5_Pagada=n.C5_Pagada,
                               C5=n.C5

                           }).ToList();
            return Listado;
        }
        #endregion
        #region GUARDAR INFORMACION DE LAS POLIZAS CON ATRASO
        /// <summary>
        /// Procesa la Informacion de la data de cobros
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Gerencia.EProcesarInformacionGuardarAntiguedadPorAtraso ProcesarPolizasConAtrasos(UtilidadesAmigos.Logica.Entidades.Gerencia.EProcesarInformacionGuardarAntiguedadPorAtraso Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Gerencia.EProcesarInformacionGuardarAntiguedadPorAtraso Procesar = null;

            var PolizasConAtrasos = ObjData.SP_GUARDAR_ANTIGUEDAD_POR_ATRASO(
                Item.IdUsuario,
                Item.Poliza,
                Item.Codigo_Intermediario,
                Item.Intermediario,
                Item.Codigo_Supervisor,
                Item.Supervisor,
                Item.Codigo,
                Item.Cliente,
                Item.Direccion,
                Item.Telefonos,
                Item.Concepto,
                Item.Fecha_Facturacion,
                Item.Inicio_Vigencia,
                Item.Fin_Vigencia,
                Item.Fecha_Ultimo_Pago,
                Item.DiasTranscurridos,
                Item.Dias_Transcurridos_Pago,
                Item.Valor_Poliza,
                Item.Total_Pagado,
                Item.Balance_Pendiente,
                Item.Ramo,
                Item.SubRamo,
                Item.NombreRamo,
                Item.NombreSubRamo,
                Item.Inicial,
                Item.Inicial_Pagado,
                Item.Cuota,
                Item.C1_Pagada,
                Item.C1,
                Item.C2_Pagada,
                Item.C2,
                Item.C3_Pagada,
                Item.C3,
                Item.C4_Pagada,
                Item.C4,
                Item.C5_Pagada,
                Item.C5,
                Item.TotalDescuento,
                Accion);
            if (PolizasConAtrasos != null) {

                Procesar = (from n in PolizasConAtrasos
                            select new UtilidadesAmigos.Logica.Entidades.Gerencia.EProcesarInformacionGuardarAntiguedadPorAtraso
                            {
                                IdUsuario=n.IdUsuario,
                                Poliza = n.Poliza,
                                Codigo_Intermediario = n.Codigo_Intermediario,
                                Intermediario = n.Intermediario,
                                Codigo_Supervisor = n.Codigo_Supervisor,
                                Supervisor = n.Supervisor,
                                Codigo = n.Codigo,
                                Cliente = n.Cliente,
                                Direccion = n.Direccion,
                                Telefonos = n.Telefonos,
                                Concepto = n.Concepto,
                                Fecha_Facturacion = n.Fecha_Facturacion,
                                Inicio_Vigencia = n.Inicio_Vigencia,
                                Fin_Vigencia = n.Fin_Vigencia,
                                Fecha_Ultimo_Pago = n.Fecha_Ultimo_Pago,
                                DiasTranscurridos = n.DiasTranscurridos,
                                Dias_Transcurridos_Pago = n.Dias_Transcurridos_Pago,
                                Valor_Poliza = n.Valor_Poliza,
                                Total_Pagado = n.Total_Pagado,
                                Balance_Pendiente = n.Balance_Pendiente,
                                Ramo = n.Ramo,
                                SubRamo = n.SubRamo,
                                NombreRamo = n.NombreRamo,
                                NombreSubRamo = n.NombreSubRamo,
                                Inicial = n.Inicial,
                                Inicial_Pagado = n.Inicial_Pagado,
                                Cuota = n.Cuota,
                                C1_Pagada = n.C1_Pagada,
                                C1 = n.C1,
                                C2_Pagada = n.C2_Pagada,
                                C2 = n.C2,
                                C3_Pagada = n.C3_Pagada,
                                C3 = n.C3,
                                C4_Pagada = n.C4_Pagada,
                                C4 = n.C4,
                                C5_Pagada = n.C5_Pagada,
                                C5 = n.C5,
                                TotalDescuento=n.TotalDescuento
                            }).FirstOrDefault();
            }
            return Procesar;


        }
        #endregion
        #region MOSTRAR REPORTE DE ANTIGUEDAD POR ATRASO RESULTADO
        /// <summary>
        /// Muestra el reporte de atraso final
        /// </summary>
        /// <param name="Supervisor"></param>
        /// <param name="Intermediario"></param>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Gerencia.EReporteAntiguedadPorAtrasoResultado> ReporteAntiguedadPorAtrasoResultado(string Poliza = null, int? Ramo = null, int? Subramo = null, int? Supervisor = null, int? Intermediario = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_REPORTE_ANTIGUEDAD_POR_ATRASO_RESULTADO(Poliza,Ramo,Subramo,Supervisor,Intermediario)
                           select new UtilidadesAmigos.Logica.Entidades.Gerencia.EReporteAntiguedadPorAtrasoResultado
                           {
                              Poliza=n.Poliza,
                              Fecha_Facturacion=n.Fecha_Facturacion,
                              Inicio_Vigencia=n.Inicio_Vigencia,
                              Fin_Vigencia=n.Fin_Vigencia,
                              Fecha_Ultimo_Pago=n.Fecha_Ultimo_Pago,
                              Supervisor=n.Supervisor,
                              Intermediario=n.Intermediario,
                              Cliente=n.Cliente,
                              Concepto=n.Concepto,
                              Valor_Poliza=n.Valor_Poliza,
                              Total_Pagado=n.Total_Pagado,
                              Balance_Pendiente=n.Balance_Pendiente,
                              Ramo=n.Ramo,
                              NombreRamo=n.NombreRamo,
                              SubRamo=n.SubRamo,
                              NombreSubRamo=n.NombreSubRamo,
                              Estatus=n.Estatus,
                              Balance_En_Atraso=n.Balance_En_Atraso,
                              Inicial=n.Inicial,
                              Cuota=n.Cuota,
                              Pago_0_10=n.Pago_0_10,
                              Pago_0_30=n.Pago_0_30,
                              Pago_31_60=n.Pago_31_60,
                              Pago_61_90=n.Pago_61_90,
                              Pago_91_120=n.Pago_91_120,
                              Pago_121_Mas=n.Pago_121_Mas,
                              DiasTranscurridos=n.DiasTranscurridos,
                              Atraso_0_30=n.Atraso_0_30,
                              Atraso_31_60=n.Atraso_31_60,
                              Atraso_61_90=n.Atraso_61_90,
                              Atraso_91_120=n.Atraso_91_120,
                              Atraso_Mas_120_Dias=n.Atraso_Mas_120_Dias
                           }).ToList();
            return Listado;

        }
        #endregion
    }
}
