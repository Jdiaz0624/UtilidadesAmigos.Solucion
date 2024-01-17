using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta
{
    public class ProcesarInformacionMAntenimientoCoberturas
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.LogicaSistema();

        private decimal IdCobertura = 0;
        private string Descripcion = "";
        private bool Estatus = false;
        private string Accion = "";

        public ProcesarInformacionMAntenimientoCoberturas(
            decimal IdCoberturaCON,
        string DescripcionCON,
        bool EstatusCON,
        string AccionCON)
        {
            IdCobertura = IdCoberturaCON;
            Descripcion = DescripcionCON;
            Estatus = EstatusCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.EBuscaCoberturasMantenimiento Procesar = new Entidades.EBuscaCoberturasMantenimiento();

            Procesar.IdCobertura = IdCobertura;
            Procesar.Descripcion = Descripcion;
            Procesar.Estatus0 = Estatus;

            var MAN = ObjData.MantenimientoCobertura(Procesar, Accion);
        }
    }
}
