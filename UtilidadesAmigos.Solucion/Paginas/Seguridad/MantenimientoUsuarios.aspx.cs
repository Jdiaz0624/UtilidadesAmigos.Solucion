using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class MantenimientoUsuarios : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataLogica = new Lazy<Logica.Logica.LogicaSistema>();

        #region LISTAS DESPLEGABLES DE LA PANTALLA DE CONSULTA
        private void ListaSucursalesConsulta() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSucursalCOnsulta, ObjDataLogica.Value.BuscaListas("SUCURSAL", null, null), true);
        }
        private void ListaOficinasConsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaConsulta, ObjDataLogica.Value.BuscaListas("OFICINA", ddlSucursalCOnsulta.SelectedValue.ToString(), null), true);
        }
        private void ListaDepartamentoConsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjDataLogica.Value.BuscaListas("DEPARTAMENTO", ddlSucursalCOnsulta.SelectedValue.ToString(), ddlOficinaConsulta.SelectedValue.ToString()), true);
        }
        private void ListaPersilConsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPerfilCOnsulta, ObjDataLogica.Value.BuscaListas("PERFILES", null, null), true);
        }
        #endregion





        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                DivBloqueConsulta.Visible = true;
                DivBloqueMantenimiento.Visible = false;
                ListaSucursalesConsulta();
                ListaOficinasConsulta();
                ListaDepartamentoConsulta();
                ListaPersilConsulta();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnRestablecer_Click(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionarUsuario_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPaginaUsuarios_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorUsuarios_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionUsuarios_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionUsuarios_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteUsuarios_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoUsuarios_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

        }

        protected void ddlSucursalCOnsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaOficinasConsulta();
            ListaDepartamentoConsulta();
        }

        protected void ddlOficinaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaDepartamentoConsulta();
        }
    }
}