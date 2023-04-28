using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Speech.Synthesis.TtsEngine;

namespace UtilidadesAmigos.Solucion.Paginas.Correcciones
{
    public partial class EliminarEntodoso : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaCorrecciones.LogicaCorrecciones> ObjDataCorrecciones = new Lazy<Logica.Logica.LogicaCorrecciones.LogicaCorrecciones>();
        #region CONTROL DE PAGINACION DEl HEADER
        readonly PagedDataSource pagedDataSource_Header = new PagedDataSource();
        int _PrimeraPagina_Header, _UltimaPagina_Header;
        private int _TamanioPagina_Header = 10;
        private int CurrentPage_Header
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

        private void HandlePaging_Header(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Header = CurrentPage_Header - 5;
            if (CurrentPage_Header > 5)
                _UltimaPagina_Header = CurrentPage_Header + 5;
            else
                _UltimaPagina_Header = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Header > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Header = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Header = _UltimaPagina_Header - 10;
            }

            if (_PrimeraPagina_Header < 0)
                _PrimeraPagina_Header = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Header;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Header; i < _UltimaPagina_Header; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void PaginarHeader(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_Header.DataSource = Listado;
            pagedDataSource_Header.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_Header.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_Header.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_Header.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Header : _NumeroRegistros);
            pagedDataSource_Header.CurrentPageIndex = CurrentPage_Header;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_Header.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_Header.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_Header.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_Header.IsLastPage;

