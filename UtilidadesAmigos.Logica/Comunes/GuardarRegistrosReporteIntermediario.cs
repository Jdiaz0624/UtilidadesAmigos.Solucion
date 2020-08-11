using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes
{
  


    public class GuardarRegistrosReporteIntermediario
    {
        public readonly Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Data = new Lazy<Logica.LogicaSistema>();


        private decimal IdUsuario = 0;
        private string Poliza = "";
        private string NoFactura = "";
        private DateTime FechaSinFormato = DateTime.Now;
        private string Mes = "";
        private string Fecha = "";
        private decimal Valor = 0;
        private string Cliente = "";
        private string Vendedor = "";
        private string Cobreaor = "";
        private string Concepto = "";
        private decimal Balance = 0;
        private string NCF = "";
        private decimal Tasa = 0;
        private string Moneda = "";
        private string Ofiicna = "";
        private decimal Total = 0;
        private string TipoVehiculo = "";
        private string Marca = "";
        private string Modelo = "";
        private string Capacidad = "";
        private string Ano = "";
        private string Color = "";
        private string Chasis = "";
        private string Placa = "";
        private string Uso = "";
        private decimal ValorVehiculo = 0;
        private string Accion = "";

        public GuardarRegistrosReporteIntermediario(
            decimal IdUsuarioCON,
            string PolizaCON,
            string NoFacturaCON,
            DateTime FechaSinFormatoCON,
            string MesCON,
            string FechaCON,
            decimal ValorCON,
            string ClienteCON,
            string VendedorCON,
            string CobreaorCON,
            string ConceptoCON,
            decimal BalanceCON,
            string NCFCON,
            decimal TasaCON,
            string MonedaCON,
            string OfiicnaCON,
            decimal TotalCON,
            string TipoVehiculoCON,
            string MarcaCON,
            string ModeloCON,
            string CapacidadCON,
            string AnoCON,
            string ColorCON,
            string ChasisCON,
            string PlacaCON,
            string UsoCON,
            decimal ValorVehiculoCON,
            string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            Poliza = PolizaCON;
            NoFactura = NoFacturaCON;
            FechaSinFormato = FechaSinFormatoCON;
            Mes = MesCON;
            Fecha = FechaCON;
            Valor = ValorCON;
            Cliente = ClienteCON;
            Vendedor = VendedorCON;
            Cobreaor = CobreaorCON;
            Concepto = ConceptoCON;
            Balance = BalanceCON;
            NCF = NCFCON;
            Tasa = TasaCON;
            Moneda = MonedaCON;
            Ofiicna = OfiicnaCON;
            Total = TotalCON;
            TipoVehiculo = TipoVehiculoCON;
            Marca = MarcaCON;
            Modelo = ModeloCON;
            Capacidad = CapacidadCON;
            Ano = AnoCON;
            Color = ColorCON;
            Chasis = ChasisCON;
            Placa = PlacaCON;
            Uso = UsoCON;
            ValorVehiculo = ValorVehiculoCON;
            Accion = AccionCON;
    }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.EGuardarRegistrosProduccionIntermediario Procesar = new Entidades.EGuardarRegistrosProduccionIntermediario();

            Procesar.IdUsuario = IdUsuario;
            Procesar.Poliza = Poliza;
            Procesar.NoFactura = NoFactura;
            Procesar.FechaSinFormato = FechaSinFormato;
            Procesar.Mes = Mes;
            Procesar.Fecha = Fecha;
            Procesar.Valor = Valor;
            Procesar.Cliente = Cliente;
            Procesar.Vendedor = Vendedor;
            Procesar.Cobreaor = Cobreaor;
            Procesar.Concepto = Concepto;
            Procesar.Balance = Balance;
            Procesar.NCF = NCF;
            Procesar.Tasa = Tasa;
            Procesar.Moneda = Moneda;
            Procesar.Ofiicna = Ofiicna;
            Procesar.Total = Total;
            Procesar.TipoVehiculo = TipoVehiculo;
            Procesar.Marca = Marca;
            Procesar.Modelo = Modelo;
            Procesar.Capacidad = Capacidad;
            Procesar.Ano = Ano;
            Procesar.Color = Color;
            Procesar.Chasis = Chasis;
            Procesar.Placa = Placa;
            Procesar.Uso = Uso;
            Procesar.ValorVehiculo = ValorVehiculo;

            var MAN = Data.Value.GaurdarRegistrosProduccionIntermediario(Procesar, Accion);
        }
    }
}
