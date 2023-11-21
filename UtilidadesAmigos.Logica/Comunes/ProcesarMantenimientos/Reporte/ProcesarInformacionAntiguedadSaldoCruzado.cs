using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Reporte
{
    public class ProcesarInformacionAntiguedadSaldoCruzado
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido(); 

        private decimal IdUsuario = 0;
        private string Poliza = "";
        private string Origen = "";
        private string EstatusSistema = "";
        private int CodigoRamo = 0;
        private string Ramo = "";
        private int CodigoSubRamo = 0;
        private string SubRamo = "";
        private int Item = 0;
        private string InicioVigencia = "";
        private string FInVigencia = "";
        private decimal MontoNeto = 0;
        private int CodigoSupervisor = 0;
        private string NombreSupervisor = "";
        private int CodigoIntermediario = 0;
        private string NombreIntermediario = "";
        private decimal Codigocliente = 0;
        private string NombreCliente = "";
        private string NumeroIdentificacionCliente = "";
        private string TelefonoOficinaCliente = "";
        private string TelefonoResidenciaCliente = "";
        private string CelularCliente = "";
        private string FaxCliente = "";
        private decimal Facturado = 0;
        private decimal Balance = 0;
        private int CantidadDias = 0;
        private decimal ValorPorDia = 0;
        private string UltimaFechaPago = "";
        private decimal MontoUltimoPago = 0;
        private string FinCobertura = "";
        private decimal _0_30 = 0;
        private decimal _31_60 = 0;
        private decimal _61_90 = 0;
        private decimal _91_120 = 0;
        private decimal _121_150 = 0;
        private decimal _151_MAS = 0;
        private string Accion = "";

        public ProcesarInformacionAntiguedadSaldoCruzado(
        decimal IdUsuarioCON,
        string PolizaCON,
        string OrigenCON,
        string EstatusSistemCON,
        int CodigoRamoCON,
        string RamoCON,
        int CodigoSubRamoCON,
        string SubRamoCON,
        int ItemCON,
        string InicioVigenciaCON,
        string FInVigenciaCON,
        decimal MontoNetoCON,
        int CodigoSupervisorCON,
        string NombreSupervisorCON,
        int CodigoIntermediarioCON,
        string NombreIntermediarioCON,
        decimal CodigoclienteCON,
        string NombreClienteCON,
        string NumeroIdentificacionClienteCON,
        string TelefonoOficinaClienteCON,
        string TelefonoResidenciaClienteCON,
        string CelularClienteCON,
        string FaxClienteCON,
        decimal FacturadoCON,
        decimal BalanceCON,
        int CantidadDiasCON,
        decimal ValorPorDiaCON,
        string UltimaFechaPagoCON,
        decimal MontoUltimoPagoCON,
        string FinCoberturaCON,
        decimal _0_30CON,
        decimal _31_60CON,
        decimal _61_90CON,
        decimal _91_120CON,
        decimal _121_150CON,
        decimal _151_MASCON,
        string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            Poliza = PolizaCON;
            Origen = OrigenCON;
            EstatusSistema = EstatusSistemCON;
            CodigoRamo = CodigoRamoCON;
            Ramo = RamoCON;
            CodigoSubRamo = CodigoSubRamoCON;
            SubRamo = SubRamoCON;
            Item = ItemCON;
            InicioVigencia = InicioVigenciaCON;
            FInVigencia = FInVigenciaCON;
            MontoNeto = MontoNetoCON;
            CodigoSupervisor = CodigoSupervisorCON;
            NombreSupervisor = NombreSupervisorCON;
            CodigoIntermediario = CodigoIntermediarioCON;
            NombreIntermediario = NombreIntermediarioCON;
            Codigocliente = CodigoclienteCON;
            NombreCliente = NombreClienteCON;
            NumeroIdentificacionCliente = NumeroIdentificacionClienteCON;
            TelefonoOficinaCliente = TelefonoOficinaClienteCON;
            TelefonoResidenciaCliente = TelefonoResidenciaClienteCON;
            CelularCliente = CelularClienteCON;
            FaxCliente = FaxClienteCON;
            Facturado = FacturadoCON;
            Balance = BalanceCON;
            CantidadDias = CantidadDiasCON;
            ValorPorDia = ValorPorDiaCON;
            UltimaFechaPago = UltimaFechaPagoCON;
            MontoUltimoPago = MontoUltimoPagoCON;
            FinCobertura = FinCoberturaCON;
            _0_30 = _0_30CON;
            _31_60 = _31_60CON;
            _61_90 = _61_90CON;
            _91_120 = _91_120CON;
            _121_150 = _121_150CON;
            _151_MAS = _151_MASCON;
            Accion = AccionCON;                          
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionAntiguedadSaldoCruzado Procesar = new Entidades.Reportes.EProcesarInformacionAntiguedadSaldoCruzado();

            Procesar.IdUsuario = IdUsuario;
            Procesar.Poliza = Poliza;
            Procesar.Origen = Origen;
            Procesar.EstatusSistema = EstatusSistema;
            Procesar.CodigoRamo = CodigoRamo;
            Procesar.Ramo = Ramo;
            Procesar.CodigoSubRamo = CodigoSubRamo;
            Procesar.SubRamo = SubRamo;
            Procesar.Item = Item;
            Procesar.InicioVigencia = InicioVigencia;
            Procesar.FInVigencia = FInVigencia;
            Procesar.MontoNeto = MontoNeto;
            Procesar.CodigoSupervisor = CodigoSupervisor;
            Procesar.NombreSupervisor = NombreSupervisor;
            Procesar.CodigoIntermediario = CodigoIntermediario;
            Procesar.NombreIntermediario = NombreIntermediario;
            Procesar.Codigocliente = Codigocliente;
            Procesar.NombreCliente = NombreCliente;
            Procesar.NumeroIdentificacionCliente = NumeroIdentificacionCliente;
            Procesar.TelefonoOficinaCliente = TelefonoOficinaCliente;
            Procesar.TelefonoResidenciaCliente = TelefonoResidenciaCliente;
            Procesar.CelularCliente = CelularCliente;
            Procesar.FaxCliente = FaxCliente;
            Procesar.Facturado = Facturado;
            Procesar.Balance = Balance;
            Procesar.CantidadDias = CantidadDias;
            Procesar.ValorPorDia = ValorPorDia;
            Procesar.UltimaFechaPago = UltimaFechaPago;
            Procesar.MontoUltimoPago = MontoUltimoPago;
            Procesar.FinCobertura = FinCobertura;
            Procesar.__0_30 = _0_30;
            Procesar.__31_60 = _31_60;
            Procesar.__61_90 = _61_90;
            Procesar.__91_120 = _91_120;
            Procesar.__121_150 = _121_150;
            Procesar.__151_MAS = _151_MAS;

            var MAN = ObData.ProcesarInformacionAntiguedadSaldoCruzado(Procesar, Accion);
        }
    }
}
