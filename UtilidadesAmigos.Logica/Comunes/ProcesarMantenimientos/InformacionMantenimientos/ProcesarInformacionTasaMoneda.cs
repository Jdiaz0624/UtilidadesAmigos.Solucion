using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionMantenimientos
{
    public class ProcesarInformacionTasaMoneda
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos ObjData = new Logica.LogicaMantenimientos.LogicaMantenimientos();

        private int Codigo = 0;
        private decimal Tasa = 0;

        public ProcesarInformacionTasaMoneda(
            int CodigoCON,
        decimal TasaCON)
        {
            Codigo = CodigoCON;
            Tasa = TasaCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMantenimientoTasaMoneda Procesar = new Entidades.Mantenimientos.EMantenimientoTasaMoneda();

            Procesar.Codigo = Codigo;
            Procesar.Prima = Tasa;

            var MAN = ObjData.ModificarTasaMoneda(Procesar, "UPDATE");
        }
    }
}
