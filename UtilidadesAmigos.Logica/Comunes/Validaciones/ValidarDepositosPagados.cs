using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Validaciones
{
    public class ValidarDepositosPagados
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObjData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private decimal Deposito = 0;
        private decimal Monto = 0;

        public ValidarDepositosPagados(
            decimal DepositoCON,
            decimal MontoCon)
        {

            Deposito = DepositoCON;
            Monto = MontoCon;
        }

        public string ResultadoValidacion() {

            string Resultado = "";

            var Validar = ObjData.ValidarDepositosPagados(Deposito, Monto);
            foreach (var n in Validar) {

                Resultado = n.Validacion;
            }
            return Resultado;
        }
    }
}
