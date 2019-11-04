using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class ETarjetaAccesoMantenimiento
    {
        public string Notarjeta {get;set;}

        public System.Nullable<decimal> NoUsuaerioEntero {get;set;}

        public string NoUsuario {get;set;}

        public System.Nullable<decimal> IdDepartamento {get;set;}

        public System.Nullable<decimal> IdOficina {get;set;}

        public System.Nullable<decimal> Idusuario {get;set;}

        public System.Nullable<System.DateTime> FechaEntrega {get;set;}

        public System.Nullable<decimal> IdEstatustarjeta {get;set;}

        public System.Nullable<bool> Entregada {get;set;}

        public string Comentario {get;set;}

        public System.Nullable<decimal> UsuarioAdiciona {get;set;}

        public System.Nullable<System.DateTime> FechaAdiciona {get;set;}

        public System.Nullable<decimal> UsuarioModifica {get;set;}

        public System.Nullable<System.DateTime> FechaModifica {get;set;}
    }
}
