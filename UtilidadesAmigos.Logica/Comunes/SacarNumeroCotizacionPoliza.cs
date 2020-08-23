using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes
{
    public static class SacarNumeroCotizacionPoliza
    {
        public static readonly Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Data = new Lazy<Logica.LogicaSistema>();

        public static decimal SacarNumeroCotiacion( string Poliza) {

            decimal Dato = 0;

            var SacarNumero = Data.Value.SacarNumeroCotizacion(Poliza);
            foreach (var n in SacarNumero) {
                Dato = Convert.ToDecimal(n.Cotizacion);
            }
            return Dato;
        }
    }
}
