using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionGrafico
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObjData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private decimal Idusuario = 0;
        private string Entidad = "";
        private decimal ValorDecimal = 0;
        private int ValorEntero = 0;
        private string Accion = "";

        public ProcesarInformacionGrafico(
        decimal IdusuarioCON,
        string EntidadCON,
        decimal ValorDecimalCON,
        int ValorEnteroCON,
        string AccionCON)
        {
            Idusuario = IdusuarioCON;
            Entidad = EntidadCON;
            ValorDecimal = ValorDecimalCON;
            ValorEntero = ValorEnteroCON;
            Accion = AccionCON;
        }
        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Reportes.EProcesarDatosGrafico Procesar = new Entidades.Reportes.EProcesarDatosGrafico();

            Procesar.IdUsuario = Idusuario;
            Procesar.Entidad = Entidad;
            Procesar.ValorDecimal = ValorDecimal;
            Procesar.valorEntero = ValorEntero;

            var MAN = ObjData.ProcesarGrafico(Procesar, Accion);
        }
    }
}
