using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionImpresionMarbetes : UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos
    {
     
        private decimal IdUsuario = 0;
        private string Poliza="";
        private decimal Cotizacion = 0;
        private decimal CodigoCliente = 0;
        private int Secuencia = 0;
        private string NombreCliente = "";
        private string InicioVigencia = "";
        private string FinVigencia = "";
        private string Asegurado = "";
        private string TipoVehiculo = "";
        private string Marca = "";
        private string Modelo = "";
        private string Chasis = "";
        private string Placa = "";
        private string Color = "";
        private string Uso = "";
        private string Ano = "";
        private string Capacidad = "";
        private decimal ValorVehiculo = 0;
        private string FianzaJudicial = "";
        private string Vendedor = "";
        private string Grua = "";
        private string AeroAmbulancia = "";
        private string OtrosServicios = "";
        private int CantidadRegistros = 0;
        private string Accion = "";

        public ProcesarInformacionImpresionMarbetes(
        decimal IdUsuarioCON,
        string PolizaCON,
        decimal CotizacionCON,
        decimal CodigoClienteCON,
        int SecuenciaCON,
        string NombreClienteCON,
        string InicioVigenciaCON,
        string FinVigenciaCON,
        string AseguradoCON,
        string TipoVehiculoCON,
        string MarcaCON,
        string ModeloCON,
        string ChasisCON,
        string PlacaCON,
        string ColorCON,
        string UsoCON,
        string AnoCON,
        string CapacidadCON,
        decimal ValorVehiculoCON,
        string FianzaJudicialCON,
        string VendedorCON,
        string GruaCON,
        string AeroAmbulanciaCON,
        string OtrosServiciosCON,
        int CantidadRegistrosCON,
        string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            Poliza = PolizaCON;
            Cotizacion = CotizacionCON;
            CodigoCliente = CodigoClienteCON;
            Secuencia = SecuenciaCON;
            NombreCliente = NombreClienteCON;
            InicioVigencia = InicioVigenciaCON;
            FinVigencia = FinVigenciaCON;
            Asegurado = AseguradoCON;
            TipoVehiculo = TipoVehiculoCON;
            Marca = MarcaCON;
            Modelo = ModeloCON;
            Chasis = ChasisCON;
            Placa = PlacaCON;
            Color = ColorCON;
            Uso = UsoCON;
            Ano = AnoCON;
            Capacidad = CapacidadCON;
            ValorVehiculo = ValorVehiculoCON;
            FianzaJudicial = FianzaJudicialCON;
            Vendedor = VendedorCON;
            Grua = GruaCON;
            AeroAmbulancia = AeroAmbulanciaCON;
            OtrosServicios = OtrosServiciosCON;
            CantidadRegistros = CantidadRegistrosCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Procesos.EProcesarInformacionMarbetes Procesar = new Entidades.Procesos.EProcesarInformacionMarbetes();

            Procesar.IdUsuario = IdUsuario;
            Procesar.Poliza = Poliza;
            Procesar.Cotizacion = Cotizacion;
            Procesar.CodigoCliente = CodigoCliente;
            Procesar.Secuencia = Secuencia;
            Procesar.NombreCliente = NombreCliente;
            Procesar.InicioVigencia = InicioVigencia;
            Procesar.FinVigencia = FinVigencia;
            Procesar.Asegurado = Asegurado;
            Procesar.TipoVehiculo = TipoVehiculo;
            Procesar.Marca = Marca;
            Procesar.Modelo = Modelo;
            Procesar.Chasis = Chasis;
            Procesar.Placa = Placa;
            Procesar.Color = Color;
            Procesar.Uso = Uso;
            Procesar.Ano = Ano;
            Procesar.Capacidad = Capacidad;
            Procesar.ValorVehiculo = ValorVehiculo;
            Procesar.FianzaJudicial = FianzaJudicial;
            Procesar.Vendedor = Vendedor;
            Procesar.Grua = Grua;
            Procesar.AeroAmbulancia = AeroAmbulancia;
            Procesar.OtrosServicios = OtrosServicios;
            Procesar.CantidadRegistros = CantidadRegistros;

            ProcesarImpresionMarbete(Procesar, Accion);
        }
    }
}
