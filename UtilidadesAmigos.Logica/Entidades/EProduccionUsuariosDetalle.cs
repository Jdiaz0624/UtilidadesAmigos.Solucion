using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EProduccionUsuariosDetalle
    {
        public string Sucursal { get; set; }

        public string Oficina { get; set; }

        public string Departamento { get; set; }

        public string Usuario { get; set; }

        public string Concepto { get; set; }

        public string Poliza { get; set; }

        public System.Nullable<decimal> Monto { get; set; }

        public System.Nullable<int> TotalRegistros { get; set; }

        public System.Nullable<decimal> TotalValor { get; set; }
    }
}
