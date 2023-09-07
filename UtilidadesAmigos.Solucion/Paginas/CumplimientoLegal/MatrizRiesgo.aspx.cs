using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace UtilidadesAmigos.Solucion.Paginas.CumplimientoLegal
{
    public partial class MatrizRiesgo : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaCumplimiento.LogicaCumplimiento> ObjDataCumplimiento = new Lazy<Logica.Logica.LogicaCumplimiento.LogicaCumplimiento>();


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
        #region MOSTRAR LISTADO DE MATRIZ
        private void MostrarListadoMatriz() {

            string _Nombre = string.IsNullOrEmpty(txtNombreConsulta.Text.Trim()) ? null : txtNombreConsulta.Text.Trim();
            string _NumeroIdentificacion = string.IsNullOrEmpty(txtNumeroIdentificacionConsulta.Text.Trim()) ? null : txtNumeroIdentificacionConsulta.Text.Trim();
            int? _Area = ddlAreaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlAreaConsulta.SelectedValue) : new Nullable<int>();
            int? _Posicion = ddlPosicionConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlPosicionConsulta.SelectedValue) : new Nullable<int>();

            var Listado = ObjDataCumplimiento.Value.BuscaMatrisRiezgo(
                new Nullable<decimal>(),
                null, null, null,
                _Nombre,
                null,
                _NumeroIdentificacion,
                _Area,
                _Posicion);
            if (Listado.Count() < 1) {
                rpListado.DataSource = null;
                rpListado.DataBind();
            }
            else {
                Paginar(ref rpListado, Listado, 10, ref lbCantidadPAgina, ref btnPrimeraPagina, ref btnPaginaAnterior, ref btnSiguientePagina, ref btnUltimaPagina);
                HandlePaging(ref dtPaginacion, ref lbPaginaActual);
            }
        }
        #endregion
        #region LISTAS GENERALES
        private void CargarListas() {
            ListaTipoIdentificaciion();
            ListaTipoTercero();
            ListaNivelRiesto_TipoTercero();
            ListaArea();
            ListaNivelRiesto_Area();
            ListaPosiciion();
            ListaNivelRiesto_Posicion();
            ListanivelAcademico();
            ListaNivelRiesto_NivelAcademico();
            ListaPaisProcedencia();
            ListaNivelRiesto_PaisProcedencia();
            ListaPaisResidencia();
            ListaNivelRiesto_PaisResidencia();
            ListaProvincia();
            ListaNivelRiesto_Provincia();
            ListaSalarioDevengado();
            ListaNivelRiesto_SalarioDevengado();
            ListaPEP();
            ListaNivelRiesto_PEP();
            ListaTipoMonitoreo();
            TipoDebidaDiligencia();
            ListaNivelRiesto_NIVELRIESGOCONSOLIDADO();
            ListaNivelRiesto_ActividadSegundaria();
            ListaNivelRiesto_IngresosAdicionales();
            ListaNivelRiesto_PrimaAnual();
        }

        private void ListaTipoIdentificaciion()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoIdentificacion_Matriz, ObjDataGeneral.Value.BuscaListas("TIPO_IDENTIFICACION_MATRIZ", null, null));
        }
        private void ListaTipoTercero() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoTercero_Matriz, ObjDataGeneral.Value.BuscaListas("TIPO_TERCERO_MATRIZ", null, null));
        }
        private void ListaNivelRiesto_TipoTercero() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRIesgo_TipoRiesgo_MAtriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaArea()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlArea_Matriz, ObjDataGeneral.Value.BuscaListas("AREA_MATRIZ", null, null));
        }
        private void ListaAreaConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlAreaConsulta, ObjDataGeneral.Value.BuscaListas("AREA_MATRIZ", null, null),true);
        }
        private void ListaNivelRiesto_Area()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_Area_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaPosiciion()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPocision_Matriz, ObjDataGeneral.Value.BuscaListas("POCISION_MATRIZ", null, null));
        }
        private void ListaPosiciion_Consulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPosicionConsulta, ObjDataGeneral.Value.BuscaListas("POCISION_MATRIZ", null, null),true);
        }
        private void ListaNivelRiesto_Posicion()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_Posicion_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListanivelAcademico()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelAcademico_Matriz, ObjDataGeneral.Value.BuscaListas("NIVELACADEMICO_MATRIZ", null, null));
        }
        private void ListaNivelRiesto_NivelAcademico()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_NivelAcademico_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaPaisProcedencia()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPaisProcedencia_Matriz, ObjDataGeneral.Value.BuscaListas("PAIS_PROCEDENCIA_MATRIZ", null, null));
        }
        private void ListaNivelRiesto_PaisProcedencia()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_PaisProcedencia_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaPaisResidencia()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPaisResidencia_Matriz, ObjDataGeneral.Value.BuscaListas("PAIS_RESIDENCIA_MATRIZ", null, null));
        }
        private void ListaNivelRiesto_PaisResidencia()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_PaisResidencia_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaProvincia()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlProvincia_Matriz, ObjDataGeneral.Value.BuscaListas("PROVINCIA_MATRIZ", ddlPaisResidencia_Matriz.SelectedValue.ToString(), null));
        }
        private void ListaNivelRiesto_Provincia()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_Provincia_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaSalarioDevengado()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSalarioDevengado_Matriz, ObjDataGeneral.Value.BuscaListas("SALARIO_DEVENGADO_MATRIZ", null, null));
        }
        private void ListaNivelRiesto_SalarioDevengado()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgoSalarioDevengado, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaPEP()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPEP_Matriz, ObjDataGeneral.Value.BuscaListas("PEP_MATRIZ", null, null));
        }
        private void ListaNivelRiesto_PEP()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_PEP_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaTipoMonitoreo()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoMonitoreo_Matriz, ObjDataGeneral.Value.BuscaListas("TIPO_MONITOREO_MATRIZ", null, null));
        }

        private void TipoDebidaDiligencia() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoDebidaDiligencia, ObjDataGeneral.Value.BuscaListas("TIPO_DEBIDA_DILIGENCIA_MATRIZ", null, null));

        }

        private void ListaNivelRiesto_NIVELRIESGOCONSOLIDADO()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_Consolidado_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaNivelRiesto_ActividadSegundaria()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_ActividaSegundaria, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaNivelRiesto_IngresosAdicionales()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_IngresosAdicionales_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaNivelRiesto_PrimaAnual()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_PrimaAnual_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }
        #endregion
        #region PROCESAR LA INFORMACION DE LA MATRIZ DE RIESGO
        private void GuardarInformacionMatriz(decimal IdRegistro, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Cumplimiento.ProcesarInformacionMatrizRiezgo Procesar = new Logica.Comunes.ProcesarMantenimientos.Cumplimiento.ProcesarInformacionMatrizRiezgo(
                IdRegistro,
                DateTime.Now,
                (decimal)Session["IdUsuario"],
                txtNombre_Matriz.Text,
                Convert.ToInt32(ddlTipoIdentificacion_Matriz.SelectedValue),
                txtNumeroidentificacion.Text,
                Convert.ToInt32(ddlTipoTercero_Matriz.SelectedValue),
                Convert.ToInt32(ddlNivelRIesgo_TipoRiesgo_MAtriz.SelectedValue),
                Convert.ToInt32(ddlArea_Matriz.SelectedValue),
                Convert.ToInt32(ddlNivelRiesgo_Area_Matriz.SelectedValue),
                Convert.ToInt32(ddlPocision_Matriz.SelectedValue),
                Convert.ToInt32(ddlNivelRiesgo_Posicion_Matriz.SelectedValue),
                Convert.ToInt32(ddlNivelAcademico_Matriz.SelectedValue),
                Convert.ToInt32(ddlNivelRiesgo_NivelAcademico_Matriz.SelectedValue),
                Convert.ToInt32(ddlPaisProcedencia_Matriz.SelectedValue),
                Convert.ToInt32(ddlNivelRiesgo_PaisProcedencia_Matriz.SelectedValue),
                Convert.ToInt32(ddlPaisResidencia_Matriz.SelectedValue),
                Convert.ToInt32(ddlNivelRiesgo_PaisResidencia_Matriz.SelectedValue),
                Convert.ToInt32(ddlProvincia_Matriz.SelectedValue),
                Convert.ToInt32(ddlNivelRiesgo_PaisProcedencia_Matriz.SelectedValue),
                Convert.ToInt32(ddlSalarioDevengado_Matriz.SelectedValue),
                Convert.ToInt32(ddlNivelRiesgoSalarioDevengado.SelectedValue),
                txtActividadSegundaria_Matriz.Text,
                Convert.ToInt32(ddlNivelRiesgo_ActividaSegundaria.SelectedValue),
                Convert.ToDecimal(txtIngresosAdicionales.Text),
                Convert.ToInt32(ddlNivelRiesgo_IngresosAdicionales_Matriz.SelectedValue),
                Convert.ToInt32(ddlPEP_Matriz.SelectedValue),
                Convert.ToInt32(ddlNivelRiesgo_PEP_Matriz.SelectedValue),
                Convert.ToDecimal(txtPrimaAnual.Text),
                Convert.ToInt32(ddlNivelRiesgo_PrimaAnual_Matriz.SelectedValue),
                Convert.ToInt32(ddlTipoMonitoreo_Matriz.SelectedValue),
                Convert.ToInt32(ddlTipoDebidaDiligencia.SelectedValue),
                Convert.ToInt32(ddlNivelRiesgo_Consolidado_Matriz.SelectedValue),
                txtObservaciones.Text,
                Accion);
            Procesar.ProcesarInformacion();
        }
        #endregion
        #region GENERAR MATRIZ DE RIESGO
        private void GenerarMatrizRiesgo(string Nombre, decimal IdRegistro) {

            string RutaReporte = Server.MapPath("MatrizRiezgo.rpt");
            string NombreReporte = "Registro de " + Nombre;
            string UsuarioBD = "", ClaveBD = "";

            UtilidadesAmigos.Logica.Comunes.SacarCredencialesBD Credenciales = new Logica.Comunes.SacarCredencialesBD(1);
            UsuarioBD = Credenciales.SacarUsuario();
            ClaveBD = Credenciales.SacarClaveBD();

            ReportDocument Matriz = new ReportDocument();

            Matriz.Load(RutaReporte);
            Matriz.Refresh();

            Matriz.SetParameterValue("@IdRegistro", IdRegistro);
            Matriz.SetParameterValue("@FechaDesde", new Nullable<DateTime>());
            Matriz.SetParameterValue("@FechaHasta", new Nullable<DateTime>());
            Matriz.SetParameterValue("@IdUsuarui", new Nullable<decimal>());
            Matriz.SetParameterValue("@Nombre", null);
            Matriz.SetParameterValue("@IdTipoIdentificacion", new Nullable<int>());
            Matriz.SetParameterValue("@NumeroIdentificacion", null);
            Matriz.SetParameterValue("@IdArea", new Nullable<int>());
            Matriz.SetParameterValue("@IdPosicion", new Nullable<int>());

            Matriz.SetDatabaseLogon(UsuarioBD, ClaveBD);

            Matriz.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);

            Matriz.Dispose();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {

                DivBloqueConsulta.Visible = true;
                DIVBloqueMatriz.Visible = false;
                ListaAreaConsulta();
                ListaPosiciion_Consulta();
                
            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoMatriz();
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            DivBloqueConsulta.Visible = false;
            DIVBloqueMatriz.Visible = true;
            CargarListas();
            txtNombre_Matriz.Text = string.Empty;
            txtNumeroidentificacion.Text = string.Empty;
            txtActividadSegundaria_Matriz.Text = string.Empty;
            txtIngresosAdicionales.Text = string.Empty;
            txtPrimaAnual.Text = "0";
            txtIngresosAdicionales.Text = "0";
            txtObservaciones.Text = string.Empty;
            hfIdRegistroSeleccionado.Value = "0";
            hfAccionTomar.Value = "INSERT";
            txtNombre_Matriz.Focus();
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var IdRegsitro = ((HiddenField)ItemSeleccionado.FindControl("hfIdRegistro")).Value.ToString();
            hfIdRegistroSeleccionado.Value = IdRegsitro;
            hfAccionTomar.Value = "UPDATE";

            var SacarInformacion = ObjDataCumplimiento.Value.BuscaMatrisRiezgo(Convert.ToDecimal(IdRegsitro));
            foreach (var n in SacarInformacion) {
                txtNombre_Matriz.Text = n.Nombre;
                ListaTipoIdentificaciion();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlTipoIdentificacion_Matriz, n.IdTipoIdentificacion.ToString());
                txtNumeroidentificacion.Text = n.NumeroIdentificacion;
                ListaTipoTercero();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlTipoTercero_Matriz, n.IdTipoTercero.ToString());
                ListaNivelRiesto_TipoTercero();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlNivelRIesgo_TipoRiesgo_MAtriz, n.IdNivel_Riesgo_TipoTercero.ToString());
                ListaArea();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlArea_Matriz, n.IdArea.ToString());
                ListaNivelRiesto_Area();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlNivelRiesgo_Area_Matriz, n.IdNivel_Riesgo_Area.ToString());
                ListaPosiciion();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlPocision_Matriz, n.IdPosicion.ToString());
                ListaNivelRiesto_Posicion();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlNivelRiesgo_Posicion_Matriz, n.IdNivel_Riesgo_Posicion.ToString());
                ListanivelAcademico();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlNivelAcademico_Matriz, n.IdNivelAcademico.ToString());
                ListaNivelRiesto_NivelAcademico();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlNivelRiesgo_NivelAcademico_Matriz, n.IdNivel_Riesgo_NivelAcademico.ToString());
                ListaPaisProcedencia();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlPaisProcedencia_Matriz, n.IdPaisProcedencia.ToString());
                ListaNivelRiesto_PaisProcedencia();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlNivelRiesgo_PaisProcedencia_Matriz, n.IdNivel_Riesgo_PaisProcedencia.ToString());
                ListaPaisResidencia();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlPaisResidencia_Matriz, n.IdPaisResidencia.ToString());
                ListaNivelRiesto_PaisResidencia();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlNivelRiesgo_PaisResidencia_Matriz, n.IdNivel_Riesgo_PaisResidencia.ToString());
                ListaProvincia();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlProvincia_Matriz, n.Provincia.ToString());
                ListaNivelRiesto_Provincia();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlNivelRiesgo_Provincia_Matriz, n.IdNivel_Riesgo_Provincia.ToString());
                ListaSalarioDevengado();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSalarioDevengado_Matriz, n.IdSalarioDevengado.ToString());
                ListaNivelRiesto_SalarioDevengado();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlNivelRiesgoSalarioDevengado, n.IdNivel_Riesgo_SalarioDevengado.ToString());
                txtActividadSegundaria_Matriz.Text = n.ActividadSegundaria;
                ListaNivelRiesto_ActividadSegundaria();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlNivelRiesgo_ActividaSegundaria, n.IdNivel_Riesgo_ActividadSegundaria.ToString());
                txtIngresosAdicionales.Text = n.IngresosAdicionales.ToString();
                ListaNivelRiesto_IngresosAdicionales();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlNivelRiesgo_IngresosAdicionales_Matriz, n.IdNivel_Riesgo_IngresosAdicionales.ToString());
                ListaPEP();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlPEP_Matriz, n.IdPEP.ToString());
                ListaNivelRiesto_PEP();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlNivelRiesgo_PEP_Matriz, n.IdNivel_Riesgo_PEP.ToString());
                txtPrimaAnual.Text = n.PrimaAnual.ToString();
                ListaNivelRiesto_PrimaAnual();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlNivelRiesgo_PrimaAnual_Matriz, n.IdNivel_Riesgo_PrimaAnual.ToString());
                ListaTipoMonitoreo();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlTipoMonitoreo_Matriz, n.IdTipoMonitoreo.ToString());
                TipoDebidaDiligencia();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlTipoDebidaDiligencia, n.IdTipoDebidaDiligencia.ToString());
                ListaNivelRiesto_NIVELRIESGOCONSOLIDADO();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlNivelRiesgo_Consolidado_Matriz, n.IdNivel_Riesgo_Consolidado.ToString());
                txtObservaciones.Text = n.Observaciones;

                DivBloqueConsulta.Visible = false;
                DIVBloqueMatriz.Visible = true;
            }
        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            
            GuardarInformacionMatriz(Convert.ToDecimal(hfIdRegistroSeleccionado.Value), hfAccionTomar.Value);
            ClientScript.RegisterStartupScript(GetType(), "ProcesoCompletado()", "ProcesoCompletado();", true);
            if (hfAccionTomar.Value == "INSERT") {
                var SacarRegistroSeleccionado = ObjDataCumplimiento.Value.SacaNumeroMatrizGenerado((decimal)Session["IdUsuario"]);
                foreach (var n in SacarRegistroSeleccionado)
                {

                    hfIdRegistroSeleccionado.Value = n.IdRegistro.ToString();
                }
            }

            //MOSTRAMOS LA INFORMACION
            CurrentPage = 0;
            var MostrarRegistro = ObjDataCumplimiento.Value.BuscaMatrisRiezgo(Convert.ToDecimal(hfIdRegistroSeleccionado.Value));
            Paginar(ref rpListado, MostrarRegistro, 10, ref lbCantidadPAgina, ref btnPrimeraPagina, ref btnPaginaAnterior, ref btnSiguientePagina, ref btnUltimaPagina);
            HandlePaging(ref dtPaginacion, ref lbPaginaActual);

            DivBloqueConsulta.Visible = true;
            DIVBloqueMatriz.Visible = false;
        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            DivBloqueConsulta.Visible = true;
            DIVBloqueMatriz.Visible = false;
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            var RegistroSelccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var IdRegistroSeleccionado = ((HiddenField)RegistroSelccionado.FindControl("hfIdRegistro")).Value.ToString();
            var NombreSeleccionado = ((HiddenField)RegistroSelccionado.FindControl("hfNombre")).Value.ToString();

            GenerarMatrizRiesgo(NombreSeleccionado, Convert.ToDecimal(IdRegistroSeleccionado));
        }
    }
}