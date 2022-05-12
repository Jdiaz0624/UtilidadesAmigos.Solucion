using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSeguridad
{
    public class ProcesarInformacionOpcionesPantallas
    {

        readonly UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad ObjData = new Logica.LogicaSeguridad.LogicaSeguridad();

        private int IdModulo = 0;
        private int IdPantalla = 0;
        private int IdOpcion = 0;
        private string Descripcion = "";
        private bool Estatus = false;
        private string Accion = "";

        public ProcesarInformacionOpcionesPantallas(
            int IdModuloCON,
            int IdPantallaCON,
            int IdOpcionCON,
            string DescripcionCON,
            bool EstatusCON,
            string AccionCON)
        {
            IdModulo = IdModuloCON;
            IdPantalla = IdPantallaCON;
            IdOpcion = IdOpcionCON;
            Descripcion = DescripcionCON;
            Estatus = EstatusCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Seguridad.EOpcionPantalla Procesar = new Entidades.Seguridad.EOpcionPantalla();

            Procesar.IdModulo = IdModulo;
            Procesar.IdPantalla = IdPantalla;
            Procesar.IdOpcion = IdOpcion;
            Procesar.Opcion = Descripcion;
            Procesar.Estatus0 = Estatus;

            var MAN = ObjData.ProcesarOpcionesPantalla(Procesar, Accion);
        }

    }
}
