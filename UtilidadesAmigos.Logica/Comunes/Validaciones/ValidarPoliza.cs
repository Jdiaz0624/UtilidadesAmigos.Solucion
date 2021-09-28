using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Validaciones
{
    public class ValidarPoliza
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.LogicaSistema();

        private string Poliza = "";

        public ValidarPoliza(
            string PolizaCON)
        {
            Poliza = PolizaCON;
        }

        public bool ValidacionPoliza() {

            bool ResultadoValidacion = false;

            var Validar = ObjData.ValidarPoliza(Poliza);
            if (Validar.Count() < 1) {
                ResultadoValidacion = false;
            }
            else {
                ResultadoValidacion = true;
            }
            return ResultadoValidacion;
        }
    }
}
