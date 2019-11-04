using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class ECargarTablaReclamacionPowerBi
    {
        public string Supervisor { get; set; }

        public string intermediario { get; set; }

        public string Mes { get; set; }

        public string Ano { get; set; }

        public string Poliza { get; set; }

        public decimal Reclamacion { get; set; }

        public System.Nullable<decimal> MontoReclamado { get; set; }

        public System.Nullable<decimal> MontoAjustado { get; set; }

        public string Estatus { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Año { get; set; }
    }
}
