﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ControlVisitas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        enum TipoDeProceso
        {
            Visitas = 1,
            EntregaDeDocumentos = 2,
            SalidaDeDocumentos = 3
        }


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
        private void HandlePaging(ref DataList NombreDataList, ref Label PaginaActual)
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
            PaginaActual.Text = (NumeroPagina + 1).ToString();
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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label CantidadPagina, ref LinkButton PrimeraPagina, ref LinkButton PaginaAnterior, ref LinkButton SiguientePagina, ref LinkButton UltimaPagina)
        {
            pagedDataSource.DataSource = Listado;
            pagedDataSource.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource.PageCount;
            // lbNumeroVariable.Text = "1";
            CantidadPagina.Text = pagedDataSource.PageCount.ToString();

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


            //divPaginacionCliente.Visible = true;
            //DivPaginacionIntermediario.Visible = true;
            //OcultarDetalle();
        }
        enum OpcionesPaginacionValores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPagina)
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
        #region MOSTRAR EL LISTADO DEL CONTROL DE LAS VISITAS
        private void MostrarListadoControlCisitas() {
            int? _TipoProceso = ddlSeleccionarTipoProcesoCOnsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarTipoProcesoCOnsulta.SelectedValue) : new Nullable<int>();
            string _Nombre = string.IsNullOrEmpty(txtNombreConsulta.Text.Trim()) ? null : txtNombreConsulta.Text.Trim();
            string _Remitente = string.IsNullOrEmpty(txtRemitenteConsulta.Text.Trim()) ? null : txtRemitenteConsulta.Text.Trim();
            string _Destinatario = string.IsNullOrEmpty(txtDestinatario.Text.Trim()) ? null : txtDestinatario.Text.Trim();

            DateTime? _FechaDesde = cbAgregarRangoFecha.Checked == true ? Convert.ToDateTime(txtFechaDesde.Text) : new Nullable<DateTime>();
            DateTime? _FechaHasta = cbAgregarRangoFecha.Checked == true ? Convert.ToDateTime(txtFechaHAsta.Text) : new Nullable<DateTime>();

            var Listado = ObjData.Value.BuscaControlVisitas(
                new Nullable<decimal>(),
                _TipoProceso,
                _Nombre,
                _Remitente,
                _Destinatario,
                null,
                _FechaDesde,
                _FechaHasta,
                null);
            Paginar(ref rpListadoControlVisitas, Listado, 10, ref lbCantidadPaginaVAriableControlVisistas, ref LinkPrimeraPaginaControlVisistas, ref LinkAnteriorControlVisistas, ref LinkSiguienteControlVisistas, ref LinkUltimoControlVisistas);
            HandlePaging(ref dtPaginacionControlVisistas, ref lbPaginaActualVariableControlVisistas);
        }
        #endregion
        #region CARGAR EL LISTADO DE RECEPCON DE DOCUMENTOS
        private void CargarTipoProcesoCOsnsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoProcesoCOnsulta, ObjData.Value.BuscaListas("TIPOPROCESORECEPCION", null, null), true);
        }
        private void CargarTipoProcesoMantenimiento() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoprocesoMantenimiento, ObjData.Value.BuscaListas("TIPOPROCESORECEPCION", null, null));
        }
        #endregion
        #region PROCESAR LA INFORMACION DEL CONTROL DE VISITAS
        private void ProcesarInformacion(decimal NoRegistro, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionControlVisitas Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionControlVisitas(
                NoRegistro,
                Convert.ToInt32(ddlTipoprocesoMantenimiento.SelectedValue),
                txtNombreMantenimiento.Text,
                txtRemitenteMantenimiento.Text,
                txtDestinatarioMantenimiento.Text,
                txtNumeroIdentificacionMantenimiento.Text,
                Convert.ToInt32(txtCantidadDocumentosMantenimiento.Text),
                Convert.ToInt32(txtCantidadPersonasMantenimiento.Text),
                (decimal)Session["IdUsuario"],
                (decimal)Session["IdUsuario"],
                txtComentarioMantenimiento.Text,
                Accion);
            Procesar.ProcesarInformacion();
        }
        #endregion
        #region VOLVER ATRAS
        private void VolverAtras() {
            DivBloqueMantenimiento.Visible = false;
            DivBloqueCOnsulta.Visible = true;
            CurrentPage = 0;
            MostrarListadoControlCisitas();


            btnConsultar.Enabled = true;
            btnReporte.Enabled = true;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            LinkPrimeraPaginaControlVisistas.Enabled = true;
            LinkSiguienteControlVisistas.Enabled = true;
            LinkAnteriorControlVisistas.Enabled = true;
            LinkUltimoControlVisistas.Enabled = true;
        }
        #endregion
        #region BLOQUEAR Y DESBLOQUEAR CONTROLES
        private void BloquearControles() {
            ddlTipoprocesoMantenimiento.Enabled = false;
            txtNombreMantenimiento.Enabled = false;
            txtNumeroIdentificacionMantenimiento.Enabled = false;
            txtRemitenteMantenimiento.Enabled = false;
            txtDestinatarioMantenimiento.Enabled = false;
            txtCantidadDocumentosMantenimiento.Enabled = false;
            txtCantidadPersonasMantenimiento.Enabled = false;
            txtComentarioMantenimiento.Enabled = false;
        }
        private void DesbloquearControles() {
            ddlTipoprocesoMantenimiento.Enabled = true;
            txtNombreMantenimiento.Enabled = true;
            txtNumeroIdentificacionMantenimiento.Enabled = true;
            txtRemitenteMantenimiento.Enabled = true;
            txtDestinatarioMantenimiento.Enabled = true;
            txtCantidadDocumentosMantenimiento.Enabled = true;
            txtCantidadPersonasMantenimiento.Enabled = true;
            txtComentarioMantenimiento.Enabled = true;
        }
        #endregion
        #region ACCION DEL DROP
        private void AccionDrop(int AccionDrop) {

            switch (AccionDrop) {
                case (int)TipoDeProceso.Visitas:
                    txtCantidadDocumentosMantenimiento.Enabled = false;
                    txtCantidadDocumentosMantenimiento.Text = "1";
                    txtCantidadPersonasMantenimiento.Enabled = true;
                    txtCantidadPersonasMantenimiento.Text = "1";
                    break;

                case (int)TipoDeProceso.EntregaDeDocumentos:
                    txtCantidadDocumentosMantenimiento.Enabled = true;
                    txtCantidadDocumentosMantenimiento.Text = "1";
                    txtCantidadPersonasMantenimiento.Enabled = false;
                    txtCantidadPersonasMantenimiento.Text = "1";
                    break;

                case (int)TipoDeProceso.SalidaDeDocumentos:
                    txtCantidadDocumentosMantenimiento.Enabled = true;
                    txtCantidadDocumentosMantenimiento.Text = "1";
                    txtCantidadPersonasMantenimiento.Enabled = false;
                    txtCantidadPersonasMantenimiento.Text = "1";
                    break;
            }
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                Label lbNombreUsuarioCOnectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbNombreUsuarioCOnectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "CONTROL DE VISITAS";

                DivFechaDesde.Visible = false;
                DivFechaHAsta.Visible = false;

                CargarTipoProcesoCOsnsulta();
                CargarTipoProcesoMantenimiento();
                MostrarListadoControlCisitas();
                cbAgregarRangoFecha.Checked = false;
                rbPDF.Checked = true;

                DivBloqueMantenimiento.Visible = false;


            }
        }

        protected void cbAgregarRangoFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAgregarRangoFecha.Checked == true) {
                DivFechaDesde.Visible = true;
                DivFechaHAsta.Visible = true;
            }
            else {
                DivFechaDesde.Visible = false;
                DivFechaHAsta.Visible = false;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoControlCisitas();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            DesbloquearControles();
            lbIdRegistroSeleccionado.Text = "0";
            lbAccionTomarSeleccionado.Text = "INSERT";
            CargarTipoProcesoMantenimiento();
            txtNombreMantenimiento.Text = string.Empty;
            txtNumeroIdentificacionMantenimiento.Text = string.Empty;
            txtRemitenteMantenimiento.Text = string.Empty;
            txtDestinatarioMantenimiento.Text = string.Empty;
            txtCantidadDocumentosMantenimiento.Text = string.Empty;
            txtCantidadPersonasMantenimiento.Text = string.Empty;
            txtComentarioMantenimiento.Text = string.Empty;
            DivBloqueCOnsulta.Visible = false;
            DivBloqueMantenimiento.Visible = true;

            AccionDrop(Convert.ToInt32(ddlTipoprocesoMantenimiento.SelectedValue));
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            DesbloquearControles();
            ddlTipoprocesoMantenimiento.Enabled = false;
            lbAccionTomarSeleccionado.Text = "UPDATE";
            DivBloqueCOnsulta.Visible = false;
            DivBloqueMantenimiento.Visible = true;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            BloquearControles();
            lbAccionTomarSeleccionado.Text = "DELETE";
            DivBloqueCOnsulta.Visible = false;
            DivBloqueMantenimiento.Visible = true;
        }

        protected void LinkPrimeraPaginaControlVisistas_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoControlCisitas();
        }

        protected void LinkAnteriorControlVisistas_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoControlCisitas();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableControlVisistas, ref lbCantidadPaginaVAriableControlVisistas);
        }

        protected void dtPaginacionControlVisistas_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionControlVisistas_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoControlCisitas();
        }

        protected void LinkSiguienteControlVisistas_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoControlCisitas();
        }

        protected void LinkUltimoControlVisistas_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoControlCisitas();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableControlVisistas, ref lbCantidadPaginaVAriableControlVisistas);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesarInformacion(Convert.ToDecimal(lbIdRegistroSeleccionado.Text), lbAccionTomarSeleccionado.Text);
            VolverAtras();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            VolverAtras();
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {

        }

        protected void ddlTipoprocesoMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccionDrop(Convert.ToInt32(ddlTipoprocesoMantenimiento.SelectedValue));
        }

        protected void btnRestablecer_Click(object sender, EventArgs e)
        {
            VolverAtras();
        }

        protected void btnSeleccionarRegistros_Click(object sender, EventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfNoRegistroseleccionado = ((HiddenField)ItemSeleccionado.FindControl("hfNoRegistro")).Value.ToString();
            lbIdRegistroSeleccionado.Text = hfNoRegistroseleccionado.ToString();

            var BuscarInformacionSeleccionada = ObjData.Value.BuscaControlVisitas(
                Convert.ToDecimal(hfNoRegistroseleccionado),
                null, null, null, null, null, null, null, null);
            Paginar(ref rpListadoControlVisitas, BuscarInformacionSeleccionada, 1, ref lbCantidadPaginaVAriableControlVisistas, ref LinkPrimeraPaginaControlVisistas, ref LinkAnteriorControlVisistas, ref LinkSiguienteControlVisistas, ref LinkUltimoControlVisistas);
            HandlePaging(ref dtPaginacionControlVisistas, ref lbPaginaActualVariableControlVisistas);

            foreach (var n in BuscarInformacionSeleccionada) {

                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlTipoprocesoMantenimiento, n.IdTipoProcesoRecepcion.ToString());
                txtNombreMantenimiento.Text = n.Nombre;
                txtNumeroIdentificacionMantenimiento.Text = n.NumeroIdentificacion;
                txtRemitenteMantenimiento.Text = n.Remitente;
                txtDestinatarioMantenimiento.Text = n.Destinatario;
                txtCantidadDocumentosMantenimiento.Text = n.CantidadDocumentos.ToString();
                txtCantidadPersonasMantenimiento.Text = n.CantidadPersonas.ToString();
                txtComentarioMantenimiento.Text = n.Comentario;
            }
            btnConsultar.Enabled = false;
            btnReporte.Enabled = false;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            LinkPrimeraPaginaControlVisistas.Enabled = false;
            LinkSiguienteControlVisistas.Enabled = false;
            LinkAnteriorControlVisistas.Enabled = false;
            LinkUltimoControlVisistas.Enabled = false;
        }
    }
}