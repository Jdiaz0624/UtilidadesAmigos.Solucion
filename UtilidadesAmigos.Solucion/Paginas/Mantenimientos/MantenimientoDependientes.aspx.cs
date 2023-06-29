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
    public partial class MantenimientoDependientes : System.Web.UI.Page
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


        #region MOSTRAR EL LISTADO DE LOS DEPENDIENTES
        private void MostrarListadoDependientes() {

            string _Poliza = string.IsNullOrEmpty(txtNumeroPolizaConuslta.Text.Trim()) ? null : txtNumeroPolizaConuslta.Text.Trim();

            var Listado = ObjData.Value.BuscaDependientes(_Poliza);
            if (Listado.Count() < 1) {
                rpListadodepenientes.DataSource = null;
                rpListadodepenientes.DataBind();
                lbEstatusPolizaVariable.Text = "";
                lbRamoVariable.Text = "";
                lbSubRamoVariable.Text = "";
                btnAgregarDependiente.Visible = false;
            }
            else {
                foreach (var n in Listado) {
                    lbEstatusPolizaVariable.Text = n.Estatus;
                    lbRamoVariable.Text = n.Ramo;
                    lbSubRamoVariable.Text = n.SubRamo;
                }
                string Estatus = lbEstatusPolizaVariable.Text;

                if (Estatus == "ACTIVO") {
                    lbEstatusPolizaVariable.ForeColor = System.Drawing.Color.DarkSeaGreen;
                }
                else {
                    lbEstatusPolizaVariable.ForeColor = System.Drawing.Color.Red;
                }
                btnAgregarDependiente.Visible = true;
                Paginar(ref rpListadodepenientes, Listado, 10, ref lbCantidadPaginaVAriableDependientes, ref btnPrimeraPagina, ref btnPaginaAnterior, ref btnSiguientePaginar, ref btnUltimaPagina);
                HandlePaging(ref dtPaginacion, ref lbPaginaActualVariableDependientes);
            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lbNombreUsuarioCOnectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbNombreUsuarioCOnectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "CONSULTA DE DEPENDIENTES";
            }
        }

        protected void btnConsultarRegistros_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoDependientes();
        }

        protected void btnExportarInformacion_Click(object sender, ImageClickEventArgs e)
        {
            string _Poliza = string.IsNullOrEmpty(txtNumeroPolizaConuslta.Text.Trim()) ? null : txtNumeroPolizaConuslta.Text.Trim();

            var Exportar = (from n in ObjData.Value.BuscaDependientes(_Poliza)
                            select new
                            {
                                Nombre =n.Nombre,
                                Parentezco =n.Parentezco,
                                Cedula =n.Cedula,
                                FechaNacimiento = n.FechaNacimiento,
                                Sexo=n.Sexo,
                                Prima=n.PorcPrima
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Dependientes de " + _Poliza , Exportar);
        }

        protected void btnEditarRegistro_Click(object sender, ImageClickEventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "OpcionNoDisponible()", "OpcionNoDisponible();", true);
        }

        protected void btnBorrarRegistro_Click(object sender, ImageClickEventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "OpcionNoDisponible()", "OpcionNoDisponible();", true);
        }


        protected void btnAgregarDependiente_Click(object sender, ImageClickEventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "OpcionNoDisponible()", "OpcionNoDisponible();", true);
        }

        protected void btnEditarRegistro_Click1(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoDependientes();
        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoDependientes();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableDependientes, ref lbCantidadPaginaVAriableDependientes);
        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoDependientes();
        }

        protected void btnSiguientePaginar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoDependientes();
        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoDependientes();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.UltimaPagina, ref lbPaginaActualVariableDependientes, ref lbCantidadPaginaVAriableDependientes);
        }
    }
}