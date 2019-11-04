using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EBuscarEmpleados
    {
        public decimal IdEmpleado { get; set; }

        public System.Nullable<decimal> IdDepartamento { get; set; }

        public string Departamento { get; set; }

        public string Nombre { get; set; }

        public string Oficina { get; set; }

        public System.Nullable<int> IdOficinaPertenece { get; set; }
    }
}
