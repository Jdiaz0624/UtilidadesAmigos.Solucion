using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarBakupBD : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaOpcionesAdministrador.LogicaOpcionesdministrador> ObjDataAdministrador = new Lazy<Logica.Logica.LogicaOpcionesAdministrador.LogicaOpcionesdministrador>();
        UtilidadesAmigos.Logica.Comunes.Mail Correo = new Logica.Comunes.Mail();
        UtilidadesAmigos.Logica.Comunes.VariablesGlobales variablesGlobales = new Logica.Comunes.VariablesGlobales();


        #region OCULTAR CONTROLES
        private void OcultarControles()
        {
            lbNombreArchivo.Visible = false;
            txtNombrearchivo.Visible = false;

            lbRutaBakup.Visible = false;
            txtRutaArchivo.Visible = false;
            lbExtencionArchivo.Visible = false;
            txtExtencionArchivo.Visible = false;

            lbFechaDesde.Visible = false;
            txtFechaDesde.Visible = false;
            lbFechaHasta.Visible = false;
            txtFechaHasta.Visible = false;

            btnProcesar.Visible = false;
        }
        #endregion
        #region PROCESAR RUTA ARCHIVO
        private void ProcesarRutaArchivo(int IdRutaArchivo, string Ruta, string Extencion,string Accion)
        {
            try {
                UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.ERutaArchivoBakup Procesar = new Logica.Entidades.OpcionesAdministrador.ERutaArchivoBakup();

                Procesar.IdRutaArchivoBakup = IdRutaArchivo;
                Procesar.RutaBackup = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(Ruta);
                Procesar.ExtencionBackup = Extencion;

                var MAn = ObjDataAdministrador.Value.MantenimientoRutaArchivoBackup(Procesar, Accion);
            }
            catch (Exception ex) { }
        }
        #endregion
        #region GENERAR BACKUP
        private void GenerarBAckup(string Ruta)
        {
            UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.GenerarBakupBD Generar = new Logica.Entidades.OpcionesAdministrador.GenerarBakupBD();

            Generar.RutaArchivo = Ruta;

            var MAn = ObjDataAdministrador.Value.GenerarBackupDatabase(Generar, "PROCESAR");
        }
        #endregion
        #region GENERAR NUMERO RAMDOM
        private void GenerarNumeroRamdom()
        {
            Random Numero = new Random();
            int Numero2 = Numero.Next(0, 999999999);
            lbNumeroBackup.Text = Numero2.ToString();
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbIdUsuario.Text = Session["IdUsuario"].ToString();
                GenerarNumeroRamdom();
            }
        }

        protected void btnValidarClaveSeguridad_Click(object sender, EventArgs e)
        {
            
            try {
                //VALIDAMOS LA CLAVE DE SEGURIDAD
                if (string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadVacia", "ClaveSeguridadVacia();", true);
                }
                else
                {
                    string _ClaveSeguridadIngresada = string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()) ? null : txtClaveSeguridad.Text.Trim();

                    var ValidarClaveSeguridad = ObjData.Value.BuscaClaveSeguridad(
                        new Nullable<decimal>(),
                        UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(_ClaveSeguridadIngresada));
                    if (ValidarClaveSeguridad.Count() < 1)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadNoValida", "ClaveSeguridadNoValida();", true);
                        txtClaveSeguridad.Text = string.Empty;
                        txtClaveSeguridad.Focus();
                    }
                    else
                    {
                        lbIngresarClaveSeguridad.Visible = false;
                        txtClaveSeguridad.Visible = false;
                        btnValidarClaveSeguridad.Visible = false;
                        rbGenerarBakup.Visible = true;
                        rbConfigurarRutaBD.Visible = true;
                        rbHistorial.Visible = true;
                        rbGenerarBakup.Checked = true;

                        lbNombreArchivo.Visible = true;
                        txtNombrearchivo.Visible = true;
                        btnProcesar.Visible = true;
                    }
                }
             //   ClientScript.RegisterStartupScript(GetType(), "Ocultarspiner", "Ocultarspiner();", true);
            }
            catch (Exception ex) {
                string Error = "";
                Error = "El proceso de bakup arrojo el siguiente error--> " + ex.Message;
                //Mandamos el correo
   
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            try {
                if (rbGenerarBakup.Checked == true)
                {
                    if (string.IsNullOrEmpty(txtNombrearchivo.Text.Trim()))
                    {
                        string Year = DateTime.Now.Year.ToString();
                        string Month = DateTime.Now.Month.ToString();
                        string Day = DateTime.Now.Day.ToString();

                        if (Month.Length == 1)
                        {
                            Month = "0" + Month;
                        }
                        if (Day.Length == 1)
                        {
                            Day = "0" + Day;
                        }

                        string NombreGenerico = Year + Month + Day;
                        txtNombrearchivo.Text = NombreGenerico;

                       
                    }

                    //SACAMOS LA RUTA DONDE SE VA A GUARDAR EL ARCHIVO Y LA EXTENCION DE LA MISMA
                    string Rutaarchivo = "", Extencion = "";
                    var SacarRutaArchivo = ObjDataAdministrador.Value.BuscaRutaArchivoBakup(1);
                    foreach (var n in SacarRutaArchivo)
                    {
                        Rutaarchivo = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.DesEncriptar(n.RutaBackup);
                        Extencion = n.ExtencionBackup;
                    }

                    //GUARDAMOS EL REGISTRO PARA DEJAR UN HISTORIAL DEL BAKUP REALIZADO
                
                        UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.EMantenimientoBackupDatabase Guardar = new Logica.Entidades.OpcionesAdministrador.EMantenimientoBackupDatabase();


                        Guardar.IdHistorialBakupDatabase = 0;
                        Guardar.NumeroBackup = lbNumeroBackup.Text;
                        Guardar.IdUsuario = Convert.ToDecimal(lbIdUsuario.Text);
                        Guardar.NombreArchivo = txtNombrearchivo.Text;
                        Guardar.Descripcion = "Bakup de Base de datos";
                        Guardar.FechaCreado = DateTime.Now;
                        Guardar.Hora0 = DateTime.Now;
                        Guardar.IdEstatus = false;
                        Guardar.Comentario = "Registro Guardado con exito";

                        var MAN = ObjDataAdministrador.Value.MantenimientoHistorialDatabase(Guardar, "INSERT");


                    //PROCEDEMOS A GENERAR EL BACKUP
                    variablesGlobales.RutaGuardarBackup = Rutaarchivo + txtNombrearchivo.Text + Extencion;
                    GenerarBAckup(@"" + variablesGlobales.RutaGuardarBackup);

                    //SACAMOS EL REGISTRO GUARDADO
                    var SacarRegistroGuardado = ObjDataAdministrador.Value.BuscaHistorialBakupDatabase(
                        new Nullable<decimal>(),
                        lbNumeroBackup.Text,
                        null, null, null);

                  

                    foreach (var Datos in SacarRegistroGuardado)
                    {
                        variablesGlobales.NombreArchivoBackup = Datos.NombreArchivo;
                        variablesGlobales.DescripcionArchivoBackup = Datos.Descripcion;
                        variablesGlobales.UsuarioBackup = Datos.Usuario;
                        variablesGlobales.FechaBAckup = Datos.Fecha;
                        variablesGlobales.HoraBackup = Datos.Hora;
                        variablesGlobales.EstatusBAckup = Datos.Estatus;
                        variablesGlobales.ComentarioBAckup = Datos.Comentario;
                    }

                    List<string> InformacionBackup = new List<string>();
                    InformacionBackup.Add("Nombre del archivo: " + variablesGlobales.NombreArchivoBackup);
                    InformacionBackup.Add("Descripcion: " + variablesGlobales.DescripcionArchivoBackup);
                    InformacionBackup.Add("Generado Por: " + variablesGlobales.UsuarioBackup);
                    InformacionBackup.Add("Fecha: " + variablesGlobales.FechaBAckup);
                    InformacionBackup.Add("Hora: " + variablesGlobales.FechaBAckup);
                    InformacionBackup.Add("Estatus: " + variablesGlobales.EstatusBAckup);
                    InformacionBackup.Add("Observacion: " + variablesGlobales.ComentarioBAckup);

                    string Data = "";
                    foreach (var Informacion in InformacionBackup)
                    {
                        
                        Data = Data + Informacion + " | ";

                    
                    }
                    //MANDAMOS EL CORREO CON DE AVISO DE QUE SE CREO EL BACKUP
                    //MANDAMOS LOS DATOS A LOA CORREOS CORRESPONDIENTES
                    decimal IdCorreoEnviar = 0;
                    var MandarCorreos = ObjDataAdministrador.Value.BuscaCorreosEnviar(
                        new Nullable<decimal>(),
                        1, null, true);
                    foreach (var n2 in MandarCorreos)
                    {
                        //BUSCAMOS EL CORREO
                        IdCorreoEnviar = Convert.ToDecimal(n2.IdCorreoEnviar);
                        var BuscarCorreo = ObjDataAdministrador.Value.BuscaCorreosEnviar(IdCorreoEnviar);
                        foreach (var n3 in BuscarCorreo)
                        {
                            Correo.EnviarCorreo("ing.juanmarcelinom.diaz@hotmail.com", "!@Pa$$W0rd!@0624", n3.Correo, @"" + Data, "Backup de Base de datos");
                        }
                    }

                    // Correo.EnviarCorreo("ing.juanmarcelinom.diaz@hotmail.com", "!@Pa$$W0rd!@0624", "jmdiaz@amigosseguros.com",@""+ Data);
                    //   Correo.EnviarCorreo("ing.juanmarcelinom.diaz@hotmail.com", "!@Pa$$W0rd!@0624", "jmdiaz@amigosseguros.com", @"" + Data, "Backup de Base de datos");

                }
                else if (rbConfigurarRutaBD.Checked == true)
                {
                    if (string.IsNullOrEmpty(txtRutaArchivo.Text.Trim()))
                    {
                        if (string.IsNullOrEmpty(txtRutaArchivo.Text.Trim()))
                        {
                            ClientScript.RegisterStartupScript(GetType(), "CampoRutaArchivoVacio", "CampoRutaArchivoVacio();", true);
                        }
                    
                    }
                    else
                    {
                        //PROCESAMOS, VALIDAMOS LOS CAMPOS ANTES DE PROCEDER
                        var ValidarRuta = ObjDataAdministrador.Value.BuscaRutaArchivoBakup(1);
                        if (ValidarRuta.Count() < 1)
                        {
                            //GUARDAMOS
                            ProcesarRutaArchivo(0, txtRutaArchivo.Text,".bak", "INSERT");
                            rbGenerarBakup.Checked = true;
                        }
                        else
                        {
                            //MODIFICAMOS
                            ProcesarRutaArchivo(1, txtRutaArchivo.Text, ".bak", "UPDATE");
                            rbGenerarBakup.Checked = true;
                        }
                    }
                }
                else if (rbHistorial.Checked == true)
                {

                }
            }
            catch (Exception ex) {
                //MANDAMOS UN CORREO CON EL ERROR RELACIONADO
                string MensajeError = "Se encontro el siguiente error al realizar el proceso de Base de datos, favor de verificar, Error: --> " + ex.Message;

                //ACTUALIZAMOS EL REGISTRO EN LA BASE DE DATOS
                UtilidadesAmigos.Logica.Entidades.OpcionesAdministrador.EMantenimientoBackupDatabase Update = new Logica.Entidades.OpcionesAdministrador.EMantenimientoBackupDatabase();

                Update.NumeroBackup = lbNumeroBackup.Text;
                Update.Comentario = MensajeError;

                var MAN = ObjDataAdministrador.Value.MantenimientoHistorialDatabase(Update, "UPDATE");
                //SACAMOS LAS CREDENCIALES DEL CORREOd
                Correo.EnviarCorreo("ing.juanmarcelinom.diaz@hotmail.com", "!@Pa$$W0rd!@0624", "jmdiaz@amigosseguros.com", @"" + MensajeError, "Backup de Base de datos");
            }
        }

        protected void rbGenerarBakup_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGenerarBakup.Checked)
            {
                lbNombreArchivo.Visible = true;
                txtNombrearchivo.Visible = true;

                lbRutaBakup.Visible = false;
                txtRutaArchivo.Visible = false;
                lbExtencionArchivo.Visible = false;
                txtExtencionArchivo.Visible = false;

                lbFechaDesde.Visible = false;
                txtFechaDesde.Visible = false;
                lbFechaHasta.Visible = false;
                txtFechaHasta.Visible = false;

                btnProcesar.Visible = true;
              
            }
            else
            {
                OcultarControles();
       
            }
        }

        protected void rbConfigurarRutaBD_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConfigurarRutaBD.Checked)
            {
                lbNombreArchivo.Visible = false;
                txtNombrearchivo.Visible = false;

                lbRutaBakup.Visible = true;
                txtRutaArchivo.Visible = true;
                lbExtencionArchivo.Visible = false;
                txtExtencionArchivo.Visible = false;

                lbFechaDesde.Visible = false;
                txtFechaDesde.Visible = false;
                lbFechaHasta.Visible = false;
                txtFechaHasta.Visible = false;

                btnProcesar.Visible = true;

                //SACAMOS LOS DATOS DE LA BASE DE DATOS

                var SacarDatos = ObjDataAdministrador.Value.BuscaRutaArchivoBakup(1);
                foreach (var n in SacarDatos)
                {
                    txtRutaArchivo.Text = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.DesEncriptar(n.RutaBackup);
                }
            
            }
            else
            {
                OcultarControles();
              
            }
        }

        protected void rbHistorial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHistorial.Checked)
            {
                lbNombreArchivo.Visible = false;
                txtNombrearchivo.Visible = false;

                lbRutaBakup.Visible = false;
                txtRutaArchivo.Visible = false;
                lbExtencionArchivo.Visible = false;
                txtExtencionArchivo.Visible = false;

                lbFechaDesde.Visible = true;
                txtFechaDesde.Visible = true;
                lbFechaHasta.Visible = true;
                txtFechaHasta.Visible = true;

                btnProcesar.Visible = true;

            }
            else
            {
                OcultarControles();
 
            }
        }
    }
}