using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionReporteAntiguedadSaldo
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos ObjData = new Logica.LogicaMantenimientos.LogicaMantenimientos();

        private decimal IdUsuario = 0;
        private DateTime FechaCorte = DateTime.Now;
        private string DocumentoFormateado = "";
        private decimal DocumentoFiltro = 0;
        private int Tipo = 0;
        private string DescripcionTipo = "";
        private string Asegurado = "";
        private decimal CodCliente = 0;
        private string FechaFactura = "";
        private string Intermediario = "";
        private int CodIntermediario = 0;
        private string Poliza = "";
        private int CodMoneda = 0;
        private string DescripcionMoneda = "";
        private string Estatus = "";
        private int CodRamo = 0;
        private string InicioVigencia = "";
        private DateTime Inicio = DateTime.Now;
        private string FinVigencia = "";
        private DateTime Fin = DateTime.Now;
        private int CodOficina = 0;
        private string Oficina = "";
        private int dias = 0;
        private decimal Facturado = 0;
        private decimal Cobrado = 0;
        private decimal Balance = 0;
        private decimal Impuesto = 0;
        private decimal PorcientoComision = 0;
        private decimal ValorComision = 0;
        private decimal ComisionPendiente = 0;
        private decimal _0_10 = 0;
        private decimal _0_30 = 0;
        private decimal _31_60 = 0;
        private decimal _61_90 = 0;
        private decimal _91_120 = 0;
        private decimal _121_150 = 0;
        private decimal _151_mas = 0;
        private decimal Total = 0;
        private decimal Diferencia = 0;
        private int OrigenTipo = 0;
        private string Accion = "";

        public ProcesarInformacionReporteAntiguedadSaldo(
        decimal IdUsuarioCON,
        DateTime FechaCorteCON,
        string DocumentoFormateadoCON,
        decimal DocumentoFiltroCON,
        int TipoCON,
        string DescripcionTipoCON,
        string AseguradoCON,
        decimal CodClienteCON,
        string FechaFacturaCON,
        string IntermediarioCON,
        int CodIntermediarioCON,
        string PolizaCON,
        int CodMonedaCON,
        string DescripcionMonedaCON,
        string EstatusCON,
        int CodRamoCON,
        string InicioVigenciaCON,
        DateTime InicioCON,
        string FinVigenciaCON,
        DateTime FinCON,
        int CodOficinaCON,
        string OficinaCON,
        int diasCON,
        decimal FacturadoCON,
        decimal CobradoCON,
        decimal BalanceCON,
        decimal ImpuestoCON,
        decimal PorcientoComisionCON,
        decimal ValorComisionCON,
        decimal ComisionPendienteCON,
        decimal _0_10CON,
        decimal _0_30CON,
        decimal _31_60CON,
        decimal _61_90CON,
        decimal _91_120CON,
        decimal _121_150CON,
        decimal _151_masCON,
        decimal TotalCON,
        decimal DiferenciaCON,
        int OrigenTipoCON,
        string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            FechaCorte = FechaCorteCON;
            DocumentoFormateado = DocumentoFormateadoCON;
            DocumentoFiltro = DocumentoFiltroCON;
            Tipo = TipoCON;
            DescripcionTipo = DescripcionTipoCON;
            Asegurado = AseguradoCON;
            CodCliente = CodClienteCON;
            FechaFactura = FechaFacturaCON;
            Intermediario = IntermediarioCON;
            CodIntermediario = CodIntermediarioCON;
            Poliza = PolizaCON;
            CodMoneda = CodMonedaCON;
            DescripcionMoneda = DescripcionMonedaCON;
            Estatus = EstatusCON;
            CodRamo = CodRamoCON;
            InicioVigencia = InicioVigenciaCON;
            Inicio = InicioCON;
            FinVigencia = FinVigenciaCON;
            Fin = FinCON;
            CodOficina = CodOficinaCON;
            Oficina = OficinaCON;
            dias = diasCON;
            Facturado = FacturadoCON;
            Cobrado = CobradoCON;
            Balance = BalanceCON;
            Impuesto = ImpuestoCON;
            PorcientoComision = PorcientoComisionCON;
            ValorComision = ValorComisionCON;
            ComisionPendiente = ComisionPendienteCON;
            _0_10 = _0_10CON;
            _0_30 = _0_30CON;
            _31_60 = _31_60CON;
            _61_90 = _61_90CON;
            _91_120 = _91_120CON;
            _121_150 = _121_150CON;
            _151_mas = _151_masCON;
            Total = TotalCON;
            Diferencia = DiferenciaCON;
            OrigenTipo = OrigenTipoCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarInformacionAntiguedadSaldo Procesar = new Entidades.Mantenimientos.EProcesarInformacionAntiguedadSaldo();

            Procesar.IdUsuario = IdUsuario;
            Procesar.FechaCorte = FechaCorte;
            Procesar.DocumentoFormateado = DocumentoFormateado;
            Procesar.DocumentoFiltro = DocumentoFiltro;
            Procesar.Tipo = Tipo;
            Procesar.DescripcionTipo = DescripcionTipo;
            Procesar.Asegurado = Asegurado;
            Procesar.CodCliente = CodCliente;
            Procesar.FechaFactura = FechaFactura;
            Procesar.Intermediario = Intermediario;
            Procesar.CodIntermediario = CodIntermediario;
            Procesar.Poliza = Poliza;
            Procesar.CodMoneda = CodMoneda;
            Procesar.DescripcionMoneda = DescripcionMoneda;
            Procesar.Estatus = Estatus;
            Procesar.CodRamo = CodRamo;
            Procesar.InicioVigencia = InicioVigencia;
            Procesar.Inicio = Inicio;
            Procesar.FinVigencia = FinVigencia;
            Procesar.Fin = Fin;
            Procesar.CodOficina = CodOficina;
            Procesar.Oficina = Oficina;
            Procesar.dias = dias;
            Procesar.Facturado = Facturado;
            Procesar.Cobrado = Cobrado;
            Procesar.Balance = Balance;
            Procesar.Impuesto = Impuesto;
            Procesar.PorcientoComision = PorcientoComision;
            Procesar.ValorComision = ValorComision;
            Procesar.ComisionPendiente = ComisionPendiente;
            Procesar.__0_10 = _0_10;
            Procesar.__0_30 = _0_30;
            Procesar.__31_60 = _31_60;
            Procesar.__61_90 = _61_90;
            Procesar.__91_120 = _91_120;
            Procesar.__121_150 = _121_150;
            Procesar.__151_mas = _151_mas;
            Procesar.Total = Total;
            Procesar.Diferencia = Diferencia;
            Procesar.OrigenTipo = OrigenTipo;

            var MAn = ObjData.ProcesarInformacionAntiguedadSaldo(Procesar, Accion);

    }

    }
}
