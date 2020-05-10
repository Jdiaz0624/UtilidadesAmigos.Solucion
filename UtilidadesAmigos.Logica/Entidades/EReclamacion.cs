using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EReclamacion
    {
        public System.Nullable<decimal> Numero { get; set; }

        public System.Nullable<decimal> Reclamacion { get; set; }

        public string Poliza { get; set; }

        public string Estatus { get; set; }

        public System.Nullable<decimal> Intermediario { get; set; }

        public string NombreIntermediario { get; set; }

        public string Asegurado { get; set; }

        public System.Nullable<decimal> IdCondicion { get; set; }

        public string Condicion { get; set; }

        public System.Nullable<decimal> Monto { get; set; }

        public string Beneficiario { get; set; }

        public System.Nullable<decimal> IdTipo { get; set; }

        public string TipoReclamacion { get; set; }

        public System.Nullable<System.DateTime> InicioVigencia0 { get; set; }

        public string InicioVigencia { get; set; }

        public System.Nullable<System.DateTime> FinVigencia0 { get; set; }
    
        public string FinVigencia { get; set; }

        public System.Nullable<System.DateTime> FechaApertura0 { get; set; }

        public string FechaApertura { get; set; }

        public System.Nullable<System.DateTime> FechaSiniestro0 { get; set; }

        public string FechaSiniestro { get; set; }

        public System.Nullable<System.DateTime> FechaFactura0 { get; set; }

        public string FechaFactura { get; set; }

        public System.Nullable<System.DateTime> FechaCreacion0 { get; set; }

        public string FechaCreacion { get; set; }

        public System.Nullable<decimal> IdEstatus { get; set; }

        public string EstatusReclamacion { get; set; }

        public System.Nullable<decimal> IdUsuario { get; set; }

        public string Usuario { get; set; }

        public string Comentario { get; set; }

        public System.Nullable<int> CantidadRegistros { get; set; }
    }
}
