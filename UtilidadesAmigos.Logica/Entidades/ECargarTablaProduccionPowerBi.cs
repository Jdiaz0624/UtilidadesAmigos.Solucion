using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class ECargarTablaProduccionPowerBi
    {
        public string Supervisor { get; set; }

        public string Intermediario { get; set; }

        public string Mes { get; set; }

        public string Ano { get; set; }

        public System.Nullable<decimal> Facturado { get; set; }

        public System.Nullable<decimal> FacturadoNeto { get; set; }

        public System.Nullable<decimal> Cobrado { get; set; }

        public System.Nullable<decimal> CobradoNeto { get; set; }

        public string Poliza { get; set; }

        public string Ramo { get; set; }

        public System.Nullable<decimal> Prima { get; set; }

        public System.Nullable<decimal> ValorAsegurado { get; set; }

        public string Fianza { get; set; }

        public System.Nullable<decimal> ValorVehiculo { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Año { get; set; }
    }
}
