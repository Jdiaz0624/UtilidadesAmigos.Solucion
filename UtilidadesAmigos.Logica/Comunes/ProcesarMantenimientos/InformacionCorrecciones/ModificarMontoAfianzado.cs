using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones
{
    public class ModificarMontoAfianzado
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaCorrecciones.LogicaCorrecciones ObjData = new Logica.LogicaCorrecciones.LogicaCorrecciones();

        private string Poliza = "";
        private decimal MontoAfianzado = 0;
        private string Accion = "";

        public ModificarMontoAfianzado(
            string PolizaCON,
            decimal MontoAfianzadoCON,
            string AccionCON)
        {

            Poliza = PolizaCON;
            MontoAfianzado = MontoAfianzadoCON;
            Accion = AccionCON;
        }
        public void ModificarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Correcciones.EModificarMontoAfianzado Modiicar = new Entidades.Correcciones.EModificarMontoAfianzado();

            Modiicar.Poliza = Poliza;
            Modiicar.MontoAfianzado = MontoAfianzado;

            var MAN = ObjData.ModificarMontoAfianzado(Modiicar, Accion);
        }
    }
}
