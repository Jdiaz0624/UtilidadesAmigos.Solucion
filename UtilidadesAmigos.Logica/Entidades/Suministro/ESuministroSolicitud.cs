using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Suministro
{
    public class ESuministroSolicitud
    {
        public decimal? NumeroSolicitud {get;set;}

        public System.Nullable<int> IdSucursal {get;set;}

        public string Sucursal {get;set;}

        public System.Nullable<int> IdOficina {get;set;}

        public string Oficina {get;set;}

        public System.Nullable<int> IdDepartamento {get;set;}

        public string Departamento {get;set;}

        public System.Nullable<decimal> IdUsuario {get;set;}

        public string Usuario {get;set;}

        public System.Nullable<decimal> CodigoArticulo {get;set;}

        public string DescripcionArticulo {get;set;}

        public System.Nullable<int> IdCategoria {get;set;}

        public string Categoria {get;set;}

        public System.Nullable<int> IdUnidadMedida {get;set;}

        public string UnidadMedida {get;set;}

        public System.Nullable<int> Cantidad {get;set;}

        public System.Nullable<System.DateTime> Fecha0 {get;set;}

        public string Fecha {get;set;}

        public string Hora {get;set;}

        public System.Nullable<int> IdEstatusSolicitud {get;set;}

        public string Estatus {get;set;}

        public string GeneradoPor {get;set;}

        public System.Nullable<int> CantidadSolicitudes {get;set;}

        public System.Nullable<int> SolicitudesActivas {get;set;}

        public System.Nullable<int> SolicitudesProcesadas {get;set;}

        public System.Nullable<int> SolicitudesCanceladas {get;set;}

        public System.Nullable<int> SolicitudesRechazadas {get;set;}
    }
}
