using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarMarbetes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                cbOtrosFiltros.Checked = false;
                rbMarbetePVC.Checked = true;
            }
        }
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjdataProcesos = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();
        #region MOSTRAR EL LISTADO DE LOS REGISTROS
        private void MostrarListadoPolizasMarbete() {
            if (cbOtrosFiltros.Checked) {
                //BUSCAMOS POR CHASIS O POR PLACA (SI AMBOS CAMPOS ESTAN VACIOS NO BUSCA NADA)
                if (string.IsNullOrEmpty(txtChasisConsulta.Text.Trim()) && string.IsNullOrEmpty(txtPlacaConsulta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CamposChasisPlacaVacios()", "CamposChasisPlacaVacios();", true);
                }
                else {
                    string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
                    string _Item = string.IsNullOrEmpty(txtItemConsulta.Text.Trim()) ? null : txtItemConsulta.Text.Trim();
                    string _Chasis = string.IsNullOrEmpty(txtChasisConsulta.Text.Trim()) ? null : txtChasisConsulta.Text.Trim();
                    string _Placa = string.IsNullOrEmpty(txtPlacaConsulta.Text.Trim()) ? null : txtPlacaConsulta.Text.Trim();

                    var BuscarRegistros = ObjdataProcesos.Value.GenerarDatosParaMarbeteVehiculos(
                        _Poliza,
                        _Item,
                        _Chasis,
                        _Placa);
                    if (BuscarRegistros.Count() < 1)
                    {
                        lbCantidadRegistrosVariable.Text = "0";
                    }
                    else
                    {
                        gvListadoPoliza.DataSource = BuscarRegistros;
                        gvListadoPoliza.DataBind();

                        int CantidadRegistros = 0;
                        foreach (var n in BuscarRegistros)
                        {
                            CantidadRegistros = Convert.ToInt32(n.CantidadRegistros);
                            lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                        }
                    }
                }
            }
            else {
                //BUSCMAOS POR POLIZA E ITEM (CAMPO POLIZA OBLIGATORIO)
                if (string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoPolizaVacio()", "CampoPolizaVacio();", true);
                }
                else {
                    string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
                    string _Item = string.IsNullOrEmpty(txtItemConsulta.Text.Trim()) ? null : txtItemConsulta.Text.Trim();

                    var Buscarregistros = ObjdataProcesos.Value.GenerarDatosParaMarbeteVehiculos(
                        _Poliza,
                        _Item,
                        null,
                        null);
                    if (Buscarregistros.Count() < 1) {
                        lbCantidadRegistrosVariable.Text = "0";
                    }
                    else {
                        gvListadoPoliza.DataSource = Buscarregistros;
                        gvListadoPoliza.DataBind();

                        int CantidadRegistros = 0;
                        foreach (var n in Buscarregistros) {
                            CantidadRegistros = Convert.ToInt32(n.CantidadRegistros);
                            lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                        }
                    }
                }

            }
        }
        #endregion
        #region MOSTRAR Y OCULTAR CONTROLES
        private void MostrarControles() { }
        private void OcultarControles() { }
        private void LimpiarControles() { }
        #endregion

        protected void cbOtrosFiltros_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOtrosFiltros.Checked)
            {
                rbBuscarPorChasis.Visible = true;
                rbBuscarPorPlaca.Visible = true;
                rbBuscarPorChasis.Checked = true;
            }
            else {
                rbBuscarPorChasis.Visible = false;
                rbBuscarPorPlaca.Visible = false;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoPolizasMarbete();
        }

        protected void gvListadoPoliza_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoPoliza.PageIndex = e.NewPageIndex;
            MostrarListadoPolizasMarbete();
        }

        protected void gvListadoPoliza_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow GV = gvListadoPoliza.SelectedRow;
        }
    }
}