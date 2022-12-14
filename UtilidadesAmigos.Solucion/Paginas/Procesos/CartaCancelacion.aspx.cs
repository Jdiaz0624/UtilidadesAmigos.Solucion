using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace UtilidadesAmigos.Solucion.Paginas.Procesos
{
    public partial class CartaCancelacion : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjDataProcesos = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();

        #region CONTROL DE PAGINACION DE CARTA DE CANCELACION DE ASEGURADO	
        readonly PagedDataSource pagedDataSource_CartaAsegurado = new PagedDataSource();
        int _PrimeraPagina_CartaAsegurado, _UltimaPagina_CartaAsegurado;
        private int _TamanioPagina_CartaAsegurado = 10;
        private int CurrentPage_CartaAsegurado
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

        private void HandlePaging_CartaAsegurado(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_CartaAsegurado = CurrentPage_CartaAsegurado - 5;
            if (CurrentPage_CartaAsegurado > 5)
                _UltimaPagina_CartaAsegurado = CurrentPage_CartaAsegurado + 5;
            else
                _UltimaPagina_CartaAsegurado = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_CartaAsegurado > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_CartaAsegurado = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_CartaAsegurado = _UltimaPagina_CartaAsegurado - 10;
            }

            if (_PrimeraPagina_CartaAsegurado < 0)
                _PrimeraPagina_CartaAsegurado = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_CartaAsegurado;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_CartaAsegurado; i < _UltimaPagina_CartaAsegurado; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_CartaAsegurado(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_CartaAsegurado.DataSource = Listado;
            pagedDataSource_CartaAsegurado.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_CartaAsegurado.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_CartaAsegurado.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_CartaAsegurado.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_CartaAsegurado : _NumeroRegistros);
            pagedDataSource_CartaAsegurado.CurrentPageIndex = CurrentPage_CartaAsegurado;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_CartaAsegurado.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_CartaAsegurado.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_CartaAsegurado.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_CartaAsegurado.IsLastPage;

            RptGrid.DataSource = pagedDataSource_CartaAsegurado;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_CartaAsegurado
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_CartaAsegurado(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
                    lbPaginaActual.Text = lbCantidadPaginas.Text;
                    break;


            }

        }
        #endregion
        #region CONTROL DE PAGINACION DE CARTA DE CANCELACION DE INTERMEDIARIO
        readonly PagedDataSource pagedDataSource_CartaIntermediario = new PagedDataSource();
        int _PrimeraPagina_CartaIntermediario, _UltimaPagina_CartaIntermediario;
        private int _TamanioPagina_CartaIntermediario = 10;
        private int CurrentPage_CartaIntermediario
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

        private void HandlePaging_CartaIntermediario(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_CartaIntermediario = CurrentPage_CartaIntermediario - 5;
            if (CurrentPage_CartaIntermediario > 5)
                _UltimaPagina_CartaIntermediario = CurrentPage_CartaIntermediario + 5;
            else
                _UltimaPagina_CartaIntermediario = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_CartaIntermediario > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_CartaIntermediario = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_CartaIntermediario = _UltimaPagina_CartaIntermediario - 10;
            }

            if (_PrimeraPagina_CartaIntermediario < 0)
                _PrimeraPagina_CartaIntermediario = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_CartaIntermediario;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_CartaIntermediario; i < _UltimaPagina_CartaIntermediario; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_CartaIntermediario(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_CartaIntermediario.DataSource = Listado;
            pagedDataSource_CartaIntermediario.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_CartaIntermediario.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_CartaIntermediario.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_CartaIntermediario.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_CartaIntermediario : _NumeroRegistros);
            pagedDataSource_CartaIntermediario.CurrentPageIndex = CurrentPage_CartaIntermediario;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_CartaIntermediario.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_CartaIntermediario.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_CartaIntermediario.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_CartaIntermediario.IsLastPage;

            RptGrid.DataSource = pagedDataSource_CartaIntermediario;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_CartaIntermediario
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_CartaIntermediario(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
                    lbPaginaActual.Text = lbCantidadPaginas.Text;
                    break;


            }

        }
        #endregion
        #region LISTADO DE CARTA DE CANCELACIONES DE ASEGURADOS E INTERMEDIARIOS
        private void ListadoCartaAsegurado() {

            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor_CartaAsegurado.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor_CartaAsegurado.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario_CartaAsegurado.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario_CartaAsegurado.Text);
            decimal? _Asegurado = string.IsNullOrEmpty(txtCodigoAsegurado_CartaAsegurado.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoAsegurado_CartaAsegurado.Text);
            string _Poliza = string.IsNullOrEmpty(txtPoliza_CartaAsegurado.Text.Trim()) ? null : txtPoliza_CartaAsegurado.Text.Trim();
            int? _CantidadDias = string.IsNullOrEmpty(txtDias_CartaAsegurado.Text.Trim()) ? 0 : Convert.ToInt32(txtDias_CartaAsegurado.Text);


            var Listado = ObjDataProcesos.Value.BuscaCartaCancelacionAsegurado(
                _Supervisor,
                _Intermediario,
                _Asegurado,
                _Poliza,
                _CantidadDias);
            if (Listado.Count() < 1) {
                rpListadoCartaAsegurado.DataSource = null;
                rpListadoCartaAsegurado.DataBind();
            }
            else {

                Paginar_CartaAsegurado(ref rpListadoCartaAsegurado, Listado, 10, ref lbCantidadPaginaVariable_CartaAsegurado, ref btnPrimeraPagina_CartaAsegurado, ref btnPaginaAnterior_CartaAsegurado, ref btnPaginaSiguiente_CartaAsegurado, ref btnUltimaPagina_CartaAsegurado);
                HandlePaging_CartaAsegurado(ref dtPaginacion_CartaAsegurado, ref lbPaginaActual_CartaAsegurado);
            }
        }

        private void ListadoCartaIntermediario() {

            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor_CartaIntermediario.Text) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor_CartaIntermediario.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario_CartaIntermediario.Text) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario_CartaIntermediario.Text);

            var Listado = ObjDataProcesos.Value.BuscaCartaCancelacionIntermediario(
                _Supervisor,
                _Intermediario);
            if (Listado.Count() < 1) {

                rpListadoCartaIntermediario.DataSource = null;
                rpListadoCartaIntermediario.DataBind();
            }
            else {

                Paginar_CartaIntermediario(ref rpListadoCartaIntermediario, Listado, 10, ref lbCantidadPaginaVariable_CartaIntermediario, ref btnPrimeraPagina_CartaIntermediario, ref btnPaginaAnterior_CartaIntermediario, ref btnPaginaSiguiente_CartaIntermediario, ref btnUltimaPagina_CartaIntermediario);
                HandlePaging_CartaIntermediario(ref dtPaginacion_CartaIntermediario, ref lbPaginaActual_CartaIntermediario);
            }
        }
        #endregion

        #region GENERAR REPORTE DE CARTA DE CANCELACION DE ASEGURADOS E INTERMEDIARIOS
        private void CartaCancelacionAsegurado(int Supervisor, int Intermediario, decimal Cliente, string Poliza,string Asegurado) {

            string RutaReporte = "", UsuarioBD = "", ClaveBD = "", NombreCarta = "";

            RutaReporte = Server.MapPath("CartaCancelacionAsegurado.rpt");
            UsuarioBD = "sa";
            ClaveBD = "Pa$$W0rd";
            NombreCarta = "Carta de Cancelación de " + Asegurado;

            ReportDocument Carta = new ReportDocument();

            Carta.Load(RutaReporte);
            Carta.Refresh();

            Carta.SetParameterValue("@Supervisor", Supervisor);
            Carta.SetParameterValue("@Intermediario", Intermediario);
            Carta.SetParameterValue("@Cliente", Cliente);
            Carta.SetParameterValue("@Poliza", Poliza);
            Carta.SetParameterValue("@CantidadDIas", new Nullable<int>());

            Carta.SetDatabaseLogon(UsuarioBD, ClaveBD);

            Carta.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreCarta);

            Carta.Close();
            Carta.Dispose();
        }

        private void CartaCancelacionIntermediario(int Supervisor, int Intermediario, string NombreIntermediario) {

            string RutaReporte = "", UsuarioBD = "", ClaveBD = "", NombreReporte = "";

            RutaReporte = Server.MapPath("CartaCancelacionIntermediarios.rpt");
            UsuarioBD = "sa";
            ClaveBD = "Pa$$W0rd";
            NombreReporte = "Carta de Cancelación de " + NombreIntermediario;

            ReportDocument Carta = new ReportDocument();

            Carta.Load(RutaReporte);
            Carta.Refresh();

            Carta.SetParameterValue("@Supervisor", Supervisor);
            Carta.SetParameterValue("@Intermediario", Intermediario);

            Carta.SetDatabaseLogon(UsuarioBD, ClaveBD);

            Carta.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);

            Carta.Close();
            Carta.Dispose();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["Idusuario"]);
                Label lbUsuarioConectado = (Label)Master.FindControl("lbUsuarioConectado");
                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");

                lbUsuarioConectado.Text = Nombre.SacarNombreUsuarioConectado();
                lbPantalla.Text = "Carta de Cancelación de Asegurados / Intermediarios";

                rbCartaCancelacionAsegurado.Checked = true;
                DivBloqueCartaCancelacionAsegurado.Visible = true;
                DIVBloqueCartaCancelacionIntermediario.Visible = false;

                rbCartaCancelacionIntermediario.Enabled = false;
            }
        }

        protected void rbCartaCancelacionAsegurado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCartaCancelacionAsegurado.Checked == true) {
                DivBloqueCartaCancelacionAsegurado.Visible = true;
                DIVBloqueCartaCancelacionIntermediario.Visible = false;
            }
            else {
                DivBloqueCartaCancelacionAsegurado.Visible = false;
                DIVBloqueCartaCancelacionIntermediario.Visible = false;
            }
        }

        protected void rbCartaCancelacionIntermediario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCartaCancelacionIntermediario.Checked == true) {
                DivBloqueCartaCancelacionAsegurado.Visible = false;
                DIVBloqueCartaCancelacionIntermediario.Visible = true;
            }
            else {
                DivBloqueCartaCancelacionAsegurado.Visible = false;
                DIVBloqueCartaCancelacionIntermediario.Visible = false;
            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CartaAsegurado = 0;
            ListadoCartaAsegurado();
        }

        protected void txtCodigoSupervisor_CartaAsegurado_TextChanged(object sender, EventArgs e)
        {
            try {

                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisor_CartaAsegurado.Text);
                txtNombreSupervisor_CartaAsegurado.Text = Nombre.SacarNombreSupervisor();
            }
            catch (Exception) {
                txtNombreSupervisor_CartaAsegurado.Text = string.Empty;
            }
        }

        protected void txtCodigoIntermediario_CartaAsegurado_TextChanged(object sender, EventArgs e)
        {
            try {
                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediario_CartaAsegurado.Text);
                txtNombreIntermediario_CartaAsegurado.Text = Nombre.SacarNombreIntermediario();
            }
            catch (Exception) {
                txtNombreIntermediario_CartaAsegurado.Text = string.Empty;
            }
        }

        protected void txtCodigoAsegurado_CartaAsegurado_TextChanged(object sender, EventArgs e)
        {
            try {

                UtilidadesAmigos.Logica.Comunes.ESacarNombreCliente Nombre = new Logica.Comunes.ESacarNombreCliente(txtCodigoAsegurado_CartaAsegurado.Text);
                txtNombreAsegurado_CartaAsegurado.Text = Nombre.SacarCodigoCLiente();
            }
            catch (Exception) {
                txtNombreAsegurado_CartaAsegurado.Text = string.Empty;
            }
        }

        protected void btnCartaAsegurado_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;

            var Supervisor = ((HiddenField)ItemSeleccionado.FindControl("hfSupervisor_CartaAsegurado")).Value.ToString();
            var Intermediario = ((HiddenField)ItemSeleccionado.FindControl("hfIntermediario_CargaAsegurado")).Value.ToString();
            var Asegurado = ((HiddenField)ItemSeleccionado.FindControl("hfAsegurado_CartaIAsegurado")).Value.ToString();
            var Poliza = ((HiddenField)ItemSeleccionado.FindControl("hfPoliza_CartaAsegurado")).Value.ToString();
            var NombreAsegurado = ((HiddenField)ItemSeleccionado.FindControl("hfNombreAsegurado_CartaAsegurado")).Value.ToString();

            CartaCancelacionAsegurado(
                Convert.ToInt32(Supervisor),
                Convert.ToInt32(Intermediario),
                Convert.ToDecimal(Asegurado),
                Poliza,
                NombreAsegurado);
        }

        protected void btnPrimeraPagina_CartaAsegurado_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CartaAsegurado = 0;
            ListadoCartaAsegurado(); 
        }

        protected void btnPaginaAnterior_CartaAsegurado_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CartaAsegurado += -1;
            ListadoCartaAsegurado();
            MoverValoresPaginacion_CartaAsegurado((int)OpcionesPaginacionValores_CartaAsegurado.PaginaAnterior, ref lbPaginaActual_CartaAsegurado, ref lbCantidadPaginaVariable_CartaAsegurado);
        }

        protected void dtPaginacion_CartaAsegurado_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_CartaAsegurado_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_CartaAsegurado = Convert.ToInt32(e.CommandArgument.ToString());
            ListadoCartaAsegurado();
        }

        protected void btnPaginaSiguiente_CartaAsegurado_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CartaAsegurado += 1;
            ListadoCartaAsegurado();

        }

        protected void btnUltimaPagina_CartaAsegurado_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CartaAsegurado = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            ListadoCartaAsegurado();
            MoverValoresPaginacion_CartaAsegurado((int)OpcionesPaginacionValores_CartaAsegurado.UltimaPagina, ref lbPaginaActual_CartaAsegurado, ref lbCantidadPaginaVariable_CartaAsegurado);
        }

        protected void txtCodigoSupervisor_CartaIntermediario_TextChanged(object sender, EventArgs e)
        {
            try {
                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisor_CartaIntermediario.Text);
                txtNombreSupervisor_CartaIntermediario.Text = Nombre.SacarNombreSupervisor();
            }
            catch (Exception) {
                txtNombreSupervisor_CartaIntermediario.Text = string.Empty;
            }
        }

        protected void txtCodigoIntermediario_CartaIntermediario_TextChanged(object sender, EventArgs e)
        {
            try {
                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediario_CartaIntermediario.Text);
                txtNombreIntermediario_CartaIntermediario.Text = Nombre.SacarNombreIntermediario();
            }
            catch (Exception) { }
        }

        protected void btnConsukltar_CartaIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CartaIntermediario = 0;
            ListadoCartaIntermediario();
        }

        protected void btnPrimeraPagina_CartaIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CartaIntermediario = 0;
            ListadoCartaIntermediario();
        }

        protected void btnPaginaAnterior_CartaIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CartaIntermediario += -1;
            ListadoCartaIntermediario();
            MoverValoresPaginacion_CartaIntermediario((int)OpcionesPaginacionValores_CartaIntermediario.PaginaAnterior, ref lbPaginaActual_CartaIntermediario, ref lbCantidadPaginaVariable_CartaIntermediario);
        }

        protected void dtPaginacion_CartaIntermediario_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_CartaIntermediario_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_CartaIntermediario = Convert.ToInt32(e.CommandArgument.ToString());
            ListadoCartaIntermediario();
        }

        protected void btnCartaIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;

            var Supervisor = ((HiddenField)ItemSeleccionado.FindControl("hfSupervisor_CartaIntermediario")).Value.ToString();
            var Intermediario = ((HiddenField)ItemSeleccionado.FindControl("hfIntermediario_CartaIntermediario")).Value.ToString();
            var NombreIntermediario = ((HiddenField)ItemSeleccionado.FindControl("hfNombreIntermediario")).Value.ToString();

            CartaCancelacionIntermediario(
                Convert.ToInt32(Supervisor),
                Convert.ToInt32(Intermediario),
                NombreIntermediario);
        }

        protected void btnCartasEnLote_Click(object sender, ImageClickEventArgs e)
        {
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor_CartaAsegurado.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor_CartaAsegurado.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario_CartaAsegurado.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario_CartaAsegurado.Text);
            decimal? _Asegurado = string.IsNullOrEmpty(txtCodigoAsegurado_CartaAsegurado.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoAsegurado_CartaAsegurado.Text);
            string _Poliza = string.IsNullOrEmpty(txtPoliza_CartaAsegurado.Text.Trim()) ? null : txtPoliza_CartaAsegurado.Text.Trim();
            int? _CantidadDias = string.IsNullOrEmpty(txtDias_CartaAsegurado.Text.Trim()) ? 0 : Convert.ToInt32(txtDias_CartaAsegurado.Text);

            string RutaReporte = "", UsuarioBD = "", ClaveBD = "", NombreCarta = "";

            RutaReporte = Server.MapPath("CartaCancelacionAsegurado.rpt");
            UsuarioBD = "sa";
            ClaveBD = "Pa$$W0rd";
            NombreCarta = "Carta de Cancelaciónes en Lote";

            ReportDocument Carta = new ReportDocument();

            Carta.Load(RutaReporte);
            Carta.Refresh();

            Carta.SetParameterValue("@Supervisor", _Supervisor);
            Carta.SetParameterValue("@Intermediario", _Intermediario);
            Carta.SetParameterValue("@Cliente", _Asegurado);
            Carta.SetParameterValue("@Poliza", _Poliza);
            Carta.SetParameterValue("@CantidadDIas", _CantidadDias);

            Carta.SetDatabaseLogon(UsuarioBD, ClaveBD);

            Carta.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreCarta);

            Carta.Close();
            Carta.Dispose();
        }

        protected void btnPaginaSiguiente_CartaIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CartaIntermediario += 1;
            ListadoCartaIntermediario();
        }

        protected void btnUltimaPagina_CartaIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CartaIntermediario = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            ListadoCartaIntermediario();
            MoverValoresPaginacion_CartaIntermediario((int)OpcionesPaginacionValores_CartaIntermediario.UltimaPagina, ref lbPaginaActual_CartaIntermediario, ref lbCantidadPaginaVariable_CartaIntermediario);
        }
    }
}