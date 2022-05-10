using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSeguridad
{
    public class ProcesarInformacionPantallas
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad ObjData = new Logica.LogicaSeguridad.LogicaSeguridad();

        private int IdModulo = 0;
        private int IdPantalla = 0;
        private string Pantalla = "";
        private bool Estatus = false;
        private string Accion = "";

        public ProcesarInformacionPantallas(
            int IdModuloCON,
            int IdPantallaCON,
            string PantallaCON,
            bool EstatusCON,
            string AccionCON)
        {
            IdModulo = IdModuloCON;
            IdPantalla = IdPantallaCON;
            Pantalla = PantallaCON;
            Estatus = EstatusCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Seguridad.EPantallas Procesar = new Entidades.Seguridad.EPantallas();

            Procesar.IdModulo = IdModulo;
            Procesar.IdPantalla = IdPantalla;
            Procesar.Pantalla = Pantalla;
            Procesar.Estatus0 = Estatus;

            var MAN = ObjData.ProcesarPantallas(Procesar, Accion);
        }
    }
}
