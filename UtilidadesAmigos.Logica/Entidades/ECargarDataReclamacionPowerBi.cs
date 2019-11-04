using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class ECargarDataReclamacionPowerBi
    {
        public string Supervisor { get; set; }

        public string Intermediario { get; set; }

        public string Mes { get; set; }

        public string Poliza { get; set; }

        public System.Nullable<decimal> Reclamacion { get; set; }

        public System.Nullable<decimal> MontoReclamado { get; set; }

        public System.Nullable<decimal> MontoAjustado { get; set; }

        public string Estatus { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Anovehiculo { get; set; }
    }
}
