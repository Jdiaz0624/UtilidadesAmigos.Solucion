using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes
{
    public class SacarNombreUsuario
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSistema Objdata = new Logica.LogicaSistema();

        private decimal IdUsuario { get; set; }

        public SacarNombreUsuario(decimal IdUsuarioCON) {
            IdUsuario = IdUsuarioCON;
        }

        public string SacarNombreUsuarioConectado() {
            string NombreUsuario = "";
            var Buscar = Objdata.BuscaUsuarios(IdUsuario);
            foreach (var n in Buscar) {
                NombreUsuario = n.Persona;
            }
            return NombreUsuario;
        }

        public string SacarCorreoUsuario()
        {
            string Correo = "";
            var Buscar = Objdata.BuscaUsuarios(IdUsuario);
            foreach (var n in Buscar)
            {
                Correo = n.Email;
            }
            return Correo;
        }

        public int SacarPerfilUsuarioConectado()
        {
            int Perfil = 0;
            var Buscar = Objdata.BuscaUsuarios(IdUsuario);
            foreach (var n in Buscar)
            {
                Perfil =(int)n.IdPerfil;
            }
            return Perfil;
        }


    }
}
