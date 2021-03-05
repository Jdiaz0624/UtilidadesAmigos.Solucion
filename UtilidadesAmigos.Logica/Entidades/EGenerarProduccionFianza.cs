using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EGenerarProduccionFianza
    {
        public string NoFactura {get;set;}

        public string Poliza {get;set;}

        public string Estatus {get;set;}

        public string NoFormulario {get;set;}

        public int? CodRamo {get;set;}

        public int? CodSubramo {get;set;}

        public string Ramo {get;set;}

        public string SubRamo {get;set;}

        public string Cliente {get;set;}
        public string Deudor { get; set; }

        public string TelefonoResidencia {get;set;}

        public string TelefonoOficina {get;set;}

        public string Celular {get;set;}

        public string fax {get;set;}

        public string Otro {get;set;}

        public string Direccion {get;set;}

        public string UbicacionCliente {get;set;}

        public string ProvinciaCliente {get;set;}

        public string MunicipioCliente {get;set;}

        public string SectorCliente {get;set;}

        public string Supervisor {get;set;}

        public string Intermediario {get;set;}

        public string UbicacionIntermediario {get;set;}

        public string ProvinciaIntermediario {get;set;}

        public string MunicipioIntermediario {get;set;}

        public string SectorIntermediario {get;set;}

        public System.Nullable<System.DateTime> Fecha {get;set;}

        public string FechaFacturacion {get;set;}

        public string InicioVigencia {get;set;}

        public string FinVigencia {get;set;}

        public System.Nullable<decimal> SumaAsegurada {get;set;}

        public System.Nullable<decimal> Neto {get;set;}

        public System.Nullable<decimal> Tasa {get;set;}

        public System.Nullable<decimal> Impuesto {get;set;}

        public System.Nullable<decimal> PorcComision {get;set;}

        public System.Nullable<decimal> Facturado {get;set;}

        public System.Nullable<decimal> Cobrado {get;set;}

        public System.Nullable<decimal> Balance {get;set;}

        public string LeyInfraccionImputado {get;set;}

        public System.Nullable<int> Cantidad {get;set;}
    }
}
