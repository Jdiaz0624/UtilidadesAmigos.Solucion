using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta
{
    public class ProcesarInformacionMantenimientoPlanCobertura
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.LogicaSistema();
        private decimal IdPlanCobertura = 0;
        private decimal IdCobertura = 0;
        private decimal CodigoCobertura = 0;
        private string Descripcion = "";
        private bool Estatus = false;
        private string Accion = "";

        public ProcesarInformacionMantenimientoPlanCobertura(
            decimal IdPlanCoberturaCON,
        decimal IdCoberturaCON,
        decimal CodigoCoberturaCON,
        string DescripcionCON,
        bool EstatusCON,
        string AccionCON)
        {
            IdPlanCobertura = IdPlanCoberturaCON;
            IdCobertura = IdCoberturaCON;
            CodigoCobertura = CodigoCoberturaCON;
            Descripcion = DescripcionCON;
            Estatus = EstatusCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.EPlanCoberturasMantenimiento procesar = new Entidades.EPlanCoberturasMantenimiento();

            procesar.IdPlanCobertura = IdPlanCobertura;
            procesar.IdCobertura = IdCobertura;
            procesar.CodigoCobertura = CodigoCobertura;
            procesar.PlanCobertura = Descripcion;
            procesar.Estatus0 = Estatus;

            var MAN = ObjData.MantenimientoPlanCoberturas(procesar, Accion);
        }
    }
}
