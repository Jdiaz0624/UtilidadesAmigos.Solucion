using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilidadesAmigos.Logica.Entidades;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones
{
    public class ProcesarInformacionBitacoraMontoAfianzado
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaCorrecciones.LogicaCorrecciones ObjData = new Logica.LogicaCorrecciones.LogicaCorrecciones();

        private decimal IdRegistro = 0;
        private string Poliza = "";
        private decimal Anterior = 0;
        private decimal Cambio = 0;
        private decimal Usuario = 0;
        private string Concepto = "";
        private string Accion = "";

        public ProcesarInformacionBitacoraMontoAfianzado(
        decimal IdRegistroCON,
        string PolizaCON,
        decimal AnteriorCON,
        decimal CambioCON,
        decimal UsuarioCON,
        string ConceptoCON,
        string AccionCON)
        {
            IdRegistro = IdRegistroCON;
            Poliza = PolizaCON;
            Anterior = AnteriorCON;
            Cambio = CambioCON;
            Usuario = UsuarioCON;
            Concepto = ConceptoCON;
            Accion = AccionCON;
        }
        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Correcciones.EBitacoraMontoAfianzado Procesar = new Entidades.Correcciones.EBitacoraMontoAfianzado();

            Procesar.IdRegistro = IdRegistro;
            Procesar.Poliza = Poliza;
            Procesar.Anterior = Anterior;
            Procesar.Cambio = Cambio;
            Procesar.Usuario = Usuario;
            Procesar.Concepto = Concepto;

            var MAN = ObjData.ProcesarBitacoraMontoAfianzado(Procesar, Accion);
        }
    }
}
