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
            if (cbComicion.Checked)
            {
                if (cbAgregarOficina.Checked)
                {
                    try {
                        var BuscarComisiones = ObjData.Value.ComisionesSupervisores(
                          Convert.ToDateTime(txtFechaDesde.Text),
                          Convert.ToDateTime(txtFechaHasta.Text),
                          Convert.ToDecimal(txtCodigoSupervisor.Text),
                          Convert.ToInt32(ddlSeleccionaroficina.SelectedValue));
                        gbListadoComisiones.DataSource = BuscarComisiones;
                        gbListadoComisiones.DataBind();
                    }
                    catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true); }
                }
                else
                {
                    try {
                       // decimal? _Supervisor = Convert.ToDecimal(string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim());
                        var BuscarComisiones = ObjData.Value.ComisionesSupervisores(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text),
                            Convert.ToDecimal(txtCodigoSupervisor.Text),
                            null);
                        gbListadoComisiones.DataSource = BuscarComisiones;
                        gbListadoComisiones.DataBind();
                    }
                    catch (Exception) {
                        ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true);
                    }
                }

            }
            else
            {
                MostrarCartera();
            }
        }

        protected void cbComicion_CheckedChanged(object sender, EventArgs e)
        {
            if (cbComicion.Checked)
            {
                lbFechaDesde.Visible = true;
                txtFechaDesde.Visible = true;
                lbFechaHasta.Visible = true;
                txtFechaHasta.Visible = true;
                cbAgregarOficina.Visible = true;
                cbAgregarOficina.Checked = false;
                gbListadoCarteraSupervisor.Visible = false;
                gbListadoComisiones.Visible = true;
                lbComisionPagar.Visible = true;
                lbMontoComisionPagar.Visible = true;
                lbCodigoIntermediario.Visible = false;
                txtCodigoIntermediario.Visible = false;
                lbNombreIntermediario.Visible = false;
                txtNombreIntermediario.Visible = false;
                lbMontoComisionPagar.Text = "000000";
            }
            else
            {
                lbFechaDesde.Visible = false;
                txtFechaDesde.Visible = false;
                lbFechaHasta.Visible = false;
                txtFechaHasta.Visible = false;
                cbAgregarOficina.Visible = false;
                cbAgregarOficina.Checked = false;
                lbSeleccionaroficina.Visible = false;
                ddlSeleccionaroficina.Visible = false;
                gbListadoCarteraSupervisor.Visible = true;
                gbListadoComisiones.Visible = false;
                lbComisionPagar.Visible = false;
                lbMontoComisionPagar.Visible = false;
                lbCodigoIntermediario.Visible = true;
                txtCodigoIntermediario.Visible = true;
                lbNombreIntermediario.Visible = true;
                txtNombreIntermediario.Visible = true;
            }
        }

        protected void gbListadoCarteraSupervisor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbListadoCarteraSupervisor.PageIndex = e.NewPageIndex;
            MostrarCartera();
        }

        protected void gbListadoCarteraSupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                GridViewRow gb = gbListadoCarteraSupervisor.SelectedRow;

                var SacarCliente = (from n in ObjData.Value.ListadoClientesintermediarios(Convert.ToDecimal(gb.Cells[0].Text))
                                    select new
                                    {
                                        Poliza=n.Poliza,
                                        Ramo=n.Ramo,
                                        Subramo=n.Subramo,
                                        Estatus=n.Estatus,
                                        Oficina=n.Oficina,
                                        InicioVigencia=n.InicioVigencia,
                                        FinVigencia=n.FinVigencia,
                                        Neto=n.Neto,
                                        Supervisor=n.Supervisor,
                                        Vendedor=n.Vendedor,
                                        TelefonosVendedor=n.TelefonosVendedor,
                                        DireccionVendedor=n.DireccionVendedor,
                                        Cliente=n.Cliente,
                                        Direccion=n.Direccion,
                                        TipoIdentificacion=n.TipoIdentificacion,
                                        NumeroIdentificacion=n.NumeroIdentificacion,
                                        TelefonosClientes=n.TelefonosClientes,
                                        TipoVehiculo=n.TipoVehiculo,
                                        Marca=n.Marca,
                                        Modelo=n.Modelo,
                                        Capacidad=n.Capacidad,
                                        Ano=n.Ano,
                                        Color=n.Color,
                                        Chasis=n.Chasis,
                                        Placa=n.Placa,
                                        Uso=n.Uso,
                                        ValorVehiculo=n.ValorVehiculo,
                                        CantidadPuerta=n.CantidadPuerta,
                                        Fianza=n.Fianza,
                                        Observacion=n.Onservacion,
                                        Deducible=n.Deducible,
                                        Coaseguro=n.Coaseguro,
                                        TotalFacturado=n.TotalFacturado,
                                        TotalCobrado=n.TotalCobrado,
                                        Balance=n.Balance,
                                        _1_30=n.__1_30,
                                        _31_60=n.__31_60,
                                        _61_90=n.__61_90,
                                        _91_120=n.__91_120,
                                        _121_O_MAS=n.__121_O_MAS
                                    }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(gb.Cells[1].Text, SacarCliente);
            }
            catch (Exception) { }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            if (cbComicion.Checked)
            {
                if (cbAgregarOficina.Checked)
                {
                    try
                    {
                        var Exportar = (from n in ObjData.Value.ComisionesSupervisores(
                     Convert.ToDateTime(txtFechaDesde.Text),
                     Convert.ToDateTime(txtFechaHasta.Text),
                     Convert.ToDecimal(txtCodigoSupervisor.Text),
                     Convert.ToInt32(ddlSeleccionaroficina.SelectedValue))
                                        select new
                                        {
                                            Supervisor = n.Supervisor,
                                            Intermediario = n.Intermediario,
                                            Factura = n.Numero,
                                            Valor = n.Valor,
                                            Oficina = n.Oficina,
                                            Fecha = n.Fecha,
                                            Concepto = n.Concepto,
                                            PorcientoComision = n.__Comision,
                                            ComisionPagar = n.ComisionPagar,
                                            ValidadoDesde = n.ValidadoDesde,
                                            ValidadoHasta = n.ValidadoHasta
                                        }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comision Supervisor", Exportar);
                    }
                    catch (Exception) { }
                }
                else
                {
                    try {
                        var Exportar = (from n in ObjData.Value.ComisionesSupervisores(
                     Convert.ToDateTime(txtFechaDesde.Text),
                     Convert.ToDateTime(txtFechaHasta.Text),
                     Convert.ToDecimal(txtCodigoSupervisor.Text),
                     null)
                                        select new
                                        {
                                            Supervisor =n.Supervisor,
                                            Intermediario=n.Intermediario,
                                            Factura=n.Numero,
                                            Valor=n.Valor,
                                            Oficina=n.Oficina,
                                            Fecha=n.Fecha,
                                            Concepto =n.Concepto,
                                            PorcientoComision=n.__Comision,
                                            ComisionPagar=n.ComisionPagar,
                                            ValidadoDesde=n.ValidadoDesde,
                                            ValidadoHasta=n.ValidadoHasta
                                        }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comision Supervisor", Exportar);
                    }
                    catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true); }
                }
            }
            else
            {
                try {

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
                catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true); }
            }


        }

        protected void gbListadoCarteraSupervisor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try {
                e.Row.Cells[0].Visible = false;
            }
            catch (Exception) { }
        }

        protected void cbAgregarOficina_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAgregarOficina.Checked)
            {
                lbSeleccionaroficina.Visible = true;
                ddlSeleccionaroficina.Visible = true;
                //CARGAMOS LAS OFICINAS
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficina, ObjData.Value.BuscaListas("OFICINAS", null, null));
            }
            else
            {
                lbSeleccionaroficina.Visible = false;
                ddlSeleccionaroficina.Visible = false;
            }
        }

        protected void gbListadoComisiones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gbListadoComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gbListadoComisiones_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnExportarListadoCompleto_Click(object sender, EventArgs e)
        {
            if (cbAgregarOficina.Checked)
            {
                try
                {
                    var Exportar = (from n in ObjData.Value.ComisionesSupervisores(
                 Convert.ToDateTime(txtFechaDesde.Text),
                 Convert.ToDateTime(txtFechaHasta.Text),
                 null,
                 Convert.ToInt32(ddlSeleccionaroficina.SelectedValue))
                                    select new
                                    {
                                        Supervisor = n.Supervisor,
                                        Intermediario = n.Intermediario,
                                        Factura = n.Numero,
                                        Valor = n.Valor,
                                        Oficina = n.Oficina,
                                        Fecha = n.Fecha,
                                        Concepto = n.Concepto,
                                        PorcientoComision = n.__Comision,
                                        ComisionPagar = n.ComisionPagar,
                                        ValidadoDesde = n.ValidadoDesde,
                                        ValidadoHasta = n.ValidadoHasta
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comision Supervisor Completo", Exportar);
                }
                catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true); }
            }
            else
            {
                try
                {
                    var Exportar = (from n in ObjData.Value.ComisionesSupervisores(
                 Convert.ToDateTime(txtFechaDesde.Text),
                 Convert.ToDateTime(txtFechaHasta.Text))
                                    select new
                                    {
                                        Supervisor = n.Supervisor,
                                        Intermediario = n.Intermediario,
                                        Factura = n.Numero,
                                        Valor = n.Valor,
                                        Oficina = n.Oficina,
                                        Fecha = n.Fecha,
                                        Concepto = n.Concepto,
                                        PorcientoComision = n.__Comision,
                                        ComisionPagar = n.ComisionPagar,
                                        ValidadoDesde = n.ValidadoDesde,
                                        ValidadoHasta = n.ValidadoHasta
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comision Supervisor Completo", Exportar);
                }
                catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true); }
            }
        }

        protected void gbListadoCarteraSupervisor_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            try { e.Row.Cells[0].Visible = false; }
            catch (Exception) { }
        }
    }
}