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

namespace UtilidadesAmigos.Solucion.Paginas.Seguridad
{
    public partial class Opciones : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataComun = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad> ObjDataSeguridad = new Lazy<Logica.Logica.LogicaSeguridad.LogicaSeguridad>();



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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label CantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
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

        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarModulos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarModulo, ObjDataComun.Value.BuscaListas("MODULOSSISTEMA", null, null), true);
        }
        private void CargarPantalla()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPantalla, ObjDataComun.Value.BuscaListas("PANTALLASSISTEMA", ddlSeleccionarModulo.SelectedValue.ToString(), null), true);
        }
        #endregion

        #region MOSTRAR EL LISTADO DE LAS OPCIONES DEL SISTEMA
        private void MostrarListadoOpcionesSistema() {

            int? _Modulo = ddlSeleccionarModulo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarModulo.SelectedValue) : new Nullable<int>();
            int? _Pantalla = ddlSeleccionarPantalla.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarPantalla.SelectedValue) : new Nullable<int>();
            string _Opcion = string.IsNullOrEmpty(txtOpcion.Text.Trim()) ? null : txtOpcion.Text.Trim();

            var ListadoOpciones = ObjDataSeguridad.Value.BuscaOpcionesPantalla(
                _Modulo,
                _Pantalla,
                new Nullable<int>(),
                _Opcion);
            if (ListadoOpciones.Count() < 1) {
                CurrentPage = 0;
                rpListadoOpciones.DataSource = null;
                rpListadoOpciones.DataBind();
            }
            else {

                Paginar(ref rpListadoOpciones, ListadoOpciones, 10, ref lbCantidadPagina, ref btnPrimeraPagina, ref btnAnterior, ref btnSiguiente, ref btnUltimo);
                HandlePaging(ref dtPaginacion, ref lbPaginaActual);
            }
        }
        #endregion

        #region EXPORTAR INFORMAICON A EXCEL
        private void ExportarInformaiconExcel() {
            int? _Modulo = ddlSeleccionarModulo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarModulo.SelectedValue) : new Nullable<int>();
            int? _Pantalla = ddlSeleccionarPantalla.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarPantalla.SelectedValue) : new Nullable<int>();
            string _Opcion = string.IsNullOrEmpty(txtOpcion.Text.Trim()) ? null : txtOpcion.Text.Trim();

            var Exportar = (from n in ObjDataSeguridad.Value.BuscaOpcionesPantalla(
                _Modulo,
                _Pantalla,
                new Nullable<int>(),
                _Opcion)
                            select new
                            {
                                Modulo =n.Modulo,
                                Pantalla =n.Pantalla,
                                Opcion =n.Opcion,
                                Estatus =n.Estatus
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Opciones del Sistema", Exportar);
        }
        #endregion

        #region PROCESAR LA INFORMACION DE LAS OPCIONES
        private void ProcesarInformacionOpciones(int IdModulo, int IdPantalla, int IdOpcion, bool Estatus, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSeguridad.ProcesarInformacionOpcionesPantallas Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionSeguridad.ProcesarInformacionOpcionesPantallas(
                IdModulo,
                IdPantalla,
                IdOpcion,
                "",
                Estatus,
                Accion);
            Procesar.ProcesarInformacion();
        }
        #endregion
        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoOpcionesSistema();
        }

        protected void btnExportar_Click(object sender, ImageClickEventArgs e)
        {
            ExportarInformaiconExcel();
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;

            var ModuloSeleccionado = ((HiddenField)ItemSeleccionado.FindControl("hfModulo")).Value.ToString();
            var PantallaSeleccionada = ((HiddenField)ItemSeleccionado.FindControl("hfPantalla")).Value.ToString();
            var OpcionSeleccionada = ((HiddenField)ItemSeleccionado.FindControl("hfOpcion")).Value.ToString();
            var EstatusSeleccionada = ((HiddenField)ItemSeleccionado.FindControl("hfEstatus")).Value.ToString();

            ProcesarInformacionOpciones(
                Convert.ToInt32(ModuloSeleccionado),
                Convert.ToInt32(PantallaSeleccionada),
                Convert.ToInt32(OpcionSeleccionada),
                Convert.ToBoolean(EstatusSeleccionada),
                "UPDATE");
            MostrarListadoOpcionesSistema();
        }

        protected void ddlSeleccionarModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPantalla();
        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoOpcionesSistema();
        }

        protected void btnAnterior_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoOpcionesSistema();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActual, ref lbCantidadPagina);
        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoOpcionesSistema();
        }

        protected void btnSiguiente_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoOpcionesSistema();
        }

        protected void btnUltimo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoOpcionesSistema();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.UltimaPagina, ref lbPaginaActual, ref lbCantidadPagina);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                Label lbNombreUsuarioCOnectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbNombreUsuarioCOnectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "OPCIONES DE PANTALLA";

                CargarModulos();
                CargarPantalla();
  
            }
        }
    }
}