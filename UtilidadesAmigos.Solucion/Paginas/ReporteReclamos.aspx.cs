using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    
    public partial class ReporteReclamos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        UtilidadesAmigos.Logica.Comunes.Mail Correo = new Logica.Comunes.Mail();

        #region CARGAMOS LAS LISTAS DESPLEGABLES PARA LA CONSULTA
        private void CargarListasDesplegablesConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarCondicionConsulta, ObjData.Value.BuscaListas("CONDICIONRECLAMACION", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoConsulta, ObjData.Value.BuscaListas("TIPORECLAMACION", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarEstatutsConsulta, ObjData.Value.BuscaListas("ESTATUSRECLAMACION", null, null), true);
        }
        #endregion
        #region CONSULTAR REGISTROS
        private void ConsultarRegistros()
        {
            try {
                decimal? _CondicionReclamacion = ddlSeleccionarCondicionConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarCondicionConsulta.SelectedValue) : new Nullable<decimal>();
                decimal? _TipoReclamacion = ddlSeleccionarTipoConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarTipoConsulta.SelectedValue) : new Nullable<decimal>();
                decimal? _EstatusReclamacion = ddlSeleccionarEstatutsConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarEstatutsConsulta.SelectedValue) : new Nullable<decimal>();
                string _Numeroreclamacion = string.IsNullOrEmpty(txtReclamacionConsulta.Text.Trim()) ? null : txtReclamacionConsulta.Text.Trim();
                string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
                string _Intermediario = string.IsNullOrEmpty(txtIntermediarioConsulta.Text.Trim()) ? null : txtIntermediarioConsulta.Text.Trim();
                string _Asegurado = string.IsNullOrEmpty(txtAseguradoCOnsulta.Text.Trim()) ? null : txtAseguradoCOnsulta.Text.Trim();
                string _Beneficiario = string.IsNullOrEmpty(txtBeneficiarioConsulta.Text.Trim()) ? null : txtBeneficiarioConsulta.Text.Trim();

                if (cbAgregarRangoFechaConsulta.Checked)
                {

                    if (rbConsultarInicioVigenciaConsulta.Checked == true)
                    {
                        //CONSULTAMOS POR EL INICIO DE VIGENCIA
                        var Consultar = ObjData.Value.BuscaReclamaciones(
                     new Nullable<decimal>(),
                     _Numeroreclamacion,
                     _Poliza,
                     _Intermediario,
                     _Asegurado,
                     _CondicionReclamacion,
                     _Beneficiario,
                     _TipoReclamacion,
                     Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                     Convert.ToDateTime(txtFechaHAstaConsulta.Text),
                     null,
                     null,
                     null,
                     null,
                     null,
                     null,
                     _EstatusReclamacion);
                        gvListadoReclamos.DataSource = Consultar;
                        gvListadoReclamos.DataBind();

                        if (Consultar.Count() < 1)
                        {
                            lbCantidadRegistrosVariables.Text = "0";
                        }
                        else {
                            foreach (var n in Consultar)
                            {
                                decimal CantidadRegistros = 0;
                                CantidadRegistros = Convert.ToDecimal(n.CantidadRegistros);
                                lbCantidadRegistrosVariables.Text = CantidadRegistros.ToString("N0");
                            }
                        }
                    }
                    else if (rbConsultarFinVigencia.Checked == true)
                    {
                        //CONSULTAMOS POR EL FIN DE VIGENCIA
                        var Consultar = ObjData.Value.BuscaReclamaciones(
                     new Nullable<decimal>(),
                     _Numeroreclamacion,
                     _Poliza,
                     _Intermediario,
                     _Asegurado,
                     _CondicionReclamacion,
                     _Beneficiario,
                     _TipoReclamacion,
                     null,
                     null,
                     Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                     Convert.ToDateTime(txtFechaHAstaConsulta.Text),
                     null,
                     null,
                     null,
                     null,
                     _EstatusReclamacion);
                        gvListadoReclamos.DataSource = Consultar;
                        gvListadoReclamos.DataBind();

                        if (Consultar.Count() < 1)
                        {
                            lbCantidadRegistrosVariables.Text = "0";
                        }
                        else
                        {
                            foreach (var n in Consultar)
                            {
                                decimal CantidadRegistros = 0;
                                CantidadRegistros = Convert.ToDecimal(n.CantidadRegistros);
                                lbCantidadRegistrosVariables.Text = CantidadRegistros.ToString("N0");
                            }
                        }
                    }
                    else if (rbConsultarFechaApertura.Checked == true)
                    {
                        //CONSULTAMOS POR LA FECHA DE APERTURA
                        var Consultar = ObjData.Value.BuscaReclamaciones(
                     new Nullable<decimal>(),
                     _Numeroreclamacion,
                     _Poliza,
                     _Intermediario,
                     _Asegurado,
                     _CondicionReclamacion,
                     _Beneficiario,
                     _TipoReclamacion,
                     null,
                     null,
                     null,
                     null,
                     Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                     Convert.ToDateTime(txtFechaHAstaConsulta.Text),
                     null,
                     null,
                     _EstatusReclamacion);
                        gvListadoReclamos.DataSource = Consultar;
                        gvListadoReclamos.DataBind();

                        if (Consultar.Count() < 1)
                        {
                            lbCantidadRegistrosVariables.Text = "0";
                        }
                        else
                        {
                            foreach (var n in Consultar)
                            {
                                decimal CantidadRegistros = 0;
                                CantidadRegistros = Convert.ToDecimal(n.CantidadRegistros);
                                lbCantidadRegistrosVariables.Text = CantidadRegistros.ToString("N0");
                            }
                        }
                    }
                    else if (rbConsultarFechaSiniestro.Checked == true)
                    {
                        //CONSULTAMOS POR LA FECHA DE SINIESTRO
                        var Consultar = ObjData.Value.BuscaReclamaciones(
                     new Nullable<decimal>(),
                     _Numeroreclamacion,
                     _Poliza,
                     _Intermediario,
                     _Asegurado,
                     _CondicionReclamacion,
                     _Beneficiario,
                     _TipoReclamacion,
                     null,
                     null,
                     null,
                     null,
                     null,
                     null,
                    Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                     Convert.ToDateTime(txtFechaHAstaConsulta.Text),
                     _EstatusReclamacion);
                        gvListadoReclamos.DataSource = Consultar;
                        gvListadoReclamos.DataBind();

                        if (Consultar.Count() < 1)
                        {
                            lbCantidadRegistrosVariables.Text = "0";
                        }
                        else
                        {
                            foreach (var n in Consultar)
                            {
                                decimal CantidadRegistros = 0;
                                CantidadRegistros = Convert.ToDecimal(n.CantidadRegistros);
                                lbCantidadRegistrosVariables.Text = CantidadRegistros.ToString("N0");
                            }
                        }
                    }


                }
                else
                {
                    //CONSULTAMOS SIN UTILIZAR LOS RANGOS DE FECHA
                    var Consultar = ObjData.Value.BuscaReclamaciones(
                        new Nullable<decimal>(),
                        _Numeroreclamacion,
                        _Poliza,
                        _Intermediario,
                        _Asegurado,
                        _CondicionReclamacion,
                        _Beneficiario,
                        _TipoReclamacion,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        _EstatusReclamacion);
                    gvListadoReclamos.DataSource = Consultar;
                    gvListadoReclamos.DataBind();

                    if (Consultar.Count() < 1)
                    {
                        lbCantidadRegistrosVariables.Text = "0";
                    }
                    else
                    {
                        foreach (var n in Consultar)
                        {
                            decimal CantidadRegistros = 0;
                            CantidadRegistros = Convert.ToDecimal(n.CantidadRegistros);
                            lbCantidadRegistrosVariables.Text = CantidadRegistros.ToString("N0");
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        #endregion
        #region EXPORTAR LA DATA A EXEL
        private void ExportarDataExel() {
            try {
                decimal? _CondicionReclamacion = ddlSeleccionarCondicionConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarCondicionConsulta.SelectedValue) : new Nullable<decimal>();
                decimal? _TipoReclamacion = ddlSeleccionarTipoConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarTipoConsulta.SelectedValue) : new Nullable<decimal>();
                decimal? _EstatusReclamacion = ddlSeleccionarEstatutsConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarEstatutsConsulta.SelectedValue) : new Nullable<decimal>();
                string _Numeroreclamacion = string.IsNullOrEmpty(txtReclamacionConsulta.Text.Trim()) ? null : txtReclamacionConsulta.Text.Trim();
                string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
                string _Intermediario = string.IsNullOrEmpty(txtIntermediarioConsulta.Text.Trim()) ? null : txtIntermediarioConsulta.Text.Trim();
                string _Asegurado = string.IsNullOrEmpty(txtAseguradoCOnsulta.Text.Trim()) ? null : txtAseguradoCOnsulta.Text.Trim();
                string _Beneficiario = string.IsNullOrEmpty(txtBeneficiarioConsulta.Text.Trim()) ? null : txtBeneficiarioConsulta.Text.Trim();

                if (cbAgregarRangoFechaConsulta.Checked)
                {
                    if (rbConsultarInicioVigenciaConsulta.Checked == true)
                    {
                        //EXPORTAR POR FECHA DE INICIO DE VIGENCIA
                        var ExportarData = (from n in ObjData.Value.BuscaReclamaciones(
                       new Nullable<decimal>(),
                       _Numeroreclamacion,
                       _Poliza,
                       _Intermediario,
                       _Asegurado,
                       _CondicionReclamacion,
                       _Beneficiario,
                       _TipoReclamacion,
                       Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                       Convert.ToDateTime(txtFechaHAstaConsulta.Text),
                       null,
                       null,
                       null,
                       null,
                       null,
                       null,
                       _EstatusReclamacion)
                                            select new
                                            {
                                                Numero = n.Numero,
                                                Reclamacion = n.Reclamacion,
                                                Poliza = n.Poliza,
                                                Estatus = n.Estatus,
                                                Intermediario = n.Intermediario,
                                                NombreIntermediario = n.NombreIntermediario,
                                                Asegurado = n.Asegurado,
                                                Condicion = n.Condicion,
                                                Monto = n.Monto,
                                                Beneficiario = n.Beneficiario,
                                                TipoReclamacion = n.TipoReclamacion,
                                                InicioVigencia = n.InicioVigencia,
                                                FinVigencia = n.FinVigencia,
                                                FechaApertura = n.FechaApertura,
                                                FechaSiniestro = n.FechaSiniestro,
                                                FechaFactura = n.FechaFactura,
                                                FechaCreacion = n.FechaCreacion,
                                                EstatusReclamacion = n.EstatusReclamacion,
                                                Usuario = n.Usuario,
                                                Comentario = n.Comentario
                                            }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de reclamos General", ExportarData);
                    }
                    else if (rbConsultarFinVigencia.Checked == true)
                    {
                        //EXPORTAR POR FECHA DE FIN DE VIGENCIA
                        var ExportarData = (from n in ObjData.Value.BuscaReclamaciones(
                       new Nullable<decimal>(),
                       _Numeroreclamacion,
                       _Poliza,
                       _Intermediario,
                       _Asegurado,
                       _CondicionReclamacion,
                       _Beneficiario,
                       _TipoReclamacion,
                       null,
                       null,
                       Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                       Convert.ToDateTime(txtFechaHAstaConsulta.Text),
                       null,
                       null,
                       null,
                       null,
                       _EstatusReclamacion)
                                            select new
                                            {
                                                Numero = n.Numero,
                                                Reclamacion = n.Reclamacion,
                                                Poliza = n.Poliza,
                                                Estatus = n.Estatus,
                                                Intermediario = n.Intermediario,
                                                NombreIntermediario = n.NombreIntermediario,
                                                Asegurado = n.Asegurado,
                                                Condicion = n.Condicion,
                                                Monto = n.Monto,
                                                Beneficiario = n.Beneficiario,
                                                TipoReclamacion = n.TipoReclamacion,
                                                InicioVigencia = n.InicioVigencia,
                                                FinVigencia = n.FinVigencia,
                                                FechaApertura = n.FechaApertura,
                                                FechaSiniestro = n.FechaSiniestro,
                                                FechaFactura = n.FechaFactura,
                                                FechaCreacion = n.FechaCreacion,
                                                EstatusReclamacion = n.EstatusReclamacion,
                                                Usuario = n.Usuario,
                                                Comentario = n.Comentario
                                            }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de reclamos General", ExportarData);
                    }
                    else if (rbConsultarFechaApertura.Checked == true)
                    {
                        //EXPORTAR POR FECHA DE APERTURA
                        var ExportarData = (from n in ObjData.Value.BuscaReclamaciones(
                       new Nullable<decimal>(),
                       _Numeroreclamacion,
                       _Poliza,
                       _Intermediario,
                       _Asegurado,
                       _CondicionReclamacion,
                       _Beneficiario,
                       _TipoReclamacion,
                       null,
                       null,
                       null,
                       null,
                       Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                       Convert.ToDateTime(txtFechaHAstaConsulta.Text),
                       null,
                       null,
                       _EstatusReclamacion)
                                            select new
                                            {
                                                Numero = n.Numero,
                                                Reclamacion = n.Reclamacion,
                                                Poliza = n.Poliza,
                                                Estatus = n.Estatus,
                                                Intermediario = n.Intermediario,
                                                NombreIntermediario = n.NombreIntermediario,
                                                Asegurado = n.Asegurado,
                                                Condicion = n.Condicion,
                                                Monto = n.Monto,
                                                Beneficiario = n.Beneficiario,
                                                TipoReclamacion = n.TipoReclamacion,
                                                InicioVigencia = n.InicioVigencia,
                                                FinVigencia = n.FinVigencia,
                                                FechaApertura = n.FechaApertura,
                                                FechaSiniestro = n.FechaSiniestro,
                                                FechaFactura = n.FechaFactura,
                                                FechaCreacion = n.FechaCreacion,
                                                EstatusReclamacion = n.EstatusReclamacion,
                                                Usuario = n.Usuario,
                                                Comentario = n.Comentario
                                            }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de reclamos General", ExportarData);
                    }
                    else if (rbConsultarFechaSiniestro.Checked == true)
                    {
                        //EXPORTAR POR FECHA DE SINIESTRO
                        var ExportarData = (from n in ObjData.Value.BuscaReclamaciones(
                       new Nullable<decimal>(),
                       _Numeroreclamacion,
                       _Poliza,
                       _Intermediario,
                       _Asegurado,
                       _CondicionReclamacion,
                       _Beneficiario,
                       _TipoReclamacion,
                       null,
                       null,
                       null,
                       null,
                       null,
                       null,
                       Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                       Convert.ToDateTime(txtFechaHAstaConsulta.Text),
                       _EstatusReclamacion)
                                            select new
                                            {
                                                Numero = n.Numero,
                                                Reclamacion = n.Reclamacion,
                                                Poliza = n.Poliza,
                                                Estatus = n.Estatus,
                                                Intermediario = n.Intermediario,
                                                NombreIntermediario = n.NombreIntermediario,
                                                Asegurado = n.Asegurado,
                                                Condicion = n.Condicion,
                                                Monto = n.Monto,
                                                Beneficiario = n.Beneficiario,
                                                TipoReclamacion = n.TipoReclamacion,
                                                InicioVigencia = n.InicioVigencia,
                                                FinVigencia = n.FinVigencia,
                                                FechaApertura = n.FechaApertura,
                                                FechaSiniestro = n.FechaSiniestro,
                                                FechaFactura = n.FechaFactura,
                                                FechaCreacion = n.FechaCreacion,
                                                EstatusReclamacion = n.EstatusReclamacion,
                                                Usuario = n.Usuario,
                                                Comentario = n.Comentario
                                            }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de reclamos General", ExportarData);
                    }
                }
                else
                {
                    var ExportarData = (from n in ObjData.Value.BuscaReclamaciones(
                        new Nullable<decimal>(),
                        _Numeroreclamacion,
                        _Poliza,
                        _Intermediario,
                        _Asegurado,
                        _CondicionReclamacion,
                        _Beneficiario,
                        _TipoReclamacion,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        _EstatusReclamacion)
                                        select new
                                        {
                                            Numero = n.Numero,
                                            Reclamacion = n.Reclamacion,
                                            Poliza = n.Poliza,
                                            Estatus = n.Estatus,
                                            Intermediario = n.Intermediario,
                                            NombreIntermediario = n.NombreIntermediario,
                                            Asegurado = n.Asegurado,
                                            Condicion = n.Condicion,
                                            Monto = n.Monto,
                                            Beneficiario = n.Beneficiario,
                                            TipoReclamacion = n.TipoReclamacion,
                                            InicioVigencia = n.InicioVigencia,
                                            FinVigencia = n.FinVigencia,
                                            FechaApertura = n.FechaApertura,
                                            FechaSiniestro = n.FechaSiniestro,
                                            FechaFactura = n.FechaFactura,
                                            FechaCreacion = n.FechaCreacion,
                                            EstatusReclamacion = n.EstatusReclamacion,
                                            Usuario = n.Usuario,
                                            Comentario = n.Comentario
                                        }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de reclamos General", ExportarData);
                }
            }
            catch (Exception ex) {
                string MEnsajeError = "Error al exportar la data a exel en la pantalla de consulta de reclamaciones " + ex.Message;
                Correo.EnviarCorreo("ing.juanmarcelinom.diaz@hotmail.com", "!@Pa$$W0rd!@0624", "jmdiaz@amigosseguros.com", MEnsajeError, "Error en Proceso");
            }
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LAS CONDICIONES DE RECLAMACION
        private void MostrarListadoCondicionesReclamos()
        {
            string _Condicion = string.IsNullOrEmpty(txtMantenimientoCOndicion.Text.Trim()) ? null : txtMantenimientoCOndicion.Text.Trim();

            var Buscar = ObjData.Value.BuscaCondicionReclamaciones(
                new Nullable<decimal>(),
                _Condicion);
            gvListadoCondicionesReclamaciones.DataSource = Buscar;
            gvListadoCondicionesReclamaciones.DataBind();
        }
        #endregion
        #region MANTENIMIENTO DE CONDICIONES DE RECLAMACIONES
        private void MAnCondicionreclamacion(string Accion) {
            try {
                UtilidadesAmigos.Logica.Entidades.ECondicionReclamacion Mantenimiento = new Logica.Entidades.ECondicionReclamacion();

                Mantenimiento.IdCondicion = Convert.ToDecimal(lbIdMantenimientoCondicion.Text);
                Mantenimiento.Condicion = txtMantenimientoCOndicion.Text;
                Mantenimiento.Estatus0 = cbEstatusMantenimientoCondicion.Checked;

                var MAN = ObjData.Value.MantenimientoCondicionesReclamos(Mantenimiento, Accion);
            }
            catch (Exception) { }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListasDesplegablesConsulta();
                ConsultarRegistros();
                ClientScript.RegisterStartupScript(GetType(), "ModoConsulta", "ModoConsulta();", true);
            }
        }

        protected void btnConsultarRegistros_Click(object sender, EventArgs e)
        {
            ConsultarRegistros();
            ClientScript.RegisterStartupScript(GetType(), "ModoConsulta", "ModoConsulta();", true);
        }

        protected void btnExportarRegistrosConsulta_Click(object sender, EventArgs e)
        {
            ExportarDataExel();
            ClientScript.RegisterStartupScript(GetType(), "ModoConsulta", "ModoConsulta();", true);
        }

        protected void gvListadoReclamos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoReclamos.PageIndex = e.NewPageIndex;
            ConsultarRegistros();
            ClientScript.RegisterStartupScript(GetType(), "ModoConsulta", "ModoConsulta();", true);
        }

        protected void gvListadoReclamos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Mensaje", "Mensaje();", true);
           // ClientScript.RegisterStartupScript(GetType(), "ModoMantenimiento", "ModoMantenimiento();", true);
        }

        protected void cbAgregarRangoFechaConsulta_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAgregarRangoFechaConsulta.Checked)
            {
             
                rbConsultarInicioVigenciaConsulta.Visible = true;
                rbConsultarFinVigencia.Visible = true;
                rbConsultarFechaApertura.Visible = true;
                rbConsultarFechaSiniestro.Visible = true;

                rbConsultarInicioVigenciaConsulta.Checked = true;
                lbFechaDesdeConsulta.Visible = true;
                txtFechaDesdeConsulta.Visible = true;
                lbFechHAstaConsulta.Visible = true;
                txtFechaHAstaConsulta.Visible = true;
            }
            else
            {
                rbConsultarInicioVigenciaConsulta.Visible = false;
                rbConsultarFinVigencia.Visible = false;
                rbConsultarFechaApertura.Visible = false;
                rbConsultarFechaSiniestro.Visible = false;

                rbConsultarInicioVigenciaConsulta.Checked = true;
                lbFechaDesdeConsulta.Visible = false;
                txtFechaDesdeConsulta.Visible = false;
                lbFechHAstaConsulta.Visible = false;
                txtFechaHAstaConsulta.Visible = false;
                txtFechaDesdeConsulta.Text = string.Empty;
                txtFechaHAstaConsulta.Text = string.Empty;
            }
            ClientScript.RegisterStartupScript(GetType(), "ModoConsulta", "ModoConsulta();", true);
        }

        protected void btnRestabelcerPantalla_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "ModoConsulta", "ModoConsulta();", true);
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        protected void btnConsultarCOndicionresReclamacion_Click(object sender, EventArgs e)
        {
            MostrarListadoCondicionesReclamos();
        }

        protected void btnExportarCondicionReclamos_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), " ModoConsultaCondicion", " ModoConsultaCondicion();", true);
        }

        protected void btnGuardarCondicionReclamos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMantenimientoCOndicion.Text.Trim()))
            {
               ClientScript.RegisterStartupScript(GetType(), "CamposVaciosCondicion", "CamposVaciosCondicion();", true);
            }
            else
            {
                MAnCondicionreclamacion(lbAccionCondicionMantenimiento.Text);
                txtMantenimientoCOndicion.Text = string.Empty;
                MostrarListadoCondicionesReclamos();
            }
        }

        protected void btnModificarCondicionReclamos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMantenimientoCOndicion.Text.Trim()))
            {

            }
            else
            {
                MAnCondicionreclamacion("UPDATE");
                txtMantenimientoCOndicion.Text = string.Empty;
                MostrarListadoCondicionesReclamos();
            }
        }

        protected void btnEliminarCondicionReclamos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMantenimientoCOndicion.Text.Trim()))
            {

            }
            else
            {
                lbAccionCondicionMantenimiento.Text = "DELETE";
                txtMantenimientoCOndicion.Text = string.Empty;
                MostrarListadoCondicionesReclamos();
            }
        }

        protected void btnRestabelcerCondicionReclamos_Click(object sender, EventArgs e)
        {
            btnConsultarCOndicionresReclamacion.Visible = true;
            btnGuardarCondicionReclamos.Visible = true;
            btnModificarCondicionReclamos.Visible = false;
            btnRestabelcerCondicionReclamos.Visible = false;
            txtMantenimientoCOndicion.Text = string.Empty;
            cbEstatusMantenimientoCondicion.Checked = true;
            MostrarListadoCondicionesReclamos();
        }

        protected void gvListadoCondicionesReclamaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoCondicionesReclamaciones.PageIndex = e.NewPageIndex;
            MostrarListadoCondicionesReclamos();
        }

        protected void gvListadoCondicionesReclamaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gvListadoCondicionesReclamaciones.SelectedRow;

            lbIdMantenimientoCondicion.Text = gb.Cells[0].Text;
            btnConsultarCOndicionresReclamacion.Visible = false;
            btnGuardarCondicionReclamos.Visible = false;
            btnModificarCondicionReclamos.Visible = true;
            btnRestabelcerCondicionReclamos.Visible = true;

            var Buscar = ObjData.Value.BuscaCondicionReclamaciones(
                Convert.ToDecimal(gb.Cells[0].Text));
            gvListadoCondicionesReclamaciones.DataSource = Buscar;
            gvListadoCondicionesReclamaciones.DataBind();
            foreach (var n in Buscar)
            {
                txtMantenimientoCOndicion.Text = n.Condicion;
                cbEstatusMantenimientoCondicion.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
            }
        }
    }
}