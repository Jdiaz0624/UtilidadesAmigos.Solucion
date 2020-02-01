using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class ESacarProduccionContabilidad
    {
        public string Intermediario { get; set; }

        public int? Codigo { get; set; }

        public int? Ramo { get; set; }

        public string Descripcion { get; set; }

        public int? Tipo { get; set; }

        public string DescripcionTipo { get; set; }

        public int? CodOficina { get; set; }

        public string Oficina { get; set; }

        public string Concepto { get; set; }

        public System.Nullable<decimal> FacturadoMes { get; set; }

        public System.Nullable<decimal> Total { get; set; }

        public System.Nullable<decimal> MesAnterior { get; set; }

        public System.Nullable<decimal> Hoy { get; set; }

        public System.Nullable<decimal> TotalCredito { get; set; }

        public System.Nullable<decimal> TotalDebito { get; set; }

        public System.Nullable<decimal> TotalOtros { get; set; }
    }
}
