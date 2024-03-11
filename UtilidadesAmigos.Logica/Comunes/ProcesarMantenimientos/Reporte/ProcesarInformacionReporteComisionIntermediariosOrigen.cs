using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Reporte
{
    public class ProcesarInformacionReporteComisionIntermediariosOrigen
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido Objata = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private decimal IdUSuario = 0;
        private int CodigoSupervisor = 0;
        private string Supervisor = "";
        private int CodigoIntermediario = 0;
        private string Intermediario = "";
        private int Oficina = 0;
        private string NombreOficina = "";
        private string NumeroIdentificacion = "";
        private string NumeroCuenta = "";
        private string TipoCuentaBanco = "";
        private int Banco = 0;
        private string NombreBanco = "";
        private decimal NumeroRecibo = 0;
        private DateTime FechaRecibo0 = DateTime.Now;
        private string FechaRecibo = "";
        private string HoraRecibo = "";
        private string NumeroReciboFormateado = "";
        private decimal NumeroFactura = 0;
        private string NumeroFacturaFormateada = "";
        private DateTime FechaFactura0 = DateTime.Now;
        private string FechaFactura = "";
        private string HoraFactura = "";
        private int CodMoneda = 0;
        private string NoPoliza = "";
        private int Ramo = 0;
        private string NombreRamo = "";
        private decimal TasaPesos = 0;
        private decimal TasaDollar = 0;
        private decimal TasaEuro = 0;
        private decimal ValorRecibo = 0;
        private decimal PorcientoComision = 0;
        private decimal Bruto = 0;
        private decimal Neto = 0;
        private decimal Comision = 0;
        private decimal Retencion = 0;
        private decimal AvanceComision = 0;
        private decimal Aliquidar = 0;
        private string GeneradoPor = "";
        private decimal CodigoUsuario = 0;
        private string ValidadoDesde = "";
        private string ValidadoHasta = "";
        private string Accion = "";

        public ProcesarInformacionReporteComisionIntermediariosOrigen(
            decimal IdUSuarioCON,
            int CodigoSupervisorCON,
            string SupervisorCON,
            int CodigoIntermediarioCON,
            string IntermediarioCON,
            int OficinaCON,
            string NombreOficinaCON,
            string NumeroIdentificacionCON,
            string NumeroCuentaCON,
            string TipoCuentaBancoCON,
            int BancoCON,
            string NombreBancoCON,
            decimal NumeroReciboCON,
            DateTime FechaRecibo0CON,
            string FechaReciboCON,
            string HoraReciboCON,
            string NumeroReciboFormateadoCON,
            decimal NumeroFacturaCON,
            string NumeroFacturaFormateadaCON,
            DateTime FechaFactura0CON,
            string FechaFacturaCON,
            string HoraFacturaCON,
            int CodMonedaCON,
            string NoPolizaCON,
            int RamoCON,
            string NombreRamoCON,
            decimal TasaPesosCON,
            decimal TasaDollarCON,
            decimal TasaEuroCON,
            decimal ValorReciboCON,
            decimal PorcientoComisionCON,
            decimal BrutoCON,
            decimal NetoCON,
            decimal ComisionCON,
            decimal RetencionCON,
            decimal AvanceComisionCON,
            decimal AliquidarCON,
            string GeneradoPorCON,
            decimal CodigoUsuarioCON,
            string ValidadoDesdeCON,
            string ValidadoHastaCON,
            string AccionCON)
        {
            IdUSuario = IdUSuarioCON;
            CodigoSupervisor = CodigoSupervisorCON;
            Supervisor = SupervisorCON;
            CodigoIntermediario = CodigoIntermediarioCON;
            Intermediario = IntermediarioCON;
            Oficina = OficinaCON;
            NombreOficina = NombreOficinaCON;
            NumeroIdentificacion = NumeroIdentificacionCON;
            NumeroCuenta = NumeroCuentaCON;
            TipoCuentaBanco = TipoCuentaBancoCON;
            Banco = BancoCON;
            NombreBanco = NombreBancoCON;
            NumeroRecibo = NumeroReciboCON;
            FechaRecibo0 = FechaRecibo0CON;
            FechaRecibo = FechaReciboCON;
            HoraRecibo = HoraReciboCON;
            NumeroReciboFormateado = NumeroReciboFormateadoCON;
            NumeroFactura = NumeroFacturaCON;
            NumeroFacturaFormateada = NumeroFacturaFormateadaCON;
            FechaFactura0 = FechaFactura0CON;
            FechaFactura = FechaFacturaCON;
            HoraFactura = HoraFacturaCON;
            CodMoneda = CodMonedaCON;
            NoPoliza = NoPolizaCON;
            Ramo = RamoCON;
            NombreRamo = NombreRamoCON;
            TasaPesos = TasaPesosCON;
            TasaDollar = TasaDollarCON;
            TasaEuro = TasaEuroCON;
            ValorRecibo = ValorReciboCON;
            PorcientoComision = PorcientoComisionCON;
            Bruto = BrutoCON;
            Neto = NetoCON;
            Comision = ComisionCON;
            Retencion = RetencionCON;
            AvanceComision = AvanceComisionCON;
            Aliquidar = AliquidarCON;
            GeneradoPor = GeneradoPorCON;
            CodigoUsuario = CodigoUsuarioCON;
            ValidadoDesde = ValidadoDesdeCON;
            ValidadoHasta = ValidadoHastaCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            try {
                UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionReporteComisionIntermediarioOrgen Procesar = new Entidades.Reportes.EProcesarInformacionReporteComisionIntermediarioOrgen();


                Procesar.IdUSuario = IdUSuario;
                Procesar.CodigoSupervisor = CodigoSupervisor;
                Procesar.Supervisor = Supervisor;
                Procesar.CodigoIntermediario = CodigoIntermediario;
                Procesar.Intermediario = Intermediario;
                Procesar.Oficina = Oficina;
                Procesar.NombreOficina = NombreOficina;
                Procesar.NumeroIdentificacion = NumeroIdentificacion;
                Procesar.NumeroCuenta = NumeroCuenta;
                Procesar.TipoCuentaBanco = TipoCuentaBanco;
                Procesar.Banco = Banco;
                Procesar.NombreBanco = NombreBanco;
                Procesar.NumeroRecibo = NumeroRecibo;
                Procesar.FechaRecibo0 = FechaRecibo0;
                Procesar.FechaRecibo = FechaRecibo;
                Procesar.HoraRecibo = HoraRecibo;
                Procesar.NumeroReciboFormateado = NumeroReciboFormateado;
                Procesar.NumeroFactura = NumeroFactura;
                Procesar.NumeroFacturaFormateada = NumeroFacturaFormateada;
                Procesar.FechaFactura0 = FechaFactura0;
                Procesar.FechaFactura = FechaFactura;
                Procesar.HoraFactura = HoraFactura;
                Procesar.CodMoneda = CodMoneda;
                Procesar.NoPoliza = NoPoliza;
                Procesar.Ramo = Ramo;
                Procesar.NombreRamo = NombreRamo;
                Procesar.TasaPesos = TasaPesos;
                Procesar.TasaDollar = TasaDollar;
                Procesar.TasaEuro = TasaEuro;
                Procesar.ValorRecibo = ValorRecibo;
                Procesar.PorcientoComision = PorcientoComision;
                Procesar.Bruto = Bruto;
                Procesar.Neto = Neto;
                Procesar.Comision = Comision;
                Procesar.Retencion = Retencion;
                Procesar.AvanceComision = AvanceComision;
                Procesar.Aliquidar = Aliquidar;
                Procesar.GeneradoPor = GeneradoPor;
                Procesar.CodigoUsuario = CodigoUsuario;
                Procesar.ValidadoDesde = ValidadoDesde;
                Procesar.ValidadoHasta = ValidadoHasta;

                var MAN = Objata.ProcesarDatosInformacionReporteIntermediarioOrigen(Procesar, Accion);
            }
            catch (Exception ex) { }
        }
    }
}
