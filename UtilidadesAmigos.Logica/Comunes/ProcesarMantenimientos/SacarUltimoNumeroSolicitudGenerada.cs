using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public static class SacarUltimoNumeroSolicitudGenerada
    {
        static readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos ObjData = new Logica.LogicaMantenimientos.LogicaMantenimientos();
        public static  int SacarNumeroSolicitud(int CodigoBeneficiario) {

            int NumeroSolicitud = 0;

            var Sacarnumero = ObjData.SacarUltimoNumeroSolicitudGenrado(CodigoBeneficiario);
            foreach (var n in Sacarnumero) {
                NumeroSolicitud = Convert.ToInt32(n.NumeroSolicitud);
            }
            return NumeroSolicitud;
        }
    }
}
