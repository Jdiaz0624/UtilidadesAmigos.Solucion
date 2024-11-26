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
            IdRegistro = IdRegistroCON;
            NumeroVisita = NumeroVisitaCON;
            FechaEntrada = FechaEntradaCON;
            FechaSalida = FechaSalidaCON;
            IdCarnet = IdCarnetCON;
            Estatus = EstatusCON;
            Accion = AccionCON;
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
