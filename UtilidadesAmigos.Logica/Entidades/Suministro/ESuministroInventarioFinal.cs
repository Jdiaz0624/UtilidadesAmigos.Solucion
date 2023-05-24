using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Suministro
{
    public class ESuministroInventarioFinal
    {
        public System.Nullable<decimal> IdRegistro {get;set;}

        public System.Nullable<int> IdSucursal {get;set;}

        public string Sucursal {get;set;}

        public System.Nullable<int> IdOficina {get;set;}

        public string Oficina {get;set;}

        public System.Nullable<int> IdCategoria {get;set;}

        public string Categoria {get;set;}

        public System.Nullable<int> IdUnidadMedida {get;set;}

        public string UnidadMedida {get;set;}

        public string Articulo {get;set;}

        public System.Nullable<int> Stock {get;set;}

        public System.Nullable<int> StockMinimo {get;set;}

        public System.Nullable<System.DateTime> FechaIngreso0 {get;set;}

        public string Fecha {get;set;}

        public string Hora {get;set;}

        public string GeneradoPor {get;set;}

        public System.Nullable<int> CantidadRegistros {get;set;}

        public System.Nullable<int> CantidadRegistrosAgotadosAgotados {get;set;}
    }
}
