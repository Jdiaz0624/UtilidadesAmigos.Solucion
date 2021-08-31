using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta
{
    public class ProcesarInformacionReporteComentarioGestionCobros
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta ObjData = new Logica.LogicaConsulta.LogicaConsulta();

        private decimal NumeroRegistro = 0;
        private string Poliza = "";
        private string Comentario = "";
        private decimal IdUsuario = 0;
        private string Usuario = "";
        private DateTime FechaProceso = DateTime.Now;
        private string Fecha = "";
        private string Hora = "";
        private int CantidadRegistros = 0;
        private decimal IdUsuarioGenera = 0;
        private string Accion = "";

        public ProcesarInformacionReporteComentarioGestionCobros(
            decimal NumeroRegistroCON,
            string PolizaCON,
            string ComentarioCON,
            decimal IdUsuarioCON,
            string UsuarioCON,
            DateTime FechaProcesoCON,
            string FechaCON,
            string HoraCON,
            int CantidadRegistrosCON,
            decimal IdUsuarioGeneraCON,
            string AccionCON)
        {
            NumeroRegistro = NumeroRegistroCON;
            Poliza = PolizaCON;
            Comentario = ComentarioCON;
            IdUsuario = IdUsuarioCON;
            Usuario = UsuarioCON;
            FechaProceso = FechaProcesoCON;
            Fecha = FechaCON;
            Hora = HoraCON;
            CantidadRegistros = CantidadRegistrosCON;
            IdUsuarioGenera = IdUsuarioGeneraCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarInformacionReporteComentarioGestionCobro Procesar = new Entidades.Consulta.EProcesarInformacionReporteComentarioGestionCobro();

            Procesar.NumeroRegistro = NumeroRegistro;
            Procesar.Poliza = Poliza;
            Procesar.Comentario = Comentario;
            Procesar.IdUsuario = IdUsuario;
            Procesar.Usuario = Usuario;
            Procesar.FechaProceso = FechaProceso;
            Procesar.Fecha = Fecha;
            Procesar.Hora = Hora;
            Procesar.CantidadRegistros = CantidadRegistros;
            Procesar.IdUsuarioGenera = IdUsuarioGenera;


            var MAN = ObjData.ProcesarComentarioGestionCobro(Procesar, Accion);
        }
    }
}
