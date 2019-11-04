using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EMantenimientoProduccionTodosLosRamos
    {
        public System.Nullable<decimal> IdUsuario { get; set; }

        public System.Nullable<decimal> IdDepartamento { get; set; }

        public System.Nullable<decimal> IdPerfil { get; set; }

        public string Ramo { get; set; }

        public string Concepto { get; set; }

        public System.Nullable<int> Total { get; set; }

        public System.Nullable<decimal> FacturadoEnPesos { get; set; }

        public System.Nullable<decimal> FacturadoEnDollar { get; set; }

        public System.Nullable<decimal> FacturadoTotal { get; set; }

        public System.Nullable<decimal> FacturadoNeto { get; set; }

        public System.Nullable<System.DateTime> ValidadoDesde { get; set; }

        public System.Nullable<System.DateTime> ValidadoHasta { get; set; }
    }
}
