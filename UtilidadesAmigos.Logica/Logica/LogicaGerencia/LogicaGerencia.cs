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
    }
}
