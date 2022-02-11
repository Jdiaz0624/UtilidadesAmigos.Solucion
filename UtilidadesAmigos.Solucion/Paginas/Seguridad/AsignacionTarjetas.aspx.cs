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

namespace UtilidadesAmigos.Solucion.Paginas
{//decimal? _Oficina = ddlOficinaConsulta.SelectedValue != "-1" ? decimal.Parse(ddlOficinaConsulta.SelectedValue) : new Nullable<decimal>();
    
    public partial class AsignacionTarjetas : System.Web.UI.Page

  
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad> ObjDataSeguridad = new Lazy<Logica.Logica.LogicaSeguridad.LogicaSeguridad>();

        enum PermisoUSuarios
        {
            JuanMarcelinoMedinaDiaz=1
        }

        #region CONTROL DE PAGINACION
        readonly PagedDataSource pagedDataSource_ControlTarjetaAcceso = new PagedDataSource();
        int _PrimeraPagina_ControlTarjetaAcceso, _UltimaPagina_ControlTarjetaAcceso;
        private int _TamanioPagina_ControlTarjetaAcceso = 10;
        private int CurrentPage_ControlTarjetaAcceso
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

        private void HandlePaging_ControlTarjetaAcceso(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_ControlTarjetaAcceso = CurrentPage_ControlTarjetaAcceso - 5;
            if (CurrentPage_ControlTarjetaAcceso > 5)
                _UltimaPagina_ControlTarjetaAcceso = CurrentPage_ControlTarjetaAcceso + 5;
            else
                _UltimaPagina_ControlTarjetaAcceso = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_ControlTarjetaAcceso > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_ControlTarjetaAcceso = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_ControlTarjetaAcceso = _UltimaPagina_ControlTarjetaAcceso - 10;
            }

            if (_PrimeraPagina_ControlTarjetaAcceso < 0)
                _PrimeraPagina_ControlTarjetaAcceso = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_ControlTarjetaAcceso;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_ControlTarjetaAcceso; i < _UltimaPagina_ControlTarjetaAcceso; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_ControlTarjetaAcceso(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_ControlTarjetaAcceso.DataSource = Listado;
            pagedDataSource_ControlTarjetaAcceso.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_ControlTarjetaAcceso.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_ControlTarjetaAcceso.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_ControlTarjetaAcceso.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_ControlTarjetaAcceso : _NumeroRegistros);
            pagedDataSource_ControlTarjetaAcceso.CurrentPageIndex = CurrentPage_ControlTarjetaAcceso;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_ControlTarjetaAcceso.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_ControlTarjetaAcceso.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_ControlTarjetaAcceso.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_ControlTarjetaAcceso.IsLastPage;

