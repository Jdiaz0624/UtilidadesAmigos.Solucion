using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes
{
    public class SacarCredencialesBD
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad ObjData = new Logica.LogicaSeguridad.LogicaSeguridad();

        private int IdCredencial = 0;

        public SacarCredencialesBD(
            int IdCredencialCON)
        {

            IdCredencial = IdCredencialCON;
        }

        public string SacarUsuario() {

            string Usuario = "";

            var SacarInformacion = ObjData.BuscaCredencialesBD(IdCredencial);
            foreach (var n in SacarInformacion) {

                Usuario = n.UsuarioBD;
            }
            return Usuario;
        }

        public string SacarClaveBD()
        {

            string Clave = "";

            var SacarInformacion = ObjData.BuscaCredencialesBD(IdCredencial);
            foreach (var n in SacarInformacion)
            {

                Clave = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.DesEncriptar(n.Clave);
            }
            return Clave;
        }
    }
}
