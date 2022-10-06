using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//EXPORTAMOS A EXEL
using System.IO;
using System.Drawing;


namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ProduccionDiaria : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataLogica = new Lazy<Logica.Logica.LogicaSistema>();
        public UtilidadesAmigos.Logica.Comunes.VariablesGlobales VariablesGlobales = new Logica.Comunes.VariablesGlobales();

        #region CARGAR LOS RAMOS
        private void CargarRamos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjDataLogica.Value.BuscaListas("RAMO", null, null));
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LA PRODUCCION DIARIA
        private void MostrarProduccionDiaria()
        {
            if (cbEspesificarRamo.Checked)
            {
                var MostrarData = ObjDataLogica.Value.ProduccionDiaria(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    Convert.ToInt32(ddlSeleccionarRamo.SelectedValue),
                    null);
                gbProduccionDiaria.DataSource = MostrarData;
                gbProduccionDiaria.DataBind();
                decimal TotalFacturado = 0, TotalPesosDominicanos = 0;
                foreach (var n in MostrarData)
                {
                    TotalFacturado = Convert.ToDecimal(n.TotalFacturado);
                    TotalPesosDominicanos = Convert.ToDecimal(n.TotalPesosDominicanos);
                    lbCantidadFActuradoVariable.Text = TotalFacturado.ToString("N2");
                    lbCantidadFacturadoPesosVariable.Text = TotalPesosDominicanos.ToString("N2");
                }
            }
            else
            {
                var MostrarData = ObjDataLogica.Value.ProduccionDiaria(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text));
                gbProduccionDiaria.DataSource = MostrarData;
                gbProduccionDiaria.DataBind();
                decimal TotalFacturado = 0, TotalPesosDominicanos = 0;
                foreach (var n in MostrarData)
                {
                    TotalFacturado = Convert.ToDecimal(n.TotalFacturado);
                    TotalPesosDominicanos = Convert.ToDecimal(n.TotalPesosDominicanos);
                    lbCantidadFActuradoVariable.Text = TotalFacturado.ToString("N2");
                    lbCantidadFacturadoPesosVariable.Text = TotalPesosDominicanos.ToString("N2");
                }
            }
        }
        #endregion
        #region EXPORTAR DATA A EXEL
        private void ExportarDataExel()
        {
            if (cbEspesificarRamo.Checked)
            {
                var Exportar = (from n in ObjDataLogica.Value.ProduccionDiaria(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    Convert.ToInt32(ddlSeleccionarRamo.SelectedValue),
                    null)
                                select new
                                {
                                    Ramo =n.Ramo,
                                    Concepto =n.Concepto,
                                    Cantidad=n.Cantidad,
                                    Moneda=n.Moneda,
                                    Facturado=n.Facturado,
                                    PesosDominicanos=n.PesosDominicanos
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion Diaria " + " - " + ddlSeleccionarRamo.SelectedItem, Exportar);
            }
            else
            {
                var Exportar = (from n in ObjDataLogica.Value.ProduccionDiaria(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text))
                                select new
                                {
                                    Ramo = n.Ramo,
                                    Concepto = n.Concepto,
                                    Cantidad = n.Cantidad,
                                    Moneda = n.Moneda,
                                    Facturado = n.Facturado,
                                    PesosDominicanos = n.PesosDominicanos
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion Diaria " + " - " + ddlSeleccionarRamo.SelectedItem, Exportar);
            }
        }
        #endregion
        #region MOSTRAR EL DETALLE DE LA PRODUCCION DIARIA
        private void MostrarDetalleProduccionDiaria()
        {
            //SELECCIONAMOS LOS CAMPOS NECESARIOS PAA SACAR LOS DATOS
            try
            {
                GridViewRow gb = gbProduccionDiaria.SelectedRow;

                var SacarDetalle = ObjDataLogica.Value.ProduccionDiariaDetalle(
                    Convert.ToInt32(gb.Cells[0].Text),
                    gb.Cells[2].Text,
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text));
                gbProduccionDiaria.Visible = false;
                gbProduccionDiariaDetalle.Visible = true;
                rbExportarDependientes.Visible = true;
                rbExportarNormal.Visible = true;
                rbExportarNormal.Checked = true;
                txtFechaDesde.Enabled = false;
                txtFechaHasta.Enabled = false;
                btnAtras.Visible = true;
                cbExportarTodo.Visible = true;
                btnBuscarRegistros.Enabled = false;
                btnGenerarReporte.Enabled = false;
                gbProduccionDiariaDetalle.DataSource = SacarDetalle;
                gbProduccionDiariaDetalle.DataBind();
            }
            catch (Exception) { }
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRamos();
                lbSeleccionarRamo.Visible = false;
                ddlSeleccionarRamo.Visible = false;

            }
          

        }


        protected void gbListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gbListado.PageIndex = e.NewPageIndex;
            //CargarData();
        }

        protected void cbEspesificarRamo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEspesificarRamo.Checked)
            {
                lbSeleccionarRamo.Visible = true;
                ddlSeleccionarRamo.Visible = true;
            }
            else
            {
                lbSeleccionarRamo.Visible = false;
                ddlSeleccionarRamo.Visible = false;
            }
        }

        protected void gbProduccionDiaria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbProduccionDiaria.PageIndex = e.NewPageIndex;
            MostrarProduccionDiaria();
        }

        protected void gbProduccionDiaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbCantidadFacturadoTitulo.Visible = false;
            lbCantidadFActuradoVariable.Visible = false;
            lbCantidadFacturadoCerrar.Visible = false;
            lbEncabezado.Visible = false;
            lbCantidadFacturadoPesosTitulo.Visible = false;
            lbCantidadFacturadoPesosVariable.Visible = false;
            lbCantidadFacturadoPesosCerrar.Visible = false;
            MostrarDetalleProduccionDiaria();
        }

        protected void btnBuscarRegistros_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorConsulta();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio", "CampoFechaHastaVacio();", true);
                }
            }
            else
            {
                try
                {
                    lbCantidadFacturadoTitulo.Visible = true;
                    lbCantidadFActuradoVariable.Visible = true;
                    lbCantidadFacturadoCerrar.Visible = true;
                    lbEncabezado.Visible = true;
                    lbCantidadFacturadoPesosTitulo.Visible = true;
                    lbCantidadFacturadoPesosVariable.Visible = true;
                    lbCantidadFacturadoPesosCerrar.Visible = true;
                    MostrarProduccionDiaria();
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
                }
            }
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "ErrorExportar", "ErrorExportar();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio", "CampoFechaHastaVacio();", true);
                }
            }
            else
            {
                try
                {
                    ExportarDataExel();
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorExportar()", true);
                }
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            //REGRESAMOS TODO A ATRAS NUEVAMENTE
            btnAtras.Visible = false;
            btnBuscarRegistros.Enabled = true;
            btnGenerarReporte.Enabled = true;
            gbProduccionDiariaDetalle.Visible = false;
            rbExportarNormal.Visible = false;
            rbExportarDependientes.Visible = false;
            rbExportarNormal.Checked = true;
            gbProduccionDiaria.Visible = true;
            txtFechaDesde.Enabled = true;
            txtFechaHasta.Enabled = true;
            cbExportarTodo.Visible = false;


            lbCantidadFacturadoTitulo.Visible = true;
            lbCantidadFActuradoVariable.Visible = true;
            lbCantidadFacturadoCerrar.Visible = true;
            lbEncabezado.Visible = true;
            lbCantidadFacturadoPesosTitulo.Visible = true;
            lbCantidadFacturadoPesosVariable.Visible = true;
            lbCantidadFacturadoPesosCerrar.Visible = true;

           
        }

        protected void gbProduccionDiariaDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbProduccionDiariaDetalle.PageIndex = e.NewPageIndex;
            MostrarDetalleProduccionDiaria();
        }

        protected void gbProduccionDiariaDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbExportarTodo.Checked)
            {
                if (rbExportarNormal.Checked)
                {
                    try
                    {
                        GridViewRow gb = gbProduccionDiariaDetalle.SelectedRow;

                        //SACAMOS EL CODIGO DEL RAMO
                        int Ramo = 0;

                        var ExportarData = ObjDataLogica.Value.ProduccionDiariaDetalle(
                            null, null, null, null, gb.Cells[0].Text);
                        foreach (var n in ExportarData)
                        {
                            Ramo = Convert.ToInt32(n.CodRamo);
                        }
                        //HACEMOS EL FILTRO PARA EXPORTAR
                        var Exel = (from n in ObjDataLogica.Value.ProduccionDiariaDetalle(
                            Ramo,
                            gb.Cells[3].Text,
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text))
                                    select new
                                    {
                                        Factura = n.Numero,
                                        Poliza = n.Poliza,
                                        FechaFacturacion = n.FechaFacturacion,
                                        Concepto = n.Concepto,
                                        CodRamo = n.CodRamo,
                                        Ramo = n.Ramo,
                                        CodSubramo = n.CodSubramo,
                                        Subramo = n.Subramo,
                                        NombreCliente = n.NombreCliente,
                                        Telefonos = n.Telefonos,
                                        Direccion = n.Direccion,
                                        CodSupervisor = n.CodSupervisor,
                                        Supervisor = n.Supervisor,
                                        CodVendedor = n.CodIntermediario,
                                        Vendedor = n.Vendedor,
                                        TotalFacturado = n.Facturado,
                                        TotalCobrado = n.Cobrado,
                                        BalancePendiente = n.Balance,
                                        Oficina = n.Oficina
                                    }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción Diaria Normal", Exel);
                    }
                    catch (Exception) { }
                }
                else if (rbExportarDependientes.Checked)
                {

                }
            }
            else
            {
                //EXPORTAMOS LOS DATOS A EXEL
                //EXPORTAMOS LOS CAMPOS MOSTRADOS EN EL GRID MAS LOS REGISTROS FALTANTES
                if (rbExportarNormal.Checked)
                {
                    try
                    {
                        GridViewRow gb = gbProduccionDiariaDetalle.SelectedRow;

                        //SACAMOS EL CODIGO DEL RAMO
                        int Ramo = 0;

                        var ExportarData = ObjDataLogica.Value.ProduccionDiariaDetalle(
                            null, null, null, null, gb.Cells[0].Text);
                        foreach (var n in ExportarData)
                        {
                            Ramo = Convert.ToInt32(n.CodRamo);
                        }
                        //HACEMOS EL FILTRO PARA EXPORTAR
                        var Exel = (from n in ObjDataLogica.Value.ProduccionDiariaDetalle(
                            Ramo,
                            gb.Cells[3].Text,
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text),
                            gb.Cells[0].Text)
                                    select new
                                    {
                                        Factura = n.Numero,
                                        Poliza = n.Poliza,
                                        FechaFacturacion = n.FechaFacturacion,
                                        Concepto = n.Concepto,
                                        CodRamo = n.CodRamo,
                                        Ramo = n.Ramo,
                                        CodSubramo = n.CodSubramo,
                                        Subramo = n.Subramo,
                                        NombreCliente = n.NombreCliente,
                                        Telefonos = n.Telefonos,
                                        Direccion = n.Direccion,
                                        CodSupervisor = n.CodSupervisor,
                                        Supervisor = n.Supervisor,
                                        CodVendedor = n.CodIntermediario,
                                        Vendedor = n.Vendedor,
                                        TotalFacturado = n.Facturado,
                                        TotalCobrado = n.Cobrado,
                                        BalancePendiente = n.Balance,
                                        Oficina = n.Oficina
                                    }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción Diaria Normal Detalle", Exel);
                    }
                    catch (Exception) { }




                }
                else if (rbExportarDependientes.Checked)
                {
                    //AQUI EXPORTAMOS LOS DATOS DE LOS DEPENDIENTE SIEMPRE Y CUANDO LAS POLIZAS SELECCIONADAS NO SEAN DE VEHICULO NI DE FIANZAS
                }
            }
        }

        protected void btnExportarTodo_Click(object sender, EventArgs e)
        {

        }

        protected void cbExportarTodo_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void gbProduccionDiaria_DataBound(object sender, EventArgs e)
        {
            
        }

        protected void gbProduccionDiaria_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }
    }
}
 