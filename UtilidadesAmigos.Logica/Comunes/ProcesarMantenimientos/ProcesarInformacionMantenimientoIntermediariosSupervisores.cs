using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionMantenimientoIntermediariosSupervisores
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos ObjData = new Logica.LogicaMantenimientos.LogicaMantenimientos();

        //DECLARAMOS LAS VARIABLES PROVADAS PARA PROCESAR LA INFORMACION

        private int Compania = 0;
        private int Codigo = 0;
        private string Cuenta = "";
        private int Auxiliar = 0;
        private int TipoRnc = 0;
        private string Rnc = "";
        private string NombreVendedor = "";
        private decimal PorcientoComision = 0;
        private int CodigoSupervisor = 0;
        private int Estatus = 0;
        private DateTime Fecha_Entrada = DateTime.Now;
        private string UsuarioAdiciona = "";
        private DateTime FechaAdiciona = DateTime.Now;
        private string UsuarioModifica = "";
        private DateTime FechaModifica = DateTime.Now;
        private decimal PorcientoGastos = 0;
        private string nota = "";
        private string tipo_Intermediario = "";
        private string Agencia = "";
        private DateTime Fec_Nac = DateTime.Now;
        private string Publicidad = "";
        private string PagoComPor = "";
        private int Banco = 0;
        private string CtaBanco = "";
        private int CodigoRnc = 0;
        private string Retencion = "";
        private decimal PorcDescuento = 0;
        private int SupervisorCrea = 0;
        private int VendedorCrea = 0;
        private string Poliza = "";
        private string Direccion = "";
        private int Ubicacion = 0;
        private string Telefono = "";
        private string TelefonoOficina = "";
        private string Celular = "";
        private string Beeper = "";
        private string Fax = "";
        private string Email = "";
        private string LicenciaSeguro = "";
        private string CodigoAnterior = "";
        private string Apellido = "";
        private string Nombre = "";
        private int Oficina = 0;
        private string TipoCuentaBco = "";
        private int EjecutivoServicio = 0;
        private int AsumeCxc = 0;
        private int CodigoCliente = 0;
        private Guid Record_Id = Guid.NewGuid();
        private decimal PorcientoCapitalizacion = 0;
        private int Gestor = 0;
        private int EjecutivoCobros = 0;
        private int DiasCancelacionAutomatica = 0;
        private string Accion = "";


        //CREAMOS UN CONSTRUCTOR PARA PROCESAR TODA LA INFORMACION QUE LLEGE DE FUERA
        public ProcesarInformacionMantenimientoIntermediariosSupervisores(
        int CompaniaCON,
        int CodigoCON,
        string CuentaCON,
        int AuxiliarCON,
        int TipoRncCON,
        string RncCON,
        string NombreVendedorCON,
        decimal PorcientoComisionCON,
        int CodigoSupervisorCON,
        int EstatusCON,
        DateTime Fecha_EntradaCON,
        string UsuarioAdicionaCON,
        DateTime FechaAdicionaCON,
        string UsuarioModificaCON,
        DateTime FechaModificaCON,
        decimal PorcientoGastosCON,
        string notaCON,
        string tipo_IntermediarioCON,
        string AgenciaCON,
        DateTime Fec_NacCON,
        string PublicidadCON,
        string PagoComPorCON,
        int BancoCON,
        string CtaBancoCON,
        int CodigoRncCON,
        string RetencionCON,
        decimal PorcDescuentoCON,
        int SupervisorCreaCON,
        int VendedorCreaCON,
        string PolizaCON,
        string DireccionCON,
        int UbicacionCON,
        string TelefonoCON,
        string TelefonoOficinaCON,
        string CelularCON,
        string BeeperCON,
        string FaxCON,
        string EmailCON,
        string LicenciaSeguroCON,
        string CodigoAnteriorCON,
        string ApellidoCON,
        string NombreCON,
        int OficinaCON,
        string TipoCuentaBcoCON,
        int EjecutivoServicioCON,
        int AsumeCxcCON,
        int CodigoClienteCON,
        Guid Record_IdCON,
        decimal PorcientoCapitalizacionCON,
        int GestorCON,
        int EjecutivoCobrosCON,
        int DiasCancelacionAutomaticaCON,
        string AccionCON)
        {
            Compania = CompaniaCON;
            Codigo = CodigoCON;
            Cuenta = CuentaCON;
            Auxiliar = AuxiliarCON;
            TipoRnc = TipoRncCON;
            Rnc = RncCON;
            NombreVendedor = NombreVendedorCON;
            PorcientoComision = PorcientoComisionCON;
            CodigoSupervisor = CodigoSupervisorCON;
            Estatus = EstatusCON;
            Fecha_Entrada = Fecha_EntradaCON;
            UsuarioAdiciona = UsuarioAdicionaCON;
            FechaAdiciona = FechaAdicionaCON;
            UsuarioModifica = UsuarioModificaCON;
            FechaModifica = FechaModificaCON;
            PorcientoGastos = PorcientoGastosCON;
            nota = notaCON;
            tipo_Intermediario = tipo_IntermediarioCON;
            Agencia = AgenciaCON;
            Fec_Nac = Fec_NacCON;
            Publicidad = PublicidadCON;
            PagoComPor = PagoComPorCON;
            Banco = BancoCON;
            CtaBanco = CtaBancoCON;
            CodigoRnc = CodigoRncCON;
            Retencion = RetencionCON;
            PorcDescuento = PorcDescuentoCON;
            SupervisorCrea = SupervisorCreaCON;
            VendedorCrea = VendedorCreaCON;
            Poliza = PolizaCON;
            Direccion = DireccionCON;
            Ubicacion = UbicacionCON;
            Telefono = TelefonoCON;
            TelefonoOficina = TelefonoOficinaCON;
            Celular = CelularCON;
            Beeper = BeeperCON;
            Fax = FaxCON;
            Email = EmailCON;
            LicenciaSeguro = LicenciaSeguroCON;
            CodigoAnterior = CodigoAnteriorCON;
            Apellido = ApellidoCON;
            Nombre = NombreCON;
            Oficina = OficinaCON;
            TipoCuentaBco = TipoCuentaBcoCON;
            EjecutivoServicio = EjecutivoServicioCON;
            AsumeCxc = AsumeCxcCON;
            CodigoCliente = CodigoClienteCON;
            Record_Id = Record_IdCON;
            PorcientoCapitalizacion = PorcientoCapitalizacionCON;
            Gestor = GestorCON;
            EjecutivoCobros = EjecutivoCobrosCON;
            DiasCancelacionAutomatica = DiasCancelacionAutomaticaCON;
            Accion = AccionCON;
        }

        //CREAMOS UN METODO PARA PROCESAR
        private void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMantenimientoIntermediariosSupervisores Procesar = new Entidades.Mantenimientos.EMantenimientoIntermediariosSupervisores();

            Procesar.Compania = Convert.ToByte(Compania);
            Procesar.Codigo = Codigo;
            Procesar.Cuenta = Cuenta;
            Procesar.Auxiliar = Auxiliar;
            Procesar.TipoRnc = TipoRnc;
            Procesar.Rnc = Rnc;
            Procesar.NombreVendedor = NombreVendedor;
            Procesar.PorcientoComision = PorcientoComision;
            Procesar.CodigoSupervisor = CodigoSupervisor;
            Procesar.Estatus = Convert.ToByte(Estatus);
            Procesar.Fecha_Entrada = Fecha_Entrada;
            Procesar.UsuarioAdiciona = UsuarioAdiciona;
            Procesar.FechaAdiciona = FechaAdiciona;
            Procesar.UsuarioModifica = UsuarioModifica;
            Procesar.FechaModifica = FechaModifica;
            Procesar.PorcientoGastos = PorcientoGastos;
            Procesar.nota = nota;
            Procesar.tipo_Intermediario = tipo_Intermediario;
            Procesar.Agencia = Agencia;
            Procesar.Fec_Nac = Fec_Nac;
            Procesar.Publicidad = Publicidad;
            Procesar.PagoComPor = PagoComPor;
            Procesar.Banco = Banco;
            Procesar.CtaBanco = CtaBanco;
            Procesar.CodigoRnc = CodigoRnc;
            Procesar.Retencion = Retencion;
            Procesar.PorcDescuento = PorcDescuento;
            Procesar.SupervisorCrea = SupervisorCrea;
            Procesar.VendedorCrea = VendedorCrea;
            Procesar.Poliza = Poliza;
            Procesar.Direccion = Direccion;
            Procesar.Ubicacion = Ubicacion;
            Procesar.Telefono = Telefono;
            Procesar.TelefonoOficina = TelefonoOficina;
            Procesar.Celular = Celular;
            Procesar.Beeper = Beeper;
            Procesar.Fax = Fax;
            Procesar.Email = Email;
            Procesar.LicenciaSeguro = LicenciaSeguro;
            Procesar.CodigoAnterior = CodigoAnterior;
            Procesar.Apellido = Apellido;
            Procesar.Nombre = Nombre;
            Procesar.Oficina = Oficina;
            Procesar.TipoCuentaBco = TipoCuentaBco;
            Procesar.EjecutivoServicio = EjecutivoServicio;
            Procesar.AsumeCxc = Convert.ToByte(AsumeCxc);
            Procesar.CodigoCliente = CodigoCliente;
            Procesar.Record_Id = Record_Id;
            Procesar.PorcientoCapitalizacion = PorcientoCapitalizacion;
            Procesar.Gestor = Gestor;
            Procesar.EjecutivoCobros = EjecutivoCobros;
            Procesar.DiasCancelacionAutomatica = DiasCancelacionAutomatica;

            var MAN = ObjData.MantenimientoIntermediarioSupervisor(Procesar, Accion);
              

        }

    }
}
