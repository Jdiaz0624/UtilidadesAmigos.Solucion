using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas.Procesos
{
    public partial class GenerarBackupBaseDatos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaOpcionesAdministrador.LogicaOpcionesdministrador> ObjDataAdministrador = new Lazy<Logica.Logica.LogicaOpcionesAdministrador.LogicaOpcionesdministrador>();
        UtilidadesAmigos.Logica.Comunes.Mail Correo = new Logica.Comunes.Mail();
        UtilidadesAmigos.Logica.Comunes.VariablesGlobales variablesGlobales = new Logica.Comunes.VariablesGlobales();

        #region GENERAR BACKUP DE BASE DE DATOS
        private void GenerarBackupBD() {
            string _ClaveSeguridad = string.IsNullOrEmpty(txtClaveSeguridadGenerarBackup.Text.Trim()) ? null : txtClaveSeguridadGenerarBackup.Text.Trim();

            UtilidadesAmigos.Logica.Comunes.ValidarClaveSeguridad ValidarClave = new Logica.Comunes.ValidarClaveSeguridad(_ClaveSeguridad);
            bool Resultado = ValidarClave.ValidarClave();
            if (Resultado == true) {
                if (string.IsNullOrEmpty(txtNombreArchivo.Text.Trim())) {
                    string _AnoActual = DateTime.Now.Year.ToString();
                    string _MesActual = DateTime.Now.Month.ToString();
                    string _DiaActual = DateTime.Now.Day.ToString();
                    if (_MesActual.Length == 1) {
                        _MesActual = "0" + _MesActual;
                    }
                    if (_DiaActual.Length == 1) {
                        _DiaActual = "0" + _DiaActual;
                    }
                    string _NombreArchivo = _AnoActual + _MesActual + _DiaActual + ".bak";
                    txtNombreArchivo.Text = _NombreArchivo;
                }

                string RutaArchivo = "", Extencion = "";
                var SacarRutaArchivo = ObjDataAdministrador.Value.BuscaRutaArchivoBakup(1);
                foreach (var n in SacarRutaArchivo) {
                    RutaArchivo = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.DesEncriptar(n.RutaBackup);
                    Extencion = n.ExtencionBackup;
                }
                string _RutaBackup = RutaArchivo + txtNombreArchivo.Text;

                string _Numerobackup = "";
                Random NumeroAleatorio = new Random();
                _Numerobackup = NumeroAleatorio.Next(0, 999999999).ToString();

                decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;


                GenerarBAckup(_RutaBackup, _Numerobackup, IdUsuario);





            }
            else {
                ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadErronea()", "ClaveSeguridadErronea();", true);
                txtClaveSeguridadGenerarBackup.Text = string.Empty;
            }
        }
        #endregion
        #region GENERAR BACKUP
        private void GenerarBAckup(string Ruta, string NumeroBackup, decimal Idusuario)
        {
            try
            {
                UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.GenerarBakupBD Generar = new Logica.Entidades.OpcionesAdministrador.GenerarBakupBD();
                Generar.RutaArchivo = Ruta;
                var MAn = ObjDataAdministrador.Value.GenerarBackupDatabase(Generar, "PROCESAR");

                //GUARDAMOS EL REGISTRO PARA EL HISTORIAL

                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionAdministrador.ProcesarInformacionBackupBD ProcesarHistorialBackup = new Logica.Comunes.ProcesarMantenimientos.InformacionAdministrador.ProcesarInformacionBackupBD(
                    0,
                    NumeroBackup,
                    Idusuario,
                    txtNombreArchivo.Text,
                    "Backup de Base de Datos",
                    DateTime.Now,
                    DateTime.Now,
                    false,
                    "Registro Guardado con Exito.",
                    "INSERT");
                ProcesarHistorialBackup.ProcesarInformacion();

                //SACAMOS EL REGISTRO GUARDADO
                var SacarRegistroGuardado = ObjDataAdministrador.Value.BuscaHistorialBakupDatabase(
                    new Nullable<decimal>(),
                    NumeroBackup,
                    null, null, null, null);

                string DatoNombreArchivo = "", DatoDescripcion = "", DatoUsuario = "", DatoFecha = "", DatoHora = "", DatoEstatus = "", DatoComentario = "", CuerpoMensaje = "";
                foreach (var Datos in SacarRegistroGuardado)
                {
                    DatoNombreArchivo = Datos.NombreArchivo;
                    DatoDescripcion = Datos.Descripcion;
                    DatoUsuario = Datos.Usuario;
                    DatoFecha = Datos.Fecha;
                    DatoHora = Datos.Hora;
                    DatoEstatus = Datos.Estatus;
                    DatoComentario = Datos.Comentario;
                }
                CuerpoMensaje = "Nombre de archivo: " + DatoNombreArchivo + " | Descripción: " + DatoDescripcion + " | Generado Por: " + DatoUsuario + " | En Fecha: " + DatoFecha + " | En Hora: " + DatoHora + " | Estatus: " + DatoEstatus + " | Comentario: " + DatoComentario;

                string CorreoEmisor = "ing.juanmarcelinom.diaz@hotmail.com";
                string Alias = "Utilidades Amigos";
                string Asunto = "Backup de Base de Datos";
                string Clave = "!@Pa$$W0rd!@0624";
                int Puerto = 587;
                string SMTP = "smtp.live.com";
                string Cuerpo = CuerpoMensaje;
                EnvioCorreo(CorreoEmisor, Alias, Asunto, Clave, Puerto, SMTP, Cuerpo);
            }

            catch (Exception ex) {
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionAdministrador.ProcesarInformacionBackupBD GuardarError = new Logica.Comunes.ProcesarMantenimientos.InformacionAdministrador.ProcesarInformacionBackupBD(
                    0, NumeroBackup, Idusuario, "N/A", "ERROR", DateTime.Now, DateTime.Now, true, "El proceso no se pudo completar debido al siguiente error: " + ex.Message, "INSERT");
                GuardarError.ProcesarInformacion();

                //SACAMOS EL REGISTRO GUARDADO
                var SacarRegistroGuardado = ObjDataAdministrador.Value.BuscaHistorialBakupDatabase(
                    new Nullable<decimal>(),
                    NumeroBackup,
                    null, null, null);

                string DatoNombreArchivo = "", DatoDescripcion = "", DatoUsuario = "", DatoFecha = "", DatoHora = "", DatoEstatus = "", DatoComentario = "", CuerpoMensaje = "";
                foreach (var Datos in SacarRegistroGuardado)
                {
                    DatoNombreArchivo = Datos.NombreArchivo;
                    DatoDescripcion = Datos.Descripcion;
                    DatoUsuario = Datos.Usuario;
                    DatoFecha = Datos.Fecha;
                    DatoHora = Datos.Hora;
                    DatoEstatus = Datos.Estatus;
                    DatoComentario = Datos.Comentario;
                }
                CuerpoMensaje = "Nombre de archivo: " + DatoNombreArchivo + " | Descripción: " + DatoDescripcion + " | Generado Por: " + DatoUsuario + " | En Fecha: " + DatoFecha + " | En Hora: " + DatoHora + " | Estatus: " + DatoEstatus + " | Comentario: " + DatoComentario;

                string CorreoEmisor = "ing.juanmarcelinom.diaz@hotmail.com";
                string Alias = "Utilidades Amigos";
                string Asunto = "Backup de Base de Datos";
                string Clave = "!@Pa$$W0rd!@0624";
                int Puerto = 587;
                string SMTP = "smtp.live.com";
                string Cuerpo = CuerpoMensaje;
                EnvioCorreo(CorreoEmisor, Alias, Asunto, Clave, Puerto, SMTP, Cuerpo);
            }
        }
        #endregion
        #region ENVIO DE CORREO
        private void EnvioCorreo(string CorreoEmisor, string Alias, string Asunto, string ClaveCorreo, int Puerto, string SMTP, string Cuerpo) {


            UtilidadesAmigos.Logica.Comunes.EnvioCorreos Mail = new Logica.Comunes.EnvioCorreos
            {
                Mail = CorreoEmisor,
                Alias = Alias,
                Asunto = Asunto,
                Clave = ClaveCorreo,
                Puerto = Puerto,
                smtp = SMTP,
                RutaImagen = Server.MapPath("LogoReducido.jpg"),
                Cuerpo = Cuerpo,
                Destinatarios = new List<string>(),
                Adjuntos = new List<string>()
            };


            var MandarCorreos = ObjDataAdministrador.Value.BuscaCorreosEnviar(
                        new Nullable<decimal>(),
                        1, null, true);
            foreach (var n in MandarCorreos) {
                Mail.Destinatarios.Add(n.Correo);
            }

            //List<string> Logo = new List<string>();
            //Logo.Add(Server.MapPath("Logo.jpg"));

            //foreach (var n2 in Logo) {
            //    Mail.Adjuntos.Add(n2);
            //}



            if (Mail.Enviar(Mail)) {

            }
        }
        #endregion

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


            divPaginacionDetalle.Visible = true;
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
        #region MOSTRAR EL HISTORIAL DE BACKUP DE BASE DE DATOS
        private void MostrarHistorialBackupBaseDatos() {
            DateTime? FechaDesde = string.IsNullOrEmpty(txtFechaDesdeHistorial.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesdeHistorial.Text.Trim());
            DateTime? FechaHasta = string.IsNullOrEmpty(txtFechaHastaHistorial.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesdeHistorial.Text.Trim());
            string _Usuario = string.IsNullOrEmpty(txtNombreUsuarioHistorial.Text.Trim()) ? null : txtNombreUsuarioHistorial.Text.Trim();

            //BUSCAMOS

            var BuscarRegistros = ObjDataAdministrador.Value.BuscaHistorialBakupDatabase(
                new Nullable<decimal>(),
                null,
                FechaDesde,
                FechaHasta,
                null,
                _Usuario);
            int CantidadRegistros = BuscarRegistros.Count;
            lbCantidadregistrosVariable.Text = CantidadRegistros.ToString("N0");

            Paginar(ref rpListado, BuscarRegistros, 10, ref lbCantidadPaginaVariable, ref LinkPrimeraPagina, ref LinkAnterior, ref LinkSiguiente, ref LinkUltimo);
            HandlePaging(ref dtPaginacion, ref LinkBlbPaginaActualVariavle);
        }
        #endregion

        #region GENERAR REPORTE DE HISTORIAL DE BACKUP DE BASE DE DATOS
        private void GenerarReporteBackupBD(string RutaReporte, string NombreArchivo) {
            decimal? IdHistorialBakup = null;
            string NumeroBackup = null;
            DateTime? _Fechadesde = string.IsNullOrEmpty(txtFechaDesdeHistorial.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesdeHistorial.Text.Trim());
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHastaHistorial.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHastaHistorial.Text.Trim());
            bool? _IdEstatus = null;
            string _NombreUsuario = string.IsNullOrEmpty(txtNombreUsuarioHistorial.Text.Trim()) ? null : txtNombreUsuarioHistorial.Text.Trim();


            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@IdHistorialBakup", IdHistorialBakup);
            Reporte.SetParameterValue("@NumeroBackup", NumeroBackup);
            Reporte.SetParameterValue("@Fechadesde", _Fechadesde);
            Reporte.SetParameterValue("@FechaHasta", _FechaHasta);
            Reporte.SetParameterValue("@IdEstatus", _IdEstatus);
            Reporte.SetParameterValue("@NombreUsuario", _NombreUsuario);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

            if (rbPDF.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);
            }
            else if (rbExcel.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreArchivo);
            }
            else if (rbWord.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreArchivo);
            }

        }
        #endregion


        #region MOSTRAR EL LISTADO DE LOS CORREOS 
        private void MostrarListadoCorreos() {

            int IdProceso = 1;
            int CantidadCorreos = 0;

            var ListadoCorreos = ObjDataAdministrador.Value.BuscaCorreosEnviar(
                new Nullable<decimal>(),
                IdProceso,
                null, null);
            CantidadCorreos = ListadoCorreos.Count;
            lbCantidadCorreosregistradosVariable.Text = CantidadCorreos.ToString("N0");
            Paginar(ref rpListadoCorreos, ListadoCorreos, 10, ref lbCantidadPaginaConfiguracionVariable, ref LinkPrimeraPaginaConfiguracion, ref LinkAnteriorConfiguracion, ref LinkSiguienteConfiguracion, ref LinkUltimoConfiguracion);
            HandlePaging(ref dtPaginacionConfiguracion, ref LinkBlbPaginaActualConfiguracionVariable);

        }
        #endregion
        #region MANUPULAR CORREOS
        private void ManipularCorreosEnviar(decimal IdCorreoEnviar, decimal IdProceso, string Correo, bool Estatus, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionAdministrador.ProcesarInformacionCorreosENviar Manupular = new Logica.Comunes.ProcesarMantenimientos.InformacionAdministrador.ProcesarInformacionCorreosENviar(
                IdCorreoEnviar,
                IdProceso,
                Correo,
                Estatus,
                Accion);
            Manupular.ProcesarInformacion();


        }
        #endregion
        #region RESTABLECER LA PANTALLA DE CONFIGURACION
        private void RestablecerPantallaConfiguracion() {
            rbConfigurarRutaBackup.Enabled = true;
            rbConfigurarCorreosBackup.Enabled = true;
            txtClaveSeguridadConfiguracion.Text = string.Empty;
            txtRutaArchivoConfiguracion.Text = string.Empty;
            txtCorreoElectronico.Text = string.Empty;
            txtCorreoElectronico.Enabled = false;
            rbConfigurarRutaBackup.Checked = true;
            btnGuardar.Enabled = false;
            cbEstatusCorreo.Visible = false;
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
            btnRestablecer.Visible = false;
            MostrarListadoCorreos();

        }
        #endregion
        #region SACAR LA RUTA DONDE SE GUARDA EL BACKUP DE BASE DE DATOS
        private string SacarRutaBackup() {
            string Ruta = "";
            var sacarTuta = ObjDataAdministrador.Value.BuscaRutaArchivoBakup(1);
            foreach (var n in sacarTuta)
            {
                Ruta = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.DesEncriptar(n.RutaBackup);
            }
            return Ruta;
        }
        #endregion
        #region PROCESAR LA INFORMACION DE LA RUTA DEL ARCHIVO
        private void ProcesarInformacionRutaBackupBaseDatos(string RutaBackup, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionAdministrador.ProcesarInformacionRutaBackupBD Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionAdministrador.ProcesarInformacionRutaBackupBD(
                1, UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(RutaBackup), ".bak", Accion);
            Procesar.ProcesarInformacion();
            txtRutaArchivoConfiguracion.Text = SacarRutaBackup();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario SacarNombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = SacarNombre.SacarNombreUsuarioConectado();
                Label lbPantallaActual = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantallaActual.Text = "GENERAR BACKUP DE BD";

                rbGenerarBackuup.Checked = true;
                rbPDF.Checked = true;
                rbConfigurarRutaBackup.Checked = true;

                txtRutaArchivoConfiguracion.Text = string.Empty;
                txtCorreoElectronico.Text = string.Empty;
                txtRutaArchivoConfiguracion.Enabled = true;
                txtCorreoElectronico.Enabled = false;


                DivBloqueBackup.Visible = true;
        
            }
        }

        protected void rbGenerarBackuup_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGenerarBackuup.Checked == true) {
                DivBloqueBackup.Visible = true;
                DivBloqueHistorialBaseDatos.Visible = false;
                DivBloqueConfiguracionBaseDatos.Visible = false;
            }
            else {
                DivBloqueBackup.Visible = false;
                DivBloqueHistorialBaseDatos.Visible = false;
                DivBloqueConfiguracionBaseDatos.Visible = false;
            }
        }

        protected void rbHistorialBackup_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHistorialBackup.Checked == true) {
                DivBloqueBackup.Visible = false;
                DivBloqueHistorialBaseDatos.Visible = true;
                DivBloqueConfiguracionBaseDatos.Visible = false;
            }
            else {
                DivBloqueBackup.Visible = false;
                DivBloqueHistorialBaseDatos.Visible = false;
                DivBloqueConfiguracionBaseDatos.Visible = false;
            }
        }

        protected void rbConfiguracion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConfiguracion.Checked == true) {
                DivBloqueBackup.Visible = false;
                DivBloqueHistorialBaseDatos.Visible = false;
                DivBloqueConfiguracionBaseDatos.Visible = true;
                MostrarListadoCorreos();

                btnModificar.Visible = false;
                btnEliminar.Visible = false;
                btnRestablecer.Visible = false;
                cbEstatusCorreo.Visible = false;
                txtCorreoElectronico.Text = string.Empty;
                txtRutaArchivoConfiguracion.Text = SacarRutaBackup();
            }
            else {
                DivBloqueBackup.Visible = false;
                DivBloqueHistorialBaseDatos.Visible = false;
                DivBloqueConfiguracionBaseDatos.Visible = false;
            }
        }

        protected void btnGenerarBackup_Click(object sender, EventArgs e)
        {
            GenerarBackupBD();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarHistorialBackupBaseDatos();
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            GenerarReporteBackupBD(Server.MapPath("ReporteHistorialBackupBD.rpt"), "Historial Backup BD");
        }

        protected void LinkPrimeraPagina_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarHistorialBackupBaseDatos();
        }

        protected void LinkAnterior_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarHistorialBackupBaseDatos();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref LinkBlbPaginaActualVariavle, ref lbCantidadPaginaVariable);
        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarHistorialBackupBaseDatos();
        }

        protected void LinkSiguiente_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarHistorialBackupBaseDatos();
        }

        protected void LinkUltimo_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarHistorialBackupBaseDatos();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref LinkBlbPaginaActualVariavle, ref lbCantidadPaginaVariable);
        }

        protected void rbConfigurarRutaBackup_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConfigurarRutaBackup.Checked == true) {
                txtRutaArchivoConfiguracion.Text = string.Empty;
                txtCorreoElectronico.Text = string.Empty;
                txtRutaArchivoConfiguracion.Enabled = true;
                txtCorreoElectronico.Enabled = false;
                txtRutaArchivoConfiguracion.Text = SacarRutaBackup();
            }
            else {
                txtRutaArchivoConfiguracion.Text = string.Empty;
                txtCorreoElectronico.Text = string.Empty;
                txtRutaArchivoConfiguracion.Enabled = false;
                txtCorreoElectronico.Enabled = false;
            }
        }

        protected void rbConfigurarCorreosBackup_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConfigurarCorreosBackup.Checked == true) {

                txtRutaArchivoConfiguracion.Text = string.Empty;
                txtCorreoElectronico.Text = string.Empty;
                txtRutaArchivoConfiguracion.Enabled = false;
                txtCorreoElectronico.Enabled = true;

               
            }
            else {
                txtRutaArchivoConfiguracion.Text = string.Empty;
                txtCorreoElectronico.Text = string.Empty;
                txtRutaArchivoConfiguracion.Enabled = false;
                txtCorreoElectronico.Enabled = false;
            }
        }

       

        protected void LinkPrimeraPaginaConfiguracion_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoCorreos();
        }

        protected void LinkAnteriorConfiguracion_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoCorreos();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref LinkBlbPaginaActualConfiguracionVariable, ref lbCantidadPaginaConfiguracionVariable);
        }

        protected void dtPaginacionConfiguracion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionConfiguracion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoCorreos();
        }

        protected void LinkSiguienteConfiguracion_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoCorreos();
        }

        protected void LinkUltimoConfiguracion_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoCorreos();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref LinkBlbPaginaActualConfiguracionVariable, ref lbCantidadPaginaConfiguracionVariable);

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            bool RespuestaValidacion = false;
            string _ClaveSeguridad = string.IsNullOrEmpty(txtClaveSeguridadConfiguracion.Text.Trim()) ? null : txtClaveSeguridadConfiguracion.Text.Trim();
            string _Correo = string.IsNullOrEmpty(txtCorreoElectronico.Text.Trim()) ? null : txtCorreoElectronico.Text.Trim();

            UtilidadesAmigos.Logica.Comunes.ValidarClaveSeguridad Validar = new Logica.Comunes.ValidarClaveSeguridad(_ClaveSeguridad);
            RespuestaValidacion = Validar.ValidarClave();

            if (RespuestaValidacion == true) {
                ManipularCorreosEnviar(
                    Convert.ToDecimal(lbIdCorreoEnviarConfiguracion.Text),
                    Convert.ToDecimal(lbIdProcesoConfiguracion.Text),
                    _Correo,
                    cbEstatusCorreo.Checked,
                    "UPDATE");
                RestablecerPantallaConfiguracion();
            }
            else {
                ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadErronea()", "ClaveSeguridadErronea();", true);
            }
        }

      

        protected void btnRestablecer_Click(object sender, EventArgs e)
        {
            RestablecerPantallaConfiguracion();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            bool RespuestaValidacion = false;
            string _ClaveSeguridad = string.IsNullOrEmpty(txtClaveSeguridadConfiguracion.Text.Trim()) ? null : txtClaveSeguridadConfiguracion.Text.Trim();
            string _Correo = string.IsNullOrEmpty(txtCorreoElectronico.Text.Trim()) ? null : txtCorreoElectronico.Text.Trim();

            UtilidadesAmigos.Logica.Comunes.ValidarClaveSeguridad Validar = new Logica.Comunes.ValidarClaveSeguridad(_ClaveSeguridad);
            RespuestaValidacion = Validar.ValidarClave();

            if (RespuestaValidacion == true)
            {
                ManipularCorreosEnviar(
                    Convert.ToDecimal(lbIdCorreoEnviarConfiguracion.Text),
                    Convert.ToDecimal(lbIdProcesoConfiguracion.Text),
                    _Correo,
                    cbEstatusCorreo.Checked,
                    "DELETE");
                RestablecerPantallaConfiguracion();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadErronea()", "ClaveSeguridadErronea();", true);
            }
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            var IdCorreoSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfIdCorreoSeleccionado = ((HiddenField)IdCorreoSeleccionado.FindControl("hfIdCorreo")).Value.ToString();

            var IdProcesoSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfIdProcesoSeleccionado = ((HiddenField)IdProcesoSeleccionado.FindControl("hfIdProceso")).Value.ToString();

            lbIdCorreoEnviarConfiguracion.Text = hfIdCorreoSeleccionado;
            lbIdProcesoConfiguracion.Text = hfIdProcesoSeleccionado;
            rbConfigurarRutaBackup.Enabled = false;
            rbConfigurarCorreosBackup.Enabled = false;
            txtCorreoElectronico.Enabled = false;
            btnGuardar.Enabled = false;

            cbEstatusCorreo.Visible = true;
            btnModificar.Visible = true;
            btnEliminar.Visible = true;
            btnRestablecer.Visible = true;
            lbCantidadCorreosregistradosVariable.Text = "1";

            var BuscarCorreoSeleccionado = ObjDataAdministrador.Value.BuscaCorreosEnviar(
                Convert.ToDecimal(hfIdCorreoSeleccionado),
                Convert.ToDecimal(hfIdProcesoSeleccionado),
                null, null);
            foreach (var n in BuscarCorreoSeleccionado) {
                txtCorreoElectronico.Text = n.Correo;
                cbEstatusCorreo.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
            }
            Paginar(ref rpListadoCorreos, BuscarCorreoSeleccionado, 1, ref lbCantidadPaginaConfiguracionVariable, ref LinkPrimeraPaginaConfiguracion, ref LinkAnteriorConfiguracion, ref LinkSiguienteConfiguracion, ref LinkUltimoConfiguracion);
            HandlePaging(ref dtPaginacionConfiguracion, ref LinkBlbPaginaActualConfiguracionVariable);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (rbConfigurarRutaBackup.Checked == true) {
                if (string.IsNullOrEmpty(txtRutaArchivoConfiguracion.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoRutaVacio()", "CampoRutaVacio();", true);
                }
                else {
                    //VALIDAMOS LA CLAVE DE SEGURIDAD
                    bool ResultadoValidacion = false;
                    string _ClaveSeguridad = string.IsNullOrEmpty(txtClaveSeguridadConfiguracion.Text.Trim()) ? null : txtClaveSeguridadConfiguracion.Text.Trim();

                    UtilidadesAmigos.Logica.Comunes.ValidarClaveSeguridad Validar = new Logica.Comunes.ValidarClaveSeguridad(_ClaveSeguridad);
                    ResultadoValidacion = Validar.ValidarClave();

                    if (ResultadoValidacion == true) {
                        string _RutaArchivo = string.IsNullOrEmpty(txtRutaArchivoConfiguracion.Text.Trim()) ? null : txtRutaArchivoConfiguracion.Text.Trim();
                        ProcesarInformacionRutaBackupBaseDatos(_RutaArchivo, "UPDATE");

                    }
                    else {
                        ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadErronea()", "ClaveSeguridadErronea();", true);
                    }
                }
            }
            else if (rbConfigurarCorreosBackup.Checked == true) {
                if (string.IsNullOrEmpty(txtCorreoElectronico.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoCorreoVacio()", "CampoCorreoVacio();", true);
                }
                else {

                    bool RespuestaValidacion = false;
                    string _ClaveSeguridad = string.IsNullOrEmpty(txtClaveSeguridadConfiguracion.Text.Trim()) ? null : txtClaveSeguridadConfiguracion.Text.Trim();

                    UtilidadesAmigos.Logica.Comunes.ValidarClaveSeguridad ValidarClave = new Logica.Comunes.ValidarClaveSeguridad(_ClaveSeguridad);
                    RespuestaValidacion = ValidarClave.ValidarClave();
                    if (RespuestaValidacion == true) {

                        //VALIDAMOS QUE EL CORREO INGRESADO NO EXISTA EN LA BASE DE DATOS BAJO ESTE PROCESO
                        decimal IdProceso = 1;
                        string _Correo = string.IsNullOrEmpty(txtCorreoElectronico.Text.Trim()) ? null : txtCorreoElectronico.Text.Trim();

                        var ValidarCorreo = ObjDataAdministrador.Value.ListadoCorreosEnviar(
                            new Nullable<decimal>(),
                            IdProceso,
                            null,
                            _Correo,
                            null);
                        if (ValidarCorreo.Count() < 1)
                        {
                            ManipularCorreosEnviar(0, 1, _Correo, true, "INSERT");
                            MostrarListadoCorreos();
                            txtCorreoElectronico.Text = string.Empty;
                        }
                        else {
                            ClientScript.RegisterStartupScript(GetType(), "CorreoEncontrado()", "CorreoEncontrado();", true);
                        }
                    }
                    else {
                        ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadErronea()", "ClaveSeguridadErronea();", true);
                    }
                }
            }
        }
    }
}