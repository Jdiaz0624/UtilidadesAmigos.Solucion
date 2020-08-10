using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes
{
    public class EliminarFacturaPDF
    {
        public readonly Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.LogicaSistema>();

        private decimal IdComprobante = 0;
        private string Comprobante = "";
        private string ComprobanteAfectado = "";
        private string Accion = "";

        public EliminarFacturaPDF(
            decimal IdComprobanteCON,
            string COmprobanteCON,
            string ComprobanteAfectadoCON,
            string AcionCON)
        {
            IdComprobante = IdComprobanteCON;
            Comprobante = COmprobanteCON;
            ComprobanteAfectado = ComprobanteAfectadoCON;
            Accion = AcionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.EGenerarDatosFacturasPDF Porcesar = new Entidades.EGenerarDatosFacturasPDF();

            Porcesar.IdComprobante = IdComprobante;
            Porcesar.Comprobante = Comprobante;
            Porcesar.ComprobanteAfectado = ComprobanteAfectado;

            var MAN = ObjData.Value.MantenimientoFacturasPDF(Porcesar, Accion);
        }


    }
}
