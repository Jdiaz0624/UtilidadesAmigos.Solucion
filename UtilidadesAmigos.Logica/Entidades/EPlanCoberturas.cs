using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EPlanCoberturas
    {
        public System.Nullable<decimal> IdPlanCobertura { get; set; }

        public System.Nullable<decimal> IdCobertura { get; set; }

        public string Cobertura { get; set; }

        public System.Nullable<decimal> CodigoCobertura { get; set; }

        public string planCobertura { get; set; }
        
        public System.Nullable<bool> Estatus0 { get; set; }

        public string Estatus { get; set; }
    }
}
