using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Threading;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ProduccionDiariaContabilidad : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        enum TipoDeReporte { 
        
            Produccion=1,
            Cobros=2
        }

        #region CONTROL DE PAGINACION PRODUCCION SIN INTERMEDIARIO
        readonly PagedDataSource pagedDataSource_ProduccionSinIntermediario = new PagedDataSource();
        int _PrimeraPagina_ProduccionSinIntermediario, _UltimaPagina_ProduccionSinIntermediario;
        private int _TamanioPagina_ProduccionSinIntermediario = 10;
        private int CurrentPage_ProduccionSinIntermediario
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

        private void HandlePaging_ProduccionSinIntermediario(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_ProduccionSinIntermediario = CurrentPage_ProduccionSinIntermediario - 5;
            if (CurrentPage_ProduccionSinIntermediario > 5)
                _UltimaPagina_ProduccionSinIntermediario = CurrentPage_ProduccionSinIntermediario + 5;
            else
                _UltimaPagina_ProduccionSinIntermediario = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_ProduccionSinIntermediario > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_ProduccionSinIntermediario = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_ProduccionSinIntermediario = _UltimaPagina_ProduccionSinIntermediario - 10;
            }

            if (_PrimeraPagina_ProduccionSinIntermediario < 0)
                _PrimeraPagina_ProduccionSinIntermediario = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_ProduccionSinIntermediario;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_ProduccionSinIntermediario; i < _UltimaPagina_ProduccionSinIntermediario; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_ProduccionSinIntermediario(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_ProduccionSinIntermediario.DataSource = Listado;
            pagedDataSource_ProduccionSinIntermediario.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_ProduccionSinIntermediario.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_ProduccionSinIntermediario.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_ProduccionSinIntermediario.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_ProduccionSinIntermediario : _NumeroRegistros);
            pagedDataSource_ProduccionSinIntermediario.CurrentPageIndex = CurrentPage_ProduccionSinIntermediario;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_ProduccionSinIntermediario.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_ProduccionSinIntermediario.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_ProduccionSinIntermediario.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_ProduccionSinIntermediario.IsLastPage;

            RptGrid.DataSource = pagedDataSource_ProduccionSinIntermediario;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_ProduccionSinIntermediario
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_ProduccionSinIntermediario(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION PRODUCCION CON INTERMEDIARIO
        readonly PagedDataSource pagedDataSource_ProduccionConIntermediario = new PagedDataSource();
        int _PrimeraPagina_ProduccionConIntermediario, _UltimaPagina_ProduccionConIntermediario;
        private int _TamanioPagina_ProduccionConIntermediario = 10;
        private int CurrentPage_ProduccionConIntermediario
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

        private void HandlePaging_ProduccionConIntermediario(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_ProduccionConIntermediario = CurrentPage_ProduccionConIntermediario - 5;
            if (CurrentPage_ProduccionConIntermediario > 5)
                _UltimaPagina_ProduccionConIntermediario = CurrentPage_ProduccionConIntermediario + 5;
            else
                _UltimaPagina_ProduccionConIntermediario = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_ProduccionConIntermediario > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_ProduccionConIntermediario = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_ProduccionConIntermediario = _UltimaPagina_ProduccionConIntermediario - 10;
            }

            if (_PrimeraPagina_ProduccionConIntermediario < 0)
                _PrimeraPagina_ProduccionConIntermediario = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_ProduccionConIntermediario;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_ProduccionConIntermediario; i < _UltimaPagina_ProduccionConIntermediario; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_ProduccionConIntermediario(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_ProduccionConIntermediario.DataSource = Listado;
            pagedDataSource_ProduccionConIntermediario.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_ProduccionConIntermediario.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_ProduccionConIntermediario.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_ProduccionConIntermediario.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_ProduccionConIntermediario : _NumeroRegistros);
            pagedDataSource_ProduccionConIntermediario.CurrentPageIndex = CurrentPage_ProduccionConIntermediario;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_ProduccionConIntermediario.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_ProduccionConIntermediario.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_ProduccionConIntermediario.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_ProduccionConIntermediario.IsLastPage;

            RptGrid.DataSource = pagedDataSource_ProduccionConIntermediario;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_ProduccionConIntermediario
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_ProduccionConIntermediario(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION COBROS SIN INTERMEDIARIO
        readonly PagedDataSource pagedDataSource_CobroSinIntermedairio = new PagedDataSource();
        int _PrimeraPagina_CobroSinIntermedairio, _UltimaPagina_CobroSinIntermedairio;
        private int _TamanioPagina_CobroSinIntermedairio = 10;
        private int CurrentPage_CobroSinIntermedairio
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

        private void HandlePaging_CobroSinIntermedairio(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_CobroSinIntermedairio = CurrentPage_CobroSinIntermedairio - 5;
            if (CurrentPage_CobroSinIntermedairio > 5)
                _UltimaPagina_CobroSinIntermedairio = CurrentPage_CobroSinIntermedairio + 5;
            else
                _UltimaPagina_CobroSinIntermedairio = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_CobroSinIntermedairio > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_CobroSinIntermedairio = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_CobroSinIntermedairio = _UltimaPagina_CobroSinIntermedairio - 10;
            }

            if (_PrimeraPagina_CobroSinIntermedairio < 0)
                _PrimeraPagina_CobroSinIntermedairio = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_CobroSinIntermedairio;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_CobroSinIntermedairio; i < _UltimaPagina_CobroSinIntermedairio; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_CobroSinIntermedairio(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_CobroSinIntermedairio.DataSource = Listado;
            pagedDataSource_CobroSinIntermedairio.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_CobroSinIntermedairio.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_CobroSinIntermedairio.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_CobroSinIntermedairio.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_CobroSinIntermedairio : _NumeroRegistros);
            pagedDataSource_CobroSinIntermedairio.CurrentPageIndex = CurrentPage_CobroSinIntermedairio;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_CobroSinIntermedairio.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_CobroSinIntermedairio.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_CobroSinIntermedairio.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_CobroSinIntermedairio.IsLastPage;

            RptGrid.DataSource = pagedDataSource_CobroSinIntermedairio;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_CobroSinIntermedairio
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_CobroSinIntermedairio(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION COBROS CON INTERMEDIARIO
        readonly PagedDataSource pagedDataSource_CobroConIntermedairio = new PagedDataSource();
        int _PrimeraPagina_CobroConIntermedairio, _UltimaPagina_CobroConIntermedairio;
        private int _TamanioPagina_CobroConIntermedairio = 10;
        private int CurrentPage_CobroConIntermedairio
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

        private void HandlePaging_CobroConIntermedairio(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_CobroConIntermedairio = CurrentPage_CobroConIntermedairio - 5;
            if (CurrentPage_CobroConIntermedairio > 5)
                _UltimaPagina_CobroConIntermedairio = CurrentPage_CobroConIntermedairio + 5;
            else
                _UltimaPagina_CobroConIntermedairio = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_CobroConIntermedairio > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_CobroConIntermedairio = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_CobroConIntermedairio = _UltimaPagina_CobroConIntermedairio - 10;
            }

            if (_PrimeraPagina_CobroConIntermedairio < 0)
                _PrimeraPagina_CobroConIntermedairio = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_CobroConIntermedairio;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_CobroConIntermedairio; i < _UltimaPagina_CobroConIntermedairio; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_CobroConIntermedairio(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_CobroConIntermedairio.DataSource = Listado;
            pagedDataSource_CobroConIntermedairio.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_CobroConIntermedairio.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_CobroConIntermedairio.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_CobroConIntermedairio.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_CobroConIntermedairio : _NumeroRegistros);
            pagedDataSource_CobroConIntermedairio.CurrentPageIndex = CurrentPage_CobroConIntermedairio;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_CobroConIntermedairio.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_CobroConIntermedairio.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_CobroConIntermedairio.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_CobroConIntermedairio.IsLastPage;

            RptGrid.DataSource = pagedDataSource_CobroConIntermedairio;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_CobroConIntermedairio
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_CobroConIntermedairio(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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


        #region CARGAR LOS RAMOS
        private void CargarRamos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjData.Value.BuscaListas("RAMO", null, null), true);
        }
        #endregion
        #region CARGAR LAS OFICINAS
        private void CargarOficinas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficina, ObjData.Value.BuscaListas("OFICINANORMAL", null, null), true);
        }
        #endregion
        #region CARGAR EL LISTADO DE PRODUCCION Y COBRADO DE CONTABILIDAD
        private void CargarListado()
        {
            if (string.IsNullOrEmpty(txtAno.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CampoAnoVacio", "CampoAnoVacio();", true);
            }
            else
            {
                DateTime FechaDesde = DateTime.Now, FechaHasta= DateTime.Now, FechaDesdeAnterior= DateTime.Now, FechaHastaAnterior= DateTime.Now;
                string FechaConcatenadaDesde = "";
                string FechaConcatenadaHasta = "";
                string FechaConcatenadaDesdeAnterior = "";
                string FechaConcatenadaHastaAnterior = "";
                int MesSeleccionado = Convert.ToInt32(ddlSeleccionarMes.SelectedValue);
                //HACEMOS EL PROCESO PARA SACAR LA FECHA DESDE Y LA FECHA HASTA
                switch (MesSeleccionado)
                {
                    case 1:
                        //ENERO
                        FechaConcatenadaDesde = txtAno.Text + "-01-01";
                        FechaConcatenadaHasta = txtAno.Text + "-01-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);


                        //MES ANTERIOR
                        int MesAnterior = Convert.ToInt32(txtAno.Text);
                        MesAnterior = MesAnterior - 1;
                        FechaConcatenadaDesdeAnterior = MesAnterior.ToString() + "-12-01";
                        FechaConcatenadaHastaAnterior = MesAnterior.ToString() + "-12-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 2:
                        //FEBRERO
                        FechaConcatenadaDesde = txtAno.Text + "-02-01";
                        FechaConcatenadaHasta = txtAno.Text + "-02-29";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);


                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-01-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-01-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 3:
                        //MARZO
                        FechaConcatenadaDesde = txtAno.Text + "-03-01";
                        FechaConcatenadaHasta = txtAno.Text + "-03-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);


                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-02-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-02-29";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 4:
                        //ABRIL
                        FechaConcatenadaDesde = txtAno.Text + "-04-01";
                        FechaConcatenadaHasta = txtAno.Text + "-04-30";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);



                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-03-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-03-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 5:
                        //MAYO
                        FechaConcatenadaDesde = txtAno.Text + "-05-01";
                        FechaConcatenadaHasta = txtAno.Text + "-05-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);



                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-04-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-04-30";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 6:
                        //JUNIO
                        FechaConcatenadaDesde = txtAno.Text + "-06-01";
                        FechaConcatenadaHasta = txtAno.Text + "-06-30";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);




                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-05-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-05-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 7:
                        //JULIO
                        FechaConcatenadaDesde = txtAno.Text + "-07-01";
                        FechaConcatenadaHasta = txtAno.Text + "-07-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);




                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-06-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-06-30";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 8:
                        //AGOSTO
                        FechaConcatenadaDesde = txtAno.Text + "-08-01";
                        FechaConcatenadaHasta = txtAno.Text + "-08-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);




                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-07-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-07-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 9:
                        //SEPTIEMBRE
                        FechaConcatenadaDesde = txtAno.Text + "-09-01";
                        FechaConcatenadaHasta = txtAno.Text + "-09-30";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);



                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-08-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-08-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 10:
                        //OCTUBRE
                        FechaConcatenadaDesde = txtAno.Text + "-10-01";
                        FechaConcatenadaHasta = txtAno.Text + "-10-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);



                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-09-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-09-30";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 11:
                        //NOVIEMBRE
                        FechaConcatenadaDesde = txtAno.Text + "-11-01";
                        FechaConcatenadaHasta = txtAno.Text + "-11-30";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);




                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-10-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-10-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 12:
                        //DICIEMBRE
                        FechaConcatenadaDesde = txtAno.Text + "-12-01";
                        FechaConcatenadaHasta = txtAno.Text + "-12-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);



                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-11-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-11-30";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;
                }
                //VERIFICAMOS EL TIPO DE REPORTE QUE SE VA A USAR
                //REPORTE DE PRODUCCION
                if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == (int)TipoDeReporte.Produccion)
                {
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();

                    //VERIFICAMOS SI LA CONSULTA LLEVA INTERMEDARIOS
                    //EN CASO DE QUE NO LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == (int)LlevaIntermediarios.SinIntermediario)
                    {
                        var CargarListado = ObjData.Value.SacarProduccionDiariaContabilidad(
                            FechaDesde,
                            FechaHasta,
                            FechaDesdeAnterior,
                            FechaHastaAnterior,
                            _Ramo,
                            _Oficina,
                            null,
                            null,
                            _LlevaIntermediario);
                        foreach (var n in CargarListado)
                        {
                            decimal FacturadoHoy = Convert.ToDecimal(n.Hoy);
                            lbFacturadoHoy_ProduccionSinIntermediario.Text = FacturadoHoy.ToString("N2");

                            decimal FacturadoDebitos = Convert.ToDecimal(n.TotalDebito);
                            lbCantidadDebitos_ProduccionSinIntermediario.Text = FacturadoDebitos.ToString("N2");

                            decimal FacturadoCredito = Convert.ToDecimal(n.TotalCredito);
                            lbCantidadCreditos_ProduccionSinIntermediario.Text = FacturadoCredito.ToString("N2");

                            decimal FacturadoOtros = Convert.ToDecimal(n.TotalOtros);
                            lbOtros_ProduccionSinIntermediario.Text = FacturadoOtros.ToString("N2");

                            decimal FacturadoTotal = Convert.ToDecimal(n.Total);
                            lbTotal_ProduccionSinIntermediario.Text = FacturadoTotal.ToString("N2");

                            decimal FacturadoMesAnterior = Convert.ToDecimal(n.MesAnterior);
                            lbTotalMesAnterior_ProduccionSinIntermediario.Text = FacturadoMesAnterior.ToString("N2");

                        }
                        Paginar_ProduccionSinIntermediario(ref rpProduccionSinIntermediario, CargarListado, 10, ref lbCantidadPagina_ProduccionSinIntermediario, ref btnPrimeraPagina_ProduccionSinIntermediario, ref btnPaginaAnterior_ProduccionSinIntermediario, ref btnSiguientePagina_ProduccionSinIntermediario, ref btnUltimaPagina_ProduccionSinIntermediario);
                        HandlePaging_ProduccionSinIntermediario(ref dtPaginacion_ProduccionSinIntermediario, ref lbPaginaActual_ProduccionSinIntermediario);

                    }
                    //EN CASO DE QUE LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == (int)LlevaIntermediarios.ConIntermediario)
                    {
                        //VALIDAMOS SI SE VAN A FILTRAR TODOS LOS INTERMEDIARIOS O SOLO 1
                        //VALIDAMOS TODOS LOS INTERMEDIAIOS
                        if (cbTodosLosIntermediarios.Checked)
                        {
                            var CargarListado = ObjData.Value.SacarProduccionDiariaContabilidad(
                        FechaDesde,
                        FechaHasta,
                        FechaDesdeAnterior,
                        FechaHastaAnterior,
                        _Ramo,
                        _Oficina,
                        null,
                        null,
                        _LlevaIntermediario);
                            foreach (var n in CargarListado)
                            {
                                decimal FacturadoHoy = Convert.ToDecimal(n.Hoy);
                                lbFacturadoHoy_ProduccionConIntermediario.Text = FacturadoHoy.ToString("N2");

                                decimal FacturadoDebitos = Convert.ToDecimal(n.TotalDebito);
                                lbCantidadDebitos_ProduccionConIntermediario.Text = FacturadoDebitos.ToString("N2");

                                decimal FacturadoCredito = Convert.ToDecimal(n.TotalCredito);
                                lbCantidadCreditos_ProduccionConIntermediario.Text = FacturadoCredito.ToString("N2");

                                decimal FacturadoOtros = Convert.ToDecimal(n.TotalOtros);
                                lbOtros_ProduccionConIntermediario.Text = FacturadoOtros.ToString("N2");

                                decimal FacturadoTotal = Convert.ToDecimal(n.Total);
                                lbTotal_ProduccionConIntermediario.Text = FacturadoTotal.ToString("N2");

                                decimal FacturadoMesAnterior = Convert.ToDecimal(n.MesAnterior);
                                lbTotalMesAnterior_ProduccionConIntermediario.Text = FacturadoMesAnterior.ToString("N2");

                            }
                            Paginar_ProduccionConIntermediario(ref rpProduccionConIntermediario, CargarListado, 10, ref lbCantidadPagina_ProduccionConIntermediario, ref btnPrimeraPagina_ProduccionConIntermediario, ref btnPaginaAnterior_ProduccionConIntermediario, ref btnSiguientePagina_ProduccionConIntermediario, ref btnUltimaPagina_ProduccionConIntermediario);
                            HandlePaging_ProduccionConIntermediario(ref dtPaginacion_ProduccionConIntermediario, ref lbPaginaActual_ProduccionConIntermediario);
                        }
                        //VALIDAMOS UN INTERMEDIARIO EN ESPESIFICO
                        else
                        {
                            if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "CampoCodogoIntermediarioVacio", "CampoCodogoIntermediarioVacio()", true);
                            }
                            else
                            {
                                var CargarListado = ObjData.Value.SacarProduccionDiariaContabilidad(
                           FechaDesde,
                           FechaHasta,
                           FechaDesdeAnterior,
                           FechaHastaAnterior,
                           _Ramo,
                           _Oficina,
                           null,
                           _CodigoIntermediario,
                           _LlevaIntermediario);
                                foreach (var n in CargarListado)
                                {
                                    decimal FacturadoHoy = Convert.ToDecimal(n.Hoy);
                                    lbFacturadoHoy_ProduccionConIntermediario.Text = FacturadoHoy.ToString("N2");

                                    decimal FacturadoDebitos = Convert.ToDecimal(n.TotalDebito);
                                    lbCantidadDebitos_ProduccionConIntermediario.Text = FacturadoDebitos.ToString("N2");

                                    decimal FacturadoCredito = Convert.ToDecimal(n.TotalCredito);
                                    lbCantidadCreditos_ProduccionConIntermediario.Text = FacturadoCredito.ToString("N2");

                                    decimal FacturadoOtros = Convert.ToDecimal(n.TotalOtros);
                                    lbOtros_ProduccionConIntermediario.Text = FacturadoOtros.ToString("N2");

                                    decimal FacturadoTotal = Convert.ToDecimal(n.Total);
                                    lbTotal_ProduccionConIntermediario.Text = FacturadoTotal.ToString("N2");

                                    decimal FacturadoMesAnterior = Convert.ToDecimal(n.MesAnterior);
                                    lbTotalMesAnterior_ProduccionConIntermediario.Text = FacturadoMesAnterior.ToString("N2");

                                }
                                Paginar_ProduccionConIntermediario(ref rpProduccionConIntermediario, CargarListado, 10, ref lbCantidadPagina_ProduccionConIntermediario, ref btnPrimeraPagina_ProduccionConIntermediario, ref btnPaginaAnterior_ProduccionConIntermediario, ref btnSiguientePagina_ProduccionConIntermediario, ref btnUltimaPagina_ProduccionConIntermediario);
                                HandlePaging_ProduccionConIntermediario(ref dtPaginacion_ProduccionConIntermediario, ref lbPaginaActual_ProduccionConIntermediario);
                            }
                        }

                    }
                }

                //REPORTE DE COBROS
                if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == (int)TipoDeReporte.Cobros)
                {
                    //VERIFICAMOS SI LA CONSULTA LLEVA INTERMEDARIOS
                    //EN CASO DE QUE NO LLEVE INTERMEDIARIO
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                    {
                        var MostrarListado = ObjData.Value.ReporteCobradoCOntabilidad(
                            FechaDesde,
                            FechaHasta,
                            FechaDesdeAnterior,
                            FechaHastaAnterior,
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario,
                            null);
                        foreach (var n in MostrarListado)
                        {
                            decimal CobradoSantoDomingo = 0, CobradoSantiago = 0, CobradoOtros = 0, TotalCobrado = 0, CobredoMesAnterior = 0, CobradoHoy = 0;

                            CobradoSantoDomingo = Convert.ToDecimal(n.CobradoSantoDomingo);
                            CobradoSantiago = Convert.ToDecimal(n.CobradoSantiago);
                            CobradoOtros = Convert.ToDecimal(n.CobradoOtros);
                            TotalCobrado = Convert.ToDecimal(n.Total);
                            CobredoMesAnterior = Convert.ToDecimal(n.CobradoMesAnterior);
                            CobradoHoy = Convert.ToDecimal(n.CobradoHoy);


                            lbCobradoSantoDomingo_CobradoSinIntermediario.Text = CobradoSantoDomingo.ToString("N2");
                            lbCobradoSantiago_CobradoSinIntermediario.Text = CobradoSantiago.ToString("N2");
                            lbCobradoOtros_CobradoSinIntermediario.Text = CobradoOtros.ToString("N2");
                            lbTotalCobrado_CobradoSinIntermediario.Text = TotalCobrado.ToString("N2");
                            lbCobradoHoy_CobradoSinIntermediario.Text = CobradoHoy.ToString("N2");
                            lbCobradoMesAnterior_CobradoSinIntermediario.Text = CobredoMesAnterior.ToString("N2");
                        }
                        Paginar_CobroSinIntermedairio(ref rpCobradoSinIntermediario, MostrarListado, 10, ref lbCantidadPagina_CobradoSinIntermediario, ref btnPrimeraPagina_CobradoSinIntermediario, ref btnPaginaAnterior_CobradoSinIntermediario, ref btnSiguientePagina_CobradoSinIntermediario, ref btnUltimaPagina_CobradoSinIntermediario);
                        HandlePaging_CobroSinIntermedairio(ref dtPaginacion_CobradoSinIntermediario, ref lbPaginaActual_CobradoSinIntermediario);
                    }
                    //EN CASO DE QUE LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
                    {
                        //VALIDAMOS SI SE VAN A FILTRAR TODOS LOS INTERMEDIARIOS O SOLO 1
                        //VALIDAMOS TODOS LOS INTERMEDIAIOS
                        if (cbTodosLosIntermediarios.Checked)
                        {
                            var MostrarListado = ObjData.Value.ReporteCobradoCOntabilidad(
                            FechaDesde,
                            FechaHasta,
                            FechaDesdeAnterior,
                            FechaHastaAnterior,
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario);
                            foreach (var n in MostrarListado)
                            {
                                decimal CobradoSantoDomingo = 0, CobradoSantiago = 0, CobradoOtros = 0, TotalCobrado = 0, CobredoMesAnterior = 0, CobradoHoy = 0;

                                CobradoSantoDomingo = Convert.ToDecimal(n.CobradoSantoDomingo);
                                CobradoSantiago = Convert.ToDecimal(n.CobradoSantiago);
                                CobradoOtros = Convert.ToDecimal(n.CobradoOtros);
                                TotalCobrado = Convert.ToDecimal(n.Total);
                                CobredoMesAnterior = Convert.ToDecimal(n.CobradoMesAnterior);
                                CobradoHoy = Convert.ToDecimal(n.CobradoHoy);


                                lbCobradoSantoDomingo_CobradoConIntermediario.Text = CobradoSantoDomingo.ToString("N2");
                                lbCobradoSantiago_CobradoConIntermediario.Text = CobradoSantiago.ToString("N2");
                                lbCobradoOtros_CobradoConIntermediario.Text = CobradoOtros.ToString("N2");
                                lbTotalCobrado_CobradoConIntermediario.Text = TotalCobrado.ToString("N2");
                                lbCobradoHoy_CobradoConIntermediario.Text = CobradoHoy.ToString("N2");
                                lbCobradoMesAnterior_CobradoConIntermediario.Text = CobredoMesAnterior.ToString("N2");
                            }
                            Paginar_CobroConIntermedairio(ref rpCobradoConIntermediario, MostrarListado, 10, ref lbCantidadPagina_CobradoConIntermediario, ref btnPrimeraPagina_CobradoConIntermediario, ref btnPaginaAnterior_CobradoConIntermediario, ref btnSiguientePagina_CobradoConIntermediario, ref btnUltimaPagina_CobradoConIntermediario);
                            HandlePaging_CobroConIntermedairio(ref dtPaginacion_CobradoConIntermediario, ref lbPaginaActual_CobradoConIntermediario);
                        }
                        //VALIDAMOS UN INTERMEDIARIO EN ESPESIFICO
                        else
                        {
                            if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "CampoCodogoIntermediarioVacio", "CampoCodogoIntermediarioVacio();", true);
                            }
                            else
                            {
                                var MostrarListado = ObjData.Value.ReporteCobradoCOntabilidad(
                            FechaDesde,
                            FechaHasta,
                            FechaDesdeAnterior,
                            FechaHastaAnterior,
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario,
                            _CodigoIntermediario);
                                foreach (var n in MostrarListado)
                                {
                                    decimal CobradoSantoDomingo = 0, CobradoSantiago = 0, CobradoOtros = 0, TotalCobrado = 0, CobredoMesAnterior = 0, CobradoHoy = 0;

                                    CobradoSantoDomingo = Convert.ToDecimal(n.CobradoSantoDomingo);
                                    CobradoSantiago = Convert.ToDecimal(n.CobradoSantiago);
                                    CobradoOtros = Convert.ToDecimal(n.CobradoOtros);
                                    TotalCobrado = Convert.ToDecimal(n.Total);
                                    CobredoMesAnterior = Convert.ToDecimal(n.CobradoMesAnterior);
                                    CobradoHoy = Convert.ToDecimal(n.CobradoHoy);


                                    lbCobradoSantoDomingo_CobradoConIntermediario.Text = CobradoSantoDomingo.ToString("N2");
                                    lbCobradoSantiago_CobradoConIntermediario.Text = CobradoSantiago.ToString("N2");
                                    lbCobradoOtros_CobradoConIntermediario.Text = CobradoOtros.ToString("N2");
                                    lbTotalCobrado_CobradoConIntermediario.Text = TotalCobrado.ToString("N2");
                                    lbCobradoHoy_CobradoConIntermediario.Text = CobradoHoy.ToString("N2");
                                    lbCobradoMesAnterior_CobradoConIntermediario.Text = CobredoMesAnterior.ToString("N2");
                                }
                                Paginar_CobroConIntermedairio(ref rpCobradoConIntermediario, MostrarListado, 10, ref lbCantidadPagina_CobradoConIntermediario, ref btnPrimeraPagina_CobradoConIntermediario, ref btnPaginaAnterior_CobradoConIntermediario, ref btnSiguientePagina_CobradoConIntermediario, ref btnUltimaPagina_CobradoConIntermediario);
                                HandlePaging_CobroConIntermedairio(ref dtPaginacion_CobradoConIntermediario, ref lbPaginaActual_CobradoConIntermediario);
                            }
                        }

                    }
                }
            }
          

        }
        #endregion
        #region CARGAR LISTADO EN MODO COMPARATIVO
        private void CargarListadoModoCOmparativo()
        {
            try {
                if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 1)
                {
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();

                    //VERIFICAMOS SI LA CONSULTA LLEVA INTERMEDARIOS

                    //EN CASO DE QUE NO LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                    {
                        var CargarListado = ObjData.Value.SacarProduccionDiariaContabilidad(
                            Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                            _Ramo,
                            _Oficina,
                            null,
                            null,
                            _LlevaIntermediario);
                        foreach (var n in CargarListado)
                        {
                            decimal FacturadoHoy = Convert.ToDecimal(n.Hoy);
                            lbFacturadoHoy_ProduccionSinIntermediario.Text = FacturadoHoy.ToString("N2");

                            decimal FacturadoDebitos = Convert.ToDecimal(n.TotalDebito);
                            lbCantidadDebitos_ProduccionSinIntermediario.Text = FacturadoDebitos.ToString("N2");

                            decimal FacturadoCredito = Convert.ToDecimal(n.TotalCredito);
                            lbCantidadCreditos_ProduccionSinIntermediario.Text = FacturadoCredito.ToString("N2");

                            decimal FacturadoOtros = Convert.ToDecimal(n.TotalOtros);
                            lbOtros_ProduccionSinIntermediario.Text = FacturadoOtros.ToString("N2");

                            decimal FacturadoTotal = Convert.ToDecimal(n.Total);
                            lbTotal_ProduccionSinIntermediario.Text = FacturadoTotal.ToString("N2");

                            decimal FacturadoMesAnterior = Convert.ToDecimal(n.MesAnterior);
                            lbTotalMesAnterior_ProduccionSinIntermediario.Text = FacturadoMesAnterior.ToString("N2");

                        }
                        Paginar_ProduccionSinIntermediario(ref rpProduccionSinIntermediario, CargarListado, 10, ref lbCantidadPagina_ProduccionSinIntermediario, ref btnPrimeraPagina_ProduccionSinIntermediario, ref btnPaginaAnterior_ProduccionSinIntermediario, ref btnSiguientePagina_ProduccionSinIntermediario, ref btnUltimaPagina_ProduccionSinIntermediario);
                        HandlePaging_ProduccionSinIntermediario(ref dtPaginacion_ProduccionSinIntermediario, ref lbPaginaActual_ProduccionSinIntermediario);

                    }
                    //EN CASO DE QUE LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
                    {
                        //VALIDAMOS SI SE VAN A FILTRAR TODOS LOS INTERMEDIARIOS O SOLO 1
                        //VALIDAMOS TODOS LOS INTERMEDIAIOS
                        if (cbTodosLosIntermediarios.Checked)
                        {
                            var CargarListado = ObjData.Value.SacarProduccionDiariaContabilidad(
                         Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                        _Ramo,
                        _Oficina,
                        null,
                        null,
                        _LlevaIntermediario);
                            foreach (var n in CargarListado)
                            {
                                decimal FacturadoHoy = Convert.ToDecimal(n.Hoy);
                                lbFacturadoHoy_ProduccionConIntermediario.Text = FacturadoHoy.ToString("N2");

                                decimal FacturadoDebitos = Convert.ToDecimal(n.TotalDebito);
                                lbCantidadDebitos_ProduccionConIntermediario.Text = FacturadoDebitos.ToString("N2");

                                decimal FacturadoCredito = Convert.ToDecimal(n.TotalCredito);
                                lbCantidadCreditos_ProduccionConIntermediario.Text = FacturadoCredito.ToString("N2");

                                decimal FacturadoOtros = Convert.ToDecimal(n.TotalOtros);
                                lbOtros_ProduccionConIntermediario.Text = FacturadoOtros.ToString("N2");

                                decimal FacturadoTotal = Convert.ToDecimal(n.Total);
                                lbTotal_ProduccionConIntermediario.Text = FacturadoTotal.ToString("N2");

                                decimal FacturadoMesAnterior = Convert.ToDecimal(n.MesAnterior);
                                lbTotalMesAnterior_ProduccionConIntermediario.Text = FacturadoMesAnterior.ToString("N2");

                            }
                            Paginar_ProduccionConIntermediario(ref rpProduccionConIntermediario, CargarListado, 10, ref lbCantidadPagina_ProduccionConIntermediario, ref btnPrimeraPagina_ProduccionConIntermediario, ref btnPaginaAnterior_ProduccionConIntermediario, ref btnSiguientePagina_ProduccionConIntermediario, ref btnUltimaPagina_ProduccionConIntermediario);
                            HandlePaging_ProduccionConIntermediario(ref dtPaginacion_ProduccionConIntermediario, ref lbPaginaActual_ProduccionConIntermediario);
                        }
                        //VALIDAMOS UN INTERMEDIARIO EN ESPESIFICO
                        else
                        {
                            if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "CampoCodogoIntermediarioVacio", "CampoCodogoIntermediarioVacio()", true);
                            }
                            else
                            {
                                var CargarListado = ObjData.Value.SacarProduccionDiariaContabilidad(
                        Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                           _Ramo,
                           _Oficina,
                           null,
                           _CodigoIntermediario,
                           _LlevaIntermediario);
                                foreach (var n in CargarListado)
                                {
                                    decimal FacturadoHoy = Convert.ToDecimal(n.Hoy);
                                    lbFacturadoHoy_ProduccionConIntermediario.Text = FacturadoHoy.ToString("N2");

                                    decimal FacturadoDebitos = Convert.ToDecimal(n.TotalDebito);
                                    lbCantidadDebitos_ProduccionConIntermediario.Text = FacturadoDebitos.ToString("N2");

                                    decimal FacturadoCredito = Convert.ToDecimal(n.TotalCredito);
                                    lbCantidadCreditos_ProduccionConIntermediario.Text = FacturadoCredito.ToString("N2");

                                    decimal FacturadoOtros = Convert.ToDecimal(n.TotalOtros);
                                    lbOtros_ProduccionConIntermediario.Text = FacturadoOtros.ToString("N2");

                                    decimal FacturadoTotal = Convert.ToDecimal(n.Total);
                                    lbTotal_ProduccionConIntermediario.Text = FacturadoTotal.ToString("N2");

                                    decimal FacturadoMesAnterior = Convert.ToDecimal(n.MesAnterior);
                                    lbTotalMesAnterior_ProduccionConIntermediario.Text = FacturadoMesAnterior.ToString("N2");

                                }
                                Paginar_ProduccionConIntermediario(ref rpProduccionConIntermediario, CargarListado, 10, ref lbCantidadPagina_ProduccionConIntermediario, ref btnPrimeraPagina_ProduccionConIntermediario, ref btnPaginaAnterior_ProduccionConIntermediario, ref btnSiguientePagina_ProduccionConIntermediario, ref btnUltimaPagina_ProduccionConIntermediario);
                                HandlePaging_ProduccionConIntermediario(ref dtPaginacion_ProduccionConIntermediario, ref lbPaginaActual_ProduccionConIntermediario);
                            }
                        }

                    }
                }

                //REPORTE DE COBROS
                if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 2)
                {
                    //VERIFICAMOS SI LA CONSULTA LLEVA INTERMEDARIOS
                    //EN CASO DE QUE NO LLEVE INTERMEDIARIO
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                    {
                        var MostrarListado = ObjData.Value.ReporteCobradoCOntabilidad(
                            Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario,
                            null);
                        foreach (var n in MostrarListado)
                        {
                            decimal CobradoSantoDomingo = 0, CobradoSantiago = 0, CobradoOtros = 0, TotalCobrado = 0, CobredoMesAnterior = 0, CobradoHoy = 0;

                            CobradoSantoDomingo = Convert.ToDecimal(n.CobradoSantoDomingo);
                            CobradoSantiago = Convert.ToDecimal(n.CobradoSantiago);
                            CobradoOtros = Convert.ToDecimal(n.CobradoOtros);
                            TotalCobrado = Convert.ToDecimal(n.Total);
                            CobredoMesAnterior = Convert.ToDecimal(n.CobradoMesAnterior);
                            CobradoHoy = Convert.ToDecimal(n.CobradoHoy);




                            lbCobradoSantoDomingo_CobradoSinIntermediario.Text = CobradoSantoDomingo.ToString("N2");
                            lbCobradoSantiago_CobradoSinIntermediario.Text = CobradoSantiago.ToString("N2");
                            lbCobradoOtros_CobradoSinIntermediario.Text = CobradoOtros.ToString("N2");
                            lbTotalCobrado_CobradoSinIntermediario.Text = TotalCobrado.ToString("N2");
                            lbCobradoHoy_CobradoSinIntermediario.Text = CobradoHoy.ToString("N2");
                            lbCobradoMesAnterior_CobradoSinIntermediario.Text = CobredoMesAnterior.ToString("N2");
                        }
                        Paginar_CobroSinIntermedairio(ref rpCobradoSinIntermediario, MostrarListado, 10, ref lbCantidadPagina_CobradoSinIntermediario, ref btnPrimeraPagina_CobradoSinIntermediario, ref btnPaginaAnterior_CobradoSinIntermediario, ref btnSiguientePagina_CobradoSinIntermediario, ref btnUltimaPagina_CobradoSinIntermediario);
                        HandlePaging_CobroSinIntermedairio(ref dtPaginacion_CobradoSinIntermediario, ref lbPaginaActual_CobradoSinIntermediario);
                    }
                    //EN CASO DE QUE LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
                    {
                        //VALIDAMOS SI SE VAN A FILTRAR TODOS LOS INTERMEDIARIOS O SOLO 1
                        //VALIDAMOS TODOS LOS INTERMEDIAIOS
                        if (cbTodosLosIntermediarios.Checked)
                        {
                            var MostrarListado = ObjData.Value.ReporteCobradoCOntabilidad(
                            Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario);
                            foreach (var n in MostrarListado)
                            {
                                decimal CobradoSantoDomingo = 0, CobradoSantiago = 0, CobradoOtros = 0, TotalCobrado = 0, CobredoMesAnterior = 0, CobradoHoy = 0;

                                CobradoSantoDomingo = Convert.ToDecimal(n.CobradoSantoDomingo);
                                CobradoSantiago = Convert.ToDecimal(n.CobradoSantiago);
                                CobradoOtros = Convert.ToDecimal(n.CobradoOtros);
                                TotalCobrado = Convert.ToDecimal(n.Total);
                                CobredoMesAnterior = Convert.ToDecimal(n.CobradoMesAnterior);
                                CobradoHoy = Convert.ToDecimal(n.CobradoHoy);


                                lbCobradoSantoDomingo_CobradoConIntermediario.Text = CobradoSantoDomingo.ToString("N2");
                                lbCobradoSantiago_CobradoConIntermediario.Text = CobradoSantiago.ToString("N2");
                                lbCobradoOtros_CobradoConIntermediario.Text = CobradoOtros.ToString("N2");
                                lbTotalCobrado_CobradoConIntermediario.Text = TotalCobrado.ToString("N2");
                                lbCobradoHoy_CobradoConIntermediario.Text = CobradoHoy.ToString("N2");
                                lbCobradoMesAnterior_CobradoConIntermediario.Text = CobredoMesAnterior.ToString("N2");
                            }
                            Paginar_CobroConIntermedairio(ref rpCobradoConIntermediario, MostrarListado, 10, ref lbCantidadPagina_CobradoConIntermediario, ref btnPrimeraPagina_CobradoConIntermediario, ref btnPaginaAnterior_CobradoConIntermediario, ref btnSiguientePagina_CobradoConIntermediario, ref btnUltimaPagina_CobradoConIntermediario);
                            HandlePaging_CobroConIntermedairio(ref dtPaginacion_CobradoConIntermediario, ref lbPaginaActual_CobradoConIntermediario);
                        }
                        //VALIDAMOS UN INTERMEDIARIO EN ESPESIFICO
                        else
                        {
                            if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "CampoCodogoIntermediarioVacio", "CampoCodogoIntermediarioVacio();", true);
                            }
                            else
                            {
                                var MostrarListado = ObjData.Value.ReporteCobradoCOntabilidad(
                         Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario,
                            _CodigoIntermediario);
                                foreach (var n in MostrarListado)
                                {
                                    decimal CobradoSantoDomingo = 0, CobradoSantiago = 0, CobradoOtros = 0, TotalCobrado = 0, CobredoMesAnterior = 0, CobradoHoy = 0;

                                    CobradoSantoDomingo = Convert.ToDecimal(n.CobradoSantoDomingo);
                                    CobradoSantiago = Convert.ToDecimal(n.CobradoSantiago);
                                    CobradoOtros = Convert.ToDecimal(n.CobradoOtros);
                                    TotalCobrado = Convert.ToDecimal(n.Total);
                                    CobredoMesAnterior = Convert.ToDecimal(n.CobradoMesAnterior);
                                    CobradoHoy = Convert.ToDecimal(n.CobradoHoy);


                                    lbCobradoSantoDomingo_CobradoConIntermediario.Text = CobradoSantoDomingo.ToString("N2");
                                    lbCobradoSantiago_CobradoConIntermediario.Text = CobradoSantiago.ToString("N2");
                                    lbCobradoOtros_CobradoConIntermediario.Text = CobradoOtros.ToString("N2");
                                    lbTotalCobrado_CobradoConIntermediario.Text = TotalCobrado.ToString("N2");
                                    lbCobradoHoy_CobradoConIntermediario.Text = CobradoHoy.ToString("N2");
                                    lbCobradoMesAnterior_CobradoConIntermediario.Text = CobredoMesAnterior.ToString("N2");
                                }
                                Paginar_CobroConIntermedairio(ref rpCobradoConIntermediario, MostrarListado, 10, ref lbCantidadPagina_CobradoConIntermediario, ref btnPrimeraPagina_CobradoConIntermediario, ref btnPaginaAnterior_CobradoConIntermediario, ref btnSiguientePagina_CobradoConIntermediario, ref btnUltimaPagina_CobradoConIntermediario);
                                HandlePaging_CobroConIntermedairio(ref dtPaginacion_CobradoConIntermediario, ref lbPaginaActual_CobradoConIntermediario);
                            }
                        }

                    }
                }
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
            }
        }
        #endregion
        #region CARGAR LOS MESES
        private void CargarMeses()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMes, ObjData.Value.BuscaListas("MESES", null, null));
        }
        #endregion
        #region EXPORTAR LA DATA A EXEL
        private void ExportarDataExel()
        {
            //VALIDAMOS EL CAMPO Año
            if (string.IsNullOrEmpty(txtAno.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CampoAnoVacio", "CampoAnoVacio()", true);
            }
            else
            {
                //REALIZAMOS EL PROCESOS DE LOS MESES
                DateTime FechaDesde = DateTime.Now, FechaHasta = DateTime.Now, FechaDesdeAnterior = DateTime.Now, FechaHastaAnterior = DateTime.Now;
                string FechaConcatenadaDesde = "";
                string FechaConcatenadaHasta = "";
                string FechaConcatenadaDesdeAnterior = "";
                string FechaConcatenadaHastaAnterior = "";
                int MesSeleccionado = Convert.ToInt32(ddlSeleccionarMes.SelectedValue);
                //HACEMOS EL PROCESO PARA SACAR LA FECHA DESDE Y LA FECHA HASTA
                switch (MesSeleccionado)
                {
                    case 1:
                        //ENERO
                        FechaConcatenadaDesde = txtAno.Text + "-01-01";
                        FechaConcatenadaHasta = txtAno.Text + "-01-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);


                        //MES ANTERIOR
                        int MesAnterior = Convert.ToInt32(txtAno.Text);
                        MesAnterior = MesAnterior - 1;
                        FechaConcatenadaDesdeAnterior = MesAnterior.ToString() + "-12-01";
                        FechaConcatenadaHastaAnterior = MesAnterior.ToString() + "-12-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 2:
                        //FEBRERO
                        FechaConcatenadaDesde = txtAno.Text + "-02-01";
                        FechaConcatenadaHasta = txtAno.Text + "-02-29";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);


                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-01-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-01-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 3:
                        //MARZO
                        FechaConcatenadaDesde = txtAno.Text + "-03-01";
                        FechaConcatenadaHasta = txtAno.Text + "-03-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);


                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-02-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-02-29";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 4:
                        //ABRIL
                        FechaConcatenadaDesde = txtAno.Text + "-04-01";
                        FechaConcatenadaHasta = txtAno.Text + "-04-30";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);



                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-03-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-03-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 5:
                        //MAYO
                        FechaConcatenadaDesde = txtAno.Text + "-05-01";
                        FechaConcatenadaHasta = txtAno.Text + "-05-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);



                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-04-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-04-30";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 6:
                        //JUNIO
                        FechaConcatenadaDesde = txtAno.Text + "-06-01";
                        FechaConcatenadaHasta = txtAno.Text + "-06-30";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);




                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-05-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-05-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 7:
                        //JULIO
                        FechaConcatenadaDesde = txtAno.Text + "-07-01";
                        FechaConcatenadaHasta = txtAno.Text + "-07-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);




                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-06-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-06-30";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 8:
                        //AGOSTO
                        FechaConcatenadaDesde = txtAno.Text + "-08-01";
                        FechaConcatenadaHasta = txtAno.Text + "-08-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);




                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-07-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-07-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 9:
                        //SEPTIEMBRE
                        FechaConcatenadaDesde = txtAno.Text + "-09-01";
                        FechaConcatenadaHasta = txtAno.Text + "-09-30";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);



                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-08-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-08-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 10:
                        //OCTUBRE
                        FechaConcatenadaDesde = txtAno.Text + "-10-01";
                        FechaConcatenadaHasta = txtAno.Text + "-10-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);



                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-09-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-09-30";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 11:
                        //NOVIEMBRE
                        FechaConcatenadaDesde = txtAno.Text + "-11-01";
                        FechaConcatenadaHasta = txtAno.Text + "-11-30";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);




                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-10-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-10-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 12:
                        //DICIEMBRE
                        FechaConcatenadaDesde = txtAno.Text + "-12-01";
                        FechaConcatenadaHasta = txtAno.Text + "-12-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);



                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-11-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-11-30";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;
                }

                //VERIFICAMOS EL TIPO DE REPORTE SELECCIONAD
                //SI EL REPORTE A EXPORTAR ES PRODUCCION
                if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 1)
                {
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
                    //VERIFICAMOS SI LA CONSULTA LLEVA INTERMEDARIOS
                    //EN CASO DE QUE NO LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                    {
                        var Exportar = (from n in ObjData.Value.SacarProduccionDiariaContabilidad(
                            FechaDesde,
                            FechaHasta,
                            FechaDesdeAnterior,
                            FechaHastaAnterior,
                            _Ramo,
                            _Oficina,
                            null,
                            null,
                            _LlevaIntermediario)
                                        select new {
                                            Ramo = n.Ramo,
                                            Descripcion = n.Descripcion,
                                            Tipo = n.Tipo,
                                            DescripcionTipo = n.DescripcionTipo,
                                            CodOficina = n.CodOficina,
                                            Oficina = n.Oficina,
                                            Concepto = n.Concepto,
                                            FacturadoMes = n.FacturadoMes,
                                            Total = n.Total,
                                            MesAnterior = n.MesAnterior,
                                            Hoy = n.Hoy,
                                            TotalCredito = n.TotalCredito,
                                            TotalDebito = n.TotalDebito,
                                            TotalOtros = n.TotalOtros
                                        }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción Sin Intermediario", Exportar);
                            
                    }
                    //EN CASO DE QUE LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
                    {
                        //VALIDAMOS SI SE VAN A FILTRAR TODOS LOS INTERMEDIARIOS O SOLO 1
                        //VALIDAMOS TODOS LOS INTERMEDIAIOS
                        if (cbTodosLosIntermediarios.Checked)
                        {
                            var Exportar = (from n in ObjData.Value.SacarProduccionDiariaContabilidad(
                           FechaDesde,
                           FechaHasta,
                           FechaDesdeAnterior,
                           FechaHastaAnterior,
                           _Ramo,
                           _Oficina,
                           null,
                           null,
                           _LlevaIntermediario)
                                            select new
                                            {
                                                Intermediario = n.Intermediario,
                                                Codigo = n.Codigo,
                                                Ramo = n.Ramo,
                                                Descripcion = n.Descripcion,
                                                Tipo = n.Tipo,
                                                DescripcionTipo = n.DescripcionTipo,
                                                CodOficina = n.CodOficina,
                                                Oficina = n.Oficina,
                                                Concepto = n.Concepto,
                                                FacturadoMes = n.FacturadoMes,
                                                Total = n.Total,
                                                MesAnterior = n.MesAnterior,
                                                Hoy = n.Hoy,
                                                TotalCredito = n.TotalCredito,
                                                TotalDebito = n.TotalDebito,
                                                TotalOtros = n.TotalOtros
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción Todos los  Intermediario", Exportar);
                        }
                        //VALIDAMOS UN INTERMEDIARIO EN ESPESIFICO
                        else
                        {
                            var Exportar = (from n in ObjData.Value.SacarProduccionDiariaContabilidad(
                           FechaDesde,
                           FechaHasta,
                           FechaDesdeAnterior,
                           FechaHastaAnterior,
                           _Ramo,
                           _Oficina,
                           null,
                           _CodigoIntermediario,
                           _LlevaIntermediario)
                                            select new
                                            {
                                                Intermediario = n.Intermediario,
                                                Codigo = n.Codigo,
                                                Ramo = n.Ramo,
                                                Descripcion = n.Descripcion,
                                                Tipo = n.Tipo,
                                                DescripcionTipo = n.DescripcionTipo,
                                                CodOficina = n.CodOficina,
                                                Oficina = n.Oficina,
                                                Concepto = n.Concepto,
                                                FacturadoMes = n.FacturadoMes,
                                                Total = n.Total,
                                                MesAnterior = n.MesAnterior,
                                                Hoy = n.Hoy,
                                                TotalCredito = n.TotalCredito,
                                                TotalDebito = n.TotalDebito,
                                                TotalOtros = n.TotalOtros
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción Intermediario Espesifico", Exportar); 
                        }

                    }

                }
                //SI EL REPORTE A EXPORTAR ES DE LO COBRADO
                else if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 2)
                {
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
                    //VERIFICAMOS SI LA CONSULTA LLEVA INTERMEDARIOS
                    //EN CASO DE QUE NO LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                    {
                        var Exportar = (from n in ObjData.Value.ReporteCobradoCOntabilidad(
                            FechaDesde,
                            FechaHasta,
                            FechaDesdeAnterior,
                            FechaHastaAnterior,
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario,
                            null)
                                        select new
                                        {
                                            CodRamo = n.CodRamo,
                                            Ramo = n.Ramo,
                                            CodOficina = n.CodOficina,
                                            Oficina = n.Oficina,
                                            Cobrado = n.Cobrado,
                                            CobradoHoy = n.CobradoHoy,
                                            CobradoSantoDomingo = n.CobradoSantoDomingo,
                                            CobradoSantiago = n.CobradoSantiago,
                                            CobradoOtros = n.CobradoOtros,
                                            Total = n.Total,
                                            CobradoMesAnterior = n.CobradoMesAnterior
                                        }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cobrado Sin Intermediario", Exportar);
                    }
                    //EN CASO DE QUE LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
                    {
                        //VALIDAMOS SI SE VAN A FILTRAR TODOS LOS INTERMEDIARIOS O SOLO 1
                        //VALIDAMOS TODOS LOS INTERMEDIAIOS
                        if (cbTodosLosIntermediarios.Checked)
                        {
                            var Exportar = (from n in ObjData.Value.ReporteCobradoCOntabilidad(
                            FechaDesde,
                            FechaHasta,
                            FechaDesdeAnterior,
                            FechaHastaAnterior,
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario
                            )
                                            select new
                                            {
                                                Intermediario = n.Intermediario,
                                                CodigoIntermediario = n.CodigoIntermediario,
                                                CodRamo = n.CodRamo,
                                                Ramo = n.Ramo,
                                                CodOficina = n.CodOficina,
                                                Oficina = n.Oficina,
                                                Cobrado = n.Cobrado,
                                                CobradoHoy = n.CobradoHoy,
                                                CobradoSantoDomingo = n.CobradoSantoDomingo,
                                                CobradoSantiago = n.CobradoSantiago,
                                                CobradoOtros = n.CobradoOtros,
                                                Total = n.Total,
                                                CobradoMesAnterior = n.CobradoMesAnterior
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cobrado Con Intermediario", Exportar);
                        }
                        //VALIDAMOS UN INTERMEDIARIO EN ESPESIFICO
                        else
                        {
                            var Exportar = (from n in ObjData.Value.ReporteCobradoCOntabilidad(
                            FechaDesde,
                            FechaHasta,
                            FechaDesdeAnterior,
                            FechaHastaAnterior,
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario,
                            _CodigoIntermediario)
                                            select new
                                            {
                                                Intermediario = n.Intermediario,
                                                CodigoIntermediario = n.CodigoIntermediario,
                                                CodRamo = n.CodRamo,
                                                Ramo = n.Ramo,
                                                CodOficina = n.CodOficina,
                                                Oficina = n.Oficina,
                                                Cobrado = n.Cobrado,
                                                CobradoHoy = n.CobradoHoy,
                                                CobradoSantoDomingo = n.CobradoSantoDomingo,
                                                CobradoSantiago = n.CobradoSantiago,
                                                CobradoOtros = n.CobradoOtros,
                                                Total = n.Total,
                                                CobradoMesAnterior = n.CobradoMesAnterior
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cobrado Intermediario Espesifico", Exportar);
                        }

                    }
                }
            }
        }
        #endregion
        #region EXPORTAR DATA MODO COMPARATIVO
        private void ExportarDataModoCOmparativo()
        {
            try {
                //VERIFICAMOS EL TIPO DE REPORTE SELECCIONAD
                //SI EL REPORTE A EXPORTAR ES PRODUCCION
                if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 1)
                {
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
                    //VERIFICAMOS SI LA CONSULTA LLEVA INTERMEDARIOS
                    //EN CASO DE QUE NO LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                    {
                        var Exportar = (from n in ObjData.Value.SacarProduccionDiariaContabilidad(
                             Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                            _Ramo,
                            _Oficina,
                            null,
                            null,
                            _LlevaIntermediario)
                                        select new
                                        {
                                            Ramo = n.Ramo,
                                            Descripcion = n.Descripcion,
                                            Tipo = n.Tipo,
                                            DescripcionTipo = n.DescripcionTipo,
                                            CodOficina = n.CodOficina,
                                            Oficina = n.Oficina,
                                            Concepto = n.Concepto,
                                            FacturadoMes = n.FacturadoMes,
                                            Total = n.Total,
                                            MesAnterior = n.MesAnterior,
                                            Hoy = n.Hoy,
                                            TotalCredito = n.TotalCredito,
                                            TotalDebito = n.TotalDebito,
                                            TotalOtros = n.TotalOtros
                                        }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción Sin Intermediario", Exportar);

                    }
                    //EN CASO DE QUE LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
                    {
                        //VALIDAMOS SI SE VAN A FILTRAR TODOS LOS INTERMEDIARIOS O SOLO 1
                        //VALIDAMOS TODOS LOS INTERMEDIAIOS
                        if (cbTodosLosIntermediarios.Checked)
                        {
                            var Exportar = (from n in ObjData.Value.SacarProduccionDiariaContabilidad(
                           Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                           _Ramo,
                           _Oficina,
                           null,
                           null,
                           _LlevaIntermediario)
                                            select new
                                            {
                                                Intermediario = n.Intermediario,
                                                Codigo = n.Codigo,
                                                Ramo = n.Ramo,
                                                Descripcion = n.Descripcion,
                                                Tipo = n.Tipo,
                                                DescripcionTipo = n.DescripcionTipo,
                                                CodOficina = n.CodOficina,
                                                Oficina = n.Oficina,
                                                Concepto = n.Concepto,
                                                FacturadoMes = n.FacturadoMes,
                                                Total = n.Total,
                                                MesAnterior = n.MesAnterior,
                                                Hoy = n.Hoy,
                                                TotalCredito = n.TotalCredito,
                                                TotalDebito = n.TotalDebito,
                                                TotalOtros = n.TotalOtros
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción Todos los  Intermediario", Exportar);
                        }
                        //VALIDAMOS UN INTERMEDIARIO EN ESPESIFICO
                        else
                        {
                            var Exportar = (from n in ObjData.Value.SacarProduccionDiariaContabilidad(
                            Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                           _Ramo,
                           _Oficina,
                           null,
                           _CodigoIntermediario,
                           _LlevaIntermediario)
                                            select new
                                            {
                                                Intermediario = n.Intermediario,
                                                Codigo = n.Codigo,
                                                Ramo = n.Ramo,
                                                Descripcion = n.Descripcion,
                                                Tipo = n.Tipo,
                                                DescripcionTipo = n.DescripcionTipo,
                                                CodOficina = n.CodOficina,
                                                Oficina = n.Oficina,
                                                Concepto = n.Concepto,
                                                FacturadoMes = n.FacturadoMes,
                                                Total = n.Total,
                                                MesAnterior = n.MesAnterior,
                                                Hoy = n.Hoy,
                                                TotalCredito = n.TotalCredito,
                                                TotalDebito = n.TotalDebito,
                                                TotalOtros = n.TotalOtros
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción Intermediario Espesifico", Exportar);
                        }

                    }

                }
                //SI EL REPORTE A EXPORTAR ES DE LO COBRADO
                else if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 2)
                {
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
                    //VERIFICAMOS SI LA CONSULTA LLEVA INTERMEDARIOS
                    //EN CASO DE QUE NO LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                    {
                        var Exportar = (from n in ObjData.Value.ReporteCobradoCOntabilidad(
                            Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario,
                            null)
                                        select new
                                        {
                                            CodRamo = n.CodRamo,
                                            Ramo = n.Ramo,
                                            CodOficina = n.CodOficina,
                                            Oficina = n.Oficina,
                                            Cobrado = n.Cobrado,
                                            CobradoHoy = n.CobradoHoy,
                                            CobradoSantoDomingo = n.CobradoSantoDomingo,
                                            CobradoSantiago = n.CobradoSantiago,
                                            CobradoOtros = n.CobradoOtros,
                                            Total = n.Total,
                                            CobradoMesAnterior = n.CobradoMesAnterior
                                        }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cobrado Sin Intermediario", Exportar);
                    }
                    //EN CASO DE QUE LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
                    {
                        //VALIDAMOS SI SE VAN A FILTRAR TODOS LOS INTERMEDIARIOS O SOLO 1
                        //VALIDAMOS TODOS LOS INTERMEDIAIOS
                        if (cbTodosLosIntermediarios.Checked)
                        {
                            var Exportar = (from n in ObjData.Value.ReporteCobradoCOntabilidad(
                          Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario
                            )
                                            select new
                                            {
                                                Intermediario = n.Intermediario,
                                                CodigoIntermediario = n.CodigoIntermediario,
                                                CodRamo = n.CodRamo,
                                                Ramo = n.Ramo,
                                                CodOficina = n.CodOficina,
                                                Oficina = n.Oficina,
                                                Cobrado = n.Cobrado,
                                                CobradoHoy = n.CobradoHoy,
                                                CobradoSantoDomingo = n.CobradoSantoDomingo,
                                                CobradoSantiago = n.CobradoSantiago,
                                                CobradoOtros = n.CobradoOtros,
                                                Total = n.Total,
                                                CobradoMesAnterior = n.CobradoMesAnterior
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cobrado Con Intermediario", Exportar);
                        }
                        //VALIDAMOS UN INTERMEDIARIO EN ESPESIFICO
                        else
                        {
                            var Exportar = (from n in ObjData.Value.ReporteCobradoCOntabilidad(
                            Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario,
                            _CodigoIntermediario)
                                            select new
                                            {
                                                Intermediario = n.Intermediario,
                                                CodigoIntermediario = n.CodigoIntermediario,
                                                CodRamo = n.CodRamo,
                                                Ramo = n.Ramo,
                                                CodOficina = n.CodOficina,
                                                Oficina = n.Oficina,
                                                Cobrado = n.Cobrado,
                                                CobradoHoy = n.CobradoHoy,
                                                CobradoSantoDomingo = n.CobradoSantoDomingo,
                                                CobradoSantiago = n.CobradoSantiago,
                                                CobradoOtros = n.CobradoOtros,
                                                Total = n.Total,
                                                CobradoMesAnterior = n.CobradoMesAnterior
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cobrado Intermediario Espesifico", Exportar);
                        }

                    }
                }
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorExportacionConsulta", "ErrorExportacionConsulta();", true);
            }
        }
        #endregion
        #region OCULTAR Y MOSTRAR CONTROLES
        enum LlevaIntermediarios { 
        SinIntermediario=1,
        ConIntermediario=2,
        }
        private void ModoFacturracion()
        {
            int LlevaIntermediario = Convert.ToInt32(ddlLlevaIntermediario.SelectedValue);

            switch (LlevaIntermediario) {

                case (int)LlevaIntermediarios.ConIntermediario:
                    DivProduccionSinIntermediario.Visible = false;
                    DivProduccionConIntermediario.Visible = true;
                    DivCobroSinIntermedairio.Visible = false;
                    DivCobrosConIntermediario.Visible = false;
                    break;

                case (int)LlevaIntermediarios.SinIntermediario:
                    DivProduccionSinIntermediario.Visible = true;
                    DivProduccionConIntermediario.Visible = false;
                    DivCobroSinIntermedairio.Visible = false;
                    DivCobrosConIntermediario.Visible = false;
                    break;
            }
          
        }
        private void ModoCobrado()
        {
            int LlevaIntermediario = Convert.ToInt32(ddlLlevaIntermediario.SelectedValue);

            switch (LlevaIntermediario)
            {

                case (int)LlevaIntermediarios.ConIntermediario:
                    DivProduccionSinIntermediario.Visible = false;
                    DivProduccionConIntermediario.Visible = false;
                    DivCobroSinIntermedairio.Visible = false;
                    DivCobrosConIntermediario.Visible = true;
                    break;

                case (int)LlevaIntermediarios.SinIntermediario:
                    DivProduccionSinIntermediario.Visible = false;
                    DivProduccionConIntermediario.Visible = false;
                    DivCobroSinIntermedairio.Visible = true;
                    DivCobrosConIntermediario.Visible = false;
                    break;
            }
          

        }
        #endregion

        #region CONSULTAR DATA
        private void ConsultarData() {
            if (cbModoComparativo.Checked)
            {
                CargarListadoModoCOmparativo();
            }
            else
            {
                CargarListado();
            }
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
                lbPantalla.Text = "PRODUCCION DIARIA (CONTABILIDAD)";

                cbModoComparativo.Checked = false;
                CargarRamos();
                CargarOficinas();
                CargarMeses();


                DivProduccionSinIntermediario.Visible = true;
                DivProduccionConIntermediario.Visible = false;
                DivCobroSinIntermedairio.Visible = false;
                DivCobrosConIntermediario.Visible = false;

                DivfechaDesdeComoarativo.Visible = false;
                DivFechaHAstaComparativo.Visible = false;
                DivFechaDesdeMesAnteriorComparativo.Visible = false;
                DivFechaHastaMesAnteriorComparativo.Visible = false;
            }
        }

        protected void cbModoComparativo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModoComparativo.Checked == true) {
                DivfechaDesdeComoarativo.Visible = true;
                DivFechaHAstaComparativo.Visible = true;
                DivFechaDesdeMesAnteriorComparativo.Visible = true;
                DivFechaHastaMesAnteriorComparativo.Visible = true;
                ddlSeleccionarMes.Enabled = false;
                txtAno.Enabled = false;
            }
            else {
                DivfechaDesdeComoarativo.Visible = false;
                DivFechaHAstaComparativo.Visible = false;
                DivFechaDesdeMesAnteriorComparativo.Visible = false;
                DivFechaHastaMesAnteriorComparativo.Visible = false;
                ddlSeleccionarMes.Enabled = true;
                txtAno.Enabled = true;
            }
        }

        protected void cbTodosLosIntermediarios_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodosLosIntermediarios.Checked)
            {
                lbLetreroTodosIntermediairos.Visible = true;
                ClientScript.RegisterStartupScript(GetType(), "DesactivarCodigoIntermediario", "DesactivarCodigoIntermediario();", true);
            }
            else
            {
                lbLetreroTodosIntermediairos.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "ActivarCodigoIntermediario", "ActivarCodigoIntermediario()", true);
            }
        }

        protected void ddlSeleccionarTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 1)
            {
                ModoFacturracion();
            }
            else if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 2)
            {
                ModoCobrado();
            }
        }

        protected void ddlLlevaIntermediario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == (int)LlevaIntermediarios.ConIntermediario)
            {
                lbIntermediario.Visible = true;
                txtCodigoIntermediario.Visible = true;
                cbTodosLosIntermediarios.Visible = true;
                txtCodigoIntermediario.Text = string.Empty;

                int TipoReporte = Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue);

                switch (TipoReporte) {

                    case (int)TipoDeReporte.Produccion:
                        DivProduccionSinIntermediario.Visible = false;
                        DivProduccionConIntermediario.Visible = true;
                        DivCobroSinIntermedairio.Visible = false;
                        DivCobrosConIntermediario.Visible = false;
                        break;


                    case (int)TipoDeReporte.Cobros:
                        DivProduccionSinIntermediario.Visible = false;
                        DivProduccionConIntermediario.Visible = false;
                        DivCobroSinIntermedairio.Visible = false;
                        DivCobrosConIntermediario.Visible = true;
                        break;
                }
            }
            else
            {
                lbIntermediario.Visible = false;
                txtCodigoIntermediario.Visible = false;
                cbTodosLosIntermediarios.Visible = false;

                int TipoReporte = Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue);

                switch (TipoReporte)
                {

                    case (int)TipoDeReporte.Produccion:
                        DivProduccionSinIntermediario.Visible = true;
                        DivProduccionConIntermediario.Visible = false;
                        DivCobroSinIntermedairio.Visible = false;
                        DivCobrosConIntermediario.Visible = false;
                        break;


                    case (int)TipoDeReporte.Cobros:
                        DivProduccionSinIntermediario.Visible = false;
                        DivProduccionConIntermediario.Visible = false;
                        DivCobroSinIntermedairio.Visible = true;
                        DivCobrosConIntermediario.Visible = false;
                        break;
                }


            }
        }

        protected void btnConsultarNuevo_Click(object sender, ImageClickEventArgs e)
        {
            ConsultarData();
        }

        protected void btnExportarNuevo_Click(object sender, ImageClickEventArgs e)
        {
            if (cbModoComparativo.Checked)
            {
                ExportarDataModoCOmparativo();
            }
            else
            {
                ExportarDataExel();
            }
        }

        protected void dtPaginacion_ProduccionSinIntermediario_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ProduccionSinIntermediario_ItemCommand(object source, DataListCommandEventArgs e)
        {

            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_ProduccionSinIntermediario = Convert.ToInt32(e.CommandArgument.ToString());
            ConsultarData();
        }

        protected void btnSiguientePagina_ProduccionSinIntermediario_Click(object sender, ImageClickEventArgs e)
        {

            CurrentPage_ProduccionSinIntermediario += 1;
            ConsultarData();
        }

        protected void btnUltimaPagina_ProduccionSinIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ProduccionSinIntermediario = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            ConsultarData();
            MoverValoresPaginacion_ProduccionSinIntermediario((int)OpcionesPaginacionValores_ProduccionSinIntermediario.UltimaPagina, ref lbPaginaActual_ProduccionSinIntermediario, ref lbCantidadPagina_ProduccionSinIntermediario);
        }

        protected void btnPrimeraPagina_ProduccionSinIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ProduccionSinIntermediario = 0;
            ConsultarData();
        }

        protected void btnPaginaAnterior_ProduccionSinIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ProduccionSinIntermediario += -1;
            ConsultarData();
            MoverValoresPaginacion_ProduccionSinIntermediario((int)OpcionesPaginacionValores_ProduccionSinIntermediario.PaginaAnterior, ref lbPaginaActual_ProduccionSinIntermediario, ref lbCantidadPagina_ProduccionSinIntermediario);
        }

        protected void btnPrimeraPagina_ProduccionConIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ProduccionConIntermediario = 0;
            ConsultarData();
        }

        protected void btnPaginaAnterior_ProduccionConIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ProduccionConIntermediario += -1;
            ConsultarData();
            MoverValoresPaginacion_ProduccionConIntermediario((int)OpcionesPaginacionValores_ProduccionConIntermediario.PaginaAnterior, ref lbPaginaActual_ProduccionConIntermediario, ref lbCantidadPagina_ProduccionConIntermediario);
        }

        protected void dtPaginacion_ProduccionConIntermediario_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ProduccionConIntermediario_ItemCommand(object source, DataListCommandEventArgs e)
        {

            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_ProduccionConIntermediario = Convert.ToInt32(e.CommandArgument.ToString());
            CargarListado();
        }

        protected void btnSiguientePagina_ProduccionConIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ProduccionConIntermediario += 1;
            ConsultarData();
        }

        protected void btnUltimaPagina_ProduccionConIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ProduccionConIntermediario = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            ConsultarData();
            MoverValoresPaginacion_ProduccionConIntermediario((int)OpcionesPaginacionValores_ProduccionConIntermediario.UltimaPagina, ref lbPaginaActual_ProduccionConIntermediario, ref lbCantidadPagina_ProduccionConIntermediario);
        }

        protected void btnPrimeraPagina_CobradoSinIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CobroSinIntermedairio = 0;
            ConsultarData();
        }

        protected void btnPaginaAnterior_CobradoSinIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CobroSinIntermedairio += -1;
            ConsultarData();
            MoverValoresPaginacion_CobroSinIntermedairio((int)OpcionesPaginacionValores_CobroSinIntermedairio.PaginaAnterior, ref lbPaginaActual_CobradoSinIntermediario, ref lbCantidadPagina_CobradoSinIntermediario);
        }

        protected void dtPaginacion_CobradoSinIntermediario_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_CobradoSinIntermediario_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_CobroSinIntermedairio = Convert.ToInt32(e.CommandArgument.ToString());
            ConsultarData();
        }

        protected void btnSiguientePagina_CobradoSinIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CobroSinIntermedairio += 1;
            ConsultarData();
        }

        protected void btnUltimaPagina_CobradoSinIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CobroSinIntermedairio = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            ConsultarData();
            MoverValoresPaginacion_CobroSinIntermedairio((int)OpcionesPaginacionValores_CobroSinIntermedairio.UltimaPagina, ref lbPaginaActual_CobradoSinIntermediario, ref lbCantidadPagina_CobradoSinIntermediario);
        }

        protected void btnPrimeraPagina_CobradoConIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CobroConIntermedairio = 0;
            ConsultarData();
        }

        protected void btnPaginaAnterior_CobradoConIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CobroConIntermedairio += -1;
            ConsultarData();
            MoverValoresPaginacion_CobroConIntermedairio((int)OpcionesPaginacionValores_CobroConIntermedairio.PaginaAnterior, ref lbPaginaActual_CobradoConIntermediario, ref lbCantidadPagina_CobradoConIntermediario);
        }

        protected void dtPaginacion_CobradoConIntermediario_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_CobradoConIntermediario_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_CobroConIntermedairio = Convert.ToInt32(e.CommandArgument.ToString());
            ConsultarData();
        }

        protected void btnSiguientePagina_CobradoConIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CobroConIntermedairio += 1;
            ConsultarData();
        }

        protected void btnUltimaPagina_CobradoConIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CobroConIntermedairio = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            ConsultarData();
            MoverValoresPaginacion_CobroConIntermedairio((int)OpcionesPaginacionValores_CobroConIntermedairio.UltimaPagina, ref lbPaginaActual_CobradoConIntermediario, ref lbCantidadPagina_CobradoConIntermediario);
        }
    }
}