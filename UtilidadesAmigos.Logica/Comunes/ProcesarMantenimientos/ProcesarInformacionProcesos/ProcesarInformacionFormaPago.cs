using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos
{
    public class ProcesarInformacionFormaPago
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos ObjData = new Logica.LogicaProcesos.LogicaProcesos();

        private decimal NumeroRecibo = 0;
        private string Tipo = "";
        private string Accion = "";

        public ProcesarInformacionFormaPago(
            decimal NumeroReciboCON,
            string TipoCON,
            string AccionCON)
        {
            NumeroRecibo = NumeroReciboCON;
            Tipo = TipoCON;
            Accion = AccionCON;
        }

        /// <summary>
        /// Este metodo modifica las informaciones de los tipos de pagos
        /// </summary>
        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Procesos.EModificarFormaPago Procesar = new Entidades.Procesos.EModificarFormaPago();

            Procesar.Compania = 30;
            Procesar.TipoFactura = "";
            Procesar.Anulado = "";
            Procesar.sistema = 1;
            Procesar.tipodocumento = 1;
            Procesar.NumeroRecibo = NumeroRecibo;
            Procesar.Fechapago = DateTime.Now;
            Procesar.Tipo = Tipo;
            Procesar.Monto = 0;
            Procesar.NoDocumento = "";
            Procesar.NoAprobacion = "";
            Procesar.FechaVencimiento = "";
            Procesar.CodBanco = "";
            Procesar.TipoTarjeta = "";

            var MAN = ObjData.ModificarFormaPago(Procesar, Accion);
        }


    }
}
