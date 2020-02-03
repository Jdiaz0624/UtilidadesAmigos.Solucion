using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ProduccionDiariaContabilidad : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAR LOS RAMOS
        private void CargarRamos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjData.Value.BuscaListas("RAMO", null, null), true);
        }
        #endregion
        #region CARGAR LAS OFICINAS
        private void CargarOficinas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficina, ObjData.Value.BuscaListas("OFICINANORMAL", null, null), true);
        }
        #endregion
        #region CARGAR EL LISTADO DE PRODUCCION Y COBRADO DE CONTABILIDAD
        private void CargarListado()
        {
            if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 1)
            {
                //CARGAMOS TODA LA DATA DE PRODUCCION
                if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                {
                    //CARGAMOS LA DATA SIN CONTAR CON LOS INTERMEDIARIOS
                    try {
                        if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                        {
                            ClientScript.RegisterStartupScript(GetType(), "CamposVacios", "CamposVacios();", true);
                            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "ValidarFechaDesde", "ValidarFechaDesde();", true);
                            }
                            if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "ValidarFechaHasta", "ValidarFechaHasta();", true);
                            }
                        }
                        else
                        {
                            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                            int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                            int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();

                            var SacarData = ObjData.Value.SacarProduccionDiariaContabilidad(
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text),
                                _Ramo,
                                _Oficina,
                                null,
                                null,
                                _LlevaIntermediario);
                            foreach (var n in SacarData)
                            {
                                decimal FacturacionHoy = Convert.ToDecimal(n.Hoy);
                                lbFacturadoHoyVariable.Text = FacturacionHoy.ToString("N2");

                                decimal CantidadDebitos = Convert.ToDecimal(n.TotalDebito);
                                lbCantidadDebitosVariable.Text = CantidadDebitos.ToString("N2");

                                decimal CantidadCreditos = Convert.ToDecimal(n.TotalCredito);
                                lbTotalCretitoVariable.Text = CantidadCreditos.ToString("N2");

                                decimal CantidadOtros = Convert.ToDecimal(n.TotalOtros);
                                lbOtrosVariable.Text = CantidadOtros.ToString("N2");

                                decimal Total = Convert.ToDecimal(n.Total);
                                LablbTotalVariableel7.Text = Total.ToString("N2");

                                decimal MesAnterior = Convert.ToDecimal(n.MesAnterior);
                                lbMesAnteriorvariable.Text = MesAnterior.ToString("N2");

                            }
                            gvGridSinIntermediario.DataSource = SacarData;
                            gvGridSinIntermediario.DataBind();
                        }
                    }
                    catch (Exception) {
                        ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
                    }
                }
                else
                {
                    if (cbTodosLosIntermediarios.Checked == true)
                    {
                        //CARGAMOS LA DATA CON TODOS LOS INTERMEDIARIOS
                        try
                        {
                            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "CamposVacios", "CamposVacios();", true);
                                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "ValidarFechaDesde", "ValidarFechaDesde();", true);
                                }
                                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "ValidarFechaHasta", "ValidarFechaHasta();", true);
                                }
                            
                            }
                            else
                            {
                                int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                                int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                                int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                                string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();

                                var SacarData = ObjData.Value.SacarProduccionDiariaContabilidad(
                                    Convert.ToDateTime(txtFechaDesde.Text),
                                    Convert.ToDateTime(txtFechaHasta.Text),
                                    _Ramo,
                                    _Oficina,
                                    null,
                                    null,
                                    _LlevaIntermediario);
                                foreach (var n in SacarData)
                                {
                                    decimal FacturacionHoy = Convert.ToDecimal(n.Hoy);
                                    lbFacturadoHoyVariable.Text = FacturacionHoy.ToString("N2");

                                    decimal CantidadDebitos = Convert.ToDecimal(n.TotalDebito);
                                    lbCantidadDebitosVariable.Text = CantidadDebitos.ToString("N2");

                                    decimal CantidadCreditos = Convert.ToDecimal(n.TotalCredito);
                                    lbTotalCretitoVariable.Text = CantidadCreditos.ToString("N2");

                                    decimal CantidadOtros = Convert.ToDecimal(n.TotalOtros);
                                    lbOtrosVariable.Text = CantidadOtros.ToString("N2");

                                    decimal Total = Convert.ToDecimal(n.Total);
                                    LablbTotalVariableel7.Text = Total.ToString("N2");

                                    decimal MesAnterior = Convert.ToDecimal(n.MesAnterior);
                                    lbMesAnteriorvariable.Text = MesAnterior.ToString("N2");

                                }
                                gvGridConIntermediario.DataSource = SacarData;
                                gvGridConIntermediario.DataBind();
                            }

                        }
                        catch (Exception)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
                        }
                    }
                    else
                    {
                        //CARGAMOS LA DATA VALIDANDO UN SOLO INTERMEDIARIO
                        try
                        {
                            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()) || string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "CamposVacios", "CamposVacios();", true);
                                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "ValidarFechaDesde", "ValidarFechaDesde();", true);
                                }
                                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "ValidarFechaHasta", "ValidarFechaHasta();", true);
                                }
                                if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "ValidarCodigoIntermediario", "ValidarCodigoIntermediario();", true);
                                }
                            }
                            else
                            {
                                int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                                int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                                int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                                string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();

                                var SacarData = ObjData.Value.SacarProduccionDiariaContabilidad(
                                    Convert.ToDateTime(txtFechaDesde.Text),
                                    Convert.ToDateTime(txtFechaHasta.Text),
                                    _Ramo,
                                    _Oficina,
                                    null,
                                    _CodigoIntermediario,
                                    _LlevaIntermediario);
                                foreach (var n in SacarData)
                                {
                                    decimal FacturacionHoy = Convert.ToDecimal(n.Hoy);
                                    lbFacturadoHoyVariable.Text = FacturacionHoy.ToString("N2");

                                    decimal CantidadDebitos = Convert.ToDecimal(n.TotalDebito);
                                    lbCantidadDebitosVariable.Text = CantidadDebitos.ToString("N2");

                                    decimal CantidadCreditos = Convert.ToDecimal(n.TotalCredito);
                                    lbTotalCretitoVariable.Text = CantidadCreditos.ToString("N2");

                                    decimal CantidadOtros = Convert.ToDecimal(n.TotalOtros);
                                    lbOtrosVariable.Text = CantidadOtros.ToString("N2");

                                    decimal Total = Convert.ToDecimal(n.Total);
                                    LablbTotalVariableel7.Text = Total.ToString("N2");

                                    decimal MesAnterior = Convert.ToDecimal(n.MesAnterior);
                                    lbMesAnteriorvariable.Text = MesAnterior.ToString("N2");

                                }
                                gvGridConIntermediario.DataSource = SacarData;
                                gvGridConIntermediario.DataBind();
                            }

                            }
                        catch (Exception)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
                        }
                    }
                }
            }
            else
            {
                //CARGAMOS TODA LA DATA DE LO COBRADO
                try
                {
                    ClientScript.RegisterStartupScript(GetType(), "OpcionNoDisponible", "OpcionNoDisponible();", true);

                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
                }
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRamos();
                CargarOficinas();
            }
        }

        protected void ddlSeleccionarTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlLlevaIntermediario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
            {
                lbIntermediario.Visible = true;
                txtCodigoIntermediario.Visible = true;
                cbTodosLosIntermediarios.Visible = true;
                txtCodigoIntermediario.Text = string.Empty;
                gvGridConIntermediario.Visible = true;
                gvGridSinIntermediario.Visible = false;
            }
            else
            {
                lbIntermediario.Visible = false;
                txtCodigoIntermediario.Visible = false;
                cbTodosLosIntermediarios.Visible = false;
                gvGridConIntermediario.Visible = false;
                gvGridSinIntermediario.Visible = true;
            }
        }

        protected void cbTodosLosIntermediarios_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodosLosIntermediarios.Checked)
            {
                lbLetreroTodosIntermediairos.Visible = true;
            }
            else
            {
                lbLetreroTodosIntermediairos.Visible = false;
            }
        }

        protected void gvGridSinIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGridSinIntermediario.PageIndex = e.NewPageIndex;
            CargarListado();
        }

        protected void gvGridConIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGridConIntermediario.PageIndex = e.NewPageIndex;
            CargarListado();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarListado();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            //SELECCIONAMOS EL TIPO DE REPORTE

            //SI TIPO DE REPORTE SELECCIONADO ES EL 1 EXPORTAMOS LA PRODUCCION
            if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 1)
            {
                //VALIDAMOS SI LA EXPORTACION VA A LLEVAR INTERMEDIARIOS
                //EXPORTAMOS LA DATA EN CASO DE QUE NO SE VAN A LLEVAR INTERMEDIAIROS
                if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                {
                    //EN ESTE CASO SOLO VALIDAMOS SI LOS CAMPOS DE FECHA ESTAN VACIOS
                    try {
                        if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrWhiteSpace(txtFechaHasta.Text.Trim()))
                        {
                            ClientScript.RegisterStartupScript(GetType(), "ErrorExportacionConsulta", "ErrorExportacionConsulta();", true);
                            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "ValidarFechaDesde", "ValidarFechaDesde();", true);
                            }
                            if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "ValidarFechaHasta", "ValidarFechaHasta();", true);
                            }
                        }
                        else
                        {
                            //EXPORTAMOS LA DATA PARA EL USUARUI, FILTRAMOS POR RAMO, Y OFICINA
                            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                            int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                            int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();

                            var ExportarData = (from n in ObjData.Value.SacarProduccionDiariaContabilidad(
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text),
                                _Ramo,
                                _Oficina,
                                null,
                                null,
                                _LlevaIntermediario)
                                                select new
                                                {
                                                    Ramo = n.Ramo,
                                                    Descripcion = n.Descripcion,
                                                    Tipo = n.Tipo,
                                                    DescripcionTipo = n.DescripcionTipo,
                                                    CodOficina = n.CodOficina,
                                                    Oficina = n.Oficina,
                                                    Concepto = n.Concepto,
                                                    FacturadoMes = n.FacturadoMes,
                                                    Total = n.Total,
                                                    MesAnterior = n.MesAnterior,
                                                    Hoy = n.Hoy,
                                                    TotalCredito = n.TotalCredito,
                                                    TotalDebito = n.TotalDebito,
                                                    TotalOtros = n.TotalOtros
                                                }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion Contabilidad Sin Intermediario", ExportarData);

                        }
                      
                    }
                    catch (Exception) {
                        ClientScript.RegisterStartupScript(GetType(), "ErrorExportar", "ErrorExportar();", true);
                    }
                }
                //MOSTRAMOS LA DATA EN CASO DE QUE SI LLEVA INTERMEDIARIOS
                else if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
                {
                    //VERIFICAMIS SI SE VA A FILTRAR POR UN SOLO INTERMEDIARIOS
                    if (cbTodosLosIntermediarios.Checked == true)
                    {
                        try
                        {
                            //VALIDAMOS LOS CAMPOS DE FECHA
                            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "ErrorExportacionConsulta", "ErrorExportacionConsulta();", true);
                                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "ValidarFechaDesde", "ValidarFechaDesde();", true);
                                }
                                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "ValidarFechaHasta", "ValidarFechaHasta();", true);
                                }
                            }
                            else
                            {
                                int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                                int? _Oficina = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                                int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                                string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();

                                var ExportarData = (from n in ObjData.Value.SacarProduccionDiariaContabilidad(
                                    Convert.ToDateTime(txtFechaDesde.Text),
                                    Convert.ToDateTime(txtFechaHasta.Text),
                                    _Ramo,
                                    _Oficina,
                                    null,
                                    null,
                                    _LlevaIntermediario)
                                                    select new
                                                    {
                                                        Intermediario = n.Intermediario,
                                                        Codigo = n.Codigo,
                                                        Ramo = n.Ramo,
                                                        Descripcion = n.Descripcion,
                                                        Tipo = n.Tipo,
                                                        DescripcionTipo = n.DescripcionTipo,
                                                        CodOficina = n.CodOficina,
                                                        Oficina = n.Oficina,
                                                        Concepto = n.Concepto,
                                                        FacturadoMes = n.FacturadoMes,
                                                        Total = n.Total,
                                                        MesAnterior = n.MesAnterior,
                                                        Hoy = n.Hoy,
                                                        TotalCredito = n.TotalCredito,
                                                        TotalDebito = n.TotalDebito,
                                                        TotalOtros = n.TotalOtros
                                                    }).ToList();
                                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion Contabilidad Todos los Intermediarios", ExportarData);
                            }
                        }
                        catch (Exception)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "ErrorExportar", "ErrorExportar();", true);
                        }
                    }
                    else if (cbTodosLosIntermediarios.Checked == false)
                    {
                        try
                        {
                            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()) || string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "ErrorExportacionConsulta", "ErrorExportacionConsulta();", true);
                                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "ValidarFechaDesde", "ValidarFechaDesde();", true);
                                }
                                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "ValidarFechaHasta", "ValidarFechaHasta();", true);
                                }
                                if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "ValidarCodigoIntermediario", "ValidarCodigoIntermediario();", true);
                                }
                            }
                            else
                            {
                                int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                                int? _Oficina = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                                int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                                string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();

                                var ExportarData = (from n in ObjData.Value.SacarProduccionDiariaContabilidad(
                                    Convert.ToDateTime(txtFechaDesde.Text),
                                    Convert.ToDateTime(txtFechaHasta.Text),
                                    _Ramo,
                                    _Oficina,
                                    null,
                                    _CodigoIntermediario,
                                    _LlevaIntermediario)
                                                    select new
                                                    {
                                                        Intermediario = n.Intermediario,
                                                        Codigo = n.Codigo,
                                                        Ramo = n.Ramo,
                                                        Descripcion = n.Descripcion,
                                                        Tipo = n.Tipo,
                                                        DescripcionTipo = n.DescripcionTipo,
                                                        CodOficina = n.CodOficina,
                                                        Oficina = n.Oficina,
                                                        Concepto = n.Concepto,
                                                        FacturadoMes = n.FacturadoMes,
                                                        Total = n.Total,
                                                        MesAnterior = n.MesAnterior,
                                                        Hoy = n.Hoy,
                                                        TotalCredito = n.TotalCredito,
                                                        TotalDebito = n.TotalDebito,
                                                        TotalOtros = n.TotalOtros
                                                    }).ToList();
                                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion Contabilidad Con Intermediario", ExportarData);
                            }
                        }
                        catch (Exception)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "ErrorExportar", "ErrorExportar();", true);
                        }
                    }
                    

                    
                }
            }
            //DE LO CONTRARIO MOSTRAMOS LO CONTRARIO EXPORTAMOS LO COBRADO
            else if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 2)
            {
                ClientScript.RegisterStartupScript(GetType(), "OpcionNoDisponible", "OpcionNoDisponible();", true);
            }
        }
    }
}