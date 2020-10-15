using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes 
{
    public static class SacartasaMoneda 
    {
        static readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos ObjData = new Logica.LogicaMantenimientos.LogicaMantenimientos();

        public static decimal SacarTasaMoneda(int CodigoMoneda) {
            decimal TasaMoneda = 0;

            var SacarTasaMoneda = ObjData.SacartasaMoneda(CodigoMoneda);
            foreach (var n in SacarTasaMoneda) {
                TasaMoneda = (decimal)n.Prima;
            }

            return TasaMoneda;


        }
    }
}
