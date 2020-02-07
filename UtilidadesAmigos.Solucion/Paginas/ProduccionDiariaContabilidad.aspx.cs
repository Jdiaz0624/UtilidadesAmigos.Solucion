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
                DateTime FechaDesde = DateTime.Now, FechaHasta= DateTime.Now, FechaDesdeAnterior= DateTime.Now, FechaHastaAnterior= DateTime.Now;
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
                        FechaConcatenadaHasta = txtAno.Text + "-02-29";
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
                //VERIFICAMOS EL TIPO DE REPORTE QUE SE VA A USAR
                //REPORTE DE PRODUCCION
                if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 1)
                {
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();

                    //VERIFICAMOS SI LA CONSULTA LLEVA INTERMEDARIOS
                    //EN CASO DE QUE NO LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                    {
                        var CargarListado = ObjData.Value.SacarProduccionDiariaContabilidad(
                            FechaDesde,
                            FechaHasta,
                            FechaDesdeAnterior,
                            FechaHastaAnterior,
                            _Ramo,
                            _Oficina,
                            null,
                            null,
                            _LlevaIntermediario);
                        foreach (var n in CargarListado)
                        {
                            decimal FacturadoHoy = Convert.ToDecimal(n.Hoy);
                            lbFacturadoHoyVariable.Text = FacturadoHoy.ToString("N2");

                            decimal FacturadoDebitos = Convert.ToDecimal(n.TotalDebito);
                            lbCantidadDebitosVariable.Text = FacturadoDebitos.ToString("N2");

                            decimal FacturadoCredito = Convert.ToDecimal(n.TotalCredito);
                            lbTotalCretitoVariable.Text = FacturadoCredito.ToString("N2");

                            decimal FacturadoOtros = Convert.ToDecimal(n.TotalOtros);
                            lbOtrosVariable.Text = FacturadoOtros.ToString("N2");

                            decimal FacturadoTotal = Convert.ToDecimal(n.Total);
                            LablbTotalVariableel7.Text = FacturadoTotal.ToString("N2");

                            decimal FacturadoMesAnterior = Convert.ToDecimal(n.MesAnterior);
                            lbMesAnteriorvariable.Text = FacturadoMesAnterior.ToString("N2");

                        }
                        gvGridSinIntermediario.DataSource = CargarListado;
                        gvGridSinIntermediario.DataBind();

                    }
                    //EN CASO DE QUE LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
                    {
                        //VALIDAMOS SI SE VAN A FILTRAR TODOS LOS INTERMEDIARIOS O SOLO 1
                        //VALIDAMOS TODOS LOS INTERMEDIAIOS
                        if (cbTodosLosIntermediarios.Checked)
                        {
                            var CargarListado = ObjData.Value.SacarProduccionDiariaContabilidad(
                        FechaDesde,
                        FechaHasta,
                        FechaDesdeAnterior,
                        FechaHastaAnterior,
                        _Ramo,
                        _Oficina,
                        null,
                        null,
                        _LlevaIntermediario);
                            foreach (var n in CargarListado)
                            {
                                decimal FacturadoHoy = Convert.ToDecimal(n.Hoy);
                                lbFacturadoHoyVariable.Text = FacturadoHoy.ToString("N2");

                                decimal FacturadoDebitos = Convert.ToDecimal(n.TotalDebito);
                                lbCantidadDebitosVariable.Text = FacturadoDebitos.ToString("N2");

                                decimal FacturadoCredito = Convert.ToDecimal(n.TotalCredito);
                                lbTotalCretitoVariable.Text = FacturadoCredito.ToString("N2");

                                decimal FacturadoOtros = Convert.ToDecimal(n.TotalOtros);
                                lbOtrosVariable.Text = FacturadoOtros.ToString("N2");

                                decimal FacturadoTotal = Convert.ToDecimal(n.Total);
                                LablbTotalVariableel7.Text = FacturadoTotal.ToString("N2");

                                decimal FacturadoMesAnterior = Convert.ToDecimal(n.MesAnterior);
                                lbMesAnteriorvariable.Text = FacturadoMesAnterior.ToString("N2");

                            }
                            gvGridConIntermediario.DataSource = CargarListado;
                            gvGridConIntermediario.DataBind();
                        }
                        //VALIDAMOS UN INTERMEDIARIO EN ESPESIFICO
                        else
                        {
                            if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "CampoCodogoIntermediarioVacio", "CampoCodogoIntermediarioVacio()", true);
                            }
                            else
                            {
                                var CargarListado = ObjData.Value.SacarProduccionDiariaContabilidad(
                           FechaDesde,
                           FechaHasta,
                           FechaDesdeAnterior,
                           FechaHastaAnterior,
                           _Ramo,
                           _Oficina,
                           null,
                           _CodigoIntermediario,
                           _LlevaIntermediario);
                                foreach (var n in CargarListado)
                                {
                                    decimal FacturadoHoy = Convert.ToDecimal(n.Hoy);
                                    lbFacturadoHoyVariable.Text = FacturadoHoy.ToString("N2");

                                    decimal FacturadoDebitos = Convert.ToDecimal(n.TotalDebito);
                                    lbCantidadDebitosVariable.Text = FacturadoDebitos.ToString("N2");

                                    decimal FacturadoCredito = Convert.ToDecimal(n.TotalCredito);
                                    lbTotalCretitoVariable.Text = FacturadoCredito.ToString("N2");

                                    decimal FacturadoOtros = Convert.ToDecimal(n.TotalOtros);
                                    lbOtrosVariable.Text = FacturadoOtros.ToString("N2");

                                    decimal FacturadoTotal = Convert.ToDecimal(n.Total);
                                    LablbTotalVariableel7.Text = FacturadoTotal.ToString("N2");

                                    decimal FacturadoMesAnterior = Convert.ToDecimal(n.MesAnterior);
                                    lbMesAnteriorvariable.Text = FacturadoMesAnterior.ToString("N2");

                                }
                                gvGridConIntermediario.DataSource = CargarListado;
                                gvGridConIntermediario.DataBind();
                            }
                        }

                    }
                }

                //REPORTE DE COBROS
                if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 2)
                {
                    //VERIFICAMOS SI LA CONSULTA LLEVA INTERMEDARIOS
                    //EN CASO DE QUE NO LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                    {

                    }
                    //EN CASO DE QUE LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
                    {
                        //VALIDAMOS SI SE VAN A FILTRAR TODOS LOS INTERMEDIARIOS O SOLO 1
                        //VALIDAMOS TODOS LOS INTERMEDIAIOS
                        if (cbTodosLosIntermediarios.Checked)
                        {

                        }
                        //VALIDAMOS UN INTERMEDIARIO EN ESPESIFICO
                        else
                        {

                        }

                    }
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
        #region EXPORTAR LA DATA A EXEL
        private void ExportarDataExel()
        {
            //VALIDAMOS EL CAMPO Año
            if (string.IsNullOrEmpty(txtAno.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CampoAnoVacio", "CampoAnoVacio()", true);
            }
            else
            {
                //REALIZAMOS EL PROCESOS DE LOS MESES
                DateTime FechaDesde = DateTime.Now, FechaHasta = DateTime.Now, FechaDesdeAnterior = DateTime.Now, FechaHastaAnterior = DateTime.Now;
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
                        FechaConcatenadaHasta = txtAno.Text + "-02-29";
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

                //VERIFICAMOS EL TIPO DE REPORTE SELECCIONAD
                //SI EL REPORTE A EXPORTAR ES PRODUCCION
                if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 1)
                {
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
                    //VERIFICAMOS SI LA CONSULTA LLEVA INTERMEDARIOS
                    //EN CASO DE QUE NO LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                    {
                        var Exportar = (from n in ObjData.Value.SacarProduccionDiariaContabilidad(
                            FechaDesde,
                            FechaHasta,
                            FechaDesdeAnterior,
                            FechaHastaAnterior,
                            _Ramo,
                            _Oficina,
                            null,
                            null,
                            _LlevaIntermediario)
                                        select new {
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
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción Sin Intermediario", Exportar);
                            
                    }
                    //EN CASO DE QUE LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
                    {
                        //VALIDAMOS SI SE VAN A FILTRAR TODOS LOS INTERMEDIARIOS O SOLO 1
                        //VALIDAMOS TODOS LOS INTERMEDIAIOS
                        if (cbTodosLosIntermediarios.Checked)
                        {
                            var Exportar = (from n in ObjData.Value.SacarProduccionDiariaContabilidad(
                           FechaDesde,
                           FechaHasta,
                           FechaDesdeAnterior,
                           FechaHastaAnterior,
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
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción Todos los  Intermediario", Exportar);
                        }
                        //VALIDAMOS UN INTERMEDIARIO EN ESPESIFICO
                        else
                        {
                            var Exportar = (from n in ObjData.Value.SacarProduccionDiariaContabilidad(
                           FechaDesde,
                           FechaHasta,
                           FechaDesdeAnterior,
                           FechaHastaAnterior,
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
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción Intermediario Espesifico", Exportar);
                        }

                    }

                }
                //SI EL REPORTE A EXPORTAR ES DE LO COBRADO
                else if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 2)
                {
                    //VERIFICAMOS SI LA CONSULTA LLEVA INTERMEDARIOS
                    //EN CASO DE QUE NO LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                    {

                    }
                    //EN CASO DE QUE LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
                    {
                        //VALIDAMOS SI SE VAN A FILTRAR TODOS LOS INTERMEDIARIOS O SOLO 1
                        //VALIDAMOS TODOS LOS INTERMEDIAIOS
                        if (cbTodosLosIntermediarios.Checked)
                        {

                        }
                        //VALIDAMOS UN INTERMEDIARIO EN ESPESIFICO
                        else
                        {

                        }

                    }
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
                ClientScript.RegisterStartupScript(GetType(), "DesactivarCodigoIntermediario", "DesactivarCodigoIntermediario();", true);
            }
            else
            {
                lbLetreroTodosIntermediairos.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "ActivarCodigoIntermediario", "ActivarCodigoIntermediario()", true);
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
            ExportarDataExel();
        }
    }
}