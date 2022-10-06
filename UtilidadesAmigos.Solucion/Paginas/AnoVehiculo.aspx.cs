using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class AnoVehiculo : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataComun = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaCotizador.LogicaCotizador> ObjdataCotizador = new Lazy<Logica.Logica.LogicaCotizador.LogicaCotizador>();



        #region MOSTRAR EL LISTADO DE LOS AÑOS DE LOS VEHICULOS
        private void MostrarListadoAnoVehiculo()
        {
            decimal? _TipoCotizador = ddlTipoCotizadorCnsulta.SelectedValue != "-1" ? decimal.Parse(ddlTipoCotizadorCnsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _ValorVehiculo = ddlValorVehiculoCOnsulta.SelectedValue != "-1" ? decimal.Parse(ddlValorVehiculoCOnsulta.SelectedValue) : new Nullable<decimal>();
            string _AnoVehiculo = string.IsNullOrEmpty(txtAnoVehiculoConsulta.Text.Trim()) ? null : txtAnoVehiculoConsulta.Text.Trim();

            var Buscar = ObjdataCotizador.Value.BuscaAnoVehiculo(
                _TipoCotizador,
                _ValorVehiculo,
                new Nullable<decimal>(),
                _AnoVehiculo);
            gvListadoAnoVehiculo.DataSource = Buscar;
            gvListadoAnoVehiculo.DataBind();
            //gvListado.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoAnoVehiculo.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoAnoVehiculo.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoAnoVehiculo.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoAnoVehiculo.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoAnoVehiculo.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoAnoVehiculo.Columns[5].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }
        #endregion

        #region OCULTAR Y MOSTRAR LOS CONTROLES
        private void OcultarControles()
        {
            //CONTROLES SUPERIORES
            lbTipoCotizadorConsulta.Visible = false;
            ddlTipoCotizadorCnsulta.Visible = false;
            lbValorVehiculoConsulta.Visible = false;
            ddlValorVehiculoCOnsulta.Visible = false;
            lbAnoVehiculoConsulta.Visible = false;
            txtAnoVehiculoConsulta.Visible = false;
            btnConsultar.Visible = false;
            btnNuevo.Visible = false;
            gvListadoAnoVehiculo.Visible = false;

            //CONTROLES INFERIORES
            lbAgregarEditar.Visible = true;
            lbTipoCotizadorMantenimiento.Visible = true;
            ddlTipoCotizadorMantenimiento.Visible = true;
            lbValorVehiculoMantenimiento.Visible = true;
            ddlValorVehiculoMantenimiento.Visible = true;
            lbAnoVehiculoMantenimiento.Visible = true;
            txtAnoVehiculoMantenimiento.Visible = true;
            cbEstatusMantenimiento.Visible = true;
            btnGuardarMantenimiento.Visible = true;
            btnAtras.Visible = true;
            
        }
        private void MostrarControles()
        {
            //CONTROLES SUPERIORES
            lbTipoCotizadorConsulta.Visible = true;
            ddlTipoCotizadorCnsulta.Visible = true;
            lbValorVehiculoConsulta.Visible = true;
            ddlValorVehiculoCOnsulta.Visible = true;
            lbAnoVehiculoConsulta.Visible = true;
            txtAnoVehiculoConsulta.Visible = true;
            btnConsultar.Visible = true;
            btnNuevo.Visible = true;
            gvListadoAnoVehiculo.Visible = true;

            //CONTROLES INFERIORES
            lbAgregarEditar.Visible = false;
            lbTipoCotizadorMantenimiento.Visible = false;
            ddlTipoCotizadorMantenimiento.Visible = false;
            lbValorVehiculoMantenimiento.Visible = false;
            ddlValorVehiculoMantenimiento.Visible = false;
            lbAnoVehiculoMantenimiento.Visible = false;
            txtAnoVehiculoMantenimiento.Visible = false;
            cbEstatusMantenimiento.Visible = false;
            btnGuardarMantenimiento.Visible = false;
            btnAtras.Visible = false;

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoCotizadorCnsulta, ObjDataComun.Value.BuscaListas("TIPOCOTIZADOR", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlValorVehiculoCOnsulta, ObjDataComun.Value.BuscaListas("VALORVEHICULO", ddlTipoCotizadorCnsulta.SelectedValue.ToString(), null), true);

            txtAnoVehiculoConsulta.Text = string.Empty;
            MostrarListadoAnoVehiculo();
            btnDeshabilitar.Visible = false;
            txtAnoVehiculoMantenimiento.Text = string.Empty;
            cbEstatusMantenimiento.Checked = false;
        }
        #endregion

        #region MANTENIMIENTO DE AÑO DE VEHICULO
        private void MANAnoVehiculo(decimal IdMantenimiento, string Accion)
        {
            if (string.IsNullOrEmpty(txtAnoVehiculoMantenimiento.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No puedes dejar el campo año de vehiculo vacio para realizar esta operación')", true);
            }
            else
            {
                UtilidadesAmigos.Logica.Entidades.Cotizador.EAnoVehiculo Mantenimiento = new Logica.Entidades.Cotizador.EAnoVehiculo();

                Mantenimiento.IdTipoCotizador = Convert.ToDecimal(ddlTipoCotizadorMantenimiento.SelectedValue);
                Mantenimiento.IdValorVehiculo = Convert.ToDecimal(ddlValorVehiculoMantenimiento.SelectedValue);
                Mantenimiento.IdAnoVehiculo = IdMantenimiento;
                Mantenimiento.AnoVehiculo = txtAnoVehiculoMantenimiento.Text;
                Mantenimiento.Estatus0 = cbEstatusMantenimiento.Checked;

                var MAN = ObjdataCotizador.Value.MantenimientoAnoVehiculo(Mantenimiento, Accion);
            }
           
        }
#endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CARGAMOS LOS TIPOS DE COTIZADORES
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoCotizadorCnsulta, ObjDataComun.Value.BuscaListas("TIPOCOTIZADOR", null, null), true);

                //CARGAR LOS VALORES DE LOS VEHICULOS
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlValorVehiculoCOnsulta, ObjDataComun.Value.BuscaListas("VALORVEHICULO", ddlTipoCotizadorCnsulta.SelectedValue.ToString(), null), true);

                //MOSTRAMOS EL LISTADO
                MostrarListadoAnoVehiculo();

            }
        }

        protected void gvListadoAnoVehiculo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoAnoVehiculo.PageIndex = e.NewPageIndex;
            MostrarListadoAnoVehiculo();
        }

        protected void gvListadoAnoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gv = gvListadoAnoVehiculo.SelectedRow;

            OcultarControles();
            lbIdMantenimiento.Text = gv.Cells[1].Text;
            lbAccion.Text = "UPDATE";
            var Buscar = ObjdataCotizador.Value.BuscaAnoVehiculo(
                null, null,
                Convert.ToDecimal(gv.Cells[1].Text),
                null);
            foreach (var n in Buscar)
            {
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoCotizadorMantenimiento, ObjDataComun.Value.BuscaListas("TIPOCOTIZADOR", null, null));
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlTipoCotizadorMantenimiento, n.IdTipoCotizador.ToString());
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlValorVehiculoMantenimiento, ObjDataComun.Value.BuscaListas("VALORVEHICULO", ddlTipoCotizadorMantenimiento.SelectedValue.ToString(), null));
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlValorVehiculoMantenimiento, n.IdValorVehiculo.ToString());
                txtAnoVehiculoMantenimiento.Text = n.AnoVehiculo;
                cbEstatusMantenimiento.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
            }
       
            if (cbEstatusMantenimiento.Checked == true)
            {
                cbEstatusMantenimiento.Visible = false;
                btnDeshabilitar.Visible = true;
            }
            else
            {
                cbEstatusMantenimiento.Visible = true;
                btnDeshabilitar.Visible = false;
            }
            
            
        }

        protected void ddlTipoCotizadorCnsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlValorVehiculoCOnsulta, ObjDataComun.Value.BuscaListas("VALORVEHICULO", ddlTipoCotizadorCnsulta.SelectedValue.ToString(), null), true);
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoAnoVehiculo();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            OcultarControles();
            lbAgregarEditar.Text = "Nuevo Registro";
            lbAccion.Text = "INSERT";
            lbIdMantenimiento.Text = "0";
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoCotizadorMantenimiento, ObjDataComun.Value.BuscaListas("TIPOCOTIZADOR", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlValorVehiculoMantenimiento, ObjDataComun.Value.BuscaListas("VALORVEHICULO", ddlTipoCotizadorMantenimiento.SelectedValue.ToString(), null));
            cbEstatusMantenimiento.Checked = true;
            cbEstatusMantenimiento.Visible = false;
        }

        protected void btnGuardarMantenimiento_Click(object sender, EventArgs e)
        {
            MANAnoVehiculo(Convert.ToDecimal(lbIdMantenimiento.Text), lbAccion.Text);
            MostrarControles();
        }

        protected void ddlTipoCotizadorMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlValorVehiculoMantenimiento, ObjDataComun.Value.BuscaListas("VALORVEHICULO", ddlTipoCotizadorMantenimiento.SelectedValue.ToString(), null));
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            MostrarControles();
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            MANAnoVehiculo(Convert.ToDecimal(lbIdMantenimiento.Text),"DISABLE");
            MostrarControles();
        }
    }
}