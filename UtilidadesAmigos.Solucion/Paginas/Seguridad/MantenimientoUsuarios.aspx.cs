using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

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
            decimal? _departamento = ddlSucursalCOnsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSucursalCOnsulta.SelectedValue) : new Nullable<decimal>();
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



        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                DivBloqueConsulta.Visible = true;
                DivBloqueMantenimiento.Visible = false;
                ListaSucursalesConsulta();
                ListaOficinasConsulta();
                ListaDepartamentoConsulta();
                ListaPersilConsulta();
                CurrentPage = 0;
                ListadoUsuarios();
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
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnRestablecer_Click(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionarUsuario_Click(object sender, EventArgs e)
        {

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