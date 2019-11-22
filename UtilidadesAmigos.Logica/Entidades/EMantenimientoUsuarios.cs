using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EMantenimientoUsuarios
    {
        public System.Nullable<decimal> IdUsuario {get;set;}

        public System.Nullable<decimal> IdDepartamento {get;set;}

        public System.Nullable<decimal> IdPerfil {get;set;}

        public string Usuario {get;set;}

        public string Clave {get;set;}

        public string Persona {get;set;}

        public System.Nullable<bool> Estatus {get;set;}

        public System.Nullable<bool> LlevaEmail {get;set;}

        public string Email {get;set;}

        public System.Nullable<int> Contador {get;set;}

        public System.Nullable<bool> CambiaClave {get;set;}

        public string RazonBloqueo {get;set;}

        public System.Nullable<decimal> IdTipoPersona {get;set;}
    }
}
