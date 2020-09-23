using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionPorcientoComisionesPorDefecto
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos Objdata = new Logica.LogicaMantenimientos.LogicaMantenimientos();

        private decimal IdRegistro = 0;
        private int Ramo = 0;
        private int SubRamo = 0;
        private decimal PorcientoComision = 0;
        private string Accion = "";

        public ProcesarInformacionPorcientoComisionesPorDefecto(
        decimal IdRegistroCON,
        int RamoCON,
        int SubRamoCON,
        decimal PorcientoComisionCON,
        string AccionCON)
        {
            IdRegistro = IdRegistroCON;
            Ramo = RamoCON;
            SubRamo = SubRamoCON;
            PorcientoComision = PorcientoComisionCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EComisionesPorDefecto Procesar = new Entidades.Mantenimientos.EComisionesPorDefecto();

            Procesar.IdRegistro = IdRegistro;
            Procesar.CodRamo = Ramo;
            Procesar.CodSubramo = SubRamo;
            Procesar.PorcientoComision = PorcientoComision;

            var MAN = Objdata.MantenimientoPorcientoComisionPorDefecto(Procesar, Accion);
        }
    }
}
