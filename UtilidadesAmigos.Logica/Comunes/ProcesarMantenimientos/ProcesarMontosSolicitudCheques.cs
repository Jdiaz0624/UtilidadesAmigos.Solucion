using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarMontosSolicitudCheques
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos ObjData = new Logica.LogicaMantenimientos.LogicaMantenimientos();

        private decimal IdUsuario = 0;
        private int CodigoIntermediario = 0;
        private decimal Bruto = 0;
        private decimal Neto = 0;
        private decimal Comision = 0;
        private decimal Retencion = 0;
        private decimal Avance = 0;
        private decimal AliQuidar = 0;
        private string Accion = "";

        public ProcesarMontosSolicitudCheques(
            decimal IdUsuarioCON,
            int CodigoIntermediarioCON,
            decimal BrutoCON,
            decimal NetoCON,
            decimal ComisionCON,
            decimal RetencionCON,
            decimal AvanceCON,
            decimal AliQuidarCON,
            string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            CodigoIntermediario = CodigoIntermediarioCON;
            Bruto = BrutoCON;
            Neto = NetoCON;
            Comision = ComisionCON;
            Retencion = RetencionCON;
            Avance = AvanceCON;
            AliQuidar = AliQuidarCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMontosSolicitudCheques Procesar = new Entidades.Mantenimientos.EMontosSolicitudCheques();

            Procesar.IdUsuario = IdUsuario;
            Procesar.CodigoIntermediario = CodigoIntermediario;
            Procesar.Bruto = Bruto;
            Procesar.Neto = Neto;
            Procesar.Comision = Comision;
            Procesar.Retencion = Retencion;
            Procesar.Avance = Avance;
            Procesar.ALiquidar = AliQuidar;


            var MAN = ObjData.ProcesarMontosSolicitudCheque(Procesar, Accion);
        }
    }
}
