using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        private void GenerarBAckup(string Ruta, string NumeroBackup,decimal Idusuario)
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
        private void EnvioCorreo(string CorreoEmisor, string Alias, string Asunto, string ClaveCorreo, int Puerto, string SMTP,string Cuerpo) {
           

            UtilidadesAmigos.Logica.Comunes.EnvioCorreos Mail = new Logica.Comunes.EnvioCorreos
            {
                Mail = CorreoEmisor,
                Alias = Alias,
                Asunto = Asunto,
                Clave = ClaveCorreo,
                Puerto = Puerto,
                smtp = SMTP,
                RutaImagen = "",
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

         

            if (Mail.Enviar(Mail)) {

            }
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

        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPagina_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnterior_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguiente_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimo_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}