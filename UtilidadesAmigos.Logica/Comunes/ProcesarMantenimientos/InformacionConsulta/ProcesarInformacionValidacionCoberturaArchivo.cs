using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta
{
    public class ProcesarInformacionValidacionCoberturaArchivo
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta ObjData = new Logica.LogicaConsulta.LogicaConsulta();

        private decimal NumeroRegistro = 0;
        private decimal IdUaurioProceso = 0;
        private string Poliza = "";
        private string Chasis = "";
        private string Placa = "";
        private string Cobertura = "";
        private string Accion = "";

        public ProcesarInformacionValidacionCoberturaArchivo(
            decimal NumeroRegistroCON,
        decimal IdUaurioProcesoCON,
        string PolizaCON,
        string ChasisCON,
        string PlacaCON,
        string CoberturaCON,
        string AccionCON)
        {
            NumeroRegistro = NumeroRegistroCON;
            IdUaurioProceso = IdUaurioProcesoCON;
            Poliza = PolizaCON;
            Chasis = ChasisCON;
            Placa = PlacaCON;
            Cobertura = CoberturaCON;
            Accion = AccionCON;
        }


        /// <summary>
        /// Procesar la Información de los archivos
        /// </summary>
        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarInformacionValidacionArchivo Procesar = new Entidades.Consulta.EProcesarInformacionValidacionArchivo();

            Procesar.NumeroRegistro = NumeroRegistro;
            Procesar.IdUaurioProceso = IdUaurioProceso;
            Procesar.Poliza = Poliza;
            Procesar.Chasis = Chasis;
            Procesar.Placa = Placa;
            Procesar.Cobertura = Cobertura;

            var MAN = ObjData.ProcesarValidacionCoberturaArchivo(Procesar, Accion);
        }
    }
}
