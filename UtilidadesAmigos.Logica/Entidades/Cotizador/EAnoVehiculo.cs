using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Cotizador
{
    public class EAnoVehiculo
    {
        public System.Nullable<decimal> IdTipoCotizador { get; set; }

        public string TipoCotizador { get; set; }

        public System.Nullable<decimal> IdValorVehiculo { get; set; }

        public string ValorVehiculo { get; set; }

        public decimal? IdAnoVehiculo { get; set; }

        public string AnoVehiculo { get; set; }

        public System.Nullable<bool> Estatus0 { get; set; }

        public string Estatus { get; set; }
    }
}
