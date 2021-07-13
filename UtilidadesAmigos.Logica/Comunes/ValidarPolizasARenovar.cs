using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes
{
    public class ValidarPolizasARenovar
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObjData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private decimal CodigoIntermediario = 0;
        private decimal CodigoSupervisor = 0;
        private string Poliza = "";
        private int Ramo = 0;
        private int SubRamo = 0;
        private DateTime InicioVigencia = DateTime.Now;
        private DateTime FinVigencia = DateTime.Now;
        private int Mes = 0;
        private int Ano = 0;

        public ValidarPolizasARenovar(
            decimal CodigoIntermediarioCON,
        decimal CodigoSupervisorCON,
        string PolizaCON,
        int RamoCON,
        int SubRamoCON,
        DateTime InicioVigenciaCON,
        DateTime FinVigenciaCON,
        int MesCON,
        int AnoCON)
        {
            CodigoIntermediario = CodigoIntermediarioCON;
            CodigoSupervisor = CodigoSupervisorCON;
            Poliza = PolizaCON;
            Ramo = RamoCON;
            SubRamo = SubRamoCON;
            InicioVigencia = InicioVigenciaCON;
            FinVigencia = FinVigenciaCON;
            Mes = MesCON;
            Ano = AnoCON;
        }

        public bool ValidacionPolizasRenovar() {
            bool ResultadoValidacion = false;

            var Validar = ObjData.ValidarInformacionPolizaARenovar(
                CodigoIntermediario,
                CodigoSupervisor,
                Poliza,
                Ramo,
                SubRamo,
                InicioVigencia,
                FinVigencia,
                Mes,
                Ano);
            if (Validar.Count() < 1)
            {
                ResultadoValidacion = false;
            }
            else {
                ResultadoValidacion = true;
            }
            return ResultadoValidacion;
        }
    }
}
