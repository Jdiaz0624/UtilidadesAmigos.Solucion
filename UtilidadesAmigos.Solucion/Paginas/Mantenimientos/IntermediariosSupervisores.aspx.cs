﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class IntermediariosSupervisores : System.Web.UI.Page
    {
        UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.Logica.LogicaSistema();
        UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos Objdatamantenimientos = new Logica.Logica.LogicaMantenimientos.LogicaMantenimientos();

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
        #region CARGAR LAS OFICINAS PARA LA PANTALLA DE CONSULTA
        private void CargaroficinaConsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficinaConsulta, ObjData.BuscaListas("OFICINAS", null, null), true);
        }
        #endregion

        #region MOSTRAR EL LISTADO DE LOS INTERMEDIARIOS Y SUPERVISORES
        private void MostrarIntermediariosSupervisores() {
            string _Codigo = string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()) ? null : txtCodigoIntermediarioConsulta.Text.Trim();
            string _Nombre = string.IsNullOrEmpty(txtNombreIntermediarioConsulta.Text.Trim()) ? null : txtNombreIntermediarioConsulta.Text.Trim();
            int? _Oficina = ddlSeleccionarOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficinaConsulta.SelectedValue) : new Nullable<int>();

            var Listado = Objdatamantenimientos.BuscaListadoIntermediario(
                _Codigo,
                _Nombre,
                null,
                null,
                _Oficina);
            Paginar(ref rpListado, Listado, 10, ref lbCantidadPaginaVariableIntermediariosSupervisores, ref LinkPrimeraPaginaIntermediariosSupervisores, ref LinkAnteriorIntermediariosSupervisores, ref LinkSiguienteIntermediariosSupervisores, ref LinkUltimoIntermediariosSupervisores);
            HandlePaging(ref dtPaginacionIntermediariosSupervisores, ref lbPaginaActualVariavleIntermediariosSupervisores);
        }
        #endregion

        #region LISTAS DEL BLOQUE DE MANTENIMIENTO
        private void ListaTipoIdentificacionMAntenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoIdentificacionMantenimiento, ObjData.BuscaListas("TIPOIDENTIFICACION", null, null));
        }
        private void ListaPaisMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPaisMantenimiento, ObjData.BuscaListas("LISTADOPAIS", null, null));
        }
        private void ListaZonaMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlZonaMantenimiento, ObjData.BuscaListas("LISTADOZONAS", ddlPaisMantenimiento.SelectedValue, null));
        }
        private void ListaProvinciaMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlProvinciaMantenimiento, ObjData.BuscaListas("LISTADOPROVINCIAS", ddlPaisMantenimiento.SelectedValue, ddlZonaMantenimiento.SelectedValue));
        }
        private void ListaMunicipioMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlMunicipioMAntenimiento, ObjData.BuscaListas("LISTADOMUNICIPIO", ddlPaisMantenimiento.SelectedValue, ddlZonaMantenimiento.SelectedValue, ddlProvinciaMantenimiento.SelectedValue));
        }
        private void ListaSectorMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSectorMantenimiento, ObjData.BuscaListas("LISTADOSECTOR", ddlPaisMantenimiento.SelectedValue, ddlZonaMantenimiento.SelectedValue, ddlProvinciaMantenimiento.SelectedValue, ddlMunicipioMAntenimiento.SelectedValue));
        }
        private void ListaUbicacionMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlUbicacionMantenimiento, ObjData.BuscaListas("LISTADOBARRIO", ddlPaisMantenimiento.SelectedValue, ddlZonaMantenimiento.SelectedValue, ddlProvinciaMantenimiento.SelectedValue, ddlMunicipioMAntenimiento.SelectedValue, ddlSectorMantenimiento.SelectedValue));
        }
        private void ListaOficinaMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMAntenimiento, ObjData.BuscaListas("OFICINAS", null, null));
        }
        private void ListaBancoMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlBancoMantenimiento, ObjData.BuscaListas("LISTADOBANCOS", null, null));
        }
        private void ListaCanalDistribucion() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlCanalDistribucionMantenimiento, ObjData.BuscaListas("LISTADOCANALESDISTRIBUCION", null, null));
        }

        #endregion

        #region CONFIGURACIONES INICIALES PANTALLA DE MANTENIMIENTO
        private void CargarConfiguracionesInicialesBloqueMantenimiento() {
            rbRetencionNoMantenimiento.Checked = true;
            rbActivoMantenimiento.Checked = true;
            rbIntermediarioNoDirectoMantenimiento.Checked = true;
            ListaTipoIdentificacionMAntenimiento();
            ListaPaisMantenimiento();
            ListaZonaMantenimiento();
            ListaProvinciaMantenimiento();
            ListaMunicipioMantenimiento();
            ListaSectorMantenimiento();
            ListaUbicacionMantenimiento();
            ListaOficinaMantenimiento();
            ListaBancoMantenimiento();
            ListaCanalDistribucion();
            rbCuentaCorrienteMantenimiento.Checked = true;
            rbChequeMantenimiento.Checked = true;
        }
        #endregion

        #region MANTENIMIENTO DE INTERMEDIARIOS
        private void MANIntermediario(int CodigoIntermediario, int Estatus, string UsuarioProcesa, string CanalDistribucion, string Publicidad, string TipoPago, string Retencion, string TipoCuentaBanco, string Accion) {
            try {
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionMantenimientoIntermediariosSupervisores Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionMantenimientoIntermediariosSupervisores(
                    30,
                    CodigoIntermediario,
                    "",
                    0,
                    Convert.ToInt32(ddlSeleccionarTipoIdentificacionMantenimiento.SelectedValue),
                    txtNumeroIdentificacionMantenimiento.Text,
                    "",
                    0,
                    Convert.ToInt32(txtCodigoSupervisorMantenimiento.Text),
                    Estatus,
                    Convert.ToDateTime(txtFechaEntradaMantenimiento.Text),
                    UsuarioProcesa,
                    DateTime.Now,
                    UsuarioProcesa,
                    DateTime.Now,
                    0,
                    txtComentarioMantenimiento.Text,
                    CanalDistribucion,
                    txtContactoMantenimiento.Text,
                    Convert.ToDateTime(txtFechaNacimientoMantenimiento.Text),
                    Publicidad,
                    TipoPago,
                    Convert.ToInt32(ddlBancoMantenimiento.SelectedValue),
                    txtNumeroCuentaMantenimiento.Text,
                    0,
                    Retencion,
                    Convert.ToDecimal(17.50),
                    0,
                    Convert.ToInt32(txtCodigoSupervisorMantenimiento.Text),
                    "",
                    txtDireccion.Text,
                    Convert.ToInt32(ddlUbicacionMantenimiento.SelectedValue),
                    txtTelefono2Mantenimiento.Text,
                    txtTelefono1Mantenimiento.Text,
                    txtCelularMantenimiento.Text,
                    txtTelefono3Mantenimiento.Text,
                    txtFAxMantenimiento.Text,
                    txtEmailMantenimiento.Text,
                    txtLicenciaSeguro.Text,
                    "",
                    txtApellidoMantenimiento.Text,
                    txtNombreMantenimiento.Text,
                    Convert.ToInt32(ddlOficinaMAntenimiento.SelectedValue),
                    TipoCuentaBanco,
                    0,
                    0,
                    0,
                    Guid.NewGuid(),
                    0, 0, 0, 0, Accion);
                Procesar.ProcesarInformacion();

            
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorRealizarMantenimiento()", "ErrorRealizarMantenimiento();", true);
            }
        }

        private void MANIntermediarioCadenaDetalle(int Compania, int IdIntermediario, int IdSupervisor, string UsuarioAdiciona, string Accion)
        {
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionIntermediarioCadenaDetalle IntermediarioCadenaDetalle = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionIntermediarioCadenaDetalle(
                Compania,
                IdIntermediario,
                IdSupervisor,
                UsuarioAdiciona,
                DateTime.Now,
                Accion);
            IntermediarioCadenaDetalle.ProcesarInformaicon();
        
        }

        /// <summary>
        /// Este metodo es para procesar la información para guardar o modificar cualquier registro
        /// </summary>
        private void ProcesarInformacionRegistros() {
            int CodigoIntermediario = 0;
            int EstatusIntermediario = 0, Publicidad = 0;
            string UsuarioProcesa = "", CanalDistribucion = "", TipoPago = "", Retencion = "", TipoCuenta = "";
            int CodigoCanalDistribucion = Convert.ToInt32(ddlCanalDistribucionMantenimiento.SelectedValue);
            if (lbAccionTomar.Text == "INSERT")
            {
                CodigoIntermediario = 0;
            }
            else
            {
                CodigoIntermediario = Convert.ToInt32(lbCodigoSeleccionadoVariable.Text);
            }
            //SACAMOS EL ESTATUS
            if (rbActivoMantenimiento.Checked == true)
            {
                EstatusIntermediario = 1;
            }
            else if (rbInactivoMantenimiento.Checked == true)
            {
                EstatusIntermediario = 2;
            }

            //SACAMOS EL NOMBRE DEL USUARIO QUE ESTA PROCESANDO LA INFORMACION
            var SacarNombreUsuario = ObjData.BuscaUsuarios(
                Convert.ToDecimal(Session["IdUsuario"]), null, null, null, null, null, null, null, null);
            foreach (var nUsuario in SacarNombreUsuario)
            {
                UsuarioProcesa = nUsuario.Persona;
            }

            //SACAMOS LOS CANALES DE DISTRIBUCION
            switch (CodigoCanalDistribucion)
            {
                case 1:
                    CanalDistribucion = "Agentes";
                    break;

                case 2:
                    CanalDistribucion = "Corredor";
                    break;

                case 3:
                    CanalDistribucion = "Canales Alternos";
                    break;

                case 4:
                    CanalDistribucion = "Banca Seguros";
                    break;

                case 5:
                    CanalDistribucion = "Dealers";
                    break;

                case 6:
                    CanalDistribucion = "Gerente Senior";
                    break;

                default:
                    CanalDistribucion = "Agentes";
                    break;
            }
            //SACAMOS LA PUBLICIDAD O SI EL INTERMEDIARIO ES DIRECTO O NO
            if (rbIntermediarioDirectoMantenimiento.Checked == true)
            {
                Publicidad = 1;
            }
            else if (rbIntermediarioNoDirectoMantenimiento.Checked == true)
            {
                Publicidad = 0;
            }

            //SACAMOS EL TIPO DE PAGO
            if (rbChequeMantenimiento.Checked == true)
            {
                TipoPago = "CK";
            }
            else if (rbEfectivoMantenimiento.Checked == true)
            {
                TipoPago = "EF";
            }
            else if (rbTransferenciaMantenimiento.Checked == true)
            {
                TipoPago = "DP";
            }
            else if (rbCuentasPorPagar.Checked == true)
            {
                TipoPago = "CXP";
            }

            //SACAMOS LA RETENCION DEL INTERMEDIARIO
            if (rbRetencionSiMantenimiento.Checked == true)
            {
                Retencion = "S";
            }
            else if (rbRetencionNoMantenimiento.Checked == true)
            {
                Retencion = "N";
            }

            //SACAMOS EL TIPO DE CUENTA DEL INTERMEDIARIO
            if (rbCuentaAhorroMantenimiento.Checked == true)
            {
                TipoCuenta = "Ahorro";
            }
            else if (rbCuentaCorrienteMantenimiento.Checked == true)
            {
                TipoCuenta = "Corriente";
            }
            else if (rbTarjetaMantenimiento.Checked == true)
            {
                TipoCuenta = "Tarjeta";
            }
            else if (rbPrestamoMantenimiento.Checked == true)
            {
                TipoCuenta = "Prestamo";
            }


            MANIntermediario(CodigoIntermediario, EstatusIntermediario, UsuarioProcesa, CanalDistribucion, Publicidad.ToString(), TipoPago, Retencion, TipoCuenta, lbAccionTomar.Text);


            decimal CodigoVendedorAfectado = 0;
            if (lbAccionTomar.Text == "UPDATE")
            {
                CodigoVendedorAfectado = Convert.ToDecimal(lbCodigoSeleccionadoVariable.Text);

            }
            else
            {
                //SACAMOS EL CODIGO MAXIMO PARA REALIZAR LA CONSULTA

                var SacarCodigoMaximo = Objdatamantenimientos.SacarCodigoMaximo();
                foreach (var n in SacarCodigoMaximo)
                {
                    CodigoVendedorAfectado = Convert.ToDecimal(n.Codigo);
                }

                //EN ESTA PARTE INGRESAMOS LOS DATOS DE LAS COMISIONES DEL INTERMEDIARIO CREADO
                //BUSCAMOS LAS COMISIONES POR DEFECTO
                var BuscarComisionesPorDefecto = Objdatamantenimientos.BuscaComisionesPorDefecto(
                    new Nullable<decimal>(),
                    null, null);
                foreach (var nNuevoPorDefecto in BuscarComisionesPorDefecto)
                {
                    //GUARDAMOS LOS DATOS DE LAS COMISIONES DEL INTERMEDIARIO
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionComisionesIntermediarioSeleccionado NuevaComision = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionComisionesIntermediarioSeleccionado(
                        30,
                        (int)CodigoVendedorAfectado,
                        (int)nNuevoPorDefecto.CodRamo,
                        (int)nNuevoPorDefecto.CodSubramo,
                        (decimal)nNuevoPorDefecto.PorcientoComision,
                        0,
                        0,
                        0,
                        new Guid(),
                        UsuarioProcesa,
                        "INSERT");
                    NuevaComision.ProcesarInformacion();
                }

            }
            MANIntermediarioCadenaDetalle(30, Convert.ToInt32(CodigoVendedorAfectado), Convert.ToInt32(txtCodigoSupervisorMantenimiento.Text), UsuarioProcesa, lbAccionTomar.Text);

            CurrentPage = 0;
            var Buscar = Objdatamantenimientos.BuscaListadoIntermediario(CodigoVendedorAfectado.ToString(), null, null, null, null);
            Paginar(ref rpListado, Buscar, 1, ref lbCantidadPaginaVariableIntermediariosSupervisores, ref LinkPrimeraPaginaIntermediariosSupervisores, ref LinkAnteriorIntermediariosSupervisores, ref LinkSiguienteIntermediariosSupervisores, ref LinkUltimoIntermediariosSupervisores);
            HandlePaging(ref dtPaginacionIntermediariosSupervisores, ref lbPaginaActualVariavleIntermediariosSupervisores);
            LimpiarControles();

            ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
        }
        #endregion

        #region VOLVER ATRAS
        private void VolverAtras() {
            DivBloqueConsulta.Visible = true;
            DivBloqueMantenimiento.Visible = false;
            DivBloqueComisiones.Visible = false;
            DivBloqueInternoComision.Visible = false;
        }
        #endregion


        #region LIMPIAR CONTROLES
        private void LimpiarControles() {

            CargaroficinaConsulta();
            //LIMPIAMOS LOS CONTROLES
            txtFechaEntradaMantenimiento.Text = string.Empty;
            txtFechaNacimientoMantenimiento.Text = string.Empty;
            txtNumeroIdentificacionMantenimiento.Text = string.Empty;
            txtApellidoMantenimiento.Text = string.Empty;
            txtNombreMantenimiento.Text = string.Empty;
            txtNombreIntermediarioConsulta.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtContactoMantenimiento.Text = string.Empty;
            txtCodigoSupervisorMantenimiento.Text = string.Empty;
            txtNombreSupervisorMantenimiento.Text = string.Empty;
            txtNumeroCuentaMantenimiento.Text = string.Empty;
            txtTelefono1Mantenimiento.Text = string.Empty;
            txtTelefono2Mantenimiento.Text = string.Empty;
            txtTelefono3Mantenimiento.Text = string.Empty;
            txtCelularMantenimiento.Text = string.Empty;
            txtFAxMantenimiento.Text = string.Empty;
            txtEmailMantenimiento.Text = string.Empty;




            txtCodigoIntermediarioConsulta.Text = string.Empty;

            btnConsultar.Enabled = true;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnRestabelcer.Enabled = false;

        }
        #endregion

        #region Restablecer Pantalla
        private void RestablecerPantalla() {
            LimpiarControles();
            CurrentPage = 0;
            MostrarIntermediariosSupervisores();
        }
        #endregion

        #region SACAR LOS DATOS DEL INTERMEDIARIO SELECCIONADO PARA MODIFICAR
        private void SacarDatosIntermediario(string CodigoIntermediario) {

            string RetencionIntermediario = "";
            int EstatusIntermediario = 0, IntermediarioDirecto = 0;


            var SacarInformacion = Objdatamantenimientos.BuscaListadoIntermediario(CodigoIntermediario, null, null, null, null);
            foreach (var n in SacarInformacion) {
                RetencionIntermediario = n.Retencion;
                EstatusIntermediario = Convert.ToInt32(n.Estatus0);
                IntermediarioDirecto = Convert.ToInt32(n.Publicidad);
                if (RetencionIntermediario == "S")
                {
                    rbRetencionNoMantenimiento.Checked = false;
                    rbRetencionSiMantenimiento.Checked = true;
                }
                else
                {
                    rbRetencionSiMantenimiento.Checked = false;
                    rbRetencionNoMantenimiento.Checked = true;
                }


                //SACAMOS EL ESTATUS
                if (EstatusIntermediario == 1)
                {
                    rbInactivoMantenimiento.Checked = false;
                    rbActivoMantenimiento.Checked = true;
                }
                else
                {
                    rbActivoMantenimiento.Checked = false;
                    rbInactivoMantenimiento.Checked = true;
                }

                //VALIDAMOS SI EL INTERMEDIARIO ES DIRECTO O NO, (EN LA TABLA ESTE CAMPO SE LLAMA PUBLICIDAD)
                if (IntermediarioDirecto == 1)
                {
                    rbIntermediarioNoDirectoMantenimiento.Checked = false;
                    rbIntermediarioDirectoMantenimiento.Checked = true;
                }
                else
                {
                    rbIntermediarioDirectoMantenimiento.Checked = false;
                    rbIntermediarioNoDirectoMantenimiento.Checked = true;
                }


                //SACAMOS LAS FECHA DE ENTRADA Y NACIMIENTO
                DateTime FechaEntrada = Convert.ToDateTime(n.Fecha_Entrada);
                DateTime FechaNacimiento = Convert.ToDateTime(n.Fec_Nac);
                txtFechaEntradaMantenimiento.Text = FechaEntrada.ToString("yyyy-MM-dd");
                txtFechaNacimientoMantenimiento.Text = FechaNacimiento.ToString("yyyy-MM-dd");

                //SACAMOS EL TIPO Y EL NUMERO DE RNC
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarTipoIdentificacionMantenimiento, n.TipoRnc.ToString());
                txtNumeroIdentificacionMantenimiento.Text = n.Rnc;


                //SACAMOS LOS DATOS GENERALES DEL INTERMEDIRIO
                txtApellidoMantenimiento.Text = n.Apellido;
                txtNombreMantenimiento.Text = n.Nombre;
                txtDireccion.Text = n.Direccion;
                txtContactoMantenimiento.Text = n.Agencia;
                txtCodigoSupervisorMantenimiento.Text = n.VendedorCrea.ToString();

                //SACAMOS EL NOMBRE DEL SUPERVISOR
                if (string.IsNullOrEmpty(txtCodigoSupervisorMantenimiento.Text.Trim()))
                {
                    txtNombreSupervisorMantenimiento.Text = "";
                }
                else
                {
                    string _CodigoSupervisorSacado = string.IsNullOrEmpty(txtCodigoSupervisorMantenimiento.Text.Trim()) ? "0" : txtNombreSupervisorMantenimiento.Text.Trim();
                    UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(_CodigoSupervisorSacado);
                    txtNombreSupervisorMantenimiento.Text = Nombre.SacarNombreSupervisor();
                  
                }

                //SACAMOS LOS DATOS DE LA UBICACION GEIGRAFICA
                int CodigoPais = 0, CodigoZona = 0, CodigoProvincia = 0, CodigoMinicipio = 0, CodigoSector = 0, CodigoUbicacion = 0;


                //SACAMOS LOS DATOS DE LA UBICACION DEOGRAFICA (CODIGOS)
                var SacarCodigosUbicacionGeografica = ObjData.BuscaDatosUbicacionGeografica(
                    null,
                    null,
                    null,
                    null,
                    null,
                    Convert.ToInt32(n.Ubicacion));
                foreach (var nGeografia in SacarCodigosUbicacionGeografica)
                {
                    CodigoPais = Convert.ToInt32(nGeografia.CodPais);
                    CodigoZona = Convert.ToInt32(nGeografia.CodZona);
                    CodigoProvincia = Convert.ToInt32(nGeografia.CodProvincia);
                    CodigoMinicipio = Convert.ToInt32(nGeografia.CodMunicipio);
                    CodigoSector = Convert.ToInt32(nGeografia.CodSector);
                    CodigoUbicacion = Convert.ToInt32(nGeografia.CodUbicacion);
                }
                ListaPaisMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlPaisMantenimiento, CodigoPais.ToString());
                ListaZonaMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlZonaMantenimiento, CodigoZona.ToString());
                ListaProvinciaMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlProvinciaMantenimiento, CodigoProvincia.ToString());
                ListaMunicipioMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlMunicipioMAntenimiento, CodigoMinicipio.ToString());
                ListaSectorMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSectorMantenimiento, CodigoSector.ToString());
                ListaUbicacionMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlUbicacionMantenimiento, CodigoUbicacion.ToString());


                //SACAMOS BANCO Y OFICINA
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlOficinaMAntenimiento, n.Oficina.ToString());
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlBancoMantenimiento, n.Banco.ToString());

                txtNumeroCuentaMantenimiento.Text = n.CtaBanco;

                string CanalDistribucion = n.tipo_Intermediario;
                int IdCanalDistribucion = 0;
                switch (CanalDistribucion)
                {
                    case "Agentes":
                        IdCanalDistribucion = 1;
                        break;

                    case "Corredor":
                        IdCanalDistribucion = 2;
                        break;

                    case "Canales Alternos":
                        IdCanalDistribucion = 3;
                        break;

                    case "Banca Seguros":
                        IdCanalDistribucion = 4;
                        break;

                    case "Dealers":
                        IdCanalDistribucion = 5;
                        break;

                    case "Gerente Senior":
                        IdCanalDistribucion = 6;
                        break;

                }
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlCanalDistribucionMantenimiento, IdCanalDistribucion.ToString());


                //SACAMOS EL TIPO DE CUENTA DE BANCO
                string TipoCuentaBanco = n.TipoCuentaBco;
                switch (TipoCuentaBanco)
                {
                    case "Ahorro":
                        rbCuentaCorrienteMantenimiento.Checked = false;
                        rbTarjetaMantenimiento.Checked = false;
                        rbPrestamoMantenimiento.Checked = false;
                        rbCuentaAhorroMantenimiento.Checked = true;
                        break;

                    case "Corriente":
                        rbTarjetaMantenimiento.Checked = false;
                        rbPrestamoMantenimiento.Checked = false;
                        rbCuentaAhorroMantenimiento.Checked = false;
                        rbCuentaCorrienteMantenimiento.Checked = true;
                        break;

                    case "Tarjeta":
                        rbPrestamoMantenimiento.Checked = false;
                        rbCuentaAhorroMantenimiento.Checked = false;
                        rbCuentaCorrienteMantenimiento.Checked = false;
                        rbTarjetaMantenimiento.Checked = true;
                        break;
                    case "Prestamo":
                        rbCuentaAhorroMantenimiento.Checked = false;
                        rbCuentaCorrienteMantenimiento.Checked = false;
                        rbTarjetaMantenimiento.Checked = false;
                        rbPrestamoMantenimiento.Checked = true;
                        break;
                    default:
                        rbCuentaCorrienteMantenimiento.Checked = false;
                        rbTarjetaMantenimiento.Checked = false;
                        rbPrestamoMantenimiento.Checked = false;
                        rbCuentaAhorroMantenimiento.Checked = true;
                        break;
                }


                //SACAMOS EL TIPO DE OCBRO
                string TipoCobro = n.PagoComPor;
                switch (TipoCobro)
                {
                    case "CK":
                        rbEfectivoMantenimiento.Checked = false;
                        rbTransferenciaMantenimiento.Checked = false;
                        rbCuentasPorPagar.Checked = false;
                        rbChequeMantenimiento.Checked = true;
                        break;

                    case "EF":
                        rbTransferenciaMantenimiento.Checked = false;
                        rbCuentasPorPagar.Checked = false;
                        rbChequeMantenimiento.Checked = false;
                        rbEfectivoMantenimiento.Checked = true;
                        break;

                    case "DP":
                        rbCuentasPorPagar.Checked = false;
                        rbChequeMantenimiento.Checked = false;
                        rbEfectivoMantenimiento.Checked = false;
                        rbTransferenciaMantenimiento.Checked = true;
                        break;

                    case "CXP":
                        rbChequeMantenimiento.Checked = false;
                        rbEfectivoMantenimiento.Checked = false;
                        rbTransferenciaMantenimiento.Checked = false;
                        rbCuentasPorPagar.Checked = true;
                        break;
                }


                //SACAMOS LOS DATOS DE LA COMUNICACION
                txtTelefono1Mantenimiento.Text = n.Telefono;
                txtTelefono2Mantenimiento.Text = n.TelefonoOficina;
                txtTelefono3Mantenimiento.Text = n.Beeper;
                txtCelularMantenimiento.Text = n.Celular;
                txtFAxMantenimiento.Text = n.Fax;
                txtEmailMantenimiento.Text = n.Email;
                txtComentarioMantenimiento.Text = n.nota;





            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario SacarNombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = SacarNombre.SacarNombreUsuarioConectado();
                Label lbPantallaActual = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantallaActual.Text = "MANTENIMIENTO INTERMEDIARIOS / SUPERVISORES";
                CargaroficinaConsulta();
                CurrentPage = 0;
                MostrarIntermediariosSupervisores();
                DivBloqueConsulta.Visible = true;
                DivBloqueMantenimiento.Visible = false;
                DivBloqueComisiones.Visible = false;
                DivBloqueInternoComision.Visible = false;
                btnModificar.Enabled = false;
                btnComisiones.Enabled = false;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarIntermediariosSupervisores();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lbAccionTomar.Text = "INSERT";
            DivBloqueConsulta.Visible = false;
            DivBloqueComisiones.Visible = false;
            DivBloqueInternoComision.Visible = false;
            DivBloqueMantenimiento.Visible = true;
            CargarConfiguracionesInicialesBloqueMantenimiento();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            lbAccionTomar.Text = "UPDATE";
            DivBloqueConsulta.Visible = false;
            DivBloqueComisiones.Visible = false;
            DivBloqueInternoComision.Visible = false;
            DivBloqueMantenimiento.Visible = true;
            CargarConfiguracionesInicialesBloqueMantenimiento();
            SacarDatosIntermediario(lbCodigoSeleccionadoVariable.Text);
        }

        protected void btnComisiones_Click(object sender, EventArgs e)
        {

        }

        protected void btnRestabelcer_Click(object sender, EventArgs e)
        {
            RestablecerPantalla();
        }

        protected void btnSeleccionarRegistro_Click(object sender, EventArgs e)
        {
            /*var RegistroSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfRegistroSeleccionado = ((HiddenField)RegistroSeleccionado.FindControl("hfIdRegistroSeleccionado")).Value.ToString();*/

            var RegistroSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfIdRegistroSeleccionado = ((HiddenField)RegistroSeleccionado.FindControl("hfIdRegistroSeleccionado")).Value.ToString();
            lbCodigoSeleccionadoVariable.Text = hfIdRegistroSeleccionado.ToString();
            var BuscarRegistroSeleccionado = Objdatamantenimientos.BuscaListadoIntermediario(lbCodigoSeleccionadoVariable.Text, null, null, null, null);
            Paginar(ref rpListado, BuscarRegistroSeleccionado, 1, ref lbCantidadPaginaVariableIntermediariosSupervisores, ref LinkPrimeraPaginaIntermediariosSupervisores, ref LinkAnteriorIntermediariosSupervisores, ref LinkSiguienteIntermediariosSupervisores, ref LinkUltimoIntermediariosSupervisores);
            HandlePaging(ref dtPaginacionIntermediariosSupervisores, ref lbPaginaActualVariavleIntermediariosSupervisores);

            btnConsultar.Enabled = false;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = true;
            btnRestabelcer.Enabled = true;


        }

        protected void LinkPrimeraPaginaIntermediariosSupervisores_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarIntermediariosSupervisores();

        }

        protected void LinkAnteriorIntermediariosSupervisores_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarIntermediariosSupervisores();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleIntermediariosSupervisores, ref lbCantidadPaginaVariableIntermediariosSupervisores);
        }

        protected void dtPaginacionIntermediariosSupervisores_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionIntermediariosSupervisores_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarIntermediariosSupervisores();
        }

        protected void LinkSiguienteIntermediariosSupervisores_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarIntermediariosSupervisores();
        }

        protected void btnGuardarMantenimiento_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaEntradaMantenimiento.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CampoFechaEntradaVacio()", "CampoFechaEntradaVacio();", true);
            }
            else {
                if (string.IsNullOrEmpty(txtFechaNacimientoMantenimiento.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaNAcimientoVacio()", "CampoFechaNAcimientoVacio();", true);
                }
                else {
                    if (string.IsNullOrEmpty(txtTelefono1Mantenimiento.Text.Trim()) && string.IsNullOrEmpty(txtTelefono2Mantenimiento.Text.Trim()) && string.IsNullOrEmpty(txtTelefono3Mantenimiento.Text.Trim()) && string.IsNullOrEmpty(txtCelularMantenimiento.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "CamposComunicacionVacios(),", "CamposComunicacionVacios();", true);
                    }
                    else
                    {
                        ProcesarInformacionRegistros();
                        VolverAtras();
                        LimpiarControles();
                    }
                }
            }

        }

        protected void btnVolverAtrasMantenimiento_Click(object sender, EventArgs e)
        {
            VolverAtras();
            LimpiarControles();
        }

        protected void btnConsultarComisiones_Click(object sender, EventArgs e)
        {

        }

        protected void btnValidarClaveSeguridad_Click(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionarComision_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPaginaIntermediariosSupervisoresComisiones_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorIntermediariosSupervisoresComisiones_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionIntermediariosSupervisoresComisiones_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionIntermediariosSupervisoresComisiones_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteIntermediariosSupervisoresComisiones_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoIntermediariosSupervisoresComisiones_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificarComision_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancearProceso_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverAtrasComisiones_Click(object sender, EventArgs e)
        {
            VolverAtras();
            LimpiarControles();
        }

        protected void ddlPaisMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaZonaMantenimiento();
            ListaProvinciaMantenimiento();
            ListaMunicipioMantenimiento();
            ListaSectorMantenimiento();
            ListaUbicacionMantenimiento();
        }

        protected void ddlZonaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaProvinciaMantenimiento();
            ListaMunicipioMantenimiento();
            ListaSectorMantenimiento();
            ListaUbicacionMantenimiento();
        }

        protected void ddlProvinciaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaMunicipioMantenimiento();
            ListaSectorMantenimiento();
            ListaUbicacionMantenimiento();
        }

        protected void ddlMunicipioMAntenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaSectorMantenimiento();
            ListaUbicacionMantenimiento();
        }

        protected void ddlSectorMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaUbicacionMantenimiento();
        }

        protected void txtCodigoSupervisorMantenimiento_TextChanged(object sender, EventArgs e)
        {
            try {
                string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorMantenimiento.Text.Trim()) ? null : txtCodigoSupervisorMantenimiento.Text.Trim();
                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(_CodigoSupervisor);
                txtNombreSupervisorMantenimiento.Text = Nombre.SacarNombreSupervisor();
            }
            catch (Exception) {
                txtNombreSupervisorMantenimiento.Text = "";
            }
        }

        protected void LinkUltimoIntermediariosSupervisores_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarIntermediariosSupervisores();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleIntermediariosSupervisores, ref lbCantidadPaginaVariableIntermediariosSupervisores);
        }
    }
}