using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EUsuarios
    {
        public decimal? IdUsuario {get;set;}

        public System.Nullable<decimal> IdDepartamento {get;set;}

        public string Departamento {get;set;}

        public System.Nullable<decimal> IdPerfil {get;set;}

        public string Perfil {get;set;}

        public string Usuario {get;set;}

        public string Clave {get;set;}

        public string Persona {get;set;}

        public System.Nullable<bool> Estatus0 {get;set;}

        public string Estatus {get;set;}

        public string LlevaEmail {get;set;}

        public System.Nullable<bool> LlevaEmail0 {get;set;}

        public string Email {get;set;}

        public System.Nullable<int> Contador {get;set;}

        public string CambiaClave {get;set;}

        public System.Nullable<bool> CambiaClave0 {get;set;}

        public string RazonBloqueo {get;set;}

        public decimal IdTipoPersona {get;set;}

        public string TipoPersona {get;set;}
    }
}
