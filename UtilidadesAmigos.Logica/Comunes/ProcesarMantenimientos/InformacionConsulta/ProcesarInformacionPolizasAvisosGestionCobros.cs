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

        decimal NumeroRegistro = 0;
        string Poliza = "";
        int IdEstatusLlamada = 0;
        int IdConceptoLlamada = 0;
        string Comentario = "";
        decimal IdUsuario = 0;
        DateTime FechaGuardado = DateTime.Now;
        string InicioVigencia = "";
        string FinVigencia = "";
        bool Estatus = false;
        string Accion = "";

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

            var MAN = ObjData.ProcesarPolizasGestionCobros(Procesar, Accion);
        }
    }
}
