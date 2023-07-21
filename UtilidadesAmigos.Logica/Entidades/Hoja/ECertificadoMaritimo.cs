using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Hoja
{
    public class ECertificadoMaritimo
    {
        public System.Nullable<System.DateTime> FechaAdiciona {get;set;}

        public string FechaEmision {get;set;}

        public string Asegurado {get;set;}

        public string Poliza {get;set;}

        public string DescripciónMercancía {get;set;}

        public string MedioTransporte {get;set;}

        public System.Nullable<System.DateTime> FechaInicioVigencia {get;set;}

        public System.Nullable<System.DateTime> FechaFinVigencia {get;set;}

        public string InicioVigencia {get;set;}

        public string FinVigencia {get;set;}

        public string FechaSalida {get;set;}

        public string FechaAproximadaLlegada {get;set;}

        public System.Nullable<decimal> ValorMercancíaFOB {get;set;}

        public System.Nullable<decimal> ValorAseguradoCF {get;set;}

        public System.Nullable<decimal> PrimaSeguro {get;set;}

        public string PuertoDesembarque {get;set;}

        public string PaísProcedencia {get;set;}

        public string PuertoEmbarque {get;set;}
    }
}
