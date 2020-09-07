using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionCodigosSupervisoresPermitidos
    {
        public readonly UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.LogicaSistema();

        private decimal IdRegistro = 0;
        private decimal CodigoSupervisor = 0;
        private decimal IdUsuario = 0;
        private string Accion = "";

        public ProcesarInformacionCodigosSupervisoresPermitidos(
            decimal IdRegistroCON,
            decimal CodigoSupervisorCON,
            decimal IdUsuarioCON,
            string AccionCON)
        {
            IdRegistro = IdRegistroCON;
            CodigoSupervisor = CodigoSupervisorCON;
            IdUsuario = IdUsuarioCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.EBuscarCodigosSupervisoresPermitidos Procesar = new Entidades.EBuscarCodigosSupervisoresPermitidos();

            Procesar.IdRegistro = IdRegistro;
            Procesar.CodigoSupervisor = CodigoSupervisor;
            Procesar.IdUsuario = IdUsuario;
            Procesar.FechaAgregado0 = DateTime.Now;

            var MAN = ObjData.MantenimientoCodigoSupervisoresPermitidos(Procesar, Accion);
        }

    }
}
