using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SpreadsheetLight;
using System.IO;
using UtilidadesAmigos.Logica.Entidades;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ValidarCoberturas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad> ObjDataSeguridad = new Lazy<Logica.Logica.LogicaSeguridad.LogicaSeguridad>();

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

        enum CodigoServicios { 
        GrupoNobe=1,
        Proinsa=2,
        CasaConductor=3,
        CentroAutomovilista=4
        }

        enum CodigosPlanServicio { 
        TuAsistencia_Premium=32,
        TuAsistencia_Superior=37,
        TuAsistencia_Basica=38,
        GruaVIP=42,
        GruaBasicoMini=43,
        GruaBasicoLiviano=44,
        CasaConductor=17,
        CentroAutomovilista=40
        }

        enum RutasArchivosGuardados { 
        
            VolantePagos=1,
            ArchivoTXT=2
        }


        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarServicios() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlServicio, ObjData.Value.BuscaListas("COBERTURA", null, null));
        }
        private void CargarPlanes() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPlan, ObjData.Value.BuscaListas("PLANCOBERTURA", ddlServicio.SelectedValue.ToString(), null));
        }
        private void CargarSucursales() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSucursal, ObjData.Value.BuscaListas("SUCURSAL", null, null),true);
        }
        private void Cargaroficinas() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficina, ObjData.Value.BuscaListas("OFICINA", ddlSucursal.SelectedValue.ToString(), null),true);
        }
        #endregion
        #region MOSTRAR INFORMACION POR PANTALLA
        private void MostrarInformacionCpobertutasPorPantalla() {

            DateTime _FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime _FechaHAsta = Convert.ToDateTime(txtFechaHasta.Text);
            int _Plan = Convert.ToInt32(ddlPlan.SelectedValue);
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();

            var MostrarListado = ObjData.Value.SacarDataServiciosPorpAntalla(
                _FechaDesde,
                _FechaHAsta,
                _Poliza,
                _Plan,
                _oficina);
            if (MostrarListado.Count() < 1) {

                rpListadoGeneral.DataSource = null;
                rpListadoGeneral.DataBind();
            }
            else {
                Paginar(ref rpListadoGeneral, MostrarListado, 10, ref lbCantidadPAgina, ref btnPrimeraPagina, ref btnPaginaAnterior, ref btnSiguiente, ref btnUltimaPagina);
                HandlePaging(ref dtPaginacion, ref lbPaginaActual);
            }


            //SacarDataCoberturasFinal
        }
        #endregion
        #region EXPORTAR Y CONSULTAR INFORMACION
        private void ExportarInformacion() {

            int Servicio = Convert.ToInt32(ddlServicio.SelectedValue);

            switch (Servicio) {

                case (int)CodigoServicios.CasaConductor:
                    if (rbExcel.Checked == true) {
                        SacarDataCasaConductor();
                    }
                    else if (rbTXT.Checked == true) {
                        ClientScript.RegisterStartupScript(GetType(), "OpcionNoDisponible()", "OpcionNoDisponible();", true);
                    }
                    break;

                case (int)CodigoServicios.GrupoNobe:
                    if (rbExcel.Checked == true) {
                        GrupoNobeExcel();
                    }
                    else if (rbTXT.Checked == true) {
                        ClientScript.RegisterStartupScript(GetType(), "OpcionNoDisponible()", "OpcionNoDisponible();", true);
                    }
                    break;

                case (int)CodigoServicios.CentroAutomovilista:
                    if (rbExcel.Checked == true) {
                        CentroAutomovilistaExcel();
                    }
                    else if (rbTXT.Checked == true) {
                        CentroAutomovilistaTXT();
                    }
                    break;

                case (int)CodigoServicios.Proinsa:
                    if (rbExcel.Checked == true) {
                        SacarDataProinsa();
                    }
                    else if (rbTXT.Checked == true) {
                        ClientScript.RegisterStartupScript(GetType(), "OpcionNoDisponible()", "OpcionNoDisponible();", true);
                    }
                    break;
            }
        }

        #endregion
        #region GRUPO NOBE
        private void GrupoNobeExcel() {
            DateTime _FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime _FechaHAsta = Convert.ToDateTime(txtFechaHasta.Text);
            int _Plan = Convert.ToInt32(ddlPlan.SelectedValue);
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();

            var ExportarInformacion = (from n in ObjData.Value.SacarDataTuAsistencia(
                _FechaDesde,
                _FechaHAsta,
                _Poliza,
                _Plan,
                _oficina)
                                       select new
                                       {
                                           Nombre = n.Nombre,
                                           Apellido = n.Apellido,
                                           Poliza = n.Poliza,
                                           Ciudad = n.Ciudad,
                                           Direccion = n.Direccion,
                                           Telefono = n.Telefono,
                                           TipoIdentificacion = n.TipoIdentificacion,
                                           NumeroIdentificacion = n.NumeroIdentificacion,
                                           Tipovehiculo = n.Tipovehiculo,
                                           Marca = n.Marca,
                                           Modelo = n.Modelo,
                                           Ano = n.Ano,
                                           Color = n.Color,
                                           Chasis = n.Chasis,
                                           Placa = n.Placa,
                                           InicioVigencia = n.InicioVigencia,
                                           FinVigencia = n.FinVigencia,
                                           Estatus = n.Estatus,
                                           Cobertura = n.Cobertura,
                                           TipoMovimiento = n.TipoMovimiento
                                       }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Data Grupo Nobe " + ddlPlan.SelectedItem.Text, ExportarInformacion);



        }
        #endregion
        #region CENTRO DEL AUTOMOVILISTA
        private void CentroAutomovilistaTXT() {
            DateTime _FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime _FechaHAsta = Convert.ToDateTime(txtFechaHasta.Text);
            int _Plan = Convert.ToInt32(ddlPlan.SelectedValue);
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
            string NombreArchivo = "", Encabezado = "";
            int ano = DateTime.Now.Year;
            int Mes = DateTime.Now.Month;
            int Dia = DateTime.Now.Day;
            int Hora = DateTime.Now.Hour;
            int Minuto = DateTime.Now.Minute;
            NombreArchivo = "30" + ano.ToString() + Mes.ToString() + Dia.ToString() + Hora.ToString() + Minuto.ToString() + ".txt";
            Encabezado = "30|" + ano.ToString() + Mes.ToString() + Dia.ToString();
            var SacarInformacion = ObjData.Value.SacardataCentroAutomovilistaArchivo(_FechaDesde, _FechaHAsta, _Poliza, _Plan, _oficina);
            string RutaArchivo = "";
            UtilidadesAmigos.Logica.Comunes.SacarRutaArchivoGuardado Ruta = new Logica.Comunes.SacarRutaArchivoGuardado((int)RutasArchivosGuardados.ArchivoTXT);
            RutaArchivo = Ruta.SacarRuta();

            //ELIMINA TODOS LOS ARCHIVOS DE LA CARPETA SELECCIONADA
            DirectoryInfo Directorio = new DirectoryInfo(@"" + RutaArchivo);
            FileInfo[] files = Directorio.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }

            StreamWriter DataCentroAutomovilista = new StreamWriter(@"" + RutaArchivo + NombreArchivo, true);
            DataCentroAutomovilista.WriteLine(Encabezado);

            foreach (var n in SacarInformacion) {
                DataCentroAutomovilista.WriteLine(n.Informacion);
            }
            DataCentroAutomovilista.Close();

            //CORREOS A ENVIAR
            StreamWriter CorreosEnviar = new StreamWriter(@"" + RutaArchivo + "Correos a Enviar.txt", true);
            CorreosEnviar.WriteLine("Correos a los que se les envia la Data");
            CorreosEnviar.WriteLine("");
            CorreosEnviar.WriteLine("p.lugo@centrodelautomovilista.com");
            CorreosEnviar.WriteLine("l.boitel@centrodelautomovilista.com");
            CorreosEnviar.WriteLine("------------------------------------------------------------------------------");
            CorreosEnviar.WriteLine("Correos a los que poner en copia");
            CorreosEnviar.WriteLine("");
            CorreosEnviar.WriteLine("Alfredo.Pimentel@futuroseguros.com");
            CorreosEnviar.WriteLine("Eduard.Garcia@futuroseguros.com");
            CorreosEnviar.WriteLine("Noelia.Gonzalez@futuroseguros.com");
            CorreosEnviar.WriteLine("Juan.Diaz@futuroseguros.com");
            CorreosEnviar.WriteLine("");


            CorreosEnviar.Close();
            ClientScript.RegisterStartupScript(GetType(), "Archivogenerado()", "Archivogenerado();", true);


        }
        private void CentroAutomovilistaExcel() {
            DateTime _FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime _FechaHAsta = Convert.ToDateTime(txtFechaHasta.Text);
            int _Plan = Convert.ToInt32(ddlPlan.SelectedValue);
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();

            var Exportar = (from n in ObjData.Value.SacarDataCentroAutomovilistaDetalle(
                _FechaDesde,
                _FechaHAsta,
                _Poliza,
                _Plan,
                _oficina)
                            select new
                            {
                                Poliza = n.Poliza,
                                Referencia = n.Referencia,
                                Tipo_Poliza = n.Tipo_Poliza,
                                Tipo_ID = n.Tipo_ID,
                                Id_Propietario = n.Id_Propietario,
                                Nombre_Propietario = n.Nombre_Propietario,
                                Tipo_Vehiculo = n.Tipo_Vehiculo,
                                Marca_Vehiculo = n.Marca_Vehiculo,
                                Modelo_Vehiculo = n.Modelo_Vehiculo,
                                Color_Vehiculo = n.Color_Vehiculo,
                                Placa_Vehiculo = n.Placa_Vehiculo,
                                Chasis_Vehiculo = n.Chasis_Vehiculo,
                                Ano_Vehiculo = n.Ano_Vehiculo,
                                Inicio_Vigencia = n.Inicio_Vigencia,
                                Fin_Vigencia = n.Fin_Vigencia,
                                TipoMovimiento = n.TipoMovimiento,
                                Concepto = n.Concepto,
                                Fecha_Baja = n.Fecha_Baja
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Data Centro del Automovilista", Exportar);

        }
        #endregion
        #region CASA DEL CONDUCTOR
        private void SacarDataCasaConductor() {
            DateTime _FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime _FechaHAsta = Convert.ToDateTime(txtFechaHasta.Text);
            int _Plan = Convert.ToInt32(ddlPlan.SelectedValue);
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();

            var exportar = (from n in ObjData.Value.SacarDataCasaConductor(
                _FechaDesde,
                _FechaHAsta,
                _Poliza,
                _Plan,
                _oficina)
                            select new
                            {
                                Poliza = n.Poliza,
                                Items = n.Items,
                                Estatus = n.Estatus,
                                Concepto = n.Concepto,
                                Cliente = n.Cliente,
                                TipoIdentificacion = n.TipoIdentificacion,
                                NumeroIdentificacion = n.NumeroIdentificacion,
                                FechaInicioVigencia = n.FechaInicioVigencia,
                                FechaFinVigencia = n.FechaFinVigencia,
                                InicioVigencia = n.InicioVigencia,
                                FinVigencia = n.FinVigencia,
                                FechaProcesoBruto = n.FechaProcesoBruto,
                                FechaProceso = n.FechaProceso,
                                MesValidado = n.MesValidado,
                                Tipovehiculo = n.Tipovehiculo,
                                Marca = n.Marca,
                                Modelo = n.Modelo,
                                Capacidad = n.Capacidad,
                                Ano = n.Ano,
                                Color = n.Color,
                                Chasis = n.Chasis,
                                Placa = n.Placa,
                                ValorAsegurado = n.ValorAsegurado,
                                Cobertura = n.Cobertura,
                                TipoMovimiento = n.TipoMovimiento,
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Data Casa del Conductor", exportar);
            

        }
        #endregion
        #region PROINSA
        private void SacarDataProinsa() {
            DateTime _FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime _FechaHAsta = Convert.ToDateTime(txtFechaHasta.Text);
            int _Plan = Convert.ToInt32(ddlPlan.SelectedValue);
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
            string NombreArchivo = "Data " + ddlServicio.SelectedItem.Text + " - " + ddlPlan.SelectedItem.Text;

            var Exportar = (from n in ObjData.Value.SacarDataProinsa(
                _FechaDesde,
                _FechaHAsta,
                _Poliza,
                _Plan,
                _oficina)
                            select new
                            {
                                Poliza = n.Poliza,
                                Asegurado = n.Asegurado,
                                Inicio_Vigencia = n.Inicio_Vigencia,
                                Fin_Vigencia = n.Fin_Vigencia,
                                Marca = n.Marca_Vehiculo,
                                Modelo = n.Modelo_Vehiculo,
                                Ano = n.Ano_Vehiculo,
                                Chasis = n.Chasis_Vehiculo,
                                Placa = n.Placa_Vehiculo,
                                Tipo = n.Tipo_Vehiculo,
                                Fecha_Trabajo = n.FechaTrabajo,
                                Sucursal = n.Sucursal,
                                Cobertura = n.Cobertura,
                                Concepto = n.Concepto,
                                Movimiento = n.TipoMovimiento
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(NombreArchivo, Exportar);
        }
        #endregion


        #region COBERTURAS Y PLAN DE COBERTURAS
        private void CargarCoberturasPOPOP() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlServicio_POPOP, ObjData.Value.BuscaListas("COBERTURA", null, null),true);
        }
        private void MostrarCoberturas() {

            var MostrarCoberturas = ObjData.Value.BuscaCoberturaMantenimiento();
            rpListadoServicios.DataSource = MostrarCoberturas;
            rpListadoServicios.DataBind();
        }
        private void MostrarPlanes() {

            int? _IdCobertura = ddlServicio_POPOP.SelectedValue != "-1" ? Convert.ToInt32(ddlServicio_POPOP.SelectedValue) : new Nullable<int>();
            var MostrarPlanes = ObjData.Value.BuscaPlanCoberturas(
                new Nullable<int>(),
                _IdCobertura,
                null, null);
            if (MostrarPlanes.Count() < 1) {

                rpListadoPlan.DataSource = null;
                rpListadoPlan.DataBind();
            }
            else {
                rpListadoPlan.DataSource = MostrarPlanes;
                rpListadoPlan.DataBind();
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
                lbPantalla.Text = "GENERAR DATA DE COBERTURAS";

                SubBloqueConsulta.Visible = true;
                SubBloqueValidacion.Visible = false;
                rbExcel.Checked = true;

                //CARGAMOS LOS RANGOS DE FECHAS
                UtilidadesAmigos.Logica.Comunes.Rangofecha Rango = new Logica.Comunes.Rangofecha();
                Rango.FechaMes(ref txtFechaDesde, ref txtFechaHasta);

                CargarServicios();
                CargarPlanes();
                CargarSucursales();
                Cargaroficinas();

                MostrarCoberturas();
                CargarCoberturasPOPOP();
                MostrarPlanes();
            }
        }

        protected void cbValidarData_CheckedChanged(object sender, EventArgs e)
        {
            if (cbValidarData.Checked == true) {
                ClientScript.RegisterStartupScript(GetType(), "FuncionNodisponible();", "FuncionNodisponible();", true);
                cbValidarData.Checked = false;
                //SubBloqueConsulta.Visible = false;
                //SubBloqueValidacion.Visible = true;
            }
            else if (cbValidarData.Checked == false) {
                SubBloqueConsulta.Visible = true;
                SubBloqueValidacion.Visible = false;
            }
        }

        protected void BuscarInformacion(object sender, EventArgs e) {

            CurrentPage = 0;
            MostrarInformacionCpobertutasPorPantalla();
        }

        protected void ddlServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPlanes();
        }

        protected void ddlSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargaroficinas();
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarInformacionCpobertutasPorPantalla();
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            ExportarInformacion();
        }

        protected void btnModificarCobertura_Click(object sender, ImageClickEventArgs e)
        {
            var RegistroSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var IdCobertura = ((HiddenField)RegistroSeleccionado.FindControl("hfIdServicios_servicio")).Value.ToString();
            var Estatus = ((HiddenField)RegistroSeleccionado.FindControl("hfEstatusServicio")).Value.ToString();

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionMAntenimientoCoberturas Editar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionMAntenimientoCoberturas(
                Convert.ToDecimal(IdCobertura),
                "",
                Convert.ToBoolean(Estatus),
                "UPDATE");
            Editar.ProcesarInformacion();
            CargarServicios();
            CargarPlanes();
            MostrarCoberturas();
        }

        protected void ddlServicio_POPOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarPlanes();
        }

        protected void btnModificarCoberturaPlan_Click(object sender, ImageClickEventArgs e)
        {
            var RegistroSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var IdCobertura = ((HiddenField)RegistroSeleccionado.FindControl("hfIdServicios_servicio")).Value.ToString();
            var IdPlanCobertura = ((HiddenField)RegistroSeleccionado.FindControl("hfIdPlanCobertura")).Value.ToString();
            var Estatus = ((HiddenField)RegistroSeleccionado.FindControl("hfEstatusServicio")).Value.ToString();
            var IdCodigoCobertura = ((HiddenField)RegistroSeleccionado.FindControl("hfCodigoCobertura")).Value.ToString();

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionMantenimientoPlanCobertura Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionMantenimientoPlanCobertura(
                Convert.ToDecimal(IdPlanCobertura),
                Convert.ToDecimal(IdCobertura),
                Convert.ToDecimal(IdCodigoCobertura),
                "",
                Convert.ToBoolean(Estatus),
                "UPDATE");
            Procesar.ProcesarInformacion();

            MostrarPlanes();
        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarInformacionCpobertutasPorPantalla();
        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += -1;
            MostrarInformacionCpobertutasPorPantalla();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActual, ref lbCantidadPAgina);
        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_CancelCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarInformacionCpobertutasPorPantalla();
        }

        protected void btnSiguiente_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += 1;
            MostrarInformacionCpobertutasPorPantalla();
        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarInformacionCpobertutasPorPantalla();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.UltimaPagina, ref lbPaginaActual, ref lbCantidadPAgina);
        }

        protected void btnValidar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Plantilla_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}