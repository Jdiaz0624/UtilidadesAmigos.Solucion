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
        DateTime InicioVigencia = DateTime.Now, Finvigencia = DateTime.Now, FechaSiniestro = DateTime.Now, fechaApertura = DateTime.Now;

        #region CARGAMOS LAS LISTAS DESPLEGABLES PARA LA CONSULTA
        private void CargarListasDesplegablesConsulta()
        {
            //LISTAS DESPLEGABLES EN LA PANTALLA DE CONSULTA
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarCondicionConsulta, ObjData.Value.BuscaListas("CONDICIONRECLAMACION", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoConsulta, ObjData.Value.BuscaListas("TIPORECLAMACION", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarEstatutsConsulta, ObjData.Value.BuscaListas("ESTATUSRECLAMACION", null, null), true);

            //LISTAS DESPLEGABLES EN LA PANTALLA DE MANTENIMIENTO
        }
        #endregion
        #region CARGAR EL LISTADO DE LAS LISTAS EN EL MANTENIMIENTO
        private void CargarListasMAN() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarCondicionMantenimiento, ObjData.Value.BuscaListas("CONDICIONRECLAMACION", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoMantenimiento, ObjData.Value.BuscaListas("TIPORECLAMACION", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarEstatusMantenimiento, ObjData.Value.BuscaListas("ESTATUSRECLAMACION", null, null));
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
               // gvListadoReclamos.Columns[0].Visible = false;
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
               // Correo.EnviarCorreo("ing.juanmarcelinom.diaz@hotmail.com", "!@Pa$$W0rd!@0624", "jmdiaz@amigosseguros.com", MEnsajeError, "Error en Proceso");
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
        #region MOSTRAR EL LISTADO DE LOS TIPOS DE RECLAMACIONES
        private void MostrarListadoTipoReclamos()
        {
            string _TipoReclamo = string.IsNullOrEmpty(txtMantenimientoTipoReclamo.Text.Trim()) ? null : txtMantenimientoTipoReclamo.Text.Trim();

            var BuscarTipoReclamao = ObjData.Value.BuscaTipoReclamacion(
                new Nullable<decimal>(),
                _TipoReclamo);
            gvListadoTipoReclamo.DataSource = BuscarTipoReclamao;
            gvListadoTipoReclamo.DataBind();
        }
        #endregion
        #region MANTENIMIENTO DE TIPO DE RECLAMO
        private void MANTipoReclamo(string Accion)
        {
            try {
                UtilidadesAmigos.Logica.Entidades.ETipoReclamacion Mantenimiento = new Logica.Entidades.ETipoReclamacion();

                Mantenimiento.IdTipoReclamacion = Convert.ToDecimal(lbIdMantenimientoTipoReclamo.Text);
                Mantenimiento.Tipo = txtMantenimientoTipoReclamo.Text;
                Mantenimiento.Estatus0 = cbEstatusTipoRecmalo.Checked;

                var MAn = ObjData.Value.MantenimientoTipoReclamos(Mantenimiento, Accion);
            }
            catch (Exception) { }
        }
        #endregion
        #region LIMPIAR CONTROLES EN TIPO DE RECLAMOS
        private void LimpiarControlesTipoReclamo() {
            txtMantenimientoTipoReclamo.Text = string.Empty;
            cbEstatusTipoRecmalo.Checked = true;
            cbEstatusTipoRecmalo.ForeColor = System.Drawing.Color.Green;
            MostrarListadoTipoReclamos();
            btnConsultarTipoReclamo.Visible = true;
            btnGuardarTipoReclamo.Visible = true;
            btnModificarTipoReclamo.Visible = false;
            btnRestablecerTipoReclamo.Visible = false;
            CargarListasDesplegablesConsulta();
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LOS ESTATUS DE RECLAMO
        private void MostrarListadoEstatusReclamo()
        {
            string _Estatus = string.IsNullOrEmpty(txtMantenimientoEstatusReclamo.Text.Trim()) ? null : txtMantenimientoEstatusReclamo.Text.Trim();

            var Buscar = ObjData.Value.BuscaEstatusReclamacion(
                new Nullable<decimal>(),
                _Estatus);
            gvListadoEstatusReclamo.DataSource = Buscar;
            gvListadoEstatusReclamo.DataBind();
        }
        #endregion
        #region MANTENIMIENTO DE ESTATUS DE RECLAMO
        private void MANEstatusReclamo(string Accion)
        {
            try {
                UtilidadesAmigos.Logica.Entidades.EBuscaEstatusReclamacion Mantenimiento = new Logica.Entidades.EBuscaEstatusReclamacion();

                Mantenimiento.IdEstatusReclamacion = Convert.ToDecimal(lbIdMantenimientoEstatusReclamo.Text);
                Mantenimiento.DescripcionEstatus = txtMantenimientoEstatusReclamo.Text;
                Mantenimiento.Estatus0 = cbMantenimientoEstatusReclamo.Checked;

                var MAn = ObjData.Value.MantenimientoEstatusReclamacion(Mantenimiento, Accion);
            }
            catch (Exception) { }
        }
        #endregion
        #region RESTABELCER ESTATUS RECLAMO
        private void ResablecerEstatusReclamo()
        {
            txtMantenimientoEstatusReclamo.Text = string.Empty;
            cbMantenimientoEstatusReclamo.Checked = true;
            btnConsultarEstatusReclamo.Visible = true;
            btnGuardarEstatusReclamo.Visible = true;
            btnModificarEstatusReclamo.Visible = false;
            btnRestablecerEstatusReclamo.Visible = false;
            MostrarListadoEstatusReclamo();
        }
        #endregion
        #region MANTENIMIENTO DE RECLAMACIONES
        private void MANReclamaciones(decimal IdReclamacion, string Accion) {
            try {
              

                if (cbBuscarFechaAutomatico.Checked == false)
                {
                    InicioVigencia = Convert.ToDateTime(txtInicioVigenciaMantenimiento.Text);
                    Finvigencia = Convert.ToDateTime(txtFinVigenciaMantenimiento.Text);
                    fechaApertura = Convert.ToDateTime(txtFechaAperturaMantenimiento.Text);
                    FechaSiniestro = Convert.ToDateTime(txtFechaSiniestroMantenimiento.Text);
                }

                UtilidadesAmigos.Logica.Entidades.EReclamacion Mantenimiento = new Logica.Entidades.EReclamacion();

                Mantenimiento.Numero = IdReclamacion;
                Mantenimiento.Reclamacion = Convert.ToDecimal(txtNumeroReclamacionMantenimiento.Text);
                Mantenimiento.Poliza = txtPolizaMantenimiento.Text;
                Mantenimiento.Intermediario = Convert.ToDecimal(txtIntermediarioMantenimiento.Text);
                Mantenimiento.Asegurado = txtAseguradoMantenimiento.Text;
                Mantenimiento.IdCondicion = Convert.ToDecimal(ddlSeleccionarCondicionMantenimiento.SelectedValue);
                Mantenimiento.Monto = Convert.ToDecimal(txtMontoMantenimiento.Text);
                Mantenimiento.Beneficiario = txtBeneficiarioMantenimiento.Text;
                Mantenimiento.IdTipo = Convert.ToDecimal(ddlSeleccionarTipoMantenimiento.SelectedValue);
                Mantenimiento.InicioVigencia0 = InicioVigencia;
                Mantenimiento.FinVigencia0 = Finvigencia;
                Mantenimiento.FechaApertura0 = fechaApertura;
                Mantenimiento.FechaSiniestro0 = FechaSiniestro;
                Mantenimiento.FechaCreacion0 = DateTime.Now;
                Mantenimiento.IdEstatus = Convert.ToDecimal(ddlSeleccionarEstatusMantenimiento.SelectedValue);
                Mantenimiento.IdUsuario = Convert.ToDecimal(lbIdUsuarioConectado.Text);
                Mantenimiento.Comentario = txtComentarioMantenimiento.Text;

                var MAN = ObjData.Value.MantenimientoReclamaciones(Mantenimiento, Accion);

                
            }
            catch (Exception ex) {
                string mensajeEroror = ex.Message;
            }
        }
        #endregion
        #region MANTENIMIENTO PARA ELIMINAR Y MODIFICAR
        private void MANElimianrModificar(decimal IdReclamacion, DateTime FechaInicioMAN, DateTime FechaFinMAN, DateTime FechaAperturaMAN, DateTime FechaSinietroMAN, string Accion)
        {
            try {
                UtilidadesAmigos.Logica.Entidades.EReclamacion Mantenimiento = new Logica.Entidades.EReclamacion();

                Mantenimiento.Numero = IdReclamacion;
                Mantenimiento.Reclamacion = Convert.ToDecimal(txtNumeroReclamacionMantenimiento.Text);
                Mantenimiento.Poliza = txtPolizaMantenimiento.Text;
                Mantenimiento.Intermediario = Convert.ToDecimal(txtIntermediarioMantenimiento.Text);
                Mantenimiento.Asegurado = txtAseguradoMantenimiento.Text;
                Mantenimiento.IdCondicion = Convert.ToDecimal(ddlSeleccionarCondicionMantenimiento.SelectedValue);
                Mantenimiento.Monto = Convert.ToDecimal(txtMontoMantenimiento.Text);
                Mantenimiento.Beneficiario = txtBeneficiarioMantenimiento.Text;
                Mantenimiento.IdTipo = Convert.ToDecimal(ddlSeleccionarTipoMantenimiento.SelectedValue);
                Mantenimiento.InicioVigencia0 = FechaInicioMAN;
                Mantenimiento.FinVigencia0 = FechaFinMAN;
                Mantenimiento.FechaApertura0 = FechaAperturaMAN;
                Mantenimiento.FechaSiniestro0 = FechaSinietroMAN;
                Mantenimiento.FechaCreacion0 = DateTime.Now;
                Mantenimiento.IdEstatus = Convert.ToDecimal(ddlSeleccionarEstatusMantenimiento.SelectedValue);
                Mantenimiento.IdUsuario = Convert.ToDecimal(lbIdUsuarioConectado.Text);
                Mantenimiento.Comentario = txtComentarioMantenimiento.Text;

                var MAN = ObjData.Value.MantenimientoReclamaciones(Mantenimiento, Accion);
            }
            catch (Exception ex) { }
        }
        #endregion
        #region RESTABLECER
        private void Restablecer() {
            lbRegistroSeleccionado.Visible = false;
            txtReclamacionConsulta.Text = string.Empty;
            txtPolizaConsulta.Text = string.Empty;
            txtIntermediarioConsulta.Text = string.Empty;
            txtAseguradoCOnsulta.Text = string.Empty;
            txtBeneficiarioConsulta.Text = string.Empty;
            cbAgregarRangoFechaConsulta.Checked = false;
            txtFechaDesdeConsulta.Text = string.Empty;
            txtFechaHAstaConsulta.Text = string.Empty;
            CargarListasDesplegablesConsulta();
            ConsultarRegistros();

            //MOSTRAMOS LOS CONTROLES NECESARIOS
            lbRegistroSeleccionado.Visible = false;
            lbNumeriIDSeleccionadoConsulta.Visible = false;
            txtNumeroIdSeleccionadoConsulta.Visible = false;
            lbNumeroreclamacinSeleccionadoConsulta.Visible = false;
            txtNumeroreclamacionSeleccionadoConsulta.Visible = false;
            lbPolizaSeleccionadaConsulta.Visible = false;
            txtPolizaSeleccionadaConsulta.Visible = false;
            lbEstatusPolizaSeleccionadaConsulta.Visible = false;
            txtEstatusPolizaSelccionadaConsulta.Visible = false;
            lbIntermediarioSeleccionadoCOnsulta.Visible = false;
            txtIntermediarioSeleccionadoConsulta.Visible = false;
            lbAseguradoSeleccionadoConsulta.Visible = false;
            txtaseguradoSeleccionadoConsulta.Visible = false;
            lbBeneficiarioSeleccionadoCOnsulta.Visible = false;
            txtBeneficiarioSeleccionadoConsulta.Visible = false;
            lbTipoSeleccionadoConsulta.Visible = false;
            txtTipoReclamoSeleccionado.Visible = false;
            lbCondicionSeleccionadaConsulta.Visible = false;
            txtCondicionSeleccionadaConsulta.Visible = false;
            lbEstatusSeleccionadaConsulta.Visible = false;
            txtEstatusSeleccionadoConsulta.Visible = false;
            lbMontoSeleccionadoConsulta.Visible = false;
            txtMontoSeleccionadoConsulta.Visible = false;
            lbUsuarioSeleccionadoCOnsulta.Visible = false;
            txtUsuarioSeleccionadoCOnsulta.Visible = false;
            lbInicioVigenciaSeleccionadoConsulta.Visible = false;
            txtInicioVigenciaSeleccionadoConsulta.Visible = false;
            lbFechaFinVigenciaSeleccionadaConsulta.Visible = false;
            txtFechaFinVigenciaSeleccionadaConsulta.Visible = false;
            lbFechaAperturaSeleccionadaConsulta.Visible = false;
            txtFechaAperturaSeleccionadaConsulta.Visible = false;
            lbFechaSiniestroSeleccionadaConsulta.Visible = false;
            lbComentarioSeleccionadoConsulta.Visible = false;
            txtComentarioSeleccionadoCnsulta.Visible = false;
            txtFechaSiniestroSeleccionadaConsulta.Visible = false;


            //MOSTRAMOS LOS CONTROLES NECESARIOS
          //  lbRegistroSeleccionado.Text = string.Empty;
         //   lbNumeriIDSeleccionadoConsulta.Text = string.Empty;
            txtNumeroIdSeleccionadoConsulta.Text = string.Empty;
          //  lbNumeroreclamacinSeleccionadoConsulta.Text = string.Empty;
            txtNumeroreclamacionSeleccionadoConsulta.Text = string.Empty;
          //  lbPolizaSeleccionadaConsulta.Text = string.Empty;
            txtPolizaSeleccionadaConsulta.Text = string.Empty;
         //   lbEstatusPolizaSeleccionadaConsulta.Text = string.Empty;
            txtEstatusPolizaSelccionadaConsulta.Text = string.Empty;
          //  lbIntermediarioSeleccionadoCOnsulta.Text = string.Empty;
            txtIntermediarioSeleccionadoConsulta.Text = string.Empty;
          //  lbAseguradoSeleccionadoConsulta.Text = string.Empty;
            txtaseguradoSeleccionadoConsulta.Text = string.Empty;
         //  lbBeneficiarioSeleccionadoCOnsulta.Text = string.Empty;
            txtBeneficiarioSeleccionadoConsulta.Text = string.Empty;
         //   lbTipoSeleccionadoConsulta.Text = string.Empty;
            txtTipoReclamoSeleccionado.Text = string.Empty;
         //   lbCondicionSeleccionadaConsulta.Text = string.Empty;
            txtCondicionSeleccionadaConsulta.Text = string.Empty;
         //   lbEstatusSeleccionadaConsulta.Text = string.Empty;
            txtEstatusSeleccionadoConsulta.Text = string.Empty;
          //  lbMontoSeleccionadoConsulta.Text = string.Empty;
            txtMontoSeleccionadoConsulta.Text = string.Empty;
          //  lbUsuarioSeleccionadoCOnsulta.Text = string.Empty;
            txtUsuarioSeleccionadoCOnsulta.Text = string.Empty;
         //   lbInicioVigenciaSeleccionadoConsulta.Text = string.Empty;
            txtInicioVigenciaSeleccionadoConsulta.Text = string.Empty;
         //   lbFechaFinVigenciaSeleccionadaConsulta.Text = string.Empty;
            txtFechaFinVigenciaSeleccionadaConsulta.Text = string.Empty;
         //   lbFechaAperturaSeleccionadaConsulta.Text = string.Empty;
            txtFechaAperturaSeleccionadaConsulta.Text = string.Empty;
         //   lbFechaSiniestroSeleccionadaConsulta.Text = string.Empty;
         //   lbComentarioSeleccionadoConsulta.Text = string.Empty;
            txtComentarioSeleccionadoCnsulta.Text = string.Empty;

            rbBuscarFacturasTodas.Visible = false;
            rbBuscaFActurasAnuladas.Visible = false;
            rbBuscarFacturasActivas.Visible = false;
            lbLetreroNumeroFacturaRelacionado.Visible = false;
            gvListadoFacturaReclamos.Visible = false;

            ClientScript.RegisterStartupScript(GetType(), "ModoConsulta", "ModoConsulta();", true);
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LAS FACTURAS PAGADAS
        private void MostrarListadoFacturasPaadasReclamos(string Numerpreclamo, string Anulado ) {
            try {
                var Buscar = ObjData.Value.BuscaFActurasPagadasReclamos(Numerpreclamo, Anulado);
                gvListadoFacturaReclamos.DataSource = Buscar;
                gvListadoFacturaReclamos.DataBind();
            }
            catch (Exception) { }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListasDesplegablesConsulta();
                CargarListasMAN();
                ConsultarRegistros();
                ClientScript.RegisterStartupScript(GetType(), "ModoConsulta", "ModoConsulta();", true);
                cbEstatusMantenimientoCondicion.Checked = true;
                cbEstatusTipoRecmalo.Checked = true;
                cbEstatusTipoRecmalo.ForeColor = System.Drawing.Color.Green;
                lbIdUsuarioConectado.Text = Session["IdUsuario"].ToString();
                rbBuscarFacturasTodas.Checked = true;

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
            GridViewRow Gb = gvListadoReclamos.SelectedRow;
            Gb.Cells[0].Visible = false;
            lbNumeroReclamacionSeleccionado.Text = Gb.Cells[0].Text;
            lbPolizaSeleccionada.Text = Gb.Cells[1].Text;

            var BuscarRegistro = ObjData.Value.BuscaReclamaciones(
                Convert.ToDecimal(lbNumeroReclamacionSeleccionado.Text));
            gvListadoReclamos.DataSource = BuscarRegistro;
            gvListadoReclamos.DataBind();
            //SACAMOS LOS DATOS NECESARIOS PARA REALIZAR EL PROCESO
            foreach (var n in BuscarRegistro)
            {
                lbCantidadRegistrosVariables.Text = n.CantidadRegistros.ToString();
                lbRegistroSeleccionado.Visible = true;
                txtInicioVigenciaMantenimiento.Visible = false;
                txtFechaInicioVigenciaAutomatico.Visible = true;
                txtFinVigenciaMantenimiento.Visible = false;
                txtFechaFinVigenciaAutomatico.Visible = true;
                txtFechaAperturaMantenimiento.Visible = false;
                txtFechaAperturaAutomatica.Visible = true;
                txtFechaSiniestroMantenimiento.Visible = false;
                txtFechaSiniestroAutomatica.Visible = true;
                InicioVigencia = Convert.ToDateTime(n.InicioVigencia0);
                Finvigencia = Convert.ToDateTime(n.FinVigencia0);
                fechaApertura = Convert.ToDateTime(n.FechaApertura0);
                FechaSiniestro = Convert.ToDateTime(n.FechaSiniestro0);
                lbClaveseguridadMantenimiento.Visible = true;
                txtClaveSeguridadMantenimiento.Visible = true;
                cbModificarInicioVigencia.Visible = true;

                //SACAMOS LOS DATOS PARA EL MANTENIMIENTO
                txtNumeroReclamacionMantenimiento.Text = n.Reclamacion.ToString();
                txtPolizaMantenimiento.Text = n.Poliza;
                txtIntermediarioMantenimiento.Text = n.Intermediario.ToString();
                txtAseguradoMantenimiento.Text = n.Asegurado;
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarTipoMantenimiento, n.IdTipo.ToString());
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarCondicionMantenimiento, n.IdCondicion.ToString());
                txtMontoMantenimiento.Text = n.Monto.ToString();
                txtBeneficiarioMantenimiento.Text = n.Beneficiario;
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarEstatusMantenimiento, n.IdEstatus.ToString());
                txtFechaInicioVigenciaAutomatico.Text = n.InicioVigencia;
                txtFechaFinVigenciaAutomatico.Text = n.FinVigencia;
                txtFechaAperturaAutomatica.Text = n.FechaApertura;
                txtFechaSiniestroAutomatica.Text = n.FechaSiniestro;
                txtComentarioMantenimiento.Text = n.Comentario;

                //MOSTRAMOS LOS CONTROLES NECESARIOS
                lbRegistroSeleccionado.Visible = true;
                lbNumeriIDSeleccionadoConsulta.Visible = true;
                txtNumeroIdSeleccionadoConsulta.Visible = true;
                lbNumeroreclamacinSeleccionadoConsulta.Visible = true;
                txtNumeroreclamacionSeleccionadoConsulta.Visible = true;
                lbPolizaSeleccionadaConsulta.Visible = true;
                txtPolizaSeleccionadaConsulta.Visible = true;
                lbEstatusPolizaSeleccionadaConsulta.Visible = true;
                txtEstatusPolizaSelccionadaConsulta.Visible = true;
                lbIntermediarioSeleccionadoCOnsulta.Visible = true;
                txtIntermediarioSeleccionadoConsulta.Visible = true;
                lbAseguradoSeleccionadoConsulta.Visible = true;
                txtaseguradoSeleccionadoConsulta.Visible = true;
                lbBeneficiarioSeleccionadoCOnsulta.Visible = true;
                txtBeneficiarioSeleccionadoConsulta.Visible = true;
                lbTipoSeleccionadoConsulta.Visible = true;
                txtTipoReclamoSeleccionado.Visible = true;
                lbCondicionSeleccionadaConsulta.Visible = true;
                txtCondicionSeleccionadaConsulta.Visible = true;
                lbEstatusSeleccionadaConsulta.Visible = true;
                txtEstatusSeleccionadoConsulta.Visible = true;
                lbMontoSeleccionadoConsulta.Visible = true;
                txtMontoSeleccionadoConsulta.Visible = true;
                lbUsuarioSeleccionadoCOnsulta.Visible = true;
                txtUsuarioSeleccionadoCOnsulta.Visible = true;
                lbInicioVigenciaSeleccionadoConsulta.Visible = true;
                txtInicioVigenciaSeleccionadoConsulta.Visible = true;
                lbFechaFinVigenciaSeleccionadaConsulta.Visible = true;
                txtFechaFinVigenciaSeleccionadaConsulta.Visible = true;
                lbFechaAperturaSeleccionadaConsulta.Visible = true;
                txtFechaAperturaSeleccionadaConsulta.Visible = true;
                lbFechaSiniestroSeleccionadaConsulta.Visible = true;
                lbComentarioSeleccionadoConsulta.Visible = true;
                txtComentarioSeleccionadoCnsulta.Visible = true;
                txtFechaSiniestroSeleccionadaConsulta.Visible = true;

                //MOSTRAMOS LOS DATOS
                txtNumeroIdSeleccionadoConsulta.Text = n.Numero.ToString();
                txtNumeroreclamacionSeleccionadoConsulta.Text = n.Reclamacion.ToString();
                txtPolizaSeleccionadaConsulta.Text = n.Poliza;
                txtEstatusPolizaSelccionadaConsulta.Text = n.Estatus;
                txtIntermediarioSeleccionadoConsulta.Text = n.NombreIntermediario;
                txtaseguradoSeleccionadoConsulta.Text = n.Asegurado;
                txtBeneficiarioSeleccionadoConsulta.Text = n.Beneficiario;
                txtTipoReclamoSeleccionado.Text = n.TipoReclamacion;
                txtCondicionSeleccionadaConsulta.Text = n.Condicion;
                txtEstatusSeleccionadoConsulta.Text = n.EstatusReclamacion;
                decimal MontoReclamo = Convert.ToDecimal(n.Monto);
                txtMontoSeleccionadoConsulta.Text = MontoReclamo.ToString("N2");
                txtUsuarioSeleccionadoCOnsulta.Text = n.Usuario;
                txtInicioVigenciaSeleccionadoConsulta.Text = n.InicioVigencia;
                txtFechaFinVigenciaSeleccionadaConsulta.Text = n.FinVigencia;
                txtFechaAperturaSeleccionadaConsulta.Text = n.FechaApertura;
                txtFechaSiniestroSeleccionadaConsulta.Text = n.FechaSiniestro;
                txtComentarioSeleccionadoCnsulta.Text = n.Comentario;

                //MOSTRAMOS EL LISTADO DE LAS FACTURAS RELACIONADO CON EL NUMERO DE RECLAMO SELECCIONADO
                rbBuscarFacturasTodas.Visible = true;
                rbBuscaFActurasAnuladas.Visible = true;
                rbBuscarFacturasActivas.Visible = true;
                gvListadoFacturaReclamos.Visible = true;
                rbBuscarFacturasTodas.Checked = true;
                lbLetreroNumeroFacturaRelacionado.Visible = true;
                MostrarListadoFacturasPaadasReclamos(txtNumeroreclamacionSeleccionadoConsulta.Text,null);
            }
            ClientScript.RegisterStartupScript(GetType(), "ModoMantenimiento", "ModoMantenimiento();", true);
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
            Restablecer();
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
                CargarListasDesplegablesConsulta();
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
                CargarListasDesplegablesConsulta();
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
                CargarListasDesplegablesConsulta();
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

        protected void btnConsultarTipoReclamo_Click(object sender, EventArgs e)
        {
            MostrarListadoTipoReclamos();
        }

        protected void btnGuardarTipoReclamo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMantenimientoTipoReclamo.Text.Trim()))
            {

            }
            else
            {
                lbIdMantenimientoTipoReclamo.Text = "0";
                MANTipoReclamo("INSERT");
                LimpiarControlesTipoReclamo();
            }
        }

        protected void btnModificarTipoReclamo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMantenimientoTipoReclamo.Text.Trim()))
            {

            }
            else
            {
               // lbIdMantenimientoTipoReclamo.Text = "0";
                MANTipoReclamo("UPDATE");
                LimpiarControlesTipoReclamo();
            }
        }

        protected void btnRestablecerTipoReclamo_Click(object sender, EventArgs e)
        {
            LimpiarControlesTipoReclamo();
        }

        protected void gvListadoTipoReclamo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoTipoReclamo.PageIndex = e.NewPageIndex;
            MostrarListadoTipoReclamos();
        }

        protected void gvListadoTipoReclamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gvListadoTipoReclamo.SelectedRow;

            lbIdMantenimientoTipoReclamo.Text = gb.Cells[0].Text;

            var Buscar = ObjData.Value.BuscaTipoReclamacion(
                Convert.ToDecimal(gb.Cells[0].Text));
            gvListadoTipoReclamo.DataSource = Buscar;
            gvListadoTipoReclamo.DataBind();
            btnConsultarTipoReclamo.Visible = false;
            btnGuardarTipoReclamo.Visible = false;
            btnModificarTipoReclamo.Visible = true;
            btnRestablecerTipoReclamo.Visible = true;
            foreach (var n in Buscar)
            {
                txtMantenimientoTipoReclamo.Text = n.Tipo;
                cbEstatusTipoRecmalo.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
            }
        }

        protected void cbEstatusTipoRecmalo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEstatusTipoRecmalo.Checked)
            {
                cbEstatusTipoRecmalo.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                cbEstatusTipoRecmalo.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnConsultarEstatusReclamo_Click(object sender, EventArgs e)
        {
            MostrarListadoEstatusReclamo();
        }

        protected void btnGuardarEstatusReclamo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbIdMantenimientoEstatusReclamo.Text.Trim()))
            {

            }
            else
            {
                lbIdMantenimientoEstatusReclamo.Text = "0";
                MANEstatusReclamo("INSERT");
                ResablecerEstatusReclamo();
            }
        }

        protected void btnModificarEstatusReclamo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbIdMantenimientoEstatusReclamo.Text.Trim()))
            {

            }
            else
            {
                // lbIdMantenimientoEstatusReclamo.Text = "0";
                if (cbModificarInicioVigencia.Checked)
                {
                    UtilidadesAmigos.Logica.Entidades.EReclamacion Mantenimiento = new Logica.Entidades.EReclamacion();

                    Mantenimiento.Numero = Convert.ToDecimal(txtNumeroIdSeleccionadoConsulta.Text);
                    Mantenimiento.Reclamacion = Convert.ToDecimal(txtNumeroReclamacionMantenimiento.Text);
                    Mantenimiento.Poliza = txtPolizaMantenimiento.Text;
                    Mantenimiento.Intermediario = Convert.ToDecimal(txtIntermediarioMantenimiento.Text);
                    Mantenimiento.Asegurado = txtAseguradoMantenimiento.Text;
                    Mantenimiento.IdCondicion = Convert.ToDecimal(ddlSeleccionarCondicionMantenimiento.SelectedValue);
                    Mantenimiento.Monto = Convert.ToDecimal(txtMontoMantenimiento.Text);
                    Mantenimiento.Beneficiario = txtBeneficiarioMantenimiento.Text;
                    Mantenimiento.IdTipo = Convert.ToDecimal(ddlSeleccionarTipoMantenimiento.SelectedValue);
                    Mantenimiento.InicioVigencia0 = InicioVigencia;
                    Mantenimiento.FinVigencia0 = Finvigencia;
                    Mantenimiento.FechaApertura0 = fechaApertura;
                    Mantenimiento.FechaSiniestro0 = FechaSiniestro;
                    Mantenimiento.FechaCreacion0 = DateTime.Now;
                    Mantenimiento.IdEstatus = Convert.ToDecimal(ddlSeleccionarEstatusMantenimiento.SelectedValue);
                    Mantenimiento.IdUsuario = Convert.ToDecimal(lbIdUsuarioConectado.Text);
                    Mantenimiento.Comentario = txtComentarioMantenimiento.Text;

                    var MAN = ObjData.Value.MantenimientoReclamaciones(Mantenimiento, "UPDATE");
                }
                else
                {
                    UtilidadesAmigos.Logica.Entidades.EReclamacion Mantenimiento = new Logica.Entidades.EReclamacion();

                    Mantenimiento.Numero = Convert.ToDecimal(txtNumeroIdSeleccionadoConsulta.Text);
                    Mantenimiento.Reclamacion = Convert.ToDecimal(txtNumeroReclamacionMantenimiento.Text);
                    Mantenimiento.Poliza = txtPolizaMantenimiento.Text;
                    Mantenimiento.Intermediario = Convert.ToDecimal(txtIntermediarioMantenimiento.Text);
                    Mantenimiento.Asegurado = txtAseguradoMantenimiento.Text;
                    Mantenimiento.IdCondicion = Convert.ToDecimal(ddlSeleccionarCondicionMantenimiento.SelectedValue);
                    Mantenimiento.Monto = Convert.ToDecimal(txtMontoMantenimiento.Text);
                    Mantenimiento.Beneficiario = txtBeneficiarioMantenimiento.Text;
                    Mantenimiento.IdTipo = Convert.ToDecimal(ddlSeleccionarTipoMantenimiento.SelectedValue);
                    Mantenimiento.InicioVigencia0 = InicioVigencia;
                    Mantenimiento.FinVigencia0 = Finvigencia;
                    Mantenimiento.FechaApertura0 = fechaApertura;
                    Mantenimiento.FechaSiniestro0 = FechaSiniestro;
                    Mantenimiento.FechaCreacion0 = DateTime.Now;
                    Mantenimiento.IdEstatus = Convert.ToDecimal(ddlSeleccionarEstatusMantenimiento.SelectedValue);
                    Mantenimiento.IdUsuario = Convert.ToDecimal(lbIdUsuarioConectado.Text);
                    Mantenimiento.Comentario = txtComentarioMantenimiento.Text;

                    var MAN = ObjData.Value.MantenimientoReclamaciones(Mantenimiento, "UPDATE");
                }

                ResablecerEstatusReclamo();
            }
        }

        protected void btnRestablecerEstatusReclamo_Click(object sender, EventArgs e)
        {
            ResablecerEstatusReclamo();
        }

        protected void gvListadoEstatusReclamo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoEstatusReclamo.PageIndex = e.NewPageIndex;
            MostrarListadoEstatusReclamo();
        }

        protected void btnModificarMantenimeinto_Click(object sender, EventArgs e)
        {
            //VERIFICAMOS SI LA CLAVE DE SEGURIDAD INGRESADA NO ES VALIDA
            string _ClaveSeguridad = string.IsNullOrEmpty(txtClaveSeguridadMantenimiento.Text.Trim()) ? null : txtClaveSeguridadMantenimiento.Text.Trim();

            var ValidarClaveSeguridad = ObjData.Value.BuscaClaveSeguridad(
                new Nullable<decimal>(),
                UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(_ClaveSeguridad));
            if (ValidarClaveSeguridad.Count()<1)
            {
                //MENSAJE
                ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadErronea", "ClaveSeguridadErronea();", true);
            }
            else
            {
                DateTime fechaInicioVigenciaUpdate2 = DateTime.Now, FechaFinVigenciaUpdate2 = DateTime.Now, FechaAperturaUpdate2 = DateTime.Now, FechaSIniestroUpdate2 = DateTime.Now;

                var Sacarfechas = ObjData.Value.BuscaFechaReclamos(Convert.ToDecimal(txtNumeroreclamacionSeleccionadoConsulta.Text));
                foreach (var n in Sacarfechas)
                {
                    fechaInicioVigenciaUpdate2 = Convert.ToDateTime(n.InicioVigencia0);
                    FechaFinVigenciaUpdate2 = Convert.ToDateTime(n.FinVigencia0);
                    FechaAperturaUpdate2 = Convert.ToDateTime(n.FechaApertura0);
                    FechaSIniestroUpdate2 = Convert.ToDateTime(n.FechaSiniestro0);
                }

                if (cbModificarInicioVigencia.Checked)
                {

                    DateTime fechaInicioVigenciaUpdate3 = DateTime.Now, FechaFinVigenciaUpdate3 = DateTime.Now, FechaAperturaUpdate3 = DateTime.Now, FechaSIniestroUpdate3 = DateTime.Now;

                    if (string.IsNullOrEmpty(txtInicioVigenciaMantenimiento.Text.Trim()))
                    {
                        fechaInicioVigenciaUpdate3 = fechaInicioVigenciaUpdate2;
                    }
                    else
                    {
                        fechaInicioVigenciaUpdate3 = Convert.ToDateTime(txtInicioVigenciaMantenimiento.Text);
                    }

                    if (string.IsNullOrEmpty(txtFinVigenciaMantenimiento.Text.Trim()))
                    {
                        FechaFinVigenciaUpdate3 = FechaFinVigenciaUpdate2;
                    }
                    else {
                        FechaFinVigenciaUpdate3 = Convert.ToDateTime(txtFinVigenciaMantenimiento.Text);
                    }

                    if (string.IsNullOrEmpty(txtFechaAperturaMantenimiento.Text.Trim()))
                    {
                        FechaAperturaUpdate3 = FechaAperturaUpdate2;
                    }
                    else {
                        FechaAperturaUpdate3 = Convert.ToDateTime(txtFechaAperturaMantenimiento.Text);
                    }

                    if (string.IsNullOrEmpty(txtFechaSiniestroMantenimiento.Text.Trim()))
                    {
                        FechaSIniestroUpdate3 = FechaSIniestroUpdate2;
                    }
                    else {
                        FechaSIniestroUpdate3 = Convert.ToDateTime(txtFechaSiniestroMantenimiento.Text);
                    }

                    //MODIFICAMOS EL REGISTRO
                    MANElimianrModificar(
                        Convert.ToDecimal(txtNumeroIdSeleccionadoConsulta.Text),
                        fechaInicioVigenciaUpdate3,
                        FechaFinVigenciaUpdate3,
                        FechaAperturaUpdate3,
                        FechaSIniestroUpdate3,
                        "UPDATE");
                    Restablecer();
                }
                else
                {
                    //MODIFICAMOS EL REGISTRO
                    MANElimianrModificar(
                        Convert.ToDecimal(txtNumeroIdSeleccionadoConsulta.Text),
                        fechaInicioVigenciaUpdate2,
                        FechaFinVigenciaUpdate2,
                        FechaAperturaUpdate2,
                        FechaSIniestroUpdate2,
                        "UPDATE");
                    Restablecer();
                }
            }

        }

        protected void btnEliminarMantenimiento_Click(object sender, EventArgs e)
        {
            try {
                string _ClaveSeguridad = string.IsNullOrEmpty(txtClaveSeguridadMantenimiento.Text.Trim()) ? null : txtClaveSeguridadMantenimiento.Text.Trim();

                var ValidarClave = ObjData.Value.BuscaClaveSeguridad(
                    new Nullable<decimal>(),
                    UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(_ClaveSeguridad));
                if (ValidarClave.Count() < 1)
                {
                    //MENSAJE
                    ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadErronea", "ClaveSeguridadErronea();", true);

                }
                else
                {
                    //ELIMINAMOS EL REGISTRO
                    UtilidadesAmigos.Logica.Entidades.EReclamacion Mantenimiento = new Logica.Entidades.EReclamacion();

                    Mantenimiento.Numero = Convert.ToDecimal(txtNumeroIdSeleccionadoConsulta.Text);

                    var MAN = ObjData.Value.MantenimientoReclamaciones(Mantenimiento, "DELETE");
                    Restablecer();
                }
            }
            catch (Exception) { }
        }

        protected void gvListadoReclamos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void cbModificarInicioVigencia_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModificarInicioVigencia.Checked)
            {
                txtInicioVigenciaMantenimiento.Visible = true;
                txtFinVigenciaMantenimiento.Visible = true;
                txtFechaSiniestroMantenimiento.Visible = true;
                txtFechaAperturaMantenimiento.Visible = true;

                txtFechaFinVigenciaAutomatico.Visible = false;
                txtFechaInicioVigenciaAutomatico.Visible = false;
                txtFechaAperturaAutomatica.Visible = false;
                txtFechaSiniestroAutomatica.Visible = false;
            }
            else
            {
                txtInicioVigenciaMantenimiento.Visible = false;
                txtFinVigenciaMantenimiento.Visible = false;
                txtFechaSiniestroMantenimiento.Visible = false;
                txtFechaAperturaMantenimiento.Visible = false;

                txtFechaFinVigenciaAutomatico.Visible = true;
                txtFechaInicioVigenciaAutomatico.Visible = true;
                txtFechaAperturaAutomatica.Visible = true;
                txtFechaSiniestroAutomatica.Visible = true;
            }
        }

        protected void gvListadoFacturaReclamos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvListadoFacturaReclamos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvListadoFacturaReclamos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rbBuscarFacturasTodas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBuscarFacturasTodas.Checked)
            {
                MostrarListadoFacturasPaadasReclamos(txtNumeroreclamacionSeleccionadoConsulta.Text,null);
            }
            else { }
        }

        protected void rbBuscarFacturasActivas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBuscarFacturasActivas.Checked)
            {
                MostrarListadoFacturasPaadasReclamos(txtNumeroreclamacionSeleccionadoConsulta.Text, "N");
            }
            else { }
        }

        protected void rbBuscaFActurasAnuladas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBuscaFActurasAnuladas.Checked)
            {
                MostrarListadoFacturasPaadasReclamos(txtNumeroreclamacionSeleccionadoConsulta.Text, "S");
            }
            else { }
        }

        protected void gvListadoEstatusReclamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gvListadoEstatusReclamo.SelectedRow;

            lbIdMantenimientoEstatusReclamo.Text = gb.Cells[0].Text;

            var SacarDatos = ObjData.Value.BuscaEstatusReclamacion(
                Convert.ToDecimal(gb.Cells[0].Text));
            gvListadoEstatusReclamo.DataSource = SacarDatos;
            gvListadoEstatusReclamo.DataBind();
            foreach (var n in SacarDatos)
            {
                txtMantenimientoEstatusReclamo.Text = n.DescripcionEstatus;
                cbMantenimientoEstatusReclamo.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
            }
            btnConsultarEstatusReclamo.Visible = false;
            btnGuardarEstatusReclamo.Visible = false;
            btnModificarEstatusReclamo.Visible = true;
            btnRestablecerEstatusReclamo.Visible = true;
        }

        protected void cbBuscarFechaAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBuscarFechaAutomatico.Checked)
            {
                //VERIFICAMOS QUE EL CAMPO NUMERO DE RECLAMO NO ESTE VACIO
                if (string.IsNullOrEmpty(txtNumeroReclamacionMantenimiento.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "NumeroReclamoVacio", "NumeroReclamoVacio();", true);
                    cbBuscarFechaAutomatico.Checked = false;
                }
                else
                {
                    //VALIDAMOS EL NUMERO DE RECLAMO
                    string _NumeroReclamo = string.IsNullOrEmpty(txtNumeroReclamacionMantenimiento.Text.Trim()) ? null : txtNumeroReclamacionMantenimiento.Text.Trim();

                    var Validar = ObjData.Value.BuscaFechaReclamos(Convert.ToDecimal(_NumeroReclamo));
                    if (Validar.Count() < 1)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "NumeroReclamoNoValido", "NumeroReclamoNoValido();", true);
                        cbBuscarFechaAutomatico.Checked = false;
                    }
                    else
                    {
                        txtInicioVigenciaMantenimiento.Visible = false;
                        txtFechaInicioVigenciaAutomatico.Visible = true;
                        txtFinVigenciaMantenimiento.Visible = false;
                        txtFechaFinVigenciaAutomatico.Visible = true;
                        txtFechaAperturaMantenimiento.Visible = false;
                        txtFechaAperturaAutomatica.Visible = true;
                        txtFechaSiniestroMantenimiento.Visible = false;
                        txtFechaSiniestroAutomatica.Visible = true;
                        txtNumeroReclamacionMantenimiento.Enabled = false;

                        //SACAMOS LOS DATOS PARA REALIZAR LA OPERACIóN
                        foreach (var n in Validar)
                        {
                            txtFechaInicioVigenciaAutomatico.Text = n.InicioVigencia;
                            txtFechaFinVigenciaAutomatico.Text = n.FinVigencia;
                            txtFechaAperturaAutomatica.Text = n.FechaApertura;
                            txtFechaSiniestroAutomatica.Text = n.FechaSiniestro;
                            InicioVigencia = Convert.ToDateTime(n.InicioVigencia0);
                            Finvigencia = Convert.ToDateTime(n.FinVigencia0);
                            fechaApertura = Convert.ToDateTime(n.FechaApertura0);
                            FechaSiniestro = Convert.ToDateTime(n.FechaSiniestro0);
                        }
                    }
                }
            }
            else
            {
                txtInicioVigenciaMantenimiento.Visible = true;
                txtFechaInicioVigenciaAutomatico.Visible = false;
                txtFinVigenciaMantenimiento.Visible = true;
                txtFechaFinVigenciaAutomatico.Visible = false;
                txtFechaAperturaMantenimiento.Visible = true;
                txtFechaAperturaAutomatica.Visible = false;
                txtFechaSiniestroMantenimiento.Visible = true;
                txtFechaSiniestroAutomatica.Visible = false;
                txtNumeroReclamacionMantenimiento.Enabled = true;
            }
            
        }

        protected void btnGuardarMantenimiento_Click(object sender, EventArgs e)
        {
            MANReclamaciones(0, "INSERT");
            ConsultarRegistros();
            ClientScript.RegisterStartupScript(GetType(), "ModoConsulta", "ModoConsulta();", true);
        }
    }
}
 