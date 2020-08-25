using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EGRACY
    {
        public System.Nullable<decimal> Numero { get; set; }

        public string Cedula { get; set; }

        public string NotasCredito { get; set; }

        public string FechaComprobante { get; set; }

        public string NCfAfectado { get; set; }

        public string Fecha_NCf_Afectado { get; set; }

        public decimal? Valor { get; set; }
    }
}
