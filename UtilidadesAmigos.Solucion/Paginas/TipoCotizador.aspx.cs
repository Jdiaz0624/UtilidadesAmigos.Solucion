using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class TipoCotizador : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaCotizador.LogicaCotizador> ObjDataCotizador = new Lazy<Logica.Logica.LogicaCotizador.LogicaCotizador>();

        #region MOSTRAR EL LISTADO DEL TIPO DE COTIZADOR
        private void MostrarListadoTipoCotizador()
        {
            string _TipoCotizador = string.IsNullOrEmpty(txtBuscarTipoCotizador.Text.Trim()) ? null : txtBuscarTipoCotizador.Text.Trim();

            var Buscar = ObjDataCotizador.Value.BuscaTipoCotizador(
                new Nullable<decimal>(),
                _TipoCotizador);
            gvListado.DataSource = Buscar;
            gvListado.DataBind();
            //GridView1.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListado.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListado.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListado.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }
        #endregion

        #region OCULTAR Y MOSTRAR CONTROLES
        private void OcultarControles()
        {
            lbAgregarEditar.Visible = true;
            lbDescripcion.Visible = true;
            txtTipoCotizador.Visible = true;
            cbEstatus.Visible = true;
            btnGuardar.Visible = true;
            btnAtras.Visible = true;
            //Ocultar
            lbConsultarTipoCotizador.Visible = false;
            txtBuscarTipoCotizador.Visible = false;
            btnConsultar.Visible = false;
            btnNuevo.Visible = false;
            txtBuscarTipoCotizador.Text = string.Empty;
            gvListado.Visible = false;
        }
        private void MostrarControles()
        {
            lbAgregarEditar.Visible = false;
            lbDescripcion.Visible = false;
            txtTipoCotizador.Visible = false;
            cbEstatus.Visible = false;
            btnGuardar.Visible = false;
            btnAtras.Visible = false;
            //Ocultar
            lbConsultarTipoCotizador.Visible = true;
            txtBuscarTipoCotizador.Visible = true;
            btnConsultar.Visible = true;
            btnNuevo.Visible = true;
            txtTipoCotizador.Text = string.Empty;
            cbEstatus.Checked = false;
            gvListado.Visible = true;
            btnDeshabilitar.Visible = false;
            MostrarListadoTipoCotizador();
            txtTipoCotizador.Text = string.Empty;
            cbEstatus.Checked = false;
            lbAgregarEditar.Visible = false;
        }
        #endregion

        #region MANTENIMIENTO TIPO DE COTIZADOR
        private void MANTipoCotizador(decimal IdTipoCotizador, string Accion)
        {
            UtilidadesAmigos.Logica.Entidades.Cotizador.ETipoCotizador Mantenimiento = new Logica.Entidades.Cotizador.ETipoCotizador();

            Mantenimiento.IdTipoCotizador = IdTipoCotizador;
            Mantenimiento.TipoCotizador = txtTipoCotizador.Text;
            Mantenimiento.Estatus0 = cbEstatus.Checked;

            var MAM = ObjDataCotizador.Value.MantenimientoTipoCotizador(Mantenimiento, Accion);
        }
#endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarListadoTipoCotizador();
            }
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MostrarListadoTipoCotizador();
        }

        protected void gvListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gv = gvListado.SelectedRow;

            OcultarControles();
            lbAgregarEditar.Text = "Editar Registro";
            //VERIFICAMOS LA COLUMNA Y HACEMOS LA CONSULTA
            //decimal IdTipoCotizador = Convert.ToDecimal(gv.Cells[1].Text);
            var Buscar = ObjDataCotizador.Value.BuscaTipoCotizador(
                Convert.ToDecimal(gv.Cells[1].Text),
                null);
            foreach (var n in Buscar)
            {
                txtTipoCotizador.Text = n.TipoCotizador;
                cbEstatus.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
            }
            if (cbEstatus.Checked == true)
            {
                cbEstatus.Visible = false;
            }
            else
            {
                cbEstatus.Visible = true;
            }
            lbIdMantemiminto.Text = gv.Cells[1].Text;
            lbAccion.Text = "UPDATE";
            btnDeshabilitar.Visible = true;
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoTipoCotizador();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            OcultarControles();
            lbAgregarEditar.Text = "Nuevo Registro";
            cbEstatus.Checked = true;
            cbEstatus.Visible = false;
            lbIdMantemiminto.Text = "0";
            lbAccion.Text = "INSERT";
            cbEstatus.Checked = true;
            cbEstatus.Visible = false;
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            MostrarControles();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            MANTipoCotizador(Convert.ToDecimal(lbIdMantemiminto.Text), lbAccion.Text);
            MostrarControles();
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            MANTipoCotizador(Convert.ToDecimal(lbIdMantemiminto.Text), "DESHABILITAR");
            MostrarControles();
        }
    }
}