            RptGrid.DataSource = pagedDataSource_Header;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_Header
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_Header(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DEL HISTORIAL DE ENDOSIS ELIMINADOS
        readonly PagedDataSource pagedDataSource_Historial = new PagedDataSource();
        int _PrimeraPagina_Historial, _UltimaPagina_Historial;
        private int _TamanioPagina_Historial = 10;
        private int CurrentPage_Historial
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

        private void HandlePaging_Historial(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Historial = CurrentPage_Historial - 5;
            if (CurrentPage_Historial > 5)
                _UltimaPagina_Historial = CurrentPage_Historial + 5;
            else
                _UltimaPagina_Historial = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Historial > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Historial = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Historial = _UltimaPagina_Historial - 10;
            }

            if (_PrimeraPagina_Historial < 0)
                _PrimeraPagina_Historial = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Historial;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Historial; i < _UltimaPagina_Historial; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void PaginarHistorial(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_Historial.DataSource = Listado;
            pagedDataSource_Historial.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_Historial.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_Historial.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_Historial.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Historial : _NumeroRegistros);
            pagedDataSource_Historial.CurrentPageIndex = CurrentPage_Historial;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_Historial.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_Historial.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_Historial.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_Historial.IsLastPage;

            RptGrid.DataSource = pagedDataSource_Historial;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_Historial
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_Historial(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region BUSCAR REGISTRO
        private void BuscarRegistro() {

            string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
            int? _Item = string.IsNullOrEmpty(txtItemConsulta.Text) ? new Nullable<int>() : Convert.ToInt32(txtItemConsulta.Text);

            var Listado = ObjDataCorrecciones.Value.BuscaEndosos(_Poliza, _Item);
            if (Listado.Count() < 1) {
                rpListadoEndosos.DataSource = null;
                rpListadoEndosos.DataBind();
                ClientScript.RegisterStartupScript(GetType(), "PolizaNoEncontrada()", "PolizaNoEncontrada();", true);
            }
            else {

                PaginarHeader(ref rpListadoEndosos, Listado, 10, ref lbCantidadPaginaVariable_Header, ref btnPrimeraPagina_Header, ref btnPaginaAnterior_Header, ref btnSiguientePagina_Header, ref btnUltimaPagina_Header);
                HandlePaging_Header(ref dtPaginacion_Header, ref lbPaginaActualVariable_Header);
            }
        }
        #endregion

        private void VolverAtras() {
            DIVBloqueConsulta.Visible = true;
            DivBloqueProceso.Visible = false;
            DivBloqueHistorico.Visible = false;
            CurrentPage_Header = 0;
            txtPolizaConsulta.Text = string.Empty;
            txtItemConsulta.Text = string.Empty;
            rpListadoEndosos.DataSource = null;
            rpListadoEndosos.DataBind();
        }

        #region ELIMINAR ENDOSOS
        private void EliminarEndoso(decimal Cotizacion, int Secuencia, int IdBeneficiario, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones.ProcesarInformacionEliminarEndosos Eliminar = new Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones.ProcesarInformacionEliminarEndosos(
                30,
                Cotizacion,
                Secuencia,
                IdBeneficiario,
                "", 0, "", DateTime.Now, "DELETE");
            Eliminar.ProcesarInformacion();
        }
        #endregion

        #region PROCESAR INFORMACION DE ENDOSOS ELIMINADOS
        private void ProcesarInformacionHistorial(string Accion) {

            var SacarInformacion = ObjDataCorrecciones.Value.BuscaEndosos(
                txtPolizaProceso.Text,
                Convert.ToInt32(txtItemProceso.Text));
            foreach (var n in SacarInformacion) {

                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones.ProcesarInformacionEndososEliminados Guardar = new Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones.ProcesarInformacionEndososEliminados(
                    0,
                    (byte)n.Compania,
                    (decimal)n.Cotizacion,
                    (int)n.Item,
                    (int)n.IdBeneficiario,
                    n.NombreBeneficiario,
                    (decimal)n.ValorEndosoCesion,
                    n.UsuarioAdiciona,
                    (DateTime)n.FechaAdiciona0,
                    (decimal)Session["IdUsuario"],
                    DateTime.Now,
                    false,
                    Accion);
                Guardar.ProcesarInformacion();
            }
        }
        #endregion

        #region MOSTRAR EL HISTORIAL DE ENDOSOS ELIMINADOS
        private void MostrarHistorialEndososEliminados() {

            string _Poliza = string.IsNullOrEmpty(txtPoliza_Historial.Text.Trim()) ? null : txtPoliza_Historial.Text.Trim();
            int? _Item = string.IsNullOrEmpty(txtItem_Historial.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtItem_Historial.Text);
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesde_Historial.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesde_Historial.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHasta_Historial.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHasta_Historial.Text);

            var MostrarListado = ObjDataCorrecciones.Value.BuscaHistoricoEndosos(
                new Nullable<decimal>(),
                _Poliza,
                _Item,
                _FechaDesde,
                _FechaHasta);
            if (MostrarListado.Count() < 1)
            {

                rpListadoEndosos.DataSource = null;
                rpListadoEndosos.DataBind();
            }
            else {
                PaginarHistorial(ref rpHistorial, MostrarListado, 10, ref lbCantidadPaginaVariable_Historial, ref btnPrimeraPagina_Historial, ref btnPaginaAnterior_Historial, ref btnSiguientePagina_Historial, ref btnUltimaPagina_Historial);
                HandlePaging_Historial(ref dtPaginacion_Historial, ref lbPaginaActualVariable_Historial);
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                Label lbNombreUsuarioCOnectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbNombreUsuarioCOnectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "ELIMINAR ENDOSOS";

                DIVBloqueConsulta.Visible = true;
                DivBloqueProceso.Visible = false;
                DivBloqueHistorico.Visible = false;
            }
        }

        protected void btnSeleccionar_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;

            var Poliza = ((HiddenField)ItemSeleccionado.FindControl("hfPoliza")).Value.ToString();
            var Item = ((HiddenField)ItemSeleccionado.FindControl("hfItem")).Value.ToString();
            var Beneficiario = ((HiddenField)ItemSeleccionado.FindControl("hfBeneficiario")).Value.ToString();

            

            var BuscarInformacion = ObjDataCorrecciones.Value.BuscaEndosos(Poliza, Convert.ToInt32(Item));
            foreach (var n in BuscarInformacion) {

                txtPolizaProceso.Text = n.Poliza;
                txtRamoProceso.Text = n.Ramo;
                txtSubRamoProceso.Text = n.Subramo;
                txtItemProceso.Text = n.Item.ToString();
                txtFechaInicioVigenciaProceso.Text = n.FechaInicioVigencia;
                txtFechaFinVigenciaProceso.Text = n.FechaFinVigencia;
                txtBeneficiarioProceso.Text = n.NombreBeneficiario;
                decimal ValorEndoso = n.ValorEndosoCesion;
                txtValorEndosoProceso.Text = ValorEndoso.ToString("N2");
                lbCotizacion_Proceso.Text = n.Cotizacion.ToString();
                lbSecuencia_Proceso.Text = n.Item.ToString();
                lbIdbeneficiario_Proceso.Text = n.IdBeneficiario.ToString();
                
            }
            DIVBloqueConsulta.Visible = false;
            DivBloqueProceso.Visible = true;
            DivBloqueHistorico.Visible = false;
        }

