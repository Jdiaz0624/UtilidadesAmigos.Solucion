using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.ProcesoInformacion
{
    public class ProcesarInformacionUsuarios : UtilidadesAmigos.Logica.Logica.LogicaSistema
    {



        private decimal IdUsuario = 0;
        private decimal IdSucursal = 0;
        private decimal IdOficina = 0;
        private decimal IdDepartamento = 0;
        private decimal IdPerfil = 0;
        private string Usuario = "";
        private string Clave = "";
        private string Persona = "";
        private bool Estatus = false;
        private bool LlevaEmail = false;
        private string Email = "";
        private int Contador = 0;
        private bool CambiaClave = false;
        private string RazonBloqueo = "";
        private decimal IdTipoPersona = 0;
        private string Accion = "";

        public ProcesarInformacionUsuarios(
            decimal IdUsuarioCON,
            decimal IdSucursalCON,
            decimal IdOficinaCON,
            decimal IdDepartamentoCON,
            decimal IdPerfilCON,
            string UsuarioCON,
            string ClaveCON,
            string PersonaCON,
            bool EstatusCON,
            bool LlevaEmailCON,
            string EmailCON,
            int ContadorCON,
            bool CambiaClaveCON,
            string RazonBloqueoCON,
            decimal IdTipoPersonaCON,
            string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            IdSucursal = IdSucursalCON;
            IdOficina = IdOficinaCON;
            IdDepartamento = IdDepartamentoCON;
            IdPerfil = IdPerfilCON;
            Usuario = UsuarioCON;
            Clave = ClaveCON;
            Persona = PersonaCON;
            Estatus = EstatusCON;
            LlevaEmail = LlevaEmailCON;
            Email = EmailCON;
            Contador = ContadorCON;
            CambiaClave = CambiaClaveCON;
            RazonBloqueo = RazonBloqueoCON;
            IdTipoPersona = IdTipoPersonaCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.EMantenimientoUsuarios Procesar = new Entidades.EMantenimientoUsuarios();

            Procesar.IdUsuario = IdUsuario;
            Procesar.IdSucursal = IdSucursal;
            Procesar.IdOficina = IdOficina;
            Procesar.IdDepartamento = IdDepartamento;
            Procesar.IdPerfil = IdPerfil;
            Procesar.Usuario = Usuario;
            Procesar.Clave = Clave;
            Procesar.Persona = Persona;
            Procesar.Estatus = Estatus;
            Procesar.LlevaEmail = LlevaEmail;
            Procesar.Email = Email;
            Procesar.Contador = Contador;
            Procesar.CambiaClave = CambiaClave;
            Procesar.RazonBloqueo = RazonBloqueo;
            Procesar.IdTipoPersona = IdTipoPersona;

            MantenimientoUsuarios(Procesar, Accion);

        }
    }
}
