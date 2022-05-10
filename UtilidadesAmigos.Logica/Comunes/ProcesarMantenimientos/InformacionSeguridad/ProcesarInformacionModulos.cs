using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSeguridad
{
    public class ProcesarInformacionModulos
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad ObjData = new Logica.LogicaSeguridad.LogicaSeguridad();

        private int IdModulo=0;
        private string Modulo = "";
        private bool Estatus = false;
        private string Accion = "";

        public ProcesarInformacionModulos(
            int IdModuloCON,
            string ModuloCON,
            bool EstatusCON,
            string AccionCON)
        {
            IdModulo = IdModuloCON;
            Modulo = ModuloCON;
            Estatus = EstatusCON;
            Accion = AccionCON;

        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Seguridad.EModulos Procesar = new Entidades.Seguridad.EModulos();

            Procesar.IdModulo = IdModulo;
            Procesar.Modulo = Modulo;
            Procesar.Estatus0 = Estatus;

            var MAN = ObjData.ProcesarModulos(Procesar, Accion);
        }

    }
}
