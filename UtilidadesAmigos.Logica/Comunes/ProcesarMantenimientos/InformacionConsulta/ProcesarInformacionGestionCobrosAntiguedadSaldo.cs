using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta
{
    public class ProcesarInformacionGestionCobrosAntiguedadSaldo
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta ObjData = new Logica.LogicaConsulta.LogicaConsulta();

        private decimal NumeroRegistro = 0;
        private string Poliza = "";
        private int IdEstatusLlamada = 0;
        private int IdConceptoLlamada = 0;
        private string Comentario = "";
        private DateTime FechaNuevaLlamada = DateTime.Now;
        private string HoraNuevaLlamada = "";
        private decimal CodigoUsuario = 0;
        private DateTime FechaProceso = DateTime.Now;
        private string Accion = "";

        public ProcesarInformacionGestionCobrosAntiguedadSaldo(
            decimal NumeroRegistroCON,
            string PolizaCON,
            int IdEstatusLlamadaCON,
            int IdConceptoLlamadaCON,
            string ComentarioCON,
            DateTime FechaNuevaLlamadaCON,
            string HoraNuevaLlamadaCON,
            decimal CodigoUsuarioCON,
            DateTime FechaProcesoCON,
            string AccionCON)
        {
            NumeroRegistro = NumeroRegistroCON;
            Poliza = PolizaCON;
            IdEstatusLlamada = IdEstatusLlamadaCON;
            IdConceptoLlamada = IdConceptoLlamadaCON;
            Comentario = ComentarioCON;
            FechaNuevaLlamada = FechaNuevaLlamadaCON;
            HoraNuevaLlamada = HoraNuevaLlamadaCON;
            CodigoUsuario = CodigoUsuarioCON;
            FechaProceso = FechaProcesoCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Consulta.EComentariosGestionCobrosAntigueadSaldo Procesar = new Entidades.Consulta.EComentariosGestionCobrosAntigueadSaldo();

            Procesar.NumeroRegistro = NumeroRegistro;
            Procesar.Poliza = Poliza;
            Procesar.IdEstatusLlamada = IdEstatusLlamada;
            Procesar.IdConceptoLlamada = IdConceptoLlamada;
            Procesar.Comentario = Comentario;
            Procesar.FechaNuevaLlamada0 = FechaNuevaLlamada;
            Procesar.HoraNuevaLlamada = HoraNuevaLlamada;
            Procesar.CodigoUsuario = CodigoUsuario;
            Procesar.FechaProceso0 = FechaProceso;

            var MAn = ObjData.ProcesarComentariosAntiguedadSaldoCobros(Procesar, Accion);
        }
    }
}
