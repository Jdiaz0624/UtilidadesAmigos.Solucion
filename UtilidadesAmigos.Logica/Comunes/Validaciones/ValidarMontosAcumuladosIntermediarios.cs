using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Validaciones
{
    public class ValidarMontosAcumuladosIntermediarios
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.LogicaSistema();

        private int CodigoIntermediario = 0;
        private int CodigoOficina = 0;
        private int CodigoRamo = 0;
        private decimal Numerorecibo = 0;
        private decimal NumeroFactura = 0;
        private string Poliza = "";

        public ValidarMontosAcumuladosIntermediarios(
        int CodigoIntermediarioCON,
        int CodigoOficinaCON,
        int CodigoRamoCON,
        decimal NumeroreciboCON,
        decimal NumeroFacturaCON,
        string PolizaCON)
        {
            CodigoIntermediario = CodigoIntermediarioCON;
            CodigoOficina = CodigoOficinaCON;
            CodigoRamo = CodigoRamoCON;
            Numerorecibo = NumeroreciboCON;
            NumeroFactura = NumeroFacturaCON;
            Poliza = PolizaCON;
        }

        public bool ValidarIntermediario() {
            bool Validacion = false;

            var Validar = ObjData.ValidarDetalleIntermediarioComisiones(CodigoIntermediario, CodigoOficina, CodigoRamo, Numerorecibo, NumeroFactura, Poliza);
            if (Validar.Count() < 1) {
                Validacion = false;
            }
            else {
                Validacion = true;
            }
            return Validacion;
        }
    }
}
