using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Reportes
{
    public class ProcesarInformacionProduccuinPorUsuarioDetalle : UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido
    {
        private decimal IdUsuario = 0;
        private DateTime FechaDesde = DateTime.Now;
        private DateTime FechaHasta = DateTime.Now;
        private string Sucursal = "";
        private string Oficina = "";
        private string Departamento = "";
        private string Usuario = "";
        private string Concepto = "";
        private string Poliza = "";
        private decimal Monto = 0;
        private decimal TotalRegistros = 0;
        private decimal TotalValor = 0;
        private string Accion = "";

        public ProcesarInformacionProduccuinPorUsuarioDetalle(
            decimal IdUsuarioCON,
            DateTime FechaDesdeCON,
            DateTime FechaHastaCON,
            string SucursalCON,
            string OficinaCON,
            string DepartamentoCON,
            string UsuarioCON,
            string ConceptoCON,
            string PolizaCON,
            decimal MontoCON,
            decimal TotalRegistrosCON,
            decimal TotalValorCON,
            string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            FechaDesde = FechaDesdeCON;
            FechaHasta = FechaHastaCON;
            Sucursal = SucursalCON;
            Oficina = OficinaCON;
            Departamento = DepartamentoCON;
            Usuario = UsuarioCON;
            Concepto = ConceptoCON;
            Poliza = PolizaCON;
            Monto = MontoCON;
            TotalRegistros = TotalRegistrosCON;
            TotalValor = TotalValorCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacionProduccionUsuarioDetalle() {
            UtilidadesAmigos.Logica.Entidades.Reportes.EProduccionPorUsuarioDetalle Detalle = new Entidades.Reportes.EProduccionPorUsuarioDetalle();

            Detalle.IdUsuario = IdUsuario;
            Detalle.FechaDesde = FechaDesde;
            Detalle.FechaHasta = FechaHasta;
            Detalle.Sucursal = Sucursal;
            Detalle.Oficina = Oficina;
            Detalle.Departamento = Departamento;
            Detalle.Usuario = Usuario;
            Detalle.Concepto = Concepto;
            Detalle.Poliza = Poliza;
            Detalle.Monto = Monto;
            Detalle.TotalRegistros = TotalRegistros;
            Detalle.TotalValor = TotalValor;

            DataProduccionusuarioDetalle(Detalle, Accion);
        }
    }       
}           
            
            
            
            
            
            
            
            
            