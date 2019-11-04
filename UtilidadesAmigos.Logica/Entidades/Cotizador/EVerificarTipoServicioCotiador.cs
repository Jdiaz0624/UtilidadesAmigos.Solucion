using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Cotizador
{
    public class EVerificarTipoServicioCotiador
    {
        public decimal? IdTipoCotizador { get; set; }

        public string TipoCotizador { get; set; }

        public decimal? IdServicio { get; set; }

        public string Servicio { get; set; }

        public System.Nullable<bool> TieneServicio0 { get; set; }

        public string TieneServicio { get; set; }
    }
}
