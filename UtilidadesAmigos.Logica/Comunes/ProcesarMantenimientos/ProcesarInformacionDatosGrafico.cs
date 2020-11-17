using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionDatosGrafico
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObjData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();


        private decimal IdUsuario = 0;
        private string EntidadRamo = "";
        private int ValorEnteroRamo = 0;
        private decimal ValorDecimalRamo = 0;
        private string EntidadAsegurado = "";
        private int ValorEnteroAsegurado = 0;
        private decimal ValorDecimalAsegurado = 0;
        private string EntidadSupervisor = "";
        private int ValorEnteroSupervisor = 0;
        private decimal ValorDecimalSupervisor = 0;
        private string EntidadIntermediario = "";
        private int ValorEnteroIntermediario = 0;
        private decimal ValorDecimalIntermediario = 0;
        private string EntidadEstatus = "";
        private int ValorEnteroEstatus = 0;
        private decimal ValorDecimalEstatus = 0;
        private string EntidadOficina = "";
        private int ValorEnteroOficina = 0;
        private decimal ValorDecimalOficina = 0;
        private string EntidadConcepto = "";
        private int ValorEnteroConcepto = 0;
        private decimal ValorDecimalConcepto = 0;
        private string EntidadDescripcionTipo = "";
        private int ValorEnteroDescripcionTipo = 0;
        private decimal ValorDecimalDescripcionTipo = 0;
        private string EntidadMoneda = "";
        private int ValorEnteroMoneda = 0;
        private decimal ValorDecimalMoneda = 0;
        private string Accion = "";

        public ProcesarInformacionDatosGrafico(
        decimal IdUsuarioCON,
        string EntidadRamoCON,
        int ValorEnteroRamoCON,
        decimal ValorDecimalRamoCON,
        string EntidadAseguradoCON,
        int ValorEnteroAseguradoCON,
        decimal ValorDecimalAseguradoCON,
        string EntidadSupervisorCON,
        int ValorEnteroSupervisorCON,
        decimal ValorDecimalSupervisorCON,
        string EntidadIntermediarioCON,
        int ValorEnteroIntermediarioCON,
        decimal ValorDecimalIntermediarioCON,
        string EntidadEstatusCON,
        int ValorEnteroEstatusCON,
        decimal ValorDecimalEstatusCON,
        string EntidadOficinaCON,
        int ValorEnteroOficinaCON,
        decimal ValorDecimalOficinaCON,
        string EntidadConceptoCON,
        int ValorEnteroConceptoCON,
        decimal ValorDecimalConceptoCON,
        string EntidadDescripcionTipoCON,
        int ValorEnteroDescripcionTipoCON,
        decimal ValorDecimalDescripcionTipoCON,
        string EntidadMonedaCON,
        int ValorEnteroMonedaCON,
        decimal ValorDecimalMonedaCON,
        string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            EntidadRamo = EntidadRamoCON;
            ValorEnteroRamo = ValorEnteroRamoCON;
            ValorDecimalRamo = ValorDecimalRamoCON;
            EntidadAsegurado = EntidadAseguradoCON;
            ValorEnteroAsegurado = ValorEnteroAseguradoCON;
            ValorDecimalAsegurado = ValorDecimalAseguradoCON;
            EntidadSupervisor = EntidadSupervisorCON;
            ValorEnteroSupervisor = ValorEnteroSupervisorCON;
            ValorDecimalSupervisor = ValorDecimalSupervisorCON;
            EntidadIntermediario = EntidadIntermediarioCON;
            ValorEnteroIntermediario = ValorEnteroIntermediarioCON;
            ValorDecimalIntermediario = ValorDecimalIntermediarioCON;
            EntidadEstatus = EntidadEstatusCON;
            ValorEnteroEstatus = ValorEnteroEstatusCON;
            ValorDecimalEstatus = ValorDecimalEstatusCON;
            EntidadOficina = EntidadOficinaCON;
            ValorEnteroOficina = ValorEnteroOficinaCON;
            ValorDecimalOficina = ValorDecimalOficinaCON;
            EntidadConcepto = EntidadConceptoCON;
            ValorEnteroConcepto = ValorEnteroConceptoCON;
            ValorDecimalConcepto = ValorDecimalConceptoCON;
            EntidadDescripcionTipo = EntidadDescripcionTipoCON;
            ValorEnteroDescripcionTipo = ValorEnteroDescripcionTipoCON;
            ValorDecimalDescripcionTipo = ValorDecimalDescripcionTipoCON;
            EntidadMoneda = EntidadMonedaCON;
            ValorEnteroMoneda = ValorEnteroMonedaCON;
            ValorDecimalMoneda = ValorDecimalMonedaCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacionGraficos() {
            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarInformacionDatosGraficos Procesar = new Entidades.Reportes.EProcesarInformacionDatosGraficos();

            Procesar.IdUsuario = IdUsuario;
            Procesar.EntidadRamo = EntidadRamo;
            Procesar.ValorEnteroRamo = ValorEnteroRamo;
            Procesar.ValorDecimalRamo = ValorDecimalRamo;
            Procesar.EntidadAsegurado = EntidadAsegurado;
            Procesar.ValorEnteroAsegurado = ValorEnteroAsegurado;
            Procesar.ValorDecimalAsegurado = ValorDecimalAsegurado;
            Procesar.EntidadSupervisor = EntidadSupervisor;
            Procesar.ValorEnteroSupervisor = ValorEnteroSupervisor;
            Procesar.ValorDecimalSupervisor = ValorEnteroSupervisor;
            Procesar.EntidadIntermediario = EntidadIntermediario;
            Procesar.ValorEnteroIntermediario = ValorEnteroIntermediario;
            Procesar.ValorDecimalIntermediario = ValorDecimalIntermediario;
            Procesar.EntidadEstatus = EntidadEstatus;
            Procesar.ValorEnteroEstatus = ValorEnteroEstatus;
            Procesar.ValorDecimalEstatus = ValorDecimalEstatus;
            Procesar.EntidadOficina = EntidadOficina;
            Procesar.ValorEnteroOficina = ValorEnteroOficina;
            Procesar.ValorDecimalOficina = ValorDecimalOficina;
            Procesar.EntidadConcepto = EntidadConcepto;
            Procesar.ValorEnteroConcepto = ValorEnteroConcepto;
            Procesar.ValorDecimalConcepto = ValorDecimalConcepto;
            Procesar.EntidadDescripcionTipo = EntidadDescripcionTipo;
            Procesar.ValorEnteroDescripcionTipo = ValorEnteroDescripcionTipo;
            Procesar.ValorDecimalDescripcionTipo = ValorDecimalDescripcionTipo;
            Procesar.EntidadMoneda = EntidadMoneda;
            Procesar.ValorEnteroMoneda = ValorEnteroMoneda;
            Procesar.ValorDecimalMoneda = ValorDecimalMoneda;

            var MAN = ObjData.ProcesarInformacionDatoGrafico(Procesar, Accion);
        }
    }
}
