using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Validaciones
{
    public class ValidarClaveSeguridad
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.LogicaSistema();  

        private string ClaveSeguridad = "";

        public ValidarClaveSeguridad(
            string ClaveSeguridadCON)
        {
            ClaveSeguridad = ClaveSeguridadCON;
        }

        public bool ValidacionClave() {
            bool Resultado = false;

            var Valida = ObjData.BuscaClaveSeguridad(
                new Nullable<decimal>(),
                UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(ClaveSeguridad));
            if (Valida.Count() < 1) {
                Resultado = false;
            }
            else {
                Resultado = true;
            }
            return Resultado;
        }
    }
}
