using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class MantenimientoUsuarios : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataLogica = new Lazy<Logica.Logica.LogicaSistema>();

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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref LinkButton PrimeraPagina, ref LinkButton PaginaAnterior, ref LinkButton SiguientePagina, ref LinkButton UltimaPagina)
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


            //divPaginacionComisionSupervisor.Visible = true;
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

        #region LISTAS DESPLEGABLES DE LA PANTALLA DE CONSULTA
        private void ListaSucursalesConsulta() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSucursalCOnsulta, ObjDataLogica.Value.BuscaListas("SUCURSAL", null, null), true);
        }
        private void ListaOficinasConsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaConsulta, ObjDataLogica.Value.BuscaListas("OFICINA", ddlSucursalCOnsulta.SelectedValue.ToString(), null), true);
        }
        private void ListaDepartamentoConsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjDataLogica.Value.BuscaListas("DEPARTAMENTO", ddlSucursalCOnsulta.SelectedValue.ToString(), ddlOficinaConsulta.SelectedValue.ToString()), true);
        }
        private void ListaPersilConsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPerfilCOnsulta, ObjDataLogica.Value.BuscaListas("PERFILES", null, null), true);
        }
        #endregion

        #region LISTADO DE USUARIOS
        private void ListadoUsuarios() {
            decimal? _Sucursal = ddlSucursalCOnsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSucursalCOnsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Oficina = ddlOficinaConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlOficinaConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _departamento = ddlDepartamentoConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlDepartamentoConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Perfil = ddlPerfilCOnsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlPerfilCOnsulta.SelectedValue) : new Nullable<decimal>();
            string _Usuario = string.IsNullOrEmpty(txtUsuarioConsulta.Text.Trim()) ? null : txtUsuarioConsulta.Text.Trim();

            var Listado = ObjDataLogica.Value.BuscaUsuarios(
                new Nullable<decimal>(),
                _Sucursal,
                _Oficina,
                _departamento,
                _Perfil,
                _Usuario,
                null, null, null);
            if (Listado.Count() < 1)
            {
                rpListadoUsuarios.DataSource = null;
                rpListadoUsuarios.DataBind();
            }
            else {
                Paginar(ref rpListadoUsuarios, Listado, 10, ref lbCantidadPaginaVariableUsuarios, ref LinkPrimeraPaginaUsuarios, ref LinkAnteriorUsuarios, ref LinkSiguienteUsuarios, ref LinkUltimoUsuarios);
                HandlePaging(ref dtPaginacionUsuarios, ref lbPaginaActualVariavleUsuarios);
            }
        }
        #endregion

        #region LISTAS DESPLEGABLES DE LA PANTALLA DE MANTENIMIENTO
        private void ListaSucursalesMantenimiento()
        {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSucursalMantenimiento, ObjDataLogica.Value.BuscaListas("SUCURSAL", null, null));
        }
        private void ListaOficinasMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjDataLogica.Value.BuscaListas("OFICINA", ddlSucursalMantenimiento.SelectedValue.ToString(), null));
        }
        private void ListaDepartamentoMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoMantenimiento, ObjDataLogica.Value.BuscaListas("DEPARTAMENTO", ddlSucursalMantenimiento.SelectedValue.ToString(), ddlOficinaMantenimiento.SelectedValue.ToString())); 
        }
        private void ListaPersilMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPerfilMantenimiento, ObjDataLogica.Value.BuscaListas("PERFILES", null, null));
        }
        private void ListaTipoPersona() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoPersonaMantenimiento, ObjDataLogica.Value.BuscaListas("TIPOPERSONA", null, null));
        }
        #endregion


        #region MANTENIMIENTO DE USUARIOS
        private void MANUsuarios(decimal IdUsuario, string Accion) {

            string Clave = "RgB1AHQAdQByAG8AUwBlAGcAdQByAG8AcwAxADIAMwA=";

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSeguridad.ProcesarInformacionSeguridad Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionSeguridad.ProcesarInformacionSeguridad(
                IdUsuario,
                Convert.ToDecimal(ddlSucursalMantenimiento.SelectedValue),
                Convert.ToDecimal(ddlOficinaMantenimiento.SelectedValue),
                Convert.ToDecimal(ddlDepartamentoMantenimiento.SelectedValue),
                Convert.ToDecimal(ddlPerfilMantenimiento.SelectedValue),
                txtUsuarioMantenimiento.Text,
                Clave,
                txtPersonaMantenimiento.Text,
                cbEstatusMantenimiento.Checked,
                cbLLevaEmail.Checked,
                txtEmailMantenimiento.Text,
                0,
                cbCambiaClave.Checked,
                "",
                Convert.ToDecimal(ddlTipoPersonaMantenimiento.Text),
                cbImpresionMarbete.Checked,
                Accion);
            Procesar.ProcesarInformacion();
        }
        #endregion

        #region REPORTE DE USUARIOS
        private void ReporteUsuarios(string RutaReporte, string NombreReporte) {

            decimal? _CodigoUsuario = new Nullable<decimal>();
            decimal? _Sucursal = ddlSucursalCOnsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSucursalCOnsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Oficina = ddlOficinaConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlOficinaConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _departamento = ddlDepartamentoConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlDepartamentoConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Perfil = ddlPerfilCOnsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlPerfilCOnsulta.SelectedValue) : new Nullable<decimal>();
            string _Usuario = string.IsNullOrEmpty(txtUsuarioConsulta.Text.Trim()) ? null : txtUsuarioConsulta.Text.Trim();
            string _UsuarioLogin = null;
            string _ClaveLogin = null;
            bool? _Estatus = new Nullable<bool>();

            ReportDocument Reporte = new ReportDocument();
            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@IdUsuario", _CodigoUsuario);
            Reporte.SetParameterValue("@IdSucursal", _Sucursal);
            Reporte.SetParameterValue("@IdOficina", _Oficina);
            Reporte.SetParameterValue("@IdDepartamento", _departamento);
            Reporte.SetParameterValue("@IdPerfil", _Perfil);
            Reporte.SetParameterValue("@UsuarioConsulta", _Usuario);
            Reporte.SetParameterValue("@Usuario", _UsuarioLogin);
            Reporte.SetParameterValue("@Clave", _ClaveLogin);
            Reporte.SetParameterValue("@Estatus", _Estatus);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");
            Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);

        }

        #endregion

        private void SacarInformacionUsuarioSeleccionado(decimal IdUsuario) {

            var SacrInformacion = ObjDataLogica.Value.BuscaUsuarios(IdUsuario);
            foreach (var n in SacrInformacion) {
                ListaSucursalesMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSucursalMantenimiento, n.IdSucursal.ToString());
                ListaOficinasMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlOficinaMantenimiento, n.IdOficina.ToString());
                ListaDepartamentoMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlDepartamentoMantenimiento, n.IdDepartamento.ToString());
                ListaPersilMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlPerfilMantenimiento, n.IdPerfil.ToString());
                txtUsuarioMantenimiento.Text = n.Usuario;
                txtPersonaMantenimiento.Text = n.Persona;
                txtEmailMantenimiento.Text = n.Email;
                ListaTipoPersona();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlTipoPersonaMantenimiento, n.IdTipoPersona.ToString());
                cbEstatusMantenimiento.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
                cbLLevaEmail.Checked = (n.LlevaEmail0.HasValue ? n.LlevaEmail0.Value : false);
                cbCambiaClave.Checked = (n.CambiaClave0.HasValue ? n.CambiaClave0.Value : false);
                cbImpresionMarbete.Checked = (n.PermisoImpresionMarbete0.HasValue ? n.PermisoImpresionMarbete0.Value : false);
            }
        }

        private void IniciarPantalla() {
            DivBloqueConsulta.Visible = true;
            DivBloqueMantenimiento.Visible = false;
            ListaSucursalesConsulta();
            ListaOficinasConsulta();
            ListaDepartamentoConsulta();
            ListaPersilConsulta();
            CurrentPage = 0;
            ListadoUsuarios();
            btnConsultar.Enabled = true;
            btnNuevo.Enabled = true;
            btnReporte.Enabled = true;
            btnModificar.Enabled = false;
            btnRestablecer.Enabled = false;

            txtUsuarioMantenimiento.Text = string.Empty;
            txtUsuarioConsulta.Text = string.Empty;
            txtPersonaMantenimiento.Text = string.Empty;
            txtEmailMantenimiento.Text = string.Empty;
            txtClaveSeguridadMAntenimiento.Text = string.Empty;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                IniciarPantalla();
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "MANTENIMIENTO DE USUARIOS";
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            ListadoUsuarios();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            DivBloqueConsulta.Visible = false;
            DivBloqueMantenimiento.Visible = true;
            ListaSucursalesMantenimiento();
            ListaOficinasMantenimiento();
            ListaDepartamentoMantenimiento();
            ListaPersilMantenimiento();
            ListaTipoPersona();
            lbAccion.Text = "INSERT";
            lbIdUsuario.Text = "0";
            lbClaveSeguridadMAntenimiento.Visible = false;
            txtClaveSeguridadMAntenimiento.Visible = false;
            cbEstatusMantenimiento.Checked = true;
            cbCambiaClave.Checked = true;
            cbCambiaClave.Enabled = false;
            txtUsuarioMantenimiento.Enabled = true;
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            ReporteUsuarios(Server.MapPath("ReporteUsuarios.rpt"), "Reporte de Usuarios");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            DivBloqueConsulta.Visible = false;
            DivBloqueMantenimiento.Visible = true;
            lbAccion.Text = "UPDATE";
            lbClaveSeguridadMAntenimiento.Visible = true;
            txtClaveSeguridadMAntenimiento.Visible = true;
            cbCambiaClave.Enabled = true;
            SacarInformacionUsuarioSeleccionado(Convert.ToDecimal(lbIdUsuario.Text));
            txtUsuarioMantenimiento.Enabled = false;
        }

        protected void btnRestablecer_Click(object sender, EventArgs e)
        {
            IniciarPantalla();
        }

        protected void btnSeleccionarUsuario_Click(object sender, EventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfIdUsuario = ((HiddenField)ItemSeleccionado.FindControl("hfIdUsuario")).Value.ToString();
            lbIdUsuario.Text = hfIdUsuario.ToString();

            var BuscarRegistroSeleccionado = ObjDataLogica.Value.BuscaUsuarios(Convert.ToDecimal(hfIdUsuario.ToString()));
            Paginar(ref rpListadoUsuarios, BuscarRegistroSeleccionado, 1, ref lbCantidadPaginaVariableUsuarios, ref LinkPrimeraPaginaUsuarios, ref LinkAnteriorUsuarios, ref LinkSiguienteUsuarios, ref LinkUltimoUsuarios);
            HandlePaging(ref dtPaginacionUsuarios, ref lbPaginaActualVariavleUsuarios);

            btnConsultar.Enabled = false;
            btnNuevo.Enabled = false;
            btnReporte.Enabled = false;
            btnModificar.Enabled = true;
            btnRestablecer.Enabled = true;
        }

        protected void LinkPrimeraPaginaUsuarios_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            ListadoUsuarios();
        }

        protected void LinkAnteriorUsuarios_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            ListadoUsuarios();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleUsuarios, ref lbCantidadPaginaVariableUsuarios);
        }

        protected void dtPaginacionUsuarios_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionUsuarios_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            ListadoUsuarios();
        }

        protected void LinkSiguienteUsuarios_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            ListadoUsuarios();
        }

        protected void LinkUltimoUsuarios_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            ListadoUsuarios();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleUsuarios, ref lbCantidadPaginaVariableUsuarios);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string AccionTomar = lbAccion.Text;
            //MANUsuarios
            switch (AccionTomar) {
                case "INSERT":
                    var ValidarUsuario = ObjDataLogica.Value.BuscaUsuarios(
                        new Nullable<decimal>(),
                        null, null, null, null, null,
                        txtUsuarioMantenimiento.Text, null, null);
                    if (ValidarUsuario.Count() < 1) {
                        ClientScript.RegisterStartupScript(GetType(), "UsuarioNoValido()", "UsuarioNoValido();", true);
                    }
                    else {
                        MANUsuarios(0, AccionTomar);
                        IniciarPantalla();
                    }
                
                    break;

                case "UPDATE":
                    if (string.IsNullOrEmpty(txtClaveSeguridadMAntenimiento.Text.Trim())) {
                        ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadVacia()", "ClaveSeguridadVacia();", true);
                    }
                    else {
                        bool Resultado = false;
                        UtilidadesAmigos.Logica.Comunes.ValidarClaveSeguridad Validacion = new Logica.Comunes.ValidarClaveSeguridad(txtClaveSeguridadMAntenimiento.Text);
                        Resultado = Validacion.ValidarClave();
                        if (Resultado == true) {
                            MANUsuarios(Convert.ToDecimal(lbIdUsuario.Text), AccionTomar);
                            if (cbCambiaClave.Checked == true) {
                                MANUsuarios(Convert.ToDecimal(lbIdUsuario.Text), "STARTCHANGEPASSWORD");
                                IniciarPantalla();
                            }
                            else {
                                IniciarPantalla();
                            }
                        }
                        else {
                            ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadErronea()", "ClaveSeguridadErronea();", true);
                        }
                    }
                    break;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            DivBloqueConsulta.Visible = true;
            DivBloqueMantenimiento.Visible = false;
        }

        protected void ddlSucursalCOnsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaOficinasConsulta();
            ListaDepartamentoConsulta();
        }

        protected void ddlSucursalMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaOficinasMantenimiento();
            ListaDepartamentoMantenimiento();
        }

        protected void ddlOficinaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaDepartamentoMantenimiento();
        }

        protected void ddlOficinaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaDepartamentoConsulta();
        }
    }
}