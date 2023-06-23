using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Suministro
{
    public class EListadoSolicitudesHeader
    {

        public decimal? NumeroSolicitud {get;set;}

        public string NumeroConector {get;set;}

        public System.Nullable<decimal> IdUsuario {get;set;}

        public string Persona {get;set;}

        public System.Nullable<decimal> IdSucursal {get;set;}

        public string Sucursal {get;set;}

        public System.Nullable<decimal> IdOficina {get;set;}

        public string Oficina {get;set;}

        public System.Nullable<decimal> IdDepartamento {get;set;}

        public string Departamento {get;set;}

        public System.Nullable<System.DateTime> FechaSolicitud0 {get;set;}

        public string Fecha {get;set;}

        public string Hora {get;set;}

        public System.Nullable<int> EstatusSolicitud { get; set; }

        public string Estatus {get;set;}

        public System.Nullable<int> CantidadItems {get;set;}

        public System.Nullable<int> CantidadSolicitudes { get; set; }

        public System.Nullable<int> CantidadSolicitudes_Activas { get; set; }

        public System.Nullable<int> CantidadSolicitudes_Procesadas { get; set; }

        public System.Nullable<int> CantidadSolicitudes_Canceladas { get; set; }

        public System.Nullable<int> CantidadSolicitudes_Rechazadas { get; set; }
        public System.Nullable<int> CantidadSolicitudes_Pendientes { get; set; }
    }
}
