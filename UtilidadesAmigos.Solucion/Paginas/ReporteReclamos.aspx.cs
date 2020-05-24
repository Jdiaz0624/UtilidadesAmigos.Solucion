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
                MANEstatusReclamo("UPDATE");
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

        }

        protected void btnEliminarMantenimiento_Click(object sender, EventArgs e)
        {

        }

        protected void gvListadoReclamos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
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
 