using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EListadoRenovacion
    {
        public string Poliza {get;set;}

        public decimal Cotizacion {get;set;}

        public string Estatus {get;set;}

        public System.Nullable<decimal> Prima {get;set;}

        public System.Nullable<decimal> SumaAsegurada {get;set;}

        public int CodRamo {get;set;}

        public int CodSubramo {get;set;}

        public string Ramo {get;set;}

        public string SubRamo {get;set;}

        public string Asegurado {get;set;}

        public string Telefonos {get;set;}

        public System.Nullable<int> Items {get;set;}

        public System.Nullable<System.DateTime> FechaInicioVigencia0 {get;set;}

        public System.Nullable<System.DateTime> FechaFinVigencia0 {get;set;}

        public string FechaInicioVigencia {get;set;}

        public string FechaFinVigencia {get;set;}

        public string Supervisor {get;set;}

        public string Intermediario {get;set;}

        public int CodSupervisor {get;set;}

        public int CodIntermediario {get;set;}

        public string TipoVehiculo {get;set;}

        public string Marca {get;set;}

        public string Modelo {get;set;}

        public string Capacidad {get;set;}

        public string Ano {get;set;}

        public string Color {get;set;}

        public string Chasis {get;set;}

        public string Placa {get;set;}

        public string Uso {get;set;}

        public System.Nullable<decimal> ValorVehiculo {get;set;}

        public string NombreAsegurado {get;set;}

        public string Fianza {get;set;}

        public string Oficina {get;set;}

        public System.Nullable<decimal> Facturado {get;set;}

        public System.Nullable<decimal> Cobrado {get;set;}

        public System.Nullable<decimal> Balance {get;set;}
        public string FechaDesde { get; set; }

        public string FechaHasta { get; set; }
        public System.Nullable<int> Dias { get; set; }

        public System.Nullable<int> Mes { get; set; }

        public System.Nullable<int> Anos { get; set; }
    }
}
