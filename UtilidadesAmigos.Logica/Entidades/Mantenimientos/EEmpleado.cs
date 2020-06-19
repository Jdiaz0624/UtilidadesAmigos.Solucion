using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class EEmpleado
    {
        public decimal? IdSucursal {get;set;}

        public string Sucursal {get;set;}

        public decimal? IdOfiicna {get;set;}

        public string Oficina {get;set;}

        public decimal? IdDepartamento {get;set;}

        public string Departamento {get;set;}

        public decimal? IdEmpleado {get;set;}

        public string Nombre {get;set;}

        public System.Nullable<bool> Estatus0 {get;set;}

        public string Estatus {get;set;}

        public System.Nullable<decimal> UsuarioAdiciona {get;set;}

        public string CreadoPor {get;set;}

        public System.Nullable<System.DateTime> FechaAdiciona {get;set;}

        public string FechaCreado {get;set;}

        public System.Nullable<decimal> UsuarioModifica {get;set;}

        public string ModificadoPor {get;set;}

        public System.Nullable<System.DateTime> FechaModifica {get;set;}

        public string FechaModificado {get;set;}

        public System.Nullable<int> CantidadRegistros {get;set;}
    }
}
