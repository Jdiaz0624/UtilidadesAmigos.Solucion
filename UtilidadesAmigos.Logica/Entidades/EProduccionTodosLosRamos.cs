using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EProduccionTodosLosRamos
    {
        public System.Nullable<decimal> IdUsuario { get; set; }

        public string Persona { get; set; }

        public System.Nullable<decimal> IdDepartamento { get; set; }

        public string Departamento { get; set; }

        public System.Nullable<decimal> IdPerfil { get; set; }

        public string Perfl { get; set; }

        public string Ramo { get; set; }

        public string Concepto { get; set; }

        public System.Nullable<int> Total { get; set; }

        public System.Nullable<decimal> FacturadoEnPesos { get; set; }

        public System.Nullable<decimal> FacturadoEnDollar { get; set; }

        public System.Nullable<decimal> FacturadoTotal { get; set; }

        public System.Nullable<decimal> FacturadoNeto { get; set; }

        public string ValidadoDesde { get; set; }

        public string ValidadoHasta { get; set; }
    }
}
