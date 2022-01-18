using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas.Consulta
{
    public partial class EstadisticaRenovacion : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataComun = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta> ObjDataConsulta = new Lazy<Logica.Logica.LogicaConsulta.LogicaConsulta>();

        enum ConceptosAgrupacion { 
        NoAgrupado=1,
        AgruparPorOficina=2,
        AgruparPorRamo=3,
        AgruparPorIntermediario=4,
        AgruparPorSupervisor=5
        }

        enum RamoPorDefecto { 
        VahiculoMotor = 106
        }

        #region CONTROL DE PAGINACION DE ESTADISTICA DE RENOVACION
        readonly PagedDataSource pagedDataSource_EstadisticaRenovacion = new PagedDataSource();
        int _PrimeraPagina_EstadisticaRenovacion, _UltimaPagina_EstadisticaRenovacion;
        private int _TamanioPagina_EstadisticaRenovacion = 10;
        private int CurrentPage_EstadisticaRenovacion
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

        private void HandlePaging_EstadisticaRenovacion(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_EstadisticaRenovacion = CurrentPage_EstadisticaRenovacion - 5;
            if (CurrentPage_EstadisticaRenovacion > 5)
                _UltimaPagina_EstadisticaRenovacion = CurrentPage_EstadisticaRenovacion + 5;
            else
                _UltimaPagina_EstadisticaRenovacion = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_EstadisticaRenovacion > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_EstadisticaRenovacion = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_EstadisticaRenovacion = _UltimaPagina_EstadisticaRenovacion - 10;
            }

            if (_PrimeraPagina_EstadisticaRenovacion < 0)
                _PrimeraPagina_EstadisticaRenovacion = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_EstadisticaRenovacion;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_EstadisticaRenovacion; i < _UltimaPagina_EstadisticaRenovacion; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_EstadisticaRenovacion(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_EstadisticaRenovacion.DataSource = Listado;
            pagedDataSource_EstadisticaRenovacion.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_EstadisticaRenovacion.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_EstadisticaRenovacion.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_EstadisticaRenovacion.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_EstadisticaRenovacion : _NumeroRegistros);
            pagedDataSource_EstadisticaRenovacion.CurrentPageIndex = CurrentPage_EstadisticaRenovacion;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_EstadisticaRenovacion.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_EstadisticaRenovacion.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_EstadisticaRenovacion.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_EstadisticaRenovacion.IsLastPage;

            RptGrid.DataSource = pagedDataSource_EstadisticaRenovacion;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_EstadisticaRenovacion
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_EstadisticaRenovacion(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        private void CargarOficinas() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficina, ObjDataComun.Value.BuscaListas("OFICINANORMAL", null, null), true);
        }

        private void CargarRamos() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjDataComun.Value.BuscaListas("RAMO", null, null), true);
        }
        private void CargarSubRamo() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSubramo, ObjDataComun.Value.BuscaListas("SUBRAMO", ddlSeleccionarRamo.SelectedValue.ToString(), null), true);
        }
        #endregion

        #region PROCESO DE CARGA DE INFORMACION
        private void CargarInformacion() {

            decimal IdUsuario = (decimal)Session["IdUsuario"];
            //ELIMINAMOS DATOS
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionEstadisticaRenovacion Eliminar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionEstadisticaRenovacion(
                IdUsuario, 0, "", "", 0, 0, 0, 0, 0, DateTime.Now, DateTime.Now,false,"DELETE");

            Eliminar.ProcesarInformacion();

            //BUSCAMOS LA INFORMACION A PROCESAR
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {

                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);

                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true); }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true); }
            }
            else {

                int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : (int)RamoPorDefecto.VahiculoMotor;
                int? _SubRamo = ddlSeleccionarSubramo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubramo.SelectedValue) : new Nullable<int>();
                int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);
                int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
                decimal? _Cliente = string.IsNullOrEmpty(txtCodigoCliente.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoCliente.Text);
                string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
                bool ExcluirMotores = cbExcluirMotores.Checked;

                var BuscarInformacion = ObjDataConsulta.Value.BuscaEstadisticaRenovacionOrigen(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    _Oficina,
                    _Ramo,
                    _SubRamo,
                    _Poliza,
                    _Intermediario,
                    _Supervisor,
                    ExcluirMotores);

                if (BuscarInformacion.Count() < 1) { ClientScript.RegisterStartupScript(GetType(), "CamposNoEncontrados()", "CamposNoEncontrados();", true); }
                else {

                    foreach (var n in BuscarInformacion) {

                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionEstadisticaRenovacion Guardar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionEstadisticaRenovacion(
                            IdUsuario,
                            (decimal)n.Cotizacion,
                            n.Poliza,
                            n.Estatus,
                            (int)n.CodigoOficina,
                            (int)n.Ramo,
                            (decimal)n.Bruto,
                            (int)n.CodigoIntermediario,
                            (int)n.CodigoSupervisor,
                            (DateTime)n.ValidadoDesde,
                            (DateTime)n.ValidadoHasta,
                            cbExcluirMotores.Checked,
                            "INSERT");
                        Guardar.ProcesarInformacion();
                    }
                }
                cbRetenerInformacion.Visible = true;
            }
        }
        #endregion

        #region MOSTRAR LA ESTADISTICA DE RENOVACION
        private void MostrarEstadisticaRenovacion() {
            decimal IdUsuario = (decimal)Session["IdUsuario"];
            if (rbDetalle.Checked == true) {

              
            }
            else {
                int TipoAgrupacion = 0;
             
                if (rbNoAgrupar.Checked == true) { TipoAgrupacion = (int)ConceptosAgrupacion.NoAgrupado; }
                else if (rbOficina.Checked == true) { TipoAgrupacion = (int)ConceptosAgrupacion.AgruparPorOficina; }
                else if (rbRamo.Checked == true) { TipoAgrupacion = (int)ConceptosAgrupacion.AgruparPorRamo; }
                else if (rbIntermediario.Checked == true) { TipoAgrupacion = (int)ConceptosAgrupacion.AgruparPorIntermediario; }
                else if (rbSupervisor.Checked == true) { TipoAgrupacion = (int)ConceptosAgrupacion.AgruparPorSupervisor; }

                var BuscarInformacion = ObjDataConsulta.Value.BuscaEstadisticaRenovacionAgrupada(IdUsuario, TipoAgrupacion);
                Paginar_EstadisticaRenovacion(ref rpEstadisticaRenovacion, BuscarInformacion, 10, ref lbCantidadPaginaVAriableEstadisticaRenovacion, ref btnkPrimeraPaginaEstadisticaRenovacion, ref btnAnteriorEstadisticaRenovacion, ref btnSiguienteEstadisticaRenovacion, ref btnUltimoEstadisticaRenovacion);
                HandlePaging_EstadisticaRenovacion(ref dtPaginacionEstadisticaRenovacion, ref lbPaginaActualVariableEstadisticaRenovacion);
            }
           
        }
        #endregion

        #region GENERER REPORTE DE ESTADISTICA DE RENOVACION
        private void GenerarReporte(string RutaReporte, string NombreReporte,int TipoAgrupaicon, decimal IdUsuario) {

            string UsuarioBD = "sa", ClaveBD = "Pa$$W0rd";

            


            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@IdUsuario", IdUsuario);
            Reporte.SetParameterValue("@TipoAgrupacion", TipoAgrupaicon);

            Reporte.SetDatabaseLogon(UsuarioBD, ClaveBD);

            if (rbPDF.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
            }
            else if (rbEXcel.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreReporte);
            }
            else if (rbWord.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreReporte);
            }

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "ESTADISTICA DE RENOVACION";


                CargarOficinas();
                CargarRamos();
                CargarSubRamo();

                rbPDF.Checked = true;
                rbNoAgrupar.Checked = true;
                cbExcluirMotores.Checked = false;
                cbRetenerInformacion.Checked = false;
            }
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediario.Text);
            txtNombreIntermediario.Text = Nombre.SacarNombreIntermediario();
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisor.Text);
            txtNombreSupervisor.Text = Nombre.SacarNombreSupervisor();
        }

        protected void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.ESacarNombreCliente Nombre = new Logica.Comunes.ESacarNombreCliente(txtCodigoCliente.Text);
            txtNombreCliente.Text = Nombre.SacarCodigoCLiente();
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            if (cbRetenerInformacion.Checked == false) {
                CargarInformacion();
            }
            CurrentPage_EstadisticaRenovacion = 0;
            MostrarEstadisticaRenovacion();
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            if (cbRetenerInformacion.Checked == false)
            {
                CargarInformacion();
            }

            int TipoAgrupacion = 0;
            string TipoAgrupacionNombre = "";
            decimal IdUsuario = (decimal)Session["IdUsuario"];
            if (rbNoAgrupar.Checked == true) {
                TipoAgrupacion = (int)ConceptosAgrupacion.NoAgrupado;
                TipoAgrupacionNombre = "No Agrupado";
            }
            else if (rbOficina.Checked == true) {
                TipoAgrupacion = (int)ConceptosAgrupacion.AgruparPorOficina;
                TipoAgrupacionNombre = "Agrupado Por Oficina";
            }
            else if (rbRamo.Checked == true) {
                TipoAgrupacion = (int)ConceptosAgrupacion.AgruparPorRamo;
                TipoAgrupacionNombre = "Agrupado Por Ramo";
            }
            else if (rbIntermediario.Checked == true) { 
                TipoAgrupacion = (int)ConceptosAgrupacion.AgruparPorIntermediario;
                TipoAgrupacionNombre = "Agrupado Por Intermediario";
            }
            else if (rbSupervisor.Checked == true) { 
                TipoAgrupacion = (int)ConceptosAgrupacion.AgruparPorSupervisor;
                TipoAgrupacionNombre = "Agrupado Por Supervisor";
            }



            GenerarReporte(Server.MapPath("ReporteEstadisticaRenovacion.rpt"), "Reporte Estadistica de Renovacion " + TipoAgrupacionNombre, TipoAgrupacion, IdUsuario);
        }

        protected void btnkPrimeraPaginaEstadisticaRenovacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_EstadisticaRenovacion = 0;
            MostrarEstadisticaRenovacion();
        }

        protected void btnAnteriorEstadisticaRenovacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_EstadisticaRenovacion += -1;
            MostrarEstadisticaRenovacion();
            MoverValoresPaginacion_EstadisticaRenovacion((int)OpcionesPaginacionValores_EstadisticaRenovacion.PaginaAnterior, ref lbPaginaActualVariableEstadisticaRenovacion, ref lbCantidadPaginaVAriableEstadisticaRenovacion);
        }

        protected void dtPaginacionEstadisticaRenovacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionEstadisticaRenovacion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_EstadisticaRenovacion = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarEstadisticaRenovacion();
        }

        protected void btnSiguienteEstadisticaRenovacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_EstadisticaRenovacion += 1;
            MostrarEstadisticaRenovacion();
        }

        protected void btnUltimoEstadisticaRenovacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_EstadisticaRenovacion = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarEstadisticaRenovacion();
            MoverValoresPaginacion_EstadisticaRenovacion((int)OpcionesPaginacionValores_EstadisticaRenovacion.UltimaPagina, ref lbPaginaActualVariableEstadisticaRenovacion, ref lbCantidadPaginaVAriableEstadisticaRenovacion);
        }

        protected void ddlSeleccionarRamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSubRamo();
        }


        protected void cbExcluirMotores_CheckedChanged(object sender, EventArgs e)
        {
            if (cbExcluirMotores.Checked == true) {

                ddlSeleccionarRamo.Enabled = false;
                ddlSeleccionarSubramo.Enabled = false;
            }
            else if (cbExcluirMotores.Checked == false) {
                ddlSeleccionarRamo.Enabled = true;
                ddlSeleccionarSubramo.Enabled = true;
            }
        }
    }
}