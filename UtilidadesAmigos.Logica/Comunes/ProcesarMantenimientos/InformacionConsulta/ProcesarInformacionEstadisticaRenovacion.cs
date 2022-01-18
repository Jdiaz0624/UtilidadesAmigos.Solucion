using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta
{
    public class ProcesarInformacionEstadisticaRenovacion
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta ObjData = new Logica.LogicaConsulta.LogicaConsulta();

        private decimal IdUsuario = 0;
        private decimal Cotizacion = 0;
        private string Poliza = "";
        private string Estatus = "";
        private int CodigoOficina = 0;
        private int Ramo = 0;
        private decimal Bruto = 0;
        private int CodigoIntermediario = 0;
        private int CodigoSupervisor = 0;
        private DateTime ValidadoDesde = DateTime.Now;
        private DateTime ValidadoHasta = DateTime.Now;
        private bool ExcluirMotores = false;
        private string Accion = "";


        public ProcesarInformacionEstadisticaRenovacion(
         decimal IdUsuarioCON,
         decimal CotizacionCON,
         string PolizaCON,
         string EstatusCON,
         int CodigoOficinaCON,
         int RamoCON,
         decimal BrutoCON,
         int CodigoIntermediarioCON,
         int CodigoSupervisorCON,
         DateTime ValidadoDesdeCON,
         DateTime ValidadoHastaCON,
         bool ExcluirMotoresCON,
         string AccionCON
            )
        {
            IdUsuario = IdUsuarioCON;
            Cotizacion = CotizacionCON;
            Poliza = PolizaCON;
            Estatus = EstatusCON;
            CodigoOficina = CodigoOficinaCON;
            Ramo = RamoCON;
            Bruto = BrutoCON;
            CodigoIntermediario = CodigoIntermediarioCON;
            CodigoSupervisor = CodigoSupervisorCON;
            ValidadoDesde = ValidadoDesdeCON;
            ValidadoHasta = ValidadoHastaCON;
            ExcluirMotores = ExcluirMotoresCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarDatosEstadistocaRenovacion Procesar = new Entidades.Consulta.EProcesarDatosEstadistocaRenovacion();

            Procesar.IdUsuario = IdUsuario;
            Procesar.Cotizacion = Cotizacion;
            Procesar.Poliza = Poliza;
            Procesar.Estatus = Estatus;
            Procesar.CodigoOficina = CodigoOficina;
            Procesar.Ramo = Ramo;
            Procesar.Prima = Bruto;
            Procesar.CodigoIntermediario = CodigoIntermediario;
            Procesar.CodigoSupervisor = CodigoSupervisor;
            Procesar.ValidadoDesde = ValidadoDesde;
            Procesar.ValidadoHasta = ValidadoHasta;
            Procesar.ExcluirMotores = ExcluirMotores;

            var MAN = ObjData.ProcesarDatosEstadisticaRenovacion(Procesar, Accion);
        }
    }
}