            RptGrid.DataSource = pagedDataSource_ControlTarjetaAcceso;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_ControlTarjetaAcceso
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_ControlTarjetaAcceso(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
            int Sucursal = 1;
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaCOnsulta, ObjData.Value.BuscaListas("OFICINA", Sucursal.ToString(), null), true);
        }
        private void CargarDepartamentos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlOficinaCOnsulta.SelectedValue.ToString(), null), true);
        }
        
        private void CargarEstatus() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEstatusCOnsulta, ObjData.Value.BuscaListas("ESTATUSTARJETA", null, null), true);
        }

        private void CargarOficinasMantenimiento()
        {
            int Sucursal = 1;
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjData.Value.BuscaListas("OFICINA", Sucursal.ToString(), null));
        }
        private void CargarDepartamentosMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoMantenimiento, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlOficinaMantenimiento.SelectedValue.ToString(), null));
        }

        private void CargarEstatusMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEstatusMantenimiento, ObjData.Value.BuscaListas("ESTATUSTARJETA", null, null));
        }
        #endregion
        #region MOSTRAR EL LISTADO DEL CONTROL DE LAS TARJETAS DE ACCESO
        private void MostrarListado() {

            decimal? _Oficina = ddlOficinaCOnsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlOficinaCOnsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Departamento = ddlDepartamentoConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlDepartamentoConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Estatus = ddlEstatusCOnsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlEstatusCOnsulta.SelectedValue) : new Nullable<decimal>();
            string _Empleado = string.IsNullOrEmpty(txtEmpleadoConsulta.Text.Trim()) ? null : txtEmpleadoConsulta.Text.Trim();
            string _NumeroTarjeta = string.IsNullOrEmpty(txtNumeroTarjeta.Text.Trim()) ? null : txtNumeroTarjeta.Text.Trim();
            string _SecuencialPoliza = string.IsNullOrEmpty(txtSecuenciainterna.Text.Trim()) ? null : txtSecuenciainterna.Text.Trim();

            var Listado = ObjDataSeguridad.Value.BuscaListadoTarjetasAcceso(
                new Nullable<decimal>(),
                _Oficina,
                _Departamento,
                _Estatus,
                _Empleado,
                _NumeroTarjeta,
                _SecuencialPoliza,
                null, null);
            if (Listado.Count() < 1) {
                rpListadoTarjetas.DataSource = null;
                rpListadoTarjetas.DataBind();
            }
            else {
                Paginar_ControlTarjetaAcceso(ref rpListadoTarjetas, Listado, 10, ref lbCantidadPaginaVAriableTarjetaAcceso, ref btnPrimeraPaginaTarjetaAcceso, ref btnPrimeraPaginaTarjetaAcceso, ref btnSiguienteTarjetaAcceso, ref btnUltimoTarjetaAcceso);
                HandlePaging_ControlTarjetaAcceso(ref dtPaginacionTarjetaAcceso, ref lbPaginaActualVariableTarjetaAcceso);
            }


        }
        #endregion
        #region MOSTRAR CONFIGURACION INICIAL
        private void ConfiguracionInicial(decimal IdUsuario) {
            btnConsultar.Visible = true;
            btnNuevo.Visible = true;
            btnReporte.Visible = true;
            btnEditar.Visible = false;
            btnRestabelcer.Visible = false;
            btnGuardar.Visible = false;



            switch (IdUsuario)
            {

                case (decimal)PermisoUSuarios.JuanMarcelinoMedinaDiaz:
                    btnGuardar.Visible = true;
                    break;
            }


            CargarOficinas();
            CargarDepartamentos();
            CargarEstatus();
            CurrentPage_ControlTarjetaAcceso = 0;
            MostrarListado();
            DIVBloqueConsulta.Visible = true;
            DIVBloqueMantenimiento.Visible = false;
            lbIdRegistroSeleccionado.Text = "0";
            lbAcionTomar.Text = "INSERT";

        }
        #endregion
        #region PROCESAR LA INFORMACION DE LAS TARJETAS DE ACCESO
        /// <summary>
        /// Procesar la informacion de las tarjeta de acceso
        /// </summary>
        private void ProcesarInformacionTarjetasAcceso() {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSeguridad.ProcesarInformacionTarjetaAcceso Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionSeguridad.ProcesarInformacionTarjetaAcceso(
                Convert.ToDecimal(lbIdRegistroSeleccionado.Text),
                Convert.ToDecimal(ddlOficinaMantenimiento.SelectedValue),
                Convert.ToDecimal(ddlDepartamentoMantenimiento.SelectedValue),
                txtEmpleadoMantenimiento.Text,
                txtNumeroTarjetaMantenimiento.Text,
                txtSecuenciaInternaMantenimiento.Text,
                Convert.ToDecimal(ddlEstatusMantenimiento.SelectedValue),
                (decimal)Session["IdUsuario"],
                lbAcionTomar.Text);
            Procesar.ProcesarInformacion();
        }
        #endregion
        #region GENERAR REPORTE DE CONTROL DE TARJETAS DE ACCESO
        private void GenerarReporte(string RutaReporte, string NombreReporte) {

            decimal? _Oficina = ddlOficinaCOnsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlOficinaCOnsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Departamento = ddlDepartamentoConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlDepartamentoConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Estatus = ddlEstatusCOnsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlEstatusCOnsulta.SelectedValue) : new Nullable<decimal>();
            string _Empleado = string.IsNullOrEmpty(txtEmpleadoConsulta.Text.Trim()) ? null : txtEmpleadoConsulta.Text.Trim();
            string _NumeroTarjeta = string.IsNullOrEmpty(txtNumeroTarjeta.Text.Trim()) ? null : txtNumeroTarjeta.Text.Trim();
            string _SecuencialPoliza = string.IsNullOrEmpty(txtSecuenciainterna.Text.Trim()) ? null : txtSecuenciainterna.Text.Trim();
            

           

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@IdRegistro", new Nullable<decimal>());
            Reporte.SetParameterValue("@IdOficina", _Oficina);
            Reporte.SetParameterValue("@IdDepartamento", _Departamento);
            Reporte.SetParameterValue("@IdEstatus", _Estatus);
            Reporte.SetParameterValue("@Empleado", _Empleado);
            Reporte.SetParameterValue("@NumeroTarjeta", _NumeroTarjeta);
            Reporte.SetParameterValue("@Secuencia", _SecuencialPoliza);
            Reporte.SetParameterValue("@FechaEntradaDesde", new Nullable<DateTime>());
            Reporte.SetParameterValue("@FechaEntradaHasta", new Nullable<DateTime>());

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");
            Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "CONTROL DE TARJETAS DE ACCESO";

                ConfiguracionInicial((decimal)Session["IdUsuario"]);

              
            }


        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ControlTarjetaAcceso = 0;
            MostrarListado();
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            DIVBloqueConsulta.Visible = false;
            DIVBloqueMantenimiento.Visible = true;
            CargarOficinasMantenimiento();
            CargarDepartamentosMantenimiento();
            CargarEstatus();
            CargarEstatusMantenimiento();
            txtEmpleadoMantenimiento.Text = string.Empty;
            txtNumeroTarjetaMantenimiento.Text = string.Empty;
            txtSecuenciaInternaMantenimiento.Text = string.Empty;
            lbIdRegistroSeleccionado.Text = "0";
            lbAcionTomar.Text = "INSERT";
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            DIVBloqueConsulta.Visible = false;
            DIVBloqueMantenimiento.Visible = true;
        }

        protected void btnRestabelcer_Click(object sender, ImageClickEventArgs e)
        {
            ConfiguracionInicial((decimal)Session["IdUsuario"]);
        }

        protected void btnSeleccionar_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfIdRegistroSelecciomado = ((HiddenField)ItemSeleccionado.FindControl("hfIdRegistro")).Value.ToString();
            lbIdRegistroSeleccionado.Text = hfIdRegistroSelecciomado;

            var MostrarRegistroSeleccionado = ObjDataSeguridad.Value.BuscaListadoTarjetasAcceso(Convert.ToDecimal(hfIdRegistroSelecciomado));
            Paginar_ControlTarjetaAcceso(ref rpListadoTarjetas, MostrarRegistroSeleccionado, 10, ref lbCantidadPaginaVAriableTarjetaAcceso, ref btnPrimeraPaginaTarjetaAcceso, ref btnPrimeraPaginaTarjetaAcceso, ref btnSiguienteTarjetaAcceso, ref btnUltimoTarjetaAcceso);
            HandlePaging_ControlTarjetaAcceso(ref dtPaginacionTarjetaAcceso, ref lbPaginaActualVariableTarjetaAcceso);
            foreach (var n in MostrarRegistroSeleccionado) {

                CargarOficinasMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlOficinaMantenimiento, n.IdOficina.ToString());
                CargarDepartamentosMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlDepartamentoMantenimiento, n.IdDepartamento.ToString());
                txtEmpleadoMantenimiento.Text = n.Empleado;
                txtNumeroTarjetaMantenimiento.Text = n.NumeroTarjeta;
                txtSecuenciaInternaMantenimiento.Text = n.SecuenciaInterna;
                CargarEstatusMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlEstatusMantenimiento, n.IdEstatus.ToString());

            }

            btnConsultar.Visible = false;
            btnNuevo.Visible = false;
            btnReporte.Visible = false;
            btnEditar.Visible = true;
            btnRestabelcer.Visible = true;
            lbAcionTomar.Text = "UPDATE";
        }

        protected void btnPrimeraPaginaTarjetaAcceso_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ControlTarjetaAcceso = 0;
            MostrarListado();
        }

        protected void btnAnteriorTarjetaAcceso_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ControlTarjetaAcceso += -1;
            MostrarListado();
            MoverValoresPaginacion_ControlTarjetaAcceso((int)OpcionesPaginacionValores_ControlTarjetaAcceso.PaginaAnterior, ref lbPaginaActualVariableTarjetaAcceso, ref lbCantidadPaginaVAriableTarjetaAcceso);
        }

        protected void dtPaginacionTarjetaAcceso_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionTarjetaAcceso_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_ControlTarjetaAcceso = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListado();
        }

        protected void btnSiguienteTarjetaAcceso_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ControlTarjetaAcceso += 1;
            MostrarListado();
        }

        protected void btnUltimoTarjetaAcceso_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ControlTarjetaAcceso = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListado();
            MoverValoresPaginacion_ControlTarjetaAcceso((int)OpcionesPaginacionValores_ControlTarjetaAcceso.UltimaPagina, ref lbPaginaActualVariableTarjetaAcceso, ref lbCantidadPaginaVAriableTarjetaAcceso);
        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            ProcesarInformacionTarjetasAcceso();
            ConfiguracionInicial((decimal)Session["IdUsuario"]);
        }

        protected void btnVolverAtras_Click(object sender, ImageClickEventArgs e)
        {
            ConfiguracionInicial((decimal)Session["IdUsuario"]);
        }

        protected void ddlOficinaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDepartamentosMantenimiento();
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            GenerarReporte(Server.MapPath("ReporteTarjetaControlAcceso.rpt"), "Control de Acceso");
        }

        protected void ddlOficinaCOnsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDepartamentos();
        }
    }
}