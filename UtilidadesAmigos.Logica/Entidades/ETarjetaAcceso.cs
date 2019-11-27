using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class ETarjetaAcceso
    {
        public System.Nullable<decimal> IdOficina { get; set; }

        public string Oficina { get; set; }

        public System.Nullable<decimal> IdDepartamento { get; set; }

        public string Departamento { get; set; }

        public System.Nullable<decimal> IdEmpleado { get; set; }

        public string Empleado { get; set; }

        public decimal? IdTarjetaAcceso { get; set; }

        public string SecuenciaInterna { get; set; }

        public string NumeroTarjeta { get; set; }

        public System.Nullable<System.DateTime> FechaEntrega0 { get; set; }

        public string FechaEntrega { get; set; }

        public System.Nullable<decimal> Estatus0 { get; set; }

        public string Estatus { get; set; }

        public System.Nullable<decimal> UsuarioAdiciona { get; set; }

        public string Creadopor { get; set; }

        public System.Nullable<System.DateTime> FechaAdiciona0 { get; set; }

        public string FechaAdiciona { get; set; }

        public System.Nullable<decimal> UsuarioModicia { get; set; }

        public string ModificadoPor { get; set; }

        public System.Nullable<System.DateTime> FechaModifica0 { get; set; }

        public string FechaModifica { get; set; }
    }
}
