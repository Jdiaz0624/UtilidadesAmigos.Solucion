using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Reportes
{
    public class ProcesarInformacionComisionesSupervisores
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObjData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private decimal IdUsuario = 0;
        private string Poliza = "";
        private decimal Recibo = 0;
        private string ConceptoPago = "";
        private string ReciboFormateado = "";
        private string Anulado = "";
        private DateTime FechaPago = DateTime.Now;
        private string FechaPagoFormateado = "";
        private string TipoPago = "";
        private decimal CodigoCliente = 0;
        private string NombreCliente = "";
        private decimal CodigoIntermediario = 0;
        private string NombreIntermediario = "";
        private decimal CodigoSupervisor = 0;
        private string NombreSupervisor = "";
        private int CodigoOficina = 0;
        private string NombreOficina = "";
        private string Usuario = "";
        private int CodigoRamo = 0;
        private string DescripcionRamo = "";
        private int CodigoMoneda = 0;
        private string DescripcionMoneda = "";
        private decimal Bruto = 0;
        private decimal Impuesto = 0;
        private decimal Neto = 0;
        private decimal Tasa = 0;
        private decimal Pesos = 0;
        private string ConceptoFactura = "";
        private decimal PorcientoComisionIntermediario = 0;
        private string ValidadoDesde = "";
        private string ValidadoHasta = "";
        private string Accion = "";

        public ProcesarInformacionComisionesSupervisores(
            decimal IdUsuarioCON,
        string PolizaCON,
        decimal ReciboCON,
        string ConceptoPagoCON,
        string ReciboFormateadoCON,
        string AnuladoCON,
        DateTime FechaPagoCON,
        string FechaPagoFormateadoCON,
        string TipoPagoCON,
        decimal CodigoClienteCON,
        string NombreClienteCON,
        decimal CodigoIntermediarioCON,
        string NombreIntermediarioCON,
        decimal CodigoSupervisorCON,
        string NombreSupervisorCON,
        int CodigoOficinaCON,
        string NombreOficinaCON,
        string UsuarioCON,
        int CodigoRamoCON,
        string DescripcionRamoCON,
        int CodigoMonedaCON,
        string DescripcionMonedaCON,
        decimal BrutoCON,
        decimal ImpuestoCON,
        decimal NetoCON,
        decimal TasaCON,
        decimal PesosCON,
        string ConceptoFacturaCON,
        decimal PorcientoComisionIntermediarioCON,
        string ValidadoDesdeCON,
        string ValidadoHastaCON,
        string AccionCON
            )
        {
            IdUsuario = IdUsuarioCON;
            Poliza = PolizaCON;
            Recibo = ReciboCON;
            ConceptoPago = ConceptoPagoCON;
            ReciboFormateado = ReciboFormateadoCON;
            Anulado = AnuladoCON;
            FechaPago = FechaPagoCON;
            FechaPagoFormateado = FechaPagoFormateadoCON;
            TipoPago = TipoPagoCON;
            CodigoCliente = CodigoClienteCON;
            NombreCliente = NombreClienteCON;
            CodigoIntermediario = CodigoIntermediarioCON;
            NombreIntermediario = NombreIntermediarioCON;
            CodigoSupervisor = CodigoSupervisorCON;
            NombreSupervisor = NombreSupervisorCON;
            CodigoOficina = CodigoOficinaCON;
            NombreOficina = NombreOficinaCON;
            Usuario = UsuarioCON;
            CodigoRamo = CodigoRamoCON;
            DescripcionRamo = DescripcionRamoCON;
            CodigoMoneda = CodigoMonedaCON;
            DescripcionMoneda = DescripcionMonedaCON;
            Bruto = BrutoCON;
            Impuesto = ImpuestoCON;
            Neto = NetoCON;
            Tasa = TasaCON;
            Pesos = PesosCON;
            ConceptoFactura = ConceptoFacturaCON;
            PorcientoComisionIntermediario = PorcientoComisionIntermediarioCON;
            ValidadoDesde = ValidadoDesdeCON;
            ValidadoHasta = ValidadoHastaCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionComisionesSupervisores Procesar = new Entidades.Reportes.EProcesarInformacionComisionesSupervisores();

            Procesar.IdUsuario = IdUsuario;
            Procesar.Poliza = Poliza;
            Procesar.Recibo = Recibo;
            Procesar.ConceptoPago = ConceptoPago;
            Procesar.ReciboFormateado = ReciboFormateado;
            Procesar.Anulado = Anulado;
            Procesar.FechaPago = FechaPago;
            Procesar.FechaPagoFormateado = FechaPagoFormateado;
            Procesar.TipoPago = TipoPago;
            Procesar.CodigoCliente = CodigoCliente;
            Procesar.NombreCliente = NombreCliente;
            Procesar.CodigoIntermediario = CodigoIntermediario;
            Procesar.NombreIntermediario = NombreIntermediario;
            Procesar.CodigoSupervisor = CodigoSupervisor;
            Procesar.NombreSupervisor = NombreSupervisor;
            Procesar.CodigoOficina = CodigoOficina;
            Procesar.NombreOficina = NombreOficina;
            Procesar.Usuario = Usuario;
            Procesar.CodigoRamo = CodigoRamo;
            Procesar.DescripcionRamo = DescripcionRamo;
            Procesar.CodigoMoneda = CodigoMoneda;
            Procesar.DescripcionMoneda = DescripcionMoneda;
            Procesar.Bruto = Bruto;
            Procesar.Impuesto = Impuesto;
            Procesar.Neto = Neto;
            Procesar.Tasa = Tasa;
            Procesar.Pesos = Pesos;
            Procesar.ConceptoFactura = ConceptoFactura;
            Procesar.PorcientoComisionIntermediario = PorcientoComisionIntermediario;
            Procesar.ValidadoDesde = ValidadoDesde;
            Procesar.ValidadoHasta = ValidadoHasta;

            var MAn = ObjData.ProcesaComisionesSupervisores(Procesar, Accion);




        }
    }

    /*
     tabla
    Utililades.InformacionComisionesSupervisores

    procedures
    [Utililades].[SP_PROCESAR_INFORMACION_COMISIONES_SUPERVISORES]
    [Utililades].[SP_BUSCA_DATA_COBRADO_DETALLE] (ORIGEN)
     */
}
