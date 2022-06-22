using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace UtilidadesAmigos.Solucion.Paginas.Consulta
{
    public partial class RegistrosImcompletos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta> ObjDataConsulta = new Lazy<Logica.Logica.LogicaConsulta.LogicaConsulta>();

        #region CONTROL DE PAGINACION DE LOS RECIBOS DIGITALES
        readonly PagedDataSource pagedDataSource_ClienteSinPolizas = new PagedDataSource();
        int _PrimeraPagina_ClienteSinPolizas, _UltimaPagina_ClienteSinPolizas;
        private int _TamanioPagina_ClienteSinPolizas = 10;
        private int CurrentPage_ClienteSinPolizas
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

        private void HandlePaging_ClienteSinPolizas(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_ClienteSinPolizas = CurrentPage_ClienteSinPolizas - 5;
            if (CurrentPage_ClienteSinPolizas > 5)
                _UltimaPagina_ClienteSinPolizas = CurrentPage_ClienteSinPolizas + 5;
            else
                _UltimaPagina_ClienteSinPolizas = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_ClienteSinPolizas > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_ClienteSinPolizas = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_ClienteSinPolizas = _UltimaPagina_ClienteSinPolizas - 10;
            }

            if (_PrimeraPagina_ClienteSinPolizas < 0)
                _PrimeraPagina_ClienteSinPolizas = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_ClienteSinPolizas;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_ClienteSinPolizas; i < _UltimaPagina_ClienteSinPolizas; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_ClienteSinPolizas(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_ClienteSinPolizas.DataSource = Listado;
            pagedDataSource_ClienteSinPolizas.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_ClienteSinPolizas.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_ClienteSinPolizas.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_ClienteSinPolizas.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_ClienteSinPolizas : _NumeroRegistros);
            pagedDataSource_ClienteSinPolizas.CurrentPageIndex = CurrentPage_ClienteSinPolizas;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_ClienteSinPolizas.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_ClienteSinPolizas.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_ClienteSinPolizas.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_ClienteSinPolizas.IsLastPage;

            RptGrid.DataSource = pagedDataSource_ClienteSinPolizas;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_ClienteSinPolizas
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_ClienteSinPolizas(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region MOSTRAR EL LISTADO DE LOS CLIENTES SIN POOLIZA
        private void MostrarListadoClienteSinpolizas() {

            decimal? _CodigoCliente = string.IsNullOrEmpty(txtCodigoClienteSinPoliza.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoClienteSinPoliza.Text);
            string _NumeroIdentificacion = string.IsNullOrEmpty(txtNumeroIdentificacionClienteSinPoliza.Text.Trim()) ? null : txtNumeroIdentificacionClienteSinPoliza.Text.Trim();
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesdeClienteSinPoliza.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesdeClienteSinPoliza.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHastaClienteSinPoliza.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHastaClienteSinPoliza.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisorClienteSinPoliza.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisorClienteSinPoliza.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioClienteSinPoliza.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioClienteSinPoliza.Text);
            string _NombreCliente = string.IsNullOrEmpty(txtNombreClienteClienteSinPoliza.Text.Trim()) ? null : txtNombreClienteClienteSinPoliza.Text.Trim();

            var Listado = ObjDataConsulta.Value.BuscaClientesSinPolizas(
                _CodigoCliente,
                _NumeroIdentificacion,
                _FechaDesde,
                _FechaHasta,
                _Supervisor,
                _Intermediario,
                _NombreCliente);
            if (Listado.Count() < 1) {
                rpListadoClienteSinPolizas.DataSource = null;
                rpListadoClienteSinPolizas.DataBind();
            }
            else {
                Paginar_ClienteSinPolizas(ref rpListadoClienteSinPolizas, Listado,10, ref lbCantidadPaginaClientesSinPoliza, ref btnPrimeraPaginaClientesSinPoliza, ref btnPaginaAnteriorClientesSinPoliza, ref btnSiguientePaginaClientesSinPoliza, ref btnUltimaPaginaClientesSinPoliza);
                HandlePaging_ClienteSinPolizas(ref dtPaginacionListadoPrincipalClientesSinPoliza, ref lbPaginaActualClientesSinPoliza);
            }
        }
        #endregion

        #region EXPORTAR CLIENTES SIN POLIZAS
        private void ExportarClientesSinPolizas() {

            decimal? _CodigoCliente = string.IsNullOrEmpty(txtCodigoClienteSinPoliza.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoClienteSinPoliza.Text);
            string _NumeroIdentificacion = string.IsNullOrEmpty(txtNumeroIdentificacionClienteSinPoliza.Text.Trim()) ? null : txtNumeroIdentificacionClienteSinPoliza.Text.Trim();
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesdeClienteSinPoliza.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesdeClienteSinPoliza.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHastaClienteSinPoliza.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHastaClienteSinPoliza.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisorClienteSinPoliza.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisorClienteSinPoliza.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioClienteSinPoliza.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioClienteSinPoliza.Text);
            string _NombreCliente = string.IsNullOrEmpty(txtNombreClienteClienteSinPoliza.Text.Trim()) ? null : txtNombreClienteClienteSinPoliza.Text.Trim();

            var Exportar = (from n in ObjDataConsulta.Value.BuscaClientesSinPolizas(
               _CodigoCliente,
               _NumeroIdentificacion,
               _FechaDesde,
               _FechaHasta,
               _Supervisor,
               _Intermediario,
               _NombreCliente)
                            select new
                            {
                                Codigo = n.Codigo,
                                TipoIdentificacion = n.TipoIdentificacion,
                                NumeroIdentificacion = n.RNC,
                                Cliente = n.Cliente,
                                Direccion = n.Direccion,
                                Supervisor = n.Supervisor,
                                Intermediario = n.Intermediario,
                                Cobrador = n.Cobrador,
                                UsuarioAdiciona = n.UsuarioAdiciona,
                                fecha0 = n.fecha0,
                                Fecha_Formateada = n.Fecha,
                                TelefonoResidencia = n.TelefonoResidencia,
                                TelefonoOficina = n.TelefonoOficina,
                                Celular = n.Celular,
                                fax = n.fax,
                                Beeper = n.Beeper,
                                Comprobante = n.Comprobante,
                                Nacionalidad = n.Nacionalidad,
                                ClaseCliente = n.ClaseCliente
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Clientes Sin polizas", Exportar);
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
                lbPantalla.Text = "REGISTROS IMCOMPLETOS";

                DIVBloqueClientesSinPoliza.Visible = true;
            }
        }

        protected void rbCLientesSinPolizas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCLientesSinPolizas.Checked == true) {
                DIVBloqueClientesSinPoliza.Visible = true;
                DIVBloquePolziaSinMarbete.Visible = false;
            }
            else {
                DIVBloqueClientesSinPoliza.Visible = false;
                DIVBloquePolziaSinMarbete.Visible = false;
            }
        }

        protected void rbPolizasSInImpresionMarbete_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPolizasSInImpresionMarbete.Checked == true) {
                DIVBloqueClientesSinPoliza.Visible = false;
                DIVBloquePolziaSinMarbete.Visible = true;
            }
            else {
                DIVBloqueClientesSinPoliza.Visible = false;
                DIVBloquePolziaSinMarbete.Visible = false;
            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            if (rbCLientesSinPolizas.Checked == true) {
                CurrentPage_ClienteSinPolizas = 0;
                MostrarListadoClienteSinpolizas();
            }
            else if (rbPolizasSInImpresionMarbete.Checked == true) { }
        }

        protected void btnExportarExel_Click(object sender, ImageClickEventArgs e)
        {
            if (rbCLientesSinPolizas.Checked == true) {
                ExportarClientesSinPolizas();
            }
            else if (rbPolizasSInImpresionMarbete.Checked == true) { }
        }

        protected void btnPrimeraPaginaClientesSinPoliza_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ClienteSinPolizas = 0;
            MostrarListadoClienteSinpolizas();
        }

        protected void btnPaginaAnteriorClientesSinPoliza_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ClienteSinPolizas += -1;
            MostrarListadoClienteSinpolizas();
            MoverValoresPaginacion_ClienteSinPolizas((int)OpcionesPaginacionValores_ClienteSinPolizas.PaginaAnterior, ref lbPaginaActualClientesSinPoliza, ref lbCantidadPaginaClientesSinPoliza);
        }

        protected void dtPaginacionListadoPrincipalClientesSinPoliza_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipalClientesSinPoliza_CancelCommand(object source, DataListCommandEventArgs e)
        {

            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_ClienteSinPolizas = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoClienteSinpolizas();
        }

        protected void btnSiguientePaginaClientesSinPoliza_Click(object sender, ImageClickEventArgs e)
        {

            CurrentPage_ClienteSinPolizas += 1;
            MostrarListadoClienteSinpolizas();
        }

        protected void txtCodigoSupervisorClienteSinPoliza_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Supervisor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisorClienteSinPoliza.Text);
            txtNombreSupervisorClienteSinPoliza.Text = Supervisor.SacarNombreSupervisor();
        }

        protected void txtCodigoIntermediarioClienteSinPoliza_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Intermediario = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediarioClienteSinPoliza.Text);
            txtNombreIntermediarioClienteSinPoliza.Text = Intermediario.SacarNombreIntermediario();
        }

        protected void btnUltimaPaginaClientesSinPoliza_Click(object sender, ImageClickEventArgs e)
        {

            CurrentPage_ClienteSinPolizas = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoClienteSinpolizas();
            MoverValoresPaginacion_ClienteSinPolizas((int)OpcionesPaginacionValores_ClienteSinPolizas.UltimaPagina, ref lbPaginaActualClientesSinPoliza, ref lbCantidadPaginaClientesSinPoliza);
        }
    }
}