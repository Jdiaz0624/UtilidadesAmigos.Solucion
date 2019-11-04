using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class Empleados : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjdataComun = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> Objdata = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();

        #region CARGAR LAS LISTAS DESPLEGABLES
        //CARGAMOS LAS LISTAS PARA LAS CONSULTAS
        private void CargarListasPadre()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaConsulta, ObjdataComun.Value.BuscaListas("OFICINA", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjdataComun.Value.BuscaListas("DEPARTAMENTO", ddlOficinaConsulta.SelectedValue, null), true);
        }
        private void CargarDepartamentosConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjdataComun.Value.BuscaListas("DEPARTAMENTO", ddlOficinaConsulta.SelectedValue, null), true);
        }

        private void CargarListaPadreMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjdataComun.Value.BuscaListas("OFICINA", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamenoMantenimiento, ObjdataComun.Value.BuscaListas("DEPARTAMENTO", ddlOficinaMantenimiento.SelectedValue, null));
        }
        private void CargarDepartamentosMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamenoMantenimiento, ObjdataComun.Value.BuscaListas("DEPARTAMENTO", ddlOficinaMantenimiento.SelectedValue, null));
        }
        #endregion
        #region OCULTAR Y MOSTRAR CONTROLES
        private void OcultarControles()
        {
            //CONTROLES SUPERIORES
            lbOficinaConsulta.Visible = false;
            ddlOficinaConsulta.Visible = false;
            lbDepartamentoConsulta.Visible = false;
            ddlDepartamentoConsulta.Visible = false;
            lbNombreConsulta.Visible = false;
            txtNombreConsulta.Visible = false;
            btnConsultar.Visible = false;
            btnNuevo.Visible = false;
            btnatrasConsulta.Visible = false;
            btnModificar.Visible = false;
            btnDeshabilitar.Visible = false;
            btnExportar.Visible = false;
            gvEmpleados.Visible = false;

            //CONTROLES INFERIORES
            CargarListaPadreMantenimiento();
           // CargarDepartamentosMantenimiento();
            lbOficinaMantenimiento.Visible = true;
            ddlOficinaMantenimiento.Visible = true;
            lbDepartamentoMantenimiento.Visible = true;
            ddlDepartamenoMantenimiento.Visible = true;
            lbNombreMantenimiento.Visible = true;
            txtNombreMantenimiento.Visible = true;
            cbEstatusMantenimiento.Visible = true;
            btnGuardarMantenimiento.Visible = true;
            btnAtrasMantenimiento.Visible = true;

        }
        private void MostrarControles()
        {
            //CONTROLES SUPERIORES
            lbOficinaConsulta.Visible = true;
            ddlOficinaConsulta.Visible = true;
            lbDepartamentoConsulta.Visible = true;
            ddlDepartamentoConsulta.Visible = true;
            lbNombreConsulta.Visible = true;
            txtNombreConsulta.Visible = true;
            btnConsultar.Visible = true;
            btnNuevo.Visible = true;
            btnatrasConsulta.Visible = true;
            btnModificar.Visible = true;
            btnDeshabilitar.Visible = true;
            btnExportar.Visible = true;
            gvEmpleados.Visible = true;
            CargarListasPadre();
            txtNombreConsulta.Text = string.Empty;
            MostrarListadoEmpleados();

            //CONTROLES INFERIORES
            
            lbOficinaMantenimiento.Visible = false;
            ddlOficinaMantenimiento.Visible = false;
            lbDepartamentoMantenimiento.Visible = false;
            ddlDepartamenoMantenimiento.Visible = false;
            lbNombreMantenimiento.Visible = false;
            txtNombreMantenimiento.Visible = false;
            cbEstatusMantenimiento.Visible = false;
            btnGuardarMantenimiento.Visible = false;
            btnAtrasMantenimiento.Visible = false;
            txtNombreMantenimiento.Text = string.Empty;
        }
        #endregion
        private void Volveratras()
        {
            btnConsultar.Enabled = true;
            btnNuevo.Enabled = true;
            btnExportar.Enabled = true;
            btnatrasConsulta.Enabled = false;
            btnModificar.Enabled = false;
            btnDeshabilitar.Enabled = false;
            MostrarListadoEmpleados();
            
        }
        #region MOSTRAR EL LISTADO DE LOS EMPLEADOS
        private void MostrarListadoEmpleados()
        {
            decimal? IdOficina = ddlOficinaConsulta.SelectedValue != "-1" ? decimal.Parse(ddlOficinaConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? IdDepartamento = ddlDepartamentoConsulta.SelectedValue != "-1" ? decimal.Parse(ddlDepartamentoConsulta.SelectedValue) : new Nullable<decimal>();
            string _Nombre = string.IsNullOrEmpty(txtNombreConsulta.Text.Trim()) ? null : txtNombreConsulta.Text.Trim();

            var Buscar = Objdata.Value.BuscaEmpleado(
                IdOficina,
                IdDepartamento,
                new Nullable<decimal>(),
                _Nombre);
            gvEmpleados.DataSource = Buscar;
            gvEmpleados.DataBind();
            OcultarColumnas();
        }
        private void OcultarColumnas()
        {
            gvEmpleados.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center; //BOTON
            gvEmpleados.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center; //ID
            gvEmpleados.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center; //OFICINA
            gvEmpleados.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center; //DEPARTAMENTO
            gvEmpleados.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Center; //NOMBRE
            gvEmpleados.Columns[5].ItemStyle.HorizontalAlign = HorizontalAlign.Center; //ESTATUS
            gvEmpleados.Columns[6].ItemStyle.HorizontalAlign = HorizontalAlign.Center; //CREADO POR
            gvEmpleados.Columns[7].ItemStyle.HorizontalAlign = HorizontalAlign.Center; //FECHA ADICIONA
        }
        #endregion
        #region MANTENIMIENTO DE EMPLEADOS
        private void MANEmpleados(decimal IdMantenimiento, string Accion)
        {
            try
            {
                UtilidadesAmigos.Logica.Entidades.Mantenimientos.EEmpleado Mantenimiento = new Logica.Entidades.Mantenimientos.EEmpleado();

                Mantenimiento.IdOficina = Convert.ToDecimal(ddlOficinaMantenimiento.SelectedValue);
                Mantenimiento.IdDepartamento = Convert.ToDecimal(ddlDepartamenoMantenimiento.SelectedValue);
                Mantenimiento.IdEmpleado = IdMantenimiento;
                Mantenimiento.Nombre = txtNombreMantenimiento.Text;
                Mantenimiento.Estatus0 = cbEstatusMantenimiento.Checked;
                Mantenimiento.UsuarioAdiciona = Convert.ToDecimal(Session["IdUsuario"].ToString());
                Mantenimiento.FechaAdiciona = DateTime.Now;
                Mantenimiento.UsuarioAdiciona = Convert.ToDecimal(Session["IdUsuario"].ToString());
                Mantenimiento.FechaModifica = DateTime.Now;

                var MAN = Objdata.Value.MantenimientoEmpleado(Mantenimiento, Accion);
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error al realziar la operación')", true);
            }
          
        }
#endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                CargarListasPadre();
                MostrarListadoEmpleados();
            }
        }

        protected void gvEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmpleados.PageIndex = e.NewPageIndex;
            MostrarListadoEmpleados();
        }

        protected void gvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gv = gvEmpleados.SelectedRow;
            lbIdMantenimiento.Text = gv.Cells[1].Text;
            var Buscar = Objdata.Value.BuscaEmpleado(
                null,
                null,
                Convert.ToDecimal(lbIdMantenimiento.Text),
                null);
            gvEmpleados.DataSource = Buscar;
            gvEmpleados.DataBind();
            OcultarColumnas();
            btnConsultar.Enabled = false;
            btnNuevo.Enabled = false;
            btnExportar.Enabled = false;
            btnatrasConsulta.Enabled = true;
            btnModificar.Enabled = true;
            btnDeshabilitar.Enabled = true;
            
        }

        protected void btnGuardarMantenimiento_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(txtNombreMantenimiento.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No puedes dejar campos vacios para realizar esta operación')", true);
            }
            else
            {
                MANEmpleados(
               Convert.ToDecimal(lbIdMantenimiento.Text),
               lbAccion.Text);
                MostrarControles();
                Volveratras();
            }
        }

        protected void btnAtrasMantenimiento_Click(object sender, EventArgs e)
        {
            MostrarControles();
            Volveratras();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoEmpleados();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            OcultarControles();
            lbIdMantenimiento.Text = "0";
            lbAccion.Text = "INSERT";
        }

        protected void btnatrasConsulta_Click(object sender, EventArgs e)
        {
            Volveratras();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            OcultarControles();
            var SacarDatos = Objdata.Value.BuscaEmpleado(
                null,
                null,
                Convert.ToDecimal(lbIdMantenimiento.Text),
                null);
            CargarListaPadreMantenimiento();
            
            foreach (var n in SacarDatos)
            {
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlOficinaMantenimiento, n.IdOficina.ToString());
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlDepartamenoMantenimiento, n.IdDepartamento.ToString());
                txtNombreMantenimiento.Text = n.Nombre;
                cbEstatusMantenimiento.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
            }
            if (cbEstatusMantenimiento.Checked == true)
            {
                cbEstatusMantenimiento.Visible = false;
            }
            else
            {
                cbEstatusMantenimiento.Visible = true;
            }
            lbAccion.Text = "UPDATE";
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            MANEmpleados(Convert.ToDecimal(lbIdMantenimiento.Text), "DISABLE");
            Volveratras();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            //EXPORTAMOS LA DATA A EXEL
            try {
                decimal? _IdOficina = ddlOficinaConsulta.SelectedValue != "-1" ? decimal.Parse(ddlOficinaConsulta.SelectedValue) : new Nullable<decimal>();
                decimal? _IdDepartamento = ddlDepartamentoConsulta.SelectedValue != "-1" ? decimal.Parse(ddlDepartamentoConsulta.SelectedValue) : new Nullable<decimal>();
                string _Nombre = string.IsNullOrEmpty(txtNombreConsulta.Text.Trim()) ? null : txtNombreConsulta.Text.Trim();

                var Exportar = (from n in Objdata.Value.BuscaEmpleado(
                    _IdOficina,
                    _IdDepartamento,
                    new Nullable<decimal>(),
                    _Nombre)
                                select new
                                {
                                    Oficina = n.Oficina,
                                    Departamento = n.Departamento,
                                    Nombre = n.Nombre,
                                    Estatus = n.Estatus,
                                    CreadoPor = n.CreadoPor,
                                    FechaCreado = n.FechaAdiciona,
                                    ModificadoPor = n.ModificadoPor,
                                    FechaModificado = n.FechaModifica
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Empleados", Exportar);
            }
            catch (Exception) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error al Exportar la data')", true);
            }
        }

        protected void ddlOficinaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDepartamentosConsulta();
        }

        protected void ddlOficinaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDepartamentosMantenimiento();
        }
    }
}