using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{//decimal? _Oficina = ddlOficinaConsulta.SelectedValue != "-1" ? decimal.Parse(ddlOficinaConsulta.SelectedValue) : new Nullable<decimal>();
    
    public partial class AsignacionTarjetas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        #region CARGAR LOS DROP 
        private void CargarDropConsulta()
        {
            //CARGAMOS LAS OFICINAS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaConsulta, ObjData.Value.BuscaListas("OFICINA", null, null), true);
            //CARGAMOS LOS DEPARTAMENTOS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlOficinaConsulta.SelectedValue, null), true);
            //CARGAMOS LOS EMPLEADOS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoConsulta, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaConsulta.SelectedValue, ddlDepartamentoConsulta.SelectedValue), true);
            //CARGAMOS LOS ESTATUS DE TARJETAS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarEstatustarjetaConsulta, ObjData.Value.BuscaListas("ESTATUSTARJETA", null, null), true);
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDropConsulta();
            }


        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {

        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {

        }

        protected void gvTarjetaAcceso_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvTarjetaAcceso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvTarjetaAcceso_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try { e.Row.Cells[1].Visible = false; }
            catch (Exception) { }
        }

        protected void cbFiltrarPorRangoFechaConsulta_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFiltrarPorRangoFechaConsulta.Checked)
            {
                lbFechaDesdeConsulta.Visible = true;
                txtFechaDesdeConsulta.Visible = true;
                lbFechaHastaConsulta.Visible = true;
                txtFechaHastaConsulta.Visible = true;
            }
            else
            {
                lbFechaDesdeConsulta.Visible = false;
                txtFechaDesdeConsulta.Visible = false;
                lbFechaHastaConsulta.Visible = false;
                txtFechaHastaConsulta.Visible = false;
            }
        }

        protected void ddlOficinaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlOficinaConsulta.SelectedValue, null), true);
            //CARGAMOS LOS EMPLEADOS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoConsulta, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaConsulta.SelectedValue, ddlDepartamentoConsulta.SelectedValue), true);
        }

        protected void ddlDepartamentoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CARGAMOS LOS EMPLEADOS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoConsulta, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaConsulta.SelectedValue, ddlDepartamentoConsulta.SelectedValue), true);
        }
    }
}