﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace UtilidadesAmigos.Solucion.Paginas.Consulta
{
    public partial class GestionCobros : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objdata = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta> ObjDataConsulta = new Lazy<Logica.Logica.LogicaConsulta.LogicaConsulta>();


        enum EstatusLlamada { 
        
            ClienteNoContactado=1,
            ClienteContactado=2
        }
        enum ConceptosDeLlamada
        {
            Cliente_va_a_Pagar = 7,
            Cliente_no_va_a_Pagar = 8,
            Llamar_mas_tarde = 9,
            Cliente_ya_realizo_el_pago = 10,
            Cliente_Vendio_El_Vehiculo = 11,
            El_Cliente_ya_Pago_su_Poliza = 12,
            Cliente_Quiere_Cancelar_Su_Poliza = 13,
            Cancelar_Poliza_por_cambio_de_compañia = 14,
            Cliente_no_puede_recibir_llamada, _llamar_mas_tarde = 15
        }

        #region ENUMERACIONES
        enum Enumeraciones_Ramos { 
        
            Vehiculo_Motor=106
        }

        enum Enumeraciones_SubRamo
        {
            Motores = 1
        }
        #endregion

        #region CONTROL DE PAGINACION DE GESTION DE COBROS HEADER 	
        readonly PagedDataSource pagedDataSource_GestionCobrosHeader = new PagedDataSource();
        int _PrimeraPagina_GestionCobrosHeader, _UltimaPagina_GestionCobrosHeader;
        private int _TamanioPagina_GestionCobrosHeader = 10;
        private int CurrentPage_GestionCobrosHeader
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

        private void HandlePaging_GestionCobrosHeader(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_GestionCobrosHeader = CurrentPage_GestionCobrosHeader - 5;
            if (CurrentPage_GestionCobrosHeader > 5)
                _UltimaPagina_GestionCobrosHeader = CurrentPage_GestionCobrosHeader + 5;
            else
                _UltimaPagina_GestionCobrosHeader = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_GestionCobrosHeader > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_GestionCobrosHeader = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_GestionCobrosHeader = _UltimaPagina_GestionCobrosHeader - 10;
            }

            if (_PrimeraPagina_GestionCobrosHeader < 0)
                _PrimeraPagina_GestionCobrosHeader = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_GestionCobrosHeader;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_GestionCobrosHeader; i < _UltimaPagina_GestionCobrosHeader; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_GestionCobrosHeader(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_GestionCobrosHeader.DataSource = Listado;
            pagedDataSource_GestionCobrosHeader.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_GestionCobrosHeader.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_GestionCobrosHeader.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_GestionCobrosHeader.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_GestionCobrosHeader : _NumeroRegistros);
            pagedDataSource_GestionCobrosHeader.CurrentPageIndex = CurrentPage_GestionCobrosHeader;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_GestionCobrosHeader.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_GestionCobrosHeader.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_GestionCobrosHeader.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_GestionCobrosHeader.IsLastPage;

            RptGrid.DataSource = pagedDataSource_GestionCobrosHeader;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_GestionCobrosHeader
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_GestionCobrosHeader(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region CONTROL DE PAGINACION DE LOS VEHICULOS DE LA POLIZA SELECCIONADA 	
        readonly PagedDataSource pagedDataSource_ListadoVehiculosPoliza = new PagedDataSource();
        int _PrimeraPagina_ListadoVehiculosPoliza, _UltimaPagina_ListadoVehiculosPoliza;
        private int _TamanioPagina_ListadoVehiculosPoliza = 10;
        private int CurrentPage_ListadoVehiculosPoliza
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

        private void HandlePaging_ListadoVehiculosPoliza(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_ListadoVehiculosPoliza = CurrentPage_ListadoVehiculosPoliza - 5;
            if (CurrentPage_ListadoVehiculosPoliza > 5)
                _UltimaPagina_ListadoVehiculosPoliza = CurrentPage_ListadoVehiculosPoliza + 5;
            else
                _UltimaPagina_ListadoVehiculosPoliza = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_ListadoVehiculosPoliza > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_ListadoVehiculosPoliza = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_ListadoVehiculosPoliza = _UltimaPagina_ListadoVehiculosPoliza - 10;
            }

            if (_PrimeraPagina_ListadoVehiculosPoliza < 0)
                _PrimeraPagina_ListadoVehiculosPoliza = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_ListadoVehiculosPoliza;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_ListadoVehiculosPoliza; i < _UltimaPagina_ListadoVehiculosPoliza; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_ListadoVehiculosPoliza(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_ListadoVehiculosPoliza.DataSource = Listado;
            pagedDataSource_ListadoVehiculosPoliza.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_ListadoVehiculosPoliza.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_ListadoVehiculosPoliza.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_ListadoVehiculosPoliza.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_ListadoVehiculosPoliza : _NumeroRegistros);
            pagedDataSource_ListadoVehiculosPoliza.CurrentPageIndex = CurrentPage_ListadoVehiculosPoliza;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_ListadoVehiculosPoliza.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_ListadoVehiculosPoliza.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_ListadoVehiculosPoliza.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_ListadoVehiculosPoliza.IsLastPage;

            RptGrid.DataSource = pagedDataSource_ListadoVehiculosPoliza;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_ListadoVehiculosPoliza
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_ListadoVehiculosPoliza(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region CONTROL DE PAGINACION DE LOS COMENTARIOS AGREGADOS
        readonly PagedDataSource pagedDataSource_ComentariosAgregados = new PagedDataSource();
        int _PrimeraPagina_ComentariosAgregados, _UltimaPagina_ComentariosAgregados;
        private int _TamanioPagina_ComentariosAgregados = 10;
        private int CurrentPage_ComentariosAgregados
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

        private void HandlePaging_ComentariosAgregados(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_ComentariosAgregados = CurrentPage_ComentariosAgregados - 5;
            if (CurrentPage_ComentariosAgregados > 5)
                _UltimaPagina_ComentariosAgregados = CurrentPage_ComentariosAgregados + 5;
            else
                _UltimaPagina_ComentariosAgregados = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_ComentariosAgregados > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_ComentariosAgregados = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_ComentariosAgregados = _UltimaPagina_ComentariosAgregados - 10;
            }

            if (_PrimeraPagina_ComentariosAgregados < 0)
                _PrimeraPagina_ComentariosAgregados = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_ComentariosAgregados;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_ComentariosAgregados; i < _UltimaPagina_ComentariosAgregados; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_ComentariosAgregados(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_ComentariosAgregados.DataSource = Listado;
            pagedDataSource_ComentariosAgregados.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_ComentariosAgregados.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_ComentariosAgregados.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_ComentariosAgregados.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_ComentariosAgregados : _NumeroRegistros);
            pagedDataSource_ComentariosAgregados.CurrentPageIndex = CurrentPage_ComentariosAgregados;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_ComentariosAgregados.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_ComentariosAgregados.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_ComentariosAgregados.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_ComentariosAgregados.IsLastPage;

            RptGrid.DataSource = pagedDataSource_ComentariosAgregados;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_ComentariosAgregados
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_ComentariosAgregados(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        private void CargarRamos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlRamoConsulta, Objdata.Value.BuscaListas("RAMO", null, null), true);
        }
        private void CargarSubramos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSubRamoConsulta, Objdata.Value.BuscaListas("SUBRAMO", ddlRamoConsulta.SelectedValue, null), true);

        }
        private void CargarOficina()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddloficina, Objdata.Value.BuscaListas("OFICINANORMAL", null, null), true);
        }

        private void CargarListas() {
            CargarRamos();
            CargarSubramos();
            CargarOficina();
            
        }
        #endregion

        #region MOSTRAR LA GESTION DE COBROS HEADER
        private void MostrarGestionCobrosHeader() {

            DateTime? _FechaCorte = string.IsNullOrEmpty(txtFechaCorte.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaCorte.Text);
            int? _Ramo = ddlRamoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlRamoConsulta.SelectedValue) : new Nullable<int>();
            int? _SubRamo = ddlSubRamoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSubRamoConsulta.SelectedValue) : new Nullable<int>();
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _oficina = ddloficina.SelectedValue != "-1" ? Convert.ToInt32(ddloficina.SelectedValue) : new Nullable<int>();
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioConsulta.Text);


            var Header = ObjDataConsulta.Value.BuscaGestionCobrosheader(
                _FechaCorte,
                _Ramo,
                _SubRamo,
                _Poliza,
                _oficina,
                _Supervisor,
                _Intermediario);
            if (Header.Count() < 1) {
                rpAntiguedadSaldo.DataSource = null;
                rpAntiguedadSaldo.DataBind();

            }
            else {

                Paginar_GestionCobrosHeader(ref rpAntiguedadSaldo, Header, 10, ref lbCantidadPaginaVariable_Antiguedad, ref btnPrimeraPagina_Antiguedad, ref btnPaginaAnterior_Antiguedad, ref btnPaginaSiguiente_Antiguedad, ref btnUltimaPagina_Antiguedad);
                HandlePaging_GestionCobrosHeader(ref dtPaginacion_Antiguedad, ref lbPaginaActual_Antiguedad);
            }
        }
        #endregion

        #region MOSTRAR EL DETALLE GENERAL DE LA POLIZA
        private void SacarInformacionPoliza(string Poliza)
        {

            var SacarInformacion = ObjDataConsulta.Value.BuscaPolizaGestionCobros(
                Poliza, null);
            foreach (var n in SacarInformacion)
            {
                txtPolizaGestionCObros.Text = n.Poliza;
                txtEstatusGestionCobros.Text = n.Estatus;
                txtRamoGestionCobros.Text = n.Ramo;
                txtClienteGestionCobros.Text = n.NombreCliente;
                txtTelefonosGestonCobros.Text = n.Telefonos;
                txtDireccionGestionCobros.Text = n.Direccion;
                txtSupervisorGEstionCobros.Text = n.Supervisor;
                txtIntermediarioGestionCobro.Text = n.Intermediario;
                txtLicencia.Text = n.LicenciaSeguro;
                txtFechaCreadaGestionCobros.Text = n.FechaCreada;
                txtInicioVigencia.Text = n.InicioVigencia;
                txtFInVigenciaGestionCobros.Text = n.FinVigencia;
                decimal TotalFActurado = (decimal)n.Facturado;
                txtTotalFacturado.Text = TotalFActurado.ToString("N2");
                decimal TotalCobrado = (decimal)n.Cobrado;
                txtTotalCobradoGestionCobros.Text = TotalCobrado.ToString("N2");
                decimal Balance = (decimal)n.Balance;
                txtBalanceGestionCobros.Text = Balance.ToString("N2");
                int TotalFacturas = (int)n.TotalFacturas;
                txtTotalFacturasGestionCobros.Text = TotalFacturas.ToString("N0");
                int TotalRecibos = (int)n.TotalRecibos;
                txtTotalRecibosGestionCobros.Text = TotalRecibos.ToString("N0");
                int TotalReclamaciones = (int)n.TotalReclamaciones;
                txtTotalReclamacionesGestionCobros.Text = TotalReclamaciones.ToString("N0");

                string Ramo = txtRamoGestionCobros.Text;

                if (Ramo == "Vehiculo De Motor")
                {
                    DivDatoVehiculo.Visible = true;
                    //BuscaDatosVehiculos(txtPolizaGestionCObros.Text);
                }
                else
                {
                    DivDatoVehiculo.Visible = false;
                }
            }
        }
        #endregion

        #region SACAR EL ULTIMO COMENTARIO REALIZADO A UNA POLIZA
        public void SacarUltimoComentarioPoliza(string Poliza) {

            var BuscarInformacion = ObjDataConsulta.Value.MostrarUltimoComentarioPolizaListadoRenovacion(Poliza);
            foreach (var n in BuscarInformacion) {

                txtUltimoConcepto.Text = n.ConceptoLlamada;
                txtUltimoEstatus.Text = n.EstatusLlamada;
                txtUltimoUsuarioComento.Text = n.Usuario;
                txtUltimafechaComentario.Text = n.Fecha;
                txtUltimaHoraComentario.Text = n.Hora;
                txtUltimoComentario.Text = n.Comentario;
            }
        }
        #endregion

        #region BUSCAR LOS DATOS DEL VEHICULO SELECCIONADO
        private void BuscaDatosVehiculos(string Poliza)
        {

            var BuscarDatos = ObjDataConsulta.Value.BuscaDatosVehiculoGestion(Poliza);
            if (BuscarDatos.Count() < 1)
            {

                rpDatosVehiculo.DataSource = null;
                rpDatosVehiculo.DataBind();
            }
            else
            {
                Paginar_ListadoVehiculosPoliza(ref rpDatosVehiculo, BuscarDatos, 10, ref lbPaginaActual_DatoVehiculo, ref btnPrimeraPagina_DatoVehiculo, ref btnPaginaAnterior_DatoVehiculo, ref btnSiguientePagina_DatoVehiculo, ref btnUltimaPagina_DatoVehiculo);
                HandlePaging_ListadoVehiculosPoliza(ref dtPaginacion_DatoVehiculo, ref lbCantidadPagina_DatoVehiculo);
            }
        }
        #endregion

        #region CARGAR LAS LISTAS DESPLEGABLES DEL ESTATUS Y DEL CONCEPTO
        private void CargarEstatusLlamada() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarEstatusLLamadaGestionCobros, Objdata.Value.BuscaListas("ESTATUSLLAMADAGESTIONCOBROS", null, null));
        }
        private void CargarConceptoLlamada() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarConceptoGestionCobros, Objdata.Value.BuscaListas("CONCEPTOLLAMADAGESTIONCOBROS", ddlSeleccionarEstatusLLamadaGestionCobros.SelectedValue.ToString(), null));
        }
        #endregion

        #region PROCESO EN CASO DE QUE SE VALLE A LLAMAR MAS TARDE
        private void LlamarMasTarde() {

            int Estatus = Convert.ToInt32(ddlSeleccionarEstatusLLamadaGestionCobros.SelectedValue);
            int Concepto = Convert.ToInt32(ddlSeleccionarConceptoGestionCobros.SelectedValue);
            DateTime _Hoy = DateTime.Now;
            txtFechaNuevaLLamada.Text = _Hoy.ToString("yyyy-MM-dd");

            if (Estatus == (int)EstatusLlamada.ClienteContactado && Concepto == (int)ConceptosDeLlamada.Llamar_mas_tarde) {
                DivFechaLlamada.Visible = true;
                DIVHoraLLamada.Visible = true;
          
            }
            else {
                DivFechaLlamada.Visible = false;
                DIVHoraLLamada.Visible = false;
            }

        }
        #endregion

        #region PROCESAR LA INFORMACION DE LOS COMENTARIOS
        private void ProcesarInformacionComentarios() {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionGestionCobrosAntiguedadSaldo Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionGestionCobrosAntiguedadSaldo(
                0,
                txtPolizaGestionCObros.Text,
                Convert.ToInt32(ddlSeleccionarEstatusLLamadaGestionCobros.SelectedValue),
                Convert.ToInt32(ddlSeleccionarConceptoGestionCobros.SelectedValue),
                txtComentarioGestionCobros.Text,
                Convert.ToDateTime(txtFechaNuevaLLamada.Text),
                txtHoraNuevaLLamada.Text,
                (decimal)Session["IdUsuario"],
                DateTime.Now,
                "INSERT");
            Procesar.ProcesarInformacion();
        }
        #endregion

        #region MOSTRAR LOS COMENTARIOS AGREGADOS
        private void MostrarComentariosAgregados(string Poliza) {

            var MostrarComentarios = ObjDataConsulta.Value.BuscaComentariosAntiguedadSaldogestionCobros(
                new Nullable<decimal>(),
                Poliza,
                null, null, null, null, (decimal)Session["idUsuario"]);
            if (MostrarComentarios.Count() < 1) {
                rpComentarios_GestionCobros.DataSource = null;
                rpComentarios_GestionCobros.DataBind();
            }
            else {
                Paginar_ComentariosAgregados(ref rpComentarios_GestionCobros, MostrarComentarios, 10, ref lbCantidadPagina_Comentarios, ref btnPrimeraPagina_Comentarios, ref btnPaginaAnterior_Comentarios, ref btnPaginaSiguiente_Comentarios, ref btnUltimaPagina_Comentarios);
                HandlePaging_ComentariosAgregados(ref dtPaginacion_Comentarios, ref lbPaginaActual_Comentarios);

                int CantidadRegistros = 0;
                foreach (var n in MostrarComentarios) {

                    CantidadRegistros = (int)n.CantidadRegistros;
                }
                lbCantidadRegistros_Comentarios.Text = CantidadRegistros.ToString("N0");

            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["Idusuario"]);
                Label lbUsuarioConectado = (Label)Master.FindControl("lbUsuarioConectado");
                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");

                lbUsuarioConectado.Text = Nombre.SacarNombreUsuarioConectado();
                lbPantalla.Text = "Gestion de Cobros";

                DIVBloqueProceso.Visible = false;
                DIVBloqueConsulta.Visible = true;
                cbReporteComentaro.Text = "Marcar para generar reporte de Comentarios";
                CargarListas();

                DateTime Hoy = DateTime.Now;
                txtFechaCorte.Text = Hoy.ToString("yyyy-MM-dd");
            }
        }

        protected void cbReporteComentaro_CheckedChanged(object sender, EventArgs e)
        {
            if (cbReporteComentaro.Checked == true) {
                cbReporteComentaro.Text = "Desmarcar para generar reporte de Gestion de Cobros";
            }
            else {
                cbReporteComentaro.Text = "Marcar para generar reporte de Comentarios";
            }
        }

        protected void ddlRamoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSubramos();
        }

        protected void txtCodigoIntermediarioConsulta_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Intermediario = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediarioConsulta.Text);
            txtNombreIntermediario.Text = Intermediario.SacarNombreIntermediario();
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Supervisor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisor.Text);
            txtNombreSupervisor.Text = Supervisor.SacarNombreSupervisor();
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_GestionCobrosHeader = 0;
            MostrarGestionCobrosHeader();
        }

        protected void btnExportarExcel_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnGestionCobros_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var Poliza = ((HiddenField)ItemSeleccionado.FindControl("hfPoliza")).Value.ToString();

            SacarInformacionPoliza(Poliza);
            SacarUltimoComentarioPoliza(Poliza);
            BuscaDatosVehiculos(Poliza);
            CargarEstatusLlamada();
            CargarConceptoLlamada();
            LlamarMasTarde();
            MostrarComentariosAgregados(Poliza);
            DIVBloqueConsulta.Visible = false;
            DIVBloqueProceso.Visible = true;
        }

        protected void btnPrimeraPagina_Antiguedad_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_Antiguedad_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_Antiguedad_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_Antiguedad_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnPaginaSiguiente_Antiguedad_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_Antiguedad_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_DatoVehiculo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_DatoVehiculo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_DatoVehiculo_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_DatoVehiculo_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePagina_DatoVehiculo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_DatoVehiculo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlSeleccionarEstatusLLamadaGestionCobros_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarConceptoLlamada();
        }

        protected void ddlSeleccionarConceptoGestionCobros_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlamarMasTarde();
        }

        protected void btnGuardar_GestionCobros_Click(object sender, ImageClickEventArgs e)
        {
            ProcesarInformacionComentarios();
            ClientScript.RegisterStartupScript(GetType(), "ComentarioGuardado()", "ComentarioGuardado();", true);
            CargarEstatusLlamada();
            CargarConceptoLlamada();
            LlamarMasTarde();
            txtComentarioGestionCobros.Text = string.Empty;
            CurrentPage_ComentariosAgregados = 0;
            MostrarComentariosAgregados(txtPolizaGestionCObros.Text);

        }

        protected void btnVolver_GestionCobros_Click(object sender, ImageClickEventArgs e)
        {
            DIVBloqueConsulta.Visible = true;
            DIVBloqueProceso.Visible = false;
        }

        protected void btnPrimeraPagina_Comentarios_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_Comentarios_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_Comentarios_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void btnPaginaSiguiente_Comentarios_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_Comentarios_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_Comentarios_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }


    }

    
}