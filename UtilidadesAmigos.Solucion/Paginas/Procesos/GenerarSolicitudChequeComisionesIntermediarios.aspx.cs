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
    
    public partial class GenerarSolicitudChequeComisionesIntermediarios : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> ObjDataMantenimientos = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();


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


            divPaginacion.Visible = true;
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
        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarListasDesplegables() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarBanco, ObjDataGeneral.Value.BuscaListas("LISTADOBANCOS", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficina, ObjDataGeneral.Value.BuscaListas("OFICINANORMAL", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjDataGeneral.Value.BuscaListas("RAMO", null, null), true);
        }
        #endregion


        /// <summary>
        /// Este metodo es para consultar los registros y mostrarlo en pantalla dependiendo de ls filtros colocados
        /// </summary>
        private void ConsultarInformacionPantalla() {

            //ELIMINAMOS LOS REGISTROS MEDIANTE EL CODIGO DEL USUARIO CONECTADO
            decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["Idusuario"] : 0;

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla Eliminar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla(
                IdUsuario, 0, 0, 0, 0, "DELETE");
            Eliminar.ProcesarInformacion();

            int CodigoIntermediario = 0, CodigoBAnco = 0;
            decimal Monto = 0, Acumulado = 0;
            //BUSCAMOS LA INFORMACION Y LA GUARDAMOS DEPENDIENDO SI ES EN LOTE O NORMAL
            if (cbGenerarSolicitudPorLote.Checked == true) {

                if (cbTomarCuentaMontosAcmulativos.Checked == true) {
                    var BuscarInformacionComisiones = ObjDataGeneral.Value.GenerarComisionIntermediario(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        null, null, null, 500, null, null, null, null, IdUsuario);
                    foreach (var n in BuscarInformacionComisiones) {
                        CodigoIntermediario = (int)n.Codigo;
                        CodigoBAnco = (int)n.CodigoBanco;
                        Monto = (decimal)n.ALiquidar;

                        var BuscarAcumulado = ObjDataGeneral.Value.ComisionesAcumuladasIntermediarios(CodigoIntermediario, null, null, null);
                        if (BuscarAcumulado.Count() < 1)
                        {
                            Acumulado = 0;
                        }
                        else {
                            foreach (var n2 in BuscarAcumulado) {
                                Acumulado = (decimal)n2.Aliquidar;
                            }
                        }

                        //guardamos
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla(
                            IdUsuario,
                            CodigoIntermediario,
                            CodigoBAnco,
                            Monto,
                            Acumulado,
                            "INSERT");
                        Guardar.ProcesarInformacion();
                    }

                    var MostrarPorPantalla = ObjDataMantenimientos.Value.ConsultarSolicitudesPorPanalla(IdUsuario, null);
                    int CantidadRegistros = MostrarPorPantalla.Count;
                    lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                    Paginar(ref rpListadoRegistrosComisiones, MostrarPorPantalla, 10, ref lbCantidadPaginaVariable, ref LinkPrimeraPagina, ref LinkAnterior, ref LinkSiguiente, ref LinkUltimo);
                    HandlePaging(ref dtPaginacion, ref lbPaginaActualVariavle);

                }
                else if(cbTomarCuentaMontosAcmulativos.Checked==false) {
                    var BuscarInformacionComisiones = ObjDataGeneral.Value.GenerarComisionIntermediario(
                           Convert.ToDateTime(txtFechaDesde.Text),
                           Convert.ToDateTime(txtFechaHasta.Text),
                           null, null, null, 500, null, null, null, null, IdUsuario);
                    foreach (var n in BuscarInformacionComisiones)
                    {
                        CodigoIntermediario = (int)n.Codigo;
                        CodigoBAnco = (int)n.CodigoBanco;
                        Monto = (decimal)n.ALiquidar;
                        Acumulado = 0;
                      

                        //GUARDAMOS
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla(
                            IdUsuario,
                            CodigoIntermediario,
                            CodigoBAnco,
                            Monto,
                            Acumulado,
                            "INSERT");
                        Guardar.ProcesarInformacion();
                    }

                    var MostrarPorPantalla = ObjDataMantenimientos.Value.ConsultarSolicitudesPorPanalla(IdUsuario, null);
                    int CantidadRegistros = MostrarPorPantalla.Count;
                    lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                    Paginar(ref rpListadoRegistrosComisiones, MostrarPorPantalla, 10, ref lbCantidadPaginaVariable, ref LinkPrimeraPagina, ref LinkAnterior, ref LinkSiguiente, ref LinkUltimo);
                    HandlePaging(ref dtPaginacion, ref lbPaginaActualVariavle);
                }
            }
            else if(cbGenerarSolicitudPorLote.Checked==false) {
                if (cbTomarCuentaMontosAcmulativos.Checked == true) {
                    var BuscarInformacionComisiones = ObjDataGeneral.Value.GenerarComisionIntermediario(
                           Convert.ToDateTime(txtFechaDesde.Text),
                           Convert.ToDateTime(txtFechaHasta.Text),
                           txtCodigoIntermediario.Text, null, null, 500, null, null, null, null, IdUsuario);
                    foreach (var n in BuscarInformacionComisiones)
                    {
                        CodigoIntermediario = (int)n.Codigo;
                        CodigoBAnco = (int)n.CodigoBanco;
                        Monto = (decimal)n.ALiquidar;

                        var BuscarAcumulado = ObjDataGeneral.Value.ComisionesAcumuladasIntermediarios(CodigoIntermediario, null, null, null);
                        if (BuscarAcumulado.Count() < 1)
                        {
                            Acumulado = 0;
                        }
                        else
                        {
                            foreach (var n2 in BuscarAcumulado)
                            {
                                Acumulado = (decimal)n2.Aliquidar;
                            }
                        }

                        //guardamos
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla(
                            IdUsuario,
                            CodigoIntermediario,
                            CodigoBAnco,
                            Monto,
                            Acumulado,
                            "INSERT");
                        Guardar.ProcesarInformacion();
                    }

                    var MostrarPorPantalla = ObjDataMantenimientos.Value.ConsultarSolicitudesPorPanalla(IdUsuario, null);
                    int CantidadRegistros = MostrarPorPantalla.Count;
                    lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                    Paginar(ref rpListadoRegistrosComisiones, MostrarPorPantalla, 10, ref lbCantidadPaginaVariable, ref LinkPrimeraPagina, ref LinkAnterior, ref LinkSiguiente, ref LinkUltimo);
                    HandlePaging(ref dtPaginacion, ref lbPaginaActualVariavle);
                }
                else if (cbTomarCuentaMontosAcmulativos.Checked == false) {
                    var BuscarInformacionComisiones = ObjDataGeneral.Value.GenerarComisionIntermediario(
                              Convert.ToDateTime(txtFechaDesde.Text),
                              Convert.ToDateTime(txtFechaHasta.Text),
                              txtCodigoIntermediario.Text, null, null, 500, null, null, null, null, IdUsuario);
                    foreach (var n in BuscarInformacionComisiones)
                    {
                        CodigoIntermediario = (int)n.Codigo;
                        CodigoBAnco = (int)n.CodigoBanco;
                        Monto = (decimal)n.ALiquidar;

                        Acumulado = 0;

                        //guardamos
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla(
                            IdUsuario,
                            CodigoIntermediario,
                            CodigoBAnco,
                            Monto,
                            Acumulado,
                            "INSERT");
                        Guardar.ProcesarInformacion();
                    }

                    var MostrarPorPantalla = ObjDataMantenimientos.Value.ConsultarSolicitudesPorPanalla(IdUsuario, null);
                    int CantidadRegistros = MostrarPorPantalla.Count;
                    lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                    Paginar(ref rpListadoRegistrosComisiones, MostrarPorPantalla, 10, ref lbCantidadPaginaVariable, ref LinkPrimeraPagina, ref LinkAnterior, ref LinkSiguiente, ref LinkUltimo);
                    HandlePaging(ref dtPaginacion, ref lbPaginaActualVariavle);
                }
            }



        }
        /// <summary>
        /// Este metodo es para exportar la informacion a excel dependiendo de los filtros colocados
        /// </summary>
        private void ExportarInformacionExcel() {
            //ELIMINAMOS LOS REGISTROS MEDIANTE EL CODIGO DEL USUARIO CONECTADO
            decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["Idusuario"] : 0;

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla Eliminar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla(
                IdUsuario, 0, 0, 0, 0, "DELETE");
            Eliminar.ProcesarInformacion();

            int CodigoIntermediario = 0, CodigoBAnco = 0;
            decimal Monto = 0, Acumulado = 0;



            if (cbGenerarSolicitudPorLote.Checked == true) {
                if (cbTomarCuentaMontosAcmulativos.Checked == true) {
                    var BuscarInformacionComisiones = ObjDataGeneral.Value.GenerarComisionIntermediario(
                         Convert.ToDateTime(txtFechaDesde.Text),
                         Convert.ToDateTime(txtFechaHasta.Text),
                         null, null, null, 500, null, null, null, null, IdUsuario);
                    foreach (var n in BuscarInformacionComisiones)
                    {
                        CodigoIntermediario = (int)n.Codigo;
                        CodigoBAnco = (int)n.CodigoBanco;
                        Monto = (decimal)n.ALiquidar;

                        var BuscarAcumulado = ObjDataGeneral.Value.ComisionesAcumuladasIntermediarios(CodigoIntermediario, null, null, null);
                        if (BuscarAcumulado.Count() < 1)
                        {
                            Acumulado = 0;
                        }
                        else
                        {
                            foreach (var n2 in BuscarAcumulado)
                            {
                                Acumulado = (decimal)n2.Aliquidar;
                            }
                        }

                        //guardamos
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla(
                            IdUsuario,
                            CodigoIntermediario,
                            CodigoBAnco,
                            Monto,
                            Acumulado,
                            "INSERT");
                        Guardar.ProcesarInformacion();
                    }

                    var Exportar = (from n in ObjDataMantenimientos.Value.ConsultarSolicitudesPorPanalla(IdUsuario, null)
                                    select new
                                    {
                                        Codigo = n.CodigoIntermediario,
                                        Nombre = n.NombreIntermediario,
                                        Banco = n.Banco,
                                        ALiquidar = n.Monto,
                                        MontoAcumulado = n.Acumulado,
                                        Total = n.Total
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Informacion de Solicitud de cheque", Exportar);

                }
                else if (cbTomarCuentaMontosAcmulativos.Checked == false) {
                    var BuscarInformacionComisiones = ObjDataGeneral.Value.GenerarComisionIntermediario(
                          Convert.ToDateTime(txtFechaDesde.Text),
                          Convert.ToDateTime(txtFechaHasta.Text),
                          null, null, null, 500, null, null, null, null, IdUsuario);
                    foreach (var n in BuscarInformacionComisiones)
                    {
                        CodigoIntermediario = (int)n.Codigo;
                        CodigoBAnco = (int)n.CodigoBanco;
                        Monto = (decimal)n.ALiquidar;

                        Acumulado = 0;

                        //guardamos
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla(
                            IdUsuario,
                            CodigoIntermediario,
                            CodigoBAnco,
                            Monto,
                            Acumulado,
                            "INSERT");
                        Guardar.ProcesarInformacion();
                    }

                    var Exportar = (from n in ObjDataMantenimientos.Value.ConsultarSolicitudesPorPanalla(IdUsuario, null)
                                    select new
                                    {
                                        Codigo = n.CodigoIntermediario,
                                        Nombre = n.NombreIntermediario,
                                        Banco = n.Banco,
                                        ALiquidar = n.Monto,
                                        MontoAcumulado = n.Acumulado,
                                        Total = n.Total
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Informacion de Solicitud de cheque", Exportar);

                }
            }
            else if (cbGenerarSolicitudPorLote.Checked == false) {
                if (cbTomarCuentaMontosAcmulativos.Checked == true) {
                    var BuscarInformacionComisiones = ObjDataGeneral.Value.GenerarComisionIntermediario(
                           Convert.ToDateTime(txtFechaDesde.Text),
                           Convert.ToDateTime(txtFechaHasta.Text),
                           txtCodigoIntermediario.Text, null, null, 500, null, null, null, null, IdUsuario);
                    foreach (var n in BuscarInformacionComisiones)
                    {
                        CodigoIntermediario = (int)n.Codigo;
                        CodigoBAnco = (int)n.CodigoBanco;
                        Monto = (decimal)n.ALiquidar;

                        var BuscarAcumulado = ObjDataGeneral.Value.ComisionesAcumuladasIntermediarios(CodigoIntermediario, null, null, null);
                        if (BuscarAcumulado.Count() < 1)
                        {
                            Acumulado = 0;
                        }
                        else
                        {
                            foreach (var n2 in BuscarAcumulado)
                            {
                                Acumulado = (decimal)n2.Aliquidar;
                            }
                        }

                        //guardamos
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla(
                            IdUsuario,
                            CodigoIntermediario,
                            CodigoBAnco,
                            Monto,
                            Acumulado,
                            "INSERT");
                        Guardar.ProcesarInformacion();
                    }

                    var Exportar = (from n in ObjDataMantenimientos.Value.ConsultarSolicitudesPorPanalla(IdUsuario, null)
                                    select new
                                    {
                                        Codigo = n.CodigoIntermediario,
                                        Nombre = n.NombreIntermediario,
                                        Banco = n.Banco,
                                        ALiquidar = n.Monto,
                                        MontoAcumulado = n.Acumulado,
                                        Total = n.Total
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Informacion de Solicitud de cheque", Exportar);
                }
                else if (cbTomarCuentaMontosAcmulativos.Checked == false) {
                    var BuscarInformacionComisiones = ObjDataGeneral.Value.GenerarComisionIntermediario(
                             Convert.ToDateTime(txtFechaDesde.Text),
                             Convert.ToDateTime(txtFechaHasta.Text),
                             txtCodigoIntermediario.Text, null, null, 500, null, null, null, null, IdUsuario);
                    foreach (var n in BuscarInformacionComisiones)
                    {
                        CodigoIntermediario = (int)n.Codigo;
                        CodigoBAnco = (int)n.CodigoBanco;
                        Monto = (decimal)n.ALiquidar;
                        Acumulado = 0;

                        //guardamos
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla(
                            IdUsuario,
                            CodigoIntermediario,
                            CodigoBAnco,
                            Monto,
                            Acumulado,
                            "INSERT");
                        Guardar.ProcesarInformacion();
                    }

                    var Exportar = (from n in ObjDataMantenimientos.Value.ConsultarSolicitudesPorPanalla(IdUsuario, null)
                                    select new
                                    {
                                        Codigo = n.CodigoIntermediario,
                                        Nombre = n.NombreIntermediario,
                                        Banco = n.Banco,
                                        ALiquidar = n.Monto,
                                        MontoAcumulado = n.Acumulado,
                                        Total = n.Total
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Informacion de Solicitud de cheque", Exportar);
                }
            }
        }

        /// <summary>
        /// Este metodo es para generar las solicitudes de cheques dependiendo de los filtros colocados
        /// </summary>
        private void ProcesarInformacionSOlicitudChqeue() { }
  

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                //SACAMOS EL NOMBRE DE USUARIO Y EL NOMBRE DE LA PANTALLA EN LA QUE ESTAMOS
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuarioConectado = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuarioConectado.Text = Nombre.SacarNombreUsuarioConectado();
                Label lbNombrePantallaActual = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantallaActual.Text = "GENERAR SOLICITUD DE CHEQUES";

                CargarListasDesplegables();
                rbNoEndosable.Checked = true;
                txttasa.Text = UtilidadesAmigos.Logica.Comunes.SacartasaMoneda.SacarTasaMoneda(2).ToString();
                txtMontoMinimo.Text = "500";
            }
        }

        protected void cbGenerarSolicitudPorLote_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGenerarSolicitudPorLote.Checked == true) {
                lbLetreroRojo.Visible = true;
                txtCodigoIntermediario.Enabled = false;
                txtCodigoIntermediario.Text = "00000";
            }
            else if (cbGenerarSolicitudPorLote.Checked == false) {
                lbLetreroRojo.Visible = false;
                txtCodigoIntermediario.Enabled = true;
                txtCodigoIntermediario.Text = string.Empty;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ConsultarInformacionPantalla();
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ExportarInformacionExcel();
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ProcesarInformacionSOlicitudChqeue();
            }
        }

        protected void LinkPrimeraPagina_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ConsultarInformacionPantalla();
            }
        }

        protected void LinkAnterior_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ConsultarInformacionPantalla();
            }
        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ConsultarInformacionPantalla();
            }
        }

        protected void LinkSiguiente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ConsultarInformacionPantalla();
            }
        }

        protected void LinkUltimo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ConsultarInformacionPantalla();
            
            }
        }

        protected void btnSeleccionarSeleccionarRegistro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else
            {
                ConsultarInformacionPantalla();

            }
        }
    }
}