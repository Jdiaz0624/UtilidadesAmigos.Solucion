using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class ESacarCobrado
    {
        public decimal? IdOficina { get; set; }

        public string Oficina { get; set; }

        public decimal? IdDepartamento { get; set; }

        public string Departamento { get; set; }

        public decimal? IdEmpleado { get; set; }

        public string Usuario { get; set; }

        public string Concepto { get; set; }

        public System.Nullable<int> Cantidad { get; set; }
    }
}
