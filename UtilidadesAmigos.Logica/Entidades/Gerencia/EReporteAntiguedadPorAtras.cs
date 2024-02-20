using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Gerencia
{
    public class EReporteAntiguedadPorAtras
    {
        public string Poliza {get;set;}

        public int Codigo_Intermediario {get;set;}

        public string Intermediario {get;set;}

        public int Codigo_Supervisor {get;set;}

        public string Supervisor {get;set;}

        public decimal Codigo {get;set;}

        public string Cliente {get;set;}

        public string Direccion {get;set;}

        public string Telefonos {get;set;}

        public string Concepto {get;set;}

        public string Fecha_Facturacion {get;set;}

        public string Inicio_Vigencia {get;set;}

        public string Fin_Vigencia {get;set;}

        public string Fecha_Ultimo_Pago {get;set;}

        public System.Nullable<int> DiasTranscurridos {get;set;}

        public System.Nullable<int> Dias_Transcurridos_Pago {get;set;}

        public System.Nullable<decimal> Valor_Poliza {get;set;}

        public decimal Total_Pagado {get;set;}

        public decimal TotalDescuento { get; set; }

        public System.Nullable<decimal> Balance_Pendiente {get;set;}

        public int? Ramo {get;set;}

        public int? SubRamo {get;set;}

        public string NombreRamo {get;set;}

        public string NombreSubRamo { get; set; }

        public System.Nullable<decimal> Inicial {get;set;}

        public string Inicial_Pagado {get;set;}

        public System.Nullable<decimal> Cuota {get;set;}

        public string C1_Pagada {get;set;}

        public System.Nullable<decimal> C1 {get;set;}

        public string C2_Pagada {get;set;}

        public System.Nullable<decimal> C2 {get;set;}

        public string C3_Pagada {get;set;}

        public System.Nullable<decimal> C3 {get;set;}

        public string C4_Pagada {get;set;}

        public System.Nullable<decimal> C4 {get;set;}

        public string C5_Pagada {get;set;}

        public System.Nullable<decimal> C5 {get;set;}
    }
}
