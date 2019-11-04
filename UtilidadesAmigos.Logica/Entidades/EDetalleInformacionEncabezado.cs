using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EDetalleInformacionEncabezado
    {
        public string Poliza{get;set;}

        public decimal? Cotizacion{get;set;}

        public string InicioVigencia{get;set;}

        public string FinVigencia{get;set;}

        public string Cliente{get;set;}

        public string TipoIdentificacion{get;set;}

        public string Identificacion{get;set;}

        public string Direccion{get;set;}

        public string Ciudad{get;set;}

        public string TelefonoResidencia{get;set;}

        public string TelefonoOficina{get;set;}

        public string Celular{get;set;}

        public string Supervisor{get;set;}

        public string Intermdiario{get;set;}

        public System.Nullable<decimal> Facturado{get;set;}

        public System.Nullable<decimal> Cobrado{get;set;}

        public System.Nullable<decimal> Balance{get;set;}

        public int IdRamo{get;set;}

        public string Ramo{get;set;}

        public string Oficina{get;set;}
    }
}
