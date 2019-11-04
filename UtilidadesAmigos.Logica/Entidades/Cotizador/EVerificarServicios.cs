using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Cotizador
{
    public class EVerificarServicios
    {
        public decimal? IdTipoCotizador { get; set; }

        public string TipoCotizador { get; set; }

        public System.Nullable<bool> Estatus0 { get; set; }

        public string EstatusTipoCotizador { get; set; }

        public decimal IdServicio { get; set; }

        public string Servicio { get; set; }

        public System.Nullable<bool> Estatus00 { get; set; }

        public string EstatusServicios { get; set; }

        public System.Nullable<bool> TieneAcceso0 { get; set; }

        public string TieneAcceso { get; set; }
    }
}
