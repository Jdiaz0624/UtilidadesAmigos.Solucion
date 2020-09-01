using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Reportes
{
    public class ProcesarInformacionReporteComisionIntermediario
    {
        public readonly UtilidadesAmigos.Logica.Logica.LogicaSistema Objdata = new Logica.LogicaSistema();

        private decimal IdUsuario = 0;
        private string Supervisor = "";
        private int CodigoIntermediario = 0;
        private string Intermediario = "";
        private string Oficina = "";
        private string NumeroIdentificacion = "";
        private string CuentaBanco = "";
        private string TipoCuenta = "";
        private string Banco = "";
        private string Cliente = "";
        private string NumeroRecibo = "";
        private string FechaRecibo = "";
        private string NumeroFactura = "";
        private string FechaFactura = "";
        private string Moneda = "";
        private string Poliza = "";
        private string Producto = "";
        private decimal MontoBruto = 0;
        private decimal MontoNeto = 0;
        private decimal PorcientoComision = 0;
        private decimal Comsiion = 0;
        private decimal Retencion = 0;
        private decimal AvanceComision = 0;
        private decimal ALiquidar = 0;
        private decimal CantidadRegistros = 0;
        private DateTime ValidadoDesde = DateTime.Now;
        private DateTime ValidadoHasta= DateTime.Now;
        private string Accion = "";

        public ProcesarInformacionReporteComisionIntermediario(
         decimal IdUsuarioCON,
        string SupervisorCON,
        int CodigoIntermediarioCON,
        string IntermediarioCON,
        string OficinaCON,
        string NumeroIdentificacionCON,
        string CuentaBancoCON,
        string TipoCuentaCON,
        string BancoCON,
        string ClienteCON,
        string NumeroReciboCON,
        string FechaReciboCON,
        string NumeroFacturaCON,
        string FechaFacturaCON,
        string MonedaCON,
        string PolizaCON,
        string ProductoCON,
        decimal MontoBrutoCON,
        decimal MontoNetoCON,
        decimal PorcientoComisionCON,
        decimal ComsiionCON,
        decimal RetencionCON,
        decimal AvanceComisionCON,
        decimal ALiquidarCON,
        decimal CantidadRegistrosCON,
        DateTime ValidadoDesdeCON,
        DateTime ValidadoHastaCON,
        string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            Supervisor = SupervisorCON;
            CodigoIntermediario = CodigoIntermediarioCON;
            Intermediario = IntermediarioCON;
            Oficina = OficinaCON;
            NumeroIdentificacion = NumeroIdentificacionCON;
            CuentaBanco = CuentaBancoCON;
            TipoCuenta = TipoCuentaCON;
            Banco = BancoCON;
            Cliente = ClienteCON;
            NumeroRecibo = NumeroReciboCON;
            FechaRecibo = FechaReciboCON;
            NumeroFactura = NumeroFacturaCON;
            FechaFactura = FechaFacturaCON;
            Moneda = MonedaCON;
            Poliza = PolizaCON;
            Producto = ProductoCON;
            MontoBruto = MontoBrutoCON;
            MontoNeto = MontoNetoCON;
            PorcientoComision = PorcientoComisionCON;
            Comsiion = ComsiionCON;
            Retencion = RetencionCON;
            AvanceComision = AvanceComisionCON;
            ALiquidar = ALiquidarCON;
            CantidadRegistros = CantidadRegistrosCON;
            ValidadoDesde = ValidadoDesdeCON;
            ValidadoHasta = ValidadoHastaCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            try {
                UtilidadesAmigos.Logica.Entidades.EProcesarComisionesIntermediario Procesar = new Entidades.EProcesarComisionesIntermediario();

                Procesar.IdUsuario = IdUsuario;
                Procesar.Supervisor = Supervisor;
                Procesar.CodigoIntermediario = CodigoIntermediario;
                Procesar.Intermediario = Intermediario;
                Procesar.Oficina = Oficina;
                Procesar.NumeroIdentificacion = NumeroIdentificacion;
                Procesar.CuentaBanco = CuentaBanco;
                Procesar.TipoCuenta = TipoCuenta;
                Procesar.Banco = Banco;
                Procesar.Cliente = Cliente;
                Procesar.NumeroRecibo = NumeroRecibo;
                Procesar.FechaRecibo = FechaRecibo;
                Procesar.NumeroFactura = NumeroFactura;
                Procesar.FechaFactura = FechaFactura;
                Procesar.Moneda = Moneda;
                Procesar.Poliza = Poliza;
                Procesar.Producto = Producto;
                Procesar.MontoBruto = MontoBruto;
                Procesar.MontoNeto = MontoNeto;
                Procesar.PorcientoComision = PorcientoComision;
                Procesar.Comsiion = Comsiion;
                Procesar.Retencion = Retencion;
                Procesar.AvanceComision = AvanceComision;
                Procesar.ALiquidar = ALiquidar;
                Procesar.CantidadRegistros = CantidadRegistros;
                Procesar.ValidadoDesde = ValidadoDesde;
                Procesar.ValidadoHasta = ValidadoHasta;

                var MAN = Objdata.ProcesarInformacionReporteComisioIntermediario(Procesar, Accion);
            }
            catch (Exception) { }
        }
    }
}
