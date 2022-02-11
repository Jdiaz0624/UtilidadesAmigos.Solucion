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
        //Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        //#region CARGAR LOS DROP 
        //private void CargarDropConsulta()
        //{
        //    //CARGAMOS LAS OFICINAS
        //    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaConsulta, ObjData.Value.BuscaListas("OFICINA", null, null), true);
        //    //CARGAMOS LOS DEPARTAMENTOS
        //    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlOficinaConsulta.SelectedValue, null), true);
        //    //CARGAMOS LOS EMPLEADOS
        //    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoConsulta, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaConsulta.SelectedValue, ddlDepartamentoConsulta.SelectedValue), true);
        //    //CARGAMOS LOS ESTATUS DE TARJETAS
        //    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarEstatustarjetaConsulta, ObjData.Value.BuscaListas("ESTATUSTARJETA", null, null), true);
        //}
        //private void CargarDropMantenimiento()
        //{
        //    //CARGAMOS LAS OFICINAS
        //    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjData.Value.BuscaListas("OFICINA", null, null));
        //    //CARGAMOS LOS DEPARTAMENTOS
        //    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoMantenimiento, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlOficinaMantenimiento.SelectedValue, null));
        //    //CARGAMOS LOS EMPLEADOS
        //    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoMantenimiento, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaMantenimiento.SelectedValue, ddlDepartamentoMantenimiento.SelectedValue));
        //    //CARGAMOS LOS ESTATUS DE TARJETAS
        //    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEstatus, ObjData.Value.BuscaListas("ESTATUSTARJETA", null, null));
        //}
        //#endregion

   



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }


        }


    }
}