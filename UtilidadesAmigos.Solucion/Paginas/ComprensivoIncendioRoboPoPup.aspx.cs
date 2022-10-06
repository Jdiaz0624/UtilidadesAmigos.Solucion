using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ComprensivoIncendioRoboPoPup : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaCotizador.LogicaCotizador> ObjDataCotizador = new Lazy<Logica.Logica.LogicaCotizador.LogicaCotizador>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataComun = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAMOS LAS LISTAS DESPLEGABLES PARA LAS CONSULTAS
        //LISTAS DESPLEGABLES PARA CONSULTAS
        private void CargarListasDesplegablesPadreConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoCotizadorConsulta, ObjDataComun.Value.BuscaListas("TIPOCOTIZADOR", null, null), true);
        }
        private void CargarListadoTipoCotizadorConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlValorVehiculoConsulta, ObjDataComun.Value.BuscaListas("VALORVEHICULO", ddlTipoCotizadorConsulta.SelectedValue, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlAnoVehiculoCOnsulta, ObjDataComun.Value.BuscaListas("ANOVEHICULO", ddlTipoCotizadorConsulta.SelectedValue, ddlValorVehiculoConsulta.SelectedValue), true);
        }
        private void CargarListadoAnoVehiculoConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlAnoVehiculoCOnsulta, ObjDataComun.Value.BuscaListas("ANOVEHICULO", ddlTipoCotizadorConsulta.SelectedValue, ddlValorVehiculoConsulta.SelectedValue), true);
        }

        //LISTAS DESPLEGABLES PARA MANTENIMIENTO
        private void CargarListaDesplegablePadreMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoCotizadorMantenimiento, ObjDataComun.Value.BuscaListas("TIPOCOTIZADOR", null, null));
        }
        private void CargarListadoTipoCotizadorMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlValorVehiculoMantenimiento, ObjDataComun.Value.BuscaListas("VALORVEHICULO", ddlTipoCotizadorMantenimiento.SelectedValue, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlAnoVehiculoMantenimiento, ObjDataComun.Value.BuscaListas("ANOVEHICULO", ddlTipoCotizadorMantenimiento.SelectedValue, ddlValorVehiculoMantenimiento.SelectedValue));
        }
        private void CargarListadoValorVehiculoMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlAnoVehiculoMantenimiento, ObjDataComun.Value.BuscaListas("ANOVEHICULO", ddlTipoCotizadorMantenimiento.SelectedValue, ddlValorVehiculoMantenimiento.SelectedValue));
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LA CONSULTA
        private void MostrarListadoConsulta()
        {
            //Declaramos las variables para aceptar valores nulo

            decimal? _TipoCotizador = ddlTipoCotizadorConsulta.SelectedValue != "-1" ? decimal.Parse(ddlTipoCotizadorConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _ValorVehiculo = ddlValorVehiculoConsulta.SelectedValue != "-1" ? decimal.Parse(ddlValorVehiculoConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _AnoVehiculo = ddlAnoVehiculoCOnsulta.SelectedValue != "-1" ? decimal.Parse(ddlAnoVehiculoCOnsulta.SelectedValue) : new Nullable<decimal>();
            string _ComprensivoIncendioRobo = string.IsNullOrEmpty(txtComprensivoIncendioRoboConsuta.Text.Trim()) ? null : txtComprensivoIncendioRoboConsuta.Text.Trim();

            var Buscar = ObjDataCotizador.Value.BuscaComprensivoIncendioRobo(
                _TipoCotizador,
                _ValorVehiculo,
                _AnoVehiculo,
                new Nullable<decimal>(),
                _ComprensivoIncendioRobo);
            gvListadoComprensivoIncendioRobo.DataSource = Buscar;
            gvListadoComprensivoIncendioRobo.DataBind();

            gvListadoComprensivoIncendioRobo.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoComprensivoIncendioRobo.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoComprensivoIncendioRobo.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoComprensivoIncendioRobo.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoComprensivoIncendioRobo.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoComprensivoIncendioRobo.Columns[5].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoComprensivoIncendioRobo.Columns[6].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }
        #endregion
        #region MOSTRAR Y OCULTAR CONTROLES
        private void OcultarControles()
        {
            // CONREOLES SUPERIORES
            lbTipoCotizadorConsulta.Visible = false;
            ddlTipoCotizadorConsulta.Visible = false;
            lbValorVehiculoConsulta.Visible = false;
            ddlValorVehiculoConsulta.Visible = false;
            lbAnoVehiculoConsulta.Visible = false;
            ddlAnoVehiculoCOnsulta.Visible = false;
            lbComprensivoIncendioRoboConsulta.Visible = false;
            txtComprensivoIncendioRoboConsuta.Visible = false;
            btnConsultar.Visible = false;
            btnNuevo.Visible = false;
            gvListadoComprensivoIncendioRobo.Visible = false;

            //CONTROLES INFERIORES
            lbAgregarEditar.Visible = true;
            lbTipoCotizadorMantenimiento.Visible = true;
            ddlTipoCotizadorMantenimiento.Visible = true;
            lbValorVehiculoMantenimiento.Visible = true;
            ddlValorVehiculoMantenimiento.Visible = true;
            lbAnoVehiculoMantenimiento.Visible = true;
            ddlAnoVehiculoMantenimiento.Visible = true;
            lbComprensivoIncendioRoboMantenimiento.Visible = true;
            txtCompresnvisoIncendioRobo.Visible = true;
            cbEstatusMantenimiento.Visible = true;
            btnGardar.Visible = true;
            btnAtras.Visible = true;
            txtCompresnvisoIncendioRobo.Text = string.Empty;

        }
        private void MostrarControles()
        {
            // CONREOLES SUPERIORES
            lbTipoCotizadorConsulta.Visible = true;
            ddlTipoCotizadorConsulta.Visible = true;
            lbValorVehiculoConsulta.Visible = true;
            ddlValorVehiculoConsulta.Visible = true;
            lbAnoVehiculoConsulta.Visible = true;
            ddlAnoVehiculoCOnsulta.Visible = true;
            lbComprensivoIncendioRoboConsulta.Visible = true;
            txtComprensivoIncendioRoboConsuta.Visible = true;
            btnConsultar.Visible = true;
            btnNuevo.Visible = true;
            gvListadoComprensivoIncendioRobo.Visible = true;

            //CONTROLES INFERIORES
            lbAgregarEditar.Visible = false;
            lbTipoCotizadorMantenimiento.Visible = false;
            ddlTipoCotizadorMantenimiento.Visible = false;
            lbValorVehiculoMantenimiento.Visible = false;
            ddlValorVehiculoMantenimiento.Visible = false;
            lbAnoVehiculoMantenimiento.Visible = false;
            ddlAnoVehiculoMantenimiento.Visible = false;
            lbComprensivoIncendioRoboMantenimiento.Visible = false;
            txtCompresnvisoIncendioRobo.Visible = false;
            cbEstatusMantenimiento.Visible = false;
            btnGardar.Visible = false;
            btnAtras.Visible = false;

            //CARGAMOS LOS MENUS DESPLEGABLES
            CargarListasDesplegablesPadreConsulta();
            CargarListadoTipoCotizadorConsulta();

            //LIMPIAMOS LOS CONTROLES
            txtComprensivoIncendioRoboConsuta.Text = string.Empty;

            MostrarListadoConsulta();
        }
        #endregion
        #region MANTENIMIENTO DE COMPRENSIVO INCENDIO Y ROBO
        private void MANComprensivoIncendioRobo(decimal IdComprensivoIncendioRobo, string Accion)
        {
            UtilidadesAmigos.Logica.Entidades.Cotizador.EComprensivoIncendioRobo Mantenimiento = new Logica.Entidades.Cotizador.EComprensivoIncendioRobo();

            if (string.IsNullOrEmpty(txtCompresnvisoIncendioRobo.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No puedes dejar campos vacios para proceder con esta operación')", true);
            }
            else
            {
                Mantenimiento.IdTipoCotizador = Convert.ToDecimal(ddlTipoCotizadorMantenimiento.SelectedValue);
                Mantenimiento.IdValorVehiculo = Convert.ToDecimal(ddlValorVehiculoMantenimiento.SelectedValue);
                Mantenimiento.IdAnoVehiculo = Convert.ToDecimal(ddlAnoVehiculoMantenimiento.SelectedValue);
                Mantenimiento.IdComprensivoIncendioRobo = IdComprensivoIncendioRobo;
                Mantenimiento.ComprensivoIncendioRobo = txtCompresnvisoIncendioRobo.Text;
                Mantenimiento.Estatus0 = cbEstatusMantenimiento.Checked;

                var MAN = ObjDataCotizador.Value.MantenimientoComprensivoIncendioRobo(Mantenimiento, Accion);
            }

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListasDesplegablesPadreConsulta();
                CargarListadoTipoCotizadorConsulta();
                MostrarListadoConsulta();
      
            }
        }

        protected void gvListadoComprensivoIncendioRobo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoComprensivoIncendioRobo.PageIndex = e.NewPageIndex;
            MostrarListadoConsulta();
        }

        protected void gvListadoComprensivoIncendioRobo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gv = gvListadoComprensivoIncendioRobo.SelectedRow;
            CargarListaDesplegablePadreMantenimiento();
            CargarListadoTipoCotizadorMantenimiento();
            OcultarControles();
            var SacarDatos = ObjDataCotizador.Value.BuscaComprensivoIncendioRobo(
                null,
                null,
                null,
                Convert.ToDecimal(gv.Cells[1].Text),
                null);
            foreach (var n in SacarDatos)
            {
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlTipoCotizadorMantenimiento, n.IdTipoCotizador.ToString());
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlValorVehiculoMantenimiento, n.IdValorVehiculo.ToString());
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlAnoVehiculoMantenimiento, n.IdAnoVehiculo.ToString());
                txtCompresnvisoIncendioRobo.Text = n.ComprensivoIncendioRobo;
                cbEstatusMantenimiento.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);

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
                lbIdMantenimiento.Text = gv.Cells[1].Text;
                lbAccion.Text = "UPDATE";
            }
            lbAgregarEditar.Text = "Modificar Registro";
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoConsulta();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            OcultarControles();
            lbIdMantenimiento.Text = "0";
            lbAccion.Text = "INSERT";
            CargarListaDesplegablePadreMantenimiento();
            CargarListadoTipoCotizadorMantenimiento();
            lbAgregarEditar.Text = "Nuevo Registro";
            cbEstatusMantenimiento.Checked = true;
            cbEstatusMantenimiento.Visible = false;
        }

        protected void btnGardar_Click(object sender, EventArgs e)
        {
            MANComprensivoIncendioRobo(Convert.ToDecimal(lbIdMantenimiento.Text), lbAccion.Text);
            MostrarControles();
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            MANComprensivoIncendioRobo(Convert.ToDecimal(lbIdMantenimiento.Text), "DISABLE");
            MostrarControles();
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            MostrarControles();
        }

        protected void ddlTipoCotizadorConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListadoTipoCotizadorConsulta();
        }

        protected void ddlValorVehiculoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListadoAnoVehiculoConsulta();
        }

        protected void ddlTipoCotizadorMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListadoTipoCotizadorMantenimiento();
        }

        protected void ddlValorVehiculoMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListadoValorVehiculoMantenimiento();
        }
    }
}