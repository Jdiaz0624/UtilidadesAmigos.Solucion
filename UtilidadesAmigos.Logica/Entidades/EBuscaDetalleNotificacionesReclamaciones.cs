using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EBuscaDetalleNotificacionesReclamaciones
    {
        public decimal Reclamacion {get;set;}

        public System.Nullable<int> Estatus {get;set;}

        public string NombreEstatus { get; set; }

        public System.Nullable<decimal> MontoReclamado {get;set;}

        public System.Nullable<decimal> MontoAjustado {get;set;}

        public System.Nullable<decimal> MontoReserva {get;set;}

        public System.Nullable<decimal> MontoSalvamento {get;set;}

        public System.Nullable<System.DateTime> FechaApertura0 {get;set;}

        public string FechaApertura {get;set;}

        public string HoraApertura {get;set;}

        public System.Nullable<System.DateTime> FechaSiniestro0 {get;set;}

        public string FechaSiniestro {get;set;}

        public string HoraSiniestro {get;set;}

        public string Poliza {get;set;}

        public string CLiente {get;set;}

        public string Supervisor {get;set;}

        public string Intermediario {get;set;}

        public System.Nullable<decimal> MontoPrima {get;set;}

        public System.Nullable<decimal> MontoAsegurado {get;set;}

        public string Comentario {get;set;}

        public string IniciodeVigencia {get;set;}

        public string FindeVigencia {get;set;}

        public string CreadaPor {get;set;}

        public string FechaCreada {get;set;}

        public string ModificadoPor {get;set;}

        public string Fecha_Modificada {get;set;}
    }
}
