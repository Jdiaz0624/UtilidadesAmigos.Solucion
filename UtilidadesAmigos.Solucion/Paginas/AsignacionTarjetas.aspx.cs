using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class AsignacionTarjetas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAR LAS LISTAS DESPLEGABLES
        //CARGAMOS LAS LISTAS PARA LAS CONSULTAS
        private void CargarListasPadreConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaConsulta, ObjData.Value.BuscaListas("OFICINA", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlOficinaConsulta.SelectedValue, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoConsulta, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaConsulta.SelectedValue, ddlDepartamentoConsulta.SelectedValue), true);
        }
        //
        private void CargarDepartamentosConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlOficinaConsulta.SelectedValue, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoConsulta, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaConsulta.SelectedValue, ddlDepartamentoConsulta.SelectedValue), true);
        }
        private void CargarEmpleadosConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoConsulta, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaConsulta.SelectedValue, ddlDepartamentoConsulta.SelectedValue), true);
        }

        //CARGAR LAS LISTAS PARA EL MANTENIMIENTO
        private void CargarListasPadreMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjData.Value.BuscaListas("OFICINA", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoMantenimiento, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlOficinaMantenimiento.SelectedValue, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoMantenimiento, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaMantenimiento.SelectedValue, ddlDepartamentoMantenimiento.SelectedValue));
        }
        private void CargarDepartamentosMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoMantenimiento, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlOficinaMantenimiento.SelectedValue, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoMantenimiento, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaMantenimiento.SelectedValue, ddlDepartamentoMantenimiento.SelectedValue));
        }
        private void CargarEmpleadosMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoMantenimiento, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaMantenimiento.SelectedValue, ddlDepartamentoMantenimiento.SelectedValue));
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LAS TARJETAS DE ACCESO
        private void MostrarListadotarjetas()
        {
            try {
                decimal? _Oficina = ddlOficinaConsulta.SelectedValue != "-1" ? decimal.Parse(ddlOficinaConsulta.SelectedValue) : new Nullable<decimal>();
                decimal? _Departamento = ddlDepartamentoConsulta.SelectedValue != "-1" ? decimal.Parse(ddlDepartamentoConsulta.SelectedValue) : new Nullable<decimal>();
                decimal? _Empleado = ddlEmpleadoConsulta.SelectedValue != "-1" ? decimal.Parse(ddlEmpleadoConsulta.SelectedValue) : new Nullable<decimal>();
                string _Numerotarjeta = string.IsNullOrEmpty(txtNumerotarjetaConsulta.Text.Trim()) ? null : txtNumerotarjetaConsulta.Text.Trim();

                if (cbFiltrarPorRangoFechaConsulta.Checked)
                {
                    var Buscar = ObjData.Value.BuscarTarjetaAcceso(
                        _Oficina,
                        _Departamento,
                        _Empleado,
                        new Nullable<decimal>(),
                        _Numerotarjeta,
                        null,
                        Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                        Convert.ToDateTime(txtFechaHastaConsulta.Text));
                    gvTarjetaAcceso.DataSource = Buscar;
                    gvTarjetaAcceso.DataBind();
                    OcultarColumnas();
                }
                else
                {
                    var Buscar = ObjData.Value.BuscarTarjetaAcceso(
                        _Oficina,
                        _Departamento,
                        _Empleado,
                        new Nullable<decimal>(),
                        _Numerotarjeta,
                        null,
                        null,
                        null);
                    gvTarjetaAcceso.DataSource = Buscar;
                    gvTarjetaAcceso.DataBind();
                    OcultarColumnas();
                }
            }
            catch (Exception) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error al hacer la consulta, favor de verificar los parametros espesificados, o contactar a Tecnologia')", true);
            }
        }
        private void OcultarColumnas()
        {
            gvTarjetaAcceso.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvTarjetaAcceso.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvTarjetaAcceso.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvTarjetaAcceso.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvTarjetaAcceso.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvTarjetaAcceso.Columns[5].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvTarjetaAcceso.Columns[6].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvTarjetaAcceso.Columns[7].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvTarjetaAcceso.Columns[8].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }
        #endregion
        #region MOSTRAR Y OCULTAR COLUMNAS
        private void OcultarControles()
        {
            //CONTROLES SUPERIORES
            lbOficinaConsulta.Visible = false;
            ddlOficinaConsulta.Visible = false;
            lbDepartamentoConsulta.Visible = false;
            ddlDepartamentoConsulta.Visible = false;
            lbEmpleadoConsulta.Visible = false;
            ddlEmpleadoConsulta.Visible = false;
            lbNumeroTarjetaConsulta.Visible = false;
            txtNumerotarjetaConsulta.Visible = false;
            cbFiltrarPorRangoFechaConsulta.Visible = false;
            txtFechaDesdeConsulta.Visible = false;
            txtFechaHastaConsulta.Visible = false;
            lbFechaDesdeConsulta.Visible = false;
            lbFechaHastaConsulta.Visible = false;
            btnConsultar.Visible = false;
           btnNuevo.Visible = false;
            btnAtras.Visible = false;
            btnModificar.Visible = false;
            btnDeshabilitar.Visible = false;
            btnExportar.Visible = false;
           gvTarjetaAcceso.Visible = false;


            //CONTROLES INFERIORES
            lbOficinaMantenimiento.Visible = true;
            ddlOficinaMantenimiento.Visible = true;
            lbDepartamentoMantenimiento.Visible = true;
            ddlDepartamentoMantenimiento.Visible = true;
            lbEmpleadoMantenimiento.Visible = true;
            ddlEmpleadoMantenimiento.Visible = true;
            lbNumeroTarjetraMantenimiento.Visible = true;
            txtNumerotarjetaMantenimiento.Visible = true;
            cbEstatusMantenimiento.Visible = true;
            lbFechaEntregaMantenimiento.Visible = true;
            txtFechaEntregaMantenimiento.Visible = true;
            btnGuardarMantenimiento.Visible = true;
            btnAtrasMantenimiento.Visible = true;
            lbMantenimientoTarjetasAcceso.Visible = true;
            CargarListasPadreMantenimiento();
        }
        private void MostrarControles()
        {
            //CONTROLES SUPERIORES
            lbOficinaConsulta.Visible = true;
            ddlOficinaConsulta.Visible = true;
            lbDepartamentoConsulta.Visible = true;
            ddlDepartamentoConsulta.Visible = true;
            lbEmpleadoConsulta.Visible = true;
            ddlEmpleadoConsulta.Visible = true;
            lbNumeroTarjetaConsulta.Visible = true;
            txtNumerotarjetaConsulta.Visible = true;
            cbFiltrarPorRangoFechaConsulta.Visible = true;
            txtFechaDesdeConsulta.Visible = true;
            txtFechaHastaConsulta.Visible = true;
            lbFechaDesdeConsulta.Visible = true;
            lbFechaHastaConsulta.Visible = true;
            btnConsultar.Visible = true;
            btnNuevo.Visible = true;
            btnAtras.Visible = true;
            btnModificar.Visible = true;
            btnDeshabilitar.Visible = true;
            btnExportar.Visible = true;
            gvTarjetaAcceso.Visible = true;


            //CONTROLES INFERIORES
            lbOficinaMantenimiento.Visible = false;
            ddlOficinaMantenimiento.Visible = false;
            lbDepartamentoMantenimiento.Visible = false;
            ddlDepartamentoMantenimiento.Visible = false;
            lbEmpleadoMantenimiento.Visible = false;
            ddlEmpleadoMantenimiento.Visible = false;
            lbNumeroTarjetraMantenimiento.Visible = false;
            txtNumerotarjetaMantenimiento.Visible = false;
            cbEstatusMantenimiento.Visible = false;
            txtFechaEntregaMantenimiento.Visible = false;
            btnGuardarMantenimiento.Visible = false;
            btnAtrasMantenimiento.Visible = false;
            lbMantenimientoTarjetasAcceso.Visible = false;
            txtNumerotarjetaMantenimiento.Text = string.Empty;
            cbEstatusMantenimiento.Checked = false;
            lbFechaEntregaMantenimiento.Visible = false;
            txtFechaEntregaMantenimiento.Text = string.Empty;
            CargarListasPadreConsulta();
            txtNumerotarjetaConsulta.Text = string.Empty;
            cbFiltrarPorRangoFechaConsulta.Checked = false;
            txtFechaDesdeConsulta.Text = string.Empty;
            txtFechaHastaConsulta.Text = string.Empty;
            MostrarListadotarjetas();

        }
        #endregion
        #region MANTENIMIENTO DE TARJETAS DE ACCESO

        #region VOLVER ATRAS
        private void VolverAtras()
        {
            btnConsultar.Enabled = true;
            btnNuevo.Enabled = true;
            btnAtras.Enabled = false;
            btnModificar.Enabled = false;
            btnDeshabilitar.Enabled = false;
            btnExportar.Enabled = true;
        }
