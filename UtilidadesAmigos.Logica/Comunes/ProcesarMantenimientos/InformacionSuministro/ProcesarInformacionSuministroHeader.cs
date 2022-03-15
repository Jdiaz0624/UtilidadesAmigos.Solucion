using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro
{
    public class ProcesarInformacionSuministroHeader
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSuministro.LogicaSuministro ObjData = new Logica.LogicaSuministro.LogicaSuministro();

        private decimal NumeroSolicitud = 0;
        private string NumeroConector = "";
        private decimal IdUsuario = 0;
        private bool EstatusSolicitud = false;
        private string Accion = "";

        public ProcesarInformacionSuministroHeader(
           decimal NumeroSolicitudCON,
           string NumeroConectorCON,
           decimal IdUsuarioCON,
           bool EstatusSolicitudCON,
           string AccionCON)
        {
            NumeroSolicitud = NumeroSolicitudCON;
            NumeroConector = NumeroConectorCON;
            IdUsuario = IdUsuarioCON;
            EstatusSolicitud = EstatusSolicitudCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroHeader Procesar = new Entidades.Suministro.ESuministroHeader();

            Procesar.NumeroSolicitud = NumeroSolicitud;
            Procesar.NumeroConector = NumeroConector;
            Procesar.IdUsuario = IdUsuario;
            Procesar.FechaSolicitud = DateTime.Now;
            Procesar.EstatusSolicitud = EstatusSolicitud;

            var MAN = ObjData.ProcesarSuministroHeader(Procesar, Accion);
        }
    }
}
