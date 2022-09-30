using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Reporte
{
    public class ProcesarInformacionEnlaceProveedores
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObjData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private int IdProveedores = 0;
        private int CodigoDia = 0;
        private string Accion = "";

        public ProcesarInformacionEnlaceProveedores(
            int IdProveedoresCON,
            int CodigoDiaCON,
            string AccionCON)
        {
            IdProveedores = IdProveedoresCON;
            CodigoDia = CodigoDiaCON;
            Accion = AccionCON;
        }
        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Reportes.EModificarEnlaceProveedores Modificar = new Entidades.Reportes.EModificarEnlaceProveedores();

            Modificar.IdProveedor = IdProveedores;
            Modificar.CodigoDia = CodigoDia;

            var MAN = ObjData.ProcesarEnlaceProveedores(Modificar, Accion);
        }
    }
}
