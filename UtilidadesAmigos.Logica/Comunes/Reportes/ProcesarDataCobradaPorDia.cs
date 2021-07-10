using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Reportes
{
    public class ProcesarDataCobradaPorDia
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObjData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private decimal IdUsuario = 0;
        private string Poliza = "";
        private decimal Numero = 0;
        private string Concepto = "";
        private string NumeroFormateado = "";
        private string Anulado = "";
        private DateTime Fecha = DateTime.Now;
        private string FechaFormateada = "";
        private string TipoPago = "";
        private string CodigoCliente = "";
        private string Cliente = "";
        private decimal CodigoIntermediario = 0;
        private string Intermediario = "";
        private decimal CodigoSupervisor = 0;
        private string NombreSupervisor = "";
        private decimal CodigoOficina = 0;
        private string Oficina = "";
        private string Usuario = "";
        private decimal CodigoRamo = 0;
        private string NombreRamo = "";
        private decimal CodigoMoneda = 0;
        private string NombreMoneda = "";
        private decimal Bruto = 0;
        private decimal Impuesto = 0;
        private decimal Neto = 0;
        private decimal Tasa = 0;
        private decimal MontoPesos = 0;
        private string ValidadoDesde = "";
        private string ValidadoHasta = "";
        private string Accion = "";

        public ProcesarDataCobradaPorDia(
            decimal IdUsuarioCON,
        string PolizaCON,
        decimal NumeroCON,
        string ConceptoCON,
        string NumeroFormateadoCON,
        string AnuladoCON,
        DateTime FechaCON,
        string FechaFormateadaCON,
        string TipoPagoCON,
        string CodigoClienteCON,
        string ClienteCON,
        decimal CodigoIntermediarioCON,
        string IntermediarioCON,
        decimal CodigoSupervisorCON,
        string NombreSupervisorCON,
        decimal CodigoOficinaCON,
        string OficinaCON,
        string UsuarioCON,
        decimal CodigoRamoCON,
        string NombreRamoCON,
        decimal CodigoMonedaCON,
        string NombreMonedaCON,
        decimal BrutoCON,
        decimal ImpuestoCON,
        decimal NetoCON,
        decimal TasaCON,
        decimal MontoPesosCON,
        string ValidadoDesdeCON,
        string ValidadoHastaCON,
        string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            Poliza = PolizaCON;
            Numero = NumeroCON;
            Concepto = ConceptoCON;
            NumeroFormateado = NumeroFormateadoCON;
            Anulado = AnuladoCON;
            Fecha = FechaCON;
            FechaFormateada = FechaFormateadaCON;
            TipoPago = TipoPagoCON;
            CodigoCliente = CodigoClienteCON;
            Cliente = ClienteCON;
            CodigoIntermediario = CodigoIntermediarioCON;
            Intermediario = IntermediarioCON;
            CodigoSupervisor = CodigoSupervisorCON;
            NombreSupervisor = NombreSupervisorCON;
            CodigoOficina = CodigoOficinaCON;
            Oficina = OficinaCON;
            Usuario = UsuarioCON;
            CodigoRamo = CodigoRamoCON;
            NombreRamo = NombreRamoCON;
            CodigoMoneda = CodigoMonedaCON;
            NombreMoneda = NombreMonedaCON;
            Bruto = BrutoCON;
            Impuesto = ImpuestoCON;
            Neto = NetoCON;
            Tasa = TasaCON;
            MontoPesos = MontoPesosCON;
            ValidadoDesde = ValidadoDesdeCON;
            ValidadoHasta = ValidadoHastaCON;
            Accion = AccionCON;
        }

        /// <summary>
        /// Procesar la Informacion de la Data de lo cobrado del dia.
        /// </summary>
        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionDataCobradoPorDia Procesar = new Entidades.Reportes.EProcesarInformacionDataCobradoPorDia();

            Procesar.IdUsuario = IdUsuario;
            Procesar.Poliza = Poliza;
            Procesar.Numero = Numero;
            Procesar.Concepto = Concepto;
            Procesar.NumeroFormateado = NumeroFormateado;
            Procesar.Anulado = Anulado;
            Procesar.Fecha = Fecha;
            Procesar.FechaFormateada = FechaFormateada;
            Procesar.TipoPago = TipoPago;
            Procesar.CodigoCliente = CodigoCliente;
            Procesar.Cliente = Cliente;
            Procesar.CodigoIntermediario = CodigoIntermediario;
            Procesar.Intermediario = Intermediario;
            Procesar.CodigoSupervisor = CodigoSupervisor;
            Procesar.NombreSupervisor = NombreSupervisor;
            Procesar.CodigoOficina = CodigoOficina;
            Procesar.Oficina = Oficina;
            Procesar.Usuario = Usuario;
            Procesar.CodigoRamo = CodigoRamo;
            Procesar.NombreRamo = NombreRamo;
            Procesar.CodigoMoneda = CodigoMoneda;
            Procesar.NombreMoneda = NombreMoneda;
            Procesar.Bruto = Bruto;
            Procesar.Impuesto = Impuesto;
            Procesar.Neto = Neto;
            Procesar.Tasa = Tasa;
            Procesar.MontoPesos = MontoPesos;
            Procesar.ValidadoDesde = ValidadoDesde;
            Procesar.ValidadoHasta = ValidadoHasta;


            var MAn = ObjData.ProcesarDataCobradoPorDia(Procesar, Accion);

        }
    }
}
