using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionConsultaInformacionPrPantalla
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos ObjData = new Logica.LogicaMantenimientos.LogicaMantenimientos();

        private decimal IdUsuario = 0;
        private int CodigoIntermediario = 0;
        private int CodigoBanco = 0;
        private decimal Monto = 0;
        private decimal Acumulado = 0;
        private string Accion = "";

        public ProcesarInformacionConsultaInformacionPrPantalla(
            decimal IdUsuarioCON,
        int CodigoIntermediarioCON,
        int CodigoBancoCON,
        decimal MontoCON,
        decimal AcumuladoCON,
        string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            CodigoIntermediario = CodigoIntermediarioCON;
            CodigoBanco = CodigoBancoCON;
            Monto = MontoCON;
            Acumulado = AcumuladoCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EConsultaInformacionSolicitudChequePantalla Procesar = new Entidades.Mantenimientos.EConsultaInformacionSolicitudChequePantalla();

            Procesar.IdUsuario = IdUsuario;
            Procesar.CodigoIntermediario = CodigoIntermediario;
            Procesar.CodigoBanco = CodigoBanco;
            Procesar.Monto = Monto;
            Procesar.Acumulado = Acumulado;

            var MAn = ObjData.ProcesarInformacionSolicitudChequePanalla(Procesar, Accion);
        }

    }
}
