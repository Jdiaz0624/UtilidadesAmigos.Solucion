using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Threading;

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
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                    {
                        var MostrarListado = ObjData.Value.ReporteCobradoCOntabilidad(
                            FechaDesde,
                            FechaHasta,
                            FechaDesdeAnterior,
                            FechaHastaAnterior,
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario,
                            null);
                        foreach (var n in MostrarListado)
                        {
                            decimal CobradoSantoDomingo = 0, CobradoSantiago = 0, CobradoOtros = 0, TotalCobrado = 0, CobredoMesAnterior = 0, CobradoHoy = 0;

                            CobradoSantoDomingo = Convert.ToDecimal(n.CobradoSantoDomingo);
                            CobradoSantiago = Convert.ToDecimal(n.CobradoSantiago);
                            CobradoOtros = Convert.ToDecimal(n.CobradoOtros);
                            TotalCobrado = Convert.ToDecimal(n.Total);
                            CobredoMesAnterior = Convert.ToDecimal(n.CobradoMesAnterior);
                            CobradoHoy = Convert.ToDecimal(n.CobradoHoy);


                            lbCobradoSantoDomingoVariable.Text = CobradoSantoDomingo.ToString("N2");
                            lbCobradoSantiagoVariable.Text = CobradoSantiago.ToString("N2");
                            lbCobradoOtrosVariable.Text = CobradoOtros.ToString("N2");
                            lbTotalCobradoVariable.Text = TotalCobrado.ToString("N2");
                            lbCobradoMesAnteriorVariable.Text = CobredoMesAnterior.ToString("N2");
                            lbCobradoHoyVariable.Text = CobradoHoy.ToString("N2");
                        }
                        gbCobradoSinIntermediario.DataSource = MostrarListado;
                        gbCobradoSinIntermediario.DataBind();
                    }
                    //EN CASO DE QUE LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
                    {
                        //VALIDAMOS SI SE VAN A FILTRAR TODOS LOS INTERMEDIARIOS O SOLO 1
                        //VALIDAMOS TODOS LOS INTERMEDIAIOS
                        if (cbTodosLosIntermediarios.Checked)
                        {
                            var MostrarListado = ObjData.Value.ReporteCobradoCOntabilidad(
                            FechaDesde,
                            FechaHasta,
                            FechaDesdeAnterior,
                            FechaHastaAnterior,
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario);
                            foreach (var n in MostrarListado)
                            {
                                decimal CobradoSantoDomingo = 0, CobradoSantiago = 0, CobradoOtros = 0, TotalCobrado = 0, CobredoMesAnterior = 0, CobradoHoy = 0;

                                CobradoSantoDomingo = Convert.ToDecimal(n.CobradoSantoDomingo);
                                CobradoSantiago = Convert.ToDecimal(n.CobradoSantiago);
                                CobradoOtros = Convert.ToDecimal(n.CobradoOtros);
                                TotalCobrado = Convert.ToDecimal(n.Total);
                                CobredoMesAnterior = Convert.ToDecimal(n.CobradoMesAnterior);
                                CobradoHoy = Convert.ToDecimal(n.CobradoHoy);


                                lbCobradoSantoDomingoVariable.Text = CobradoSantoDomingo.ToString("N2");
                                lbCobradoSantiagoVariable.Text = CobradoSantiago.ToString("N2");
                                lbCobradoOtrosVariable.Text = CobradoOtros.ToString("N2");
                                lbTotalCobradoVariable.Text = TotalCobrado.ToString("N2");
                                lbCobradoMesAnteriorVariable.Text = CobredoMesAnterior.ToString("N2");
                                lbCobradoHoyVariable.Text = CobradoHoy.ToString("N2");
                            }
                            gbCobradoSinIntermediario.DataSource = MostrarListado;
                            gbCobradoSinIntermediario.DataBind();
                        }
                        //VALIDAMOS UN INTERMEDIARIO EN ESPESIFICO
                        else
                        {
                            if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "CampoCodogoIntermediarioVacio", "CampoCodogoIntermediarioVacio();", true);
                            }
                            else
                            {
                                var MostrarListado = ObjData.Value.ReporteCobradoCOntabilidad(
                            FechaDesde,
                            FechaHasta,
                            FechaDesdeAnterior,
                            FechaHastaAnterior,
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario,
                            _CodigoIntermediario);
                                foreach (var n in MostrarListado)
                                {
                                    decimal CobradoSantoDomingo = 0, CobradoSantiago = 0, CobradoOtros = 0, TotalCobrado = 0, CobredoMesAnterior = 0, CobradoHoy = 0;

                                    CobradoSantoDomingo = Convert.ToDecimal(n.CobradoSantoDomingo);
                                    CobradoSantiago = Convert.ToDecimal(n.CobradoSantiago);
                                    CobradoOtros = Convert.ToDecimal(n.CobradoOtros);
                                    TotalCobrado = Convert.ToDecimal(n.Total);
                                    CobredoMesAnterior = Convert.ToDecimal(n.CobradoMesAnterior);
                                    CobradoHoy = Convert.ToDecimal(n.CobradoHoy);


                                    lbCobradoSantoDomingoVariable.Text = CobradoSantoDomingo.ToString("N2");
                                    lbCobradoSantiagoVariable.Text = CobradoSantiago.ToString("N2");
                                    lbCobradoOtrosVariable.Text = CobradoOtros.ToString("N2");
                                    lbTotalCobradoVariable.Text = TotalCobrado.ToString("N2");
                                    lbCobradoMesAnteriorVariable.Text = CobredoMesAnterior.ToString("N2");
                                    lbCobradoHoyVariable.Text = CobradoHoy.ToString("N2");
                                }
                                gbCobradoSinIntermediario.DataSource = MostrarListado;
                                gbCobradoSinIntermediario.DataBind();
                            }
                        }

                    }
                }
            }
          

        }
        #endregion
        #region CARGAR LISTADO EN MODO COMPARATIVO
        private void CargarListadoModoCOmparativo()
        {
            try {
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
                            Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
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
                         Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
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
                        Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
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
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                    {
                        var MostrarListado = ObjData.Value.ReporteCobradoCOntabilidad(
                            Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario,
                            null);
                        foreach (var n in MostrarListado)
                        {
                            decimal CobradoSantoDomingo = 0, CobradoSantiago = 0, CobradoOtros = 0, TotalCobrado = 0, CobredoMesAnterior = 0, CobradoHoy = 0;

                            CobradoSantoDomingo = Convert.ToDecimal(n.CobradoSantoDomingo);
                            CobradoSantiago = Convert.ToDecimal(n.CobradoSantiago);
                            CobradoOtros = Convert.ToDecimal(n.CobradoOtros);
                            TotalCobrado = Convert.ToDecimal(n.Total);
                            CobredoMesAnterior = Convert.ToDecimal(n.CobradoMesAnterior);
                            CobradoHoy = Convert.ToDecimal(n.CobradoHoy);


                            lbCobradoSantoDomingoVariable.Text = CobradoSantoDomingo.ToString("N2");
                            lbCobradoSantiagoVariable.Text = CobradoSantiago.ToString("N2");
                            lbCobradoOtrosVariable.Text = CobradoOtros.ToString("N2");
                            lbTotalCobradoVariable.Text = TotalCobrado.ToString("N2");
                            lbCobradoMesAnteriorVariable.Text = CobredoMesAnterior.ToString("N2");
                            lbCobradoHoyVariable.Text = CobradoHoy.ToString("N2");
                        }
                        gbCobradoSinIntermediario.DataSource = MostrarListado;
                        gbCobradoSinIntermediario.DataBind();
                    }
                    //EN CASO DE QUE LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
                    {
                        //VALIDAMOS SI SE VAN A FILTRAR TODOS LOS INTERMEDIARIOS O SOLO 1
                        //VALIDAMOS TODOS LOS INTERMEDIAIOS
                        if (cbTodosLosIntermediarios.Checked)
                        {
                            var MostrarListado = ObjData.Value.ReporteCobradoCOntabilidad(
                          Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario);
                            foreach (var n in MostrarListado)
                            {
                                decimal CobradoSantoDomingo = 0, CobradoSantiago = 0, CobradoOtros = 0, TotalCobrado = 0, CobredoMesAnterior = 0, CobradoHoy = 0;

                                CobradoSantoDomingo = Convert.ToDecimal(n.CobradoSantoDomingo);
                                CobradoSantiago = Convert.ToDecimal(n.CobradoSantiago);
                                CobradoOtros = Convert.ToDecimal(n.CobradoOtros);
                                TotalCobrado = Convert.ToDecimal(n.Total);
                                CobredoMesAnterior = Convert.ToDecimal(n.CobradoMesAnterior);
                                CobradoHoy = Convert.ToDecimal(n.CobradoHoy);


                                lbCobradoSantoDomingoVariable.Text = CobradoSantoDomingo.ToString("N2");
                                lbCobradoSantiagoVariable.Text = CobradoSantiago.ToString("N2");
                                lbCobradoOtrosVariable.Text = CobradoOtros.ToString("N2");
                                lbTotalCobradoVariable.Text = TotalCobrado.ToString("N2");
                                lbCobradoMesAnteriorVariable.Text = CobredoMesAnterior.ToString("N2");
                                lbCobradoHoyVariable.Text = CobradoHoy.ToString("N2");
                            }
                            gbCobradoSinIntermediario.DataSource = MostrarListado;
                            gbCobradoSinIntermediario.DataBind();
                        }
                        //VALIDAMOS UN INTERMEDIARIO EN ESPESIFICO
                        else
                        {
                            if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "CampoCodogoIntermediarioVacio", "CampoCodogoIntermediarioVacio();", true);
                            }
                            else
                            {
                                var MostrarListado = ObjData.Value.ReporteCobradoCOntabilidad(
                         Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario,
                            _CodigoIntermediario);
                                foreach (var n in MostrarListado)
                                {
                                    decimal CobradoSantoDomingo = 0, CobradoSantiago = 0, CobradoOtros = 0, TotalCobrado = 0, CobredoMesAnterior = 0, CobradoHoy = 0;

                                    CobradoSantoDomingo = Convert.ToDecimal(n.CobradoSantoDomingo);
                                    CobradoSantiago = Convert.ToDecimal(n.CobradoSantiago);
                                    CobradoOtros = Convert.ToDecimal(n.CobradoOtros);
                                    TotalCobrado = Convert.ToDecimal(n.Total);
                                    CobredoMesAnterior = Convert.ToDecimal(n.CobradoMesAnterior);
                                    CobradoHoy = Convert.ToDecimal(n.CobradoHoy);


                                    lbCobradoSantoDomingoVariable.Text = CobradoSantoDomingo.ToString("N2");
                                    lbCobradoSantiagoVariable.Text = CobradoSantiago.ToString("N2");
                                    lbCobradoOtrosVariable.Text = CobradoOtros.ToString("N2");
                                    lbTotalCobradoVariable.Text = TotalCobrado.ToString("N2");
                                    lbCobradoMesAnteriorVariable.Text = CobredoMesAnterior.ToString("N2");
                                    lbCobradoHoyVariable.Text = CobradoHoy.ToString("N2");
                                }
                                gbCobradoSinIntermediario.DataSource = MostrarListado;
                                gbCobradoSinIntermediario.DataBind();
                            }
                        }

                    }
                }
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
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
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
                    //VERIFICAMOS SI LA CONSULTA LLEVA INTERMEDARIOS
                    //EN CASO DE QUE NO LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                    {
                        var Exportar = (from n in ObjData.Value.ReporteCobradoCOntabilidad(
                            FechaDesde,
                            FechaHasta,
                            FechaDesdeAnterior,
                            FechaHastaAnterior,
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario,
                            null)
                                        select new
                                        {
                                            CodRamo = n.CodRamo,
                                            Ramo = n.Ramo,
                                            CodOficina = n.CodOficina,
                                            Oficina = n.Oficina,
                                            Cobrado = n.Cobrado,
                                            CobradoHoy = n.CobradoHoy,
                                            CobradoSantoDomingo = n.CobradoSantoDomingo,
                                            CobradoSantiago = n.CobradoSantiago,
                                            CobradoOtros = n.CobradoOtros,
                                            Total = n.Total,
                                            CobradoMesAnterior = n.CobradoMesAnterior
                                        }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cobrado Sin Intermediario", Exportar);
                    }
                    //EN CASO DE QUE LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
                    {
                        //VALIDAMOS SI SE VAN A FILTRAR TODOS LOS INTERMEDIARIOS O SOLO 1
                        //VALIDAMOS TODOS LOS INTERMEDIAIOS
                        if (cbTodosLosIntermediarios.Checked)
                        {
                            var Exportar = (from n in ObjData.Value.ReporteCobradoCOntabilidad(
                            FechaDesde,
                            FechaHasta,
                            FechaDesdeAnterior,
                            FechaHastaAnterior,
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario
                            )
                                            select new
                                            {
                                                Intermediario = n.Intermediario,
                                                CodigoIntermediario = n.CodigoIntermediario,
                                                CodRamo = n.CodRamo,
                                                Ramo = n.Ramo,
                                                CodOficina = n.CodOficina,
                                                Oficina = n.Oficina,
                                                Cobrado = n.Cobrado,
                                                CobradoHoy = n.CobradoHoy,
                                                CobradoSantoDomingo = n.CobradoSantoDomingo,
                                                CobradoSantiago = n.CobradoSantiago,
                                                CobradoOtros = n.CobradoOtros,
                                                Total = n.Total,
                                                CobradoMesAnterior = n.CobradoMesAnterior
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cobrado Con Intermediario", Exportar);
                        }
                        //VALIDAMOS UN INTERMEDIARIO EN ESPESIFICO
                        else
                        {
                            var Exportar = (from n in ObjData.Value.ReporteCobradoCOntabilidad(
                            FechaDesde,
                            FechaHasta,
                            FechaDesdeAnterior,
                            FechaHastaAnterior,
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario,
                            _CodigoIntermediario)
                                            select new
                                            {
                                                Intermediario = n.Intermediario,
                                                CodigoIntermediario = n.CodigoIntermediario,
                                                CodRamo = n.CodRamo,
                                                Ramo = n.Ramo,
                                                CodOficina = n.CodOficina,
                                                Oficina = n.Oficina,
                                                Cobrado = n.Cobrado,
                                                CobradoHoy = n.CobradoHoy,
                                                CobradoSantoDomingo = n.CobradoSantoDomingo,
                                                CobradoSantiago = n.CobradoSantiago,
                                                CobradoOtros = n.CobradoOtros,
                                                Total = n.Total,
                                                CobradoMesAnterior = n.CobradoMesAnterior
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cobrado Intermediario Espesifico", Exportar);
                        }

                    }
                }
            }
        }
        #endregion
        #region EXPORTAR DATA MODO COMPARATIVO
        private void ExportarDataModoCOmparativo()
        {
            try {
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
                             Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
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
                           Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
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
                            Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
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
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
                    //VERIFICAMOS SI LA CONSULTA LLEVA INTERMEDARIOS
                    //EN CASO DE QUE NO LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                    {
                        var Exportar = (from n in ObjData.Value.ReporteCobradoCOntabilidad(
                            Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario,
                            null)
                                        select new
                                        {
                                            CodRamo = n.CodRamo,
                                            Ramo = n.Ramo,
                                            CodOficina = n.CodOficina,
                                            Oficina = n.Oficina,
                                            Cobrado = n.Cobrado,
                                            CobradoHoy = n.CobradoHoy,
                                            CobradoSantoDomingo = n.CobradoSantoDomingo,
                                            CobradoSantiago = n.CobradoSantiago,
                                            CobradoOtros = n.CobradoOtros,
                                            Total = n.Total,
                                            CobradoMesAnterior = n.CobradoMesAnterior
                                        }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cobrado Sin Intermediario", Exportar);
                    }
                    //EN CASO DE QUE LLEVE INTERMEDIARIO
                    if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
                    {
                        //VALIDAMOS SI SE VAN A FILTRAR TODOS LOS INTERMEDIARIOS O SOLO 1
                        //VALIDAMOS TODOS LOS INTERMEDIAIOS
                        if (cbTodosLosIntermediarios.Checked)
                        {
                            var Exportar = (from n in ObjData.Value.ReporteCobradoCOntabilidad(
                          Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario
                            )
                                            select new
                                            {
                                                Intermediario = n.Intermediario,
                                                CodigoIntermediario = n.CodigoIntermediario,
                                                CodRamo = n.CodRamo,
                                                Ramo = n.Ramo,
                                                CodOficina = n.CodOficina,
                                                Oficina = n.Oficina,
                                                Cobrado = n.Cobrado,
                                                CobradoHoy = n.CobradoHoy,
                                                CobradoSantoDomingo = n.CobradoSantoDomingo,
                                                CobradoSantiago = n.CobradoSantiago,
                                                CobradoOtros = n.CobradoOtros,
                                                Total = n.Total,
                                                CobradoMesAnterior = n.CobradoMesAnterior
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cobrado Con Intermediario", Exportar);
                        }
                        //VALIDAMOS UN INTERMEDIARIO EN ESPESIFICO
                        else
                        {
                            var Exportar = (from n in ObjData.Value.ReporteCobradoCOntabilidad(
                            Convert.ToDateTime(txtFechaDesdeModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaModoComparativo.Text),
                            Convert.ToDateTime(txtFechaDesdeMesAnteriorModoComparativo.Text),
                            Convert.ToDateTime(txtFechaHastaMesAnteriorModoCOmparativo.Text),
                            _Ramo,
                            _Oficina,
                            _LlevaIntermediario,
                            _CodigoIntermediario)
                                            select new
                                            {
                                                Intermediario = n.Intermediario,
                                                CodigoIntermediario = n.CodigoIntermediario,
                                                CodRamo = n.CodRamo,
                                                Ramo = n.Ramo,
                                                CodOficina = n.CodOficina,
                                                Oficina = n.Oficina,
                                                Cobrado = n.Cobrado,
                                                CobradoHoy = n.CobradoHoy,
                                                CobradoSantoDomingo = n.CobradoSantoDomingo,
                                                CobradoSantiago = n.CobradoSantiago,
                                                CobradoOtros = n.CobradoOtros,
                                                Total = n.Total,
                                                CobradoMesAnterior = n.CobradoMesAnterior
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cobrado Intermediario Espesifico", Exportar);
                        }

                    }
                }
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorExportacionConsulta", "ErrorExportacionConsulta();", true);
            }
        }
        #endregion
        #region OCULTAR Y MOSTRAR CONTROLES
        private void ModoFacturracion()
        {
            lbFacturadoHoyTitulo.Visible = true;
            lbFacturadoHoyVariable.Visible = true;
            lbFacturadoHoyCerrar.Visible = true;
            Label1.Visible = true;
            lbTotalDebitosTitulo.Visible = true;
            lbCantidadDebitosVariable.Visible = true;
            lbCantidadDebitosCerrar.Visible = true;
            Label2.Visible = true;
            lbTotalCreditosTitulo.Visible = true;
            lbTotalCretitoVariable.Visible = true;
            lbCantidadCreditosCerrar.Visible = true;
            lbOtrosTitulo.Visible = true;
            lbOtrosVariable.Visible = true;
            lbOtrosCerrar.Visible = true;
            Label3.Visible = true;
            lbTotalTitulo.Visible = true;
            LablbTotalVariableel7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            lbMesAnteriorTitulo.Visible = true;
            lbMesAnteriorvariable.Visible = true;
            Label4.Visible = true;
            gvGridConIntermediario.Visible = true;
            gvGridSinIntermediario.Visible = true;



            lbCobradoMesAnteriorCerrar.Visible = false;
            lbCobradoMesAnteriorVariable.Visible = false;
            lbCobradoMesAnteriorTitulo.Visible = false;
            lbTotalCobradoCerrar.Visible = false;
            lbTotalCobradoVariable.Visible = false;
            lbTotalCobradoTitulo.Visible = false;
            lbCobradoOtrosCerrar.Visible = false;
            lbCobradoOtrosVariable.Visible = false;
            lbCobradoOtrosTitulo.Visible = false;
            lbCobradoSantiagoCerrar.Visible = false;
            lbCobradoSantiagoVariable.Visible = false;
            lbCobradoSantiagoTitulo.Visible = false;
            lbCobradoSantoDomingoCerrar.Visible = false;
            lbCobradoSantoDomingoVariable.Visible = false;
            lbCobradoSantoDomingoTitulo.Visible = false;
            lbCobradoHoyTitulo.Visible = false;
            lbCobradoHoyVariable.Visible = false;
            lbCobradoHoyCerrar.Visible = false;
            gbCobradoConIntermediario.Visible = false;
            gbCobradoSinIntermediario.Visible = false;
        }
        private void ModoCobrado()
        {

            lbFacturadoHoyTitulo.Visible = false;
            lbFacturadoHoyVariable.Visible = false;
            lbFacturadoHoyCerrar.Visible = false;
            Label1.Visible = false;
            lbTotalDebitosTitulo.Visible = false;
            lbCantidadDebitosVariable.Visible = false;
            lbCantidadDebitosCerrar.Visible = false;
            Label2.Visible = false;
            lbTotalCreditosTitulo.Visible = false;
            lbTotalCretitoVariable.Visible = false;
            lbCantidadCreditosCerrar.Visible = false;
            lbOtrosTitulo.Visible = false;
            lbOtrosVariable.Visible = false;
            lbOtrosCerrar.Visible = false;
            Label3.Visible = false;
            lbTotalTitulo.Visible = false;
            LablbTotalVariableel7.Visible = false;
            Label8.Visible = false;
            Label9.Visible = false;
            lbMesAnteriorTitulo.Visible = false;
            lbMesAnteriorvariable.Visible = false;
            Label4.Visible = false;
            gvGridConIntermediario.Visible = false;
            gvGridSinIntermediario.Visible = false;



            lbCobradoMesAnteriorCerrar.Visible = true;
            lbCobradoMesAnteriorVariable.Visible = true;
            lbCobradoMesAnteriorTitulo.Visible = true;
            lbTotalCobradoCerrar.Visible = true;
            lbTotalCobradoVariable.Visible = true;
            lbTotalCobradoTitulo.Visible = true;
            lbCobradoOtrosCerrar.Visible = true;
            lbCobradoOtrosVariable.Visible = true;
            lbCobradoOtrosTitulo.Visible = true;
            lbCobradoSantiagoCerrar.Visible = true;
            lbCobradoSantiagoVariable.Visible = true;
            lbCobradoSantiagoTitulo.Visible = true;
            lbCobradoSantoDomingoCerrar.Visible = true;
            lbCobradoSantoDomingoVariable.Visible = true;
            lbCobradoSantoDomingoTitulo.Visible = true;
            lbCobradoHoyTitulo.Visible = true;
            lbCobradoHoyVariable.Visible = true;
            lbCobradoHoyCerrar.Visible = true;
            gbCobradoConIntermediario.Visible = true;
            gbCobradoSinIntermediario.Visible = true;

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cbModoComparativo.Checked = false;
                CargarRamos();
                CargarOficinas();
                CargarMeses();
            }
        }

        protected void ddlSeleccionarTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 1)
            {
                ModoFacturracion();
            }
            else if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 2)
            {
                ModoCobrado();
            }
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
            if (cbModoComparativo.Checked)
            {
                gvGridConIntermediario.PageIndex = e.NewPageIndex;
                CargarListadoModoCOmparativo();
            }
            else
            {
                gvGridSinIntermediario.PageIndex = e.NewPageIndex;
                CargarListado();
            }
        }

        protected void gvGridConIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (cbModoComparativo.Checked)
            {
                gvGridConIntermediario.PageIndex = e.NewPageIndex;
                CargarListadoModoCOmparativo();
            }
            else
            {
                gvGridConIntermediario.PageIndex = e.NewPageIndex;
                CargarListado();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cbModoComparativo.Checked)
            {
                CargarListadoModoCOmparativo();
            }
            else
            {
                CargarListado();
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            if (cbModoComparativo.Checked)
            {
                ExportarDataModoCOmparativo();
            }
            else
            {
                ExportarDataExel();
            }
        }

        protected void gbCobradoConIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gbCobradoSinIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void cbModoComparativo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModoComparativo.Checked == true)
            {

                lbFechaDesdeModoComparativo.Visible = true;
                txtFechaDesdeModoComparativo.Visible = true;
                lbFechaHastaModoCOmparativo.Visible = true;
                txtFechaHastaModoComparativo.Visible = true;
                lbFechaDesdeMesAnteriorModoComparativo.Visible = true;
                txtFechaDesdeMesAnteriorModoComparativo.Visible = true;
                lbFechaHastaMesAnteriorModoComparativo.Visible = true;
                txtFechaHastaMesAnteriorModoCOmparativo.Visible = true;

                lbSeleccionarMes.Enabled = false;
                ddlSeleccionarMes.Enabled = false;
                lbAno.Enabled = false;
                txtAno.Enabled = false;
            }
            else
            {
                lbFechaDesdeModoComparativo.Visible = false;
                txtFechaDesdeModoComparativo.Visible = false;
                lbFechaHastaModoCOmparativo.Visible = false;
                txtFechaHastaModoComparativo.Visible = false;
                lbFechaDesdeMesAnteriorModoComparativo.Visible = false;
                txtFechaDesdeMesAnteriorModoComparativo.Visible = false;
                lbFechaHastaMesAnteriorModoComparativo.Visible = false;
                txtFechaHastaMesAnteriorModoCOmparativo.Visible = false;

                lbSeleccionarMes.Enabled = true;
                ddlSeleccionarMes.Enabled = true;
                lbAno.Enabled = true;
                txtAno.Enabled = true;
            }
        }
    }
}