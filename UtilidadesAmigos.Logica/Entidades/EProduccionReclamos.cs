using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EProduccionReclamos
    {
        public string Oficina { get; set; }

        public string Departamento { get; set; }

        public string Usuario { get; set; }

        public string Concepto { get; set; }

        public decimal? IdOficina { get; set; }

        public decimal? IdDepartamento { get; set; }

        public decimal? IdUsuario { get; set; }

        public System.Nullable<int> Cantidad { get; set; }
    }
}
