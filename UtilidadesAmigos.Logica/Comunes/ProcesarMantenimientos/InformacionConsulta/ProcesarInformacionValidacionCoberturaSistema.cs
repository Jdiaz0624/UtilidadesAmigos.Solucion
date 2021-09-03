using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta
{
    public class ProcesarInformacionValidacionCoberturaSistema
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta ObjData = new Logica.LogicaConsulta.LogicaConsulta();

        private decimal NumeroRegistro = 0;
        private decimal IdUsuario = 0;
        private string Poliza = "";
        private int Items = 0;
        private string Estatus = "";
        private string Concepto = "";
        private string Cliente = "";
        private string NombreCliente = "";
        private string ApellidoCliente = "";
        private string Ciudad = "";
        private string DireccionCliente = "";
        private string Telefono = "";
        private string TipoIdentificacion = "";
        private string NumeroIdentificacion = "";
        private string Intermediario = "";
        private DateTime FechaInicioVigencia = DateTime.Now;
        private DateTime FechaFinVigencia = DateTime.Now;
        private string InicioVigencia = "";
        private string FinVigencia = "";
        private string FechaProceso = "";
        private DateTime FechaProcesoBruto = DateTime.Now;
        private string MesValidado = "";
        private string TipoVehiculo = "";
        private string Marca = "";
        private string Modelo = "";
        private string Capacidad = "";
        private string Ano = "";
        private string Color = "";
        private string Chasis = "";
        private string Placa = "";
        private decimal ValorAsegurado = 0;
        private string Cobertura = "";
        private string TipoMovimiento = "";
        private int CantidadRegistros = 0;
        private string ValidadoDesde = "";
        private string ValidadoHasta = "";
        private string GeneradoPor = "";
        private string Oficina = "";
        private string Accion = "";

        public ProcesarInformacionValidacionCoberturaSistema(
            decimal NumeroRegistroCON,
        decimal IdUsuarioCON,
        string PolizaCON,
        int ItemsCON,
        string EstatusCON,
        string ConceptoCON,
        string ClienteCON,
        string NombreClienteCON,
        string ApellidoClienteCON,
        string CiudadCON,
        string DireccionClienteCON,
        string TelefonoCON,
        string TipoIdentificacionCON,
        string NumeroIdentificacionCON,
        string IntermediarioCON,
        DateTime FechaInicioVigenciaCON,
        DateTime FechaFinVigenciaCON,
        string InicioVigenciaCON,
        string FinVigenciaCON,
        string FechaProcesoCON,
        DateTime FechaProcesoBrutoCON,
        string MesValidadoCON,
        string TipoVehiculoCON,
        string MarcaCON,
        string ModeloCON,
        string CapacidadCON,
        string AnoCON,
        string ColorCON,
        string ChasisCON,
        string PlacaCON,
        decimal ValorAseguradoCON,
        string CoberturaCON,
        string TipoMovimientoCON,
        int CantidadRegistrosCON,
        string ValidadoDesdeCON,
        string ValidadoHastaCON,
        string GeneradoPorCON,
        string OficinaCON,
        string AccionCON)
        {
            NumeroRegistro = NumeroRegistroCON;
            IdUsuario = IdUsuarioCON;
            Poliza = PolizaCON;
            Items = ItemsCON;
            Estatus = EstatusCON;
            Concepto = ConceptoCON;
            Cliente = ClienteCON;
            NombreCliente = NombreClienteCON;
            ApellidoCliente = ApellidoClienteCON;
            Ciudad = CiudadCON;
            DireccionCliente = DireccionClienteCON;
            Telefono = TelefonoCON;
            TipoIdentificacion = TipoIdentificacionCON;
            NumeroIdentificacion = NumeroIdentificacionCON;
            Intermediario = IntermediarioCON;
            FechaInicioVigencia = FechaInicioVigenciaCON;
            FechaFinVigencia = FechaFinVigenciaCON;
            InicioVigencia = InicioVigenciaCON;
            FinVigencia = FinVigenciaCON;
            FechaProceso = FechaProcesoCON;
            FechaProcesoBruto = FechaProcesoBrutoCON;
            MesValidado = MesValidadoCON;
            TipoVehiculo = TipoVehiculoCON;
            Marca = MarcaCON;
            Modelo = ModeloCON;
            Capacidad = CapacidadCON;
            Ano = AnoCON;
            Color = ColorCON;
            Chasis = ChasisCON;
            Placa = PlacaCON;
            ValorAsegurado = ValorAseguradoCON;
            Cobertura = CoberturaCON;
            TipoMovimiento = TipoMovimientoCON;
            CantidadRegistros = CantidadRegistrosCON;
            ValidadoDesde = ValidadoDesdeCON;
            ValidadoHasta = ValidadoHastaCON;
            GeneradoPor = GeneradoPorCON;
            Oficina = OficinaCON;
            Accion = AccionCON;
        }

        /// <summary>
        /// Este metodo es para procesar la información de los registros sacados del sistema.
        /// </summary>
        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Consulta.EProcesarInformacionValidacionCoberturaSistema Procesar = new Entidades.Consulta.EProcesarInformacionValidacionCoberturaSistema();

            Procesar.NumeroRegistro = NumeroRegistro;
            Procesar.IdUsuario = IdUsuario;
            Procesar.Poliza = Poliza;
            Procesar.Items = Items;
            Procesar.Estatus = Estatus;
            Procesar.Concepto = Concepto;
            Procesar.Cliente = Cliente;
            Procesar.NombreCliente = NombreCliente;
            Procesar.ApellidoCliente = ApellidoCliente;
            Procesar.Ciudad = Ciudad;
            Procesar.DireccionCliente = DireccionCliente;
            Procesar.Telefono = Telefono;
            Procesar.TipoIdentificacion = TipoIdentificacion;
            Procesar.NumeroIdentificacion = NumeroIdentificacion;
            Procesar.Intermediario = Intermediario;
            Procesar.FechaInicioVigencia = FechaInicioVigencia;
            Procesar.FechaFinVigencia = FechaFinVigencia;
            Procesar.InicioVigencia = InicioVigencia;
            Procesar.FinVigencia = FinVigencia;
            Procesar.FechaProceso = FechaProceso;
            Procesar.FechaProcesoBruto = FechaProcesoBruto;
            Procesar.MesValidado = MesValidado;
            Procesar.TipoVehiculo = TipoVehiculo;
            Procesar.Marca = Marca;
            Procesar.Modelo = Modelo;
            Procesar.Capacidad = Capacidad;
            Procesar.Ano = Ano;
            Procesar.Color = Color;
            Procesar.Chasis = Chasis;
            Procesar.Placa = Placa;
            Procesar.ValorAsegurado = ValorAsegurado;
            Procesar.Cobertura = Cobertura;
            Procesar.TipoMovimiento = TipoMovimiento;
            Procesar.CantidadRegistros = CantidadRegistros;
            Procesar.ValidadoDesde = ValidadoDesde;
            Procesar.ValidadoHasta = ValidadoHasta;
            Procesar.GeneradoPor = GeneradoPor;
            Procesar.Oficina = Oficina;

            var MAn = ObjData.ProcesarValidacionCoberturaArchivo(Procesar, Accion);


        }
    }
}
