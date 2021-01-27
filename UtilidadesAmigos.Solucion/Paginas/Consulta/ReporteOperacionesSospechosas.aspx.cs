using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ReporteOperacionesSospechosas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoReporte, ObjData.Value.BuscaListas("TIPOREPORTEUAF", null, null));
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            //EXPORTAR DATA A EXEL
            try {
                int TipoReporte = Convert.ToInt32(ddlTipoReporte.SelectedValue);

                if (TipoReporte == 1)
                {
                    //OPERACIONES SOSPECHOSAS
                    var Exportar = (from n in ObjData.Value.ReporteOperacionesSospechosas(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text))
                                    select new
                                    {
                                        NoReporte = n.NoReporte,
                                        Poliza = n.Poliza,
                                        CodigoRegistroEntidad = n.CodigoRegistroEntidad,
                                        Usuario = n.Usuario,
                                        Oficina = n.Oficina,
                                        FechaEnvio = n.FechaEnvio,
                                        HoraEnvio = n.HoraEnvio,
                                        TipoPersonaCliente = n.TipoPersonaCliente,
                                        PEPCliente = n.PEPCliente,
                                        PEPClienteTipo = n.PEPClienteTipo,
                                        SexoCliente = n.SexoCliente,
                                        NombreRazonSocialCliente = n.NombreRazonSocialCliente,
                                        ApellidoRazonSocialCliente = n.ApellidoRazonSocialCliente,
                                        NacionalidadorigenCliente = n.NacionalidadorigenCliente,
                                        NacionalidadAdquiridaCliente = n.NacionalidadAdquiridaCliente,
                                        TipoDocumentoCliente = n.TipoDocumentoCliente,
                                        NoDocumentoIdentidadCliente = n.NoDocumentoIdentidadCliente,
                                        SiTipoDocumentoIgualOtroEspesificar = n.SiTipoDocumentoIgualOtroEspesificar,
                                        ActividadEconomicaCliente = n.ActividadEconomicaCliente,
                                        TipoProductoCliente = n.TipoProductoCliente,
                                        NoCuenta1 = n.NoCuenta1,
                                        NoCuenta2 = n.NoCuenta2,
                                        NoCuenta3 = n.NoCuenta3,
                                        ProvinciaCliente = n.ProvinciaCliente,
                                        MunicipioCliente = n.MunicipioCliente,
                                        SectorCliente = n.SectorCliente,
                                        DireccionCliente = n.DireccionCliente,
                                        TelefonoCasaCliente = n.TelefonoCasaCliente,
                                        TelefonoOficinaCliente = n.TelefonoOficinaCliente,
                                        Celular1Cliente = n.Celular1Cliente,
                                        Celular2Cliente = n.Celular2Cliente,
                                        TipoTransaccion = n.TipoTransaccion,
                                        DescripcionTransaccion = n.DescripcionTransaccion,
                                        TipoMoneda = n.TipoMoneda,
                                        MontoOriginal = n.MontoOriginal,
                                        MontoPesosDominicanos = n.MontoPesosDominicanos,
                                        PagoAcumuladoPesos = n.PagoAcumuladoPesos,
                                        PagoAcumuladoDollar = n.PagoAcumuladoDollar,
                                        TasaCambio = n.TasaCambio,
                                        TipoInstrumento = n.TipoInstrumento,
                                        FechaTransaccion = n.FechaTransaccion,
                                        HoraTransaccion = n.HoraTransaccion,
                                        FechaEnvio1 = n.FechaEnvio1,
                                        HoraTransaccion1 = n.HoraTransaccion1,
                                        OrigenFondos = n.OrigenFondos,
                                        TransaccionRealizada = n.TransaccionRealizada,
                                        MotivoTransaccion = n.MotivoTransaccion,
                                        PaisOrigen = n.PaisOrigen,
                                        PaisDestino = n.PaisDestino,
                                        EntidadCorresponsal = n.EntidadCorresponsal,
                                        Remesador = n.Remesador,
                                        IntermediarioIgualCliente = n.IntermediarioIgualCliente,
                                        SexoIntermediario = n.SexoIntermediario,
                                        NombreRazonIntermediario = n.NombreRazonIntermediario,
                                        ApellidoRazonIntermediario = n.ApellidoRazonIntermediario,
                                        NacionalidadOrigenIntermediario = n.NacionalidadOrigenIntermediario,
                                        NacionalidadAdquiridaIntermediario = n.NacionalidadAdquiridaIntermediario,
                                        TipoRncIntermediario = n.TipoRncIntermediario,
                                        NoDocumentoIntermediario = n.NoDocumentoIntermediario,
                                        SiTipoDocumentoIgualOtroEspesificarIntermdiario = n.SiTipoDocumentoIgualOtroEspesificarIntermdiario,
                                        ProvinciaIntermediario = n.ProvinciaIntermediario,
                                        MunicipioIntermediario = n.MunicipioIntermediario,
                                        SectorIntermediario = n.SectorIntermediario,
                                        DireccionIntermediario = n.DireccionIntermediario,
                                        BeneficiarioIgualCliente = n.BeneficiarioIgualCliente,
                                        SexoBeneficiario = n.SexoBeneficiario,
                                        NombreRazonSocialBeneficiario = n.NombreRazonSocialBeneficiario,
                                        ApellidoRazonSocialBeneficiario = n.ApellidoRazonSocialBeneficiario,
                                        NacionalidadBeneficiario = n.NacionalidadBeneficiario,
                                        NacionalidadAdquiridaBeneficiario = n.NacionalidadAdquiridaBeneficiario,
                                        TipoIdentificacionBeneficiario = n.TipoIdentificacionBeneficiario,
                                        NoDocumentoIdentidadBeneficiario = n.NoDocumentoIdentidadBeneficiario,
                                        SiTipoDocumentoIgualOtroEspesificar1 = n.SiTipoDocumentoIgualOtroEspesificar1,
                                        ProvinciaBeneficiario = n.ProvinciaBeneficiario,
                                        MunicipioBeneficiario = n.MunicipioBeneficiario,
                                        SectorBeneficiario = n.SectorBeneficiario,
                                        DireccionBeneficiario = n.DireccionBeneficiario,
                                        MotivoReporte = n.MotivoReporte,
                                        EspesifiquePrioridadReporte = n.EspesifiquePrioridadReporte,
                                        Anexo = n.Anexo,
                                        ValidadoDesde = n.ValidadoDesde,
                                        ValidadoHAsta = n.ValidadoHAsta
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("" + ddlTipoReporte.SelectedItem, Exportar);
                }
                else if (TipoReporte == 2)
                {
                    //TRANSACCIONES EN EFECTIVO
                    var Exportar = (from n in ObjData.Value.ReporteTransaccionesEfectivo(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text))
                                    select new
                                    {
                                        NoReporte = n.NoReporte,
                                        Poliza = n.Poliza,
                                        CodigoRegistroEntidad = n.CodigoRegistroEntidad,
                                        Usuario = n.Usuario,
                                        Oficina = n.Oficina,
                                        FechaEnvio = n.FechaEnvio,
                                        HoraEnvio = n.HoraEnvio,
                                        TipoPersonaCliente = n.TipoPersonaCliente,
                                        PEPCliente = n.PEPCliente,
                                        PEPClienteTipo = n.PEPClienteTipo,
                                        SexoCliente = n.SexoCliente,
                                        NombreRazonSocialCliente = n.NombreRazonSocialCliente,
                                        ApellidoRazonSocialCliente = n.ApellidoRazonSocialCliente,
                                        NacionalidadorigenCliente = n.NacionalidadorigenCliente,
                                        NacionalidadAdquiridaCliente = n.NacionalidadAdquiridaCliente,
                                        TipoDocumentoCliente = n.TipoDocumentoCliente,
                                        NoDocumentoIdentidadCliente = n.NoDocumentoIdentidadCliente,
                                        SiTipoDocumentoIgualOtroEspesificar = n.SiTipoDocumentoIgualOtroEspesificar,
                                        ActividadEconomicaCliente = n.ActividadEconomicaCliente,
                                        TipoProductoCliente = n.TipoProductoCliente,
                                        NoCuenta1 = n.NoCuenta1,
                                        NoCuenta2 = n.NoCuenta2,
                                        NoCuenta3 = n.NoCuenta3,
                                        ProvinciaCliente = n.ProvinciaCliente,
                                        MunicipioCliente = n.MunicipioCliente,
                                        SectorCliente = n.SectorCliente,
                                        DireccionCliente = n.DireccionCliente,
                                        TelefonoCasaCliente = n.TelefonoCasaCliente,
                                        TelefonoOficinaCliente = n.TelefonoOficinaCliente,
                                        Celular1Cliente = n.Celular1Cliente,
                                        Celular2Cliente = n.Celular2Cliente,
                                        TipoTransaccion = n.TipoTransaccion,
                                        DescripcionTransaccion = n.DescripcionTransaccion,
                                        TipoMoneda = n.TipoMoneda,
                                        MontoOriginal = n.MontoOriginal,
                                        MontoPesosDominicanos = n.MontoPesosDominicanos,
                                        PagoAcumuladoPesos = n.PagoAcumuladoPesos,
                                        PagoAcumuladoDollar = n.PagoAcumuladoDollar,
                                        TasaCambio = n.TasaCambio,
                                        TipoInstrumento = n.TipoInstrumento,
                                        FechaTransaccion = n.FechaTransaccion,
                                        HoraTransaccion = n.HoraTransaccion,
                                        FechaEnvio1 = n.FechaEnvio1,
                                        HoraTransaccion1 = n.HoraTransaccion1,
                                        OrigenFondos = n.OrigenFondos,
                                        TransaccionRealizada = n.TransaccionRealizada,
                                        MotivoTransaccion = n.MotivoTransaccion,
                                        PaisOrigen = n.PaisOrigen,
                                        PaisDestino = n.PaisDestino,
                                        EntidadCorresponsal = n.EntidadCorresponsal,
                                        Remesador = n.Remesador,
                                        IntermediarioIgualCliente = n.IntermediarioIgualCliente,
                                        SexoIntermediario = n.SexoIntermediario,
                                        NombreRazonIntermediario = n.NombreRazonIntermediario,
                                        ApellidoRazonIntermediario = n.ApellidoRazonIntermediario,
                                        NacionalidadOrigenIntermediario = n.NacionalidadOrigenIntermediario,
                                        NacionalidadAdquiridaIntermediario = n.NacionalidadAdquiridaIntermediario,
                                        TipoRncIntermediario = n.TipoRncIntermediario,
                                        NoDocumentoIntermediario = n.NoDocumentoIntermediario,
                                        SiTipoDocumentoIgualOtroEspesificarIntermdiario = n.SiTipoDocumentoIgualOtroEspesificarIntermdiario,
                                        ProvinciaIntermediario = n.ProvinciaIntermediario,
                                        MunicipioIntermediario = n.MunicipioIntermediario,
                                        SectorIntermediario = n.SectorIntermediario,
                                        DireccionIntermediario = n.DireccionIntermediario,
                                        BeneficiarioIgualCliente = n.BeneficiarioIgualCliente,
                                        SexoBeneficiario = n.SexoBeneficiario,
                                        NombreRazonSocialBeneficiario = n.NombreRazonSocialBeneficiario,
                                        ApellidoRazonSocialBeneficiario = n.ApellidoRazonSocialBeneficiario,
                                        NacionalidadBeneficiario = n.NacionalidadBeneficiario,
                                        NacionalidadAdquiridaBeneficiario = n.NacionalidadAdquiridaBeneficiario,
                                        TipoIdentificacionBeneficiario = n.TipoIdentificacionBeneficiario,
                                        NoDocumentoIdentidadBeneficiario = n.NoDocumentoIdentidadBeneficiario,
                                        SiTipoDocumentoIgualOtroEspesificar1 = n.SiTipoDocumentoIgualOtroEspesificar1,
                                        ProvinciaBeneficiario = n.ProvinciaBeneficiario,
                                        MunicipioBeneficiario = n.MunicipioBeneficiario,
                                        SectorBeneficiario = n.SectorBeneficiario,
                                        DireccionBeneficiario = n.DireccionBeneficiario,
                                        MotivoReporte = n.MotivoReporte,
                                        EspesifiquePrioridadReporte = n.EspesifiquePrioridadReporte,
                                        Anexo = n.Anexo
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("" + ddlTipoReporte.SelectedItem, Exportar);
                }
            }
            catch (Exception) { }
        }
    }
}