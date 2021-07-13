using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Reportes
{
    public class ProcesarInformacionPolizasARenovar
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObjData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private decimal IdIntermediario = 0;
        private decimal IdSupervisor = 0;
        private string Poliza = "";
        private int Ramo = 0;
        private int SubRamo = 0;
        private decimal Prima =0;
        private DateTime InicioVigencia = DateTime.Now;
        private DateTime FinVigencia = DateTime.Now;
        private int CodigoMes = 0;
        private int CodigoAno = 0;
        private decimal Facturado = 0;
        private decimal Cobrado = 0;
        private decimal Balance = 0;
        private DateTime FechaDesdeFiltro = DateTime.Now;
        private DateTime FechaHastaFiltro = DateTime.Now;
        private string Accion = "";

        public ProcesarInformacionPolizasARenovar(
            decimal IdIntermediarioCON,
        decimal IdSupervisorCON,
        string PolizaCON,
        int RamoCON,
        int SubRamoCON,
        decimal PrimaCON,
        DateTime InicioVigenciaCON,
        DateTime FinVigenciaCON,
        int CodigoMesCON,
        int CodigoAnoCON,
        decimal FacturadoCON,
        decimal CobradoCON,
        decimal BalanceCON,
        DateTime FechaDesdeFiltroCON,
        DateTime FechaHastaFiltroCON,
        string AccionCON)
        {
            IdIntermediario = IdIntermediarioCON;
            IdSupervisor = IdSupervisorCON;
            Poliza = PolizaCON;
            Ramo = RamoCON;
            SubRamo = SubRamoCON;
            Prima = PrimaCON;
            InicioVigencia = InicioVigenciaCON;
            FinVigencia = FinVigenciaCON;
            CodigoMes = CodigoMesCON;
            CodigoAno = CodigoAnoCON;
            Facturado = FacturadoCON;
            Cobrado = CobradoCON;
            Balance = BalanceCON;
            FechaDesdeFiltro = FechaDesdeFiltroCON;
            FechaHastaFiltro = FechaHastaFiltroCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionPolizasARenovar Procesar = new Entidades.Reportes.EProcesarInformacionPolizasARenovar();

            Procesar.IdIntermediario = IdIntermediario;
            Procesar.IdSupervisor = IdSupervisor;
            Procesar.Poliza = Poliza;
            Procesar.Ramo = Ramo;
            Procesar.SubRamo = SubRamo;
            Procesar.Prima = Prima;
            Procesar.InicioVigencia = InicioVigencia;
            Procesar.FinVigencia = FinVigencia;
            Procesar.CodigoMes = CodigoMes;
            Procesar.CodigoAno = CodigoAno;
            Procesar.Facturado = Facturado;
            Procesar.Cobrado = Cobrado;
            Procesar.Balance = Balance;
            Procesar.FechaDesdeFiltro = FechaDesdeFiltro;
            Procesar.FechaHastaFiltro = FechaHastaFiltro;

            var MAN = ObjData.ProcesarDataPolizasARenovar(Procesar, Accion);
        }
    }
}
