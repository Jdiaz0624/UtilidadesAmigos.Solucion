using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionReporteEstadisticaPolizasSinPagos
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.LogicaSistema();

        private decimal IdUsuario = 0;
        private string Poliza = "";
        private decimal NumeroFactura = 0;
        private int Tipo = 0;
        private int CodigoRamo = 0;
        private string Ramo = "";
        private int CodigoSubRamo = 0;
        private string SubRamo = "";
        private decimal CodigoAsegurado = 0;
        private string NombreAsegurado = "";
        private int CodigoVendedor = 0;
        private string NombreVendedor = "";
        private int CodigoSupervisor = 0;
        private string NombreSupervisor = "";
        private int CodigoOficina = 0;
        private string NombreOficina = "";
        private DateTime Fecha = DateTime.Now;
        private string FechaFormateada = "";
        private string Hora = "";
        private int DiasTranscurridos = 0;
        private string Ncf = "";
        private decimal MontoBruto = 0;
        private decimal ISC = 0;
        private decimal MontoNeto = 0;
        private decimal Cobrado = 0;
        private int CodMoneda = 0;
        private string Moneda = "";
        private string Siglas = "";
        private string Concepto = "";
        private int CodigoEstatus = 0;
        private string Accion = "";

        public ProcesarInformacionReporteEstadisticaPolizasSinPagos(
            decimal IdUsuarioCON,
        string PolizaCON,
        decimal NumeroFacturaCON,
        int TipoCON,
        int CodigoRamoCON,
        string RamoCON,
        int CodigoSubRamoCON,
        string SubRamoCON,
        decimal CodigoAseguradoCON,
        string NombreAseguradoCON,
        int CodigoVendedorCON,
        string NombreVendedorCON,
        int CodigoSupervisorCON,
        string NombreSupervisorCON,
        int CodigoOficinaCON,
        string NombreOficinaCON,
        DateTime FechaCON,
        string FechaFormateadaCON,
        string HoraCON,
        int DiasTranscurridosCON,
        string NcfCON,
        decimal MontoBrutoCON,
        decimal ISCCON,
        decimal MontoNetoCON,
        decimal CobradoCON,
        int CodMonedaCON,
        string MonedaCON,
        string SiglasCON,
        string ConceptoCON,
        int CodigoEstatusCON,
        string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            Poliza = PolizaCON;
            NumeroFactura = NumeroFacturaCON;
            Tipo = TipoCON;
            CodigoRamo = CodigoRamoCON;
            Ramo = RamoCON;
            CodigoSubRamo = CodigoSubRamoCON;
            SubRamo = SubRamoCON;
            CodigoAsegurado = CodigoAseguradoCON;
            NombreAsegurado = NombreAseguradoCON;
            CodigoVendedor = CodigoVendedorCON;
            NombreVendedor = NombreVendedorCON;
            CodigoSupervisor = CodigoSupervisorCON;
            NombreSupervisor = NombreSupervisorCON;
            CodigoOficina = CodigoOficinaCON;
            NombreOficina = NombreOficinaCON;
            Fecha = FechaCON;
            FechaFormateada = FechaFormateadaCON;
            Hora = HoraCON;
            DiasTranscurridos = DiasTranscurridosCON;
            Ncf = NcfCON;
            MontoBruto = MontoBrutoCON;
            ISC = ISCCON;
            MontoNeto = MontoNetoCON;
            Cobrado = CobradoCON;
            CodMoneda = CodMonedaCON;
            Moneda = MonedaCON;
            Siglas = SiglasCON;
            Concepto = ConceptoCON;
            CodigoEstatus = CodigoEstatusCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.EReporteEstadisticaPolizasSinPagos Procesar = new Entidades.EReporteEstadisticaPolizasSinPagos();

            Procesar.IdUsuario = IdUsuario;
            Procesar.Poliza = Poliza;
            Procesar.NumeroFactura = NumeroFactura;
            Procesar.Tipo = Tipo;
            Procesar.CodigoRamo = CodigoRamo;
            Procesar.Ramo = Ramo;
            Procesar.CodigoSubRamo = CodigoSubRamo;
            Procesar.SubRamo = SubRamo;
            Procesar.CodigoAsegurado = CodigoAsegurado;
            Procesar.NombreAsegurado = NombreAsegurado;
            Procesar.CodigoVendedor = CodigoVendedor;
            Procesar.NombreVendedor = NombreVendedor;
            Procesar.CodigoSupervisor = CodigoSupervisor;
            Procesar.NombreSupervisor = NombreSupervisor;
            Procesar.CodigoOficina = CodigoOficina;
            Procesar.NombreOficina = NombreOficina;
            Procesar.Fecha = Fecha;
            Procesar.FechaFormateada = FechaFormateada;
            Procesar.Hora = Hora;
            Procesar.DiasTranscurridos = DiasTranscurridos;
            Procesar.Ncf = Ncf;
            Procesar.MontoBruto = MontoBruto;
            Procesar.ISC = ISC;
            Procesar.MontoNeto = MontoNeto;
            Procesar.Cobrado = Cobrado;
            Procesar.CodMoneda = CodMoneda;
            Procesar.Moneda = Moneda;
            Procesar.Siglas = Siglas;
            Procesar.Concepto = Concepto;
            Procesar.CodigoEstatus = CodigoEstatus;

            var MAN = ObjData.ProcesarEstadisticaPolizasSinPagos(Procesar, Accion);
        }
    }
}
