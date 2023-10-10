using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Correcciones
{
    public class EBuscaInformacionPolizaEquiposElectronicos
    {
        public string Poliza {get;set;}

        public decimal Cotizacion {get;set;}

        public int Item {get;set;}

        public System.Nullable<decimal> Cliente {get;set;}

        public string NombreCliente {get;set;}

        public System.Nullable<int> Intermediario {get;set;}

        public string NombreIntermediario { get;set;}

        public int CodigoSupervisor {get;set;}

        public string Supervisor {get;set;}
        public System.Nullable<int> CantidadEquipos { get; set; }

        public System.Nullable<int> CantidadEquiposTotal { get; set; }
    }
}
