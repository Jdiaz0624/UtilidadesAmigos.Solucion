using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//EXPORTAMOS A EXEL
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
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
            var CArgar = ObjDataLogica.Value.CargarRamos(
                new Nullable<int>(),
                null);
            ddlRamo.DataSource = CArgar;
            ddlRamo.DataValueField = "IdRamo";
            ddlRamo.DataTextField = "Ramo";
            ddlRamo.DataBind();
            ddlRamo.Items.Insert(0, "Seleccionar");

        }
        #endregion
        #region PROCESO PARA CARGAR TODOS LOS RAMOS
        //CARGAR LA DATA DE LA TABLA
        private void CargarDataProduccionTodosLosRamos(decimal Idusuario, decimal IdDepartamento, decimal IdPerfil)
        {
            var Cargar = ObjDataLogica.Value.BuscaProduccionTodosLosRamos(
                null,
                null,
                null);
            gbListado.DataSource = Cargar;
            gbListado.DataBind();
        }

        private void GuardarDatosProduccionTodosLosRamos(string Accion)
        {
            UtilidadesAmigos.Logica.Entidades.EMantenimientoProduccionTodosLosRamos Mantenimiento = new Logica.Entidades.EMantenimientoProduccionTodosLosRamos();

            Mantenimiento.IdUsuario = 1;
            Mantenimiento.IdDepartamento = 1;
            Mantenimiento.IdPerfil = 1;
            Mantenimiento.Ramo = VariablesGlobales.Ramo;
            Mantenimiento.Concepto = VariablesGlobales.Concepto;
            Mantenimiento.Total = VariablesGlobales.Total;
            Mantenimiento.FacturadoEnPesos = VariablesGlobales.FacturadoPesos;
            Mantenimiento.FacturadoEnDollar = VariablesGlobales.FacturadoDollar;
            Mantenimiento.FacturadoTotal = VariablesGlobales.FacturadoTotal;
            Mantenimiento.FacturadoNeto = VariablesGlobales.FacturadoNeto;
            Mantenimiento.ValidadoDesde = Convert.ToDateTime(txtFechaDesde.Text);
            Mantenimiento.ValidadoHasta = Convert.ToDateTime(txtFechaHasta.Text);

            var MAN = ObjDataLogica.Value.MantenimientoProduccionTodosLosRamos(Mantenimiento, Accion);
        }
        #endregion
        #region MOSTRAR EL DETALLE DE LOS CONCEPTOS
        private void MostrarDetalleConsulta(DateTime FechaDesde, DateTime FechaHasta, string Concepto, string Ramo)
        {
            var Buscar = ObjDataLogica.Value.MostrarProduccionDiariaDetalle(
                FechaDesde,
                FechaHasta,
                Concepto, 
                Ramo);
            gbProduccionDiariaDetalle.DataSource = Buscar;
            gbProduccionDiariaDetalle.DataBind();

            //CEBTRALIZAMOS LOS RESULTADOS
            gbProduccionDiariaDetalle.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gbProduccionDiariaDetalle.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gbProduccionDiariaDetalle.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gbProduccionDiariaDetalle.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }
        #endregion
        #region OCULTAR CONTROLES
        private void DeshabilitarControles()
        {
            txtNombreArchivo.Enabled = false;
            txtFechaDesde.Enabled = false;
            txtFechaHasta.Enabled = false;
            rbConRamo.Enabled = false;
            rbSinRamo.Enabled = false;
            ddlRamo.Enabled = false;
            btnBuscar.Visible = false;
            btnExportarExel.Enabled = false;
            btnAtras.Visible = true;
        }
        private void HabilitarControles()
        {
            txtNombreArchivo.Enabled = true;
            txtFechaDesde.Enabled = true;
            txtFechaHasta.Enabled = true;
            rbConRamo.Enabled = true;
            rbSinRamo.Enabled = true;
            ddlRamo.Enabled = true;
            btnBuscar.Visible = true;
            btnExportarExel.Enabled = true;
            btnAtras.Visible = false;
            gbProduccionDiariaDetalle.Visible = false;
            gbListado.Visible = true;
            btnprueba.Visible = false;
            lbNombreArchivoDetalle.Visible = false;
        }
        #endregion
        private void CargarData()
        {
            try
            {
                if (rbConRamo.Checked == true)
                {
                    var Buscar = ObjDataLogica.Value.BuscaProduccionDiaria(
                   Convert.ToDateTime(txtFechaDesde.Text),
                   Convert.ToDateTime(txtFechaHasta.Text),
                   Convert.ToInt32(ddlRamo.SelectedValue));
                    gbListado.DataSource = Buscar;
                    gbListado.DataBind();

                    gbListado.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    gbListado.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    gbListado.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    gbListado.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                }
                else
                {
                    //LIMPIAMOS LA TABLA
                    GuardarDatosProduccionTodosLosRamos("DELETE");
                    //BUSCAMOS LOS RAMOS Y RECORREMOS LOS RAMOS
                    var BuscarRamos = ObjDataLogica.Value.CargarRamos(
                        new Nullable<int>(),
                        null);
                    foreach (var n in BuscarRamos)
                    {
                        VariablesGlobales.IdRamo = Convert.ToInt32(n.IdRamo);

                        //BUSCAMOS LA PRODUCCION MEDIANTE EL RAMO SACADO
                        var SacarProduccion = ObjDataLogica.Value.BuscaProduccionDiaria(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text),
                            VariablesGlobales.IdRamo);
                        foreach (var n2 in SacarProduccion)
                        {
                            VariablesGlobales.Ramo = n2.Ramo;
                            VariablesGlobales.Concepto = n2.Concepto;
                            VariablesGlobales.Total = Convert.ToInt32(n2.Total);
                            VariablesGlobales.FacturadoPesos = Convert.ToDecimal(n2.FacturadoPesos);
                            VariablesGlobales.FacturadoDollar = Convert.ToDecimal(n2.FacturadoDollar);
                            VariablesGlobales.FacturadoTotal = Convert.ToDecimal(n2.facturadoTotal);
                            VariablesGlobales.FacturadoNeto = Convert.ToDecimal(n2.FacturadoNeto);
                            GuardarDatosProduccionTodosLosRamos("INSERT");
                        }
                    }
                    CargarDataProduccionTodosLosRamos(1, 1, 1);
                }
                gbListado.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                gbListado.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                gbListado.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                gbListado.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;


            }
            catch (Exception) { }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rbConRamo.Checked = true;
                CargarRamos();
                VariablesGlobales.ExportarExel = false;
            }
          

        }

        protected void ddlRamo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gbProduccionDiariaDetalle.Visible = false;
            gbListado.Visible = true;
            lbNombreArchivoDetalle.Visible = false;
            btnprueba.Visible = false;
            CargarData();
           
           
        }

        protected void btnExportarExel_Click(object sender, EventArgs e)
        {
            // ExportGridToExcel();
            var ExportarExel = (from n in ObjDataLogica.Value.BuscaProduccionDiaria(
                Convert.ToDateTime(txtFechaDesde.Text),
                Convert.ToDateTime(txtFechaHasta.Text),
                Convert.ToInt32(ddlRamo.SelectedValue))
                                select new
                                {
                                    Ramo = n.Ramo,
                                    Concepto = n.Concepto,
                                    Total = n.Total,
                                    FacturadoPesos = n.FacturadoPesos,
                                    FacturadoDollar = n.FacturadoDollar,
                                    facturadoTotal = n.facturadoTotal,
                                    FacturadoNeto = n.FacturadoNeto
                                }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion desde " +  string.Format("{0:dd/mm/yyyy}",txtFechaDesde.Text) + "Hasta " + txtFechaHasta.Text, ExportarExel);
        }

        protected void gbListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbListado.PageIndex = e.NewPageIndex;
            CargarData();
        }

        protected void rbConRamo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConRamo.Checked)
            {
                ddlRamo.Visible = true;
                llbSeleccionar.Visible = true;
                CargarRamos();
            }
            else
            {
                ddlRamo.Visible = false;
                llbSeleccionar.Visible = false;
            }
        }

        protected void rbSinRamo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSinRamo.Checked)
            {
                ddlRamo.Visible = false;
                llbSeleccionar.Visible = false;
            }
            else
            {
                ddlRamo.Visible = true;
                llbSeleccionar.Visible = true;
                CargarRamos();
            }
        }

        protected void gbListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gbListado.SelectedRow;
            //Sacamos los datos para el filtro
            VariablesGlobales.FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            VariablesGlobales.FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            VariablesGlobales.ConceptoDetalle = gb.Cells[1].Text;
            VariablesGlobales.RamoDetalle = gb.Cells[0].Text;
            lbConcepto.Text = gb.Cells[1].Text;
            lbRamo.Text= gb.Cells[0].Text;
            gbListado.Visible = false;
            gbProduccionDiariaDetalle.Visible = true;
            lbNombreArchivoDetalle.Visible = true;
            llbConcepto.Visible = true;
            llbRamo.Visible = true;
            llbConcepto.Text = gb.Cells[1].Text;
            llbRamo.Text = gb.Cells[0].Text;
            lbNombreArchivoDetalle.Text = "Detalle de " + VariablesGlobales.ConceptoDetalle + " del Ramo " + VariablesGlobales.RamoDetalle;

            //REALIZAMOS LA CONSULTA
            MostrarDetalleConsulta(
                VariablesGlobales.FechaDesde,
                VariablesGlobales.FechaHasta,
                VariablesGlobales.ConceptoDetalle,
                VariablesGlobales.RamoDetalle);
            btnprueba.Visible = true;
            llbConcepto.Visible = false;
            llbRamo.Visible = false;
            DeshabilitarControles();
        }

        protected void gbProduccionDiariaDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gbGridExel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cbTodosLosRegistros_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnExportarExelDetalle_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnExportarExelDetalle_Click1(object sender, EventArgs e)
        {
           // ExportarGridToExelDetalle();
        }

        protected void btnprueba_Click(object sender, EventArgs e)
        {
            //ExportarGridToExelDetalle();
            //EXPORTAMOS LOS DATOS A EXEL
            var ExportarExel = (from n in ObjDataLogica.Value.MostrarProduccionDiariaDetalle(
                Convert.ToDateTime(txtFechaDesde.Text),
                Convert.ToDateTime(txtFechaHasta.Text),
                lbConcepto.Text,
                lbRamo.Text)
                                select new
                                {
                                    Ramo=n.Ramo,
                                    Subramo=n.Subramo,
                                    Concepto=n.Concepto,
                                    Total=n.Cantidad,
                                    Facturadopesos = n.FacturadoPesos,
                                    FacturadoDollar = n.FacturadoDollar,
                                    FacturadoTotal = n.FacturadoTotal,
                                    FacturadoNeto = n.FacturadoNeto
                                }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(lbNombreArchivoDetalle.Text, ExportarExel);
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            HabilitarControles();
        }
    }
}
 