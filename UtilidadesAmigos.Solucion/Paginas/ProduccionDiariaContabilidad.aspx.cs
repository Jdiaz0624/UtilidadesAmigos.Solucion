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
            if (string.IsNullOrEmpty(txtAno.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CampoAnoVacio", "CampoAnoVacio();", true);
            }
            else
            {
                DateTime FechaDesde, FechaHasta, FechaDesdeAnterior, FechaHastaAnterior;
                string FechaConcatenadaDesde = "";
                string FechaConcatenadaHasta = "";
                string FechaConcatenadaDesdeAnterior = "";
                string FechaConcatenadaHastaAnterior = "";
                int MesSeleccionado = Convert.ToInt32(ddlSeleccionarMes.SelectedValue);
                //HACEMOS EL PROCESO PARA SACAR LA FECHA DESDE Y LA FECHA HASTA
                switch (MesSeleccionado)
                {
                    case 1:
                        //ENERO
                        FechaConcatenadaDesde = txtAno.Text + "-01-01";
                        FechaConcatenadaHasta = txtAno.Text + "-01-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);


                        //MES ANTERIOR
                        int MesAnterior = Convert.ToInt32(txtAno.Text);
                        MesAnterior = MesAnterior - 1;
                        FechaConcatenadaDesdeAnterior = MesAnterior.ToString() + "-12-01";
                        FechaConcatenadaHastaAnterior = MesAnterior.ToString() + "-12-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 2:
                        //FEBRERO
                        FechaConcatenadaDesde = txtAno.Text + "-02-01";
                        FechaConcatenadaHasta = txtAno.Text + "-01-29";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);


                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-01-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-01-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 3:
                        //MARZO
                        FechaConcatenadaDesde = txtAno.Text + "-03-01";
                        FechaConcatenadaHasta = txtAno.Text + "-03-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);


                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-02-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-02-29";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 4:
                        //ABRIL
                        FechaConcatenadaDesde = txtAno.Text + "-04-01";
                        FechaConcatenadaHasta = txtAno.Text + "-04-30";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);



                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-03-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-03-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 5:
                        //MAYO
                        FechaConcatenadaDesde = txtAno.Text + "-05-01";
                        FechaConcatenadaHasta = txtAno.Text + "-05-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);



                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-04-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-04-30";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 6:
                        //JUNIO
                        FechaConcatenadaDesde = txtAno.Text + "-06-01";
                        FechaConcatenadaHasta = txtAno.Text + "-06-30";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);




                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-05-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-05-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 7:
                        //JULIO
                        FechaConcatenadaDesde = txtAno.Text + "-07-01";
                        FechaConcatenadaHasta = txtAno.Text + "-07-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);




                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-06-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-06-30";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 8:
                        //AGOSTO
                        FechaConcatenadaDesde = txtAno.Text + "-08-01";
                        FechaConcatenadaHasta = txtAno.Text + "-08-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);




                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-07-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-07-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 9:
                        //SEPTIEMBRE
                        FechaConcatenadaDesde = txtAno.Text + "-09-01";
                        FechaConcatenadaHasta = txtAno.Text + "-09-30";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);



                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-08-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-08-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 10:
                        //OCTUBRE
                        FechaConcatenadaDesde = txtAno.Text + "-10-01";
                        FechaConcatenadaHasta = txtAno.Text + "-10-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);



                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-09-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-09-30";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 11:
                        //NOVIEMBRE
                        FechaConcatenadaDesde = txtAno.Text + "-11-01";
                        FechaConcatenadaHasta = txtAno.Text + "-11-30";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);




                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-10-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-10-31";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;

                    case 12:
                        //DICIEMBRE
                        FechaConcatenadaDesde = txtAno.Text + "-12-01";
                        FechaConcatenadaHasta = txtAno.Text + "-12-31";
                        FechaDesde = Convert.ToDateTime(FechaConcatenadaDesde);
                        FechaHasta = Convert.ToDateTime(FechaConcatenadaHasta);



                        //MES ANTERIOR
                        FechaConcatenadaDesdeAnterior = txtAno.Text + "-11-01";
                        FechaConcatenadaHastaAnterior = txtAno.Text + "-11-30";
                        FechaDesdeAnterior = Convert.ToDateTime(FechaConcatenadaDesdeAnterior);
                        FechaHastaAnterior = Convert.ToDateTime(FechaConcatenadaHastaAnterior);
                        break;
                }
            }
          

        }
        #endregion
        #region CARGAR LOS MESES
        private void CargarMeses()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMes, ObjData.Value.BuscaListas("MESES", null, null));
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRamos();
                CargarOficinas();
                CargarMeses();
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
           // CargarListado();
        }

        protected void gvGridConIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGridConIntermediario.PageIndex = e.NewPageIndex;
          //  CargarListado();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarListado();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            ////SELECCIONAMOS EL TIPO DE REPORTE

            ////SI TIPO DE REPORTE SELECCIONADO ES EL 1 EXPORTAMOS LA PRODUCCION
            //if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 1)
            //{
            //    //VALIDAMOS SI LA EXPORTACION VA A LLEVAR INTERMEDIARIOS
            //    //EXPORTAMOS LA DATA EN CASO DE QUE NO SE VAN A LLEVAR INTERMEDIAIROS
            //    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
            //    {
            //        //EN ESTE CASO SOLO VALIDAMOS SI LOS CAMPOS DE FECHA ESTAN VACIOS
            //        try {
            //            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrWhiteSpace(txtFechaHasta.Text.Trim()))
            //            {
            //                ClientScript.RegisterStartupScript(GetType(), "ErrorExportacionConsulta", "ErrorExportacionConsulta();", true);
            //                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
            //                {
            //                    ClientScript.RegisterStartupScript(GetType(), "ValidarFechaDesde", "ValidarFechaDesde();", true);
            //                }
            //                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            //                {
            //                    ClientScript.RegisterStartupScript(GetType(), "ValidarFechaHasta", "ValidarFechaHasta();", true);
            //                }
            //            }
            //            else
            //            {
            //                //EXPORTAMOS LA DATA PARA EL USUARUI, FILTRAMOS POR RAMO, Y OFICINA
            //                int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            //                int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
            //                int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();

            //                var ExportarData = (from n in ObjData.Value.SacarProduccionDiariaContabilidad(
            //                    Convert.ToDateTime(txtFechaDesde.Text),
            //                    Convert.ToDateTime(txtFechaHasta.Text),
            //                    _Ramo,
            //                    _Oficina,
            //                    null,
            //                    null,
            //                    _LlevaIntermediario)
            //                                    select new
            //                                    {
            //                                        Ramo = n.Ramo,
            //                                        Descripcion = n.Descripcion,
            //                                        Tipo = n.Tipo,
            //                                        DescripcionTipo = n.DescripcionTipo,
            //                                        CodOficina = n.CodOficina,
            //                                        Oficina = n.Oficina,
            //                                        Concepto = n.Concepto,
            //                                        FacturadoMes = n.FacturadoMes,
            //                                        Total = n.Total,
            //                                        MesAnterior = n.MesAnterior,
            //                                        Hoy = n.Hoy,
            //                                        TotalCredito = n.TotalCredito,
            //                                        TotalDebito = n.TotalDebito,
            //                                        TotalOtros = n.TotalOtros
            //                                    }).ToList();
            //                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion Contabilidad Sin Intermediario", ExportarData);

            //            }
                      
            //        }
            //        catch (Exception) {
            //            ClientScript.RegisterStartupScript(GetType(), "ErrorExportar", "ErrorExportar();", true);
            //        }
            //    }
            //    //MOSTRAMOS LA DATA EN CASO DE QUE SI LLEVA INTERMEDIARIOS
            //    else if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
            //    {
            //        //VERIFICAMIS SI SE VA A FILTRAR POR UN SOLO INTERMEDIARIOS
            //        if (cbTodosLosIntermediarios.Checked == true)
            //        {
            //            try
            //            {
            //                //VALIDAMOS LOS CAMPOS DE FECHA
            //                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            //                {
            //                    ClientScript.RegisterStartupScript(GetType(), "ErrorExportacionConsulta", "ErrorExportacionConsulta();", true);
            //                    if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
            //                    {
            //                        ClientScript.RegisterStartupScript(GetType(), "ValidarFechaDesde", "ValidarFechaDesde();", true);
            //                    }
            //                    if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            //                    {
            //                        ClientScript.RegisterStartupScript(GetType(), "ValidarFechaHasta", "ValidarFechaHasta();", true);
            //                    }
            //                }
            //                else
            //                {
            //                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            //                    int? _Oficina = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
            //                    int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
            //                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();

            //                    var ExportarData = (from n in ObjData.Value.SacarProduccionDiariaContabilidad(
            //                        Convert.ToDateTime(txtFechaDesde.Text),
            //                        Convert.ToDateTime(txtFechaHasta.Text),
            //                        _Ramo,
            //                        _Oficina,
            //                        null,
            //                        null,
            //                        _LlevaIntermediario)
            //                                        select new
            //                                        {
            //                                            Intermediario = n.Intermediario,
            //                                            Codigo = n.Codigo,
            //                                            Ramo = n.Ramo,
            //                                            Descripcion = n.Descripcion,
            //                                            Tipo = n.Tipo,
            //                                            DescripcionTipo = n.DescripcionTipo,
            //                                            CodOficina = n.CodOficina,
            //                                            Oficina = n.Oficina,
            //                                            Concepto = n.Concepto,
            //                                            FacturadoMes = n.FacturadoMes,
            //                                            Total = n.Total,
            //                                            MesAnterior = n.MesAnterior,
            //                                            Hoy = n.Hoy,
            //                                            TotalCredito = n.TotalCredito,
            //                                            TotalDebito = n.TotalDebito,
            //                                            TotalOtros = n.TotalOtros
            //                                        }).ToList();
            //                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion Contabilidad Todos los Intermediarios", ExportarData);
            //                }
            //            }
            //            catch (Exception)
            //            {
            //                ClientScript.RegisterStartupScript(GetType(), "ErrorExportar", "ErrorExportar();", true);
            //            }
            //        }
            //        else if (cbTodosLosIntermediarios.Checked == false)
            //        {
            //            try
            //            {
            //                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()) || string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
            //                {
            //                    ClientScript.RegisterStartupScript(GetType(), "ErrorExportacionConsulta", "ErrorExportacionConsulta();", true);
            //                    if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
            //                    {
            //                        ClientScript.RegisterStartupScript(GetType(), "ValidarFechaDesde", "ValidarFechaDesde();", true);
            //                    }
            //                    if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            //                    {
            //                        ClientScript.RegisterStartupScript(GetType(), "ValidarFechaHasta", "ValidarFechaHasta();", true);
            //                    }
            //                    if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
            //                    {
            //                        ClientScript.RegisterStartupScript(GetType(), "ValidarCodigoIntermediario", "ValidarCodigoIntermediario();", true);
            //                    }
            //                }
            //                else
            //                {
            //                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            //                    int? _Oficina = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
            //                    int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
            //                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();

            //                    var ExportarData = (from n in ObjData.Value.SacarProduccionDiariaContabilidad(
            //                        Convert.ToDateTime(txtFechaDesde.Text),
            //                        Convert.ToDateTime(txtFechaHasta.Text),
            //                        _Ramo,
            //                        _Oficina,
            //                        null,
            //                        _CodigoIntermediario,
            //                        _LlevaIntermediario)
            //                                        select new
            //                                        {
            //                                            Intermediario = n.Intermediario,
            //                                            Codigo = n.Codigo,
            //                                            Ramo = n.Ramo,
            //                                            Descripcion = n.Descripcion,
            //                                            Tipo = n.Tipo,
            //                                            DescripcionTipo = n.DescripcionTipo,
            //                                            CodOficina = n.CodOficina,
            //                                            Oficina = n.Oficina,
            //                                            Concepto = n.Concepto,
            //                                            FacturadoMes = n.FacturadoMes,
            //                                            Total = n.Total,
            //                                            MesAnterior = n.MesAnterior,
            //                                            Hoy = n.Hoy,
            //                                            TotalCredito = n.TotalCredito,
            //                                            TotalDebito = n.TotalDebito,
            //                                            TotalOtros = n.TotalOtros
            //                                        }).ToList();
            //                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion Contabilidad Con Intermediario", ExportarData);
            //                }
            //            }
            //            catch (Exception)
            //            {
            //                ClientScript.RegisterStartupScript(GetType(), "ErrorExportar", "ErrorExportar();", true);
            //            }
            //        }
                    

                    
            //    }
            //}
            ////DE LO CONTRARIO MOSTRAMOS LO CONTRARIO EXPORTAMOS LO COBRADO
            //else if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 2)
            //{
            //    ClientScript.RegisterStartupScript(GetType(), "OpcionNoDisponible", "OpcionNoDisponible();", true);
            //}
        }
    }
}