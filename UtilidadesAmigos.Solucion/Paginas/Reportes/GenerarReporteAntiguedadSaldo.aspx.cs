using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarReporteAntiguedadSaldo : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjdataGeneral = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> ObDataMantenimiento = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();
     
        #region CONTROL DE PAGINACION DE ANTIGUEDAD DE SALDO
        readonly PagedDataSource pagedDataSource_AntiguedadSaldo = new PagedDataSource();
        int _PrimeraPagina_AntiguedadSaldo, _UltimaPagina_AntiguedadSaldo;
        private int _TamanioPagina_AntiguedadSaldo = 10;
        private int CurrentPage_AntiguedadSaldo
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

        private void HandlePaging_AntiguedadSaldo(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_AntiguedadSaldo = CurrentPage_AntiguedadSaldo - 5;
            if (CurrentPage_AntiguedadSaldo > 5)
                _UltimaPagina_AntiguedadSaldo = CurrentPage_AntiguedadSaldo + 5;
            else
                _UltimaPagina_AntiguedadSaldo = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_AntiguedadSaldo > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_AntiguedadSaldo = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_AntiguedadSaldo = _UltimaPagina_AntiguedadSaldo - 10;
            }

            if (_PrimeraPagina_AntiguedadSaldo < 0)
                _PrimeraPagina_AntiguedadSaldo = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_AntiguedadSaldo;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_AntiguedadSaldo; i < _UltimaPagina_AntiguedadSaldo; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_AntiguedadSaldo(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_AntiguedadSaldo.DataSource = Listado;
            pagedDataSource_AntiguedadSaldo.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_AntiguedadSaldo.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_AntiguedadSaldo.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_AntiguedadSaldo.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_AntiguedadSaldo : _NumeroRegistros);
            pagedDataSource_AntiguedadSaldo.CurrentPageIndex = CurrentPage_AntiguedadSaldo;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_AntiguedadSaldo.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_AntiguedadSaldo.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_AntiguedadSaldo.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_AntiguedadSaldo.IsLastPage;

            RptGrid.DataSource = pagedDataSource_AntiguedadSaldo;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_AntiguedadSaldo
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_AntiguedadSaldo(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region ENUMERACIONES
        enum TipoMonedas { 
        Pesos=1,
        Dollar=2,
        Euro=3
        }
        #endregion
        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarRamos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlRamo, ObjdataGeneral.Value.BuscaListas("RAMO", null, null), true);
        }
        private void CargarTipoMovimientos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipo, ObjdataGeneral.Value.BuscaListas("TIPOMOVIMIENTOS", null, null), true);
        }
        private void CargarOficinas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficina, ObjdataGeneral.Value.BuscaListas("OFICINAS", null, null), true);
        }
        private void CargarMonedas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlMoneda, ObjdataGeneral.Value.BuscaListas("MONEDA", null, null), true);
        }
        #endregion
        #region MOSTRAR LISTADO POR PANTALLA
        private void ListadoPorPantalla() {
             
            decimal? _NumeroFactura = string.IsNullOrEmpty(txtNumeroFactura.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroFactura.Text);
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _Ramo = ddlRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlRamo.SelectedValue) : new Nullable<int>();
            decimal? _Tasa = string.IsNullOrEmpty(txtTasa.Text.Trim()) ? 1 : Convert.ToDecimal(txtTasa.Text);
            int? _Tipo = ddlTipo.SelectedValue != "-1" ? Convert.ToInt32(ddlTipo.SelectedValue) : new Nullable<int>();
            decimal? _Cliente = string.IsNullOrEmpty(txtCodigoCliente.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoCliente.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
            decimal? _IdUsuario = (decimal)Session["IdUsuario"] != 0 ? (decimal)Session["IdUsuario"] : 0;
            int? _Moneda = ddlMoneda.SelectedValue != "-1" ? Convert.ToInt32(ddlMoneda.SelectedValue) : new Nullable<int>();

            int CantidadRegistros = 0;

            //ELIMINAMOS TODOS LOS REGISTROS MEDIANTE EL CODIGO DEL USUARIO
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionMantenimientos.ProcesarInformacionAntiguedadSaldo Eliminar = new Logica.Comunes.ProcesarMantenimientos.InformacionMantenimientos.ProcesarInformacionAntiguedadSaldo(
                _IdUsuario, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, DateTime.Now, DateTime.Now, "DELETE");
            Eliminar.ProcesarInformacion();

            var Buscarorigen = ObDataMantenimiento.Value.BuscaOrigenDataAntiguedadSaldo(
                Convert.ToDateTime(txtFechaCorte.Text),
                _NumeroFactura,
                _Poliza,
                _Ramo,
                _Tipo,
                _Cliente,
                _Intermediario,
                _Supervisor,
                _Oficina,
                _IdUsuario,
                _Moneda);
            if (Buscarorigen.Count() < 1) {
                lbCantidadRegistrosVariable.Text = "0";
                lbCantidadRegistrosVariable.ForeColor = System.Drawing.Color.Red;
                rpListadoAntiguedad.DataSource = null;
                rpListadoAntiguedad.DataBind();

            }
            else {
                CantidadRegistros = (int)Buscarorigen.Count;
                lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                lbCantidadRegistrosVariable.ForeColor = System.Drawing.Color.Green;

                foreach (var n in Buscarorigen) {
                    //GAURDAMOS LOS REGISTROS
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionMantenimientos.ProcesarInformacionAntiguedadSaldo Guardar = new Logica.Comunes.ProcesarMantenimientos.InformacionMantenimientos.ProcesarInformacionAntiguedadSaldo(
                        _IdUsuario,
                        n.Poliza,
                        (decimal)n.Cotizacion,
                        (decimal)n.CodigoCliente,
                        (int)n.CodigoIntermediario,
                        (int)n.CodigoSupervisor,
                        (int)n.CodigoOficina,
                        (int)n.CodigoMoneda,
                        (int)n.CodigoRamo,
                        (decimal)n.Valor,
                        (decimal)n.NumeroFactura,
                        (decimal)n.Balance,
                        (int)n.Tipo,
                        (DateTime)n.Fecha,
                        (DateTime)n.FechaCorte,
                        "INSERT");
                    Guardar.ProcesarInformacion();
                }
            }

            
        }
        #endregion

        #region EXPORTAR INFORMACION A EXCEL
        private void ExportarDataExcel() {
            decimal? _NumeroFactura = string.IsNullOrEmpty(txtNumeroFactura.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroFactura.Text);
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _Ramo = ddlRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlRamo.SelectedValue) : new Nullable<int>();
            decimal? _Tasa = string.IsNullOrEmpty(txtTasa.Text.Trim()) ? 1 : Convert.ToDecimal(txtTasa.Text);
            int? _Tipo = ddlTipo.SelectedValue != "-1" ? Convert.ToInt32(ddlTipo.SelectedValue) : new Nullable<int>();
            decimal? _Cliente = string.IsNullOrEmpty(txtCodigoCliente.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoCliente.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
            decimal? _IdUsuario = (decimal)Session["IdUsuario"] != 0 ? (decimal)Session["IdUsuario"] : 0;
            int? _Moneda = ddlMoneda.SelectedValue != "-1" ? Convert.ToInt32(ddlMoneda.SelectedValue) : new Nullable<int>();

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
                lbPantalla.Text = "ANTIGUEDAD DE SALDO";

                CargarRamos();
                CargarTipoMovimientos();
                CargarOficinas();
                CargarMonedas();
  
            }
        }

        protected void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaCorte.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CampoFechaCorteVacio()", "CampoFechaCorteVacio();", true);
            }
            else {
                ListadoPorPantalla();
            }
        }

        protected void btnGenerarExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaCorte.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CampoFechaCorteVacio()", "CampoFechaCorteVacio();", true);
            }
            else {

                ExportarDataExcel();
            }
        }

        protected void btnkPrimeraPaginaListadoAntiguedadSaldo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnAnteriorListadoAntiguedadSaldo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacionListadoAntiguedadSaldo_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoAntiguedadSaldo_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguienteListadoAntiguedadSaldo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimoListadoAntiguedadSaldo_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}