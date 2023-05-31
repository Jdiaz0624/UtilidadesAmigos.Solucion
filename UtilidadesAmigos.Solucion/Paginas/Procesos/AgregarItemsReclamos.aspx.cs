using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas.Procesos
{
    public partial class AgregarItemsReclamos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjDAta = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();

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
        private void HandlePaging(ref DataList NombreDataList, ref Label LbPaginaActual)
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
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
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

            RptGrid.DataSource = pagedDataSource;
            RptGrid.DataBind();


            //divPaginacion.Visible = true;
        }
        enum OpcionesPaginacionValores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region MOSTRAR LISTADO DE RECLAMO
        private void BuscarReclamo(decimal? _Reclamacion) {
            var BuscarInformacion = ObjDAta.Value.BuscaDatosReclamacionesAgregarItems(null, _Reclamacion, null);
            if (BuscarInformacion.Count() < 1) {
                rpListadoReclamos.DataSource = null;
                rpListadoReclamos.DataBind();
                ClientScript.RegisterStartupScript(GetType(), "ReclamacionNoEncontrada()", "ReclamacionNoEncontrada();", true);
            }
            else {
                Paginar(ref rpListadoReclamos, BuscarInformacion, 10, ref lbCantidadPaginaVariable, ref btnPrimeraPagina, ref btnPaginaAnterior, ref btnSiguientePagina, ref btnUltimaPagina);
                HandlePaging(ref dtPaginacion, ref lbPaginaActualVariable);
            }
        }
        #endregion

        #region PROCESAR LA INFORMACION DE LOS ITEMS DE RECLAMACIONES
        private void ProcesarItemsREclamos(decimal Reclamaciones, int Secuencia,int IdTipoReclamacion, string Accion) {

            DateTime FechaReclamo = string.IsNullOrEmpty(txtFechaReclamo.Text.Trim()) ? DateTime.Now : Convert.ToDateTime(txtFechaReclamo.Text);
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionItemReclamaciones Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionItemReclamaciones(
                Reclamaciones,
                Secuencia,
                txtCodigoReclamante.Text,
                IdTipoReclamacion,
                FechaReclamo,
                Accion);
            Procesar.ProcesarInformacionItems();
            BuscarReclamo(Convert.ToDecimal(lbReclamoSeleccionadoProceso.Text));
            VolverAtras();
        }
        #endregion



        private void CargarTipoReclamo() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoReclamo, ObjDataGeneral.Value.BuscaListas("TIPOSRECLAMOS", null, null));
        }

        private void SacarNombreReclamante(decimal? Codigo) {

            var SacarNombre = ObjDAta.Value.SacarNombreReclamante(Codigo);
            if (SacarNombre.Count() < 1) {
                ClientScript.RegisterStartupScript(GetType(), "NombreReclamanteNovalido()", "NombreReclamanteNovalido();", true);
                
            }
            else {
                foreach (var n in SacarNombre) {
                    txtNombreReclamante.Text = n.NombreReclamante;
                }
            }
        }

        private void VolverAtras() {
            DivBloqueConsulta.Visible = true;
            DivBloqueAgregarEditar.Visible = false;
            btnGuardar.Visible = false;
            btnModificar.Visible = false;
            lbPolizaSeleccionadaProceso.Text = "0";
            lbReclamoSeleccionadoProceso.Text = "0";
            lbSecuenciaSeleccionadaProceso.Text = "0";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "AGREGAR ITEMS A RECLAMACION";

                DivBloqueAgregarEditar.Visible = false;
                DivBloqueConsulta.Visible = true;
                btnGuardar.Visible = false;
                btnModificar.Visible = false;

                lbPolizaSeleccionadaProceso.Text = "0";
                lbReclamoSeleccionadoProceso.Text = "0";
                lbSecuenciaSeleccionadaProceso.Text = "0";
        
            }
        }
        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            var Reclamacion = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfReclamacion = ((HiddenField)Reclamacion.FindControl("hfReclamo")).Value.ToString();

            var Secuencia = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfSecuencia = ((HiddenField)Secuencia.FindControl("hfsecuencia")).Value.ToString();

            lbReclamoSeleccionadoProceso.Text = hfReclamacion;

            ProcesarItemsREclamos(Convert.ToDecimal(hfReclamacion), Convert.ToInt32(hfSecuencia),1, "DELETE");
        }

        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {
            DivBloqueConsulta.Visible = false;
            DivBloqueAgregarEditar.Visible = true;
            btnGuardar.Visible = true;
            btnModificar.Visible = false;

            lbTitulo.Text = "Agregar Nuevo Registro";

            var RegistroSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfPoliza = ((HiddenField)RegistroSeleccionado.FindControl("hfPoliza")).Value.ToString();
            var hfReclamo = ((HiddenField)RegistroSeleccionado.FindControl("hfReclamo")).Value.ToString();
            var hfSecuencia = ((HiddenField)RegistroSeleccionado.FindControl("hfsecuencia")).Value.ToString();

            lbPolizaSeleccionadaProceso.Text = hfPoliza;
            lbSecuenciaSeleccionadaProceso.Text = hfSecuencia;
            lbReclamoSeleccionadoProceso.Text = hfReclamo;

            CargarTipoReclamo();
            txtCodigoReclamante.Text = string.Empty;
            txtNombreReclamante.Text = string.Empty;
            var BuscarRegistroSeleccionado = ObjDAta.Value.BuscaDatosReclamacionesAgregarItems(
                hfPoliza,
                Convert.ToDecimal(hfReclamo),
                Convert.ToInt32(hfSecuencia));
            foreach (var n in BuscarRegistroSeleccionado) {
                txtPolizaSeleccionada.Text = n.Poliza;
                txtSecuencia.Text = n.Secuencia.ToString();
                txtReclamacionSeleccionada.Text = n.Reclamacion.ToString();
                DateTime Fecha = (DateTime)n.FechaApertura;
                txtFechaReclamo.Text = Fecha.ToString("yyyy-MM-dd");
            }
        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            decimal? Codigo = string.IsNullOrEmpty(txtCodigoReclamante.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoReclamante.Text);

            var SacarNombre = ObjDAta.Value.SacarNombreReclamante(Codigo);
            if (SacarNombre.Count() < 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "NombreReclamanteNovalido()", "NombreReclamanteNovalido();", true);

            }
            else
            {
                int TipoReclamacion = ddlSeleccionarTipoReclamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarTipoReclamo.SelectedValue) : 1;
                ProcesarItemsREclamos(Convert.ToDecimal(lbReclamoSeleccionadoProceso.Text), Convert.ToInt32(lbSecuenciaSeleccionadaProceso.Text), TipoReclamacion, "INSERT");
            }
        }

        protected void btnModificar_Click(object sender, ImageClickEventArgs e)
        {
            decimal? Codigo = string.IsNullOrEmpty(txtCodigoReclamante.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoReclamante.Text);

            var SacarNombre = ObjDAta.Value.SacarNombreReclamante(Codigo);
            if (SacarNombre.Count() < 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "NombreReclamanteNovalido()", "NombreReclamanteNovalido();", true);

            }
            else
            {
                int TipoReclamacion = ddlSeleccionarTipoReclamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarTipoReclamo.SelectedValue) : 1;
                ProcesarItemsREclamos(Convert.ToDecimal(lbReclamoSeleccionadoProceso.Text), Convert.ToInt32(lbSecuenciaSeleccionadaProceso.Text), TipoReclamacion, "UPDATE");
            }
        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            VolverAtras();
        }

        protected void btnEditarRegistro_Click(object sender, ImageClickEventArgs e)
        {
            DivBloqueConsulta.Visible = false;
            DivBloqueAgregarEditar.Visible = true;
            btnGuardar.Visible = false;
            btnModificar.Visible = true;

            lbTitulo.Text = "Editar Registro Seleccionado";

            var RegistroSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfPoliza = ((HiddenField)RegistroSeleccionado.FindControl("hfPoliza")).Value.ToString();
            var hfReclamo = ((HiddenField)RegistroSeleccionado.FindControl("hfReclamo")).Value.ToString();
            var hfSecuencia = ((HiddenField)RegistroSeleccionado.FindControl("hfsecuencia")).Value.ToString();

            lbPolizaSeleccionadaProceso.Text = hfPoliza;
            lbSecuenciaSeleccionadaProceso.Text = hfSecuencia;
            lbReclamoSeleccionadoProceso.Text = hfReclamo;

            CargarTipoReclamo();
            var BuscarRegistroSeleccionado = ObjDAta.Value.BuscaDatosReclamacionesAgregarItems(
                hfPoliza,
                Convert.ToDecimal(hfReclamo),
                Convert.ToInt32(hfSecuencia));
            foreach (var n in BuscarRegistroSeleccionado)
            {
                txtPolizaSeleccionada.Text = n.Poliza;
                txtSecuencia.Text = n.Secuencia.ToString();
                txtReclamacionSeleccionada.Text = n.Reclamacion.ToString();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarTipoReclamo, n.IdTipoReclamacion.ToString());
                txtCodigoReclamante.Text = n.IdReclamante;
                txtNombreReclamante.Text = n.Reclamante;
                DateTime Fecha = (DateTime)n.FechaAdiciona;
                txtFechaReclamo.Text = Fecha.ToString("yyyy-MM-dd");
            }


        }

        protected void txtCodigoReclamante_TextChanged(object sender, EventArgs e)
        {
            decimal? _CodigoReclamante = string.IsNullOrEmpty(txtCodigoReclamante.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoReclamante.Text);
            SacarNombreReclamante(_CodigoReclamante);
        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            decimal? _Numeroreclamo = string.IsNullOrEmpty(txtNumeroReclamoConsulta.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroReclamoConsulta.Text);
            BuscarReclamo(_Numeroreclamo);
        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {

            CurrentPage += -1;
            decimal? _Numeroreclamo = string.IsNullOrEmpty(txtNumeroReclamoConsulta.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroReclamoConsulta.Text);
            BuscarReclamo(_Numeroreclamo);
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariable, ref lbCantidadPaginaVariable);
        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            
        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            decimal? _Numeroreclamo = string.IsNullOrEmpty(txtNumeroReclamoConsulta.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroReclamoConsulta.Text);
            BuscarReclamo(_Numeroreclamo);
        }

        protected void btnSiguientePagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += 1;
            decimal? _Numeroreclamo = string.IsNullOrEmpty(txtNumeroReclamoConsulta.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroReclamoConsulta.Text);
            BuscarReclamo(_Numeroreclamo);
        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            decimal? _Numeroreclamo = string.IsNullOrEmpty(txtNumeroReclamoConsulta.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroReclamoConsulta.Text);
            BuscarReclamo(_Numeroreclamo);
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariable, ref lbCantidadPaginaVariable);
        }

        protected void txtNumeroReclamoConsulta_TextChanged(object sender, EventArgs e)
        {
            decimal? _Numeroreclamo = string.IsNullOrEmpty(txtNumeroReclamoConsulta.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroReclamoConsulta.Text);

            CurrentPage = 0;
            BuscarReclamo(_Numeroreclamo);
        }

        protected void btnConsultarReclamo_Click1(object sender, ImageClickEventArgs e)
        {
            decimal? _Numeroreclamo = string.IsNullOrEmpty(txtNumeroReclamoConsulta.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroReclamoConsulta.Text);

            CurrentPage = 0;
            BuscarReclamo(_Numeroreclamo);
        }
    }
}