#endregion
        private void MANTarjetasAccesos(decimal? IdMantenimiento, string Accion)
        {
            try {
                if (Accion != "INSERT")
                {
                    DateTime Fecha = DateTime.Now;
                    UtilidadesAmigos.Logica.Entidades.ETarjetaAcceso Mantenimiento = new Logica.Entidades.ETarjetaAcceso();

                    Mantenimiento.IdOficina = Convert.ToDecimal(ddlOficinaMantenimiento.SelectedValue);
                    Mantenimiento.IdDepartamento = Convert.ToDecimal(ddlDepartamentoMantenimiento.SelectedValue);
                    Mantenimiento.IdEmpleado = Convert.ToDecimal(ddlEmpleadoMantenimiento.SelectedValue);
                    Mantenimiento.IdTarjetaAcceso = IdMantenimiento;
                    Mantenimiento.SecuenciaInterna0 = 0;
                    Mantenimiento.NumeroTarjeta = txtNumerotarjetaMantenimiento.Text;
                    Mantenimiento.FechaEntrega0 = Fecha;
                    Mantenimiento.Estatus0 = cbEstatusMantenimiento.Checked;
                    Mantenimiento.UsuarioAdiciona = Convert.ToDecimal(Session["IdUsuario"].ToString());
                    Mantenimiento.FechaAdiciona = DateTime.Now;
                    Mantenimiento.UsuarioModicia = Convert.ToDecimal(Session["IdUsuario"].ToString());
                    Mantenimiento.FechaModifica = DateTime.Now;

                    var MAN = ObjData.Value.MantenimientoTarjetaAcceso(Mantenimiento, Accion);
                }
                else
                {
                    UtilidadesAmigos.Logica.Entidades.ETarjetaAcceso Mantenimiento = new Logica.Entidades.ETarjetaAcceso();

                    Mantenimiento.IdOficina = Convert.ToDecimal(ddlOficinaMantenimiento.SelectedValue);
                    Mantenimiento.IdDepartamento = Convert.ToDecimal(ddlDepartamentoMantenimiento.SelectedValue);
                    Mantenimiento.IdEmpleado = Convert.ToDecimal(ddlEmpleadoMantenimiento.SelectedValue);
                    Mantenimiento.IdTarjetaAcceso = IdMantenimiento;
                    Mantenimiento.SecuenciaInterna0 = 0;
                    Mantenimiento.NumeroTarjeta = txtNumerotarjetaMantenimiento.Text;
                    Mantenimiento.FechaEntrega0 = Convert.ToDateTime(txtFechaEntregaMantenimiento.Text);
                    Mantenimiento.Estatus0 = cbEstatusMantenimiento.Checked;
                    Mantenimiento.UsuarioAdiciona = Convert.ToDecimal(Session["IdUsuario"].ToString());
                    Mantenimiento.FechaAdiciona = DateTime.Now;
                    Mantenimiento.UsuarioModicia = Convert.ToDecimal(Session["IdUsuario"].ToString());
                    Mantenimiento.FechaModifica = DateTime.Now;

                    var MAN = ObjData.Value.MantenimientoTarjetaAcceso(Mantenimiento, Accion);
                }
            }
            catch (Exception) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error al procesar el mantenimiento')", true);
            }
           

        }
