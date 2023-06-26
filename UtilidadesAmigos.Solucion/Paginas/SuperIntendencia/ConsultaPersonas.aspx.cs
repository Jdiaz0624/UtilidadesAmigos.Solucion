using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using SpreadsheetLight;
using System.Web.Security;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;


namespace UtilidadesAmigos.Solucion.Paginas.SuperIntendencia
{
    public partial class ConsultaPersonas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSuperIntendencia.LogicaSuperIntendencia> ObjDataSuperIntendencia = new Lazy<Logica.Logica.LogicaSuperIntendencia.LogicaSuperIntendencia>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataSistema = new Lazy<Logica.Logica.LogicaSistema>();

        enum BuscarComo { 
        Cliente=1,
        Intermediario=2,
        Proveedores=3,
        AseguradoBajoPoliza=4,
        Asegurado=5,
        Dependiente=6,
        Cheque=7,
        DocumentosAmigos=8,
        Reclamaciones=9,
        Placa=10,
        Chasis=11
        }


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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label CantidadPagina, ref LinkButton PrimeraPagina, ref LinkButton PaginaAnterior, ref LinkButton SiguientePagina, ref LinkButton UltimaPagina)
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


            divPaginacionCliente.Visible = true;
            DivPaginacionIntermediario.Visible = true;
            OcultarDetalle();
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

        #region CONTROL DE PAGINACION DE CLIENTES
        readonly PagedDataSource pagedDataSource_Clientes = new PagedDataSource();
        int _PrimeraPagina_Clientes, _UltimaPagina_Clientes;
        private int _TamanioPagina_Clientes = 10;
        private int CurrentPage_Clientes
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

        private void HandlePaging_Clientes(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Clientes = CurrentPage_Clientes - 5;
            if (CurrentPage_Clientes > 5)
                _UltimaPagina_Clientes = CurrentPage_Clientes + 5;
            else
                _UltimaPagina_Clientes = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Clientes > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Clientes = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Clientes = _UltimaPagina_Clientes - 10;
            }

            if (_PrimeraPagina_Clientes < 0)
                _PrimeraPagina_Clientes = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Clientes;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Clientes; i < _UltimaPagina_Clientes; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_Clientes(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_Clientes.DataSource = Listado;
            pagedDataSource_Clientes.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_Clientes.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_Clientes.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_Clientes.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Clientes : _NumeroRegistros);
            pagedDataSource_Clientes.CurrentPageIndex = CurrentPage_Clientes;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_Clientes.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_Clientes.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_Clientes.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_Clientes.IsLastPage;

            RptGrid.DataSource = pagedDataSource_Clientes;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_Clientes
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_Clientes(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DE INTERMEDIARIOS SUPERVISORES
        readonly PagedDataSource pagedDataSource_IntermediariosSupervisores = new PagedDataSource();
        int _PrimeraPagina_IntermediariosSupervisores, _UltimaPagina_IntermediariosSupervisores;
        private int _TamanioPagina_IntermediariosSupervisores = 10;
        private int CurrentPage_IntermediariosSupervisores
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

        private void HandlePaging_IntermediariosSupervisores(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_IntermediariosSupervisores = CurrentPage_IntermediariosSupervisores - 5;
            if (CurrentPage_IntermediariosSupervisores > 5)
                _UltimaPagina_IntermediariosSupervisores = CurrentPage_IntermediariosSupervisores + 5;
            else
                _UltimaPagina_IntermediariosSupervisores = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_IntermediariosSupervisores > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_IntermediariosSupervisores = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_IntermediariosSupervisores = _UltimaPagina_IntermediariosSupervisores - 10;
            }

            if (_PrimeraPagina_IntermediariosSupervisores < 0)
                _PrimeraPagina_IntermediariosSupervisores = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_IntermediariosSupervisores;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_IntermediariosSupervisores; i < _UltimaPagina_IntermediariosSupervisores; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_IntermediariosSupervisores(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_IntermediariosSupervisores.DataSource = Listado;
            pagedDataSource_IntermediariosSupervisores.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_IntermediariosSupervisores.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_IntermediariosSupervisores.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_IntermediariosSupervisores.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_IntermediariosSupervisores : _NumeroRegistros);
            pagedDataSource_IntermediariosSupervisores.CurrentPageIndex = CurrentPage_Clientes;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_IntermediariosSupervisores.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_IntermediariosSupervisores.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_IntermediariosSupervisores.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_IntermediariosSupervisores.IsLastPage;

            RptGrid.DataSource = pagedDataSource_IntermediariosSupervisores;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_IntermediariosSupervisores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_IntermediariosSupervisores(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DE LOS PROVEEDORES
        readonly PagedDataSource pagedDataSource_Proveedores = new PagedDataSource();
        int _PrimeraPagina_Proveedores, _UltimaPagina_Proveedores;
        private int _TamanioPagina_Proveedores = 10;
        private int CurrentPage_Proveedores
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

        private void HandlePaging_Proveedores(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Proveedores = CurrentPage_Proveedores - 5;
            if (CurrentPage_Proveedores > 5)
                _UltimaPagina_Proveedores = CurrentPage_Proveedores + 5;
            else
                _UltimaPagina_Proveedores = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Proveedores > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Proveedores = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Proveedores = _UltimaPagina_Proveedores - 10;
            }

            if (_PrimeraPagina_Proveedores < 0)
                _PrimeraPagina_Proveedores = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Proveedores;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Proveedores; i < _UltimaPagina_Proveedores; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_Proveedores(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_Proveedores.DataSource = Listado;
            pagedDataSource_Proveedores.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_Proveedores.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_Proveedores.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_Proveedores.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Proveedores : _NumeroRegistros);
            pagedDataSource_Proveedores.CurrentPageIndex = CurrentPage_Proveedores;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_Proveedores.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_Proveedores.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_Proveedores.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_Proveedores.IsLastPage;

            RptGrid.DataSource = pagedDataSource_Proveedores;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_Proveedores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_Proveedores(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DE LOS ASEGURADOS BAJO POLIZA
        readonly PagedDataSource pagedDataSource_AseguradoBajoPoliza = new PagedDataSource();
        int _PrimeraPagina_AseguradoBajoPoliza, _UltimaPagina_AseguradoBajoPoliza;
        private int _TamanioPagina_AseguradoBajoPoliza = 10;
        private int CurrentPage_AseguradoBajoPoliza
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

        private void HandlePaging_AseguradoBajoPoliza(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_AseguradoBajoPoliza = CurrentPage_AseguradoBajoPoliza - 5;
            if (CurrentPage_AseguradoBajoPoliza > 5)
                _UltimaPagina_AseguradoBajoPoliza = CurrentPage_AseguradoBajoPoliza + 5;
            else
                _UltimaPagina_AseguradoBajoPoliza = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_AseguradoBajoPoliza > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_AseguradoBajoPoliza = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_AseguradoBajoPoliza = _UltimaPagina_AseguradoBajoPoliza - 10;
            }

            if (_PrimeraPagina_AseguradoBajoPoliza < 0)
                _PrimeraPagina_AseguradoBajoPoliza = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_AseguradoBajoPoliza;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_AseguradoBajoPoliza; i < _UltimaPagina_AseguradoBajoPoliza; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_AseguradoBajoPoliza(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_AseguradoBajoPoliza.DataSource = Listado;
            pagedDataSource_AseguradoBajoPoliza.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_AseguradoBajoPoliza.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_AseguradoBajoPoliza.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_AseguradoBajoPoliza.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_AseguradoBajoPoliza : _NumeroRegistros);
            pagedDataSource_AseguradoBajoPoliza.CurrentPageIndex = CurrentPage_AseguradoBajoPoliza;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_AseguradoBajoPoliza.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_AseguradoBajoPoliza.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_AseguradoBajoPoliza.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_AseguradoBajoPoliza.IsLastPage;

            RptGrid.DataSource = pagedDataSource_AseguradoBajoPoliza;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_AseguradoBajoPoliza
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_AseguradoBajoPoliza(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DE LOS ASEGURADOS
        readonly PagedDataSource pagedDataSource_Asegurado = new PagedDataSource();
        int _PrimeraPagina_Asegurado, _UltimaPagina_Asegurado;
        private int _TamanioPagina_Asegurado = 10;
        private int CurrentPage_Asegurado
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

        private void HandlePaging_Asegurado(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Asegurado = CurrentPage_Asegurado - 5;
            if (CurrentPage_Asegurado > 5)
                _UltimaPagina_Asegurado = CurrentPage_Asegurado + 5;
            else
                _UltimaPagina_Asegurado = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Asegurado > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Asegurado = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Asegurado = _UltimaPagina_Asegurado - 10;
            }

            if (_PrimeraPagina_Asegurado < 0)
                _PrimeraPagina_Asegurado = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Asegurado;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Asegurado; i < _UltimaPagina_Asegurado; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_Asegurado(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_Asegurado.DataSource = Listado;
            pagedDataSource_Asegurado.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_Asegurado.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_Asegurado.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_Asegurado.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Asegurado : _NumeroRegistros);
            pagedDataSource_Asegurado.CurrentPageIndex = CurrentPage_Asegurado;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_Asegurado.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_Asegurado.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_Asegurado.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_Asegurado.IsLastPage;

            RptGrid.DataSource = pagedDataSource_Asegurado;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_Asegurado
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_Asegurado(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DE LOS DEPENDIENTES
        readonly PagedDataSource pagedDataSource_Dependiente = new PagedDataSource();
        int _PrimeraPagina_Dependiente, _UltimaPagina_Dependiente;
        private int _TamanioPagina_Dependiente = 10;
        private int CurrentPage_Dependiente
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

        private void HandlePaging_Dependiente(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Dependiente = CurrentPage_Dependiente - 5;
            if (CurrentPage_Dependiente > 5)
                _UltimaPagina_Dependiente = CurrentPage_Dependiente + 5;
            else
                _UltimaPagina_Dependiente = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Dependiente > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Dependiente = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Dependiente = _UltimaPagina_Dependiente - 10;
            }

            if (_PrimeraPagina_Dependiente < 0)
                _PrimeraPagina_Dependiente = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Dependiente;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Dependiente; i < _UltimaPagina_Dependiente; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_Dependiente(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_Dependiente.DataSource = Listado;
            pagedDataSource_Dependiente.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_Dependiente.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_Dependiente.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_Dependiente.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Dependiente : _NumeroRegistros);
            pagedDataSource_Dependiente.CurrentPageIndex = CurrentPage_Dependiente;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_Dependiente.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_Dependiente.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_Dependiente.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_Dependiente.IsLastPage;

            RptGrid.DataSource = pagedDataSource_Dependiente;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_Dependiente
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_Dependiente(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DEL RESULTADO DE LA BUSQUEDA MEDIANTE ARCHIVO
        readonly PagedDataSource pagedDataSource_Archivo = new PagedDataSource();
        int _PrimeraPagina_Archivo, _UltimaPagina_Archivo;
        private int _TamanioPagina_Archivo = 10;
        private int CurrentPage_Archivo
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

        private void HandlePaging_Archivo(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Archivo = CurrentPage_Archivo - 5;
            if (CurrentPage_Archivo > 5)
                _UltimaPagina_Archivo = CurrentPage_Archivo + 5;
            else
                _UltimaPagina_Archivo = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Archivo > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Archivo = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Archivo = _UltimaPagina_Archivo - 10;
            }

            if (_PrimeraPagina_Archivo < 0)
                _PrimeraPagina_Archivo = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Archivo;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Archivo; i < _UltimaPagina_Archivo; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_Archivo(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_Archivo.DataSource = Listado;
            pagedDataSource_Archivo.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_Archivo.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_Archivo.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_Archivo.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Archivo : _NumeroRegistros);
            pagedDataSource_Archivo.CurrentPageIndex = CurrentPage_Archivo;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_Archivo.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_Archivo.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_Archivo.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_Archivo.IsLastPage;

            RptGrid.DataSource = pagedDataSource_Archivo;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_Archivo
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_Archivo(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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


        #region PROCESOS PARA LA BUSQUEDA Y PROCESO DE INFORMACION A TRAVEZ DE ARCHIVO DE EXCEL



        enum TipoBusquedaProceso { 
        BusquedaPorNombre=1,
        BusquedaPorRNC=2
        }


        private void BuscarInformacionClientesLote(int TipoBusqueda, string Nombre, string RNC) {
            decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;
            switch (TipoBusqueda) {
                case (int)TipoBusquedaProceso.BusquedaPorNombre:

                    var BuscarClientesNombre = ObjDataSuperIntendencia.Value.BuscaPersonasSuperIntendenciaCliente(
                        null,
                        Nombre,
                        null,
                        null,
                        null,
                        null, null, null, 1);
                    if (BuscarClientesNombre.Count() < 1)
                    {

                    }
                    else {
                       
                        //SACAMOS LA INFORMACION NECESARIA PARA ESTE PROCESO
                        foreach (var nNombre in BuscarClientesNombre) {

                            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.SuperIntendencia.ProcesarInformacionResultadoBusquedaArchivo Procesar = new Logica.Comunes.ProcesarMantenimientos.SuperIntendencia.ProcesarInformacionResultadoBusquedaArchivo(
                                IdUsuario,
                                nNombre.Nombre,
                                nNombre.NumeroIdentificacion,
                                nNombre.poliza,
                                "",
                                "",
                                nNombre.Ramo,
                                (decimal)nNombre.MontoAsegurado,
                                (decimal)nNombre.Prima,
                                (DateTime)nNombre.FechaInicioVigencia,
                                (DateTime)nNombre.FechaFinVigencia,
                                "Por Nombre",
                                "Cliente",
                                "",
                                "INSERT");
                            Procesar.ProcesarInformacion();
                        }
                    }

                    break;

                case (int)TipoBusquedaProceso.BusquedaPorRNC:
                    var BuscarPorRNC = ObjDataSuperIntendencia.Value.BuscaPersonasSuperIntendenciaCliente(
                        RNC,
                        null,
                        null,
                        null,
                        null,
                        null, null, null, 1);
                    if (BuscarPorRNC.Count() < 1)
                    {

                    }
                    else
                    {

                        //SACAMOS LA INFORMACION NECESARIA PARA ESTE PROCESO
                        foreach (var nNombre in BuscarPorRNC)
                        {

                            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.SuperIntendencia.ProcesarInformacionResultadoBusquedaArchivo Procesar = new Logica.Comunes.ProcesarMantenimientos.SuperIntendencia.ProcesarInformacionResultadoBusquedaArchivo(
                                IdUsuario,
                                nNombre.Nombre,
                                nNombre.NumeroIdentificacion,
                                nNombre.poliza,
                                "",
                                "",
                                nNombre.Ramo,
                                (decimal)nNombre.MontoAsegurado,
                                (decimal)nNombre.Prima,
                                (DateTime)nNombre.FechaInicioVigencia,
                                (DateTime)nNombre.FechaFinVigencia,
                                "Por Cedula/RNC",
                                "Cliente",
                                "",
                                "INSERT");
                            Procesar.ProcesarInformacion();
                        }
                    }
                    break;
            }
        
        } //COMPLETO
        private void BuscarInformacionIntermediarioLote(int TipoBusqueda, string Nombre, string RNC) {
            switch (TipoBusqueda)
            {
                case (int)TipoBusquedaProceso.BusquedaPorNombre:
                    var BuscarInformacionPorNombre = ObjDataSuperIntendencia.Value.BuscaPersonasSuperIntendenciaIntermediario(
                        new Nullable<int>(),
                        null, Nombre);
                    if (BuscarInformacionPorNombre.Count() < 1) { }
                    else {
                        decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;

                        foreach (var nIntermediario in BuscarInformacionPorNombre) {
                            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.SuperIntendencia.ProcesarInformacionResultadoBusquedaArchivo Procesar = new Logica.Comunes.ProcesarMantenimientos.SuperIntendencia.ProcesarInformacionResultadoBusquedaArchivo(
                                       IdUsuario,
                                       nIntermediario.Nombre,
                                       nIntermediario.Rnc,
                                       "",
                                       "",
                                       "",
                                       "",
                                       0,
                                       0,
                                       DateTime.Now,
                                       DateTime.Now,
                                       "Por Nombre",
                                       "Encontrado como Intermediario / Supervisor Codigo " + nIntermediario.Codigo.ToString() + " Licencia " + nIntermediario.LicenciaSeguro,
                                       "",
                                       "INSERT");
                            Procesar.ProcesarInformacion();
                        }
                    }
                    break;

                case (int)TipoBusquedaProceso.BusquedaPorRNC:

                    break;
            }
        }
        private void BuscarInformacionProveedorLote(int TipoBusqueda, string Nombre, string RNC) {

            switch (TipoBusqueda)
            {
                case (int)TipoBusquedaProceso.BusquedaPorNombre:

                    break;

                case (int)TipoBusquedaProceso.BusquedaPorRNC:

                    break;
            }
        }
        private void BuscarInformacionAseguradoLote(int TipoBusqueda, string Nombre, string RNC) {
            switch (TipoBusqueda)
            {
                case (int)TipoBusquedaProceso.BusquedaPorNombre:

                    break;

                case (int)TipoBusquedaProceso.BusquedaPorRNC:

                    break;
            }
        }
        private void BuscarInformacionAseguradoBajoPolizaLote(int TipoBusqueda, string Nombre, string RNC) {
            switch (TipoBusqueda)
            {
                case (int)TipoBusquedaProceso.BusquedaPorNombre:

                    break;

                case (int)TipoBusquedaProceso.BusquedaPorRNC:

                    break;
            }
        }
        private void BuscarInformacionDependienteLote(int TipoBusqueda, string Nombre, string RNC) {
            switch (TipoBusqueda)
            {
                case (int)TipoBusquedaProceso.BusquedaPorNombre:

                    break;

                case (int)TipoBusquedaProceso.BusquedaPorRNC:

                    break;
            }
        }
        private void BuscarInformacionReclamoLote(int TipoBusqueda, string Nombre, string RNC) {
            switch (TipoBusqueda)
            {
                case (int)TipoBusquedaProceso.BusquedaPorNombre:

                    break;

                case (int)TipoBusquedaProceso.BusquedaPorRNC:

                    break;
            }
        }
        private void BuscarInformacionDocumentosAmigosLote(int TipoBusqueda, string Nombre, string RNC) {
            switch (TipoBusqueda)
            {
                case (int)TipoBusquedaProceso.BusquedaPorNombre:

                    break;

                case (int)TipoBusquedaProceso.BusquedaPorRNC:

                    break;
            }
        }

        #endregion


        #region BUSCAR INFORMACION PARA PROCESAR POR LOTE
        /// <summary>
        /// Este metodo es apra buscar en la data de los clientes
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="BuscarComo"></param>
        /// <param name="TipoBusqueda"></param>
        private void ProcesarInformacionPersonasSuperIntendenciaPorLote(decimal IdUsuario, int BuscarComo, int TipoBusqueda) {


            var BuscarInformacion = ObjDataSuperIntendencia.Value.BuscaInformacionClienteSuperIntendenciaPorLote(
                IdUsuario,
                BuscarComo,
                TipoBusqueda);
            if (BuscarInformacion.Count() < 1) { }
            else {
                //GUARDAMOS LA INFORMACION
                foreach (var n in BuscarInformacion) {

                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.SuperIntendencia.ProcesarInformacionResultadoBusquedaArchivo Guardar = new Logica.Comunes.ProcesarMantenimientos.SuperIntendencia.ProcesarInformacionResultadoBusquedaArchivo(
                        IdUsuario,
                        n.Nombre,
                        n.NumeroIdentificacion,
                        n.Poliza,
                        n.Reclamacion,
                        n.Estatus,
                        n.Ramo,
                        (decimal)n.MontoAsegurado,
                        (decimal)n.Prima,
                        (DateTime)n.InicioVigencia,
                        (DateTime)n.FinVigencia,
                        n.TipoBusqueda,
                        n.EncontradoComo,
                        n.Comentario,
                        "INSERT");
                    Guardar.ProcesarInformacion();
                }
                    
            }
        }

      
        #endregion


        #region PROCESAR INFORMACION POR LOTE
        /// <summary>
        /// Procesar la informacion cargada por lote
        /// </summary>
        private void ProcesarInformacionPorlote(decimal IdUsuario) {
            //VALIDAMOS QUE HAY REGISTROS GUARDADOS PARA PODER PROCESARLOS
            var ValidarDatosExtraidos = ObjDataSuperIntendencia.Value.BuscarInformacionRegistrada(IdUsuario, null, null);
            if (ValidarDatosExtraidos.Count() < 1) {
                ClientScript.RegisterStartupScript(GetType(), "InformacionAProcesarNoEncontrada()", "InformacionAProcesarNoEncontrada();", true);


            }
            else {

                //ELIMINAMOS TODOS LOS REGISTROS GUARDADOS MEDIANTE EL USUARIO
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.SuperIntendencia.ProcesarInformacionResultadoBusquedaArchivo Eliminar = new Logica.Comunes.ProcesarMantenimientos.SuperIntendencia.ProcesarInformacionResultadoBusquedaArchivo(
                    IdUsuario, "", "", "", "", "", "", 0, 0, DateTime.Now, DateTime.Now, "", "", "", "DELETE");
                Eliminar.ProcesarInformacion();

                //VALIDAMOS EL TIPO DE BUSQUEDA


                if (rbTodosLosParametros.Checked == true) {
                    if (cbCliente.Checked == true) {
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Cliente, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Cliente, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbIntermediario.Checked == true) {
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Intermediario, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Intermediario, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbProvedor.Checked == true) {
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Proveedores, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Proveedores, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbAseguradoBajoPoliza.Checked == true) {
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.AseguradoBajoPoliza, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.AseguradoBajoPoliza, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbAsegurado.Checked == true) {
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Asegurado, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Asegurado, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbDependiente.Checked == true) {
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Dependiente, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Dependiente, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbCheque.Checked == true) {
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Cheque, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Cheque, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbDocumentosAmigos.Checked == true) {
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.DocumentosAmigos, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.DocumentosAmigos, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbReclamaciones.Checked == true) {
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Reclamaciones, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Reclamaciones, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbPlaca.Checked == true) {
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Placa, (int)TipoBusquedaProceso.BusquedaPorNombre);
                       // ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Placa, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbChasis.Checked == true) {
                        ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Chasis, (int)TipoBusquedaProceso.BusquedaPorNombre);
                      //  ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Chasis, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                }
                else if (rbPorNombreBusquedaPorLote.Checked == true) {
                    if (cbCliente.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Cliente, (int)TipoBusquedaProceso.BusquedaPorNombre); }
                    if (cbIntermediario.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Intermediario, (int)TipoBusquedaProceso.BusquedaPorNombre); }
                    if (cbProvedor.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Proveedores, (int)TipoBusquedaProceso.BusquedaPorNombre); }
                    if (cbAseguradoBajoPoliza.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.AseguradoBajoPoliza, (int)TipoBusquedaProceso.BusquedaPorNombre); }
                    if (cbAsegurado.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Asegurado, (int)TipoBusquedaProceso.BusquedaPorNombre); }
                    if (cbDependiente.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Dependiente, (int)TipoBusquedaProceso.BusquedaPorNombre); }
                    if (cbCheque.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Cheque, (int)TipoBusquedaProceso.BusquedaPorNombre); }
                    if (cbDocumentosAmigos.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.DocumentosAmigos, (int)TipoBusquedaProceso.BusquedaPorNombre); }
                    if (cbReclamaciones.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Reclamaciones, (int)TipoBusquedaProceso.BusquedaPorNombre); }
                    if (cbPlaca.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Placa, (int)TipoBusquedaProceso.BusquedaPorNombre); }
                    if (cbChasis.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Chasis, (int)TipoBusquedaProceso.BusquedaPorNombre); }
                }
                else if (rbNumeroIdentificacionBusquedaPorLote.Checked == true) {
                    if (cbCliente.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Cliente, (int)TipoBusquedaProceso.BusquedaPorRNC); }
                    if (cbIntermediario.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Intermediario, (int)TipoBusquedaProceso.BusquedaPorRNC); }
                    if (cbProvedor.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Proveedores, (int)TipoBusquedaProceso.BusquedaPorRNC); }
                    if (cbAseguradoBajoPoliza.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.AseguradoBajoPoliza, (int)TipoBusquedaProceso.BusquedaPorRNC); }
                    if (cbAsegurado.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Asegurado, (int)TipoBusquedaProceso.BusquedaPorRNC); }
                    if (cbDependiente.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Dependiente, (int)TipoBusquedaProceso.BusquedaPorRNC); }
                    if (cbCheque.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Cheque, (int)TipoBusquedaProceso.BusquedaPorRNC); }
                    if (cbDocumentosAmigos.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.DocumentosAmigos, (int)TipoBusquedaProceso.BusquedaPorRNC); }
                    if (cbReclamaciones.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Reclamaciones, (int)TipoBusquedaProceso.BusquedaPorRNC); }

                }
                else if (rbPlacaBusquedaPorLote.Checked == true) {

                    if (cbPlaca.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Placa, (int)TipoBusquedaProceso.BusquedaPorNombre); }
                }
                else if (rbChasisBusquedaPorLote.Checked == true) {

                    if (cbChasis.Checked == true) { ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Chasis, (int)TipoBusquedaProceso.BusquedaPorNombre); }
                }
             
            
            }
        
        }
        #endregion


        #region REPORTE DE RESULTADO DE BUSQUEDA DE PERSONAS
        private void GenerarReporte(string RutaReporte, string NombreReporte, decimal IdUsuario) {

            ReportDocument Reprte = new ReportDocument();
            Reprte.Load(RutaReporte);
            Reprte.Refresh();

            Reprte.SetParameterValue("@IdUsuario", IdUsuario);

            Reprte.SetDatabaseLogon("sa", "Pa$$W0rd");

            if (rbExportarPDF.Checked == true) {
                Reprte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
            }
            else if (rbExcel.Checked == true) {
                Reprte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreReporte);
            }
            else if (rbExportarWord.Checked == true) {
                Reprte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreReporte);
            }
        }
        #endregion


        private void OcultarDetalle() {
            DivBloqueDetalleCliente.Visible = false;
            DivDetalleInformacionIntermediarioSeleccionado.Visible = false;
            DivDetalleProveedores.Visible = false;
            DivDetalleAsegurado.Visible = false;
            DivDetalleAseguradoGeneral.Visible = false;
            DivDetalleDependientes.Visible = false;              
        }

        private void ProcesarInformacionArchivo(string Nombre, string NumeroIdentificacion, string Chasis, string Placa, string Accion) {

            decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.SuperIntendencia.ProcesarInformacionPersonasArchivoSuperIntenedencia Procesar = new Logica.Comunes.ProcesarMantenimientos.SuperIntendencia.ProcesarInformacionPersonasArchivoSuperIntenedencia(
                IdUsuario, Nombre, NumeroIdentificacion,Chasis,Placa, Accion);
            Procesar.ProcesarInformacion();
        }

        private void MostrarListadoClientes(int ReportePreciso)
        {
            string _Numeroidentificacion = string.IsNullOrEmpty(txtRNCCedula.Text.Trim()) ? null : txtRNCCedula.Text.Trim();
            string _Nombre = string.IsNullOrEmpty(txtNombre.Text.Trim()) ? null : txtNombre.Text.Trim();
            string _Placa = string.IsNullOrEmpty(txtPlacaConsulta.Text.Trim()) ? null : txtPlacaConsulta.Text.Trim();
            string _Chasis = string.IsNullOrEmpty(txtChasisConsulta.Text.Trim()) ? null : txtChasisConsulta.Text.Trim();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();

            var BuscarListado = ObjDataSuperIntendencia.Value.BuscaPersonasSuperIntendenciaCliente(
                _Numeroidentificacion,
                _Nombre,
                _Chasis,
                _Placa,
                _Ramo,
                null,null,null,
                ReportePreciso);
            if (BuscarListado.Count() < 1)
            {
                lbCantidadRegistrosClienteVariable.Text = "NO";
                lbCantidadRegistrosClienteVariable.ForeColor = System.Drawing.Color.Red;
                rpListadoBusquedaCliente.DataSource = null;
                rpListadoBusquedaCliente.DataBind();
            }
            else
            {
                lbCantidadRegistrosClienteVariable.Text = "SI";
                lbCantidadRegistrosClienteVariable.ForeColor = System.Drawing.Color.Green;

                Paginar_Clientes(ref rpListadoBusquedaCliente, BuscarListado, 10, ref lbCantidadPaginaVAriableCliente, ref btnPrimeraPaginaCliente, ref btnAnteriorCliente, ref btnSiguienteCliente, ref btnUltimoCliente);
                HandlePaging_Clientes(ref dtPaginacionCliente, ref lbPaginaActualVariavleCliente);
                divPaginacionCliente.Visible = true;
            }
        }

        private void MostrarListadoIntermediarios() {
            string _NumeroIdentificacion = string.IsNullOrEmpty(txtRNCCedula.Text.Trim()) ? null : txtRNCCedula.Text.Trim();
            string _Nombre = string.IsNullOrEmpty(txtNombre.Text.Trim()) ? null : txtNombre.Text.Trim();

            var Listado = ObjDataSuperIntendencia.Value.BuscaPersonasSuperIntendenciaIntermediario(
                new Nullable<int>(),
                _NumeroIdentificacion,
                _Nombre);
            if (Listado.Count() < 1)
            {
                lbCantidadIntermediariosSupervisorVariable.Text = "NO";
                lbCantidadIntermediariosSupervisorVariable.ForeColor = System.Drawing.Color.Red;
            }
            else {
                lbCantidadIntermediariosSupervisorVariable.ForeColor = System.Drawing.Color.Green;
                lbCantidadIntermediariosSupervisorVariable.Text = "SI";
              //  CurrentPage_IntermediariosSupervisores = 0;
                Paginar_IntermediariosSupervisores(ref rpListadoIntermediarios, Listado, 10, ref lbCantidadPaginaVAriableIntermedairaio, ref btnPrimeroIntermediario, ref btnAnteriorIntermediario, ref btnSiguienteIntermediario, ref btnUltimoIntermediario);
                HandlePaging_IntermediariosSupervisores(ref dtIntermediario, ref lbPaginaActualVariavleIntermediario);
                DivPaginacionIntermediario.Visible = true;
            }
        }
        private void SeleccionarRegistrosClientes(string Poliza, decimal Cotizacion, decimal Secuencia, int ReportePreciso) {


            var BuscarRegistroSeleccionado = ObjDataSuperIntendencia.Value.BuscaPersonasSuperIntendenciaCliente(
                null,
                null,
                null,
                null,
                null,
                Poliza,
                Cotizacion,
                Secuencia,
                ReportePreciso);
            Paginar_Clientes(ref rpListadoBusquedaCliente, BuscarRegistroSeleccionado, 1, ref lbCantidadPaginaVAriableCliente, ref btnPrimeraPaginaCliente, ref btnAnteriorCliente, ref btnSiguienteCliente, ref btnUltimoCliente);
            HandlePaging_Clientes(ref dtPaginacionCliente, ref lbPaginaActualVariavleCliente);
            DivBloqueDetalleCliente.Visible = true;
            foreach (var n in BuscarRegistroSeleccionado) {
                txtNombreDetalleCliente.Text = n.Nombre;
                txtENCDetalleCliente.Text = n.NumeroIdentificacion;
                txtRamoDetalleCliente.Text = n.Ramo;
                txtNombreVendedorDetalleCliente.Text = n.NombreVendedor;
                txtRNCVendedorDetalleCliente.Text = n.RNCIntermediario;
                txtLicenciaDetalleVendedor.Text = n.LicenciaSeguro;
                decimal MontoAsegurado = (decimal)n.MontoAsegurado;
                txtMontoAseguradoDetalleCliente.Text = MontoAsegurado.ToString("N2");
                decimal Prima = (decimal)n.Prima;
                txtPrimaDetalleCliente.Text = Prima.ToString("N2");
                txtInicioVigenciaDetalleCliente.Text = n.InicioVigencia;
                txtFinVigenciaDetalleCliente.Text = n.FinVigencia;
                txtPolizaDetalleCliente.Text = n.poliza;
                DivBloqueDetalleCliente.Visible = true;
            }
            //MOSTRAR DETALLE
        }

        private void MostrarListadoProveedores() {
            string _NombreProveedor = string.IsNullOrEmpty(txtNombre.Text.Trim()) ? null : txtNombre.Text.Trim();
            string _RNC = string.IsNullOrEmpty(txtRNCCedula.Text.Trim()) ? null : txtRNCCedula.Text.Trim();

            var Listado = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaProveedor(
                new Nullable<int>(),
                _NombreProveedor,
                _RNC);
            if (Listado.Count() < 1)
            {
                lbCantidadProveedorVariable.Text = "NO";
                lbCantidadProveedorVariable.ForeColor = System.Drawing.Color.Red;
            }
            else {
                lbCantidadProveedorVariable.Text = "SI";
                lbCantidadProveedorVariable.ForeColor = System.Drawing.Color.Green;
                Paginar_Proveedores(ref rpListadoProveedores, Listado, 10, ref lbCantidadPaginaVAriableProveedor, ref btnPrimeroProveedor, ref btnAnteriorProveedor, ref btnSiguienteProveedor, ref AnteriorUltimoProveedor);
                HandlePaging_Proveedores(ref dtProveedor, ref lbPaginaActualVariavleProveedor);
                DivPaginacionProveedores.Visible = true;
            }
        }

        private void MostrarListadoAsegurado() {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim())) { }
            else {
                string _NombreAsegurado = string.IsNullOrEmpty(txtNombre.Text.Trim()) ? null : txtNombre.Text.Trim();

                var Buscar = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaAsegurado(_NombreAsegurado, null, null, null);
                if (Buscar.Count() < 1)
                {
                    lbCantidadRegistrosAseguradoBajoPolizaVariable.Text = "NO";
                    lbCantidadRegistrosAseguradoBajoPolizaVariable.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbCantidadRegistrosAseguradoBajoPolizaVariable.Text = "SI";
                    lbCantidadRegistrosAseguradoBajoPolizaVariable.ForeColor = System.Drawing.Color.Green;

                    Paginar_AseguradoBajoPoliza(ref rpListadoRegistrosasegurado, Buscar, 10, ref lbCantidadPaginaVAriableAsegurado, ref btnPrimeraPaginaAseguradoBajoPoliza, ref btnPaginaAnteriorAseguradoBajoPoliza, ref btnSiguientePaginaAseguradoBajoPoliza, ref btnUltimaPaginaAseguradoBajoPoliza);
                    HandlePaging_AseguradoBajoPoliza(ref dtAsegurado, ref lbPaginaActualVariavleAsegurado);
                    DivPaginacionInformacionAsegurado.Visible = true;
                }
            }
        }

        private void MostrarListadoAseguradoGeneral() {
            string _Nombre = string.IsNullOrEmpty(txtNombre.Text.Trim()) ? null : txtNombre.Text.Trim();
            string _NumeroRNC = string.IsNullOrEmpty(txtRNCCedula.Text.Trim()) ? null : txtRNCCedula.Text.Trim();

            var BuscarRegistro = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaAseguradoGeneral(
                _Nombre,
                _NumeroRNC,
                null, null, null);
            if (BuscarRegistro.Count() < 1) {
                lbCantidadRegistrosAseguradoVariable.Text = "NO";
                lbCantidadRegistrosAseguradoVariable.ForeColor = System.Drawing.Color.Red;
            }
            else {
                lbCantidadRegistrosAseguradoVariable.Text = "SI";
                lbCantidadRegistrosAseguradoVariable.ForeColor = System.Drawing.Color.Green;

                Paginar_Asegurado(ref rpIDListadoAseguradoGeneral, BuscarRegistro, 10, ref lbCantidadPaginaVAriableAseguradoGeneral, ref btnPrimeroAseguradoGeneral, ref btnAnteriorAseguradoGeneral, ref btnSiguienteAseguradoGeneral, ref btnUltimoAseguradoGeneral);
                HandlePaging_Asegurado(ref dtAseguradoGeneral, ref lbPaginaActualVariavleAseguradoGeneral);
                DivPaginacionAseguradoGeneral.Visible = true;
            }
        }

        private void MostrarListadoDependientes() {
            string _Nombre = string.IsNullOrEmpty(txtNombre.Text.Trim()) ? null : txtNombre.Text.Trim();
            string _RNC = string.IsNullOrEmpty(txtRNCCedula.Text.Trim()) ? null : txtRNCCedula.Text.Trim();

            var Buscar = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaDependente(
                _Nombre,
                _RNC,
                null, null, null);
            if (Buscar.Count() < 1) {
                lbCantidadRegistrosDependienteVariable.Text = "NO";
                lbCantidadRegistrosDependienteVariable.ForeColor = System.Drawing.Color.Red;
            }
            else {
                lbCantidadRegistrosDependienteVariable.Text = "SI";
                lbCantidadRegistrosDependienteVariable.ForeColor = System.Drawing.Color.Green;

                Paginar_Dependiente(ref rpListadoDependientes, Buscar, 10, ref lbCantidadPaginaVAriableDependiente, ref btnPrimeroDependiente, ref btnAnteriorDependiente, ref btnSiguienteDependiente, ref btnUltimoDependiente);
                HandlePaging_Dependiente(ref dtDependiente, ref lbPaginaActualVariavleDependiente);
                DivPaginacionDependiente.Visible = true;
            }
        }


        private void MostrarInformacionArchivos() {
            decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;
            var BuscaInformacionRegistrada = ObjDataSuperIntendencia.Value.BuscarInformacionRegistrada(
                IdUsuario, null, null);
            if (BuscaInformacionRegistrada.Count() < 1)
            {
                lbCantidadRegistrosProcesadosVariable.Text = "0";
            }
            else
            {
                int CantidadEncontrada = BuscaInformacionRegistrada.Count;
                lbCantidadRegistrosProcesadosVariable.Text = CantidadEncontrada.ToString("N0");
                Paginar_Archivo(ref rpRegistrosCargadoArchivo, BuscaInformacionRegistrada, 10, ref lbCantidadPaginaVAriableArchivo, ref btnPrimeroarchivo, ref btnAnteriorArchivo, ref btnSiguienteArchivo, ref btnUltimoArchivo);
                HandlePaging_Archivo(ref dtArchivo, ref lbPaginaActualVariavleArchivo);
            }
        }

        /// <summary>
        /// Este metodo marca el check de todo siempre y cuando todos los demas estan marcados
        /// </summary>
        private void ValidarTodosLosCheck() {
            if (cbCliente.Checked == true &&
                            cbIntermediario.Checked == true &&
                            cbProvedor.Checked == true &&
                            cbAseguradoBajoPoliza.Checked == true &&
                            cbAsegurado.Checked == true == true &&
                            cbDependiente.Checked == true &&
                            cbCheque.Checked == true &&
                            cbDocumentosAmigos.Checked == true &&
                            cbReclamaciones.Checked == true &&
                            cbPlaca.Checked == true &&
                            cbChasis.Checked == true)
            {
                cbTodos.Checked = true;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                Label lbNombreUsuarioCOnectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbNombreUsuarioCOnectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "CONSULTA DE REGISTRO DE PERSONAS";
                DivBuscarArchivoExcel.Visible = false;


                rbHojaExcelPlano.Checked = true;
                rbConsultaNormal.Checked = true;
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjDataSistema.Value.BuscaListas("RAMO", null, null), true);
                DivBloqueDetalleCliente.Visible = false;
                DivPaginacionIntermediario.Visible = false;
                DivDetalleInformacionIntermediarioSeleccionado.Visible = false;
                DivPaginacionIntermediario.Visible = false;
                DivPaginacionProveedores.Visible = false;
                DivPaginacionInformacionAsegurado.Visible = false;
                DivPaginacionAseguradoGeneral.Visible = false;
                DivPaginacionDependiente.Visible = false;


                DivBuscarArchivoExcel.Visible = false;
                DivBloqueConsulta.Visible = true;
                DivBloqueProcesoLote.Visible = false;
                btnProcesarRegistros.Visible = false;
  
            }

       
        }

        protected void dtPaginacionCliente_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_Clientes = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoClientes(1);
        }

        protected void dtPaginacionCliente_ItemDataBound(object sender, DataListItemEventArgs e)
        {
           
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cbBusquedaPorLote.Checked == true) {
                ProcesarInformacionArchivo("", "","","", "DELETE");
                //BUSCAMOS Y LEEMOS LA RUTA DEL ARCHIVO SELECCIONADO
                try {

                    string ruta_carpeta = HttpContext.Current.Server.MapPath("~/Temporal");

                    if (!Directory.Exists(ruta_carpeta))
                    {
                        Directory.CreateDirectory(ruta_carpeta);
                    }

                    var ruta_guardado = Path.Combine(ruta_carpeta, FileUpload1.FileName);
                    FileUpload1.SaveAs(ruta_guardado);
                    string RutaArchivoSeleccionado = ruta_guardado;

                    SLDocument sl = new SLDocument(RutaArchivoSeleccionado);
                    int Row = 2;
                    while (!string.IsNullOrEmpty(sl.GetCellValueAsString(Row, 1)))
                    {
                        string Nombre = sl.GetCellValueAsString(Row, 1);
                        string Cedula = sl.GetCellValueAsString(Row, 2);
                        string Chasis = sl.GetCellValueAsString(Row, 3);
                        string Placa = sl.GetCellValueAsString(Row, 4);
                        ProcesarInformacionArchivo(Nombre, Cedula, Chasis, Placa, "INSERT");

                        Row++;

                    }
                    MostrarInformacionArchivos();


                }
                catch (Exception ex) {
                    lbError.Visible = true;
                    lbError.Text = ex.Message;
                    string Mensaje = "Error al procesar el archivo, no se selecciono ninguno o los parametros de este no son correctos, favor de verificar, Codigo de Error: ";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + Mensaje + "');", true);


                 
                }

                }
            else if (cbBusquedaPorLote.Checked == false) {
                if (rbConsultaNormal.Checked)
                {
                    if (string.IsNullOrEmpty(txtRNCCedula.Text.Trim()) && string.IsNullOrEmpty(txtNombre.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "CamposBusquedaNormalVacio()", "CamposBusquedaNormalVacio();", true);
                    }
                    else
                    {
                        MostrarListadoClientes(1);
                        MostrarListadoIntermediarios();
                        MostrarListadoProveedores();
                        MostrarListadoAsegurado();
                        MostrarListadoAseguradoGeneral();
                        MostrarListadoDependientes();
                    }
                }
                else if (rbConsultaChasisPlaca.Checked)
                {
                    if (string.IsNullOrEmpty(txtPlacaConsulta.Text.Trim()) && string.IsNullOrEmpty(txtChasisConsulta.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "CamposChasisPlacaVacios()", "CamposChasisPlacaVacios();", true);
                    }
                    else
                    {
                        MostrarListadoClientes(2);
                        //MostrarListadoIntermediarios();
                        //MostrarListadoProveedores();
                    }
                }
            }
        }


        protected void dtIntermediario_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_IntermediariosSupervisores = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoIntermediarios();
        }

        protected void dtIntermediario_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtProveedor_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoProveedores();
        }

        protected void dtProveedor_ItemDataBound(object sender, DataListItemEventArgs e)
        {


        }

        protected void dtAsegurado_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoAsegurado();
        }

        protected void dtAsegurado_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtAseguradoGeneral_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoAseguradoGeneral();
        }

        protected void dtAseguradoGeneral_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }


        protected void dtDependiente_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoDependientes();
        }

        protected void dtDependiente_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void cbBusquedaPorLote_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBusquedaPorLote.Checked == true)
            {
                DivBuscarArchivoExcel.Visible = true;
                DivBloqueConsulta.Visible = false;
                DivBloqueProcesoLote.Visible = true;
                btnProcesarRegistros.Visible = true;
                rbTodosLosParametros.Checked = true;
            }
            else {
                DivBuscarArchivoExcel.Visible = false;
                DivBloqueConsulta.Visible = true;
                DivBloqueProcesoLote.Visible = false;
                btnProcesarRegistros.Visible = false;
            }
        }

        protected void dtArchivo_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtArchivo_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnProcesarRegistros_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {

                ProcesarInformacionPorlote((decimal)Session["IdUsuario"]);

                if (rbHojaExcelPlano.Checked == true) {

                    var ExportarExcelPlano = (from n in ObjDataSuperIntendencia.Value.ResultadoBusquedaSuperIntendencia((decimal)Session["IdUsuario"])
                                              select new
                                              {
                                                //  IdUsuario = n.IdUsuario,
                                                  ProcesadoPor = n.ProcesadoPor,
                                                  Nombre = n.Nombre,
                                                  NumeroIdentificacion = n.NumeroIdentificacion,
                                                  Poliza = n.Poliza,
                                                  Reclamacion = n.Reclamacion,
                                                  Estatus = n.Estatus,
                                                  Ramo = n.Ramo,
                                                  MontoAsegurado = n.MontoAsegurado,
                                                  Prima = n.Prima,
                                                  InicioVigencia0 = n.InicioVigencia0,
                                                  InicioVigencia = n.InicioVigencia,
                                                  FinVigencia0 = n.FinVigencia0,
                                                  FinVigencia = n.FinVigencia,
                                                  TipoBusqueda = n.TipoBusqueda,
                                                  EncontradoComo = n.EncontradoComo,
                                                  Comentario = n.Comentario
                                              }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Resultado Busqueda Personas", ExportarExcelPlano);
                
                }
                else {
                    GenerarReporte(Server.MapPath("ResultadoBusquedaPersonas.rpt"), "Resultado Busqueda Personas", (decimal)Session["IdUsuario"]);
                }

            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();


            }
        }

        protected void cbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodos.Checked == true) {
                cbCliente.Checked = true;
                cbIntermediario.Checked = true;
                cbProvedor.Checked = true;
                cbAseguradoBajoPoliza.Checked = true;
                cbAsegurado.Checked = true;
                cbDependiente.Checked = true;
                cbCheque.Checked = true;
                cbDocumentosAmigos.Checked = true;
                cbReclamaciones.Checked = true;
                cbPlaca.Checked = true;
                cbChasis.Checked = true;
            }
            else if (cbTodos.Checked == false) {
                cbCliente.Checked = false;
                cbIntermediario.Checked = false;
                cbProvedor.Checked = false;
                cbAseguradoBajoPoliza.Checked = false;
                cbAsegurado.Checked = false;
                cbDependiente.Checked = false;
                cbCheque.Checked = false;
                cbDocumentosAmigos.Checked = false;
                cbReclamaciones.Checked = false;
                cbPlaca.Checked = false;
                cbChasis.Checked = false;
            }
        }

        protected void cbCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCliente.Checked == false)
            {
                cbTodos.Checked = false;
            }
            else if (cbCliente.Checked == true) {
                ValidarTodosLosCheck();
            }
        }

        protected void cbIntermediario_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIntermediario.Checked == false)
            {
                cbTodos.Checked = false;

            }
            else if (cbIntermediario.Checked == true) {
                ValidarTodosLosCheck();
            }
        }

        protected void cbProvedor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProvedor.Checked == false)
            {
                cbTodos.Checked = false;

            }
            else if (cbProvedor.Checked == true) {
                ValidarTodosLosCheck();
            }
        }

        protected void cbAseguradoBajoPoliza_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAseguradoBajoPoliza.Checked == false)
            {
                cbTodos.Checked = false;

            }
            else if (cbAseguradoBajoPoliza.Checked == true) {
                ValidarTodosLosCheck();
            }

        }

        protected void cbAsegurado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAsegurado.Checked == false)
            {
                cbTodos.Checked = false;

            }
            else if (cbAsegurado.Checked == true) {
                ValidarTodosLosCheck();
            }
        }

        protected void cbDependiente_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDependiente.Checked == false)
            {
                cbTodos.Checked = false;

            }
            else if (cbDependiente.Checked == true) {
                ValidarTodosLosCheck();
            }
            

        }

        protected void cbCheque_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCheque.Checked == false)
            {
                cbTodos.Checked = false;

            }
            else if (cbCheque.Checked == true) {
                ValidarTodosLosCheck();
            }
        }

        protected void btnPrimeraPaginaCliente_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Clientes = 0;
            MostrarListadoClientes(1);
        }

        protected void btnAnteriorCliente_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Clientes += -1;
            MostrarListadoClientes(1);
            MoverValoresPaginacion_Clientes((int)OpcionesPaginacionValores_Clientes.PaginaAnterior, ref lbPaginaActualVariavleCliente, ref lbCantidadPaginaVAriableCliente);
        }

        protected void btnSiguienteCliente_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Clientes += 1;
            MostrarListadoClientes(1);
        }

        protected void btnseleccionarRegistrosBusquedaClienteNuevo_Click(object sender, ImageClickEventArgs e)
        {
            var PolizaSeleccionada = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfPolizaSeleccionada = ((HiddenField)PolizaSeleccionada.FindControl("hfPolizaBusquedaCliente")).Value.ToString();

            var CotizacionSeleccionada = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfCotizacionSeleccionada = ((HiddenField)CotizacionSeleccionada.FindControl("hfCotizacionBusquedaCliente")).Value.ToString();

            var SecuenciaSeleccionada = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfSecuenciaSeleccionada = ((HiddenField)SecuenciaSeleccionada.FindControl("hfSecuenciaBusquedaCliente")).Value.ToString();

            SeleccionarRegistrosClientes(hfPolizaSeleccionada.ToString(), Convert.ToDecimal(hfCotizacionSeleccionada), Convert.ToDecimal(hfSecuenciaSeleccionada), 1);
            DivBloqueDetalleCliente.Visible = true;
        }

        protected void btnPrimeroIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_IntermediariosSupervisores = 0;
            MostrarListadoIntermediarios();
        }

        protected void btnAnteriorIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_IntermediariosSupervisores += -1;
            MostrarListadoIntermediarios();
            MoverValoresPaginacion_IntermediariosSupervisores((int)OpcionesPaginacionValores_IntermediariosSupervisores.PaginaAnterior, ref lbPaginaActualVariavleIntermediario, ref lbCantidadPaginaVAriableIntermedairaio);
        }

        protected void btnSiguienteIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_IntermediariosSupervisores += 1;
            MostrarListadoIntermediarios();
        }

        protected void btnUltimoIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_IntermediariosSupervisores = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoIntermediarios();
            MoverValoresPaginacion_IntermediariosSupervisores((int)OpcionesPaginacionValores_IntermediariosSupervisores.UltimaPagina, ref lbPaginaActualVariavleIntermediario, ref lbCantidadPaginaVAriableIntermedairaio);
        }

        protected void btnUltimoCliente_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Clientes = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoClientes(1);
            MoverValoresPaginacion_Clientes((int)OpcionesPaginacionValores_Clientes.UltimaPagina, ref lbPaginaActualVariavleCliente, ref lbCantidadPaginaVAriableCliente);
        }

        protected void cbDocumentosAmigos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDocumentosAmigos.Checked == false)
            {
                cbTodos.Checked = false;

            }
            else if (cbDocumentosAmigos.Checked == true) {
                ValidarTodosLosCheck();
            }
        }

        protected void cbReclamaciones_CheckedChanged(object sender, EventArgs e)
        {
            if (cbReclamaciones.Checked == false)
            {
                cbTodos.Checked = false;

            }
            else if (cbReclamaciones.Checked == true) {
                ValidarTodosLosCheck();
            }
        }

        protected void cbPlaca_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPlaca.Checked == false)
            {
                cbTodos.Checked = false;

            }
            else if (cbPlaca.Checked == true)
            {
                ValidarTodosLosCheck();
            }
           
        }

        protected void btnSeleccionarregistroProveedorNuevo_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfCodigoProveedor = ((HiddenField)ItemSeleccionado.FindControl("hfCodigoproveedor")).Value.ToString();

            var BuscarRegistros = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaProveedor(
                Convert.ToInt32(hfCodigoProveedor));
            Paginar_Proveedores(ref rpListadoProveedores, BuscarRegistros, 1, ref lbCantidadPaginaVAriableProveedor, ref btnPrimeroProveedor, ref btnPrimeroProveedor, ref btnSiguienteProveedor, ref AnteriorUltimoProveedor);
            HandlePaging_Proveedores(ref dtProveedor, ref lbPaginaActualVariavleProveedor);
            foreach (var n in BuscarRegistros)
            {
                txtDetalleProveedorCodigo.Text = n.Codigo.ToString();
                txtDetalleProveedorTipoProveedor.Text = n.TipoCliente;
                txtDetalleProveedorNombre.Text = n.NombreCliente;
                txtDetalleProveedorTipoRNC.Text = n.TipoIdentificacion;
                txtDetalleProveedorRNC.Text = n.Rnc;
                txtDetalleProveedorFechaCreado.Text = n.FechaCreado;
                txtDetalleProveedorTelefonoCasa.Text = n.TelefonoCasa;
                txtDetalleProveedorTelefonoOficina.Text = n.TelefonoOficina;
                txtDetalleProveedorCelular.Text = n.Celular;
                txtDetalleProveedorCuentaBanco.Text = n.CuentaBanco;
                txtDetalleProveedorBanco.Text = n.NombreBanco;
                txtDetalleProbeedorTipoCuentaBAnco.Text = n.TipoCuentaBanco;
                txtDetalleProveedorClaseProveedor.Text = n.ClaseProveedor;
                txtDetalleProveedorFechaUltimoPago.Text = n.FechaUltPago;
                decimal LimiteCredito = (decimal)n.LimiteCredito;
                txtDetalleProveedorLimiteCredito.Text = LimiteCredito.ToString("N2");
                txtDetalleProveedorDireccion.Text = n.Direccion;
                decimal TotalPagado = (decimal)n.ToTalPagado;
                txtDetalleProveedorTotalPagado.Text = TotalPagado.ToString("N2");
                int CantidadSolicitud = (int)n.CantidadSolicitud;
                int CantidadSolicitudCanceladas = (int)n.CantidadSolicitudCanceladas;
                txtDetalleProveedorCantidadSolicitud.Text = CantidadSolicitud.ToString("N0");
                txtDetalleProveedorCantidadSolicitudCanceadas.Text = CantidadSolicitudCanceladas.ToString("N0");
                txtDetalleProveedorUltimaFechaSOlicitud.Text = n.UltimaFechaSolicitud;
                txtDetalleProveedorNumeroSolicitud.Text = n.NoSolicitud.ToString();
                txtDetalleProveedorDescripcionTipoSolciitid.Text = n.DescripcionTipoSolicitud;
                decimal ValorSolicitud = (decimal)n.Valor;
                txtDetalleProveedorValor.Text = ValorSolicitud.ToString("N2");
                txtDetalleProveedorNumeroCheque.Text = n.NumeroCheque.ToString();
                txtDetalleProveedorFechaCheque.Text = n.FechaCheque;
                txtDetalleproveedorUsuario.Text = n.Usuario;
                txtDetalleProveedorConcepto1.Text = n.Concepto1;
                txtDetalleProveedorConcepto2.Text = n.Concepto2;
            }
            DivDetalleProveedores.Visible = true;
        }

        protected void btnPrimeroProveedor_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Proveedores = 0;
            MostrarListadoProveedores();
        }

        protected void btnSeleccionarregistrosInformacionAseguradoBajoPoliza_Click(object sender, ImageClickEventArgs e)
        {
            var PolizaSeleccionada = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var HfPolizaSeleccionada = ((HiddenField)PolizaSeleccionada.FindControl("hfPolizaInformacionAsegurado")).Value.ToString();

            var CotizzacionSeleccionada = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var HfCotizzacionSeleccionada = ((HiddenField)CotizzacionSeleccionada.FindControl("hfCotizacionInformacionAsegurado")).Value.ToString();

            var itemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var HFitemSeleccionado = ((HiddenField)itemSeleccionado.FindControl("hfSecuenciaInformacionAsegurado")).Value.ToString();

            var SacarInformacion = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaAsegurado(
                null,
                HfPolizaSeleccionada,
                Convert.ToDecimal(HfCotizzacionSeleccionada),
                Convert.ToInt32(HFitemSeleccionado));
            Paginar_AseguradoBajoPoliza(ref rpListadoRegistrosasegurado, SacarInformacion, 1, ref lbCantidadPaginaVAriableAsegurado, ref btnPrimeraPaginaAseguradoBajoPoliza, ref btnPaginaAnteriorAseguradoBajoPoliza, ref btnSiguientePaginaAseguradoBajoPoliza, ref btnUltimaPaginaAseguradoBajoPoliza);
            HandlePaging_AseguradoBajoPoliza(ref dtAsegurado, ref lbPaginaActualVariavleAsegurado);
            foreach (var n in SacarInformacion)
            {
                txtDetalleaseguradoNombre.Text = n.Nombre;
                txtDetalleaseguradoPoliza.Text = n.Poliza;
                txtDetalleaseguradoEstatus.Text = n.Estatus;
                txtDetalleaseguradoitem.Text = n.Item.ToString();
                txtDetalleaseguradoInicioVigencia.Text = n.InicioVigencia;
                txtDetalleaseguradoFinVigencia.Text = n.FinVigencia;
                txtDetalleaseguradoIntermediario.Text = n.Intermediario;
                txtDetalleaseguradoRNCIntermediario.Text = n.RNCIntermediario;
                txtDetalleaseguradoLicenciaIntermediario.Text = n.Licencia;
                decimal Prima = (decimal)n.Prima;
                txtDetalleaseguradoPrima.Text = Prima.ToString("N2");
                txtDetalleaseguradoMontoasegurado.Text = n.MontoAsegurado.ToString();
                txtDetalleaseguradoTipoVehiculo.Text = n.TipoVehiculo;
                txtDetalleaseguradoMarca.Text = n.Marca;
                txtDetalleaseguradoModelo.Text = n.Modelo;
                txtDetalleaseguradoChasis.Text = n.Chasis;
                txtDetalleaseguradoPlaca.Text = n.Placa;
                txtDetalleaseguradoAno.Text = n.Ano;
                txtDetalleaseguradoColor.Text = n.Color;
            }
            DivDetalleAsegurado.Visible = true;
        }

        protected void btnPrimeraPaginaAseguradoBajoPoliza_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_AseguradoBajoPoliza = 0;
            MostrarListadoAsegurado();
        }

        protected void btnPaginaAnteriorAseguradoBajoPoliza_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_AseguradoBajoPoliza += -1;
            MostrarListadoAsegurado();
            MoverValoresPaginacion_AseguradoBajoPoliza((int)OpcionesPaginacionValores_AseguradoBajoPoliza.PaginaAnterior, ref lbPaginaActualVariavleAsegurado, ref lbCantidadPaginaVAriableAsegurado);
        }

        protected void btnSiguientePaginaAseguradoBajoPoliza_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_AseguradoBajoPoliza += 1;
            MostrarListadoAsegurado();
        }

        protected void btnUltimaPaginaAseguradoBajoPoliza_Click(object sender, ImageClickEventArgs e)
        {

            CurrentPage_AseguradoBajoPoliza = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoAsegurado();
            MoverValoresPaginacion_AseguradoBajoPoliza((int)OpcionesPaginacionValores_AseguradoBajoPoliza.UltimaPagina, ref lbPaginaActualVariavleAsegurado, ref lbCantidadPaginaVAriableAsegurado);
        }

        protected void btnSeleccionarRegistroAseguradoGeneralNuevo_Click(object sender, ImageClickEventArgs e)
        {
            var CotizacionSeleccionada = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfControlCotiacionSeleccionada = ((HiddenField)CotizacionSeleccionada.FindControl("hfCotizacionAseguradoGeneral")).Value.ToString();

            var SecuenciaSeleccionada = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfControlSecuenciaSeleccionada = ((HiddenField)SecuenciaSeleccionada.FindControl("hfItemAseguradoGeneral")).Value.ToString();

            var NumeroAseguradoSeleccionada = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfControlNumeroAseguradoSeleccionada = ((HiddenField)NumeroAseguradoSeleccionada.FindControl("hfIdAseguradoAseguradoGeneral")).Value.ToString();

            var Seleccionrregistro = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaAseguradoGeneral(
                null, null,
                Convert.ToDecimal(hfControlCotiacionSeleccionada),
                Convert.ToDecimal(hfControlSecuenciaSeleccionada),
                Convert.ToDecimal(hfControlNumeroAseguradoSeleccionada));
            Paginar_Asegurado(ref rpIDListadoAseguradoGeneral, Seleccionrregistro, 1, ref lbCantidadPaginaVAriableAseguradoGeneral, ref btnPrimeroAseguradoGeneral, ref btnAnteriorAseguradoGeneral, ref btnSiguienteAseguradoGeneral, ref btnUltimoAseguradoGeneral);
            HandlePaging_Asegurado(ref dtAseguradoGeneral, ref lbPaginaActualVariavleAseguradoGeneral);
            foreach (var n in Seleccionrregistro)
            {
                txtDetalleAseguradoGeneralPoliza.Text = n.Poliza;
                txtDetalleAseguradoGeneralEstatus.Text = n.Estatus;
                txtDetalleAseguradoGeneralCotizacion.Text = n.Cotizacion.ToString();
                txtDetalleAseguradoGeneralSecuencia.Text = n.Secuencia.ToString();
                txtDetalleAseguradoGeneralIdAsegurado.Text = n.IdAsegurado.ToString();
                txtDetalleAseguradoGeneralNombre.Text = n.Nombre;
                txtDetalleAseguradoGeneralParentezco.Text = n.Parentezco;
                txtDetalleAseguradoGeneralRNC.Text = n.RNC;
                txtDetalleAseguradoGeneralFechaNacimiento.Text = n.FechaNacimiento;
                txtDetalleAseguradoGeneralSexo.Text = n.Sexo;
                txtDetalleAseguradoGeneralInicioVigencia.Text = n.InicioVigencia;
                txtDetalleAseguradoGeneralFinVigencia.Text = n.FinVigencia;
            }
            DivDetalleAseguradoGeneral.Visible = true;
        }

        protected void btnPrimeroAseguradoGeneral_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Asegurado = 0;
            MostrarListadoAseguradoGeneral();
        }

        protected void btnAnteriorAseguradoGeneral_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Asegurado += -1;
            MostrarListadoAseguradoGeneral();
            MoverValoresPaginacion_Asegurado((int)OpcionesPaginacionValores_Asegurado.PaginaAnterior, ref lbPaginaActualVariavleAseguradoGeneral, ref lbCantidadPaginaVAriableAseguradoGeneral);
        }

        protected void btnSiguienteAseguradoGeneral_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Asegurado += 1;
            MostrarListadoAseguradoGeneral();
        }

        protected void btnUltimoAseguradoGeneral_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Asegurado = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoAseguradoGeneral();
            MoverValoresPaginacion_Asegurado((int)OpcionesPaginacionValores_Asegurado.UltimaPagina, ref lbPaginaActualVariavleAseguradoGeneral, ref lbCantidadPaginaVAriableAseguradoGeneral);
        }

        protected void btnSeleccionarRegistroDependienteNuevo_Click(object sender, ImageClickEventArgs e)
        {
            var CotizacionSeleccionada = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var HfCotizacionSeleccionada = ((HiddenField)CotizacionSeleccionada.FindControl("hfCotizacionDependiente")).Value.ToString();

            var SecuenciaSeleccionada = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var HfSecuenciaSeleccionada = ((HiddenField)SecuenciaSeleccionada.FindControl("hfSecuenciaDependiente")).Value.ToString();

            var IdaseguradoSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfIdAseguradoSeleccionado = ((HiddenField)IdaseguradoSeleccionado.FindControl("hfIdAseguradoDependiente")).Value.ToString();

            var RegistroSeleccionado = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaDependente(
                null, null,
                Convert.ToDecimal(HfCotizacionSeleccionada),
                Convert.ToDecimal(HfSecuenciaSeleccionada),
                Convert.ToDecimal(hfIdAseguradoSeleccionado));
            Paginar_Dependiente(ref rpListadoDependientes, RegistroSeleccionado, 1, ref lbCantidadPaginaVAriableDependiente, ref btnPrimeroDependiente, ref btnAnteriorDependiente, ref btnSiguienteDependiente, ref btnUltimoDependiente);
            HandlePaging_Dependiente(ref dtDependiente, ref lbPaginaActualVariavleDependiente);
            foreach (var n in RegistroSeleccionado)
            {
                txtDetalleDependientePoliza.Text = n.Poliza;
                txtDetalleDependienteEstatus.Text = n.Estatus;
                txtDetalleDependienteCotizacion.Text = n.Cotizacion.ToString();
                txtDetalleDependienteNombre.Text = n.Nombre;
                txtDetalleDependienteRNC.Text = n.RNC;
                txtDetalleDependienteIdAsegurado.Text = n.IdAsegurado.ToString();
                txtDetalleDependienteParentezco.Text = n.Parentezco;
                txtDetalleDependienteFechaNacimiento.Text = n.FechaNacimiento;
                txtDetalleDependienteSexo.Text = n.Sexo;
                txtDetalleDependienteSecuencia.Text = n.Secuencia.ToString();
                txtDetalleDependienteinicio.Text = n.InicioVigencia;
                txtDetalleDependienteFinVigencia.Text = n.FinVigencia;
            }
            DivDetalleDependientes.Visible = true;
        }

        protected void btnPrimeroDependiente_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Dependiente = 0;
            MostrarListadoDependientes();
        }

        protected void btnAnteriorDependiente_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Dependiente += -1;
            MostrarListadoDependientes();
            MoverValoresPaginacion_Dependiente((int)OpcionesPaginacionValores_Dependiente.PaginaAnterior, ref lbPaginaActualVariavleDependiente, ref lbCantidadPaginaVAriableDependiente);
        }

        protected void btnSiguienteDependiente_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Dependiente += 1;
            MostrarListadoDependientes();
        }

        protected void btnUltimoDependiente_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Dependiente = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoDependientes();
            MoverValoresPaginacion_Dependiente((int)OpcionesPaginacionValores_Dependiente.PaginaAnterior, ref lbPaginaActualVariavleDependiente, ref lbCantidadPaginaVAriableDependiente);
        }

        protected void btnPrimeroarchivo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Archivo = 0;
            MostrarInformacionArchivos();
        }

        protected void btnAnteriorArchivo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Archivo += -1;
            MostrarInformacionArchivos();
            MoverValoresPaginacion_Archivo((int)OpcionesPaginacionValores_Archivo.PaginaAnterior, ref lbPaginaActualVariavleArchivo, ref lbCantidadPaginaVAriableArchivo);

        }

        protected void btnSiguienteArchivo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Archivo += 1;
            MostrarInformacionArchivos();
        }

        protected void btnSiguienteIntermediario_Click1(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimoArchivo_Click(object sender, ImageClickEventArgs e)
        {

            CurrentPage_Archivo = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarInformacionArchivos();
            MoverValoresPaginacion_Archivo((int)OpcionesPaginacionValores_Archivo.UltimaPagina, ref lbPaginaActualVariavleArchivo, ref lbCantidadPaginaVAriableArchivo);
        }

        protected void btnAnteriorProveedor_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Proveedores += -1;
            MostrarListadoProveedores();
            MoverValoresPaginacion_Proveedores((int)OpcionesPaginacionValores_Proveedores.PaginaAnterior, ref lbPaginaActualVariavleProveedor, ref lbCantidadPaginaVAriableProveedor);
        }

        protected void btnSiguienteProveedor_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Proveedores += 1;
            MostrarListadoProveedores();
        }

        protected void AnteriorUltimoProveedor_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Proveedores = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoProveedores();
            MoverValoresPaginacion_Proveedores((int)OpcionesPaginacionValores_Proveedores.UltimaPagina, ref lbPaginaActualVariavleProveedor, ref lbCantidadPaginaVAriableProveedor);
        }

        protected void btnseleccionarIntermediarioSupervisorNuevo_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfCodigoIntermediario = ((HiddenField)ItemSeleccionado.FindControl("hfCodigointermediario")).Value.ToString();

            var BuscarRegistroSeleccionado = ObjDataSuperIntendencia.Value.BuscaPersonasSuperIntendenciaIntermediario(Convert.ToInt32(hfCodigoIntermediario), null, null);
            Paginar_IntermediariosSupervisores(ref rpListadoIntermediarios, BuscarRegistroSeleccionado, 10, ref lbCantidadPaginaVAriableIntermedairaio, ref btnPrimeroIntermediario, ref btnAnteriorIntermediario, ref btnSiguienteIntermediario, ref btnUltimoIntermediario);
            HandlePaging_IntermediariosSupervisores(ref dtIntermediario, ref lbPaginaActualVariavleIntermediario);
            DivPaginacionIntermediario.Visible = true;
            foreach (var n in BuscarRegistroSeleccionado)
            {
                txtBusquedaIntermediarioCodigoDetalle.Text = n.Codigo.ToString();
                txtBusquedaIntermediarioTipoRNCDetalle.Text = n.TipoIdentificacion;
                txtBusquedaIntermediarioNumeroIdentificacionDetalle.Text = n.Rnc;
                txtBusquedaIntermediarioNombreDetalle.Text = n.Nombre;
                txtBusquedaIntermediarioSupervisorDetalle.Text = n.Supervisor;
                txtBusquedaIntermediarioFechaEntradaDetalle.Text = n.FechaEntrada;
                txtBusquedaIntermediarioTelefonoResidenciaDetalle.Text = n.Telefono;
                txtBusquedaIntermediarioTelefonoOficinaDetalle.Text = n.TelefonoOficina;
                txtBusquedaIntermediarioCelularDetalle.Text = n.Celular;
                txtBusquedaIntermediarioLicenciaSeguroDetalle.Text = n.LicenciaSeguro;
                txtBusquedaIntermediarioOficinaDetalle.Text = n.NombreOficina;
                txtBusquedaIntermediarioFechaNacimientoDetalle.Text = n.FechaNacimiento;
                txtBusquedaIntermediarioCuentaBancoDetalle.Text = n.CtaBanco;
                txtBusquedaIntermediarioBancoDetalle.Text = n.Banco;
                txtBusquedaIntermediarioFormaPagoDetalle.Text = n.TipoPago;
                DivDetalleInformacionIntermediarioSeleccionado.Visible = true;
            }
            DivDetalleInformacionIntermediarioSeleccionado.Visible = true;
        }

        protected void cbChasis_CheckedChanged(object sender, EventArgs e)
        {
            if (cbChasis.Checked == false)
            {
                cbTodos.Checked = false;

            }
            else if (cbChasis.Checked == true)
            {
                ValidarTodosLosCheck();
            }
        }

        protected void btnConsultar_Click1(object sender, ImageClickEventArgs e)
        {
            if (cbBusquedaPorLote.Checked == true)
            {
                ProcesarInformacionArchivo("", "", "", "", "DELETE");
                //BUSCAMOS Y LEEMOS LA RUTA DEL ARCHIVO SELECCIONADO
                try
                {

                    string ruta_carpeta = HttpContext.Current.Server.MapPath("~/Temporal");

                    if (!Directory.Exists(ruta_carpeta))
                    {
                        Directory.CreateDirectory(ruta_carpeta);
                    }

                    var ruta_guardado = Path.Combine(ruta_carpeta, FileUpload1.FileName);
                    FileUpload1.SaveAs(ruta_guardado);
                    string RutaArchivoSeleccionado = ruta_guardado;

                    SLDocument sl = new SLDocument(RutaArchivoSeleccionado);
                    int Row = 2;
                    while (!string.IsNullOrEmpty(sl.GetCellValueAsString(Row, 1)))
                    {
                        string Nombre = sl.GetCellValueAsString(Row, 1);
                        string Cedula = sl.GetCellValueAsString(Row, 2);
                        string Chasis = sl.GetCellValueAsString(Row, 3);
                        string Placa = sl.GetCellValueAsString(Row, 4);
                        ProcesarInformacionArchivo(Nombre, Cedula, Chasis, Placa, "INSERT");

                        Row++;

                    }
                    //decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;
                    //var BuscaInformacionRegistrada = ObjDataSuperIntendencia.Value.BuscarInformacionRegistrada(
                    //    IdUsuario, null, null);
                    //if (BuscaInformacionRegistrada.Count() < 1)
                    //{
                    //    lbCantidadRegistrosProcesadosVariable.Text = "0";
                    //}
                    //else
                    //{
                    //    int CantidadEncontrada = BuscaInformacionRegistrada.Count;
                    //    lbCantidadRegistrosProcesadosVariable.Text = CantidadEncontrada.ToString("N0");
                    //    Paginar_Archivo(ref rpRegistrosCargadoArchivo, BuscaInformacionRegistrada, 10, ref lbCantidadPaginaVAriableArchivo, ref btnPrimeroarchivo, ref btnAnteriorArchivo, ref btnSiguienteArchivo, ref btnUltimoArchivo);
                    //    HandlePaging_Archivo(ref dtArchivo, ref lbPaginaActualVariavleArchivo);
                    //}
                    MostrarInformacionArchivos();
                }
                catch (Exception ex)
                {
                    lbError.Visible = true;
                    lbError.Text = ex.Message;
                    string Mensaje = "Error al procesar el archivo, no se selecciono ninguno o los parametros de este no son correctos, favor de verificar, Codigo de Error: ";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + Mensaje + "');", true);
                }

            }
            else if (cbBusquedaPorLote.Checked == false)
            {
                if (rbConsultaNormal.Checked)
                {
                    if (string.IsNullOrEmpty(txtRNCCedula.Text.Trim()) && string.IsNullOrEmpty(txtNombre.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "CamposBusquedaNormalVacio()", "CamposBusquedaNormalVacio();", true);
                    }
                    else
                    {
                        MostrarListadoClientes(1);
                        MostrarListadoIntermediarios();
                        MostrarListadoProveedores();
                        MostrarListadoAsegurado();
                        MostrarListadoAseguradoGeneral();
                        MostrarListadoDependientes();
                    }
                }
                else if (rbConsultaChasisPlaca.Checked)
                {
                    if (string.IsNullOrEmpty(txtPlacaConsulta.Text.Trim()) && string.IsNullOrEmpty(txtChasisConsulta.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "CamposChasisPlacaVacios()", "CamposChasisPlacaVacios();", true);
                    }
                    else
                    {
                        MostrarListadoClientes(2);
                        //MostrarListadoIntermediarios();
                        //MostrarListadoProveedores();
                    }
                }
            }
        }

        protected void btnProcesarRegistros_Click1(object sender, ImageClickEventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {

                ProcesarInformacionPorlote((decimal)Session["IdUsuario"]);

                if (rbHojaExcelPlano.Checked == true)
                {

                    var ExportarExcelPlano = (from n in ObjDataSuperIntendencia.Value.ResultadoBusquedaSuperIntendencia((decimal)Session["IdUsuario"])
                                              select new
                                              {
                                                  //  IdUsuario = n.IdUsuario,
                                                  ProcesadoPor = n.ProcesadoPor,
                                                  Nombre = n.Nombre,
                                                  NumeroIdentificacion = n.NumeroIdentificacion,
                                                  Poliza = n.Poliza,
                                                  Reclamacion = n.Reclamacion,
                                                  Estatus = n.Estatus,
                                                  Ramo = n.Ramo,
                                                  MontoAsegurado = n.MontoAsegurado,
                                                  Prima = n.Prima,
                                                  InicioVigencia0 = n.InicioVigencia0,
                                                  InicioVigencia = n.InicioVigencia,
                                                  FinVigencia0 = n.FinVigencia0,
                                                  FinVigencia = n.FinVigencia,
                                                  TipoBusqueda = n.TipoBusqueda,
                                                  EncontradoComo = n.EncontradoComo,
                                                  Comentario = n.Comentario
                                              }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Resultado Busqueda Personas", ExportarExcelPlano);

                }
                else
                {
                    GenerarReporte(Server.MapPath("ResultadoBusquedaPersonas.rpt"), "Resultado Busqueda Personas", (decimal)Session["IdUsuario"]);
                }

            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}