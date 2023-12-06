using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EBuscaAntiguedadSaldoPolizasEmitidasProcesoAnterior
    {
        public string Poliza {get;set;}

        public string Origen {get;set;}

        public string EstatusSistema {get;set;}

        public int CodigoRamo {get;set;}

        public string Ramo {get;set;}

        public int CodigoSubRamo {get;set;}

        public string Subramo {get;set;}

        public int Item {get;set;}

        public string InicioVigencia {get;set;}

        public string FinVigencia {get;set;}

        public System.Nullable<decimal> MontoNeto {get;set;}

        public int CodigoSupervisor {get;set;}

        public string Supervisor {get;set;}

        public System.Nullable<int> CodigoIntermediario {get;set;}

        public string Intermediario {get;set;}

        public System.Nullable<decimal> CodigoCliente {get;set;}

        public string Cliente {get;set;}

        public string NumeroIdentificacionCliente {get;set;}

        public string TelefonoOficinaCliente {get;set;}

        public string TelefonoResidenciaCliente {get;set;}

        public string CelularCliente {get;set;}

        public string FaxCliente {get;set;}

        public System.Nullable<decimal> Facturado {get;set;}

        public System.Nullable<decimal> Balance {get;set;}

        public System.Nullable<int> CantidadDias {get;set;}

        public System.Nullable<decimal> ValorPorDia {get;set;}

        public string UltimaFechaPago {get;set;}

        public System.Nullable<decimal> MontoUltimoPago {get;set;}

        public System.Nullable<decimal> A_0_30 {get;set;}

        public System.Nullable<decimal> A_31_60 {get;set;}

        public System.Nullable<decimal> A_61_90 {get;set;}

        public System.Nullable<decimal> A_91_120 {get;set;}

        public System.Nullable<decimal> A_121_150 {get;set;}

        public System.Nullable<decimal> A_151_MAS {get;set;}
    }
}
