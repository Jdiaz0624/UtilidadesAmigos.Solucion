using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace UtilidadesAmigos.Solucion.Paginas.Consulta
{
    public partial class GestionCobros : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objdata = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta> ObjDataConsulta = new Lazy<Logica.Logica.LogicaConsulta.LogicaConsulta>();

        #region ENUMERACIONES
        enum Enumeraciones_Ramos { 
        
            Vehiculo_Motor=106
        }

        enum Enumeraciones_SubRamo
        {
            Motores = 1
        }
        #endregion

        #region CONTROL DE PAGINACION DE GESTION DE COBROS HEADER 	
        readonly PagedDataSource pagedDataSource_GestionCobrosHeader = new PagedDataSource();
        int _PrimeraPagina_GestionCobrosHeader, _UltimaPagina_GestionCobrosHeader;
        private int _TamanioPagina_GestionCobrosHeader = 10;
        private int CurrentPage_GestionCobrosHeader
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

        private void HandlePaging_GestionCobrosHeader(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_GestionCobrosHeader = CurrentPage_GestionCobrosHeader - 5;
            if (CurrentPage_GestionCobrosHeader > 5)
                _UltimaPagina_GestionCobrosHeader = CurrentPage_GestionCobrosHeader + 5;
            else
                _UltimaPagina_GestionCobrosHeader = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_GestionCobrosHeader > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_GestionCobrosHeader = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_GestionCobrosHeader = _UltimaPagina_GestionCobrosHeader - 10;
            }

            if (_PrimeraPagina_GestionCobrosHeader < 0)
                _PrimeraPagina_GestionCobrosHeader = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_GestionCobrosHeader;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_GestionCobrosHeader; i < _UltimaPagina_GestionCobrosHeader; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_GestionCobrosHeader(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_GestionCobrosHeader.DataSource = Listado;
            pagedDataSource_GestionCobrosHeader.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_GestionCobrosHeader.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_GestionCobrosHeader.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_GestionCobrosHeader.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_GestionCobrosHeader : _NumeroRegistros);
            pagedDataSource_GestionCobrosHeader.CurrentPageIndex = CurrentPage_GestionCobrosHeader;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_GestionCobrosHeader.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_GestionCobrosHeader.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_GestionCobrosHeader.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_GestionCobrosHeader.IsLastPage;

            RptGrid.DataSource = pagedDataSource_GestionCobrosHeader;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_GestionCobrosHeader
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_GestionCobrosHeader(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarRamos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlRamoConsulta, Objdata.Value.BuscaListas("RAMO", null, null), true);
        }
        private void CargarSubramos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSubRamoConsulta, Objdata.Value.BuscaListas("SUBRAMO", ddlRamoConsulta.SelectedValue, null), true);

        }
        private void CargarOficina()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddloficina, Objdata.Value.BuscaListas("OFICINANORMAL", null, null), true);
        }

        private void ValidarBalance()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlValidarBalance, Objdata.Value.BuscaListas("VALIDABALANCE", null, null));
        }
        private void ExcluirMotores()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlExcluirMotores, Objdata.Value.BuscaListas("EXCLUIR", null, null));
        }

        private void CargarListas() {
            CargarRamos();
            CargarSubramos();
            CargarOficina();
            ValidarBalance();
            
        }
        #endregion

        #region MOSTRAR LA GESTION DE COBROS HEADER
        private void MostrarGestionCobrosHeader() {

            DateTime? _FechaCorte = string.IsNullOrEmpty(txtFechaCorte.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaCorte.Text);
            int? _Ramo = ddlRamoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlRamoConsulta.SelectedValue) : new Nullable<int>();
            int? _SubRamo = ddlSubRamoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSubRamoConsulta.SelectedValue) : new Nullable<int>();
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _oficina = ddloficina.SelectedValue != "-1" ? Convert.ToInt32(ddloficina.SelectedValue) : new Nullable<int>();
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioConsulta.Text);


            var Header = ObjDataConsulta.Value.BuscaGestionCobrosheader(
                _FechaCorte,
                _Ramo,
                _SubRamo,
                _Poliza,
                _oficina,
                _Supervisor,
                _Intermediario);
            if (Header.Count() < 1) {
                rpAntiguedadSaldo.DataSource = null;
                rpAntiguedadSaldo.DataBind();

            }
            else {

                Paginar_GestionCobrosHeader(ref rpAntiguedadSaldo, Header, 10, ref lbCantidadPaginaVariable_Antiguedad, ref btnPrimeraPagina_Antiguedad, ref btnPaginaAnterior_Antiguedad, ref btnPaginaSiguiente_Antiguedad, ref btnUltimaPagina_Antiguedad);
                HandlePaging_GestionCobrosHeader(ref dtPaginacion_Antiguedad, ref lbPaginaActual_Antiguedad);
            }
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
                lbPantalla.Text = "Gestion de Cobros";

                DIVBloqueProceso.Visible = false;
                DIVBloqueConsulta.Visible = true;
                cbReporteComentaro.Text = "Marcar para generar reporte de Comentarios";
                CargarListas();
                DivExcluirMotores.Visible = false;

                DateTime Hoy = DateTime.Now;
                txtFechaCorte.Text = Hoy.ToString("yyyy-MM-dd");
            }
        }

        protected void cbReporteComentaro_CheckedChanged(object sender, EventArgs e)
        {
            if (cbReporteComentaro.Checked == true) {
                cbReporteComentaro.Text = "Desmarcar para generar reporte de Gestion de Cobros";
            }
            else {
                cbReporteComentaro.Text = "Marcar para generar reporte de Comentarios";
            }
        }

        protected void ddlRamoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSubramos();
        }

        protected void txtCodigoIntermediarioConsulta_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Intermediario = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediarioConsulta.Text);
            txtNombreIntermediario.Text = Intermediario.SacarNombreIntermediario();
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Supervisor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisor.Text);
            txtNombreSupervisor.Text = Supervisor.SacarNombreSupervisor();
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_GestionCobrosHeader = 0;
            MostrarGestionCobrosHeader();
        }

        protected void btnExportarExcel_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnGestionCobros_Click(object sender, ImageClickEventArgs e)
        {
            DIVBloqueConsulta.Visible = false;
            DIVBloqueProceso.Visible = true;
        }

        protected void btnPrimeraPagina_Antiguedad_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_Antiguedad_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_Antiguedad_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_Antiguedad_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnPaginaSiguiente_Antiguedad_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_Antiguedad_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_DatoVehiculo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_DatoVehiculo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_DatoVehiculo_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_DatoVehiculo_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePagina_DatoVehiculo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_DatoVehiculo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlSeleccionarEstatusLLamadaGestionCobros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSeleccionarConceptoGestionCobros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_GestionCobros_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVolver_GestionCobros_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_Comentarios_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_Comentarios_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_Comentarios_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void btnPaginaSiguiente_Comentarios_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_Comentarios_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_Comentarios_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void ddlSubRamoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Ramo = Convert.ToInt32(ddlRamoConsulta.SelectedValue);

            if (Ramo == (int)Enumeraciones_Ramos.Vehiculo_Motor) {
                DivExcluirMotores.Visible = true;
                ExcluirMotores();
            }
            else {
                DivExcluirMotores.Visible = false;
            }
        }
    }

    
}