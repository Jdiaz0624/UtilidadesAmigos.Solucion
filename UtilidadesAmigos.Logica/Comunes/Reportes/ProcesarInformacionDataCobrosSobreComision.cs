using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Reportes
{
    public class ProcesarInformacionDataCobrosSobreComision
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObjData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private decimal CodigoBeneficiario = 0;
        private decimal PorcientoComisionBeneficiario = 0;
        private decimal IdUsuarioProcesa = 0;
        private DateTime FechaValidadoDesde = DateTime.Now;
        private DateTime FechaValidadoHasta = DateTime.Now;
        private string Poliza = "";
        private decimal NumeroRecibo = 0;
        private string Concepto = "";
        private string NumeroReciboFormateado = "";
        private string TipoPago = "";
        private decimal CodigoCliente = 0;
        private string NombreCliente = "";
        private decimal CodigoIntermediario = 0;
        private string NombreIntermediario = "";
        private decimal CodigoSupervisor = 0;
        private string NombreSupervisor = "";
        private decimal CodigoOficina = 0;
        private string NombreOficina = "";
        private decimal CodigoRamo = 0;
        private string NombreRamo = "";
        private decimal CodigoMoneda = 0;
        private string NombreMoneda = "";
        private decimal Bruto = 0;
        private decimal Impuesto = 0;
        private decimal Neto = 0;
        private decimal Tasa = 0;
        private decimal MontoPesos = 0;
        private string Accion = "";

        public ProcesarInformacionDataCobrosSobreComision(
            decimal CodigoBeneficiarioCON,
        decimal PorcientoComisionBeneficiarioCON,
        decimal IdUsuarioProcesaCON,
        DateTime FechaValidadoDesdeCON,
        DateTime FechaValidadoHastaCON,
        string PolizaCON,
        decimal NumeroReciboCON,
        string ConceptoCON,
        string NumeroReciboFormateadoCON,
        string TipoPagoCON,
        decimal CodigoClienteCON,
        string NombreClienteCON,
        decimal CodigoIntermediarioCON,
        string NombreIntermediarioCON,
        decimal CodigoSupervisorCON,
        string NombreSupervisorCON,
        decimal CodigoOficinaCON,
        string NombreOficinaCON,
        decimal CodigoRamoCON,
        string NombreRamoCON,
        decimal CodigoMonedaCON,
        string NombreMonedaCON,
        decimal BrutoCON,
        decimal ImpuestoCON,
        decimal NetoCON,
        decimal TasaCON,
        decimal MontoPesosCON,
        string AccionCON)
        {
            CodigoBeneficiario = CodigoBeneficiarioCON;
            PorcientoComisionBeneficiario = PorcientoComisionBeneficiarioCON;
            IdUsuarioProcesa = IdUsuarioProcesaCON;
            FechaValidadoDesde = FechaValidadoDesdeCON;
            FechaValidadoHasta = FechaValidadoHastaCON;
            Poliza = PolizaCON;
            NumeroRecibo = NumeroReciboCON;
            Concepto = ConceptoCON;
            NumeroReciboFormateado = NumeroReciboFormateadoCON;
            TipoPago = TipoPagoCON;
            CodigoCliente = CodigoClienteCON;
            NombreCliente = NombreClienteCON;
            CodigoIntermediario = CodigoIntermediarioCON;
            NombreIntermediario = NombreIntermediarioCON;
            CodigoSupervisor = CodigoSupervisorCON;
            NombreSupervisor = NombreSupervisorCON;
            CodigoOficina = CodigoOficinaCON;
            NombreOficina = NombreOficinaCON;
            CodigoRamo = CodigoRamoCON;
            NombreRamo = NombreRamoCON;
            CodigoMoneda = CodigoMonedaCON;
            NombreMoneda = NombreMonedaCON;
            Bruto = BrutoCON;
            Impuesto = ImpuestoCON;
            Neto = NetoCON;
            Tasa = TasaCON;
            MontoPesos = MontoPesosCON;
            Accion = AccionCON;
        }

        /// <summary>
        /// Procesar la Informacion de los datos para la sobre comisión
        /// </summary>
        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionDataCobrado Procesar = new Entidades.Reportes.EProcesarInformacionDataCobrado();

            Procesar.CodigoBeneficiario = CodigoBeneficiario;
            Procesar.PorcientoComisionBeneficiario = PorcientoComisionBeneficiario;
            Procesar.IdUsuarioProcesa = IdUsuarioProcesa;
            Procesar.FechaValidadoDesde = FechaValidadoDesde;
            Procesar.FechaValidadoHasta = FechaValidadoHasta;
            Procesar.Poliza = Poliza;
            Procesar.NumeroRecibo = NumeroRecibo;
            Procesar.Concepto = Concepto;
            Procesar.NumeroReciboFormateado = NumeroReciboFormateado;
            Procesar.TipoPago = TipoPago;
            Procesar.CodigoCliente = CodigoCliente;
            Procesar.NombreCliente = NombreCliente;
            Procesar.CodigoIntermediario = CodigoIntermediario;
            Procesar.NombreIntermediario = NombreIntermediario;
            Procesar.CodigoSupervisor = CodigoSupervisor;
            Procesar.NombreSupervisor = NombreSupervisor;
            Procesar.CodigoOficina = CodigoOficina;
            Procesar.NombreOficina = NombreOficina;
            Procesar.CodigoRamo = CodigoRamo;
            Procesar.NombreRamo = NombreRamo;
            Procesar.CodigoMoneda = CodigoMoneda;
            Procesar.NombreMoneda = NombreMoneda;
            Procesar.Bruto = Bruto;
            Procesar.Impuesto = Impuesto;
            Procesar.Neto = Neto;
            Procesar.Tasa = Tasa;
            Procesar.MontoPesos = MontoPesos;

            var MAN = ObjData.ProcesarDataCobradoSobreComision(Procesar, Accion);
        }
    }
}
