using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Reportes
{
    public class ProcesarInformacionChequesImprimir
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObjData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private decimal IdUsuarioProcesa = 0;
        private decimal NumeroCheque = 0;
        private DateTime FechaCheque = DateTime.Now;
        private string ConceptoCheque = "";
        private decimal ValorCheque = 0;
        private string Beneficiario = "";
        private string MontoChqeueLetras = "";
        private string DiaCheque = "";
        private string MesCheque = "";
        private string AnoCheque = "";
        private string Accion = "";

        public ProcesarInformacionChequesImprimir(
            decimal IdUsuarioProcesaCON,
            decimal NumeroChequeCON,
            DateTime FechaChequeCON,
            string ConceptoChequeCON,
            decimal ValorChequeCON,
            string BeneficiarioCON,
            string MontoChqeueLetrasCON,
            string DiaChequeCON,
            string MesChequeCON,
            string AnoChequeCON,
            string AccionCON)
        {
            IdUsuarioProcesa = IdUsuarioProcesaCON;
            NumeroCheque = NumeroChequeCON;
            FechaCheque = FechaChequeCON;
            ConceptoCheque = ConceptoChequeCON;
            ValorCheque = ValorChequeCON;
            Beneficiario = BeneficiarioCON;
            MontoChqeueLetras = MontoChqeueLetrasCON;
            DiaCheque = DiaChequeCON;
            MesCheque = MesChequeCON;
            AnoCheque = AnoChequeCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarChequesInformacionImprimir Procesar = new Entidades.Reportes.EProcesarChequesInformacionImprimir();

            Procesar.IdUsuarioProcesa = IdUsuarioProcesa;
            Procesar.NumeroCheque = NumeroCheque;
            Procesar.FechaCheque = FechaCheque;
            Procesar.ConceptoCheque = ConceptoCheque;
            Procesar.ValorCheque = ValorCheque;
            Procesar.Beneficiario = Beneficiario;
            Procesar.MontoChqeueLetras = MontoChqeueLetras;
            Procesar.DiaCheque = DiaCheque;
            Procesar.MesCheque = MesCheque;
            Procesar.AnoCheque = AnoCheque;

            var MAN = ObjData.ProcesarDatosCheques(Procesar, Accion);

        }
    }
}
