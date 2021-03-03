using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarReporteFianzas : System.Web.UI.Page
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


        private void HandlePaging(ref DataList NombreDataList,ref Label lbPaginaActual)
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
            lbPaginaActual.Text = (NumeroPagina + 1).ToString();
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
        private void Paginar(ref Repeater ControlRepeater, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref LinkButton PrimeraPagina, ref LinkButton PaginaAnterior, ref LinkButton SiguientePagina, ref LinkButton UltimaPagina)
        {
            pagedDataSource.DataSource = Listado;
            pagedDataSource.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina : _NumeroRegistros);
            pagedDataSource.CurrentPageIndex = CurrentPage;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource.IsLastPage;

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
        private void MoverValoresPaginacion(int Accion,ref Label lbPaginaActual,ref Label lbCantidadPagina)
        {

            int PaginaActual = 0;
            switch (Accion)
            {

                case 1:
                    //PRIMERA PAGINA
                    lbPaginaActual.Text = "1";

                    break;

                case 2:
                    //SEGUNDA PAGINA
                    PaginaActual = Convert.ToInt32(lbPaginaActual.Text);
                    PaginaActual++;
                    lbPaginaActual.Text = PaginaActual.ToString();
                    break;

                case 3:
                    //PAGINA ANTERIOR
                    PaginaActual = Convert.ToInt32(lbPaginaActual.Text);
                    if (PaginaActual > 1)
                    {
                        PaginaActual--;
                        lbPaginaActual.Text = PaginaActual.ToString();
                    }
                    break;

                case 4:
                    //ULTIMA PAGINA
                    lbPaginaActual.Text = lbCantidadPagina.Text;
                    break;


            }

        }
        #endregion

        #region MOSTRAR LOS SUBRAMOS
        private void CargarSubramo(string Ramo)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSubramo, ObjData.Value.BuscaListas("SUBRAMO", Ramo, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSubramHistoriclPoliza, ObjData.Value.BuscaListas("SUBRAMO", Ramo, null), true);
        }
        #endregion

        #region MOSTRAR LOS REGISTROS
        private void MostrarRegistros()
        {
            //VALIDAMOS LOS RANGOS DE FECHA
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "MensajeConsulta", "MensajeConsulta();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeError", "FechaDesdeError();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaHastaError", "FechaHastaError();", true);
                }
            }
            else
            {
                //consultamos
                string _Poliza = string.IsNullOrEmpty(txtpolizaConsulta.Text.Trim()) ? null : txtpolizaConsulta.Text.Trim();
                decimal? _Subramo = ddlSeleccionarSubramo.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSubramo.SelectedValue) : new Nullable<decimal>();

                var Buscar = ObjData.Value.GenerarProduccionFianzas(
                    _Poliza,
                    _Subramo,
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text));
                foreach (var n in Buscar)
                {
                    int Cantidad = Convert.ToInt32(n.Cantidad);
                    lbCantidadRegistros.Text = Cantidad.ToString("N0");
                }
                Paginar(ref rpListadoFianzas, Buscar, 10, ref lbCantidadPaginaVariableFianzas, ref LinkPrimeraPaginaFianzas, ref LinkPaginaAnteriorFianzas, ref LinkSiguientePaginaFianzas, ref LinkUltimaPaginaFianzas);
                HandlePaging(ref dtPaginacionFianzas, ref lbPaginaActualVariableFianzas);
            }
        }
        #endregion
        #region CONSULTAR HISTORICO
        private void ConsultarHistorico()
        {
            string _poliza = string.IsNullOrEmpty(txtPolizaHistoricoPoliza.Text.Trim()) ? null : txtPolizaHistoricoPoliza.Text.Trim();
            int? _Subramo = ddlSeleccionarSubramHistoriclPoliza.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubramHistoriclPoliza.SelectedValue) : new Nullable<int>();

            var Buscar = ObjData.Value.BuscaHistoriclPoliza(
                _poliza,
                _Subramo,
                Convert.ToDateTime(txtFechaDesdeHistoricoPoliza.Text),
                Convert.ToDateTime(txtFechaHAstaHistoricoPoliza.Text));
            int CantidadRegistros;
            foreach (var n in Buscar)
            {
                CantidadRegistros = Convert.ToInt32(n.CantidadRegistros);
                lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
            }
            Paginar(ref rpListadoHistoricoFianzas, Buscar, 10, ref lbCantidadPaginaVariableHistoricoFianzas, ref LinkPrimeraPaginaHistoricoFianzas, ref LinkPaginaAnteriorHistoricoFianzas, ref LinkSiguientePaginaHistoricoFianzas, ref LinkUltimaPaginaHistoricoFianzas);
            HandlePaging(ref dtPaginacionHistoricoFianzas, ref lbPaginaActualVariableHistoricoFianzas);
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "REPORTE DE FIANZAS";
                CargarSubramo("103");
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarRegistros();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            try {
                //VALIDAMOS LOS RANGOS DE FECHA
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "MensajeConsulta", "MensajeConsulta();", true);
                    if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaDesdeError", "FechaDesdeError();", true);
                    }
                    if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaHastaError", "FechaHastaError();", true);
                    }
                }
                else
                {
                    string _Poliza = string.IsNullOrEmpty(txtpolizaConsulta.Text.Trim()) ? null : txtpolizaConsulta.Text.Trim();
                    decimal? _Subramo = ddlSeleccionarSubramo.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSubramo.SelectedValue) : new Nullable<decimal>();

                    var Exportar = (from n in ObjData.Value.GenerarProduccionFianzas(
                        _Poliza,
                        _Subramo,
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text))
                                    select new
                                    {
                                        NoFactura = n.NoFactura,
                                        Poliza = n.Poliza,
                                        Estatus = n.Estatus,
                                        NoFormulario=n.NoFormulario,
                                        Ramo = n.Ramo,
                                        SubRamo = n.SubRamo,
                                        Cliente = n.Cliente,
                                        TelefonoResidencia = n.TelefonoResidencia,
                                        TelefonoOficina = n.TelefonoOficina,
                                        Celular = n.Celular,
                                        fax = n.fax,
                                        Otro = n.Otro,
                                        Direccion = n.Direccion,
                                        UbicacionCliente = n.UbicacionCliente,
                                        ProvinciaCliente = n.ProvinciaCliente,
                                        MunicipioCliente = n.MunicipioCliente,
                                        SectorCliente = n.SectorCliente,
                                        Supervisor = n.Supervisor,
                                        Intermediario = n.Intermediario,
                                        UbicacionIntermediario = n.UbicacionIntermediario,
                                        ProvinciaIntermediario = n.ProvinciaIntermediario,
                                        MunicipioIntermediario = n.MunicipioIntermediario,
                                        SectorIntermediario = n.SectorIntermediario,
                                        FechaFacturacion = n.FechaFacturacion,
                                        InicioVigencia = n.InicioVigencia,
                                        FinVigencia = n.FinVigencia,
                                        SumaAsegurada = n.SumaAsegurada,
                                        Neto = n.Neto,
                                        Tasa = n.Tasa,
                                        Impuesto = n.Impuesto,
                                        PorcComision = n.PorcComision,
                                        Facturado = n.Facturado,
                                        Cobrado = n.Cobrado,
                                        Balance = n.Balance,
                                        LeyInfraccionImputado = n.LeyInfraccionImputado

                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion de Fianzas", Exportar);
                }
            }
            catch (Exception) { }
        }


 

        protected void btnConsultarHistorico_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeHistoricoPoliza.Text.Trim()) || string.IsNullOrEmpty(txtFechaHAstaHistoricoPoliza.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "MensajeConsulta", "MensajeConsulta();", true);
            }
            else {

                try {
                    ConsultarHistorico();
                }
                catch (Exception) { }

            }
        }

        protected void LinkPrimeraPaginaFianzas_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarRegistros();
        }

        protected void LinkPaginaAnteriorFianzas_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarRegistros();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableFianzas, ref lbCantidadPaginaVariableFianzas);
        }

        protected void dtPaginacionFianzas_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionFianzas_CancelCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarRegistros();
        }

        protected void LinkSiguientePaginaFianzas_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarRegistros();
        }

        protected void LinkUltimaPaginaFianzas_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarRegistros();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableFianzas, ref lbCantidadPaginaVariableFianzas);
        }

        protected void LinkPrimeraPaginaHistoricoFianzas_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            ConsultarHistorico();
        }

        protected void LinkPaginaAnteriorHistoricoFianzas_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            ConsultarHistorico();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableHistoricoFianzas, ref lbCantidadPaginaVariableHistoricoFianzas);
        }

        protected void dtPaginacionHistoricoFianzas_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionHistoricoFianzas_CancelCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            ConsultarHistorico();
        }

        protected void LinkSiguientePaginaHistoricoFianzas_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            ConsultarHistorico();
        }

        protected void LinkUltimaPaginaHistoricoFianzas_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            ConsultarHistorico();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableHistoricoFianzas, ref lbCantidadPaginaVariableHistoricoFianzas);
        }

        protected void btnExportarHistoriclPoliza_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeHistoricoPoliza.Text.Trim()) || string.IsNullOrEmpty(txtFechaHAstaHistoricoPoliza.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "MensajeConsulta", "MensajeConsulta();", true);
            }
            else
            {
                try {
                    string _poliza = string.IsNullOrEmpty(txtPolizaHistoricoPoliza.Text.Trim()) ? null : txtPolizaHistoricoPoliza.Text.Trim();
                    int? _Subramo = ddlSeleccionarSubramHistoriclPoliza.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubramHistoriclPoliza.SelectedValue) : new Nullable<int>();

                    var Exportar = (from n in ObjData.Value.BuscaHistoriclPoliza(
                        _poliza,
                        _Subramo,
                        Convert.ToDateTime(txtFechaDesdeHistoricoPoliza.Text),
                        Convert.ToDateTime(txtFechaHAstaHistoricoPoliza.Text))
                                    select new
                                    {
                                        Poliza = n.Poliza,
                                        Estatus = n.Estatus,
                                        Cliente = n.Cliente,
                                        Intermediario = n.Intermediario,
                                        Prima = n.Prima,
                                        SumaAsegurada = n.SumaAsegurada,
                                        Ramo = n.Ramo,
                                        Subramo = n.Subramo,
                                        Concepto = n.Concepto,
                                        FechaFacturacionFormateada = n.Fecha,
                                        FechaFacturacion = n.Fecha0,
                                        Usuario = n.Usuario,
                                        Valor = n.Valor,
                                        TotalFacturado = n.TotalFacturado,
                                        TotalCobrado = n.TotalCobrado,
                                        Balance = n.Balance,
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Historico de Polizas Fianzas", Exportar);
                }
                catch (Exception) { }
                //EXPORTAR
            }
        }
    }
}