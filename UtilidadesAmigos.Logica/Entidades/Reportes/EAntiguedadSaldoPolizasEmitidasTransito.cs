using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EAntiguedadSaldoPolizasEmitidasTransito
    {
        public string Poliza {get;set;}

        public string ConceptoMov {get;set;}

        public string Origen {get;set;}

        public string Estatus {get;set;}

        public int CodigoRamo {get;set;}

        public string Ramo {get;set;}

        public int CodigoSubramo {get;set;}

        public string SubRamo {get;set;}

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

        public System.Nullable<decimal> MontoMov {get;set;}
    }
}