#endregion


        protected void Page_Load(object sender, EventArgs e)
        {
          
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                CargarListasPadreConsulta();
                MostrarListadotarjetas();
            }

        }

        protected void cbAgregarDeparpamento_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void cbAgregarOficina_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        protected void cbAgregarUsuario_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        protected void ddlOficinaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        protected void ddlDepartamentoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlDepartamentoMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        protected void ddlOficinaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        protected void txtNoTarjetaMantenimiento_TextChanged(object sender, EventArgs e)
        {

        }


        protected void GVListadoTarjetas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
         
        }

        protected void GVListadoTarjetas_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnExportarExel_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
         
        }

        protected void txtClaveSeguridad_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnProcesarMantenimiento_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
           
        }

        protected void ddlSeleccionarusuarioCOnsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlUsuarioMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardarMantenimiento_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumerotarjetaMantenimiento.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El campo numero de tarjeta de acceso no puede estar vacio, favor de verificar')", true);
            }
            else
            {
                MANTarjetasAccesos(Convert.ToDecimal(lbIdMantenimiento.Text), lbAccion.Text);
                MostrarControles();
                VolverAtras();
            }
        }

        protected void btnAtrasMantenimiento_Click(object sender, EventArgs e)
        {
            MostrarControles();
            VolverAtras();
        }

        protected void gvTarjetaAcceso_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTarjetaAcceso.PageIndex = e.NewPageIndex;
            MostrarListadotarjetas();
        }

        protected void gvTarjetaAcceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SELECCIONAMOS EL REGISTRO
            GridViewRow gv = gvTarjetaAcceso.SelectedRow;
            lbIdMantenimiento.Text = gv.Cells[1].Text;

            //BUSCAMOS LOS DATOS MEDIANTE EL REGISTRO SELECCIONADO
            var Buscar = ObjData.Value.BuscarTarjetaAcceso(
                null, null, null,
                Convert.ToDecimal(gv.Cells[1].Text),
                null, null, null, null);
            gvTarjetaAcceso.DataSource = Buscar;
            gvTarjetaAcceso.DataBind();
            OcultarColumnas();
            btnConsultar.Enabled = false;
            btnNuevo.Enabled = false;
            btnAtras.Enabled = true;
            btnModificar.Enabled = true;
            btnDeshabilitar.Enabled = true;
            btnExportar.Enabled = false;

        }

        protected void ddlOficinaConsulta_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CargarDepartamentosConsulta();
        }

        protected void ddlDepartamentoConsulta_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CargarEmpleadosConsulta();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadotarjetas();
        }

        protected void btnAtras_Click1(object sender, EventArgs e)
        {
            MostrarControles();
            VolverAtras();
        }

        protected void btnNuevo_Click1(object sender, EventArgs e)
        {
            OcultarControles();
            lbIdMantenimiento.Text = "0";
            lbAccion.Text = "INSERT";
            cbEstatusMantenimiento.Checked = true;
            cbEstatusMantenimiento.Visible = false;
        }

        protected void ddlOficinaMantenimiento_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CargarDepartamentosMantenimiento();
        }

        protected void ddlDepartamentoMantenimiento_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CargarEmpleadosMantenimiento();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            try {
                //EXPORTAMOS LA CONSULTA 
                decimal? _oficina = ddlOficinaConsulta.SelectedValue != "-1" ? decimal.Parse(ddlOficinaConsulta.SelectedValue) : new Nullable<decimal>();
                decimal? _Departamento = ddlDepartamentoConsulta.SelectedValue != "-1" ? decimal.Parse(ddlDepartamentoConsulta.SelectedValue) : new Nullable<decimal>();
                decimal? _Empleado = ddlEmpleadoConsulta.SelectedValue != "-1" ? decimal.Parse(ddlEmpleadoConsulta.SelectedValue) : new Nullable<decimal>();
                string _Numerotarjeta = string.IsNullOrEmpty(txtNumerotarjetaConsulta.Text.Trim()) ? null : txtNumerotarjetaConsulta.Text.Trim();

                if (cbEstatusMantenimiento.Checked)
                {
                    //EXPORTAMOS FILTRANDO CON RANGO DE FECHA
                    var Buscar = (from n in ObjData.Value.BuscarTarjetaAcceso(
                        _oficina,
                        _Departamento,
                        _Empleado,
                        new Nullable<decimal>(),
                        _Numerotarjeta,
                        null,
                        Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                        Convert.ToDateTime(txtFechaHastaConsulta.Text))
                                  select new
                                  {
                                      Oficina = n.Oficina,
                                      Departamento = n.Departamento,
                                      Empleado = n.Empleado,
                                      SecuenciaInterna = n.SecuenciaInterna,
                                      Numerotarjeta = n.NumeroTarjeta,
                                      Estatus = n.Estatus,
                                      FechaEntrega = n.FechaEntrega0,
                                      CreadoPor = n.CreadoPor,
                                      FechaCreado = n.FechaAdiciona,
                                      ModificadoPor = n.ModificadoPor,
                                      FechaModificado = n.FechaModifica
                                  }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Tarjetas de Acceso", Buscar);
                }
                else
                {
                    //EXPORTAMOS SIN FILTRAR POR RANGO DE FECHA
                    var Buscar = (from n in ObjData.Value.BuscarTarjetaAcceso(
                      _oficina,
                      _Departamento,
                      _Empleado,
                      new Nullable<decimal>(),
                      _Numerotarjeta,
                      null,
                      null,
                      null)
                                  select new
                                  {
                                      Oficina = n.Oficina,
                                      Departamento = n.Departamento,
                                      Empleado = n.Empleado,
                                      SecuenciaInterna = n.SecuenciaInterna,
                                      Numerotarjeta = n.NumeroTarjeta,
                                      Estatus = n.Estatus,
                                      FechaEntrega = n.FechaEntrega0,
                                      CreadoPor = n.CreadoPor,
                                      FechaCreado = n.FechaAdiciona,
                                      ModificadoPor = n.ModificadoPor,
                                      FechaModificado = n.FechaModifica
                                  }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Tarjetas de Acceso", Buscar);
                }
            }
            catch (Exception) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error al exportar la data a exel')", true);
            }
        }

        protected void btnModificar_Click1(object sender, EventArgs e)
       {
            OcultarControles();
            lbAccion.Text = "UPDATE";
            //SACAMOS LOS DATOS DEL REGISTRO SELECCIONADO
            var SacarInformacion = ObjData.Value.BuscarTarjetaAcceso(
                null,
                null,
                null,
                Convert.ToDecimal(lbIdMantenimiento.Text),
                null, null, null, null);
            foreach (var n in SacarInformacion)
            {
                CargarListasPadreMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlOficinaMantenimiento, n.IdOficina.ToString());
                CargarDepartamentosMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlDepartamentoMantenimiento, n.IdDepartamento.ToString());
                CargarEmpleadosMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlEmpleadoMantenimiento, n.IdEmpleado.ToString());
                txtNumerotarjetaMantenimiento.Text = n.NumeroTarjeta;
                cbEstatusMantenimiento.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
                lbFechaEntregaMantenimiento.Visible = false;
                txtFechaEntregaMantenimiento.Visible = false;
            }
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            MANTarjetasAccesos(Convert.ToDecimal(lbIdMantenimiento.Text), "DISABLE");
            MostrarControles();
        }
    }
}