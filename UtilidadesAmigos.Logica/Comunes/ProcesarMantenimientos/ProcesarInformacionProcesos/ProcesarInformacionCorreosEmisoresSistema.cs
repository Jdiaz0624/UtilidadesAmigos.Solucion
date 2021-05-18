using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos
{
    public class ProcesarInformacionCorreosEmisoresSistema
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos ObjData = new Logica.LogicaProcesos.LogicaProcesos();

        private int IdCorreo = 0;
        private int IdProceso = 0;
        private string Correo = "";
        private string Clave = "";
        private int Puerto = 0;
        private string SMTP = "";
        private string Accion = "";

        public ProcesarInformacionCorreosEmisoresSistema(
            int IdCorreoCON,
            int IdProcesoCON,
            string CorreoCON,
            string ClaveCON,
            int PuertoCON,
            string SMTPCON,
            string AccionCON)
        {
            IdCorreo = IdCorreoCON;
            IdProceso = IdProcesoCON;
            Correo = CorreoCON;
            Clave = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(ClaveCON);
            Puerto = PuertoCON;
            SMTP = SMTPCON;
            Accion = AccionCON;
        }

        public void ProcesarInfrmacion() {
            UtilidadesAmigos.Logica.Entidades.Procesos.ECorreosEmisonesSistema Procesar = new Entidades.Procesos.ECorreosEmisonesSistema();

            Procesar.IdCorreo = IdCorreo;
            Procesar.IdProceso = IdProceso;
            Procesar.Correo = Correo;
            Procesar.Clave = Clave;
            Procesar.Puerto = Puerto;
            Procesar.SMTP = SMTP;

            var MAN = ObjData.ProcesarCorreosEmisiones(Procesar, Accion);
        }
    }
}
