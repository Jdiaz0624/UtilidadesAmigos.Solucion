using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionRegistrosSolicitudChequeLote
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos ObjData = new Logica.LogicaMantenimientos.LogicaMantenimientos();

          private decimal IdRegistro = 0;
          private decimal IdUsuairo = 0;
          private int CodigoIntermediario = 0;
          private decimal NumeroSolicitud = 0;
          private DateTime FechaProceso = DateTime.Now;
          private DateTime FechaDesde = DateTime.Now;
          private DateTime FechaHasta = DateTime.Now;
          private decimal MontoSolicitud = 0;
          private bool Estatus = false;
          private string Accion = "";


        public ProcesarInformacionRegistrosSolicitudChequeLote(
            decimal IdRegistroMAN,
            decimal IdUsuairoMAN,
            int CodigoIntermediarioMAN,
            decimal NumeroSolicitudMAN,
            DateTime FechaProcesoMAN,
            DateTime FechaDesdeMAN,
            DateTime FechaHastaMAN,
            decimal MontoSolicitudMAN,
            bool EstatusMAN,
            string AccionMAN)
        {
            IdRegistro = IdRegistroMAN;
            IdUsuairo = IdUsuairoMAN;
            CodigoIntermediario = CodigoIntermediarioMAN;
            NumeroSolicitud = NumeroSolicitudMAN;
            FechaProceso = FechaProcesoMAN;
            FechaDesde = FechaDesdeMAN;
            FechaHasta = FechaHastaMAN;
            MontoSolicitud = MontoSolicitudMAN;
            Estatus = EstatusMAN;
            Accion = AccionMAN;
        }
        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Mantenimientos.ERegistrosSolicitudChequeLote Procesar = new Entidades.Mantenimientos.ERegistrosSolicitudChequeLote();

            Procesar.IdRegistro = IdRegistro;
            Procesar.IdUsuairo = IdUsuairo;
            Procesar.CodigoIntermediario = CodigoIntermediario;
            Procesar.NumeroSolicitud = NumeroSolicitud;
            Procesar.FechaProceso0 = FechaProceso;
            Procesar.FechaDesde = FechaDesde;
            Procesar.FechaHasta = FechaHasta;
            Procesar.MontoSolicitud = MontoSolicitud;
            Procesar.Estatus0 = Estatus;

            var MAN = ObjData.MantenimientoRegistrosSolicitudLone(Procesar, Accion);
        }

    }
}
