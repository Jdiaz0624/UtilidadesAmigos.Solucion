using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta
{
    public class ProcesarInformacionEstadisticaRenovacion
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta ObjData = new Logica.LogicaConsulta.LogicaConsulta();

        private decimal IdUsuario = 0;
        private decimal Cotizacion = 0;
        private int Secuencia = 0;
        private string Poliza = "";
        private int CodigoOficina = 0;
        private int CodigoRamo = 0;
        private string NombreRamo = "";
        private int CodigoSubRamo = 0;
        private string NombreSubramo = "";
        private decimal Bruto = 0;
        private DateTime FechaInicioVigencia = DateTime.Now;
        private DateTime FechaFinVigencia = DateTime.Now;
        private int CodigoIntermediario = 0;
        private int CodigoSupervisor = 0;
        private decimal CodigoCliente = 0;
        private int CantidadRenovadas = 0;
        private decimal MontoRenovado = 0;
        private int CantidadCanceladas = 0;
        private decimal MontoCancelado = 0;
        private decimal Cobrado = 0;
        private DateTime ValidadoDesde = DateTime.Now;
        private DateTime ValidadoHasta = DateTime.Now;
        private string Accion = "";

        public ProcesarInformacionEstadisticaRenovacion(
            decimal IdUsuarioCON,
        decimal CotizacionCON,
        int SecuenciaCON,
        string PolizaCON,
        int CodigoOficinaCON,
        int CodigoRamoCON,
        string NombreRamoCON,
        int CodigoSubRamoCON,
        string NombreSubramoCON,
        decimal BrutoCON,
        DateTime FechaInicioVigenciaCON,
        DateTime FechaFinVigenciaCON,
        int CodigoIntermediarioCON,
        int CodigoSupervisorCON,
        decimal CodigoClienteCON,
        int CantidadRenovadasCON,
        decimal MontoRenovadoCON,
        int CantidadCanceladasCON,
        decimal MontoCanceladoCON,
        decimal CobradoCON,
        DateTime ValidadoDesdeCON,
        DateTime ValidadoHastaCON,
        string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            Cotizacion = CotizacionCON;
            Secuencia = SecuenciaCON;
            Poliza = PolizaCON;
            CodigoOficina = CodigoOficinaCON;
            CodigoRamo = CodigoRamoCON;
            NombreRamo = NombreRamoCON;
            CodigoSubRamo = CodigoSubRamoCON;
            NombreSubramo = NombreSubramoCON;
            Bruto = BrutoCON;
            FechaInicioVigencia = FechaInicioVigenciaCON;
            FechaFinVigencia = FechaFinVigenciaCON;
            CodigoIntermediario = CodigoIntermediarioCON;
            CodigoSupervisor = CodigoSupervisorCON;
            CodigoCliente = CodigoClienteCON;
            CantidadRenovadas = CantidadRenovadasCON;
            MontoRenovado = MontoRenovadoCON;
            CantidadCanceladas = CantidadCanceladasCON;
            MontoCancelado = MontoCanceladoCON;
            Cobrado = CobradoCON;
            ValidadoDesde = ValidadoDesdeCON;
            ValidadoHasta = ValidadoHastaCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarDatosEstadistocaRenovacion Procesar = new Entidades.Consulta.EProcesarDatosEstadistocaRenovacion();

            Procesar.IdUsuario = IdUsuario;
            Procesar.Cotizacion = Cotizacion;
            Procesar.Secuencia = Secuencia;
            Procesar.Poliza = Poliza;
            Procesar.CodigoOficina = CodigoOficina;
            Procesar.CodigoRamo = CodigoRamo;
            Procesar.NombreRamo = NombreRamo;
            Procesar.CodigoSubRamo = CodigoSubRamo;
            Procesar.NombreSubramo = NombreSubramo;
            Procesar.Bruto = Bruto;
            Procesar.FechaInicioVigencia = FechaInicioVigencia;
            Procesar.FechaFinVigencia = FechaFinVigencia;
            Procesar.CodigoIntermediario = CodigoIntermediario;
            Procesar.CodigoSupervisor = CodigoSupervisor;
            Procesar.CodigoCliente = CodigoCliente;
            Procesar.CantidadRenovadas = CantidadRenovadas;
            Procesar.MontoRenovado = MontoRenovado;
            Procesar.CantidadCanceladas = CantidadCanceladas;
            Procesar.MontoCancelado = MontoCancelado;
            Procesar.Cobrado = Cobrado;
            Procesar.ValidadoDesde = ValidadoDesde;
            Procesar.ValidadoHasta = ValidadoHasta;

            var MAN = ObjData.ProcesarDatosEstadisticaRenovacion(Procesar, Accion);
        }
    }
}
