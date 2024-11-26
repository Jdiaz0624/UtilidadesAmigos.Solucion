using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EProcesarInformacionSeguimientoCarnet
    {
        public System.Nullable<decimal> IdRegistro { get; set; }

        public System.Nullable<decimal> NumeroVisita { get; set; }

        public System.Nullable<System.DateTime> FechaEntrada { get; set; }

        public System.Nullable<System.DateTime> FechaSalida { get; set; }

        public System.Nullable<int> IdCarnet { get; set; }

        public System.Nullable<bool> Estatus { get; set; }
    }
}
