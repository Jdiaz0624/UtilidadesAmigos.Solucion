using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class ESacarDescripcionProducto
    {
        public decimal? IdProductoSubramo { get; set; }

        public System.Nullable<int> TipoProducto { get; set; }

        public System.Nullable<int> CodigoSubramo { get; set; }

        public string DescripcionSubramo { get; set; }

        public string Descripcion { get; set; }

        public System.Nullable<bool> Estatus { get; set; }
    }
}
