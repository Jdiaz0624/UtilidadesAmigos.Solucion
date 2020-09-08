using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionDatosComisionesSupervisores
    {
        public readonly UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.LogicaSistema();

        private decimal IdUsuario = 0;
        private DateTime FechaDesde = DateTime.Now;
        private DateTime FechaHasta = DateTime.Now;
        private int CodigoSupervisor = 0;
        private string Supervisor = "";
        private int CodigoIntermediario = 0;
        private string Intermediario = "";
        private string Poliza = "";
        private decimal NumeroFactura = 0;
        private decimal Valor = 0;
        private string Fecha = "";
        private DateTime Fecha0 = DateTime.Now;
        private int CodigoOficina = 0;
        private string Oficina = "";
        private string Conepto = "";
        private decimal PorcientoComision = 0;
        private decimal ComisionPagar = 0;
        private string Accion = "";

        public ProcesarInformacionDatosComisionesSupervisores(
        decimal IdUsuarioCON,
        DateTime FechaDesdeCON,
        DateTime FechaHastaCON,
        int CodigoSupervisorCON,
        string SupervisorCON,
        int CodigoIntermediarioCON,
        string IntermediarioCON,
        string PolizaCON,
        decimal NumeroFacturaCON,
        decimal ValorCON,
        string FechaCON,
        DateTime Fecha0CON,
        int CodigoOficinaCON,
        string OficinaCON,
        string ConeptoCON,
        decimal PorcientoComisionCON,
        decimal ComisionPagarCON,
        string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            FechaDesde = FechaDesdeCON;
            FechaHasta = FechaHastaCON;
            CodigoSupervisor = CodigoSupervisorCON;
            Supervisor = SupervisorCON;
            CodigoIntermediario = CodigoIntermediarioCON;
            Intermediario = IntermediarioCON;
            Poliza = PolizaCON;
            NumeroFactura = NumeroFacturaCON;
            Valor = ValorCON;
            Fecha = FechaCON;
            Fecha0 = Fecha0CON;
            CodigoOficina = CodigoOficinaCON;
            Oficina = OficinaCON;
            Conepto = ConeptoCON;
            PorcientoComision = PorcientoComisionCON;
            ComisionPagar = ComisionPagarCON;
            Accion = AccionCON;


        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.EProcesarDatosComisionesSupervisores Procesar = new Entidades.EProcesarDatosComisionesSupervisores();

            Procesar.IdUsuario = IdUsuario;
            Procesar.FechaDesde = FechaDesde;
            Procesar.FechaHasta = FechaHasta;
            Procesar.CodigoSupervisor = CodigoSupervisor;
            Procesar.Supervisor = Supervisor;
            Procesar.CodigoIntermediario = CodigoIntermediario;
            Procesar.Intermediario = Intermediario;
            Procesar.Poliza = Poliza;
            Procesar.NumeroFactura = NumeroFactura;
            Procesar.Valor = Valor;
            Procesar.Fecha = Fecha;
            Procesar.Fecha0 = Fecha0;
            Procesar.CodigoOficina = CodigoOficina;
            Procesar.Oficina = Oficina;
            Procesar.Conepto = Conepto;
            Procesar.PorcientoComision = PorcientoComision;
            Procesar.ComisionPagar = ComisionPagar;

            var MAN = ObjData.ProcesarDatosComisionesSupervisores(Procesar, Accion);
        }
    }
}
