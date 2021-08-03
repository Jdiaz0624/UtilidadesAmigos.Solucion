using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionControlVisitas
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.LogicaSistema();

        private decimal NoRegistro = 0;
        private int IdTipoProcesoRecepcion = 0;
        private string Nombre = "";
        private string Remitente = "";
        private string Destinatario = "";
        private string NumeroIdentificacion = "";
        private int CantidadDocumentos = 0;
        private int CantidadPersonas = 0;
        private decimal UsuarioDigita = 0;
        private decimal UsuarioModifica = 0;
        private string Comentario = "";
        private string Accion = "";

        public ProcesarInformacionControlVisitas(
            decimal NoRegistroCON,
            int IdTipoProcesoRecepcionCON,
            string NombreCON,
            string RemitenteCON,
            string DestinatarioCON,
            string NumeroIdentificacionCON,
            int CantidadDocumentosCON,
            int CantidadPersonasCON,
            decimal UsuarioDigitaCON,
            decimal UsuarioModificaCON,
            string ComentarioCON,
            string AccionCON)
        {
            NoRegistro = NoRegistroCON;
            IdTipoProcesoRecepcion = IdTipoProcesoRecepcionCON;
            Nombre = NombreCON;
            Remitente = RemitenteCON;
            Destinatario = DestinatarioCON;
            NumeroIdentificacion = NumeroIdentificacionCON;
            CantidadDocumentos = CantidadDocumentosCON;
            CantidadPersonas = CantidadPersonasCON;
            UsuarioDigita = UsuarioDigitaCON;
            UsuarioModifica = UsuarioModificaCON;
            Comentario = ComentarioCON;
            Accion = AccionCON;
        }

        /// <summary>
        /// Este metodo es para procesar la informacion de los datos de la rcepcion de documentos
        /// </summary>
        private void ProcesarInformacion() { 
        
        }

    }
}
