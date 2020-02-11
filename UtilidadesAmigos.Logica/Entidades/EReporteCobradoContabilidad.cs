using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EReporteCobradoContabilidad
    {
        public string Intermediario { get; set; }

        public int? CodigoIntermediario { get; set; }

        public System.Nullable<int> CodRamo { get; set; }

        public string Ramo { get; set; }

        public System.Nullable<int> CodOficina { get; set; }

        public string Oficina { get; set; }

        public System.Nullable<decimal> Cobrado { get; set; }
        public System.Nullable<decimal> CobradoHoy { get; set; }

        public System.Nullable<decimal> CobradoSantoDomingo { get; set; }

        public System.Nullable<decimal> CobradoSantiago { get; set; }

        public System.Nullable<decimal> CobradoOtros { get; set; }

        public System.Nullable<decimal> Total { get; set; }

        public System.Nullable<decimal> CobradoMesAnterior { get; set; }
    }
}
