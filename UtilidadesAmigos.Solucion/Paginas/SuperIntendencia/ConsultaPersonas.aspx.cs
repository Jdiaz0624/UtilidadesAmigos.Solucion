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
                        //ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Intermediario, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        //ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Intermediario, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbProvedor.Checked == true) {
                        //ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Proveedores, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        //ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Proveedores, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbAseguradoBajoPoliza.Checked == true) {
                        //ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.AseguradoBajoPoliza, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        //ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.AseguradoBajoPoliza, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbAsegurado.Checked == true) {
                        //ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Asegurado, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        //ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Asegurado, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbDependiente.Checked == true) {
                        //ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Dependiente, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        //ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Dependiente, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbCheque.Checked == true) {
                        //ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Cheque, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        //ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Cheque, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbDocumentosAmigos.Checked == true) {
                        //ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.DocumentosAmigos, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        //ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.DocumentosAmigos, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbReclamaciones.Checked == true) {
                        //ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Reclamaciones, (int)TipoBusquedaProceso.BusquedaPorNombre);
                        //ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Reclamaciones, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbPlaca.Checked == true) {
                      //  ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Placa, (int)TipoBusquedaProceso.BusquedaPorNombre);
                       // ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Placa, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                    if (cbChasis.Checked == true) {
                      //  ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Chasis, (int)TipoBusquedaProceso.BusquedaPorNombre);
                      //  ProcesarInformacionPersonasSuperIntendenciaPorLote(IdUsuario, (int)BuscarComo.Chasis, (int)TipoBusquedaProceso.BusquedaPorRNC);
                    }
                }
                else if (rbPorNombreBusquedaPorLote.Checked == true) {
                    if (cbCliente.Checked == true) { }
                    if (cbIntermediario.Checked == true) { }
                    if (cbProvedor.Checked == true) { }
                    if (cbAseguradoBajoPoliza.Checked == true) { }
                    if (cbAsegurado.Checked == true) { }
                    if (cbDependiente.Checked == true) { }
                    if (cbCheque.Checked == true) { }
                    if (cbDocumentosAmigos.Checked == true) { }
                    if (cbReclamaciones.Checked == true) { }
                    if (cbPlaca.Checked == true) { }
                    if (cbChasis.Checked == true) { }
                }
                else if (rbNumeroIdentificacionBusquedaPorLote.Checked == true) {
                    if (cbCliente.Checked == true) { }
                    if (cbIntermediario.Checked == true) { }
                    if (cbProvedor.Checked == true) { }
                    if (cbAseguradoBajoPoliza.Checked == true) { }
                    if (cbAsegurado.Checked == true) { }
                    if (cbDependiente.Checked == true) { }
                    if (cbCheque.Checked == true) { }
                    if (cbDocumentosAmigos.Checked == true) { }
                    if (cbReclamaciones.Checked == true) { }

                }
                else if (rbPlacaBusquedaPorLote.Checked == true) {

                    if (cbPlaca.Checked == true) { }
                }
                else if (rbChasisBusquedaPorLote.Checked == true) {

                    if (cbChasis.Checked == true) { }
                }
             
            
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

                Paginar(ref rpListadoBusquedaCliente, BuscarListado, 10, ref lbCantidadPaginaVAriableCliente, ref LinkPrimeraPaginaCliente, ref LinkAnteriorCliente, ref LinkSiguienteCliente, ref LinkUltimoCliente);
                HandlePaging(ref dtPaginacionCliente, ref lbPaginaActualVariavleCliente);
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
                Paginar(ref rpListadoIntermediarios, Listado, 10, ref lbCantidadPaginaVAriableIntermedairaio, ref LinkPrimeroIntermediario, ref LinkAnteriorIntermediario, ref LinkSiguienteCliente, ref LinkUltimoIntermediario);
                HandlePaging(ref dtIntermediario, ref lbPaginaActualVariavleIntermediario);
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
            Paginar(ref rpListadoBusquedaCliente, BuscarRegistroSeleccionado, 1, ref lbCantidadPaginaVAriableCliente, ref LinkPrimeraPaginaCliente, ref LinkAnteriorCliente, ref LinkSiguienteCliente, ref LinkUltimoCliente);
            HandlePaging(ref dtPaginacionCliente, ref lbPaginaActualVariavleCliente);
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
                Paginar(ref rpListadoProveedores, Listado, 10, ref lbCantidadPaginaVAriableProveedor, ref LinkPrimeroProveedor, ref LinkAnteriorProveedor, ref LinkSiguienteProveedor, ref LinkUltimoProveedor);
                HandlePaging(ref dtProveedor, ref lbPaginaActualVariavleProveedor);
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

                    Paginar(ref rpListadoRegistrosasegurado, Buscar, 10, ref lbCantidadPaginaVAriableAsegurado, ref LinkPrimeroAsegurado, ref LinkAnteriorAsegurado, ref LinkSiguienteAsegurado, ref LinkUltimaAsegurado);
                    HandlePaging(ref dtAsegurado, ref lbPaginaActualVariavleAsegurado);
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

                Paginar(ref rpIDListadoAseguradoGeneral, BuscarRegistro, 10, ref lbCantidadPaginaVAriableAseguradoGeneral, ref LinkPrimeroAseguradoGeneral, ref LinkAnteriorAseguradoGeneral, ref LinkSiguienteAseguradoGeneral, ref LinkUltimoAseguradoGeneral);
                HandlePaging(ref dtAseguradoGeneral, ref lbPaginaActualVariavleAseguradoGeneral);
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

                Paginar(ref rpListadoDependientes, Buscar, 10, ref lbCantidadPaginaVAriableDependiente, ref LinkPrimeroDependiente, ref LinkAnteriorDependiente, ref LinkSiguienteDependiente, ref LinkUltimoDependiente);
                HandlePaging(ref dtDependiente, ref lbPaginaActualVariavleDependiente);
                DivPaginacionDependiente.Visible = true;
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


                rbExportarPDF.Checked = true;
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

        protected void btnSeleccionarRegistrosBusquedaCliente_Click(object sender, EventArgs e)
        {
            var PolizaSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var hfPolizaSeleccionada = ((HiddenField)PolizaSeleccionada.FindControl("hfPolizaBusquedaCliente")).Value.ToString();

            var CotizacionSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var hfCotizacionSeleccionada = ((HiddenField)CotizacionSeleccionada.FindControl("hfCotizacionBusquedaCliente")).Value.ToString();

            var SecuenciaSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var hfSecuenciaSeleccionada = ((HiddenField)SecuenciaSeleccionada.FindControl("hfSecuenciaBusquedaCliente")).Value.ToString();

            SeleccionarRegistrosClientes(hfPolizaSeleccionada.ToString(), Convert.ToDecimal(hfCotizacionSeleccionada), Convert.ToDecimal(hfSecuenciaSeleccionada), 1);
            DivBloqueDetalleCliente.Visible = true;
        }

        protected void LinkPrimeraPaginaCliente_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoClientes(1);
        }

        protected void LinkAnteriorCliente_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoClientes(1);
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleCliente, ref lbCantidadPaginaVAriableCliente);
        }

        protected void dtPaginacionCliente_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoClientes(1);
        }

        protected void dtPaginacionCliente_ItemDataBound(object sender, DataListItemEventArgs e)
        {
           
        }

        protected void LinkSiguienteCliente_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoClientes(1);
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
                    decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;
                    var BuscaInformacionRegistrada = ObjDataSuperIntendencia.Value.BuscarInformacionRegistrada(
                        IdUsuario, null, null);
                    if (BuscaInformacionRegistrada.Count() < 1) {
                        lbCantidadRegistrosProcesadosVariable.Text = "0";
                    }
                    else {
                        int CantidadEncontrada = BuscaInformacionRegistrada.Count;
                        lbCantidadRegistrosProcesadosVariable.Text = CantidadEncontrada.ToString("N0");
                        Paginar(ref rpRegistrosCargadoArchivo, BuscaInformacionRegistrada, 10, ref lbCantidadPaginaVAriableArchivo, ref LinkPrimeroArchivo, ref LinkAnteriorArchivo, ref LinkSiguienteArchivo, ref LinkUltimoArchivo);
                        HandlePaging(ref dtArchivo, ref lbPaginaActualVariavleArchivo);
                    }
                    
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

        protected void btnSeleccionarIntermediarioRepeater_Click(object sender, EventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfCodigoIntermediario = ((HiddenField)ItemSeleccionado.FindControl("hfCodigointermediario")).Value.ToString();

            var BuscarRegistroSeleccionado = ObjDataSuperIntendencia.Value.BuscaPersonasSuperIntendenciaIntermediario(Convert.ToInt32(hfCodigoIntermediario), null, null);
            Paginar(ref rpListadoIntermediarios, BuscarRegistroSeleccionado, 10, ref lbCantidadPaginaVAriableIntermedairaio, ref LinkPrimeroIntermediario, ref LinkAnteriorIntermediario, ref LinkSiguienteCliente, ref LinkUltimoIntermediario);
            HandlePaging(ref dtIntermediario, ref lbPaginaActualVariavleIntermediario);
            DivPaginacionIntermediario.Visible = true;
            foreach (var n in BuscarRegistroSeleccionado) {
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

        protected void LinkPrimeroIntermediario_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoIntermediarios();
        }

        protected void LinkAnteriorIntermediario_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoIntermediarios();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleIntermediario, ref lbCantidadPaginaVAriableIntermedairaio);
        }

        protected void dtIntermediario_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoIntermediarios();
        }

        protected void dtIntermediario_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void LinkSiguienteIntermediario_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoIntermediarios();
        }

        protected void LinkUltimoIntermediario_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoIntermediarios();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleIntermediario, ref lbCantidadPaginaVAriableIntermedairaio);
        }

        protected void btnSeleccionarRegistroProveedor_Click(object sender, EventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfCodigoProveedor = ((HiddenField)ItemSeleccionado.FindControl("hfCodigoproveedor")).Value.ToString();

            var BuscarRegistros = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaProveedor(
                Convert.ToInt32(hfCodigoProveedor));
            Paginar(ref rpListadoProveedores, BuscarRegistros, 1, ref lbCantidadPaginaVAriableProveedor, ref LinkPrimeroProveedor, ref LinkPrimeroProveedor, ref LinkSiguienteProveedor, ref LinkUltimoProveedor);
            HandlePaging(ref dtProveedor, ref lbPaginaActualVariavleProveedor);
            foreach (var n in BuscarRegistros) {
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

        protected void LinkPrimeroProveedor_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoProveedores();
        }

        protected void LinkAnteriorProveedor_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoProveedores();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleProveedor, ref lbCantidadPaginaVAriableProveedor);
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

        protected void LinkSiguienteProveedor_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoProveedores();
        }

        protected void LinkUltimoProveedor_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoProveedores();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleProveedor, ref lbCantidadPaginaVAriableProveedor);
        }

        protected void btnSeleccionarRegistrosInformacionAsegurado_Click(object sender, EventArgs e)
        {
            var PolizaSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var HfPolizaSeleccionada = ((HiddenField)PolizaSeleccionada.FindControl("hfPolizaInformacionAsegurado")).Value.ToString();

            var CotizzacionSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var HfCotizzacionSeleccionada = ((HiddenField)CotizzacionSeleccionada.FindControl("hfCotizacionInformacionAsegurado")).Value.ToString();

            var itemSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var HFitemSeleccionado = ((HiddenField)itemSeleccionado.FindControl("hfSecuenciaInformacionAsegurado")).Value.ToString();

            var SacarInformacion = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaAsegurado(
                null,
                HfPolizaSeleccionada,
                Convert.ToDecimal(HfCotizzacionSeleccionada),
                Convert.ToInt32(HFitemSeleccionado));
            Paginar(ref rpListadoRegistrosasegurado, SacarInformacion, 1, ref lbCantidadPaginaVAriableAsegurado, ref LinkPrimeroAsegurado, ref LinkAnteriorAsegurado, ref LinkSiguienteAsegurado, ref LinkUltimaAsegurado);
            HandlePaging(ref dtAsegurado, ref lbPaginaActualVariavleAsegurado);
            foreach (var n in SacarInformacion) {
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

        protected void LinkPrimeroAsegurado_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoAsegurado();
        }

        protected void LinkAnteriorAsegurado_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoAsegurado();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleAsegurado, ref lbCantidadPaginaVAriableAsegurado);
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

        protected void LinkSiguienteAsegurado_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoAsegurado();
        }

        protected void LinkUltimaAsegurado_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoAsegurado();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleAsegurado, ref lbCantidadPaginaVAriableAsegurado);
        }

        protected void LinkPrimeroAseguradoGeneral_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoAseguradoGeneral();
        }

        protected void LinkAnteriorAseguradoGeneral_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoAseguradoGeneral();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleAseguradoGeneral, ref lbCantidadPaginaVAriableAseguradoGeneral);
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

        protected void LinkSiguienteAseguradoGeneral_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoAseguradoGeneral();
        }

        protected void LinkUltimoAseguradoGeneral_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoAseguradoGeneral();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleAseguradoGeneral, ref lbCantidadPaginaVAriableAseguradoGeneral);
        }

        protected void btnSeleccionarRegistroAseguradoGeneral_Click(object sender, EventArgs e)
        {
            var CotizacionSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var hfControlCotiacionSeleccionada = ((HiddenField)CotizacionSeleccionada.FindControl("hfCotizacionAseguradoGeneral")).Value.ToString();

            var SecuenciaSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var hfControlSecuenciaSeleccionada = ((HiddenField)SecuenciaSeleccionada.FindControl("hfItemAseguradoGeneral")).Value.ToString();

            var NumeroAseguradoSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var hfControlNumeroAseguradoSeleccionada = ((HiddenField)NumeroAseguradoSeleccionada.FindControl("hfIdAseguradoAseguradoGeneral")).Value.ToString();

            var Seleccionrregistro = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaAseguradoGeneral(
                null, null,
                Convert.ToDecimal(hfControlCotiacionSeleccionada),
                Convert.ToDecimal(hfControlSecuenciaSeleccionada),
                Convert.ToDecimal(hfControlNumeroAseguradoSeleccionada));
            Paginar(ref rpIDListadoAseguradoGeneral, Seleccionrregistro, 1, ref lbCantidadPaginaVAriableAseguradoGeneral, ref LinkPrimeroAseguradoGeneral, ref LinkAnteriorAseguradoGeneral, ref LinkSiguienteAseguradoGeneral, ref LinkUltimoAseguradoGeneral);
            HandlePaging(ref dtAseguradoGeneral, ref lbPaginaActualVariavleAseguradoGeneral);
            foreach (var n in Seleccionrregistro) {
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

        protected void btnSeleccionarregistroDependiente_Click(object sender, EventArgs e)
        {
            var CotizacionSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var HfCotizacionSeleccionada = ((HiddenField)CotizacionSeleccionada.FindControl("hfCotizacionDependiente")).Value.ToString();

            var SecuenciaSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var HfSecuenciaSeleccionada = ((HiddenField)SecuenciaSeleccionada.FindControl("hfSecuenciaDependiente")).Value.ToString();

            var IdaseguradoSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfIdAseguradoSeleccionado = ((HiddenField)IdaseguradoSeleccionado.FindControl("hfIdAseguradoDependiente")).Value.ToString();

            var RegistroSeleccionado = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaDependente(
                null, null,
                Convert.ToDecimal(HfCotizacionSeleccionada),
                Convert.ToDecimal(HfSecuenciaSeleccionada),
                Convert.ToDecimal(hfIdAseguradoSeleccionado));
            Paginar(ref rpListadoDependientes, RegistroSeleccionado, 1, ref lbCantidadPaginaVAriableDependiente, ref LinkPrimeroDependiente, ref LinkAnteriorDependiente, ref LinkSiguienteDependiente, ref LinkUltimoDependiente);
            HandlePaging(ref dtDependiente, ref lbPaginaActualVariavleDependiente);
            foreach (var n in RegistroSeleccionado) {
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

        protected void LinkPrimeroDependiente_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoDependientes();
        }

        protected void LinkAnteriorDependiente_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoDependientes();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleDependiente, ref lbCantidadPaginaVAriableDependiente);
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

        protected void LinkSiguienteDependiente_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoDependientes();
        }

        protected void LinkUltimoDependiente_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoDependientes();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleDependiente, ref lbCantidadPaginaVAriableDependiente);
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

        protected void LinkPrimeroArchivo_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorArchivo_Click(object sender, EventArgs e)
        {

        }

        protected void dtArchivo_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtArchivo_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteArchivo_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoArchivo_Click(object sender, EventArgs e)
        {

        }

        protected void btnProcesarRegistros_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {

                ProcesarInformacionPorlote((decimal)Session["IdUsuario"]);

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

        protected void LinkUltimoCliente_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoClientes(1);
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleCliente, ref lbCantidadPaginaVAriableCliente);
        }
    }
}