using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilidadesAmigos.Logica.Entidades;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Reporte
{
    public class ProcesarInformacionConBalanceAgrupada
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido ObjData = new Logica.LogicaReportes.ProduccionPorUsuarioResumido();

        private decimal IdUsuario = 0;
        private int CodigoAgrupacion = 0;
        private string NombreAgrupacion = "";
        private decimal Facturado = 0;
        private decimal Cobrado = 0;
        private decimal Balance = 0;
        private string OficinaFiltro = "";
        private string Motores = "";
        private string CortadoA = "";
        private string GeneradoPor = "";
        private string TipoReporteGenerado = "";
        private int TipoReporteGenerar = 0;
        private string Poliza = "";
        private string Accion = "";

        public ProcesarInformacionConBalanceAgrupada(
        decimal IdUsuarioCON,
        int CodigoAgrupacionCON,
        string NombreAgrupacionCON,
        decimal FacturadoCON,
        decimal CobradoCON,
        decimal BalanceCON,
        string OficinaFiltroCON,
        string MotoresCON,
        string CortadoACON,
        string GeneradoPorCON,
        string TipoReporteGeneradoCON,
        int TipoReporteGenerarCON,
        string PolizaCON,
        string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            CodigoAgrupacion = CodigoAgrupacionCON;
            NombreAgrupacion = NombreAgrupacionCON;
            Facturado = FacturadoCON;
            Cobrado = CobradoCON;
            Balance = BalanceCON;
            OficinaFiltro = OficinaFiltroCON;
            Motores = MotoresCON;
            CortadoA = CortadoACON;
            GeneradoPor = GeneradoPorCON;
            TipoReporteGenerado = TipoReporteGeneradoCON;
            TipoReporteGenerar = TipoReporteGenerarCON;
            Poliza = PolizaCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Reportes.EprocesarInformacionPolizasConBalanceAgrupada Procesar = new Entidades.Reportes.EprocesarInformacionPolizasConBalanceAgrupada();

            Procesar.IdUsuario = IdUsuario;
            Procesar.CodigoAgrupacion = CodigoAgrupacion;
            Procesar.NombreAgrupacion = NombreAgrupacion;
            Procesar.Facturado = Facturado;
            Procesar.Cobrado = Cobrado;
            Procesar.Balance = Balance;
            Procesar.OficinaFiltro = OficinaFiltro;
            Procesar.Motores = Motores;
            Procesar.CortadoA = CortadoA;
            Procesar.GeneradoPor = GeneradoPor;
            Procesar.TipoReporteGenerado = TipoReporteGenerado;
            Procesar.TipoReporteGenerar = TipoReporteGenerar;
            Procesar.Poliza = Poliza;

            var MAN = ObjData.ProcesarInformacionPolizasConBalanceAgrupada(Procesar, Accion);
        }
    }
}