        protected void btnPrimeraPagina_Header_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header = 0;
            BuscarRegistro();
        }

        protected void btnPaginaAnterior_Header_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header += -1;
            BuscarRegistro();
            MoverValoresPaginacion_Header((int)OpcionesPaginacionValores_Header.PaginaAnterior, ref lbPaginaActualVariable_Header, ref lbCantidadPaginaVariable_Header);
        }

        protected void dtPaginacion_Header_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_Header_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_Header = Convert.ToInt32(e.CommandArgument.ToString());
            BuscarRegistro();
        }

        protected void btnSiguientePagina_Header_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header = 0;
            BuscarRegistro();
        }

        protected void btnUltimaPagina_Header_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            BuscarRegistro();
            MoverValoresPaginacion_Header((int)OpcionesPaginacionValores_Header.UltimaPagina, ref lbPaginaActualVariable_Header, ref lbCantidadPaginaVariable_Header);
        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            ProcesarInformacionHistorial("INSERT");
            EliminarEndoso(
                Convert.ToDecimal(lbCotizacion_Proceso.Text),
                Convert.ToInt32(lbSecuencia_Proceso.Text),
                Convert.ToInt32(lbIdbeneficiario_Proceso.Text),
                "DELETE");
            ClientScript.RegisterStartupScript(GetType(), "EndosoEliminado()", "EndosoEliminado();", true);
            VolverAtras();
        }

        protected void btnVolverAtras_Click(object sender, ImageClickEventArgs e)
        {
            VolverAtras();
        }

        protected void btnHistorico_Click(object sender, ImageClickEventArgs e)
        {
            DIVBloqueConsulta.Visible = false;
            DivBloqueProceso.Visible = false;
            DivBloqueHistorico.Visible = true;
            txtPoliza_Historial.Text = string.Empty;
            txtItem_Historial.Text = string.Empty;
            UtilidadesAmigos.Logica.Comunes.Rangofecha Rango = new Logica.Comunes.Rangofecha();
            Rango.FechaMes(ref txtFechaDesde_Historial, ref txtFechaHasta_Historial);
            CurrentPage_Historial = 0;
            MostrarHistorialEndososEliminados();
        }

        protected void btnBuscar_Historial_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Historial = 0;
            MostrarHistorialEndososEliminados();

        }

        protected void btnRestaurar_Historial_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var IdRegistro = ((HiddenField)ItemSeleccionado.FindControl("hfIdRegistroHistorial")).Value.ToString();
            bool Estatus = false;

            var SacarInformacion = ObjDataCorrecciones.Value.BuscaHistoricoEndosos(Convert.ToDecimal(IdRegistro));
            foreach (var n in SacarInformacion) {
                Estatus = (bool)n.Estatus0;

                switch (Estatus)
                {

                    case true:
                        ClientScript.RegisterStartupScript(GetType(), "RegistroDevuelto()", "RegistroDevuelto();", true);
                        break;

                    case false:
                        
                        //PROCESAMOS
                        //guardamos el registro
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones.ProcesarInformacionEliminarEndosos Guardar = new Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones.ProcesarInformacionEliminarEndosos(
                            (byte)n.Compania,
                            (decimal)n.Cotizacion,
                            (int)n.Secuencia,
                            (int)n.IdBeneficiario,
                            n.NombreBeneficiario,
                            (decimal)n.ValorEndosoCesion,
                            n.UsuarioAdiciona,
                            (DateTime)n.FechaAdiciona,
                            "INSERT");
                        Guardar.ProcesarInformacion();

                        //CAMBIAMOS EL ESTATUS
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones.ProcesarInformacionEndososEliminados Modificar = new Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones.ProcesarInformacionEndososEliminados(
                            Convert.ToDecimal(IdRegistro),
                            0, 0, 0, 0, "", 0, "", DateTime.Now, 0, DateTime.Now, false, "UPDATE");
                        Modificar.ProcesarInformacion();

                        ClientScript.RegisterStartupScript(GetType(), "RegistroRestaurado()", "RegistroRestaurado();", true);

                        CurrentPage_Historial = 0;
                        MostrarHistorialEndososEliminados();
                        break;
                }


            }
            
        }

        protected void btnPrimeraPagina_Historial_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Historial = 0;
            MostrarHistorialEndososEliminados();
        }

        protected void btnPaginaAnterior_Historial_Click(object sender, ImageClickEventArgs e)
        {

            CurrentPage_Historial += -1;
            MostrarHistorialEndososEliminados();
            MoverValoresPaginacion_Historial((int)OpcionesPaginacionValores_Historial.PaginaAnterior, ref lbPaginaActualVariable_Historial, ref lbCantidadPaginaVariable_Historial);
        }

        protected void dtPaginacion_Historial_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_Historial_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_Historial = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarHistorialEndososEliminados();

        }

        protected void btnSiguientePagina_Historial_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Historial = 0;
            MostrarHistorialEndososEliminados();
        }

        protected void btnUltimaPagina_Historial_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Historial = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarHistorialEndososEliminados();
            MoverValoresPaginacion_Historial((int)OpcionesPaginacionValores_Historial.UltimaPagina, ref lbPaginaActualVariable_Historial, ref lbCantidadPaginaVariable_Historial);
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header = 0;
            BuscarRegistro();
        }
    }
}