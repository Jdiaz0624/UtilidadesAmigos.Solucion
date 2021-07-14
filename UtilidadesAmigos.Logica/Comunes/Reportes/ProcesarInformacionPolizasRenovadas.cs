using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Reportes
{
    public class ProcesarInformacionPolizasRenovadas
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObjData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private decimal IdIntermediario = 0;
        private decimal IdSupervisor = 0;
        private string Poliza = "";
        private int Ramo = 0;
        private int SubRamo = 0;
        private decimal Prima = 0;
        private DateTime InicioVigencia = DateTime.Now;
        private DateTime FinVigencia = DateTime.Now;
        private DateTime FechaProceso = DateTime.Now;
        private int CodigoMes = 0;
        private int CodigoAno = 0;
        private decimal CobradoMes = 0;
        private decimal FacturadoTotal = 0;
        private decimal CobradoTotal = 0;
        private decimal BalanceTotal = 0;
        private string Accion = "";

        public ProcesarInformacionPolizasRenovadas(
            decimal IdIntermediarioCON,
        decimal IdSupervisorCON,
        string PolizaCON,
        int RamoCON,
        int SubRamoCON,
        decimal PrimaCON,
        DateTime InicioVigenciaCON,
        DateTime FinVigenciaCON,
        DateTime FechaProcesoCON,
        int CodigoMesCON,
        int CodigoAnoCON,
        decimal CobradoMesCON,
        decimal FacturadoTotalCON,
        decimal CobradoTotalCON,
        decimal BalanceTotalCON,
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
            FechaProceso = FechaProcesoCON;
            CodigoMes = CodigoMesCON;
            CodigoAno = CodigoAnoCON;
            CobradoMes = CobradoMesCON;
            FacturadoTotal = FacturadoTotalCON;
            CobradoTotal = CobradoTotalCON;
            BalanceTotal = BalanceTotalCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionPolizasRenovadas Procesar = new Entidades.Reportes.EProcesarInformacionPolizasRenovadas();

            Procesar.IdIntermediario = IdIntermediario;
            Procesar.IdSupervisor = IdSupervisor;
            Procesar.Poliza = Poliza;
            Procesar.Ramo = Ramo;
            Procesar.SubRamo = SubRamo;
            Procesar.Prima = Prima;
            Procesar.InicioVigencia = InicioVigencia;
            Procesar.FinVigencia = FinVigencia;
            Procesar.FechaProceso = FechaProceso;
            Procesar.CodigoMes = CodigoMes;
            Procesar.CodigoAno = CodigoAno;
            Procesar.CobradoMes = CobradoMes;
            Procesar.FacturadoTotal = FacturadoTotal;
            Procesar.CobradoTotal = CobradoTotal;
            Procesar.BalanceTotal = BalanceTotal;

            var MAN = ObjData.ProcesarDataPolizasRenovadas(Procesar, Accion);
        }
    }
}
