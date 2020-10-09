using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionSolicitudCheques
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos Objdata = new Logica.LogicaMantenimientos.LogicaMantenimientos();

        private int Compania = 0;
        private string Anulado = "";
        private int Sistema = 0;
        private int Solicitud = 0;
        private int TipoSolicitud = 0;
        private string DescTipoSolicitud = "";
        private DateTime FechaSolicitud = DateTime.Now;
        private int Sucursal = 0;
        private string DescSucursal = "";
        private int Departamento = 0;
        private string DescDepto = "";
        private int Seccion = 0;
        private string DescSeccion = "";
        private int RNCTipo = 0;
        private string RNC = "";
        private int CodigoBeneficiario = 0;
        private string Beneficiario1 = "";
        private string Beneficiario2 = "";
        private string Endosable = "";
        private int CtaBanco = 0;
        private string CuentaBanco = "";
        private decimal Valor = 0;
        private string Concepto1 = "";
        private string Concepto2 = "";
        private int NumeroCheque = 0;
        private DateTime FechaCheque = DateTime.Now;
        private int AnoMesConciliado = 0;
        private DateTime FechaConciliado = DateTime.Now;
        private string UsuarioDigita = "";
        private string UsuarioModifica = "";
        private DateTime FechaDigita = DateTime.Now;
        private DateTime FechaModifica = DateTime.Now;
        private int Aprobado = 0;
        private DateTime FechaAprobado = DateTime.Now;
        private string UsuarioCheque = "";
        private string PrimeraFirma = "";
        private string SegundaFirma = "";
        private string UsuarioCancel = "";
        private int Estatus = 0;
        private string Impresion = "";
        private int TipoDoc = 0;
        private DateTime FechaProcesoDesde = DateTime.Now;
        private DateTime FechaProcesoHasta = DateTime.Now;
        private decimal TotalCobradoVendedor = 0;
        private decimal ComisionBrutaVendedor = 0;
        private decimal RetencionVendedor = 0;
        private string Accion = "";

        public ProcesarInformacionSolicitudCheques(
            int CompaniaCON,
        string AnuladoCON,
        int SistemaCON,
        int SolicitudCON,
        int TipoSolicitudCON,
        string DescTipoSolicitudCON,
        DateTime FechaSolicitudCON,
        int SucursalCON,
        string DescSucursalCON,
        int DepartamentoCON,
        string DescDeptoCON,
        int SeccionCON,
        string DescSeccionCON,
        int RNCTipoCON,
        string RNCCON,
        int CodigoBeneficiarioCON,
        string Beneficiario1CON,
        string Beneficiario2CON,
        string EndosableCON,
        int CtaBancoCON,
        string CuentaBancoCON,
        decimal ValorCON,
        string Concepto1CON,
        string Concepto2CON,
        int NumeroChequeCON,
        DateTime FechaChequeCON,
        int AnoMesConciliadoCON,
        DateTime FechaConciliadoCON,
        string UsuarioDigitaCON,
        string UsuarioModificaCON,
        DateTime FechaDigitaCON,
        DateTime FechaModificaCON,
        int AprobadoCON,
        DateTime FechaAprobadoCON,
        string UsuarioChequeCON,
        string PrimeraFirmaCON,
        string SegundaFirmaCON,
        string UsuarioCancelCON,
        int EstatusCON,
        string ImpresionCON,
        int TipoDocCON,
        DateTime FechaProcesoDesdeCON,
        DateTime FechaProcesoHastaCON,
        decimal TotalCobradoVendedorCON,
        decimal ComisionBrutaVendedorCON,
        decimal RetencionVendedorCON,
        string AccionCON)
        {
            Compania = CompaniaCON;
            Anulado = AnuladoCON;
            Sistema = SistemaCON;
            Solicitud = SolicitudCON;
            TipoSolicitud = TipoSolicitudCON;
            DescTipoSolicitud = DescTipoSolicitudCON;
            FechaSolicitud = FechaSolicitudCON;
            Sucursal = SucursalCON;
            DescSucursal = DescSucursalCON;
            Departamento = DepartamentoCON;
            DescDepto = DescDeptoCON;
            Seccion = SeccionCON;
             DescSeccion = DescSeccionCON;
            RNCTipo = RNCTipoCON;
            RNC = RNCCON;
            CodigoBeneficiario = CodigoBeneficiarioCON;
            Beneficiario1 = Beneficiario1CON;
            Beneficiario2 = Beneficiario2CON;
            Endosable = EndosableCON;
            CtaBanco = CtaBancoCON;
            CuentaBanco = CuentaBancoCON;
            Valor = ValorCON;
            Concepto1 = Concepto1CON;
            Concepto2 = Concepto2CON;
            NumeroCheque = NumeroChequeCON;
             FechaCheque = FechaChequeCON;
            AnoMesConciliado = AnoMesConciliadoCON;
            FechaConciliado = FechaConciliadoCON;
            UsuarioDigita = UsuarioDigitaCON;
            UsuarioModifica = UsuarioModificaCON;
            FechaDigita = FechaDigitaCON;
            FechaModifica = FechaModificaCON;
            Aprobado = AprobadoCON;
            FechaAprobado = FechaAprobadoCON;
            UsuarioCheque = UsuarioChequeCON;
            PrimeraFirma = PrimeraFirmaCON;
            SegundaFirma = SegundaFirmaCON;
            UsuarioCancel = UsuarioCancelCON;
            Estatus = EstatusCON;
            Impresion = ImpresionCON;
            TipoDoc = TipoDocCON;
            FechaProcesoDesde = FechaProcesoDesdeCON;
            FechaProcesoHasta = FechaProcesoHastaCON;
            TotalCobradoVendedor = TotalCobradoVendedorCON;
            ComisionBrutaVendedor = ComisionBrutaVendedorCON;
            RetencionVendedor = RetencionVendedorCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarSolicitudCheques Procesar = new Entidades.Mantenimientos.EProcesarSolicitudCheques();

            Procesar.Compania = Convert.ToByte(Compania);
            Procesar.Anulado = Anulado;
            Procesar.Sistema = Convert.ToByte(Sistema);
            Procesar.Solicitud = Solicitud;
            Procesar.TipoSolicitud = Convert.ToByte(TipoSolicitud);
            Procesar.DescTipoSolicitud = DescTipoSolicitud;
            Procesar.FechaSolicitud = FechaSolicitud;
            Procesar.Sucursal = Convert.ToByte(Sucursal);
            Procesar.DescSucursal = DescSucursal;
            Procesar.Departamento = Convert.ToByte(Departamento);
            Procesar.DescDepto = DescDepto;
            Procesar.Seccion = Convert.ToByte(Seccion);
            Procesar.DescSeccion = DescSeccion;
            Procesar.RNCTipo = Convert.ToByte(RNCTipo);
            Procesar.RNC = RNC;
            Procesar.CodigoBeneficiario = CodigoBeneficiario;
            Procesar.Beneficiario1 = Beneficiario1;
            Procesar.Beneficiario2 = Beneficiario2;
            Procesar.Endosable = Endosable;
            Procesar.CtaBanco = Convert.ToByte(CtaBanco);
            Procesar.CuentaBanco = CuentaBanco;
            Procesar.Valor = Valor;
            Procesar.Concepto1 = Concepto1;
            Procesar.Concepto2 = Concepto2;
            Procesar.NumeroCheque = NumeroCheque;
            Procesar.FechaCheque = FechaCheque;
            Procesar.AnoMesConciliado = AnoMesConciliado;
            Procesar.FechaConciliado = FechaConciliado;
            Procesar.UsuarioDigita = UsuarioDigita;
            Procesar.UsuarioModifica = UsuarioModifica;
            Procesar.FechaDigita = FechaDigita;
            Procesar.FechaModifica = FechaModifica;
            Procesar.Aprobado = Aprobado;
            Procesar.FechaAprobado = FechaAprobado;
            Procesar.UsuarioCheque = UsuarioCheque;
            Procesar.PrimeraFirma = PrimeraFirma;
            Procesar.SegundaFirma = SegundaFirma;
            Procesar.UsuarioCancel = UsuarioCancel;
            Procesar.Estatus = Convert.ToByte(Estatus);
            Procesar.Impresion = Convert.ToChar(Impresion);
            Procesar.TipoDoc = TipoDoc;

            var MAN = Objdata.ProcesarSolicitudCheques(Procesar,FechaProcesoDesde,FechaProcesoHasta,TotalCobradoVendedor,ComisionBrutaVendedor,RetencionVendedor,Accion);
        }
    }
}
