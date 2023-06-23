using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Suministro
{
    public class EBuscaDetallesSolicitud
    {
        public decimal? SecuenciaDetalle {get;set;}

        public string NumeroConector {get;set;}

        public System.Nullable<decimal> CodigoArticulo {get;set;}

        public string Descripcion {get;set;}

        public System.Nullable<int> IdMedida {get;set;}

        public string UnidadMedida {get;set;}

        public System.Nullable<int> Cantidad {get;set;}

        public System.Nullable<int> IdSucursal {get;set;}

        public System.Nullable<int> IdOficina {get;set;}

        public System.Nullable<int> IdCategoria {get;set;}

        public string Categoria {get;set;}

        public System.Nullable<int> StockMinimo {get;set;}
        public System.Nullable<int> Disponible { get; set; }
        public string Estatus { get; set; }
        public System.Nullable<bool> Despachado0 { get; set; }

        public string Despachado { get; set; }
    }
}
