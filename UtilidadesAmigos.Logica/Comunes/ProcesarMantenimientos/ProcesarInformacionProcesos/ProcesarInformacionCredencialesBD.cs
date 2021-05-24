using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos
{
    public class ProcesarInformacionCredencialesBD
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos ObjData = new Logica.LogicaProcesos.LogicaProcesos();

        private int IdCredencial = 0;
        private string Usuario = "";
        private string Clave = "";
        private string Accion = "";

        public ProcesarInformacionCredencialesBD(
            int IdCredencialCON,
        string UsuarioCON,
        string ClaveCON,
        string AccionCON)
        {
            IdCredencial = IdCredencialCON;
            Usuario = UsuarioCON;
            Clave = ClaveCON;
            Accion = AccionCON;
        }
        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Procesos.ECredencialesBD Procesar = new Entidades.Procesos.ECredencialesBD();

            Procesar.IdCredencial = IdCredencial;
            Procesar.Usuario = Usuario;
            Procesar.Clave = Clave;


            var MAN = ObjData.ModificarCredenciales(Procesar, Accion);
        }
    }
}
