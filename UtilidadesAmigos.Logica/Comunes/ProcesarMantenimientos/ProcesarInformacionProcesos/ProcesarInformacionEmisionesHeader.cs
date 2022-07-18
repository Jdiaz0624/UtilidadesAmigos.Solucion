using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos
{
    public class ProcesarInformacionEmisionesHeader
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos ObjData = new Logica.LogicaProcesos.LogicaProcesos();

        private decimal NumeroRegistro = 0;
        private string NumeroConector = "";
        private bool ClienteCreado = false;
        private decimal CodigoCliente = 0;
        private bool DocumentosEntregadoATecnico = false;
        private bool PolizaEmitida = false;
        private string NumeroPoliza = "";
        private bool SegundaRevision = false;
        private bool ImpresionMarbete = false;
        private bool Despachada = false;
        private string Accion = "";

        public ProcesarInformacionEmisionesHeader(
            decimal NumeroRegistroCON,
            string NumeroConectorCON,
            bool ClienteCreadoCON,
            decimal CodigoClienteCON,
            bool DocumentosEntregadoATecnicoCON,
            bool PolizaEmitidaCON,
            string NumeroPolizaCON,
            bool SegundaRevisionCON,
            bool ImpresionMarbeteCON,
            bool DespachadaCON,
            string AccionCON)
        {
            NumeroRegistro = NumeroRegistroCON;
            NumeroConector = NumeroConectorCON;
            ClienteCreado = ClienteCreadoCON;
            CodigoCliente = CodigoClienteCON;
            DocumentosEntregadoATecnico = DocumentosEntregadoATecnicoCON;
            PolizaEmitida = PolizaEmitidaCON;
            NumeroPoliza = NumeroPolizaCON;
            SegundaRevision = SegundaRevisionCON;
            ImpresionMarbete = ImpresionMarbeteCON;
            Despachada = DespachadaCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Procesos.EProcesoEmisionHeader Procesar = new Entidades.Procesos.EProcesoEmisionHeader();

            Procesar.NumeroRegistro = NumeroRegistro;
            Procesar.NumeroConector = NumeroConector;
            Procesar.ClienteCreado = ClienteCreado;
            Procesar.CodigoCliente = CodigoCliente;
            Procesar.DocumentosEntregadoATecnico = DocumentosEntregadoATecnico;
            Procesar.PolizaEmitida = PolizaEmitida;
            Procesar.NumeroPoliza = NumeroPoliza;
            Procesar.SegundaRevision = SegundaRevision;
            Procesar.ImpresionMarbete = ImpresionMarbete;
            Procesar.Despachada = Despachada;

            var MAN = ObjData.ProcesoEmisonPolizaHeader(Procesar, Accion);
        }
    }
}
