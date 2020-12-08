using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Reportes
{
    public class ProcesarInformacionDatosReporteIntermediarioInterno
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObjData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private decimal IdUsuario = 0;
        private string Ramo = "";
        private string Oficina = "";
        private string Intermediario = "";
        private decimal PorcientoComision = 0;
        private string RNC = "";
        private string Cuenta = "";
        private string Tipo = "";
        private string Banco = "";
        private decimal Bruto = 0;
        private decimal Neto = 0;
        private decimal Comision = 0;
        private decimal Retencion = 0;
        private decimal Avance = 0;
        private decimal APagar = 0;
        private DateTime FechaDesde = DateTime.Now;
        private DateTime FechaHasta = DateTime.Now;
        private string Accion = "";

        public ProcesarInformacionDatosReporteIntermediarioInterno(
            decimal IdUsuarioCON,
        string RamoCON,
        string OficinaCON,
        string IntermediarioCON,
        decimal PorcientoComisionCON,
        string RNCCON,
        string CuentaCON,
        string TipoCON,
        string BancoCON,
        decimal BrutoCON,
        decimal NetoCON,
        decimal ComisionCON,
        decimal RetencionCON,
        decimal AvanceCON,
        decimal APagarCON,
        DateTime FechaDesdeCON,
        DateTime FechaHastaCON,
        string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            Ramo = RamoCON;
            Oficina = OficinaCON;
            Intermediario = IntermediarioCON;
            PorcientoComision = PorcientoComisionCON;
            RNC = RNCCON;
            Cuenta = CuentaCON;
            Tipo = TipoCON;
            Banco = BancoCON;
            Bruto = BrutoCON;
            Neto = NetoCON;
            Comision = ComisionCON;
            Retencion = RetencionCON;
            Avance = AvanceCON;
            APagar = APagarCON;
            FechaDesde = FechaDesdeCON;
            FechaHasta = FechaHastaCON;
            Accion = AccionCON;
        }
        public void ProcesarInformacionReporteComisionInterno() {
            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarDatosReporteIntermediairoInterno Procesar = new Entidades.Reportes.EProcesarDatosReporteIntermediairoInterno();

            Procesar.IdUsuario = IdUsuario;
            Procesar.Ramo = Ramo;
            Procesar.Oficina = Oficina;
            Procesar.Intermediario = Intermediario;
            Procesar.PorcientoComision = PorcientoComision;
            Procesar.RNC = RNC;
            Procesar.Cuenta = Cuenta;
            Procesar.Tipo = Tipo;
            Procesar.Banco = Banco;
            Procesar.Bruto = Bruto;
            Procesar.Neto = Neto;
            Procesar.Comision = Comision;
            Procesar.Retencion = Retencion;
            Procesar.Avance = Avance;
            Procesar.APagar = APagar;
            Procesar.FechaDesde = FechaDesde;
            Procesar.FechaHasta = FechaHasta;

            var MAN = ObjData.ProcesarInformacionDatosProduccionReporte(Procesar, Accion);
        }
    }
}
