using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Transito
{
    public class EPolizasConPagosPendientes
    {
        public string Poliza {get;set;}

        public string FechaProceso {get;set;}

        public int CodigoRamo {get;set;}

        public string Ramo {get;set;}

        public int CodigoSubRamo {get;set;}

        public string SubRamo {get;set;}

        public string Estatus {get;set;}

        public int CodigoOficina {get;set;}

        public string Oficina {get;set;}

        public System.Nullable<int> CodMoneda {get;set;}

        public string Moneda {get;set;}

        public System.Nullable<decimal> Tasa {get;set;}

        public System.Nullable<decimal> Cliente {get;set;}

        public string NombreCliente {get;set;}

        public string TelefonoOficina {get;set;}

        public string TelefonoResidencia {get;set;}

        public string Celular {get;set;}

        public System.Nullable<int> CodigoIntermediario {get;set;}

        public string Intermediario {get;set;}

        public int CodigoSupervisor {get;set;}

        public string NombreSupervisor {get;set;}

        public string IncioVigencia {get;set;}

        public string FinVigencia {get;set;}

        public System.Nullable<decimal> ValorPoliza {get;set;}

        public System.Nullable<decimal> Facturado {get;set;}

        public System.Nullable<decimal> Cobrado {get;set;}

        public System.Nullable<decimal> MontoPendiente {get;set;}

        public System.Nullable<decimal> IdPerfil {get;set;}

        public string Perfl {get;set;}

        public string ValidadoDesde {get;set;}

        public string ValidadoHasta {get;set;}

        public string GeneradoPor {get;set;}
    }
}
