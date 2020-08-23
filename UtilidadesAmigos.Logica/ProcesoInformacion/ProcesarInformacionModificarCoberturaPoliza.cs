using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.ProcesoInformacion
{
    public class ProcesarInformacionModificarCoberturaPoliza
    {
        public readonly Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Data = new Lazy<Logica.LogicaSistema>();

        private int Compania = 0;
        private decimal Cotizacion = 0;
        private int Ramo = 0;
        private int SubRamo = 0;
        private int SecuenciaCot = 0;
        private int Secuencia = 0;
        private string Descripcion = "";
        private string MontoInformativo = "";
        private string TieneCobertura = "";
        private decimal Porciento = 0;
        private decimal Prima = 0;
        private decimal PorcDeducible = 0;
        private decimal MinimoDeducible = 0;
        private string Endoso = "";
        private decimal PorcCobertura = 0;
        private decimal ValorServicio = 0;
        private string Accion = "";

        //CREAMOS UN CONSTRUCTOR PARA PROCESAR LA INFORMACION

        public ProcesarInformacionModificarCoberturaPoliza(
            int CompaniaCON,
            decimal CotizacionCON,
            int RamoCON,
            int SubRamoCON,
            int SecuenciaCotCON,
            int SecuenciaCON,
            string DescripcionCON,
            string MontoInformativoCON,
            string TieneCoberturaCON,
            decimal PorcientoCON,
            decimal PrimaCON,
            decimal PorcDeducibleCON,
            decimal MinimoDeducibleCON,
            string EndosoCON,
            decimal PorcCoberturaCON,
            decimal ValorServicioCON,
            string AccionCON)
        {
            Compania = CompaniaCON;
            Cotizacion = CotizacionCON;
            Ramo = RamoCON;
            SubRamo = SubRamoCON;
            SecuenciaCot = SecuenciaCotCON;
            Secuencia = SecuenciaCON;
            Descripcion = DescripcionCON;
            MontoInformativo = MontoInformativoCON;
            TieneCobertura = TieneCoberturaCON;
            Porciento = PorcientoCON;
            Prima = PrimaCON;
            PorcDeducible = PorcDeducibleCON;
            MinimoDeducible = MinimoDeducibleCON;
            Endoso = EndosoCON;
            PorcCobertura = PorcCoberturaCON;
            ValorServicio = ValorServicioCON;
            Accion = AccionCON;
        }

        public void ModificarCoberturas() {
            UtilidadesAmigos.Logica.Entidades.EModificarCoberturasPolizas Modificar = new Entidades.EModificarCoberturasPolizas();

            Modificar.Compania = Compania;
            Modificar.Cotizacion = Cotizacion;
            Modificar.Ramo = Ramo;
            Modificar.SubRamo = SubRamo;
            Modificar.SecuenciaCot = SecuenciaCot;
            Modificar.Secuencia = Secuencia;
            Modificar.Descripcion = Descripcion;
            Modificar.MontoInformativo = MontoInformativo;
            Modificar.TieneCobertura = Convert.ToChar(TieneCobertura);
            Modificar.Porciento=Porciento;
            Modificar.Prima = Prima;
            Modificar.PorcDeducible = PorcDeducible;
            Modificar.MinimoDeducible = MinimoDeducible;
            Modificar.Endoso = Endoso;
            Modificar.PorcCobertura = PorcCobertura;
            Modificar.ValorServicio = ValorServicio;


            var MAN = Data.Value.ModificarCoberturasPolizas(Modificar, Accion);
            
        }

    }
}
