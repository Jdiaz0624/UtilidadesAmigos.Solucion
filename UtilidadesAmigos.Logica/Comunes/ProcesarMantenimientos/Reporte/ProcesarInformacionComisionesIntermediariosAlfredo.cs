using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Reporte
{
    public class ProcesarInformacionComisionesIntermediariosAlfredo
    {

        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObjData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private string Supervisor = "";
        private int CodigoSupervisor = 0;
        private int Codigo = 0;
        private string Intermediario = "";
        private int CodigoOficina = 0;
        private string Oficina = "";
        private string NumeroIdentificacion = "";
        private string CuentaBanco = "";
        private string TipoCuenta = "";
        private string Banco = "";
        private int CodigoBanco = 0;
        private string Cliente = "";
        private decimal NumeroRecibo = 0;
        private string Recibo = "";
        private string Fecha = "";
        private string Factura = "";
        private string FechaFactura = "";
        private string Moneda = "";
        private string Poliza = "";
        private int Ramo = 0;
        private string Producto = "";
        private decimal Bruto = 0;
        private decimal Neto = 0;
        private decimal PorcientoComision = 0;
        private decimal Comision = 0;
        private decimal Retencion = 0;
        private decimal AvanceComision = 0;
        private decimal ALiquidar = 0;
        private string ValidadoDesde = "";
        private string ValidadoHasta = "";
        private decimal IdUsuario = 0;
        private string Accion = "";


        public ProcesarInformacionComisionesIntermediariosAlfredo(
            string SupervisorCON,
        int CodigoSupervisorCON,
        int CodigoCON,
        string IntermediarioCON,
        int CodigoOficinaCON,
        string OficinaCON,
        string NumeroIdentificacionCON,
        string CuentaBancoCON,
        string TipoCuentaCON,
        string BancoCON,
        int CodigoBancoCON,
        string ClienteCON,
        decimal NumeroReciboCON,
        string ReciboCON,
        string FechaCON,
        string FacturaCON,
        string FechaFacturaCON,
        string MonedaCON,
        string PolizaCON,
        int RamoCON,
        string ProductoCON,
        decimal BrutoCON,
        decimal NetoCON,
        decimal PorcientoComisionCON,
        decimal ComisionCON,
        decimal RetencionCON,
        decimal AvanceComisionCON,
        decimal ALiquidarCON,
        string ValidadoDesdeCON,
        string ValidadoHastaCON,
        decimal IdUsuarioCON,
        string AccionCON)
        {
            Supervisor = SupervisorCON;
            CodigoSupervisor = CodigoSupervisorCON;
            Codigo = CodigoCON;
            Intermediario = IntermediarioCON;
            CodigoOficina = CodigoOficinaCON;
            Oficina = OficinaCON;
            NumeroIdentificacion = NumeroIdentificacionCON;
            CuentaBanco = CuentaBancoCON;
            TipoCuenta = TipoCuentaCON;
            Banco = BancoCON;
            CodigoBanco = CodigoBancoCON;
            Cliente = ClienteCON;
            NumeroRecibo = NumeroReciboCON;
            Recibo = ReciboCON;
            Fecha = FechaCON;
            Factura = FacturaCON;
            FechaFactura = FechaFacturaCON;
            Moneda = MonedaCON;
            Poliza = PolizaCON;
            Ramo = RamoCON;
            Producto = ProductoCON;
            Bruto = BrutoCON;
            Neto = NetoCON;
            PorcientoComision = PorcientoComisionCON;
            Comision = ComisionCON;
            Retencion = RetencionCON;
            AvanceComision = AvanceComisionCON;
            ALiquidar = ALiquidarCON;
            ValidadoDesde = ValidadoDesdeCON;
            ValidadoHasta = ValidadoHastaCON;
            IdUsuario = IdUsuarioCON;
            Accion = AccionCON;
        }


        /// <summary>
        /// Este metodo es para procesar la información de las comisiones de los ubtermediarios bajo el codigo de alfredo.
        /// </summary>
        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionComisionesIntermediarioAlfredo Procesar = new Entidades.Reportes.EProcesarInformacionComisionesIntermediarioAlfredo();

            Procesar.Supervisor = Supervisor;
            Procesar.CodigoSupervisor = CodigoSupervisor;
            Procesar.Codigo = Codigo;
            Procesar.Intermediario = Intermediario;
            Procesar.CodigoOficina = CodigoOficina;
            Procesar.Oficina = Oficina;
            Procesar.NumeroIdentificacion = NumeroIdentificacion;
            Procesar.CuentaBanco = CuentaBanco;
            Procesar.TipoCuenta = TipoCuenta;
            Procesar.Banco = Banco;
            Procesar.CodigoBanco = CodigoBanco;
            Procesar.Cliente = Cliente;
            Procesar.NumeroRecibo = NumeroRecibo;
            Procesar.Recibo = Recibo;
            Procesar.Fecha = Fecha;
            Procesar.Factura = Factura;
            Procesar.FechaFactura = FechaFactura;
            Procesar.Moneda = Moneda;
            Procesar.Poliza = Poliza;
            Procesar.Ramo = Ramo;
            Procesar.Producto = Producto;
            Procesar.Bruto = Bruto;
            Procesar.Neto = Neto;
            Procesar.PorcientoComision = PorcientoComision;
            Procesar.Comision = Comision;
            Procesar.Retencion = Retencion;
            Procesar.AvanceComision = AvanceComision;
            Procesar.ALiquidar = ALiquidar;
            Procesar.ValidadoDesde = ValidadoDesde;
            Procesar.ValidadoHasta = ValidadoHasta;
            Procesar.IdUsuario = IdUsuario;

            var MAN = ObjData.ProcesarInformacionAlfredo(Procesar, Accion);

        }
    }
}
