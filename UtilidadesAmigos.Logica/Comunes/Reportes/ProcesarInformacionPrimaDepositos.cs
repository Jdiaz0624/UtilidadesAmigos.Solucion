using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Reportes
{
    public class ProcesarInformacionPrimaDepositos
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObjData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private decimal Deposito = 0;
        private decimal Monto = 0;
        private string Accion = "";

        public ProcesarInformacionPrimaDepositos(
            decimal DepositoCON,
            decimal MontoCON,
            string AccionCON)
        {
            Deposito = DepositoCON;
            Monto = MontoCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Reportes.EDepositosPagados Procesar = new Entidades.Reportes.EDepositosPagados();

            Procesar.Deposito = Deposito;
            Procesar.Monto = Monto;

            var MAN = ObjData.ProcesarDepositosPagados(Procesar, Accion);
        }
    }
}
