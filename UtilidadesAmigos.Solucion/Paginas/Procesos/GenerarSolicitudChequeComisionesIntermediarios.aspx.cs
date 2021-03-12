﻿using System;
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

        #region GENERAR LA SOLICITUD DE CHEQUE
        private void GenerarSolicitudChequeIntermediario(string TipoChequeParametro, string CodigoIntermediarioParametro, int CodigoBancoParametro, DateTime FechaDesdeParametro, DateTime FechaHastaParametro, decimal MontoMinimoParametro)
        {
            try
            {
                //VALIDAMOS QUE EL CODIGO DE INTERMEDIARIO INGRESADO ES VALIDO

                var Validar = ObjDataMantenimientos.Value.BuscaListadoIntermediario(
                    CodigoIntermediarioParametro);
                if (Validar.Count() < 1)
                {
                    string Mensaje = "El codigo " + txtCodigoIntermediario.Text + " no existe, favor de verificar e intentar nuevamente";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + Mensaje + "');", true);
                }
                else
                {

                    if (Session["IdUsuario"] != null)
                    {
                        //SACAMOS EL NOMBRE DEL USUARURIO QUE VA A HACER EL PROCESO
                        string UsuarioProcesa = "";

                        var SacarNombreusuario = ObjDataGeneral.Value.BuscaUsuarios(Convert.ToDecimal(Session["IdUsuario"]));
                        foreach (var nUsuario in SacarNombreusuario)
                        {
                            UsuarioProcesa = nUsuario.Persona;
                        }
                        //SACAMOS LOS DATOS DEL INTERMEDIARIOS NECESARIOS PARA CREAR EL PROVEEDOR EN CASO DE QUE NO EXISTE
                        //DECLARAMOS LAS VARIABLES NECESARIAS
                        int Compania = 0;
                        int Codigo = 0;
                        int TipoCliente = 0;
                        int TipoRnc = 0;
                        string RNC = "";
                        string NombreCliente = "";
                        string Direccion = "";
                        int Ubicacion = 0;
                        decimal LimiteCredito = 0;
                        decimal Descuento = 0;
                        int CondicionPago = 0;
                        int Estatus = 0;
                        DateTime FechaUltPago = DateTime.Now;
                        decimal MontoUltPago = 0;
                        decimal Balance = 0;
                        string UsuarioAdiciona = "";
                        DateTime FechaAdiciona = DateTime.Now;
                        string UsuarioModifica = "";
                        DateTime FechaModifica = DateTime.Now;
                        int CodigoRnc = 0;
                        decimal PorcComision = 0;
                        int CodMoneda = 0;
                        string TelefonoCasa = "";
                        string TelefonoOficina = "";
                        string Celular = "";
                        string Fax = "";
                        string Beeper = "";
                        string Email = "";
                        int TipoPago = 0;
                        int Banco = 0;
                        string CuentaBanco = "";
                        string Contacto = "";
                        string TipoCuentaBanco = "";
                        string ClaseProveedor = "";

                        foreach (var n in Validar)
                        {
                            Compania = Convert.ToInt32(n.Compania);
                            Codigo = Convert.ToInt32(n.Codigo);
                            TipoCliente = 16;
                            TipoRnc = Convert.ToInt32(n.TipoRnc);
                            RNC = n.Rnc;
                            NombreCliente = n.NombreVendedor;
                            Direccion = n.Direccion;
                            Ubicacion = Convert.ToInt32(n.Ubicacion);
                            LimiteCredito = 0;
                            Descuento = 0;
                            CondicionPago = 0;
                            Estatus = Convert.ToInt32(n.Estatus0);
                            FechaUltPago = DateTime.Now;
                            MontoUltPago = 0;
                            Balance = 0;
                            UsuarioAdiciona = "";
                            FechaAdiciona = DateTime.Now;
                            UsuarioModifica = "";
                            FechaModifica = DateTime.Now;
                            CodigoRnc = 0;
                            PorcComision = Convert.ToDecimal(n.PorcientoComision);
                            CodMoneda = 1;
                            TelefonoCasa = n.Telefono;
                            TelefonoOficina = n.TelefonoOficina;
                            Celular = n.Celular;
                            Fax = n.Fax;
                            Beeper = n.Beeper;
                            Email = n.Email;
                            TipoPago = 0;
                            Banco = Convert.ToInt32(n.Banco);
                            CuentaBanco = n.CtaBanco;
                            Contacto = n.Agencia;
                            TipoCuentaBanco = n.TipoCuentaBco;
                            ClaseProveedor = "01 - Agente";
                        }

                        //BUSCAMOS EL REGISTRO

                        int CodigoProveedorSacardo = 0;
                        var BuscarProveedor = ObjDataMantenimientos.Value.BuscaProveedores(null, RNC, NombreCliente);
                        if (BuscarProveedor.Count() < 1)
                        {
                            //GUARDAMOS EL REGISTRO Y SACAMOS EL CODIGO DEL REGISTRO CREADO
                            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProveedoresSolicitud Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProveedoresSolicitud(
                                Compania,
                                0,
                                TipoCliente,
                                TipoRnc,
                                RNC,
                                NombreCliente,
                                Direccion,
                                Ubicacion,
                                LimiteCredito,
                                Descuento,
                                CondicionPago,
                                Estatus,
                                FechaUltPago,
                                MontoUltPago,
                                Balance,
                                UsuarioAdiciona,
                                FechaAdiciona,
                                UsuarioModifica,
                                FechaModifica,
                                CodigoRnc,
                                PorcComision,
                                CodMoneda,
                                TelefonoCasa,
                                TelefonoOficina,
                                Celular,
                                Fax,
                                Beeper,
                                Email,
                                TipoPago,
                                Banco,
                                CuentaBanco,
                                Contacto,
                                TipoCuentaBanco,
                                ClaseProveedor,
                                "INSERT");
                            Procesar.ProcesarInformacion();

                            var SacarCodigoProveedor = ObjDataMantenimientos.Value.BuscaProveedores(
                                new Nullable<int>(),
                                RNC, NombreCliente);
                            foreach (var n in SacarCodigoProveedor)
                            {
                                CodigoProveedorSacardo = Convert.ToInt32(n.Codigo);
                            }

                        }
                        else
                        {
                            var SacarCodigoProveedor = ObjDataMantenimientos.Value.BuscaProveedores(
                               new Nullable<int>(),
                               RNC, NombreCliente);
                            foreach (var n in SacarCodigoProveedor)
                            {
                                CodigoProveedorSacardo = Convert.ToInt32(n.Codigo);
                            }
                        }





                        //ELIMINAMOS LOS REGISTROS DE LA TABLA DE MONTOS
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarMontosSolicitudCheques Eliminar = new Logica.Comunes.ProcesarMantenimientos.ProcesarMontosSolicitudCheques(
                            Convert.ToDecimal(Session["IdUsuario"]),
                            Codigo, 0, 0, 0, 0, 0, 0, "DELETE");
                        Eliminar.ProcesarInformacion();

                        //PROCESAMOS LA INFORMACION PARA SACAR LOS DATOS DE LOS MONTOS PARA GUARDAR LA SOLICITUD
                        int? _OficinaFiltro = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
                        int? _RamoFiltro = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                        string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();

                        var SacarLosMontosProcesados = ObjDataGeneral.Value.GenerarComisionIntermediario(
                            FechaDesdeParametro,
                            FechaHastaParametro,
                            _CodigoIntermediario,
                            _OficinaFiltro,
                            _RamoFiltro,
                            Convert.ToDecimal(txtMontoMinimo.Text),
                            null, null, null,
                            Convert.ToDecimal(txttasa.Text),
                            null);



                        foreach (var nMontos in SacarLosMontosProcesados)
                        {
                            decimal BrutoSacado = 0, NetoSacado = 0, Comisionsacada = 0, Retencionsacada = 0, Avancesacado = 0, ALiquidarSacada = 0;

                            BrutoSacado = Convert.ToDecimal(nMontos.Bruto);
                            NetoSacado = Convert.ToDecimal(nMontos.Neto);
                            Comisionsacada = Convert.ToDecimal(nMontos.Comision);
                            Retencionsacada = Convert.ToDecimal(nMontos.Retencion);
                            Avancesacado = Convert.ToDecimal(nMontos.AvanceComision);
                            ALiquidarSacada = Convert.ToDecimal(nMontos.ALiquidar);



                            //GUARDAMOS LOS REGISTROS
                            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarMontosSolicitudCheques Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarMontosSolicitudCheques(
                                Convert.ToDecimal(Session["IdUsuario"]),
                                Codigo,
                                BrutoSacado,
                                NetoSacado,
                                Comisionsacada,
                                Retencionsacada,
                                Avancesacado,
                                ALiquidarSacada,
                                "INSERT");
                            Procesar.ProcesarInformacion();
                        }

                        //SACAMOS LA SUMA DE LOS MONTOS GUARDADOS ANTERIORMENTE
                        decimal SumaBruto = 0, SumaNeto = 0, SumaComision = 0, SumaRetencion = 0, SumaAvance = 0, SumaALiquidar = 0;

                        var SacarSumaMontos = ObjDataMantenimientos.Value.BuscaMontos(
                            Convert.ToDecimal(Session["IdUsuario"]), Codigo);
                        foreach (var nSumaMontos in SacarSumaMontos)
                        {
                            SumaBruto = Convert.ToDecimal(nSumaMontos.Bruto);
                            SumaNeto = Convert.ToDecimal(nSumaMontos.Neto);
                            SumaComision = Convert.ToDecimal(nSumaMontos.Comision);
                            SumaRetencion = Convert.ToDecimal(nSumaMontos.Retencion);
                            SumaAvance = Convert.ToDecimal(nSumaMontos.Avance);
                            SumaALiquidar = Convert.ToDecimal(nSumaMontos.ALiquidar);
                        }

                        //GUARDAMOS LOS DATOS DE LA SOLICITUD DE CHEQUE
                        if (rbEndosable.Checked == true)
                        {
                            TipoChequeParametro = "Si";
                        }
                        else if (rbNoEndosable.Checked == true)
                        {
                            TipoChequeParametro = "No";
                        }
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCheques ProcesarSolicitud = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCheques(
                            0,
                            ""
                            ,
                            0,
                            0,
                            0,
                            "",
                            DateTime.Now,
                            0,
                            "",
                            0,
                            "",
                            0,
                            "",
                            TipoRnc,
                            RNC,
                            CodigoProveedorSacardo,
                            "",
                            "",
                            TipoChequeParametro,
                            CodigoBancoParametro,
                            CuentaBanco,
                            SumaALiquidar,
                            "",
                            "",
                            0,
                            DateTime.Now,
                            0,
                            DateTime.Now,
                            UsuarioProcesa,
                            UsuarioProcesa,
                            DateTime.Now,
                            DateTime.Now,
                            0,
                            DateTime.Now,
                            UsuarioProcesa,
                            "",
                            "",
                            UsuarioProcesa,
                            0,
                            "N",
                            0,
                            FechaDesdeParametro,
                            FechaHastaParametro,
                            SumaBruto,
                            SumaComision,
                            SumaRetencion,
                            "INSERT");
                        ProcesarSolicitud.ProcesarInformacion();

                        //SACAMOS EL NUMERO DE SOLICITUD GENERADO
                        int NumeroSolicitudGenerado = UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.SacarUltimoNumeroSolicitudGenerada.SacarNumeroSolicitud(CodigoProveedorSacardo);
                        string NumeroSolicitudConvertida = NumeroSolicitudGenerado.ToString();



                        //GUARDAMOS LOS DATOS DE LAS CUENTAS CONTABLES
                        //CUENTA 1203
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas Cuenta1 = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas(
                            30, "N", 13, NumeroSolicitudGenerado, 0, "1203", 1, "", "2", SumaALiquidar, 0, 0, FechaDesdeParametro, FechaHastaParametro, "INSERT");
                        Cuenta1.ProcesarInformacion();

                        //CUENTA 2503
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas Cuenta2 = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas(
                            30, "N", 13, NumeroSolicitudGenerado, 0, "2503", 0, "", "1", SumaComision, 0, 0, FechaDesdeParametro, FechaHastaParametro, "INSERT");
                        Cuenta2.ProcesarInformacion();

                        //CUENTA 2706
                        if (TipoRnc != 0)
                        {
                            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas Cuenta3 = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas(
                            30, "N", 13, NumeroSolicitudGenerado, 0, "2706", 0, "", "2", SumaRetencion, 0, 0, FechaDesdeParametro, FechaHastaParametro, "INSERT");
                            Cuenta3.ProcesarInformacion();
                        }

                        if (cbGenerarSolicitudPorLote.Checked == true)
                        {
                            //GUARDAMOS EL REGISTRO 
                            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote GuardarLote = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote(
                                0,
                                (decimal)Session["IdUsuario"],
                                Convert.ToInt32(CodigoIntermediarioParametro),
                                Convert.ToDecimal(NumeroSolicitudGenerado),
                                DateTime.Now,
                                FechaDesdeParametro,
                                FechaHastaParametro,
                                SumaALiquidar,
                                true,
                                "INSERT");
                            GuardarLote.ProcesarInformacion();

                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Numero de Solicitud Generada " + NumeroSolicitudConvertida + "');", true);
                        }
                    }
                    else
                    {
                        FormsAuthentication.SignOut();
                        FormsAuthentication.RedirectToLoginPage();
                    }

                }
            }
            catch (Exception)
            {

            }
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
        private void ProcesarInformacionSOlicitudChqeue() {
            decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;
            int? _OficinaFiltro = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            int? _RamoFiltro = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            string _CodigoIntermediarioFiltro = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();

            if (cbGenerarSolicitudPorLote.Checked == true)
            {
                //ELIMINAMOS TODOS LOS REGISTROS DE LA TABLA DE COMISIONES MEDIANTE EL USUARIO INGRESADO
                UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario EliminarRegistros = new Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario(
                    IdUsuario, "", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, DateTime.Now, DateTime.Now, "DELETE");
                EliminarRegistros.ProcesarInformacion();

                //ELIMINAMOS TODOS LOS REGISTROS DE LA TABLA DE PROCESOS EN LOTE
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote EliminarDatosLote = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote(
                    0, IdUsuario, 0, 0, DateTime.Now, DateTime.Now, DateTime.Now, 0, false, "DELETE");
                EliminarDatosLote.ProcesarInformacion();

                //BUSCAMOS TODAS LAS COMISIONES EN EL RANGO DE FECHA INDICADO


                var BuscarComisionesEnLote = ObjDataGeneral.Value.GenerarComisionIntermediario(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    null,
                    _OficinaFiltro,
                    _RamoFiltro,
                    Convert.ToDecimal(txtMontoMinimo.Text),
                    null, null, null,
                    Convert.ToDecimal(txttasa.Text),
                    IdUsuario);
                if (BuscarComisionesEnLote.Count() >= 1)
                {
                    foreach (var Guardar in BuscarComisionesEnLote)
                    {
                     
                        //GUARDAMOS LOS DATOS EN LA TABLA DE COMISIONES 
                        UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario GuardarRegistros = new Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario(
                            IdUsuario,
                            Guardar.Supervisor,
                            (int)Guardar.Codigo,
                            Guardar.Intermediario,
                            Guardar.Oficina,
                            Guardar.NumeroIdentificacion,
                            Guardar.CuentaBanco,
                            Guardar.TipoCuenta,
                            Guardar.Banco,
                            Guardar.Cliente,
                            Guardar.Recibo,
                            Guardar.Fecha,
                            Guardar.Factura,
                            Guardar.FechaFactura,
                            Guardar.Moneda,
                            Guardar.Poliza,
                            Guardar.Producto,
                            (decimal)Guardar.Bruto,
                            (decimal)Guardar.Neto,
                            (decimal)Guardar.PorcientoComision,
                            (decimal)Guardar.Comision,
                            (decimal)Guardar.Retencion,
                            (decimal)Guardar.AvanceComision,
                            (decimal)Guardar.ALiquidar,
                            (decimal)Guardar.CantidadRegistros,
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text),
                            "INSERT");
                        GuardarRegistros.ProcesarInformacion();
                    }

                    //CONSULTAMOS LOS DATOS DE MANERA RESUMIDA
                    var ConsultarComisionesResumida = ObjDataGeneral.Value.ComisionIntermediarioResumido(
                        IdUsuario);
                    int CodigoIntermediarioResumido = 0;
                    decimal ALiquidar = 0, MontoMinimo = Convert.ToDecimal(txtMontoMinimo.Text);
                    foreach (var Resumen in ConsultarComisionesResumida) {
                        CodigoIntermediarioResumido = (int)Resumen.CodigoIntermediario;
                        ALiquidar = (decimal)Resumen.ALiquidar;

                        if (ALiquidar < MontoMinimo)
                        {
                            //GUARDAMOS LOS DATOS DE LOS REGISTROS QUE NO APLICARON EN EL PROCESO
                            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote GaurdarRegistrosDenegados = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote(
                                0,
                                IdUsuario,
                                CodigoIntermediarioResumido,
                                0,
                                DateTime.Now,
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text),
                                ALiquidar,
                                false,
                                "INSERT");
                            GaurdarRegistrosDenegados.ProcesarInformacion();
                        }
                        else {
                            //GENERAMOS LAS SOLICITUDES DE CHEQUES
                            GenerarSolicitudChequeIntermediario(
                                "",
                                CodigoIntermediarioResumido.ToString(),
                                Convert.ToInt32(ddlSeleccionarBanco.SelectedValue),
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text),
                                MontoMinimo);
                        }

                        //EXPORTAMOS LOS REGISTROS GENERADOS A EXCEL
                        var ExportarRegistrosProcesados = (from n in ObjDataMantenimientos.Value.BuscaRegistrosSolicitudChequeLote(IdUsuario, null)
                                                           select new
                                                           {
                                                               Registro=n.IdRegistro,
                                                               GeneradoPor=n.CreadoPor,
                                                               IDIntermediario=n.CodigoIntermediario,
                                                               Nombre=n.Intermediario,
                                                               NumeroSolicitud=n.NumeroSolicitud,
                                                               FechaProceso=n.FechaProceso,
                                                               ProcesadoDesde=n.ValidadoDesde,
                                                               ProcesadoHasta=n.ValidadoHasta,
                                                               ValorSolicitud=n.MontoSolicitud,
                                                               Estatus=n.Estatus
                                                           }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Proceso Solicitud de Cheque En Lote", ExportarRegistrosProcesados);
                    }

                }
            }
            else if (cbGenerarSolicitudPorLote.Checked == false)
            {

                GenerarSolicitudChequeIntermediario(
                                "",
                                txtCodigoIntermediario.Text,
                                Convert.ToInt32(ddlSeleccionarBanco.SelectedValue),
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text),
                                Convert.ToDecimal(txtMontoMinimo.Text));
            }
        }
  

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
            //if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
            //    ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
            //    if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
            //    {
            //        ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
            //    }
            //    if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            //    {
            //        ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
            //    }
            //}
            //else {
            //    ProcesarInformacionSOlicitudChqeue();
            //}

            //VALIDAMOS QUE LOS CAMPOS FECHAS NO ESTEN VACIOS
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
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

                if (cbGenerarSolicitudPorLote.Checked == true)
                {
                    //VALIDAMOS LA VARIABLE DE SESION
                    if (Session["IdUsuario"] != null)
                    {
                        if (string.IsNullOrEmpty(txtMontoMinimo.Text.Trim()))
                        {
                            txtMontoMinimo.Text = "500";
                        }

                        //ELIMINAMOS LOS REGISTROS DE LA TABLA DE COMISIONES
                        UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario EliminarRegistros = new Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario(
                            Convert.ToDecimal(Session["IdUsuario"]), "", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, DateTime.Now, DateTime.Now, "DELETE");
                        EliminarRegistros.ProcesarInformacion();

                        //ELIMINAMOS LOS DATOS DE LA TABLA DE PROCESO EN LOTE
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote EliminarDatosLote = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote(
                            0, Convert.ToDecimal(Session["IdUsuario"]), 0, 0, DateTime.Now, DateTime.Now, DateTime.Now, 0, false, "DELETE");
                        EliminarDatosLote.ProcesarInformacion();


                        //BUSCAMOS LAS COMISIONES
                        int? _CodigoOficinaFiltro = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
                        int? _CodigoRamoFiltro = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                        var GenerarComisiones = ObjDataGeneral.Value.GenerarComisionIntermediario(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text),
                            null, _CodigoOficinaFiltro, _CodigoRamoFiltro, Convert.ToDecimal(txtMontoMinimo.Text), null, null, null, null, null);

                        foreach (var n in GenerarComisiones)
                        {
                            //GUARDAMOS LOS DATOS EN LA TABLA DE COMISIONES
                            UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario GuardarComisiones = new Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario(
                                (decimal)Session["IdUsuario"],
                                n.Supervisor,
                                Convert.ToInt32(n.Codigo),
                                n.Intermediario,
                                n.Oficina,
                                n.NumeroIdentificacion,
                                n.CuentaBanco,
                                n.TipoCuenta,
                                n.Banco,
                                n.Cliente,
                                n.Recibo,
                                n.Fecha,
                                n.Factura,
                                n.FechaFactura,
                                n.Moneda,
                                n.Poliza,
                                n.Producto,
                                Convert.ToDecimal(n.Bruto),
                                Convert.ToDecimal(n.Neto),
                                Convert.ToDecimal(n.PorcientoComision),
                                Convert.ToDecimal(n.Comision),
                                Convert.ToDecimal(n.Retencion),
                                Convert.ToDecimal(n.AvanceComision),
                                Convert.ToDecimal(n.ALiquidar),
                                Convert.ToDecimal(n.CantidadRegistros),
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text),
                                "INSERT");
                            GuardarComisiones.ProcesarInformacion();


                        }

                        //CONSULTAMOS LOS DATOS DE MANERA RESUMIDA
                        var ConsultarComisionResumida = ObjDataGeneral.Value.ComisionIntermediarioResumido(Convert.ToDecimal(Session["IdUsuario"]));
                        int CodigoIntermediarioResumido = 0;
                        decimal ALiquidar = 0;
                        decimal MontoMinimo = Convert.ToDecimal(txtMontoMinimo.Text);
                        foreach (var n2 in ConsultarComisionResumida)
                        {
                            CodigoIntermediarioResumido = Convert.ToInt32(n2.CodigoIntermediario);
                            ALiquidar = Convert.ToDecimal(n2.ALiquidar);

                            if (ALiquidar < MontoMinimo)
                            {
                                //GUARDAMOS LOS DATOS DE LOS REGISTROS QUE NO SE PROCESAROS
                                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote GuardarInformacionlote = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote(
                                    0,
                                    Convert.ToDecimal(Session["IdUsuario"]),
                                    CodigoIntermediarioResumido,
                                    0,
                                    DateTime.Now,
                                    Convert.ToDateTime(txtFechaDesde.Text),
                                    Convert.ToDateTime(txtFechaHasta.Text),
                                    ALiquidar,
                                    false,
                                    "INSERT");
                                GuardarInformacionlote.ProcesarInformacion();
                            }
                            else
                            {

                                //GENERAMOS LAS COLICITUDES DE CHEQUES
                                GenerarSolicitudChequeIntermediario("", CodigoIntermediarioResumido.ToString(), Convert.ToInt32(ddlSeleccionarBanco.SelectedValue), Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text), Convert.ToDecimal(txtMontoMinimo.Text));
                            }
                        }
                        //btnProcesarSolicitud.Enabled = false;
                        //btnVolverAtras.Visible = true;

                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Hola');", true);

                        //EXPORTAMOS LOS REGISTROS GENERADOS A EXEL
                        var GenerarRegistrosExel = (from n in ObjDataMantenimientos.Value.BuscaRegistrosSolicitudChequeLote((decimal)Session["IdUsuario"], null)
                                                    select new
                                                    {
                                                        Registro_No = n.IdRegistro,
                                                        GeneradoPor = n.CreadoPor,
                                                        Codigo_Intermediario = n.CodigoIntermediario,
                                                        Nombre_Intermediario = n.Intermediario,
                                                        Numero_Solicitud_Cheque = n.NumeroSolicitud,
                                                        Fecha_Proceso = n.FechaProceso,
                                                        Validado_Desde = n.ValidadoDesde,
                                                        Validado_Hasta = n.ValidadoHasta,
                                                        Valor_Solicitud = n.MontoSolicitud,
                                                        Estatus = n.Estatus
                                                    }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Proceso Solicitud Cheque Lote", GenerarRegistrosExel);

                    }
                    else
                    {
                        FormsAuthentication.SignOut();
                        FormsAuthentication.RedirectToLoginPage();
                    }
                }
                //GENERAMOS LA SOLICITUD DE CHEQUE DE MANERA INDIVIDUAL
                else if (cbGenerarSolicitudPorLote.Checked == false)
                {

                    GenerarSolicitudChequeIntermediario("", txtCodigoIntermediario.Text, Convert.ToInt32(ddlSeleccionarBanco.SelectedValue), Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text), 0);



                }


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