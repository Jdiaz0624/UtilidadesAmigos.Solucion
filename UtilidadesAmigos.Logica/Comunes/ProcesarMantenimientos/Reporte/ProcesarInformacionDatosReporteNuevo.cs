using System;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Reporte
{
    public class ProcesarInformacionDatosReporteNuevo
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido Objdata = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private int CodRamo = 0;
        private int SubRamo = 0;
        private string Ramo = "";
        private string NombreSubRamo = "";
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
        private string Hora = "";
        private DateTime FechaInicioVigencia = DateTime.Now;
        private DateTime FechaFinVigencia = DateTime.Now;
        private string InicioVigencia = "";
        private string FinVigencia = "";
        private decimal SumaAsegurada = 0;
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
        private string Moneda = 0;
        private decimal TasaUsada = 0;
        private decimal MontoPesos = 0;
        private int CodigoMes = 0;
        private int CodigoAno = 0;
        private string Mes = "";
        private string Usuario = "";
        private string ValidadoDesde = "";
        private string ValidadoHasta = "";
        private string TipoVehiculo = "";
        private string Marca = "";
        private string Modelo = "";
        private string Ano = "";
        private string Color = "";
        private string Chasis = "";
        private string Placa = "";
        private string GeneradoPor = "";
        private decimal IdUsuarioGeneraReporte = 0;
        private string Accion = "";

        /// <summary>
        /// Este Constructor es para guardar registros para generar el reporte
        /// </summary>
        /// <param name="CodRamoCON"></param>
        /// <param name="SubRamoCON"></param>
        /// <param name="RamoCON"></param>
        /// <param name="NombreSubRamoCON"></param>
        /// <param name="NumeroFacturaCON"></param>
        /// <param name="NumeroFacturaFormateadoCON"></param>
        /// <param name="PolizaCON"></param>
        /// <param name="AseguradoCON"></param>
        /// <param name="ItemsCON"></param>
        /// <param name="SupervisorCON"></param>
        /// <param name="CodIntermediarioCON"></param>
        /// <param name="CodSupervisorCON"></param>
        /// <param name="IntermediarioCON"></param>
        /// <param name="FechaCON"></param>
        /// <param name="FechaFormateadaCON"></param>
        /// <param name="HoraCON"></param>
        /// <param name="FechaInicioVigenciaCON"></param>
        /// <param name="FechaFinVigenciaCON"></param>
        /// <param name="InicioVigenciaCON"></param>
        /// <param name="FinVigenciaCON"></param>
        /// <param name="SumaAseguradaCON"></param>
        /// <param name="EstatusCON"></param>
        /// <param name="CodOficinaCON"></param>
        /// <param name="OficinaCON"></param>
        /// <param name="ConceptoCON"></param>
        /// <param name="NcfCON"></param>
        /// <param name="TipoCON"></param>
        /// <param name="DescripcionTipoCON"></param>
        /// <param name="BrutoCON"></param>
        /// <param name="ImpuestoCON"></param>
        /// <param name="NetoCON"></param>
        /// <param name="TasaCON"></param>
        /// <param name="CobradoCON"></param>
        /// <param name="CodMonedaCON"></param>
        /// <param name="MonedaCON"></param>
        /// <param name="TasaUsadaCON"></param>
        /// <param name="MontoPesosCON"></param>
        /// <param name="CodigoMesCON"></param>
        /// <param name="CodigoAnoCON"></param>
        /// <param name="MesCON"></param>
        /// <param name="UsuarioCON"></param>
        /// <param name="ValidadoDesdeCON"></param>
        /// <param name="ValidadoHastaCON"></param>
        /// <param name="TipoVehiculoCON"></param>
        /// <param name="MarcaCON"></param>
        /// <param name="ModeloCON"></param>
        /// <param name="AnoCON"></param>
        /// <param name="ColorCON"></param>
        /// <param name="ChasisCON"></param>
        /// <param name="PlacaCON"></param>
        /// <param name="GeneradoPorCON"></param>
        /// <param name="IdUsuarioGeneraReporteCON"></param>
        /// <param name="AccionCON"></param>
        public ProcesarInformacionDatosReporteNuevo(
        int CodRamoCON,
        int SubRamoCON,
        string RamoCON,
        string NombreSubRamoCON,
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
        string HoraCON,
        DateTime FechaInicioVigenciaCON,
        DateTime FechaFinVigenciaCON,
        string InicioVigenciaCON,
        string FinVigenciaCON,
        decimal SumaAseguradaCON,
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
        int CodigoMesCON,
        int CodigoAnoCON,
        string MesCON,
        string UsuarioCON,
        string ValidadoDesdeCON,
        string ValidadoHastaCON,
        string TipoVehiculoCON,
        string MarcaCON,
        string ModeloCON,
        string AnoCON,
        string ColorCON,
        string ChasisCON,
        string PlacaCON,
        string GeneradoPorCON,
        decimal IdUsuarioGeneraReporteCON,
        string AccionCON)
        {
            CodRamo = CodRamoCON;
            SubRamo = SubRamoCON;
            Ramo = RamoCON;
            NombreSubRamo = NombreSubRamoCON;
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
            Hora = HoraCON;
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
            CodigoMes = CodigoMesCON;
            CodigoAno = CodigoAnoCON;
            Mes = MesCON;
            Usuario = UsuarioCON;
            ValidadoDesde = ValidadoDesdeCON;
             ValidadoHasta = ValidadoHastaCON;
            TipoVehiculo = TipoVehiculoCON;
             Marca = MarcaCON;
            Modelo = ModeloCON;
            Ano = AnoCON;
            Color = ColorCON;
            Chasis = ChasisCON;
            Placa = PlacaCON;
            GeneradoPor = GeneradoPorCON;
            IdUsuarioGeneraReporte = IdUsuarioGeneraReporteCON;
            Accion = AccionCON;

        }


        /// <summary>
        /// Este Constructor es para eliminar los registos antes de guardar la informacion
        /// </summary>
        /// <param name="IdUsuaruiGeneraReporteCON"></param>
        /// <param name="AccionCON"></param>
        public ProcesarInformacionDatosReporteNuevo(
            decimal IdUsuaruiGeneraReporteCON,
            string AccionCON)
        {

            IdUsuarioGeneraReporte = IdUsuaruiGeneraReporteCON;
            Accion = AccionCON;
        }


        /// <summary>
        /// Procesar la Informacion el Reporte
        /// </summary>
        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Reportes.EDatosReporteNuevo Procesar = new Entidades.Reportes.EDatosReporteNuevo();


            Procesar.CodRamo = CodRamo;
            Procesar.SubRamo = SubRamo;
            Procesar.Ramo = Ramo;
            Procesar.NombreSubRamo = NombreSubRamo;
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
            Procesar.Hora = Hora;
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
            Procesar.CodigoMes = CodigoMes;
            Procesar.CodigoAno = CodigoAno;
            Procesar.Mes = Mes;
            Procesar.Usuario = Usuario;
            Procesar.ValidadoDesde = ValidadoDesde;
            Procesar.ValidadoHasta = ValidadoHasta;
            Procesar.TipoVehiculo = TipoVehiculo;
            Procesar.Marca = Marca;
            Procesar.Modelo = Modelo;
            Procesar.Ano = Ano;
            Procesar.Color = Color;
            Procesar.Chasis = Chasis;
            Procesar.Placa = Placa;
            Procesar.GeneradoPor = GeneradoPor;
            Procesar.IdUsuarioGeneraReporte = IdUsuarioGeneraReporte;

            var MAN = Objdata.ProcesarReporteDatosProduccion(Procesar, Accion);
        }
    }
}
