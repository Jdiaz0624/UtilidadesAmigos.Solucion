using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta
{
    public class ProcesarInformacionPolizasAvisosGestionCobros
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta ObjData = new Logica.LogicaConsulta.LogicaConsulta();

        private decimal NumeroRegistro = 0;
        private string Poliza = "";
        private int IdEstatusLlamada = 0;
        private int IdConceptoLlamada = 0;
        private string Comentario = "";
        private decimal IdUsuario = 0;
        private DateTime FechaGuardado = DateTime.Now;
        private string InicioVigencia = "";
        private string FinVigencia = "";
        private bool Estatus = false;
        private DateTime? FechaNuevaLLamada = DateTime.Now;
        private string HoraNuevaLLamada = "";
        private string Accion = "";

        public ProcesarInformacionPolizasAvisosGestionCobros(
            decimal NumeroRegistroCON,
            string PolizaCON,
            int IdEstatusLlamadaCON,
            int IdConceptoLlamadaCON,
            string ComentarioCON,
            decimal IdUsuarioCON,
            DateTime FechaGuardadoCON,
            string InicioVigenciaCON,
            string FinVigenciaCON,
            bool EstatusCON,
            DateTime? FechaNuevaLLamadaCON,
            string HoraNuevaLLamadaCON,
            string AccionCON)
        {
            NumeroRegistro = NumeroRegistroCON;
            Poliza = PolizaCON;
            IdEstatusLlamada = IdEstatusLlamadaCON;
            IdConceptoLlamada = IdConceptoLlamadaCON;
            Comentario = ComentarioCON;
            IdUsuario = IdUsuarioCON;
            FechaGuardado = FechaGuardadoCON;
            InicioVigencia = InicioVigenciaCON;
            FinVigencia = FinVigenciaCON;
            Estatus = EstatusCON;
            FechaNuevaLLamada = FechaNuevaLLamadaCON;
            HoraNuevaLLamada = HoraNuevaLLamadaCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Consulta.EPolizasAvisoGestionCobros Procesar = new Entidades.Consulta.EPolizasAvisoGestionCobros();

            Procesar.NumeroRegistro = NumeroRegistro;
            Procesar.Poliza = Poliza;
            Procesar.IdEstatusLlamada = IdEstatusLlamada;
            Procesar.IdConceptoLlamada = IdConceptoLlamada;
            Procesar.Comentario = Comentario;
            Procesar.IdUsuario = IdUsuario;
            Procesar.FechaGuardado = FechaGuardado;
            Procesar.InicioVigencia = InicioVigencia;
            Procesar.FinVigencia = FinVigencia;
            Procesar.Estatus0 = Estatus;
            Procesar.FechaNuevaLLamada0 = FechaNuevaLLamada;
            Procesar.HoraNuevaLLamada = HoraNuevaLLamada;


            var MAN = ObjData.ProcesarPolizasGestionCobros(Procesar, Accion);
        }
    }
}
