using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class ESacarProduccionDiariaDetalle
    {
        public decimal? Numero {get;set;}

        public string Poliza {get;set;}

        public System.Nullable<decimal> Valor {get;set;}

        public string FechaFacturacion {get;set;}

        public System.Nullable<System.DateTime> Fecha {get;set;}

        public string Concepto {get;set;}

        public int CodRamo {get;set;}

        public string Ramo {get;set;}

        public int CodSubramo {get;set;}

        public string Subramo {get;set;}

        public string NombreCliente {get;set;}

        public string Telefonos {get;set;}

        public string Direccion {get;set;}

        public int CodSupervisor {get;set;}

        public string Supervisor {get;set;}

        public int CodIntermediario {get;set;}

        public string Vendedor {get;set;}

        public System.Nullable<decimal> Facturado {get;set;}

        public System.Nullable<decimal> Cobrado {get;set;}

        public System.Nullable<decimal> Balance {get;set;}

        public System.Nullable<int> CodOficina {get;set;}

        public string Oficina {get;set;}
    }
}
