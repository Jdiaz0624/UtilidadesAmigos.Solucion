using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ServiciosFijos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaCotizador.LogicaCotizador> ObjDataCotizador = new Lazy<Logica.Logica.LogicaCotizador.LogicaCotizador>();

        #region SACAR LOS DATOS DE LOS SERVICIOS FIJOS
        private void SacarDatosServiciosFijos(decimal IdServicioFijo)
        {
            var SacarDatos = ObjDataCotizador.Value.BuscaServiciosFijos(IdServicioFijo);
            foreach (var n in SacarDatos)
            {
                txtImpuestosServiciosFIjos.Text = n.Impuesto.ToString();
                cbImpuestoFijo.Checked = (n.ImpuestoFijo0.HasValue ? n.ImpuestoFijo0.Value : false);
                txtCasaConductorServiciosFijos.Text = n.CasaConductor.ToString();
                cbCasaConductorFijo.Checked = (n.CasaConductorFijo0.HasValue ? n.CasaConductorFijo0.Value : false);
                txtServicioGruaServicioFijo.Text = n.ServicioGrua.ToString();
                cbServicioGrua.Checked = (n.ServicioGruaFijo0.HasValue ? n.ServicioGruaFijo0.Value : false);
                txtVehiculoRentado.Text = n.VehiculoRentado.ToString();
                cbVehiculoRentado.Checked = (n.VehiculoRentadoFijo0.HasValue ? n.VehiculoRentadoFijo0.Value : false);
                txtFuturoExequial.Text = n.FuturoExequial.ToString();
                cbFuturoExequial.Checked = (n.FuturoExequialFijo0.HasValue ? n.FuturoExequialFijo0.Value : false);
                txtAeroAmbulancia.Text = n.AeroAmbulancia.ToString();
                cbAeroambulancia.Checked = (n.AeroAmbulanciaFijo0.HasValue ? n.AeroAmbulanciaFijo0.Value : false);
            }
        }
        #endregion
        #region MANTENIMIENTO DE SERVICIOS FIJOS
        private void MAMServicioFijo(decimal IdServicioFijo, string Accion)
        {
            //VERIFICAMOS LOS CAMPOS VACIOS
            if (string.IsNullOrEmpty(txtImpuestosServiciosFIjos.Text.Trim()) || string.IsNullOrEmpty(txtCasaConductorServiciosFijos.Text.Trim()) || string.IsNullOrEmpty(txtServicioGruaServicioFijo.Text.Trim()) || string.IsNullOrEmpty(txtVehiculoRentado.Text.Trim()) || string.IsNullOrEmpty(txtFuturoExequial.Text.Trim()) || string.IsNullOrEmpty(txtAeroAmbulancia.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No puedes dejar campos vacios para realizar esta operación')", true);
            }
            else
            {
                UtilidadesAmigos.Logica.Entidades.Cotizador.EServiciosFijos Mantenimiento = new Logica.Entidades.Cotizador.EServiciosFijos();

                Mantenimiento.IdServiciosFijos = IdServicioFijo;
                Mantenimiento.Impuesto = Convert.ToDecimal(txtImpuestosServiciosFIjos.Text);
                Mantenimiento.ImpuestoFijo0 = cbImpuestoFijo.Checked;
                Mantenimiento.CasaConductor = Convert.ToDecimal(txtCasaConductorServiciosFijos.Text);
                Mantenimiento.CasaConductorFijo0 = cbCasaConductorFijo.Checked;
                Mantenimiento.ServicioGrua = Convert.ToDecimal(txtServicioGruaServicioFijo.Text);
                Mantenimiento.ServicioGruaFijo0 = cbServicioGrua.Checked;
                Mantenimiento.VehiculoRentado = Convert.ToDecimal(txtVehiculoRentado.Text);
                Mantenimiento.VehiculoRentadoFijo0 = cbVehiculoRentado.Checked;
                Mantenimiento.FuturoExequial = Convert.ToDecimal(txtFuturoExequial.Text);
                Mantenimiento.FuturoExequialFijo0 = cbFuturoExequial.Checked;
                Mantenimiento.AeroAmbulancia = Convert.ToDecimal(txtAeroAmbulancia.Text);
                Mantenimiento.AeroAmbulanciaFijo0 = cbAeroambulancia.Checked;

                var MAN = ObjDataCotizador.Value.MantenimientoServiciosFijos(Mantenimiento, Accion);
            }
        }
#endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SacarDatosServiciosFijos(1);
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            MAMServicioFijo(1, "UPDATE");
        }
    }
}