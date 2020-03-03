using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class ESugerencias
    {
        public decimal? IdSugerencia { get; set; }

        public System.Nullable<decimal> IdUsuario { get; set; }

        public string Usuario { get; set; }

        public string Sugerencia { get; set; }

        public string Respuesta { get; set; }
    }
}
