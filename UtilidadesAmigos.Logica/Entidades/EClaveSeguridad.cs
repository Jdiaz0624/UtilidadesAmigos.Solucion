using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EClaveSeguridad
    {
        public decimal? IdClaveSeguridad { get; set; }

        public decimal? IdUsuario { get; set; }

        public string Clave { get; set; }
    }
}
