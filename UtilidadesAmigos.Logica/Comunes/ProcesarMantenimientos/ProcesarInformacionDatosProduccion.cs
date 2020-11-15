using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionDatosProduccion
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObjData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private decimal IdUsuario = 0;
        private int CodRamo = 0;
        private string Ramo = "";
        private decimal NumeroFactura = 0;
        private string NumeroFacturaFormateado = "";
        private string Poliza = "";
        private string Asegurado = "";
        private int Items = 0;
        private string Supervisor = "";
        private int CodIntermediario = 0;
        private int CodSupervisor = 0;
        private string Intermediario = "";
        private DateTime Fecha = DateTime.Now;
        private string FechaFormateada = "";
        private DateTime FechaInicioVigencia = DateTime.Now;
        private DateTime FechaFinVigencia = DateTime.Now;
        private string InicioVigencia = "";
        private string FinVigencia = "";
        private string SumaAsegurada = "";
        private string Estatus = "";
        private int CodOficina = 0;
        private string Oficina = "";
        private string Concepto = "";
        private string Ncf = "";
        private int Tipo = 0;
        private string DescripcionTipo = "";
        private decimal Bruto = 0;
        private decimal Impuesto = 0;
        private decimal Neto = 0;
        private decimal Tasa = 0;
        private decimal Cobrado = 0;
        private int CodMoneda = 0;
        private string Moneda = "";
        private decimal TasaUsada = 0;
        private decimal MontoPesos = 0;
        private string Mes = "";
        private string Usuario = "";
        private string Accion = "";

        public ProcesarInformacionDatosProduccion(
            decimal IdUsuarioCON,
        int CodRamoCON,
        string RamoCON,
        decimal NumeroFacturaCON,
        string NumeroFacturaFormateadoCON,
        string PolizaCON,
        string AseguradoCON,
        int ItemsCON,
        string SupervisorCON,
        int CodIntermediarioCON,
        int CodSupervisorCON,
        string IntermediarioCON,
        DateTime FechaCON,
        string FechaFormateadaCON,
        DateTime FechaInicioVigenciaCON,
        DateTime FechaFinVigenciaCON,
        string InicioVigenciaCON,
        string FinVigenciaCON,
        string SumaAseguradaCON,
        string EstatusCON,
        int CodOficinaCON,
        string OficinaCON,
        string ConceptoCON,
        string NcfCON,
        int TipoCON,
        string DescripcionTipoCON,
        decimal BrutoCON,
        decimal ImpuestoCON,
        decimal NetoCON,
        decimal TasaCON,
        decimal CobradoCON,
        int CodMonedaCON,
        string MonedaCON,
        decimal TasaUsadaCON,
        decimal MontoPesosCON,
        string MesCON,
        string UsuarioCON,
        string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            CodRamo = CodRamoCON;
            Ramo = RamoCON;
            NumeroFactura = NumeroFacturaCON;
            NumeroFacturaFormateado = NumeroFacturaFormateadoCON;
            Poliza = PolizaCON;
            Asegurado = AseguradoCON;
            Items = ItemsCON;
            Supervisor = SupervisorCON;
            CodIntermediario = CodIntermediarioCON;
            CodSupervisor = CodSupervisorCON;
             Intermediario = IntermediarioCON;
            Fecha = FechaCON;
            FechaFormateada = FechaFormateadaCON;
            FechaInicioVigencia = FechaInicioVigenciaCON;
            FechaFinVigencia = FechaFinVigenciaCON;
            InicioVigencia = InicioVigenciaCON;
            FinVigencia = FinVigenciaCON;
            SumaAsegurada = SumaAseguradaCON;
            Estatus = EstatusCON;
            CodOficina = CodOficinaCON;
            Oficina = OficinaCON;
            Concepto = ConceptoCON;
            Ncf = NcfCON;
            Tipo = TipoCON;
            DescripcionTipo = DescripcionTipoCON;
            Bruto = BrutoCON;
            Impuesto = ImpuestoCON;
            Neto = NetoCON;
            Tasa = TasaCON;
            Cobrado = CobradoCON;
            CodMoneda = CodMonedaCON;
            Moneda = MonedaCON;
            TasaUsada = TasaUsadaCON;
            MontoPesos = MontoPesosCON;
            Mes = MesCON;
            Usuario = UsuarioCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionDatosProduccion Procesar = new Entidades.Reportes.EProcesarInformacionDatosProduccion();

            Procesar.IdUsuario = IdUsuario;
            Procesar.CodRamo = CodRamo;
            Procesar.Ramo = Ramo;
            Procesar.NumeroFactura = NumeroFactura;
            Procesar.NumeroFacturaFormateado = NumeroFacturaFormateado;
            Procesar.Poliza = Poliza;
            Procesar.Asegurado = Asegurado;
            Procesar.Items = Items;
            Procesar.Supervisor = Supervisor;
            Procesar.CodIntermediario = CodIntermediario;
            Procesar.CodSupervisor = CodSupervisor;
            Procesar.Intermediario = Intermediario;
            Procesar.Fecha = Fecha;
            Procesar.FechaFormateada = FechaFormateada;
            Procesar.FechaInicioVigencia = FechaInicioVigencia;
            Procesar.FechaFinVigencia = FechaFinVigencia;
            Procesar.InicioVigencia = InicioVigencia;
            Procesar.FinVigencia = FinVigencia;
            Procesar.SumaAsegurada = SumaAsegurada;
            Procesar.Estatus = Estatus;
            Procesar.CodOficina = CodOficina;
            Procesar.Oficina = Oficina;
            Procesar.Concepto = Concepto;
            Procesar.Ncf = Ncf;
            Procesar.Tipo = Tipo;
            Procesar.DescripcionTipo = DescripcionTipo;
            Procesar.Bruto = Bruto;
            Procesar.Impuesto = Impuesto;
            Procesar.Neto = Neto;
            Procesar.Tasa = Tasa;
            Procesar.Cobrado = Cobrado;
            Procesar.CodMoneda = CodMoneda;
            Procesar.Moneda = Moneda;
            Procesar.TasaUsada = TasaUsada;
            Procesar.MontoPesos = MontoPesos;
            Procesar.Mes = Mes;
            Procesar.Usuario = Usuario;

            var MAN = ObjData.ProcesarInformacionDatosProduccion(Procesar, Accion);
        }
    }
}
