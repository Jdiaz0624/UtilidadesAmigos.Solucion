using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class ESacarDatosDatosPoliza
    {
        public string Poliza { get; set; }

        public string Estatus { get; set; }
        public decimal Cotizacion { get; set; }

        public int Item { get; set; }
        public int CodRamo { get; set; }

        public string Ramo { get; set; }

        public string SubRamo { get; set; }

        public string Tipo { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Capacidad { get; set; }

        public string Ano { get; set; }

        public string Color { get; set; }

        public string Chasis { get; set; }

        public string Placa { get; set; }

        public string Uso { get; set; }

        public System.Nullable<decimal> Valor { get; set; }

        public string Fianza { get; set; }

        public string Asegurado { get; set; }

        public string Cliente { get; set; }

        public string InicioVigencia { get; set; }

        public string FinVigencia { get; set; }

        public string Supervisor { get; set; }
    
        public string Intermediario { get; set; }
        public System.Nullable<decimal> Neto { get; set; }
    }
}
