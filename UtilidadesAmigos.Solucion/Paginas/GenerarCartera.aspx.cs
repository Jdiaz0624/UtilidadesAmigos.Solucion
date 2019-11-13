using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarCartera : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region MOSTRAR EL LISTADO DE LA CARTERA
        private void MostrarCartera()
        {
            try {
                if (string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()))
                {

                }
                else
                {
                    var Listado = ObjData.Value.SacarCarteraSupervisor(
                   Convert.ToDecimal(txtCodigoSupervisor.Text),
                   null);
                    gbListadoCarteraSupervisor.DataSource = Listado;
                    gbListadoCarteraSupervisor.DataBind();
                    lbNombreSupervisor.Visible = true;
                    foreach (var n in Listado)
                    {
                        lbNombreSupervisor.Text = n.Supervisor;
                    }
                }

            }
            catch (Exception) { }
        }
#endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarCartera();
        }

        protected void cbComicion_CheckedChanged(object sender, EventArgs e)
        {
            if (cbComicion.Checked)
            {
                lbFechaDesde.Visible = true;
                txtFechaDesde.Visible = true;
                lbFechaHasta.Visible = true;
                txtFechaHasta.Visible = true;
            }
            else
            {
                lbFechaDesde.Visible = false;
                txtFechaDesde.Visible = false;
                lbFechaHasta.Visible = false;
                txtFechaHasta.Visible = false;
            }
        }

        protected void gbListadoCarteraSupervisor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbListadoCarteraSupervisor.PageIndex = e.NewPageIndex;
            MostrarCartera();
        }

        protected void gbListadoCarteraSupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            var Exportar = (from n in ObjData.Value.SacarCarteraSupervisor(
                Convert.ToDecimal(txtCodigoSupervisor.Text))
                            select new
                            {
                                Supervisor = n.Supervisor,
                                Intermediario = n.Intermediario,
                                Telefono = n.Telefono,
                                Direccion = n.Direccion,
                                Estatus = n.Estatus,
                                Oficina = n.OficinaSupervisor
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cartera de Supervisor " + lbNombreSupervisor.Text, Exportar);


        }
    }
}