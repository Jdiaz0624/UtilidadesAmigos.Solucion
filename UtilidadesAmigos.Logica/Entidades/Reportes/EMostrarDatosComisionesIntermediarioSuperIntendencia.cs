using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EMostrarDatosComisionesIntermediarioSuperIntendencia
    {
        public System.Nullable<int> CodigoIntermediario { get; set; }

        public string Intermediario { get; set; }

        public string RNC_Cedula { get; set; }

        public string NoPoliza { get; set; }

        public System.Nullable<decimal> Comision { get; set; }

        public System.Nullable<decimal> Retencion { get; set; }

        public System.Nullable<decimal> AvanceComision { get; set; }

        public System.Nullable<decimal> ComisionPagada { get; set; }

        public System.Nullable<decimal> NumeroRecibo { get; set; }

        public string FechaPago { get; set; }

        public System.Nullable<int> Ramo { get; set; }

        public string TipoCuentaBanco { get; set; }
        public string FormaPago { get; set; }

        public string Licencia { get; set; }
    }
}
