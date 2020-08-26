using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Reportes
{
    public class ProcesarProduccionPorUsuarioResumido : UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido
    {
        private decimal IdUsuario = 0;
        private string Sucursal = "";
        private string Oficina = "";
        private string Departaemnto = "";
        private string Usuario = "";
        private string Concepto = "";
        private decimal Cantidad = 0;
        private decimal Total = 0;
        private int TipoMovimiento = 0;
        private decimal TotalRegistros = 0;
        private decimal TotalPrima = 0;
        private DateTime FechaDesde = DateTime.Now;
        private DateTime FechaHasta = DateTime.Now;
        private string Accion = "";

        public ProcesarProduccionPorUsuarioResumido(
            decimal IdUsuarioCON,
            string SucursalCON,
            string OficinaCON,
            string DepartaemntoCON,
            string UsuarioCON,
            string ConceptoCON,
            decimal CantidadCON,
            decimal TotalCON,
            int TipoMovimientoCON,
            decimal TotalRegistrosCON,
            decimal TotalPrimaCON,
            DateTime FechaDesdeCON,
            DateTime FechaHastaCON,
            string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            Sucursal = SucursalCON;
            Oficina = OficinaCON;
            Departaemnto = DepartaemntoCON;
            Usuario = UsuarioCON;
            Concepto = ConceptoCON;
            Cantidad = CantidadCON;
            Total = TotalCON;
            TipoMovimiento = TipoMovimientoCON;
            TotalRegistros = TotalRegistrosCON;
            TotalPrima = TotalPrimaCON;
            FechaDesde = FechaDesdeCON;
            FechaHasta = FechaHastaCON;
            Accion = AccionCON;
             
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Reportes.EProduccionPorusuarioResumido Procesar = new Entidades.Reportes.EProduccionPorusuarioResumido();

            Procesar.IdUsuario = IdUsuario;
            Procesar.Sucursal = Sucursal;
            Procesar.Oficina = Oficina;
            Procesar.Departaemnto = Departaemnto;
            Procesar.Usuario = Usuario;
            Procesar.Concepto = Concepto;
            Procesar.Cantidad = Cantidad;
            Procesar.Total = Total;
            Procesar.TipoMovimiento = TipoMovimiento;
            Procesar.TotalRegistros = TotalRegistros;
            Procesar.TotalPrima = TotalPrima;
            Procesar.FechaDesde = FechaDesde;
            Procesar.FechaHasta = FechaHasta;

            GuardarDatosProduccionPorUsuarioResumido(Procesar, Accion);
            
        }
    }
}
