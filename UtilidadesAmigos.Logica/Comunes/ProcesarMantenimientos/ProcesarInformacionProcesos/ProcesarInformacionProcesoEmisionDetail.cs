using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos
{
    public class ProcesarInformacionProcesoEmisionDetail
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos ObjData = new Logica.LogicaProcesos.LogicaProcesos();

        private string NumeroConector = "";
        private int Secuencia = 0;
        private int IdEstatusProcesoEmison = 0;
        private DateTime Fecha = DateTime.Now;
        private decimal IdUsuario = 0;
        private string Accion = "";

        public ProcesarInformacionProcesoEmisionDetail(
        string NumeroConectorCON,
        int SecuenciaCON,
        int IdEstatusProcesoEmisonCON,
        DateTime FechaCON,
        decimal IdUsuarioCON,
        string AccionCON)
        {
            NumeroConector = NumeroConectorCON;
            Secuencia = SecuenciaCON;
            IdEstatusProcesoEmison = IdEstatusProcesoEmisonCON;
            Fecha = FechaCON;
            IdUsuario = IdUsuarioCON;
            Accion = AccionCON;
        }
        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Procesos.EProcesoEmisionDetail Procesar = new Entidades.Procesos.EProcesoEmisionDetail();

            Procesar.NumeroConector = NumeroConector;
            Procesar.Secuencia = Secuencia;
            Procesar.IdEstatusProcesoEmison = IdEstatusProcesoEmison;
            Procesar.Fecha = Fecha;
            Procesar.IdUsuario = IdUsuario;

            var MAN = ObjData.ProcesarEmisionPolizaDetail(Procesar, Accion);
        }
    }
}
