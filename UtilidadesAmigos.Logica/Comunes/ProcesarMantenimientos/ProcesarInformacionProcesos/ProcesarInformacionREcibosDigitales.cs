using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos
{
    public class ProcesarInformacionREcibosDigitales
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos ObjDAta = new Logica.LogicaProcesos.LogicaProcesos();

        private decimal NumeroRecibo = 0;
        private int CodigoIntermediario = 0;
        private DateTime FechaRecibo = DateTime.Now;
        private decimal ValorRecibo = 0;
        private int IdTipoPago = 0;
        private string Detalle = "";
        private decimal CreadoPor = 0;
        private int Oficina = 0;
        private string Accion = "";

        public ProcesarInformacionREcibosDigitales(
            decimal NumeroReciboCON,
        int CodigoIntermediarioCON,
        DateTime FechaReciboCON,
        decimal ValorReciboCON,
        int IdTipoPagoCON,
        string DetalleCON,
        decimal CreadoPorCON,
        int OficinaCON,
        string AccionCON)
        {
            NumeroRecibo = NumeroReciboCON;
            CodigoIntermediario = CodigoIntermediarioCON;
            FechaRecibo = FechaReciboCON;
            ValorRecibo = ValorReciboCON;
            IdTipoPago = IdTipoPagoCON;
            Detalle = DetalleCON;
            CreadoPor = CreadoPorCON;
            Oficina = OficinaCON;
            Accion = AccionCON;

        }
        public void ProcesarInformacion()
        {

            UtilidadesAmigos.Logica.Entidades.Procesos.EReciboDigital Procesar = new Entidades.Procesos.EReciboDigital();

            Procesar.NumeroRecibo = NumeroRecibo;
            Procesar.CodigoIntermediario = CodigoIntermediario;
            Procesar.FechaRecibo0 = FechaRecibo;
            Procesar.ValorRecibo = ValorRecibo;
            Procesar.IdTipoPago = IdTipoPago;
            Procesar.Detalle = Detalle;
            Procesar.CreadoPor0 = CreadoPor;
            Procesar.IdOficina = Oficina;

            var MAN = ObjDAta.ProcesarReciboDigital(Procesar, Accion);
        }
    }
}
