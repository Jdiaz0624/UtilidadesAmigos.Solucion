using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Gerencia
{
    public class EReporteAntiguedadPorAtrasoPolizasEspeciales
    {
        public string Poliza {get;set;}

        public string Fecha_Facturacion {get;set;}

        public string Inicio_Vigencia {get;set;}

        public string Fin_Vigencia {get;set;}

        public string Fecha_Ultimo_Pago {get;set;}

        public string Supervisor {get;set;}

        public string Intermediario {get;set;}

        public string Cliente {get;set;}

        public string Concepto {get;set;}

        public System.Nullable<decimal> Valor_Poliza {get;set;}

        public decimal Total_Pagado {get;set;}

        public System.Nullable<decimal> Balance_Pendiente {get;set;}

        public int Ramo {get;set;}

        public string NombreRamo {get;set;}

        public int SubRamo {get;set;}

        public string NombreSubRamo {get;set;}

        public string Estatus {get;set;}

        public System.Nullable<decimal> Balance_En_Atraso {get;set;}

        public System.Nullable<decimal> Inicial {get;set;}

        public System.Nullable<decimal> Cuota {get;set;}

        public System.Nullable<decimal> Pago_0_10 {get;set;}

        public System.Nullable<decimal> Pago_0_30 {get;set;}

        public System.Nullable<decimal> Pago_31_60 {get;set;}

        public System.Nullable<decimal> Pago_61_90 {get;set;}

        public System.Nullable<decimal> Pago_91_120 {get;set;}

        public System.Nullable<decimal> Pago_121_Mas {get;set;}

        public System.Nullable<int> DiasTranscurridos {get;set;}

        public decimal Atraso_0_30 {get;set;}

        public decimal Atraso_31_60 {get;set;}

        public decimal Atraso_61_90 {get;set;}

        public decimal Atraso_91_120 {get;set;}

        public System.Nullable<decimal> Atraso_Mas_120_Dias {get;set;}
    }
}
