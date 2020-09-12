using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Reportes
{
    public class ProcesarHistoricoImpresionMarbetes
    {
        public readonly UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos ObjDaata = new Logica.LogicaProcesos.LogicaProcesos();


        private decimal IdRegistro = 0;
        private string Poliza = "";
        private decimal Cotizacion = 0;
        private decimal CodigoCliente = 0;
        private int Secuencia = 0;
        private string NombreCliente = "";
        private string InicioVigencia = "";
        private string FinVigencia = "";
        private string Asegurado = "";
        private string TipoVehiculo = "";
        private string MarcaVehiculo = "";
        private string ModeloVehiculo = "";
        private string Chasis = "";
        private string Placa = "";
        private string Color = "";
        private string uso = "";
        private string Ano = "";
        private string Capacidad = "";
        private decimal ValorVehiculo = 0;
        private string FianzaJudicial = "";
        private string Vendedor = "";
        private string Grua = "";
        private string AeroAmbulancia = "";
        private string OtrosServicios = "";
        private string UsuarioImprime = "";
        private int TipoImpresion = 0;
        private int CantidadImpreso = 0;
        private string Accion = "";

        public ProcesarHistoricoImpresionMarbetes(
            decimal IdRegistroCON,
        string PolizaCON,
        decimal CotizacionCON,
        decimal CodigoClienteCON,
        int SecuenciaCON,
        string NombreClienteCON,
        string InicioVigenciaCON,
        string FinVigenciaCON,
        string AseguradoCON,
        string TipoVehiculoCON,
        string MarcaVehiculoCON,
        string ModeloVehiculoCON,
        string ChasisCON,
        string PlacaCON,
        string ColorCON,
        string usoCON,
        string AnoCON,
        string CapacidadCON,
        decimal ValorVehiculoCON,
        string FianzaJudicialCON,
        string VendedorCON,
        string GruaCON,
        string AeroAmbulanciaCON,
        string OtrosServiciosCON,
        string UsuarioImprimeCON,
        int TipoImpresionCON,
        int CantidadImpresoCON,
        string AccionCON)
        {
            IdRegistro = IdRegistroCON;
            Poliza = PolizaCON;
            Cotizacion = CotizacionCON;
            CodigoCliente = CodigoClienteCON;
            Secuencia = SecuenciaCON;
            NombreCliente = NombreClienteCON;
            InicioVigencia = InicioVigenciaCON;
            FinVigencia = FinVigenciaCON;
            Asegurado = AseguradoCON;
            TipoVehiculo = TipoVehiculoCON;
            MarcaVehiculo = MarcaVehiculoCON;
            ModeloVehiculo = ModeloVehiculoCON;
            Chasis = ChasisCON;
            Placa = PlacaCON;
            Color = ColorCON;
            uso = usoCON;
            Ano = AnoCON;
            Capacidad = CapacidadCON;
            ValorVehiculo = ValorVehiculoCON;
            FianzaJudicial = FianzaJudicialCON;
            Vendedor = VendedorCON;
            Grua = GruaCON;
            AeroAmbulancia = AeroAmbulanciaCON;
            OtrosServicios = OtrosServiciosCON;
            UsuarioImprime = UsuarioImprimeCON;
            TipoImpresion = TipoImpresionCON;
            CantidadImpreso = CantidadImpresoCON;
            Accion = AccionCON;
               
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Procesos.EProcesarHistoricoImprsionMarbete Procesar = new Entidades.Procesos.EProcesarHistoricoImprsionMarbete();

            Procesar.IdRegistro = IdRegistro;
            Procesar.Poliza = Poliza;
            Procesar.Cotizacion = Cotizacion;
            Procesar.CodigoCliente = CodigoCliente;
            Procesar.Secuencia = Secuencia;
            Procesar.NombreCliente = NombreCliente;
            Procesar.InicioVigencia = InicioVigencia;
            Procesar.FinVigencia = FinVigencia;
            Procesar.Asegurado = Asegurado;
            Procesar.TipoVehiculo = TipoVehiculo;
            Procesar.MarcaVehiculo = MarcaVehiculo;
            Procesar.ModeloVehiculo = ModeloVehiculo;
            Procesar.Chasis = Chasis;
            Procesar.Placa = Placa;
            Procesar.Color = Color;
            Procesar.uso = uso;
            Procesar.Ano = Ano;
            Procesar.Capacidad = Capacidad;
            Procesar.ValorVehiculo = ValorVehiculo;
            Procesar.FianzaJudicial = FianzaJudicial;
            Procesar.Vendedor = Vendedor;
            Procesar.Grua = Grua;
            Procesar.AeroAmbulancia = AeroAmbulancia;
            Procesar.OtrosServicios = OtrosServicios;
            Procesar.UsuarioImprime = UsuarioImprime;
            Procesar.TipoImpresion = TipoImpresion;
            Procesar.CantidadImpreso = CantidadImpreso;

            var MAN = ObjDaata.MantenimientoHistoricoImpresionMarbete(Procesar, Accion);
        }
    }
}
