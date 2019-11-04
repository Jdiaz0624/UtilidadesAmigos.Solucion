using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ValorVehiculo : System.Web.UI.Page
    {
        UtilidadesAmigos.Logica.Logica.LogicaSistema Objdata = new Logica.Logica.LogicaSistema();
        UtilidadesAmigos.Logica.Logica.LogicaCotizador.LogicaCotizador ObjdataCotizador = new Logica.Logica.LogicaCotizador.LogicaCotizador();
        //public override void VerifyRenderingInServerForm(Control control)
        //{
        //    /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
        //       server control at run time. */
        //}
        #region CARGAR EL TIPO DE COTIZADOR
        private void CargarTipoCotizador()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoCotizadorConsulta, Objdata.BuscaListas("TIPOCOTIZADOR", null, null), true);
        }
        #endregion
        #region REGION CARGAR EL TIPO DE COTIZADOR PARA EL MANTENIMIENTO
        private void CargarTipoCotizadorManteniiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoCotizadorMantenimiento, Objdata.BuscaListas("TIPOCOTIZADOR", null, null));
        }
#endregion
        #region MOSTRAR EL LISTADO DE LOS VALORES DE LOS VEHICULOS
        private void MostrarListadoValorVehiculo()
        {
            string _Valor = string.IsNullOrEmpty(txtValorVehiculoConsulta.Text.Trim()) ? null : txtValorVehiculoConsulta.Text.Trim();
            decimal? TipoCotizador = ddlTipoCotizadorConsulta.SelectedValue != "-1" ? decimal.Parse(ddlTipoCotizadorConsulta.SelectedValue) : new Nullable<decimal>();

            var Buscar = ObjdataCotizador.BuscaValorVehiculo(
                TipoCotizador,
                null,
                _Valor);
            gvListado.DataSource = Buscar;
            gvListado.DataBind();
            gvListado.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListado.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListado.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListado.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListado.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }
        #endregion
        #region MOSTRAR Y OCULTAR CONTROLES
        private void OcultarControles()
        {
            //CONTROLES SUPERIORES
            lbTipoCotizadorConsulta.Visible = false;
            ddlTipoCotizadorConsulta.Visible = false;
            lbValorVehiculoConsulta.Visible = false;
            txtValorVehiculoConsulta.Visible = false;
            btnConsultar.Visible = false;
            btnNuevo.Visible = false;
            gvListado.Visible = false;
            //CONTROLES INFERIORES
            lbAgregarEditar.Visible = true;
            lbTipoCotizadorMantenimiento.Visible = true;
            ddlTipoCotizadorMantenimiento.Visible = true;
            lbValorVehiculoMantenimiento.Visible = true;
            txtValorVehiculoMantenimiento.Visible = true;
            cbEstatus.Visible = true;
            btnGuardarMantenimiento.Visible = true;
           // btnDeshabilitar.Visible = true;
            btnAtras.Visible = true;

        }
        private void MostrarControles()
        {
            //CONTROLES SUPERIORES
            lbTipoCotizadorConsulta.Visible = true;
            ddlTipoCotizadorConsulta.Visible = true;
            lbValorVehiculoConsulta.Visible = true;
            txtValorVehiculoConsulta.Visible = true;
            btnConsultar.Visible = true;
            btnNuevo.Visible = true;
            gvListado.Visible = true;
            //CONTROLES INFERIORES
            lbAgregarEditar.Visible = true;
            lbTipoCotizadorMantenimiento.Visible = false;
            ddlTipoCotizadorMantenimiento.Visible = false;
            lbValorVehiculoMantenimiento.Visible = false;
            txtValorVehiculoMantenimiento.Visible = false;
            cbEstatus.Visible = false;
            btnGuardarMantenimiento.Visible = false;
            btnDeshabilitar.Visible = false;
            btnAtras.Visible = false;
            txtValorVehiculoMantenimiento.Text = string.Empty;
            lbAgregarEditar.Visible = false;
        }
        #endregion
        #region MANTENIMIENTO DE VALOR DE VEHICULO
        private void MANValorVehiculo(decimal IdMantenimiento, string Accion)
        {
            if (string.IsNullOrEmpty(txtValorVehiculoMantenimiento.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No puedes dejar campos vacios para realizar esta operacion');", true);
            }
            else
            {
                UtilidadesAmigos.Logica.Entidades.Cotizador.EValorVehiculo Mantenimiento = new Logica.Entidades.Cotizador.EValorVehiculo();

                Mantenimiento.IdTipoCotizador = Convert.ToDecimal(ddlTipoCotizadorMantenimiento.SelectedValue);
                Mantenimiento.IdValorVehiculo = IdMantenimiento;
                Mantenimiento.ValorVehiculo = txtValorVehiculoMantenimiento.Text;
                Mantenimiento.Estatus0 = cbEstatus.Checked;

                var MAN = ObjdataCotizador.MantenimientoValorVehiculo(Mantenimiento, Accion);
            }
        }
#endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                CargarTipoCotizador();
                MostrarListadoValorVehiculo();
            }
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            MostrarListadoValorVehiculo();
        }

        protected void gvListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //INSTANCIAMOS EL GRID A SELECCIONAR
            GridViewRow gv = gvListado.SelectedRow;

            //CARGAMOS EL TIPO DE COTIZADOR
            CargarTipoCotizadorManteniiento();

            //HACEMOS LA CONSULTA MEDIANTE EL CAMPO SELECCIONADO
            var SacarDatos = ObjdataCotizador.BuscaValorVehiculo(
                null,
                Convert.ToDecimal(gv.Cells[1].Text),
                null);
            //SysflexWebIntegration.Logica.Comunes.UtilidadWeb.DropDownListSeleccionar(ref ddlTipoMensajero, ItemSelecciondo.IdTipoMensajero.Value.ToString());
            foreach (var n in SacarDatos)
            {
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlTipoCotizadorMantenimiento, n.IdTipoCotizador.Value.ToString());
                txtValorVehiculoMantenimiento.Text = n.ValorVehiculo;
                cbEstatus.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
            }
            
            OcultarControles();
            if (cbEstatus.Checked == true)
            {
                cbEstatus.Visible = false;
            }
            else
            {
                cbEstatus.Visible = true;
            }
            btnDeshabilitar.Visible = true;
            lbIdAccion.Text = "UPDATE";
            lbIdMantenimientos.Text = gv.Cells[1].Text;
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoValorVehiculo();
        }

        protected void btnConsultar_Click1(object sender, EventArgs e)
        {
            MostrarListadoValorVehiculo();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            OcultarControles();
            //CARGAMOS EL DROP
            CargarTipoCotizadorManteniiento();
            lbAgregarEditar.Text = "Nuevo Registro";
            lbIdAccion.Text = "INSERT";
            lbIdMantenimientos.Text = "0";
        }

        protected void dd_Click(object sender, EventArgs e)
        {
            MostrarListadoValorVehiculo();
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            MostrarControles();
            CargarTipoCotizador();
            txtValorVehiculoConsulta.Text = string.Empty;
            MostrarListadoValorVehiculo();
        }

        protected void btnGuardarMantenimiento_Click(object sender, EventArgs e)
        {
            MANValorVehiculo(
                Convert.ToDecimal(lbIdMantenimientos.Text), lbIdAccion.Text);
            MostrarControles();
            CargarTipoCotizador();
            txtValorVehiculoConsulta.Text = string.Empty;
            MostrarListadoValorVehiculo();
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            MANValorVehiculo(
                Convert.ToDecimal(lbIdMantenimientos.Text), "DESHABILITAR");
            MostrarControles();
            CargarTipoCotizador();
            txtValorVehiculoConsulta.Text = string.Empty;
            MostrarListadoValorVehiculo();
        }
    }
}