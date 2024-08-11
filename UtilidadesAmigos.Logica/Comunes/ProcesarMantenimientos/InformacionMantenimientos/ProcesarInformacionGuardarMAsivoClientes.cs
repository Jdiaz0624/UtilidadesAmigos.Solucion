using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionMantenimientos
{
    public class ProcesarInformacionGuardarMAsivoClientes
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos ObjDta = new Logica.LogicaMantenimientos.LogicaMantenimientos();


        private int Compania = 0;
        private decimal Codigo = 0;
        private int TipoCliente = 0;
        private int TipoRnc = 0;
        private string RNC = "";
        private string NombreCliente = "";
        private string Direccion = "";
        private int Ubicacion = 0;
        private decimal LimiteCredito = 0;
        private decimal Descuento = 0;
        private int Vendedor = 0;
        private int Cobrador = 0;
        private int Facturacion = 0;
        private int CondicionPago = 0;
        private string UsuarioAdiciona = "";
        private int Estatus = 0;
        private DateTime Fecha_ingreso = DateTime.Now;
        private DateTime FechaUltPago = DateTime.Now;
        private decimal MontoUltPago = 0;
        private decimal Balance = 0;
        private DateTime FechaAdiciona = DateTime.Now;
        private string UsuarioModifica = "";
        private DateTime FechaModifica = DateTime.Now;
        private string TelefonoResidencia = "";
        private string TelefonoOficina = "";
        private string fax = "";
        private string Beeper = "";
        private string Email = "";
        private string Celular = "";
        private int CodigoRnc = 0;
        private int Consorcio = 0;
        private int Ncf = 0;
        private string Nombre = "";
        private string Apellidos = "";
        private DateTime FechaNacimiento = DateTime.Now;
        private DateTime FechaLicencia = DateTime.Now;
        private int Itbis = 0;
        private string Contacto = "";
        private int Sexo = 0;
        private string Comentario = "";
        private string Nacionalidad = "";
        private int TipoRnc1 = 0;
        private string Rnc1 = "";
        private int TipoRnc2 = 0;
        private string Rnc2 = "";
        private string ClaseCliente = "";
        private string LugarTrabajo = "";
        private string CargoTrabajo = "";
        private decimal IngresoSalarial = 0;
        private string EstadoCivil = "";
        private string Ocupacion = "";
        private string Accion = "";

        public ProcesarInformacionGuardarMAsivoClientes(
        int CompaniaCON,
        decimal CodigoCON,
        int TipoClienteCON,
        int TipoRncCON,
        string RNCCON,
        string NombreClienteCON,
        string DireccionCON,
        int UbicacionCON,
        decimal LimiteCreditoCON,
        decimal DescuentoCON,
        int VendedorCON,
        int CobradorCON,
        int FacturacionCON,
        int CondicionPagoCON,
        string UsuarioAdicionaCON,
        int EstatusCON,
        DateTime Fecha_ingresoCON,
        DateTime FechaUltPagoCON,
        decimal MontoUltPagoCON,
        decimal BalanceCON,
        DateTime FechaAdicionaCON,
        string UsuarioModificaCON,
        DateTime FechaModificaCON,
        string TelefonoResidenciaCON,
        string TelefonoOficinaCON,
        string faxCON,
        string BeeperCON,
        string EmailCON,
        string CelularCON,
        int CodigoRncCON,
        int ConsorcioCON,
        int NcfCON,
        string NombreCON,
        string ApellidosCON,
        DateTime FechaNacimientoCON,
        DateTime FechaLicenciaCON,
        int ItbisCON,
        string ContactoCON,
        int SexoCON,
        string ComentarioCON,
        string NacionalidadCON,
        int TipoRnc1CON,
        string Rnc1CON,
        int TipoRnc2CON,
        string Rnc2CON,
        string ClaseClienteCON,
        string LugarTrabajoCON,
        string CargoTrabajoCON,
        decimal IngresoSalarialCON,
        string EstadoCivilCON,
        string OcupacionCON,
        string AccionCON)
        {
            Compania = CompaniaCON;
            Codigo = CodigoCON;
            TipoCliente = TipoClienteCON;
            TipoRnc = TipoRncCON;
            RNC = RNCCON;
            NombreCliente = NombreClienteCON;
            Direccion = DireccionCON;
            Ubicacion = UbicacionCON;
            LimiteCredito = LimiteCreditoCON;
            Descuento = DescuentoCON;
            Vendedor = VendedorCON;
            Cobrador = CobradorCON;
            Facturacion = FacturacionCON;
            CondicionPago = CondicionPagoCON;
            UsuarioAdiciona = UsuarioAdicionaCON;
            Estatus = EstatusCON;
            Fecha_ingreso = Fecha_ingresoCON;
            FechaUltPago = FechaUltPagoCON;
            MontoUltPago = MontoUltPagoCON;
            Balance = BalanceCON;
            FechaAdiciona = FechaAdicionaCON;
            UsuarioModifica = UsuarioModificaCON;
            FechaModifica = FechaModificaCON;
            TelefonoResidencia = TelefonoResidenciaCON;
            TelefonoOficina = TelefonoOficinaCON;
            fax = faxCON;
            Beeper = BeeperCON;
            Email = EmailCON;
            Celular = CelularCON;
            CodigoRnc = CodigoRncCON;
            Consorcio = ConsorcioCON;
            Ncf = NcfCON;
            Nombre = NombreCON;
            Apellidos = ApellidosCON;
            FechaNacimiento = FechaNacimientoCON;
            FechaLicencia = FechaLicenciaCON;
            Itbis = ItbisCON;
            Contacto = ContactoCON;
            Sexo = SexoCON;
            Comentario = ComentarioCON;
            Nacionalidad = NacionalidadCON;
            TipoRnc1 = TipoRnc1CON;
            Rnc1 = Rnc1CON;
            TipoRnc2 = TipoRnc2CON;
            Rnc2 = Rnc2CON;
            ClaseCliente = ClaseClienteCON;
            LugarTrabajo = LugarTrabajoCON;
            CargoTrabajo = CargoTrabajoCON;
            IngresoSalarial = IngresoSalarialCON;
            EstadoCivil = EstadoCivilCON;
            Ocupacion = OcupacionCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EGuardarClientesMasivos Guardar = new Entidades.Mantenimientos.EGuardarClientesMasivos();

             Guardar.Compania = 30;
             Guardar.Codigo = Codigo;
             Guardar.TipoCliente = TipoCliente;
             Guardar.TipoRnc = 1;
             Guardar.RNC = RNC;
             Guardar.NombreCliente = NombreCliente;
             Guardar.Direccion = Direccion;
             Guardar.Ubicacion = Ubicacion;
             Guardar.LimiteCredito = LimiteCredito;
             Guardar.Descuento = Descuento;
             Guardar.Vendedor = Vendedor;
             Guardar.Cobrador = Cobrador;
             Guardar.Facturacion = Facturacion;
             Guardar.CondicionPago = 30;
             Guardar.UsuarioAdiciona = "AUTOMATICO - INTERMEDIARIO";
             Guardar.Estatus = 1;
             Guardar.Fecha_ingreso = DateTime.Now;
             Guardar.FechaUltPago = DateTime.Now;
             Guardar.MontoUltPago = 0;
             Guardar.Balance = 0;
             Guardar.FechaAdiciona = DateTime.Now;
             Guardar.UsuarioModifica = "AUTOMATICO - INTERMEDIARIO";
             Guardar.FechaModifica = DateTime.Now;
             Guardar.TelefonoResidencia = TelefonoResidencia;
             Guardar.TelefonoOficina = TelefonoOficina;
             Guardar.fax = fax;
             Guardar.Beeper = Beeper;
             Guardar.Email = Email;
             Guardar.Celular = Celular;
             Guardar.CodigoRnc = 0;
             Guardar.Consorcio = 0;
             Guardar.Ncf = 7;
             Guardar.Nombre = Nombre;
             Guardar.Apellidos = Apellidos;
             Guardar.FechaNacimiento = FechaNacimiento;
             Guardar.FechaLicencia = FechaLicencia;
             Guardar.Itbis = 0;
             Guardar.Contacto = "AUTOMATICO - INTERMEDIARIO";
             Guardar.Sexo = (byte)Sexo;
             Guardar.Comentario = Comentario;
             Guardar.Nacionalidad = Nacionalidad;
             Guardar.TipoRnc1 = (byte)TipoRnc1;
             Guardar.Rnc1 = Rnc1;
             Guardar.TipoRnc2 = (byte)TipoRnc2;
             Guardar.Rnc2 = Rnc2;
             Guardar.ClaseCliente = "Persona Natural";
             Guardar.LugarTrabajo = LugarTrabajo;
             Guardar.CargoTrabajo = CargoTrabajo;
             Guardar.IngresoSalarial = IngresoSalarial;
             Guardar.EstadoCivil = EstadoCivil;
             Guardar.Ocupacion = Ocupacion;

            var MAN = ObjDta.GaurdarClienteMasivo(Guardar, Accion);
        }
    }
}
