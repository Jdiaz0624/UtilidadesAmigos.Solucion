using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionAdministrador
{
    public class ProcesarInformacionCorreosENviar
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaOpcionesAdministrador.LogicaOpcionesdministrador ObjData = new Logica.LogicaOpcionesAdministrador.LogicaOpcionesdministrador();

        private decimal IdCorreoEnviar = 0;
        private decimal IdProceso = 0;
        private string Correo = "";
        private bool Estatus = false;
        private string Accion = "";

        public ProcesarInformacionCorreosENviar(
            decimal IdCorreoEnviarCON,
            decimal IdProcesoCON,
            string CorreoCON,
            bool EstatusCON,
            string AccionCON)
        {
            IdCorreoEnviar = IdCorreoEnviarCON;
            IdProceso = IdProcesoCON;
            Correo = CorreoCON;
            Estatus = EstatusCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.EBuscaListadoCorreosEnviar Proesar = new Entidades.OpcionesAdministrador.EBuscaListadoCorreosEnviar();

            Proesar.IdCorreoEnviar = IdCorreoEnviar;
            Proesar.IdProceso = IdProceso;
            Proesar.Correo = Correo;
            Proesar.Estatus0 = Estatus;

            var MAN = ObjData.ManupularCOrreosEnviar(Proesar, Accion);
        }



    }
}
