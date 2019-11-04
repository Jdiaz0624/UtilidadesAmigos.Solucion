using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarDataCoberturas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAR LOS DROP
        //CARGAR LAS COBERTURAS
        public void CargarLosDrops()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarCobertura, ObjData.Value.BuscaListas("COBERTURA", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPlan, ObjData.Value.BuscaListas("PLANCOBERTURA", ddlSeleccionarCobertura.SelectedValue.ToString(), null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMes, ObjData.Value.BuscaListas("MESES", null, null));
        }

        #endregion
        #region GUARDAR LOS DATOS EN LA TABLA DE COBERTURAS
        private void GuardarDatos(string Accion)
        {

        }

        #endregion
        #region MOSTRAR REGISTROS
        private void MostrarListado()
        {
            var Listado = ObjData.Value.ValidarPolizasCancaladasCoberturas(
                null,
                Convert.ToInt32(ddlSeleccionarPlan.SelectedValue));
            gvListado.DataSource = Listado;
            gvListado.DataBind();
            gvListado.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListado.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListado.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListado.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListado.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListado.Columns[5].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListado.Columns[6].ItemStyle.HorizontalAlign = HorizontalAlign.Center;

        }
        #endregion

        #region EXPORTAR A EXEL
        private void ExportarExel()
        {
            var Exportar = (from n in ObjData.Value.ValidarPolizasCancaladasCoberturas(
                null,
                Convert.ToInt32(ddlSeleccionarPlan.SelectedValue))
                            select new
                            {
                                Poliza = n.Poliza,
                                Estatus =n.Estatus,
                                InicioVigencia = n.InicioVigencia,
                                FinVigencia =n.FinVigencia,
                                Concepto =n.Concepto,
                                FechaMovimiento=n.FechaMovimiento,
                                DiasConsumido =n.DiasConsumidos,
                                Total=n.Total,
                                Cobertura=n.Cobertura,
                                Comentario=n.Comentario
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(ddlSeleccionarCobertura.SelectedItem + " - " + ddlSeleccionarPlan.SelectedItem + " - " + ddlSeleccionarMes.SelectedItem, Exportar);
        }
#endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                CargarLosDrops();
            }
        }

        protected void gvEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
        }

        protected void gvListado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            MostrarListado();
        }

        protected void ddlSeleccionarCobertura_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPlan, ObjData.Value.BuscaListas("PLANCOBERTURA", ddlSeleccionarCobertura.SelectedValue.ToString(), null));
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnMostrarListado_Click(object sender, EventArgs e)
        {
            MostrarListado();
        }

        protected void btnExportarExel_Click(object sender, EventArgs e)
        {
            ExportarExel();
        }

        protected void BTNcARGAR_Click(object sender, EventArgs e)
        {
            //FileStream stream = new FileStream("../../myxlsx/sample.xlsx", FileMode.Open);

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            
        }
    }
}