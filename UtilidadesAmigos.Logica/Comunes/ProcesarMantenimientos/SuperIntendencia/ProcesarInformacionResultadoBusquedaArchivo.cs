using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.SuperIntendencia
{
    public class ProcesarInformacionResultadoBusquedaArchivo
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSuperIntendencia.LogicaSuperIntendencia ObjData = new Logica.LogicaSuperIntendencia.LogicaSuperIntendencia();

        private decimal IdUsuario = 0;
        private string Nombre = "";
        private string NumeroIdentificacion = "";
        private string Poliza = "";
        private string Reclamacion = "";
        private string Estatus = "";
        private string Ramo = "";
        private decimal MontoAsegurado = 0;
        private decimal Prima = 0;
        private DateTime InicioVigencia = DateTime.Now;
        private DateTime FinVigencia = DateTime.Now;
        private string TipoBusqueda = "";
        private string EncontradoComo = "";
        private string Comentario = "";
        private string Accion = "";

        public ProcesarInformacionResultadoBusquedaArchivo(
            decimal IdUsuarioCON,
            string NombreCON,
            string NumeroIdentificacionCON,
            string PolizaCON,
            string ReclamacionCON,
            string EstatusCON,
            string RamoCON,
            decimal MontoAseguradoCON,
            decimal PrimaCON,
            DateTime InicioVigenciaCON,
            DateTime FinVigenciaCON,
            string TipoBusquedaCON,
            string EncontradoComoCON,
            string ComentarioCON,
            string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            Nombre = NombreCON;
            NumeroIdentificacion = NumeroIdentificacionCON;
            Poliza = PolizaCON;
            Reclamacion = ReclamacionCON;
            Estatus = EstatusCON;
            Ramo = RamoCON;
            MontoAsegurado = MontoAseguradoCON;
            Prima = PrimaCON;
            InicioVigencia = InicioVigenciaCON;
            FinVigencia = FinVigenciaCON;
            TipoBusqueda = TipoBusquedaCON;
            EncontradoComo = EncontradoComoCON;
            Comentario = ComentarioCON;
            Accion = AccionCON;
        }

        /// <summary>
        /// Este metodo es para procesar la informacion del archivo
        /// </summary>
        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.SuperIntendencia.EProcesarDataResultadoBusquedaPersonaSuperIntendencia Procesar = new Entidades.SuperIntendencia.EProcesarDataResultadoBusquedaPersonaSuperIntendencia();

            Procesar.IdUsuario = IdUsuario;
            Procesar.Nombre = Nombre;
            Procesar.NumeroIdentificacion = NumeroIdentificacion;
            Procesar.Poliza = Poliza;
            Procesar.Reclamacion = Reclamacion;
            Procesar.Estatus = Estatus;
            Procesar.Ramo = Ramo;
            Procesar.MontoAsegurado = MontoAsegurado;
            Procesar.Prima = Prima;
            Procesar.InicioVigencia = InicioVigencia;
            Procesar.FinVigencia = FinVigencia;
            Procesar.TipoBusqueda = TipoBusqueda;
            Procesar.EncontradoComo = EncontradoComo;
            Procesar.Comentario = Comentario;

            var MAN = ObjData.ProcesarResultadoBusquedaSuperIntendencia(Procesar, Accion);
        
        }

    }
}
