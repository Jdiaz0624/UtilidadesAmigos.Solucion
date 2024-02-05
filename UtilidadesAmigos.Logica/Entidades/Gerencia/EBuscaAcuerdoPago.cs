using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Gerencia
{
    public class EBuscaAcuerdoPago
    {
        public string Poliza {get;set;}

        public System.Nullable<decimal> ValorPoliza {get;set;}

        public string Concepto {get;set;}

        public string FechaFacturacion {get;set;}

        public string TipoAcuerdo {get;set;}

        public string Frecuencia {get;set;}

        public System.Nullable<int> Supervisor {get;set;}

        public System.Nullable<int> Intermediario {get;set;}

        public string NombreSupervisor {get;set;}

        public string NombreIntermediario {get;set;}

        public string FrecuenciaPagos {get;set;}

        public System.Nullable<int> CantidadCuotas {get;set;}

        public System.Nullable<decimal> Inicial {get;set;}

        public System.Nullable<decimal> Cuota {get;set;}

        public string FechaC1 {get;set;}

        public System.Nullable<int> DiasC1 {get;set;}

        public System.Nullable<decimal> PagoC1 {get;set;}

        public string EstatusC1 {get;set;}

        public string FechaC2 {get;set;}

        public System.Nullable<int> DiasC2 {get;set;}

        public System.Nullable<decimal> PagoC2 {get;set;}

        public string EstatusC2 {get;set;}

        public string Fecha3 {get;set;}

        public System.Nullable<int> DiasC3 {get;set;}

        public System.Nullable<decimal> Pago3 {get;set;}

        public string EstatusC3 {get;set;}

        public string FechaC4 {get;set;}

        public System.Nullable<int> DiasC4 {get;set;}

        public System.Nullable<decimal> Pago4 {get;set;}

        public System.Nullable<int> DiasC5 {get;set;}

        public string FechaC5 {get;set;}

        public string EstatusC4 {get;set;}

        public System.Nullable<decimal> PagoC5 {get;set;}

        public string EstatusC5 {get;set;}

        public string FechaC6 {get;set;}

        public System.Nullable<int> DiasC6 {get;set;}

        public System.Nullable<decimal> PagoC6 {get;set;}

        public string EstatusC6 {get;set;}

        public System.Nullable<decimal> PagadoTotal {get;set;}

        public System.Nullable<decimal> Pendiente {get;set;}

        public string ValidadoDesde {get;set;}

        public string ValidadoHasta {get;set;}

        public string GeneradoPor {get;set;}
    }
}
