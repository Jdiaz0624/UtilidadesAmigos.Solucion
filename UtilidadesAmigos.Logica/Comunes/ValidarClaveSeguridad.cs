using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes
{
    public  class ValidarClaveSeguridad 
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.LogicaSistema();

        private string ClaveSeguridad { get; set; }

        public ValidarClaveSeguridad(string ClaveSeguridadCON) {
            ClaveSeguridad = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(ClaveSeguridadCON);
        }

        public bool ValidarClave() {
            bool Resultado = false;

            var Validar = ObjData.BuscaClaveSeguridad(
                new Nullable<decimal>(),
                ClaveSeguridad);
            if (Validar.Count() < 1) {
                Resultado = false;
            }
            else {
                Resultado = true;
            }
            return Resultado;
        }
    }
}
