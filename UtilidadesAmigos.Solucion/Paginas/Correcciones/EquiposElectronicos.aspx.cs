using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas.Correcciones
{
    public partial class EquiposElectronicos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaCorrecciones.LogicaCorrecciones> ObjData = new Lazy<Logica.Logica.LogicaCorrecciones.LogicaCorrecciones>();

        #region CONTROL DE PAGINACION DEl Item
        readonly PagedDataSource pagedDataSource_Item = new PagedDataSource();
        int _PrimeraPagina_Item, _UltimaPagina_Item;
        private int _TamanioPagina_Item = 10;
        private int CurrentPage_Item
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

        private void HandlePaging_Item(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Item = CurrentPage_Item - 5;
            if (CurrentPage_Item > 5)
                _UltimaPagina_Item = CurrentPage_Item + 5;
            else
                _UltimaPagina_Item = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Item > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Item = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Item = _UltimaPagina_Item - 10;
            }

            if (_PrimeraPagina_Item < 0)
                _PrimeraPagina_Item = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Item;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Item; i < _UltimaPagina_Item; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void PaginarItem(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_Item.DataSource = Listado;
            pagedDataSource_Item.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_Item.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_Item.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_Item.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Item : _NumeroRegistros);
            pagedDataSource_Item.CurrentPageIndex = CurrentPage_Item;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_Item.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_Item.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_Item.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_Item.IsLastPage;

            RptGrid.DataSource = pagedDataSource_Item;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_Item
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_Item(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DEl EQUIPOS
        readonly PagedDataSource pagedDataSource_EQUIPOS = new PagedDataSource();
        int _PrimeraPagina_EQUIPOS, _UltimaPagina_EQUIPOS;
        private int _TamanioPagina_EQUIPOS = 10;
        private int CurrentPage_EQUIPOS
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

        private void HandlePaging_EQUIPOS(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_EQUIPOS = CurrentPage_EQUIPOS - 5;
            if (CurrentPage_EQUIPOS > 5)
                _UltimaPagina_EQUIPOS = CurrentPage_EQUIPOS + 5;
            else
                _UltimaPagina_EQUIPOS = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_EQUIPOS > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_EQUIPOS = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_EQUIPOS = _UltimaPagina_EQUIPOS - 10;
            }

            if (_PrimeraPagina_EQUIPOS < 0)
                _PrimeraPagina_EQUIPOS = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_EQUIPOS;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_EQUIPOS; i < _UltimaPagina_EQUIPOS; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void PaginarEQUIPOS(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_EQUIPOS.DataSource = Listado;
            pagedDataSource_EQUIPOS.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_EQUIPOS.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_EQUIPOS.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_EQUIPOS.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_EQUIPOS : _NumeroRegistros);
            pagedDataSource_EQUIPOS.CurrentPageIndex = CurrentPage_EQUIPOS;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_EQUIPOS.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_EQUIPOS.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_EQUIPOS.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_EQUIPOS.IsLastPage;

            RptGrid.DataSource = pagedDataSource_EQUIPOS;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_EQUIPOS
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_EQUIPOS(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region LISTADO DE ITEMS
        private void ListadoItems() {

            string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
            int? _Item = string.IsNullOrEmpty(txtNumeroItem.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtNumeroItem.Text);

            var Listado = ObjData.Value.BuscaInformacionEquiposElectronicos(
                _Poliza,
                _Item);
            if (Listado.Count() < 1) {
                rpListadoItems.DataSource = null;
                rpListadoItems.DataBind();
                DIVBloqueEquiposElectronicos.Visible = false;
                DIVSubBloqueListado.Visible = false;
                DIvSubBloquePoliza.Visible = true;
            }
            else {

                PaginarItem(ref rpListadoItems, Listado, 10, ref lbCantidadPagina_Item, ref btnPrimeraPagina_Item, ref btnPaginaAnterior_Item, ref btnSiguientePagina_Item, ref btnUltimaPagina_Item);
                HandlePaging_Item(ref dtPaginacion_Item, ref lbPaginaActual_Items);
                int TotalEquipos = 0;
                foreach (var n in Listado) {

                    lbDatoCliente.Text = n.NombreCliente;
                    lbDatoSupervisor.Text = n.Supervisor;
                    lbDatoIntermediario.Text = n.NombreIntermediario;
                    TotalEquipos = (int)n.CantidadEquiposTotal;
                    lbDatoTotalEquipos.Text = TotalEquipos.ToString("N0");
                }
                DIVBloqueConsulta.Visible = true;
                DIvSubBloquePoliza.Visible = true;
                DIVSubBloqueListado.Visible = true;
                DIVBloqueEquiposElectronicos.Visible = false;
            }
        }
        #endregion
        #region MOSTRAR INVENTARIO 
        private void MostrarInventario(decimal Cotizacion, int Secuencia) {

            var Data = ObjData.Value.MostrarInventarioEquiposElectrinicos(Convert.ToDecimal(Cotizacion), Convert.ToInt32(Secuencia));
            PaginarEQUIPOS(ref rpListadoInventario, Data, 10, ref lbCantidadPAginas_Equipos, ref btnPrimeraPagina_Equiposo, ref btnAnterior_Equiposo, ref btnSiguiente_Equiposo, ref btnUltima_Equiposo);
            HandlePaging_EQUIPOS(ref dtEquipos, ref lbPaginaActual_Equipos);

            int CantidadEquipos = 0;
            foreach (var n in Data)
            {
                CantidadEquipos = (int)n.TotalItems;
            }
            lbCantidadEquiposElectrinicos.Text = CantidadEquipos.ToString("N0");
        }
        #endregion
        #region PROCESAR INFORMACION INVENTARIO
        private void ProcesarInformacionInventario(int Compania, decimal Cotizacion, int Secuencia, int IdEquipo, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones.ProcesarInformacionPolizasEquiposElectronicos Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones.ProcesarInformacionPolizasEquiposElectronicos(
                Compania,
                Cotizacion,
                Secuencia,
                IdEquipo,
                txtDescripcion.Text,
                txtMarca.Text,
                txtModelo.Text,
                txtSerie.Text,
                Convert.ToDecimal(txtValorAsegurado.Text),
                Convert.ToDecimal(txtValorReposicion.Text),
                Convert.ToDecimal(txtPorcientoDeducible.Text),
                txtBAseDeducible.Text,
                Convert.ToDecimal(txtMinimoDeducible.Text),
                Convert.ToDecimal(txtPorcientoPrima.Text),
                DateTime.Now,
                Accion);
            Procesar.ProcesarInformacion();
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
                lbNombrePantalla.Text = "EQUIPOS ELECTRONICOS";

                DIVBloqueConsulta.Visible = true;
                DIvSubBloquePoliza.Visible = true;
                DIVSubBloqueListado.Visible = false;
                DIVBloqueEquiposElectronicos.Visible = false;
            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Item = 0;
            ListadoItems();
        }

        protected void btnSeleccionar_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            hfCotizacionSeleccionado.Value = ((HiddenField)ItemSeleccionado.FindControl("hfCotizacion")).Value.ToString();
            hfSecuenciaSeleccionado.Value = ((HiddenField)ItemSeleccionado.FindControl("hfSecuencia")).Value.ToString();

            MostrarInventario(Convert.ToDecimal(hfCotizacionSeleccionado.Value), Convert.ToInt32(hfSecuenciaSeleccionado.Value));
            
            DIVBloqueConsulta.Visible = false;
            DIvSubBloquePoliza.Visible = false;
            DIVSubBloqueListado.Visible = false;


            DIVBloqueEquiposElectronicos.Visible = true;
            DIVSubBloqueListadoEquiposAgregados.Visible = true;
            DIVSubBloqueProcesarEquipos.Visible = false;
        }

        protected void btnPrimeraPagina_Item_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Item = 0;
            ListadoItems();
        }

        protected void btnPaginaAnterior_Item_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Item += -1;
            ListadoItems();
            MoverValoresPaginacion_Item((int)OpcionesPaginacionValores_Item.PaginaAnterior, ref lbPaginaActual_Items, ref lbCantidadPagina_Item);
        }

        protected void dtPaginacion_Item_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            
        }

        protected void dtPaginacion_Item_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_Item = Convert.ToInt32(e.CommandArgument.ToString());
            ListadoItems();
        }

        protected void btnSiguientePagina_Item_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Item += 1;
            ListadoItems();
        }

        protected void btnNuevoRegistro_Click(object sender, ImageClickEventArgs e)
        {
            DIVBloqueConsulta.Visible = false;
            DIvSubBloquePoliza.Visible = false;
            DIVSubBloqueListado.Visible = false;


            DIVBloqueEquiposElectronicos.Visible = true;
            DIVSubBloqueListadoEquiposAgregados.Visible = false;
            DIVSubBloqueProcesarEquipos.Visible = true;

            txtValorAsegurado.Text = "0";
            txtValorReposicion.Text = "0";
            txtPorcientoDeducible.Text = "0";
            txtBAseDeducible.Text = "0";
            txtMinimoDeducible.Text = "0";
            txtPorcientoPrima.Text = "0";
        }

        protected void btnVolverAtras_Click(object sender, ImageClickEventArgs e)
        {
            DIVBloqueConsulta.Visible = true;
            DIvSubBloquePoliza.Visible = true;
            DIVSubBloqueListado.Visible = false;


            DIVBloqueEquiposElectronicos.Visible = false;
            DIVSubBloqueListadoEquiposAgregados.Visible = false;
            DIVSubBloqueProcesarEquipos.Visible = false;
        }

        protected void btnPrimeraPagina_Equiposo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_EQUIPOS = 0;
            MostrarInventario(Convert.ToDecimal(hfCotizacionSeleccionado.Value), Convert.ToInt32(hfSecuenciaSeleccionado.Value));
        }

        protected void btnAnterior_Equiposo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_EQUIPOS += -1;
            MostrarInventario(Convert.ToDecimal(hfCotizacionSeleccionado.Value), Convert.ToInt32(hfSecuenciaSeleccionado.Value));
            MoverValoresPaginacion_EQUIPOS((int)OpcionesPaginacionValores_Item.PaginaAnterior, ref lbPaginaActual_Items, ref lbCantidadPagina_Item);
        }

        protected void dtEquipos_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtEquipos_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_EQUIPOS = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarInventario(Convert.ToDecimal(hfCotizacionSeleccionado.Value), Convert.ToInt32(hfSecuenciaSeleccionado.Value));
        }

        protected void btnSiguiente_Equiposo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_EQUIPOS += 1;
            MostrarInventario(Convert.ToDecimal(hfCotizacionSeleccionado.Value), Convert.ToInt32(hfSecuenciaSeleccionado.Value));
        }

        protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        {
            var Exportar = (from n in ObjData.Value.MostrarInventarioEquiposElectrinicos(Convert.ToDecimal(hfCotizacionSeleccionado.Value), Convert.ToInt32(hfSecuenciaSeleccionado.Value))
                            select new
                            {
                                Codigo = n.IdEquipo,
                                Descripcion = n.Descripcion,
                                Marca = n.Marca,
                                Modelo = n.Modelo,
                                Serie = n.Serie,
                                ValorAsegurado = n.ValorAsegurado,
                                ValorReposicion = n.ValorReposicion,
                                PorcDeducible = n.PorcDeducible,
                                BaseDeducible = n.BaseDeducible
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Equipos", Exportar);
        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            ProcesarInformacionInventario(30, Convert.ToDecimal(hfCotizacionSeleccionado.Value), Convert.ToInt32(hfSecuenciaSeleccionado.Value), 0, "INSERT");
            CurrentPage_EQUIPOS = 0;
            MostrarInventario(Convert.ToDecimal(hfCotizacionSeleccionado.Value), Convert.ToInt32(hfSecuenciaSeleccionado.Value));

            DIVBloqueConsulta.Visible = false;
            DIvSubBloquePoliza.Visible = false;
            DIVSubBloqueListado.Visible = false;


            DIVBloqueEquiposElectronicos.Visible = true;
            DIVSubBloqueListadoEquiposAgregados.Visible = true;
            DIVSubBloqueProcesarEquipos.Visible = false;
        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            DIVBloqueConsulta.Visible = false;
            DIvSubBloquePoliza.Visible = false;
            DIVSubBloqueListado.Visible = false;


            DIVBloqueEquiposElectronicos.Visible = true;
            DIVSubBloqueListadoEquiposAgregados.Visible = true;
            DIVSubBloqueProcesarEquipos.Visible = false;
        }

        protected void txtPolizaConsulta_TextChanged(object sender, EventArgs e)
        {
            CurrentPage_Item = 0;
            ListadoItems();
        }

        protected void btnUltima_Equiposo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_EQUIPOS = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarInventario(Convert.ToDecimal(hfCotizacionSeleccionado.Value), Convert.ToInt32(hfSecuenciaSeleccionado.Value));
            MoverValoresPaginacion_EQUIPOS((int)OpcionesPaginacionValores_Item.UltimaPagina, ref lbPaginaActual_Equipos, ref lbCantidadPAginas_Equipos);
        }

        protected void btnUltimaPagina_Item_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Item = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            ListadoItems();
            MoverValoresPaginacion_Item((int)OpcionesPaginacionValores_Item.UltimaPagina, ref lbPaginaActual_Items, ref lbCantidadPagina_Item);
        }
    }
}