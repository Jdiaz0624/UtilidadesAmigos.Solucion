using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ReporteOperacionesSospechosas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region CONTROL PARA MOSTRAR LA PAGINACION
        readonly PagedDataSource pagedDataSource = new PagedDataSource();
        int _PrimeraPagina, _UltimaPagina;
        private int _TamanioPagina = 10;
        private int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] == null)
                {
                    return 0;
                }
                return ((int)ViewState["CurrentPage"]);
            }
            set
            {
                ViewState["CurrentPage"] = value;
            }

        }


        private void HandlePaging(ref DataList NombreDataList)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina = CurrentPage - 5;
            if (CurrentPage > 5)
                _UltimaPagina = CurrentPage + 5;
            else
                _UltimaPagina = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina = _UltimaPagina - 10;
            }

            if (_PrimeraPagina < 0)
                _PrimeraPagina = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage;
            lbPaginaActualVariableOperacionesSospechosas.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina; i < _UltimaPagina; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }
        private void Paginar(ref Repeater ControlRepeater, IEnumerable<object> Listado, int _NumeroRegistros)
        {
            pagedDataSource.DataSource = Listado;
            pagedDataSource.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPaginaVariableOperacionesSospechosas.Text = pagedDataSource.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina : _NumeroRegistros);
            pagedDataSource.CurrentPageIndex = CurrentPage;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            LinkPrimeraOperacionesSospechosas.Enabled = !pagedDataSource.IsFirstPage;
            LinkAnteriorOperacionesSospechosas.Enabled = !pagedDataSource.IsFirstPage;
            LinkSiguienteOperacionesSospechosas.Enabled = !pagedDataSource.IsLastPage;
            LinkUltimoOperacionesSospechosas.Enabled = !pagedDataSource.IsLastPage;

            ControlRepeater.DataSource = pagedDataSource;
            ControlRepeater.DataBind();


            //  divPaginacionBancos.Visible = true;
        }
        enum OpcionesPaginacionValores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion(int Accion)
        {

            int PaginaActual = 0;
            switch (Accion)
            {

                case 1:
                    //PRIMERA PAGINA
                    lbPaginaActualVariableOperacionesSospechosas.Text = "1";

                    break;

                case 2:
                    //SEGUNDA PAGINA
                    PaginaActual = Convert.ToInt32(lbPaginaActualVariableOperacionesSospechosas.Text);
                    PaginaActual++;
                    lbPaginaActualVariableOperacionesSospechosas.Text = PaginaActual.ToString();
                    break;

                case 3:
                    //PAGINA ANTERIOR
                    PaginaActual = Convert.ToInt32(lbPaginaActualVariableOperacionesSospechosas.Text);
                    if (PaginaActual > 1)
                    {
                        PaginaActual--;
                        lbPaginaActualVariableOperacionesSospechosas.Text = PaginaActual.ToString();
                    }
                    break;

                case 4:
                    //ULTIMA PAGINA
                    lbPaginaActualVariableOperacionesSospechosas.Text = lbCantidadPaginaVariableOperacionesSospechosas.Text;
                    break;


            }

        }
        #endregion

       

        enum ConceptosOperacionesSospechosas {
            OperacionesSospechosas=1,
            TransaccionesEnEfectivo=2
    }

        private void MostrarListado() {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);

                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                int TipoInformacionGenerar = Convert.ToInt32(ddlSeleccionarTipoOperacion.SelectedValue);
                decimal? UsuarioProcesa = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;

                if (TipoInformacionGenerar == (int)ConceptosOperacionesSospechosas.OperacionesSospechosas)
                {
                    var MostrarListadoOperacionesSospechosas = ObjData.Value.GenerarReporteDeOperacionesSospechisas(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        Convert.ToDecimal(txtTasa.Text),
                        UsuarioProcesa,
                        Convert.ToDecimal(txtMontoCondicion.Text),
                        null, null);
                    Paginar(ref rpListado, MostrarListadoOperacionesSospechosas, 10);
                    HandlePaging(ref dtPaginacionOperacionesSospechosas);

                    int CantidadRegistros = MostrarListadoOperacionesSospechosas.Count;
                    lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                }
                else if (TipoInformacionGenerar == (int)ConceptosOperacionesSospechosas.TransaccionesEnEfectivo)
                {

                    var MostrarListado = ObjData.Value.GenerarReporteTransaccionesEfectivo(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        Convert.ToDecimal(txtTasa.Text),
                        UsuarioProcesa,
                        Convert.ToDecimal(txtMontoCondicion.Text),
                        null, null);
                    Paginar(ref rpListado, MostrarListado, 10);
                    HandlePaging(ref dtPaginacionOperacionesSospechosas);

                    int CantidadRegistros = MostrarListado.Count;
                    lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");


                }
            }
        }
        private void ExportarRegistros() {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                int TipoInformacionGenerar = Convert.ToInt32(ddlSeleccionarTipoOperacion.SelectedValue);
                decimal? UsuarioProcesa = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;

                if (TipoInformacionGenerar == (int)ConceptosOperacionesSospechosas.OperacionesSospechosas)
                {
                    var ValidarRegistrosOperacionesSospechosas = ObjData.Value.GenerarReporteDeOperacionesSospechisas(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        Convert.ToDecimal(txtTasa.Text),
                        UsuarioProcesa,
                        Convert.ToDecimal(txtMontoCondicion.Text),
                        null, null);
                    if (ValidarRegistrosOperacionesSospechosas.Count() < 1) {
                        GenerarArchivoVacio("Operaciones Sospechosas (ROS)");
                    }
                    else {
                        var ExportarInformacionOperacionesSospechosas = (from n in ObjData.Value.GenerarReporteDeOperacionesSospechisas(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text),
                            Convert.ToDecimal(txtTasa.Text),
                            UsuarioProcesa,
                            Convert.ToDecimal(txtMontoCondicion.Text),
                            null, null)
                                                                         select new {
                                                                             NumeroReporte = n.NumeroRecibo,
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
                                                                             NumeroRecibo = n.NumeroRecibo,
                                                                             FechaRecibo = n.FechaRecibo,
                                                                             MontoOriginal = n.MontoOriginal,
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
                                                                             ValidadoHasta = n.ValidadoHasta,
                                                                             MontoCondicion = n.MontoCondicion,
                                                                             GeneradoPor = n.GeneradoPor
                                                                         }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Operaciones Sospechosas (ROS)", ExportarInformacionOperacionesSospechosas);
                    }

                }
                else if (TipoInformacionGenerar == (int)ConceptosOperacionesSospechosas.TransaccionesEnEfectivo)
                {
                    var MostrarListado = ObjData.Value.GenerarReporteTransaccionesEfectivo(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        Convert.ToDecimal(txtTasa.Text),
                        UsuarioProcesa,
                        Convert.ToDecimal(txtMontoCondicion.Text),
                        null, null);
                    if (MostrarListado.Count() < 1) {
                        GenerarArchivoVacio("Transacciones En Efectivo (RTE)");
                    }
                    else
                    {
                        var ExportarInformacion = (from n in ObjData.Value.GenerarReporteTransaccionesEfectivo(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text),
                            Convert.ToDecimal(txtTasa.Text),
                            UsuarioProcesa,
                            Convert.ToDecimal(txtMontoCondicion.Text),
                            null, null)
                                                   select new
                                                   {
                                                       NumeroReporte = n.NumeroRecibo,
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
                                                       NumeroRecibo = n.NumeroRecibo,
                                                       FechaRecibo = n.FechaRecibo,
                                                       MontoOriginal = n.MontoOriginal,
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
                                                       ValidadoHasta = n.ValidadoHasta,
                                                       MontoCondicion = n.MontoCondicion,
                                                       GeneradoPor = n.GeneradoPor
                                                   }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Transacciones en Efectivo (RTE)", ExportarInformacion);
                    }
                }
            }
        }
        private void SacarTasaSistema() {
            txtTasa.Text = UtilidadesAmigos.Logica.Comunes.SacartasaMoneda.SacarTasaMoneda(2).ToString();
        }
        private void GenerarArchivoVacio(string NombreRegistro) {
            int Lectura = 0;
            var ListadoVacio = (from n in Lectura.ToString()
                                select new
                                {
                                    NumeroReporte = " ",
                                    Poliza = " ",
                                    CodigoRegistroEntidad = " ",
                                    Usuario = " ",
                                    Oficina = " ",
                                    FechaEnvio = " ",
                                    HoraEnvio = " ",
                                    TipoPersonaCliente = " ",
                                    PEPCliente = " ",
                                    PEPClienteTipo = " ",
                                    SexoCliente = " ",
                                    NombreRazonSocialCliente = " ",
                                    ApellidoRazonSocialCliente = " ",
                                    NacionalidadorigenCliente = " ",
                                    NacionalidadAdquiridaCliente = " ",
                                    TipoDocumentoCliente = " ",
                                    NoDocumentoIdentidadCliente = " ",
                                    SiTipoDocumentoIgualOtroEspesificar = " ",
                                    ActividadEconomicaCliente = " ",
                                    TipoProductoCliente = " ",
                                    NoCuenta1 = " ",
                                    NoCuenta2 = " ",
                                    NoCuenta3 = " ",
                                    ProvinciaCliente = " ",
                                    MunicipioCliente = " ",
                                    SectorCliente = " ",
                                    DireccionCliente = " ",
                                    TelefonoCasaCliente = " ",
                                    TelefonoOficinaCliente = " ",
                                    Celular1Cliente = " ",
                                    Celular2Cliente = " ",
                                    TipoTransaccion = " ",
                                    DescripcionTransaccion = " ",
                                    TipoMoneda = " ",
                                    NumeroRecibo = " ",
                                    FechaRecibo = " ",
                                    MontoOriginal = " ",
                                    PagoAcumuladoPesos = " ",
                                    PagoAcumuladoDollar = " ",
                                    TasaCambio = " ",
                                    TipoInstrumento = " ",
                                    FechaTransaccion = " ",
                                    HoraTransaccion = " ",
                                    FechaEnvio1 = " ",
                                    HoraTransaccion1 = " ",
                                    OrigenFondos = " ",
                                    TransaccionRealizada = " ",
                                    MotivoTransaccion = " ",
                                    PaisOrigen = " ",
                                    PaisDestino = " ",
                                    EntidadCorresponsal = " ",
                                    Remesador = " ",
                                    IntermediarioIgualCliente = " ",
                                    SexoIntermediario = " ",
                                    NombreRazonIntermediario = " ",
                                    ApellidoRazonIntermediario = " ",
                                    NacionalidadOrigenIntermediario = " ",
                                    NacionalidadAdquiridaIntermediario = " ",
                                    TipoRncIntermediario = " ",
                                    NoDocumentoIntermediario = " ",
                                    SiTipoDocumentoIgualOtroEspesificarIntermdiario = " ",
                                    ProvinciaIntermediario = " ",
                                    MunicipioIntermediario = " ",
                                    SectorIntermediario = " ",
                                    DireccionIntermediario = " ",
                                    BeneficiarioIgualCliente = " ",
                                    SexoBeneficiario = " ",
                                    NombreRazonSocialBeneficiario = " ",
                                    ApellidoRazonSocialBeneficiario = " ",
                                    NacionalidadBeneficiario = " ",
                                    NacionalidadAdquiridaBeneficiario = " ",
                                    TipoIdentificacionBeneficiario = " ",
                                    NoDocumentoIdentidadBeneficiario = " ",
                                    SiTipoDocumentoIgualOtroEspesificar1 = " ",
                                    ProvinciaBeneficiario = " ",
                                    MunicipioBeneficiario = " ",
                                    SectorBeneficiario = " ",
                                    DireccionBeneficiario = " ",
                                    MotivoReporte = " ",
                                    EspesifiquePrioridadReporte = " ",
                                    Anexo = " ",
                                    ValidadoDesde = " ",
                                    ValidadoHasta = " ",
                                    MontoCondicion = " ",
                                    GeneradoPor = " "
                                }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(NombreRegistro, ListadoVacio);
        }

        private void RestablecerPantalla() {
            DivBloqueDetalle.Visible = false;
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoOperacion, ObjData.Value.BuscaListas("TIPOREPORTEUAF", null, null));
            MostrarListado();
            SacarTasaSistema();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                  UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoOperacion, ObjData.Value.BuscaListas("TIPOREPORTEUAF", null, null));
                DivBloqueDetalle.Visible = false;
                SacarTasaSistema();
            }
        }

        protected void btnConsultarRegistros_Click(object sender, EventArgs e)
        {
            MostrarListado();
        }

        protected void btnExportarRegistros_Click(object sender, EventArgs e)
        {
            ExportarRegistros();
        }

        protected void btnRestablecerPantalla_Click(object sender, EventArgs e)
        {
            RestablecerPantalla();
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            DivBloqueDetalle.Visible = true;
            var PolizaSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var hfPolizaSeleccionada = ((HiddenField)PolizaSeleccionada.FindControl("hfPoliza")).Value.ToString();

            var NumeroreciboSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfNumeroReciboSeleccionado = ((HiddenField)NumeroreciboSeleccionado.FindControl("hfNumeroRecibo")).Value.ToString();


            int TipoOperacionSeleccionada = Convert.ToInt32(ddlSeleccionarTipoOperacion.SelectedValue);
            decimal? UsuarioProcesa = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;
            if (TipoOperacionSeleccionada == (int)ConceptosOperacionesSospechosas.TransaccionesEnEfectivo) {
                var SacarDetalle = ObjData.Value.GenerarReporteTransaccionesEfectivo(
                    Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text), Convert.ToDecimal(txtTasa.Text), UsuarioProcesa, Convert.ToDecimal(txtMontoCondicion.Text),
                    Convert.ToDecimal(hfNumeroReciboSeleccionado),
                    hfPolizaSeleccionada.ToString());
                foreach (var n in SacarDetalle) {
                    txtNumeroReporteDetalle.Text = n.NumeroReporte.ToString();
                    txtPolizaDetalle.Text = n.Poliza;
                    txtCodigoRegistroEntidadDetalle.Text = n.CodigoRegistroEntidad;
                    txtUsuario.Text = n.Usuario;
                    txtOficina.Text = n.Oficina;
                    txtFechaEnvio.Text = n.FechaEnvio;
                    txtHoraEnvio.Text = n.HoraEnvio;
                    txtTipoPersonaCliente.Text = n.TipoPersonaCliente;
                    txtPEPCliente.Text = n.PEPCliente;
                    txtPEPClienteTipo.Text = n.PEPClienteTipo;
                    txtSexoCliente.Text = n.SexoCliente;
                    txtNombreRazonSocialCliente.Text = n.NombreRazonSocialCliente;
                    txtApellidoRazonSocialCliente.Text = n.ApellidoRazonSocialCliente;
                    txtNacionalidadorigenCliente.Text = n.NacionalidadorigenCliente;
                    txtNacionalidadAdquiridaCliente.Text = n.NacionalidadAdquiridaCliente;
                    txtTipoDocumentoCliente.Text = n.TipoDocumentoCliente;
                    txtNoDocumentoIdentidadCliente.Text = n.NoDocumentoIdentidadCliente;
                    txtSiTipoDocumentoIgualOtroEspesificar.Text = n.SiTipoDocumentoIgualOtroEspesificar;
                    txtActividadEconomicaCliente.Text = n.ActividadEconomicaCliente;
                    txtTipoProductoCliente.Text = n.TipoProductoCliente;
                    txtNoCuenta1.Text = n.NoCuenta1;
                    txtNoCuenta2.Text = n.NoCuenta2;
                    txtNoCuenta3.Text = n.NoCuenta3;
                    txtProvinciaCliente.Text = n.ProvinciaCliente;
                    txtMunicipioCliente.Text = n.MunicipioCliente;
                    txtSectorCliente.Text = n.SectorCliente;
                    txtDireccionCliente.Text = n.DireccionCliente;
                    txtTelefonoCasaCliente.Text = n.TelefonoCasaCliente;
                    txtTelefonoOficinaCliente.Text = n.TelefonoOficinaCliente;
                    txtCelular1Cliente.Text = n.Celular1Cliente;
                    txtCelular2Cliente.Text = n.Celular2Cliente;
                    txtTipoTransaccion.Text = n.TipoTransaccion;
                    txtDescripcionTransaccion.Text = n.DescripcionTransaccion;
                    txtTipoMoneda.Text = n.TipoMoneda;
                    txtNumeroRecibo.Text = n.NumeroRecibo.ToString();
                    txtFechaRecibo.Text = n.FechaRecibo;
                    decimal MontoOriginal = (decimal)n.MontoOriginal;
                    txtMontoOriginal.Text = MontoOriginal.ToString("N2");
                    decimal MontoPesos = (decimal)n.PagoAcumuladoPesos;
                    txtPagoAcumuladoPesos.Text = MontoPesos.ToString("N2");
                    decimal MontoDolar = (decimal)n.PagoAcumuladoDollar;
                    txtPagoAcumuladoDollar.Text = MontoDolar.ToString("N2");
                    txtTasaCambio.Text = n.TasaCambio.ToString();
                    txtTipoInstrumento.Text = n.TipoInstrumento;
                    txtFechaTransaccion.Text = n.FechaTransaccion;
                    txtHoraTransaccion.Text = n.HoraTransaccion;
                    txtFechaEnvioDetalle.Text = n.FechaEnvio1;
                    txtHoraTransaccion2.Text = n.HoraTransaccion1;
                    txtOrigenFondos.Text = n.OrigenFondos;
                    txtTransaccionRealizada.Text = n.TransaccionRealizada;
                    txtMotivoTransaccion.Text = n.MotivoTransaccion;
                    txtPaisOrigen.Text = n.PaisOrigen;
                    txtPaisDestino.Text = n.PaisDestino;
                    txtEntidadCorresponsal.Text = n.EntidadCorresponsal;
                    txtRemesador.Text = n.Remesador;
                    txtIntermediarioIgualCliente.Text = n.IntermediarioIgualCliente;
                    txtSexoIntermediario.Text = n.SexoIntermediario;
                    txtNombreRazonIntermediario.Text = n.NombreRazonIntermediario;
                    txtApellidoRazonIntermediario.Text = n.ApellidoRazonIntermediario;
                    txtNacionalidadOrigenIntermediario.Text = n.NacionalidadOrigenIntermediario;
                    txtNacionalidadAdquiridaIntermediario.Text = n.NacionalidadAdquiridaIntermediario;
                    txtTipoRncIntermediario.Text = n.TipoRncIntermediario;
                    txtNoDocumentoIntermediario.Text = n.NoDocumentoIntermediario;
                    txtSiTipoDocumentoIgualOtroEspesificarIntermdiario.Text = n.SiTipoDocumentoIgualOtroEspesificarIntermdiario;
                    txtProvinciaIntermediario.Text = n.ProvinciaIntermediario;
                    txtMunicipioIntermediario.Text = n.MunicipioIntermediario;
                    txtSectorIntermediario.Text = n.SectorIntermediario;
                    txtDireccionIntermediario.Text = n.DireccionIntermediario;
                    txtBeneficiarioIgualCliente.Text = n.BeneficiarioIgualCliente;
                    txtSexoBeneficiario.Text = n.SexoBeneficiario;
                    txtNombreRazonSocialBeneficiario.Text = n.NombreRazonSocialBeneficiario;
                    txtApellidoRazonSocialBeneficiario.Text = n.ApellidoRazonSocialBeneficiario;
                    txtNacionalidadBeneficiario.Text = n.NacionalidadBeneficiario;
                    txtNacionalidadAdquiridaBeneficiario.Text = n.NacionalidadAdquiridaBeneficiario;
                    txtTipoIdentificacionBeneficiario.Text = n.TipoIdentificacionBeneficiario;
                    txtNoDocumentoIdentidadBeneficiario.Text = n.NoDocumentoIdentidadBeneficiario;
                    txtSiTipoDocumentoIgualOtroEspesificarBeneficiario.Text = n.SiTipoDocumentoIgualOtroEspesificar1;
                    txtProvinciaBeneficiario.Text = n.ProvinciaBeneficiario;
                    txtMunicipioBeneficiario.Text = n.MunicipioBeneficiario;
                    txtSectorBeneficiario.Text = n.SectorBeneficiario;
                    txtDireccionBeneficiario.Text = n.DireccionBeneficiario;
                    txtMotivoReporte.Text = n.MotivoReporte;
                    txtEspesifiquePrioridadReporte.Text = n.EspesifiquePrioridadReporte;
                    txtAnexo.Text = n.Anexo;
                    txtValidadoDesde.Text = n.ValidadoDesde;
                    txtValidadoHasta.Text = n.ValidadoHasta;
                    decimal MontoCondicion = (decimal)n.MontoCondicion;
                    txtMontoCondicion2.Text = MontoCondicion.ToString("N2");
                    txtGeneradoPor.Text = n.GeneradoPor;
                }


            }
            else if (TipoOperacionSeleccionada == (int)ConceptosOperacionesSospechosas.OperacionesSospechosas) {

                var SacarDetalleOperacionesSospechosas = ObjData.Value.GenerarReporteDeOperacionesSospechisas(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    Convert.ToDecimal(txtTasa.Text),
                    UsuarioProcesa,
                    Convert.ToDecimal(txtMontoCondicion.Text),
                    Convert.ToDecimal(hfNumeroReciboSeleccionado),
                    hfPolizaSeleccionada);
                foreach (var n in SacarDetalleOperacionesSospechosas) {
                    txtNumeroReporteDetalle.Text = n.NumeroReporte.ToString();
                    txtPolizaDetalle.Text = n.Poliza;
                    txtCodigoRegistroEntidadDetalle.Text = n.CodigoRegistroEntidad;
                    txtUsuario.Text = n.Usuario;
                    txtOficina.Text = n.Oficina;
                    txtFechaEnvio.Text = n.FechaEnvio;
                    txtHoraEnvio.Text = n.HoraEnvio;
                    txtTipoPersonaCliente.Text = n.TipoPersonaCliente;
                    txtPEPCliente.Text = n.PEPCliente;
                    txtPEPClienteTipo.Text = n.PEPClienteTipo;
                    txtSexoCliente.Text = n.SexoCliente;
                    txtNombreRazonSocialCliente.Text = n.NombreRazonSocialCliente;
                    txtApellidoRazonSocialCliente.Text = n.ApellidoRazonSocialCliente;
                    txtNacionalidadorigenCliente.Text = n.NacionalidadorigenCliente;
                    txtNacionalidadAdquiridaCliente.Text = n.NacionalidadAdquiridaCliente;
                    txtTipoDocumentoCliente.Text = n.TipoDocumentoCliente;
                    txtNoDocumentoIdentidadCliente.Text = n.NoDocumentoIdentidadCliente;
                    txtSiTipoDocumentoIgualOtroEspesificar.Text = n.SiTipoDocumentoIgualOtroEspesificar;
                    txtActividadEconomicaCliente.Text = n.ActividadEconomicaCliente;
                    txtTipoProductoCliente.Text = n.TipoProductoCliente;
                    txtNoCuenta1.Text = n.NoCuenta1;
                    txtNoCuenta2.Text = n.NoCuenta2;
                    txtNoCuenta3.Text = n.NoCuenta3;
                    txtProvinciaCliente.Text = n.ProvinciaCliente;
                    txtMunicipioCliente.Text = n.MunicipioCliente;
                    txtSectorCliente.Text = n.SectorCliente;
                    txtDireccionCliente.Text = n.DireccionCliente;
                    txtTelefonoCasaCliente.Text = n.TelefonoCasaCliente;
                    txtTelefonoOficinaCliente.Text = n.TelefonoOficinaCliente;
                    txtCelular1Cliente.Text = n.Celular1Cliente;
                    txtCelular2Cliente.Text = n.Celular2Cliente;
                    txtTipoTransaccion.Text = n.TipoTransaccion;
                    txtDescripcionTransaccion.Text = n.DescripcionTransaccion;
                    txtTipoMoneda.Text = n.TipoMoneda;
                    txtNumeroRecibo.Text = n.NumeroRecibo.ToString();
                    txtFechaRecibo.Text = n.FechaRecibo;
                    decimal MontoOriginal = (decimal)n.MontoOriginal;
                    txtMontoOriginal.Text = MontoOriginal.ToString("N2");
                    decimal MontoPesos = (decimal)n.PagoAcumuladoPesos;
                    txtPagoAcumuladoPesos.Text = MontoPesos.ToString("N2");
                    decimal MontoDolar = (decimal)n.PagoAcumuladoDollar;
                    txtPagoAcumuladoDollar.Text = MontoDolar.ToString("N2");
                    txtTasaCambio.Text = n.TasaCambio.ToString();
                    txtTipoInstrumento.Text = n.TipoInstrumento;
                    txtFechaTransaccion.Text = n.FechaTransaccion;
                    txtHoraTransaccion.Text = n.HoraTransaccion;
                    txtFechaEnvioDetalle.Text = n.FechaEnvio1;
                    txtHoraTransaccion2.Text = n.HoraTransaccion1;
                    txtOrigenFondos.Text = n.OrigenFondos;
                    txtTransaccionRealizada.Text = n.TransaccionRealizada;
                    txtMotivoTransaccion.Text = n.MotivoTransaccion;
                    txtPaisOrigen.Text = n.PaisOrigen;
                    txtPaisDestino.Text = n.PaisDestino;
                    txtEntidadCorresponsal.Text = n.EntidadCorresponsal;
                    txtRemesador.Text = n.Remesador;
                    txtIntermediarioIgualCliente.Text = n.IntermediarioIgualCliente;
                    txtSexoIntermediario.Text = n.SexoIntermediario;
                    txtNombreRazonIntermediario.Text = n.NombreRazonIntermediario;
                    txtApellidoRazonIntermediario.Text = n.ApellidoRazonIntermediario;
                    txtNacionalidadOrigenIntermediario.Text = n.NacionalidadOrigenIntermediario;
                    txtNacionalidadAdquiridaIntermediario.Text = n.NacionalidadAdquiridaIntermediario;
                    txtTipoRncIntermediario.Text = n.TipoRncIntermediario;
                    txtNoDocumentoIntermediario.Text = n.NoDocumentoIntermediario;
                    txtSiTipoDocumentoIgualOtroEspesificarIntermdiario.Text = n.SiTipoDocumentoIgualOtroEspesificarIntermdiario;
                    txtProvinciaIntermediario.Text = n.ProvinciaIntermediario;
                    txtMunicipioIntermediario.Text = n.MunicipioIntermediario;
                    txtSectorIntermediario.Text = n.SectorIntermediario;
                    txtDireccionIntermediario.Text = n.DireccionIntermediario;
                    txtBeneficiarioIgualCliente.Text = n.BeneficiarioIgualCliente;
                    txtSexoBeneficiario.Text = n.SexoBeneficiario;
                    txtNombreRazonSocialBeneficiario.Text = n.NombreRazonSocialBeneficiario;
                    txtApellidoRazonSocialBeneficiario.Text = n.ApellidoRazonSocialBeneficiario;
                    txtNacionalidadBeneficiario.Text = n.NacionalidadBeneficiario;
                    txtNacionalidadAdquiridaBeneficiario.Text = n.NacionalidadAdquiridaBeneficiario;
                    txtTipoIdentificacionBeneficiario.Text = n.TipoIdentificacionBeneficiario;
                    txtNoDocumentoIdentidadBeneficiario.Text = n.NoDocumentoIdentidadBeneficiario;
                    txtSiTipoDocumentoIgualOtroEspesificarBeneficiario.Text = n.SiTipoDocumentoIgualOtroEspesificar1;
                    txtProvinciaBeneficiario.Text = n.ProvinciaBeneficiario;
                    txtMunicipioBeneficiario.Text = n.MunicipioBeneficiario;
                    txtSectorBeneficiario.Text = n.SectorBeneficiario;
                    txtDireccionBeneficiario.Text = n.DireccionBeneficiario;
                    txtMotivoReporte.Text = n.MotivoReporte;
                    txtEspesifiquePrioridadReporte.Text = n.EspesifiquePrioridadReporte;
                    txtAnexo.Text = n.Anexo;
                    txtValidadoDesde.Text = n.ValidadoDesde;
                    txtValidadoHasta.Text = n.ValidadoHasta;
                    decimal MontoCondicion = (decimal)n.MontoCondicion;
                    txtMontoCondicion2.Text = MontoCondicion.ToString("N2");
                    txtGeneradoPor.Text = n.GeneradoPor;
                }
            }
        }

        protected void LinkPrimeraOperacionesSospechosas_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListado();
        }

        protected void LinkAnteriorOperacionesSospechosas_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListado();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior);
        }

        protected void dtPaginacionOperacionesSospechosas_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionOperacionesSospechosas_CancelCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListado();
        }

        protected void LinkSiguienteOperacionesSospechosas_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListado();
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverAtras_Click(object sender, EventArgs e)
        {
            RestablecerPantalla();
        }

        protected void LinkUltimoOperacionesSospechosas_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListado();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior);
        }
    }
}