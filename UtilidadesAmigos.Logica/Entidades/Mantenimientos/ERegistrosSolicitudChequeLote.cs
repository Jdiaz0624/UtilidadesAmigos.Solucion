using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class ERegistrosSolicitudChequeLote
    {
        public decimal? IdRegistro { get; set; }

        public System.Nullable<decimal> IdUsuairo { get; set; }

        public string CreadoPor { get; set; }

        public System.Nullable<int> CodigoIntermediario { get; set; }

        public string Intermediario { get; set; }

        public System.Nullable<decimal> NumeroSolicitud { get; set; }
        public System.Nullable<System.DateTime> FechaProceso0 { get; set; }

        public string FechaProceso { get; set; }

        public System.Nullable<System.DateTime> FechaDesde { get; set; }

        public string ValidadoDesde { get; set; }

        public System.Nullable<System.DateTime> FechaHasta { get; set; }

        public string ValidadoHasta { get; set; }

        public System.Nullable<decimal> MontoSolicitud { get; set; }

        public System.Nullable<bool> Estatus0 { get; set; }

        public string Estatus { get; set; }

        public System.Nullable<int> CantidadProcesados { get; set; }

        public System.Nullable<int> CantidadDescartados { get; set; }

        public System.Nullable<int> CantidadRegistros { get; set; }
    }
}
