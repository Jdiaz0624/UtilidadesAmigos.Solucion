using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionSeguimientoCarnet
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.LogicaSistema();

        private decimal IdRegistro = 0;
        private decimal NumeroVisita = 0;
        private DateTime FechaEntrada = DateTime.Now;
        private DateTime FechaSalida = DateTime.Now;
        private int IdCarnet = 0;
        private bool Estatus = false;
        private string Accion = "";

        public ProcesarInformacionSeguimientoCarnet(
         decimal IdRegistroCON,
         decimal NumeroVisitaCON,
         DateTime FechaEntradaCON,
         DateTime FechaSalidaCON,
         int IdCarnetCON,
         bool EstatusCON,
         string AccionCON)
        {
            IdRegistroCON = IdRegistro;
            NumeroVisitaCON = NumeroVisita;
            FechaEntradaCON = FechaEntrada;
            FechaSalidaCON = FechaSalida;
            IdCarnetCON = IdCarnet;
            EstatusCON = Estatus;
            AccionCON = Accion;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.EProcesarInformacionSeguimientoCarnet Procesar = new Entidades.EProcesarInformacionSeguimientoCarnet();

            Procesar.IdRegistro = IdRegistro;
            Procesar.NumeroVisita = NumeroVisita;
            Procesar.FechaEntrada = FechaEntrada;
            Procesar.FechaSalida = FechaSalida;
            Procesar.IdCarnet = IdCarnet;
            Procesar.Estatus= Estatus;
           

            var MAN = ObjData.ProcesarSeguimientoCarnet(Procesar, Accion);
        }
    }
}
