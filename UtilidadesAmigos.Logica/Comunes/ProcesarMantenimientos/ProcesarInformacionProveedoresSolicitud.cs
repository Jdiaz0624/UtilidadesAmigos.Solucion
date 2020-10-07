using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionProveedoresSolicitud
    {

        readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos ObjData = new Logica.LogicaMantenimientos.LogicaMantenimientos();

        private int Compania = 0;
        private int Codigo = 0;
        private int TipoCliente = 0;
        private int TipoRnc = 0;
        private string RNC = "";
        private string NombreCliente = "";
        private string Direccion = "";
        private int Ubicacion = 0;
        private decimal LimiteCredito = 0;
        private decimal Descuento = 0;
        private int CondicionPago = 0;
        private int Estatus = 0;
        private DateTime FechaUltPago = DateTime.Now;
        private decimal MontoUltPago = 0;
        private decimal Balance = 0;
        private string UsuarioAdiciona = "";
        private DateTime FechaAdiciona = DateTime.Now;
        private string UsuarioModifica = "";
        private DateTime FechaModifica = DateTime.Now;
        private int CodigoRnc = 0;
        private decimal PorcComision = 0;
        private int CodMoneda = 0;
        private string TelefonoCasa = "";
        private string TelefonoOficina = "";
        private string Celular = "";
        private string Fax = "";
        private string Beeper = "";
        private string Email = "";
        private int TipoPago = 0;
        private int Banco = 0;
        private string CuentaBanco = "";
        private string Contacto = "";
        private string TipoCuentaBanco = "";
        private string ClaseProveedor = "";
        private string Accion = "";

        public ProcesarInformacionProveedoresSolicitud(
            int CompaniaCON,
        int CodigoCON,
        int TipoClienteCON,
        int TipoRncCON,
        string RNCCON,
        string NombreClienteCON,
        string DireccionCON,
        int UbicacionCON,
        decimal LimiteCreditoCON,
        decimal DescuentoCON,
        int CondicionPagoCON,
        int EstatusCON,
        DateTime FechaUltPagoCON,
        decimal MontoUltPagoCON,
        decimal BalanceCON,
        string UsuarioAdicionaCON,
        DateTime FechaAdicionaCON,
        string UsuarioModificaCON,
        DateTime FechaModificaCON,
        int CodigoRncCON,
        decimal PorcComisionCON,
        int CodMonedaCON,
        string TelefonoCasaCON,
        string TelefonoOficinaCON,
        string CelularCON,
        string FaxCON,
        string BeeperCON,
        string EmailCON,
        int TipoPagoCON,
        int BancoCON,
        string CuentaBancoCON,
        string ContactoCON,
        string TipoCuentaBancoCON,
        string ClaseProveedorCON,
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
            CondicionPago = CondicionPagoCON;
            Estatus = EstatusCON;
            FechaUltPago = FechaUltPagoCON;
            MontoUltPago = MontoUltPagoCON;
            Balance = BalanceCON;
            UsuarioAdiciona = UsuarioAdicionaCON;
            FechaAdiciona = FechaAdicionaCON;
            UsuarioModifica = UsuarioModificaCON;
            FechaModifica = FechaModificaCON;
            CodigoRnc = CodigoRncCON;
            PorcComision = PorcComisionCON;
            CodMoneda = CodMonedaCON;
            TelefonoCasa = TelefonoCasaCON;
            TelefonoOficina = TelefonoOficinaCON;
            Celular = CelularCON;
            Fax = FaxCON;
            Beeper = BeeperCON;
            Email = EmailCON;
            TipoPago = TipoPagoCON;
            Banco = BancoCON;
            CuentaBanco = CuentaBancoCON;
            Contacto = ContactoCON;
            TipoCuentaBanco = TipoCuentaBancoCON;
            ClaseProveedor = ClaseProveedorCON;
            Accion = AccionCON;
    }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMantenimientoProveedoresSolicitud Procesar = new Entidades.Mantenimientos.EMantenimientoProveedoresSolicitud();

            Procesar.Compania = Convert.ToByte(Compania);
            Procesar.Codigo = 0;
            Procesar.TipoCliente = TipoCliente;
            Procesar.TipoRnc = Convert.ToByte(TipoRnc);
            Procesar.RNC = RNC;
            Procesar.NombreCliente = NombreCliente;
            Procesar.Direccion = Direccion;
            Procesar.Ubicacion = Ubicacion;
            Procesar.LimiteCredito = LimiteCredito;
            Procesar.Descuento = Descuento;
            Procesar.CondicionPago = Convert.ToByte(CondicionPago);
            Procesar.Estatus = Convert.ToByte(Estatus);
            Procesar.FechaUltPago = FechaUltPago;
            Procesar.MontoUltPago = MontoUltPago;
            Procesar.Balance = Balance;
            Procesar.UsuarioAdiciona = UsuarioAdiciona;
            Procesar.FechaAdiciona = FechaAdiciona;
            Procesar.UsuarioModifica = UsuarioModifica;
            Procesar.FechaModifica = FechaModifica;
            Procesar.CodigoRnc = CodigoRnc;
            Procesar.PorcComision = PorcComision;
            Procesar.CodMoneda = CodMoneda;
            Procesar.TelefonoCasa = TelefonoCasa;
            Procesar.TelefonoOficina = TelefonoOficina;
            Procesar.Celular = Celular;
            Procesar.Fax = Fax;
            Procesar.Beeper = Beeper;
            Procesar.Email = Email;
            Procesar.TipoPago = Convert.ToByte(TipoPago);
            Procesar.Banco = Banco;
            Procesar.CuentaBanco = CuentaBanco;
            Procesar.Contacto = Contacto;
            Procesar.TipoCuentaBanco = TipoCuentaBanco;
            Procesar.ClaseProveedor = ClaseProveedor;

            var MAN = ObjData.MantenimientoProveedoresSolicitud(Procesar, Accion);

        }
    }
}
