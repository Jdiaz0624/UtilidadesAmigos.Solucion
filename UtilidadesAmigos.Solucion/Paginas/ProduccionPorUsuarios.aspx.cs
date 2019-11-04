using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Speech.Synthesis;
using System.Threading;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ProduccionPorUsuarios : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        UtilidadesAmigos.Logica.Comunes.VariablesGlobales VariablesGlobales = new Logica.Comunes.VariablesGlobales();


        #region EXPORTAR LOS DATOS DE LA CONSULTA A EXEL CON EL FORMATO DEL GRID
        //public override void VerifyRenderingInServerForm(Control control)
        //{
        //    //
        //}
        //private void ExportGridToExcel()
        //{
        //    gbListadoExportarExel.Visible = true;
        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment;filename=ProduccionUsuarios" + Convert.ToString(txtFechaDesde.Text) + Convert.ToString(txtFechaHasta.Text) + ".xls");
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.ms-excel";
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        HtmlTextWriter hw = new HtmlTextWriter(sw);

        //        //To Export all pages
        //        gbListadoExportarExel.AllowPaging = false;
        //        this.MostrarProduccion();

        //        gbListadoExportarExel.HeaderRow.BackColor = Color.White;
        //        foreach (TableCell cell in gbListadoExportarExel.HeaderRow.Cells)
        //        {
        //            cell.BackColor = gbListadoExportarExel.HeaderStyle.BackColor;
        //        }
        //        foreach (GridViewRow row in gbListadoExportarExel.Rows)
        //        {
        //            row.BackColor = Color.White;
        //            foreach (TableCell cell in row.Cells)
        //            {
        //                if (row.RowIndex % 2 == 0)
        //                {
        //                    cell.BackColor = gbListadoExportarExel.AlternatingRowStyle.BackColor;
        //                }
        //                else
        //                {
        //                    cell.BackColor = gbListadoExportarExel.RowStyle.BackColor;
        //                }
        //                cell.CssClass = "textmode";
        //            }
        //        }

        //        gbListadoExportarExel.RenderControl(hw);

        //        //style to format numbers to string
        //        string style = @"<style> .textmode { } </style>";
        //        Response.Write(style);
        //        Response.Output.Write(sw.ToString());
        //        Response.Flush();
        //        Response.End();
        //    }
        //    gbListadoExportarExel.Visible = false;

        //}
        #endregion

       

     

      

        #region MOSTRAR LA PRODUCCION POR USUARIOS
        private void MostrarProduccion()
        {
            int TipoOperacion = Convert.ToInt32(ddlTipoReporte.SelectedValue);

            if (TipoOperacion == 1)
            {
                //PRODUCCION
                try {
                    if (cbAgregarDepartamentos.Checked && cbAgregarUsuarios.Checked)
                    {
                        var MostrarDatos = ObjData.Value.BuscaProduccionPorUsuarios(
                     Convert.ToDateTime(txtFechaDesde.Text),
                     Convert.ToDateTime(txtFechaHasta.Text),
                     Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue),
                     Convert.ToDecimal(ddlSeleccionarDepartamento.SelectedValue),
                     Convert.ToDecimal(ddlSeleccionarUsuario.SelectedValue));

                        gbListadoUsuarios.DataSource = MostrarDatos;
                        gbListadoUsuarios.DataBind();
                        gbListadoUsuarios.Visible = true;
                      
                    }
                    else if (cbAgregarDepartamentos.Checked)
                    {
                        var MostrarDatos = ObjData.Value.BuscaProduccionPorUsuarios(
                      Convert.ToDateTime(txtFechaDesde.Text),
                      Convert.ToDateTime(txtFechaHasta.Text),
                      Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue),
                      Convert.ToDecimal(ddlSeleccionarDepartamento.SelectedValue));

                        gbListadoUsuarios.DataSource = MostrarDatos;
                        gbListadoUsuarios.DataBind();
                        gbListadoUsuarios.Visible = true;
                    }
                    else
                    {
                        var MostrarDatos = ObjData.Value.BuscaProduccionPorUsuarios(
                       Convert.ToDateTime(txtFechaDesde.Text),
                       Convert.ToDateTime(txtFechaHasta.Text),
                       Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue));

                        gbListadoUsuarios.DataSource = MostrarDatos;
                        gbListadoUsuarios.DataBind();
                        gbListadoUsuarios.Visible = true;
                    }

                }
                catch (Exception) { }
            }
            else if (TipoOperacion == 2)
            {
                //COBROS
                if (cbAgregarDepartamentos.Checked && cbAgregarUsuarios.Checked)
                {
                    try {
                        var SacarCobrado = ObjData.Value.SacarCobrado(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text),
                            Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue),
                            Convert.ToDecimal(ddlSeleccionarDepartamento.SelectedValue),
                            Convert.ToDecimal(ddlSeleccionarUsuario.SelectedValue));
                        gbListadoUsuarios.DataSource = SacarCobrado;
                        gbListadoUsuarios.DataBind();
                        gbListadoUsuarios.Visible = true;
                    }
                    catch (Exception) { }
                }
                else if (cbAgregarDepartamentos.Checked)
                {
                    try
                    {
                        var SacarCobrado = ObjData.Value.SacarCobrado(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text),
                            Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue),
                            Convert.ToDecimal(ddlSeleccionarDepartamento.SelectedValue));
                        gbListadoUsuarios.DataSource = SacarCobrado;
                        gbListadoUsuarios.DataBind();
                        gbListadoUsuarios.Visible = true;
                    }
                    catch (Exception) { }
                }
                else
                {
                    try
                    {
                        var SacarCobrado = ObjData.Value.SacarCobrado(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text),
                            Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue));
                        gbListadoUsuarios.DataSource = SacarCobrado;
                        gbListadoUsuarios.DataBind();
                        gbListadoUsuarios.Visible = true;
                    }
                    catch (Exception) { }
                }
            }
            else if (TipoOperacion == 3)
            {
                //RECLAMACIONES
            }
        }
        #endregion

        #region MOSTRAR EL DETALLE DE LA BUSQUEDA
        private void MostrarDetalle()
        {
            //Seleccionamos Los Registros
            GridViewRow gb = gbListadoUsuarios.SelectedRow;
            int TipoOperacion = Convert.ToInt32(ddlTipoReporte.SelectedValue);
            if (TipoOperacion == 1)
            {
                gbListadoUsuarios.Visible = false;
                gbDetalle.Visible = true;
                var SacarInformacion = ObjData.Value.BuscaDetalleFacturacion(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    gb.Cells[2].Text,
                    gb.Cells[3].Text);
                gbDetalle.DataSource = SacarInformacion;
                gbDetalle.DataBind();
            }
            else if (TipoOperacion == 2)
            {

            }
            else if (TipoOperacion == 3)
            {

            }

       
           
        }
        #endregion

        #region SACAR LOS DATOS DEL ENCABEZADO Y EL CUERPO
        private void SacarDatosEncabezado(string Poliza)
        {
            VariablesGlobales.PolizaDetalle = Poliza;
            var SacarDatos = ObjData.Value.SacarDatosEncabezado(Poliza);
            foreach (var n in SacarDatos)
            {
                txtFechaInicioVigenciaDetalle.Text = n.InicioVigencia;
                txtFechaFinVigenciaDetalle.Text = n.FinVigencia;
                txtNombreClienteDetalle.Text = n.Cliente;
                txtTipoIdentificacionDetalle.Text = n.TipoIdentificacion;
                txtIdentificacionDetalle.Text = n.Identificacion;
                txtDireccionDetalle.Text = n.Direccion;
                txtCiudadDetalle.Text = n.Ciudad;
                txtOficinaDetalle.Text = n.Oficina;
                txtTelefonoResidenciaDetalle.Text = n.TelefonoResidencia;
                txtTelefonoOficinaDetalle.Text = n.TelefonoOficina;
                txtCelularDetalle.Text = n.Celular;
                txtSupervisorDetalle.Text = n.Supervisor;
                txtIntermediarioDetalle.Text = n.Intermdiario;
                txtTotalFacturado.Text = n.Facturado.ToString();
                txtTotalCobradoDetalle.Text = n.Cobrado.ToString();
                txtBalanceDetalle.Text = n.Balance.ToString();
                txtRamoDetalle.Text = n.Ramo;
                txtPolizaDetalle.Text = n.Poliza;

                var SacarSubRamo = ObjData.Value.SacarSubRamoDetalle(Poliza);
                ddlSubRamoDetalle.DataSource = SacarSubRamo;
                ddlSubRamoDetalle.DataValueField = "SubRamo";
                ddlSubRamoDetalle.DataTextField = "Descripcion";
                ddlSubRamoDetalle.DataBind();


                SacarItems();

                //SACAMOS EL RAMO DE LA POLIZA
                int Ramo = 0;

                var SacarRamo = ObjData.Value.SacarRamoPoliza(
                    txtPolizaDetalle.Text);
                foreach (var n2 in SacarRamo)
                {
                    Ramo = Convert.ToInt32(n2.Ramo);
                }

                //verificamos el tipo de ramo y de hay mandamos amostrar los tipos de datos
                if (Ramo == 106)
                {
                    MostrarControlesDetalle();
                    SacarDatosVehiculoDetalle(
                        txtPolizaDetalle.Text,
                        Ramo,
                        Convert.ToInt32(ddlSubRamoDetalle.SelectedValue),
                        Convert.ToInt32(ddlItemDetalle.SelectedValue));
                }
                else
                {
                    SacarDatosDepedientes();
                }
                
            }
        }

        #endregion

        #region MOSTRAR Y OCULTAR CONTROLES
        private void OcultarCOntrolesHeader()
        {
            lbPolizaDetalle.Visible = false;
            txtPolizaDetalle.Visible = false;
            lbFechaInicioVigencia.Visible = false;
            txtFechaInicioVigenciaDetalle.Visible = false;
            lbFechaFinVigenciaDetalle.Visible = false;
            txtFechaFinVigenciaDetalle.Visible = false;
            lbNombreClienteDetalle.Visible = false;
            txtNombreClienteDetalle.Visible = false;
            lbTipoIdentificacionDetalle.Visible = false;
            txtTipoIdentificacionDetalle.Visible = false;
            lbIdentificacionDetalle.Visible = false;
            txtIdentificacionDetalle.Visible = false;
            lbDireccionDetalle.Visible = false;
            txtDireccionDetalle.Visible = false;
            lbCiudadDetalle.Visible = false;
            txtCiudadDetalle.Visible = false;
            lbOficinaDetalle.Visible = false;
            txtOficinaDetalle.Visible = false;
            lbTelefonoResidenciaDetalle.Visible = false;
            txtTelefonoResidenciaDetalle.Visible = false;
            lbTelefonoOficina.Visible = false;
            txtTelefonoOficinaDetalle.Visible = false;
            lbCelularDetalle.Visible = false;
            txtCelularDetalle.Visible = false;
            lbSupervisorDetalle.Visible = false;
            txtSupervisorDetalle.Visible = false;
            lbIntermediarioDetalle.Visible = false;
            txtIntermediarioDetalle.Visible = false;
            lbTotalFacturadoDetalle.Visible = false;
            txtTotalFacturado.Visible = false;
            lbTotalCobradoDetalle.Visible = false;
            txtTotalCobradoDetalle.Visible = false;
            lbBalanceDetalle.Visible = false;
            txtBalanceDetalle.Visible = false;
            lbRamoDetalle.Visible = false;
            txtRamoDetalle.Visible = false;
            lbSubramoDetalle.Visible = false;
            ddlSubRamoDetalle.Visible = false;
            lbItemDetalle.Visible = false;
            ddlItemDetalle.Visible = false;
        }
        private void MostrarControlesGridHeader()
        {
            lbPolizaDetalle.Visible = true;
            txtPolizaDetalle.Visible = true;
            lbFechaInicioVigencia.Visible = true;
            txtFechaInicioVigenciaDetalle.Visible = true;
            lbFechaFinVigenciaDetalle.Visible = true;
            txtFechaFinVigenciaDetalle.Visible = true;
            lbNombreClienteDetalle.Visible = true;
            txtNombreClienteDetalle.Visible = true;
            lbTipoIdentificacionDetalle.Visible = true;
            txtTipoIdentificacionDetalle.Visible = true;
            lbIdentificacionDetalle.Visible = true;
            txtIdentificacionDetalle.Visible = true;
            lbDireccionDetalle.Visible = true;
            txtDireccionDetalle.Visible = true;
            lbCiudadDetalle.Visible = true;
            txtCiudadDetalle.Visible = true;
            lbOficinaDetalle.Visible = true;
            txtOficinaDetalle.Visible = true;
            lbTelefonoResidenciaDetalle.Visible = true;
            txtTelefonoResidenciaDetalle.Visible = true;
            lbTelefonoOficina.Visible = true;
            txtTelefonoOficinaDetalle.Visible = true;
            lbCelularDetalle.Visible = true;
            txtCelularDetalle.Visible = true;
            lbSupervisorDetalle.Visible = true;
            txtSupervisorDetalle.Visible = true;
            lbIntermediarioDetalle.Visible = true;
            txtIntermediarioDetalle.Visible = true;
            lbTotalFacturadoDetalle.Visible = true;
            txtTotalFacturado.Visible = true;
            lbTotalCobradoDetalle.Visible = true;
            txtTotalCobradoDetalle.Visible = true;
            lbBalanceDetalle.Visible = true;
            txtBalanceDetalle.Visible = true;
            lbRamoDetalle.Visible = true;
            txtRamoDetalle.Visible = true;
            lbSubramoDetalle.Visible = true;
            ddlSubRamoDetalle.Visible = true;
            lbItemDetalle.Visible = true;
            ddlItemDetalle.Visible = true;
        }

        private void OcultarCOntrolesDetalle()
        {
            lbSumaAseguradaDetalle.Visible = false;
            txtSumaAseguradaDetalle.Visible = false;
            lbTipoVehiculoDetalle.Visible = false;
            txtTipoVehiculoDetalle.Visible = false;
            lbMarcaDetalle.Visible = false;
            txtMarcaDetalle.Visible = false;
            lbModeloDetalle.Visible = false;
            txtModeloDetalle.Visible = false;
            lbUsoDetalle.Visible = false;
            txtUsoDetalle.Visible = false;
            lbCOlorDetalle.Visible = false;
            txtColorDetalle.Visible = false;
            lbAnoDetalle.Visible = false;
            txtAnoDetalle.Visible = false;
            lbValorVehiculoDetalle.Visible = false;
            txtValorVehiculoDetalle.Visible = false;
            lbChasisDetalle.Visible = false;
            txtChasisDetalle.Visible = false;
            lbPlacaDetalle.Visible = false;
            txtPlacaDetalle.Visible = false;
        }
        private void MostrarControlesDetalle()
        {
            lbSumaAseguradaDetalle.Visible = true;
            txtSumaAseguradaDetalle.Visible = true;
            lbTipoVehiculoDetalle.Visible = true;
            txtTipoVehiculoDetalle.Visible = true;
            lbMarcaDetalle.Visible = true;
            txtMarcaDetalle.Visible = true;
            lbModeloDetalle.Visible = true;
            txtModeloDetalle.Visible = true;
            lbUsoDetalle.Visible = true;
            txtUsoDetalle.Visible = true;
            lbCOlorDetalle.Visible = true;
            txtColorDetalle.Visible = true;
            lbAnoDetalle.Visible = true;
            txtAnoDetalle.Visible = true;
            lbValorVehiculoDetalle.Visible = true;
            txtValorVehiculoDetalle.Visible = true;
            lbChasisDetalle.Visible = true;
            txtChasisDetalle.Visible = true;
            lbPlacaDetalle.Visible = true;
            txtPlacaDetalle.Visible = true;
        }

        private void DeshabilitarControlesBusqueda()
        {
            ddlTipoReporte.Enabled = false;
            txtFechaDesde.Enabled = false;
            txtFechaHasta.Enabled = false;
            ddlSeleccionarDepartamento.Enabled = false;
            ddlSeleccionarOficina.Enabled = false;
            ddlSeleccionarUsuario.Enabled = false;
            btnBuscarRegistros.Enabled = false;
            btnGenerarReporte.Enabled = false;
            btnAtras.Visible = true;
        }
        private void HabilitarControlesBusqueda()
        {
            ddlTipoReporte.Enabled = true;
            txtFechaDesde.Enabled = true;
            txtFechaHasta.Enabled = true;
            ddlSeleccionarDepartamento.Enabled = true;
            ddlSeleccionarOficina.Enabled = true;
            ddlSeleccionarUsuario.Enabled = true;
            btnBuscarRegistros.Enabled = true;
            btnGenerarReporte.Enabled = true;
            btnAtras.Visible = false;
            gbListadoOtrosRamos.Visible = false;
            OcultarCOntrolesDetalle();
            OcultarCOntrolesHeader();
            gbDetalle.Visible = false;
            gbListadoUsuarios.Visible = true;
        }
        #endregion

        #region Sacar Item
        private void SacarItems()
        {
            var CargarItemsPoliza = ObjData.Value.SacarItemsPoliza(
               txtPolizaDetalle.Text,
               txtRamoDetalle.Text,
               Convert.ToInt32(ddlSubRamoDetalle.SelectedValue));
            ddlItemDetalle.DataSource = CargarItemsPoliza;
            ddlItemDetalle.DataValueField = "Item";
            ddlItemDetalle.DataTextField = "ItemLetra";
            ddlItemDetalle.DataBind();
        }
        #endregion

        #region SACAR LOS DATOS DEL DETALLE
        //SACAMOS LOS DATOS DEL VEHICULO
        private void SacarDatosVehiculoDetalle(string Poliza, int Ramo, int Subramo, int Secuencia)
        {
            var SacarDatos = ObjData.Value.SacarDatosVehiculosDetalle(
                Poliza, Ramo, Subramo, Secuencia);
            foreach (var n in SacarDatos)
            {
                txtSumaAseguradaDetalle.Text = n.SumaAsegurada.ToString();
                txtTipoVehiculoDetalle.Text = n.TipoVehiculo;
                txtMarcaDetalle.Text = n.Marca;
                txtModeloDetalle.Text = n.Modelo;
                txtUsoDetalle.Text = n.Uso;
                txtColorDetalle.Text = n.Color;
                txtAnoDetalle.Text = n.Ano;
                txtValorVehiculoDetalle.Text = n.ValorVehiculo.ToString();
                txtChasisDetalle.Text = n.Chasis;
                txtPlacaDetalle.Text = n.Placa;
            }
        }
        #endregion

        #region SACAR LOS DATOS DE LOS DEPENDIENTES
        private void SacarDatosDepedientes()
        {
            gbListadoOtrosRamos.Visible = true;
            var SacarDatos = ObjData.Value.SacarDependientes(
                txtPolizaDetalle.Text);
            gbListadoOtrosRamos.DataSource = SacarDatos;
            gbListadoOtrosRamos.DataBind();
        }
        #endregion

        #region VOZ
        private void Voz()
        {
            //voz
            Thread tarea = new Thread(new ParameterizedThreadStart(UtilidadesAmigos.Logica.Comunes.VozVeronica.Hablar));
            tarea.Start("Produccion Por usuario exportada corrextamente");
        }
#endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                OcultarCOntrolesHeader();
                OcultarCOntrolesDetalle();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoReporte, ObjData.Value.BuscaListas("TIPOOPERACION", null, null));
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficina, ObjData.Value.BuscaListas("OFICINA", null, null));
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarDepartamento, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlSeleccionarOficina.SelectedValue.ToString(), null), true);
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarUsuario, ObjData.Value.BuscaListas("EMPLEADO", ddlSeleccionarOficina.SelectedValue.ToString(), ddlSeleccionarDepartamento.SelectedValue.ToString()), true);
            }
        }

        protected void btnBuscarRegistros_Click(object sender, EventArgs e)
        {
            MostrarProduccion();
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            //EXPORTAMOS LOS DATOS A EXEL
            int TipoOperacion = Convert.ToInt32(ddlTipoReporte.SelectedValue);
            if (TipoOperacion == 1)
            {
                string Nombre = "";   
                if (cbAgregarDepartamentos.Checked && cbAgregarUsuarios.Checked)
                {
                    try {
                        var Exportar = (from n in ObjData.Value.BuscaProduccionPorUsuarios(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue),
                        Convert.ToDecimal(ddlSeleccionarDepartamento.SelectedValue),
                        Convert.ToDecimal(ddlSeleccionarUsuario.SelectedValue))
                                        select new
                                        {
                                            Oficina = n.Oficina,
                                            Departamento = n.Departamento,
                                            Usuario = n.Usuario,
                                            Concepto = n.Concepto,
                                            Cantidad = n.Cantidad,
                                            FechaDesde = n.FechaDesde,
                                            FechaHasta = n.FechaHasta,
                                            Nombre = n.Usuario
                                        }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion de " + Nombre + txtFechaDesde.Text + " - " + txtFechaHasta.Text, Exportar);
                        Voz();
                    }
                    catch (Exception) { }

                }
                else if (cbAgregarDepartamentos.Checked)
                {
                    try
                    {
                        var Exportar = (from n in ObjData.Value.BuscaProduccionPorUsuarios(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue),
                        Convert.ToDecimal(ddlSeleccionarDepartamento.SelectedValue))
                                        select new
                                        {
                                            Oficina = n.Oficina,
                                            Departamento = n.Departamento,
                                            Usuario = n.Usuario,
                                            Concepto = n.Concepto,
                                            Cantidad = n.Cantidad,
                                            FechaDesde = n.FechaDesde,
                                            FechaHasta = n.FechaHasta,
                                            Nombre = n.Usuario
                                        }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion por usuario Por Departamento " + txtFechaDesde.Text + " - " + txtFechaHasta.Text, Exportar);
                        Voz();
                    }
                    catch (Exception) { }
                }
                else
                {
                    try
                    {
                        var Exportar = (from n in ObjData.Value.BuscaProduccionPorUsuarios(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue))
                                        select new
                                        {
                                            Oficina = n.Oficina,
                                            Departamento = n.Departamento,
                                            Usuario = n.Usuario,
                                            Concepto = n.Concepto,
                                            Cantidad = n.Cantidad,
                                            FechaDesde = n.FechaDesde,
                                            FechaHasta = n.FechaHasta,
                                            Nombre = n.Usuario
                                        }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion Por Usuario general " + txtFechaDesde.Text + " - " + txtFechaHasta.Text, Exportar);
                        Voz();
                    }
                    catch (Exception) { }
                }
               
            }
            else if (TipoOperacion == 2)
            {
                //EXPORTAMOS A EXEL LA PARTE DE LOS COBROS
                if (cbAgregarDepartamentos.Checked && cbAgregarUsuarios.Checked)
                {
                    try {
                        var ExportaCobros = (from n in ObjData.Value.SacarCobrado(
                       Convert.ToDateTime(txtFechaDesde.Text),
                       Convert.ToDateTime(txtFechaHasta.Text),
                       Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue),
                       Convert.ToDecimal(ddlSeleccionarDepartamento.SelectedValue),
                       Convert.ToDecimal(ddlSeleccionarUsuario.SelectedValue))
                                             select new
                                             {
                                                 Oficina = n.Oficina,
                                                 Departamento = n.Departamento,
                                                 Usuario = n.Usuario,
                                                 Concepto = n.Concepto,
                                                 Cantidad = n.Cantidad
                                             }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Reporte de lo Cobrado Por Oficina", ExportaCobros);
                        Voz();
                    }
                    catch (Exception) { }
                }
                else if (cbAgregarDepartamentos.Checked)
                {
                    try
                    {
                        var ExportaCobros = (from n in ObjData.Value.SacarCobrado(
                       Convert.ToDateTime(txtFechaDesde.Text),
                       Convert.ToDateTime(txtFechaHasta.Text),
                       Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue),
                       Convert.ToDecimal(ddlSeleccionarDepartamento.SelectedValue))
                                             select new
                                             {
                                                 Oficina = n.Oficina,
                                                 Departamento = n.Departamento,
                                                 Usuario = n.Usuario,
                                                 Concepto = n.Concepto,
                                                 Cantidad = n.Cantidad
                                             }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Reporte de lo Cobrado Por Oficina", ExportaCobros);
                        Voz();
                    }
                    catch (Exception) { }
                }
                else
                {
                    try
                    {
                        var ExportaCobros = (from n in ObjData.Value.SacarCobrado(
                       Convert.ToDateTime(txtFechaDesde.Text),
                       Convert.ToDateTime(txtFechaHasta.Text),
                       Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue))
                                             select new
                                             {
                                                 Oficina = n.Oficina,
                                                 Departamento = n.Departamento,
                                                 Usuario = n.Usuario,
                                                 Concepto = n.Concepto,
                                                 Cantidad = n.Cantidad
                                             }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Reporte de lo Cobrado Por Oficina", ExportaCobros);
                        Voz();
                    }
                    catch (Exception) { }
                }
            }
            else if (TipoOperacion == 3)
            {
                //EXPORTAMOS A EXEL LA PARTE DE LAS RECLAMACIONES
            }
            }

        protected void gbListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbListadoUsuarios.PageIndex = e.NewPageIndex;
            MostrarProduccion();
        }

        protected void rbConDepartamento_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void rbSinDepartamento_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        protected void ddlSeleccionarDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSeleccionarOficina_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cbAgregarUsuarios_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        protected void cbAgregarOficina_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        protected void ddlSeleccionarOficina_SelectedIndexChanged1(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarDepartamento, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlSeleccionarOficina.SelectedValue.ToString(), null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarUsuario, ObjData.Value.BuscaListas("EMPLEADO", ddlSeleccionarOficina.SelectedValue.ToString(), ddlSeleccionarDepartamento.SelectedValue.ToString()), true);
        }

        protected void ddlSeleccionarDepartamento_SelectedIndexChanged1(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarUsuario, ObjData.Value.BuscaListas("EMPLEADO", ddlSeleccionarOficina.SelectedValue.ToString(), ddlSeleccionarDepartamento.SelectedValue.ToString()), true);
        }

        protected void gbListadoUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            MostrarDetalle();
            DeshabilitarControlesBusqueda();
        }

        protected void ddlTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        protected void gbDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbDetalle.PageIndex = e.NewPageIndex;
            MostrarDetalle();
        }

        protected void gbDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcultarCOntrolesDetalle();
            OcultarCOntrolesHeader();
            GridViewRow gb = gbDetalle.SelectedRow;
            MostrarControlesGridHeader();
            SacarDatosEncabezado(gb.Cells[4].Text);
        }

        protected void ddlSubRamoDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            SacarItems();
            int Ramo = 0;
            var SacarRamo = ObjData.Value.SacarRamoPoliza(txtPolizaDetalle.Text);
            foreach (var n in SacarRamo)
            {
                Ramo = Convert.ToInt32(n.Ramo);
            }
            SacarDatosVehiculoDetalle(
                        txtPolizaDetalle.Text,
                        Ramo,
                        Convert.ToInt32(ddlSubRamoDetalle.SelectedValue),
                        Convert.ToInt32(ddlItemDetalle.SelectedValue));
        }

        protected void ddlItemDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Ramo = 0;
            var SacarRamo = ObjData.Value.SacarRamoPoliza(txtPolizaDetalle.Text);
            foreach (var n in SacarRamo)
            {
                Ramo = Convert.ToInt32(n.Ramo);
            }
            SacarDatosVehiculoDetalle(
                        txtPolizaDetalle.Text,
                        Ramo,
                        Convert.ToInt32(ddlSubRamoDetalle.SelectedValue),
                        Convert.ToInt32(ddlItemDetalle.SelectedValue));
        }

        protected void gbListadoOtrosRamos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gbListadoOtrosRamos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            HabilitarControlesBusqueda();
        }

        protected void gbListadoExportarExel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gbListadoExportarExel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cbAgregarDepartamentos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAgregarDepartamentos.Checked)
            {
                cbAgregarUsuarios.Enabled = true;
                ddlSeleccionarDepartamento.Visible = true;
            }
            else
            {
                cbAgregarUsuarios.Enabled = false;
                cbAgregarUsuarios.Checked = false;
                ddlSeleccionarUsuario.Visible = false;
                ddlSeleccionarDepartamento.Visible = false;
            }
        }

        protected void cbAgregarUsuarios_CheckedChanged1(object sender, EventArgs e)
        {
            if (cbAgregarUsuarios.Checked)
            {
                ddlSeleccionarUsuario.Visible = true;
            }
            else
            {
                ddlSeleccionarUsuario.Visible = false;
            }
        }
    }
}