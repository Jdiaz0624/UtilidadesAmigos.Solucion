using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta
{
    public class ProcesarInformacionAsignacionEstatus
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta ObjData = new Logica.LogicaConsulta.LogicaConsulta();

        private decimal IdRegistro = 0;
        private decimal CodigoCliente = 0;
        private int IdEstatus = 0;
        private DateTime Fecha = DateTime.Now;
        private string Accion = "";

        public ProcesarInformacionAsignacionEstatus(
            decimal IdRegistroCON,
        decimal CodigoClienteCON,
        int IdEstatusCON,
        DateTime FechaCON,
        string AccionCON)
        {
            IdRegistro = IdRegistroCON;
            CodigoCliente = CodigoClienteCON;
            IdEstatus = IdEstatusCON;
            Fecha = FechaCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Consulta.EAsignacionTarjetas Procesar = new Entidades.Consulta.EAsignacionTarjetas();

            Procesar.IdRegistro = IdRegistro;
            Procesar.CodigoCliente = CodigoCliente;
            Procesar.IdEstatus = IdEstatus;
            Procesar.Fecha0 = Fecha;

            var MAN = ObjData.ProcesarAsignacionTarjetas(Procesar, Accion);
        }
    }
}
