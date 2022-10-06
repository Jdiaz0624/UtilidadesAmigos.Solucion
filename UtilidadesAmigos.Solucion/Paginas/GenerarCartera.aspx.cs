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
                   // var _CodIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
                    var Listado = ObjData.Value.SacarCarteraSupervisor(
                   Convert.ToDecimal(txtCodigoSupervisor.Text),
                   null,
                   txtNombreIntermediario.Text);
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
        #region CARGAR LAS LISTAS DESPLEGABLES DE LA PRODUCCION
        private void CargarRamosProduccion()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamoProduccion, ObjData.Value.BuscaListas("RAMO", null, null), true);
        }
        private void CargarSubramosProduccion()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSubRamoProduccion, ObjData.Value.BuscaListas("SUBRAMO", ddlSeleccionarRamoProduccion.SelectedValue, null), true);
        }
        private void CargarExliirProduccion() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlExcluirMotoresProduccion, ObjData.Value.BuscaListas("EXCLUIR", null, null));
        }
        #endregion
        #region BUSCAR PRODUCCION
        private void BuscarProduccionSupervisor() {
            try {
                int? _Ramo = ddlSeleccionarRamoProduccion.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoProduccion.SelectedValue) : new Nullable<int>();
                int? _SubRamo = ddlSeleccionarSubRamoProduccion.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamoProduccion.SelectedValue) : new Nullable<int>();
                decimal TotalFacturado = 0;
                if (Convert.ToInt32(ddlSeleccionarRamoProduccion.SelectedValue) == 106 && Convert.ToInt32(ddlExcluirMotoresProduccion.SelectedValue) == 2)
                {
                    //BUSCAMOS SIN MOTORES
                    var Buscar = ObjData.Value.SacarProduccionSupervisor(
                        Convert.ToInt32(txtCodigoSupervisor.Text),
                        null,
                        _Ramo,
                        _SubRamo,
                        Convert.ToDateTime(txtFechaDesdeProduccion.Text),
                        Convert.ToDateTime(txtFechaHastaProduccion.Text),
                        1);
                    gvProduccion.DataSource = Buscar;
                    gvProduccion.DataBind();
                    foreach (var n in Buscar) {
                        TotalFacturado = Convert.ToDecimal(n.TotalFacturado);
                        lbTotalFacturadoVariableProduccion.Text = TotalFacturado.ToString("N2");
                    }

                }
                else
                {
                    //BUSCAMOS CON MOTORES
                    var Buscar = ObjData.Value.SacarProduccionSupervisor(
                        Convert.ToInt32(txtCodigoSupervisor.Text),
                        null,
                        _Ramo,
                        _SubRamo,
                        Convert.ToDateTime(txtFechaDesdeProduccion.Text),
                        Convert.ToDateTime(txtFechaHastaProduccion.Text),
                        2);
                    gvProduccion.DataSource = Buscar;
                    gvProduccion.DataBind();
                    foreach (var n in Buscar)
                    {
                        TotalFacturado = Convert.ToDecimal(n.TotalFacturado);
                        lbTotalFacturadoVariableProduccion.Text = TotalFacturado.ToString("N2");
                    }
                }
            }
            catch (Exception) { }
        }
        private void ExportarProduccionSupervisor() {
            int? _Ramo = ddlSeleccionarRamoProduccion.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoProduccion.SelectedValue) : new Nullable<int>();
            int? _SubRamo = ddlSeleccionarSubRamoProduccion.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamoProduccion.SelectedValue) : new Nullable<int>();
            try
            {
                if (Convert.ToInt32(ddlSeleccionarRamoProduccion.SelectedValue) == 106 && Convert.ToInt32(ddlExcluirMotoresProduccion.SelectedValue) == 2)
                {
                    var Exportar = (from n in ObjData.Value.SacarProduccionSupervisor(
                        Convert.ToInt32(txtCodigoSupervisor.Text),
                        null,
                        _Ramo,
                        _SubRamo,
                        Convert.ToDateTime(txtFechaDesdeProduccion.Text),
                        Convert.ToDateTime(txtFechaHastaProduccion.Text),
                        1)
                                    select new
                                    {
                                        Poliza = n.Poliza,
                                        Estatus = n.Estatus,
                                        Prima = n.Prima,
                                        SumaAsegurada = n.SumaAsegurada,
                                        InicioVigencia = n.InicioVigencia,
                                        FinVigencia = n.FinVigencia,
                                        CodRamo = n.CodRamo,
                                        Ramo = n.Ramo,
                                        CodSubRamo = n.CodSubRamo,
                                        Subramo = n.Subramo,
                                        CodCliente = n.CodCliente,
                                        Cliente = n.Cliente,
                                        CodSupervisor = n.CodSupervisor,
                                        Supervisor = n.Supervisor,
                                        CodIntermediario = n.CodIntermediario,
                                        Intermediario = n.Intermediario,
                                        Fecha = n.Fecha,
                                        Valor = n.Valor,
                                        Numero = n.Numero,
                                        Concepto = n.Concepto,
                                        CreadoPor = n.CreadoPor,
                                        Facturado = n.Facturado,
                                        Cobrado = n.Cobrado,
                                        Balance = n.Balance
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion por supervisor", Exportar);
                }
                else
                {
                    var Exportar = (from n in ObjData.Value.SacarProduccionSupervisor(
                           Convert.ToInt32(txtCodigoSupervisor.Text),
                           null,
                           _Ramo,
                           _SubRamo,
                           Convert.ToDateTime(txtFechaDesdeProduccion.Text),
                           Convert.ToDateTime(txtFechaHastaProduccion.Text),
                           2)
                                    select new
                                    {
                                        Poliza = n.Poliza,
                                        Estatus = n.Estatus,
                                        Prima = n.Prima,
                                        SumaAsegurada = n.SumaAsegurada,
                                        InicioVigencia = n.InicioVigencia,
                                        FinVigencia = n.FinVigencia,
                                        CodRamo = n.CodRamo,
                                        Ramo = n.Ramo,
                                        CodSubRamo = n.CodSubRamo,
                                        Subramo = n.Subramo,
                                        CodCliente = n.CodCliente,
                                        Cliente = n.Cliente,
                                        CodSupervisor = n.CodSupervisor,
                                        Supervisor = n.Supervisor,
                                        CodIntermediario = n.CodIntermediario,
                                        Intermediario = n.Intermediario,
                                        Fecha = n.Fecha,
                                        Valor = n.Valor,
                                        Numero = n.Numero,
                                        Concepto = n.Concepto,
                                        CreadoPor = n.CreadoPor,
                                        Facturado = n.Facturado,
                                        Cobrado = n.Cobrado,
                                        Balance = n.Balance
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion por supervisor", Exportar);

                }
            }
            catch (Exception) { }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRamosProduccion();
                CargarSubramosProduccion();
                CargarExliirProduccion();
                ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            //if (cbComicion.Checked)
            //{
            //    if (cbAgregarOficina.Checked)
            //    {
            //        try {
            //            var BuscarComisiones = ObjData.Value.ComisionesSupervisores(
            //              Convert.ToDateTime(txtFechaDesde.Text),
            //              Convert.ToDateTime(txtFechaHasta.Text),
            //              Convert.ToDecimal(txtCodigoSupervisor.Text),
            //              Convert.ToInt32(ddlSeleccionaroficina.SelectedValue));
            //            foreach (var n in BuscarComisiones)
            //            {
            //                lbNombreSupervisor.Visible = true;
            //                lbNombreSupervisor.Text = n.Supervisor;
            //            }
            //            gbListadoComisiones.DataSource = BuscarComisiones;
            //            gbListadoComisiones.DataBind();

            //            //SACAMOS EL MONTO
            //            var SacarMonto = ObjData.Value.SacarmontoComisiones(
            //              Convert.ToDateTime(txtFechaDesde.Text),
            //              Convert.ToDateTime(txtFechaHasta.Text),
            //              Convert.ToDecimal(txtCodigoSupervisor.Text),
            //              Convert.ToInt32(ddlSeleccionaroficina.SelectedValue));
            //            foreach (var n in SacarMonto)
            //            {
            //                lbNombreSupervisor.Visible = true;
            //                lbMontoComisionPagar.Text = n.ComisionPagar.ToString();
            //            }
            //        }
            //        catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true); }
            //    }
            //    else
            //    {
            //        try {
            //           // decimal? _Supervisor = Convert.ToDecimal(string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim());
            //            var BuscarComisiones = ObjData.Value.ComisionesSupervisores(
            //                Convert.ToDateTime(txtFechaDesde.Text),
            //                Convert.ToDateTime(txtFechaHasta.Text),
            //                Convert.ToDecimal(txtCodigoSupervisor.Text),
            //                null);
            //            foreach (var n in BuscarComisiones)
            //            {
            //                lbNombreSupervisor.Visible = true;
            //                lbNombreSupervisor.Text = n.Supervisor;
            //            }
            //            gbListadoComisiones.DataSource = BuscarComisiones;
            //            gbListadoComisiones.DataBind();

            //            //SACAR MONTO
            //            var SacarMonto = ObjData.Value.SacarmontoComisiones(
            //              Convert.ToDateTime(txtFechaDesde.Text),
            //              Convert.ToDateTime(txtFechaHasta.Text),
            //              Convert.ToDecimal(txtCodigoSupervisor.Text),
            //              null);
            //            foreach (var n in SacarMonto)
            //            {
            //                lbMontoComisionPagar.Text = n.ComisionPagar.ToString();
            //            }
            //        }
            //        catch (Exception) {
            //            ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true);
            //        }
            //    }

            //}
            //else
            //{
            //    MostrarCartera();
            //}
            //ClientScript.RegisterStartupScript(GetType(), "DesbloquearBotones", "DesbloquearBotones();", true);
            //txtCodigoSupervisor.Enabled = false;
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
                //lbCodigoIntermediario.Visible = false;
                //txtCodigoIntermediario.Visible = false;
                lbNombreIntermediario.Visible = false;
                txtNombreIntermediario.Visible = false;
                lbMontoComisionPagar.Text = "000000";
                lbEncabezado.Text = "Generar Comisiones";
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
                //lbCodigoIntermediario.Visible = true;
                //txtCodigoIntermediario.Visible = true;
                lbNombreIntermediario.Visible = true;
                txtNombreIntermediario.Visible = true;
                lbEncabezado.Text = "Cartera de Supervisores";
            }
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void gbListadoCarteraSupervisor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbListadoCarteraSupervisor.PageIndex = e.NewPageIndex;
            MostrarCartera();
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
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
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            //if (cbComicion.Checked)
            //{
            //    if (cbAgregarOficina.Checked)
            //    {
            //        try
            //        {
            //            var Exportar = (from n in ObjData.Value.ComisionesSupervisores(
            //         Convert.ToDateTime(txtFechaDesde.Text),
            //         Convert.ToDateTime(txtFechaHasta.Text),
            //         Convert.ToDecimal(txtCodigoSupervisor.Text),
            //         Convert.ToInt32(ddlSeleccionaroficina.SelectedValue))
            //                            select new
            //                            {
            //                                Supervisor = n.Supervisor,
            //                                Intermediario = n.Intermediario,
            //                                Factura = n.Numero,
            //                                Valor = n.Valor,
            //                                Oficina = n.Oficina,
            //                                Fecha = n.Fecha,
            //                                Concepto = n.Concepto,
            //                                PorcientoComision = n.__Comision,
            //                                ComisionPagar = n.ComisionPagar,
            //                                ValidadoDesde = n.ValidadoDesde,
            //                                ValidadoHasta = n.ValidadoHasta
            //                            }).ToList();
            //            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comision Supervisor", Exportar);
            //        }
            //        catch (Exception) { }
            //    }
            //    else
            //    {
            //        try {
            //            var Exportar = (from n in ObjData.Value.ComisionesSupervisores(
            //         Convert.ToDateTime(txtFechaDesde.Text),
            //         Convert.ToDateTime(txtFechaHasta.Text),
            //         Convert.ToDecimal(txtCodigoSupervisor.Text),
            //         null)
            //                            select new
            //                            {
            //                                Supervisor =n.Supervisor,
            //                                Intermediario=n.Intermediario,
            //                                Factura=n.Numero,
            //                                Valor=n.Valor,
            //                                Oficina=n.Oficina,
            //                                Fecha=n.Fecha,
            //                                Concepto =n.Concepto,
            //                                PorcientoComision=n.__Comision,
            //                                ComisionPagar=n.ComisionPagar,
            //                                ValidadoDesde=n.ValidadoDesde,
            //                                ValidadoHasta=n.ValidadoHasta
            //                            }).ToList();
            //            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comision Supervisor", Exportar);
            //        }
            //        catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true); }
            //    }
            //}
            //else
            //{
            //    try {

            //        var Exportar = (from n in ObjData.Value.SacarCarteraSupervisor(
            //      Convert.ToDecimal(txtCodigoSupervisor.Text))
            //                        select new
            //                        {
            //                            Supervisor = n.Supervisor,
            //                            Intermediario = n.Intermediario,
            //                            Telefono = n.Telefono,
            //                            Direccion = n.Direccion,
            //                            Estatus = n.Estatus,
            //                            Oficina = n.OficinaSupervisor
            //                        }).ToList();
            //        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cartera de Supervisor " + lbNombreSupervisor.Text, Exportar);
            //    }
            //    catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true); }
            //}

            //ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void gbListadoCarteraSupervisor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try {
                e.Row.Cells[0].Visible = false;
            }
            catch (Exception) { }
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
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
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void gbListadoComisiones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void gbListadoComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void gbListadoComisiones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void btnExportarListadoCompleto_Click(object sender, EventArgs e)
        {
            //if (cbAgregarOficina.Checked)
            //{
            //    try
            //    {
            //        var Exportar = (from n in ObjData.Value.ComisionesSupervisores(
            //     Convert.ToDateTime(txtFechaDesde.Text),
            //     Convert.ToDateTime(txtFechaHasta.Text),
            //     null,
            //     Convert.ToInt32(ddlSeleccionaroficina.SelectedValue))
            //                        select new
            //                        {
            //                            Supervisor = n.Supervisor,
            //                            Intermediario = n.Intermediario,
            //                            Factura = n.Numero,
            //                            Valor = n.Valor,
            //                            Oficina = n.Oficina,
            //                            Fecha = n.Fecha,
            //                            Concepto = n.Concepto,
            //                            PorcientoComision = n.__Comision,
            //                            ComisionPagar = n.ComisionPagar,
            //                            ValidadoDesde = n.ValidadoDesde,
            //                            ValidadoHasta = n.ValidadoHasta
            //                        }).ToList();
            //        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comision Supervisor Completo", Exportar);
            //    }
            //    catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true); }
            //}
            //else
            //{
            //    try
            //    {
            //        var Exportar = (from n in ObjData.Value.ComisionesSupervisores(
            //     Convert.ToDateTime(txtFechaDesde.Text),
            //     Convert.ToDateTime(txtFechaHasta.Text))
            //                        select new
            //                        {
            //                            Supervisor = n.Supervisor,
            //                            Intermediario = n.Intermediario,
            //                            Factura = n.Numero,
            //                            Valor = n.Valor,
            //                            Oficina = n.Oficina,
            //                            Fecha = n.Fecha,
            //                            Concepto = n.Concepto,
            //                            PorcientoComision = n.__Comision,
            //                            ComisionPagar = n.ComisionPagar,
            //                            ValidadoDesde = n.ValidadoDesde,
            //                            ValidadoHasta = n.ValidadoHasta
            //                        }).ToList();
            //        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comision Supervisor Completo", Exportar);
            //    }
            //    catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true); }
            //}
            //ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void gbListadoCarteraSupervisor_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            try { e.Row.Cells[0].Visible = false; }
            catch (Exception) { }
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void btnRestablecerPantalla_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
            txtCodigoSupervisor.Enabled = true;
            txtCodigoSupervisor.Text = string.Empty;

        }

        protected void btnConsultarProduccion_Click(object sender, EventArgs e)
        {
            BuscarProduccionSupervisor();
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void gvProduccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProduccion.PageIndex = e.NewPageIndex;
            BuscarProduccionSupervisor();
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void ddlSeleccionarRamoProduccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSubramosProduccion();
            if (Convert.ToInt32(ddlSeleccionarRamoProduccion.SelectedValue) == 106)
            {
                lbExcluirMotoresProduccion.Visible = true;
                ddlExcluirMotoresProduccion.Visible = true;
            }
            else {
                lbExcluirMotoresProduccion.Visible = false;
                ddlExcluirMotoresProduccion.Visible = false;
            }
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void btnExportarProduccion_Click(object sender, EventArgs e)
        {
            ExportarProduccionSupervisor();
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }
    }
}