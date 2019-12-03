using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ValidarCoberturas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objdata = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarDrops()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarCpbertura, Objdata.Value.BuscaListas("COBERTURA", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPlanCobertura, Objdata.Value.BuscaListas("PLANCOBERTURA", ddlSeleccionarCpbertura.SelectedValue, null));
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LAS COBERTURAS
        private void MostrarListado()
        {
            decimal CoberturaSeleccionada = Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue);

            /*
             * 1-Tu Asistencia.
             * 2-Aeroambulancia.
             * 3-Servi Grua.
             * 4-Caribe Asistencia.
             * 5-Casa del Conductor.
             * 6-Cedensa.
             * */

            //VALIDAMOS EL TIPO DE COBERTURA SELECCIONADO


            //VALIDAMOS TU ASISTENCIA
            if (CoberturaSeleccionada == 1)
            {
                //ELEGIMOS EL TIPO DE ESTATUS PARA REALIZAR LA CONSULTA
                if (rbGeberarTodo.Checked)
                {
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                    }
                }
                else if (rbGenerarPolizasActivas.Checked)
                {
                    //BUSCAMOS SOLO LAS POLIZAS ACTIVAS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                    }
                }
                else if (rbGenerarPolizasCanceladas.Checked)
                {
                    //BUSCAMOS SOLO LAS POLIZAS CANCELADAS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                    }
                }
            }





            //VALIDAMOS AEROAMBULANCIA
            else if (CoberturaSeleccionada == 2)
            {
                //ELEGIMOS EL TIPO DE ESTATUS PARA REALIZAR LA CONSULTA
                if (rbGeberarTodo.Checked)
                {
                    //BUSCAMOS TODOS LOS ESTATUS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                        string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();
                        string _Chasis = string.IsNullOrEmpty(txtChasisFiltro.Text.Trim()) ? null : txtChasisFiltro.Text.Trim();

                        var Buscar = Objdata.Value.GenerarDataAeroAmbulancia(
                            Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                            _Poliza,
                            _Chasis,
                            null,
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text));
                        gvListadoCobertura.DataSource = Buscar;
                        gvListadoCobertura.DataBind();
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                        string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();
                        string _Chasis = string.IsNullOrEmpty(txtChasisFiltro.Text.Trim()) ? null : txtChasisFiltro.Text.Trim();

                        var Buscar = Objdata.Value.GenerarDataAeroAmbulancia(
                            Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                            _Poliza,
                            _Chasis,
                            null,
                            null,
                            null);
                        gvListadoCobertura.DataSource = Buscar;
                        gvListadoCobertura.DataBind();
                    }
                }
                else if (rbGenerarPolizasActivas.Checked)
                {
                    //BUSCAMOS SOLO LAS POLIZAS ACTIVAS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                        string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();
                        string _Chasis = string.IsNullOrEmpty(txtChasisFiltro.Text.Trim()) ? null : txtChasisFiltro.Text.Trim();

                        var Buscar = Objdata.Value.GenerarDataAeroAmbulancia(
                            Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                            _Poliza,
                            _Chasis,
                            "ACTIVO",
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text));
                        gvListadoCobertura.DataSource = Buscar;
                        gvListadoCobertura.DataBind();
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                        string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();
                        string _Chasis = string.IsNullOrEmpty(txtChasisFiltro.Text.Trim()) ? null : txtChasisFiltro.Text.Trim();

                        var Buscar = Objdata.Value.GenerarDataAeroAmbulancia(
                            Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                            _Poliza,
                            _Chasis,
                            "ACTIVO",
                            null,
                            null);
                        gvListadoCobertura.DataSource = Buscar;
                        gvListadoCobertura.DataBind();
                    }
                }
                else if (rbGenerarPolizasCanceladas.Checked)
                {
                    //BUSCAMOS SOLO LAS POLIZAS CANCELADAS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                        string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();
                        string _Chasis = string.IsNullOrEmpty(txtChasisFiltro.Text.Trim()) ? null : txtChasisFiltro.Text.Trim();

                        var Buscar = Objdata.Value.GenerarDataAeroAmbulancia(
                            Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                            _Poliza,
                            _Chasis,
                            "CANCELADA",
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text));
                        gvListadoCobertura.DataSource = Buscar;
                        gvListadoCobertura.DataBind();
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                        string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();
                        string _Chasis = string.IsNullOrEmpty(txtChasisFiltro.Text.Trim()) ? null : txtChasisFiltro.Text.Trim();

                        var Buscar = Objdata.Value.GenerarDataAeroAmbulancia(
                            Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                            _Poliza,
                            _Chasis,
                            "CANCELADA",
                            null,
                            null);
                        gvListadoCobertura.DataSource = Buscar;
                        gvListadoCobertura.DataBind();
                    }
                }
            }






            //VALIDAMOS SERVI GRUA
            else if (CoberturaSeleccionada == 3)
            {
                //ELEGIMOS EL TIPO DE ESTATUS PARA REALIZAR LA CONSULTA
                if (rbGeberarTodo.Checked)
                {
                    //BUSCAMOS TODOS LOS ESTATUS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                    }
                }
                else if (rbGenerarPolizasActivas.Checked)
                {
                    //BUSCAMOS SOLO LAS POLIZAS ACTIVAS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                    }
                }
                else if (rbGenerarPolizasCanceladas.Checked)
                {
                    //BUSCAMOS SOLO LAS POLIZAS CANCELADAS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                    }
                }
            }





            //VALIDAMOS CARIBE ASISTENCIA
            else if (CoberturaSeleccionada == 4)
            {
                //ELEGIMOS EL TIPO DE ESTATUS PARA REALIZAR LA CONSULTA
                if (rbGeberarTodo.Checked)
                {
                    //BUSCAMOS TODOS LOS ESTATUS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                    }
                }
                else if (rbGenerarPolizasActivas.Checked)
                {
                    //BUSCAMOS SOLO LAS POLIZAS ACTIVAS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                    }
                }
                else if (rbGenerarPolizasCanceladas.Checked)
                {
                    //BUSCAMOS SOLO LAS POLIZAS CANCELADAS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                    }
                }
            }






            //VALIDAMOS CASA DEL CONDUCTOR
            else if (CoberturaSeleccionada == 5)
            {
                //ELEGIMOS EL TIPO DE ESTATUS PARA REALIZAR LA CONSULTA
                if (rbGeberarTodo.Checked)
                {
                    //BUSCAMOS TODOS LOS ESTATUS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                    }
                }
                else if (rbGenerarPolizasActivas.Checked)
                {
                    //BUSCAMOS SOLO LAS POLIZAS ACTIVAS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                    }
                }
                else if (rbGenerarPolizasCanceladas.Checked)
                {
                    //BUSCAMOS SOLO LAS POLIZAS CANCELADAS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                    }
                }
            }





            //VALIDAMOS CEDENSA
            else if (CoberturaSeleccionada == 6)
            {
                //ELEGIMOS EL TIPO DE ESTATUS PARA REALIZAR LA CONSULTA
                if (rbGeberarTodo.Checked)
                {
                    //BUSCAMOS TODOS LOS ESTATUS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                    }
                }
                else if (rbGenerarPolizasActivas.Checked)
                {
                    //BUSCAMOS SOLO LAS POLIZAS ACTIVAS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                    }
                }
                else if (rbGenerarPolizasCanceladas.Checked)
                {
                    //BUSCAMOS SOLO LAS POLIZAS CANCELADAS
                    //BUSCAMOS TODOS LOS ESTATUS
                    //VERIFICAMOS SI SE VAN AGREGAR LOS RANGO DE FECHAS
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //CONSULTAMOS
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //CONSULTAMOS
                    }
                }
            }
      
        }
        #endregion
        #region EXPORTAR DATA
        private void ExportarData()
        {
            /*
         * 1-Tu Asistencia.
         * 2-Aeroambulancia.
         * 3-Servi Grua.
         * 4-Caribe Asistencia.
         * 5-Casa del Conductor.
         * 6-Cedensa.
         * */

            //VALIDAMOS EL TIPO DE COBERTURA SELECCIONADA
            decimal CoberturaSeleccionada = Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue);

            #region EXPORTAMOS LA PARTE DE TU ASISTENCIA
            if (CoberturaSeleccionada == 1)
            {

            }
            #endregion

            #region EXPORTAMOS LA PARTE DE AEROAMBULANCIA
            else if (CoberturaSeleccionada == 2)
            {
                //VALIDAMOS EL ESTATUS
                if (rbGeberarTodo.Checked)
                {
                    //VERIFICAMOS SI LLEVA RANGO DE FECHA
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //VERIFICAMOS EL TIPO E EXPORTACION
                        if (rbExportarExel.Checked)
                        {
                            try
                            {
                                string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();
                                string _Chasis = string.IsNullOrEmpty(txtChasisFiltro.Text.Trim()) ? null : txtChasisFiltro.Text.Trim();

                                var Exportar = (from n in Objdata.Value.GenerarDataAeroAmbulancia(
                                    Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                                    _Poliza,
                                    _Chasis,
                                    null,
                                    Convert.ToDateTime(txtFechaDesde.Text),
                                    Convert.ToDateTime(txtFechaHasta.Text))
                                                select new
                                                {
                                                    Poliza = n.Poliza,
                                                    Cliente = n.Cliente,
                                                    NumeroIdentificacion = n.NumeroIdentificacion,
                                                    Telefonos = n.Telefonos,
                                                    InicioVigencia = n.InicioVigencia,
                                                    FinVigencia = n.FinVigencia,
                                                    TipoVehiculo = n.TipoVehiculo,
                                                    Marca = n.Marca,
                                                    Modelo = n.Modelo,
                                                    Capacidad = n.Capacidad,
                                                    Color = n.Color,
                                                    Ano = n.Ano,
                                                    Chasis = n.Chasis,
                                                    Placa = n.Placa,
                                                    ValorAsegurado = n.ValorAsegurado,
                                                    Cobertura = n.Cobertura,
                                                    TipoPlan = n.TipoPlan,
                                                    Estatus = n.Estatus
                                                }).ToList();
                                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Aero Ambulancia Auto Alert Plus 1", Exportar);
                            }
                            catch (Exception)
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorExportarData();", true);
                            }
                        }
                        else if (rbExportarcsv.Checked)
                        {

                        }
                        else if (rbExportartxt.Checked)
                        {

                        }
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        //VERIFICAMOS EL TIPO E EXPORTACION
                        if (rbExportarExel.Checked)
                        {
                            try {
                                string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();
                                string _Chasis = string.IsNullOrEmpty(txtChasisFiltro.Text.Trim()) ? null : txtChasisFiltro.Text.Trim();

                                var Exportar = (from n in Objdata.Value.GenerarDataAeroAmbulancia(
                                    Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                                    _Poliza,
                                    _Chasis,
                                    null,
                                    null,
                                    null)
                                                select new
                                                {
                                                    Poliza = n.Poliza,
                                                    Cliente = n.Cliente,
                                                    NumeroIdentificacion = n.NumeroIdentificacion,
                                                    Telefonos = n.Telefonos,
                                                    InicioVigencia = n.InicioVigencia,
                                                    FinVigencia = n.FinVigencia,
                                                    TipoVehiculo = n.TipoVehiculo,
                                                    Marca = n.Marca,
                                                    Modelo = n.Modelo,
                                                    Capacidad = n.Capacidad,
                                                    Color = n.Color,
                                                    Ano = n.Ano,
                                                    Chasis = n.Chasis,
                                                    Placa = n.Placa,
                                                    ValorAsegurado = n.ValorAsegurado,
                                                    Cobertura = n.Cobertura,
                                                    TipoPlan = n.TipoPlan,
                                                    Estatus = n.Estatus
                                                }).ToList();
                                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Aero Ambulancia Auto Alert Plus 1", Exportar);
                            }
                            catch (Exception) {
                                ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorExportarData();", true);
                            }
                        }
                        else if (rbExportarcsv.Checked)
                        {

                        }
                        else if (rbExportartxt.Checked)
                        {

                        }
                    }
                }

                else if (rbGenerarPolizasActivas.Checked)
                {
                  
                }

                else if (rbGenerarPolizasCanceladas.Checked)
                {
                    //VALIDAMOS EL ESTATUS
                    if (rbGeberarTodo.Checked)
                    {
                        //VERIFICAMOS SI LLEVA RANGO DE FECHA
                        if (rbGenerarDataRangoFecha.Checked)
                        {
                            //VERIFICAMOS EL TIPO E EXPORTACION
                            if (rbExportarExel.Checked)
                            {
                                try
                                {
                                    string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();
                                    string _Chasis = string.IsNullOrEmpty(txtChasisFiltro.Text.Trim()) ? null : txtChasisFiltro.Text.Trim();

                                    var Exportar = (from n in Objdata.Value.GenerarDataAeroAmbulancia(
                                        Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                                        _Poliza,
                                        _Chasis,
                                        "CANCELADA",
                                        null,
                                        null)
                                                    select new
                                                    {
                                                        Poliza = n.Poliza,
                                                        Cliente = n.Cliente,
                                                        NumeroIdentificacion = n.NumeroIdentificacion,
                                                        Telefonos = n.Telefonos,
                                                        InicioVigencia = n.InicioVigencia,
                                                        FinVigencia = n.FinVigencia,
                                                        TipoVehiculo = n.TipoVehiculo,
                                                        Marca = n.Marca,
                                                        Modelo = n.Modelo,
                                                        Capacidad = n.Capacidad,
                                                        Color = n.Color,
                                                        Ano = n.Ano,
                                                        Chasis = n.Chasis,
                                                        Placa = n.Placa,
                                                        ValorAsegurado = n.ValorAsegurado,
                                                        Cobertura = n.Cobertura,
                                                        TipoPlan = n.TipoPlan,
                                                        Estatus = n.Estatus
                                                    }).ToList();
                                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Aero Ambulancia Auto Alert Plus 1", Exportar);
                                }
                                catch (Exception)
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorExportarData();", true);
                                }
                            }
                            else if (rbExportarcsv.Checked)
                            {

                            }
                            else if (rbExportartxt.Checked)
                            {

                            }
                        }
                        else if (rbGenerarDataCompleta.Checked)
                        {

                        }
                    }
                }
            }
            #endregion

            #region EXPORTAMOS LA PARTE DE SERVI GRUA
            if (CoberturaSeleccionada == 3)
            {

            }
            #endregion

            #region EXPORAMOS LA PARTE DE CARIBE ASISTENCIA
            if (CoberturaSeleccionada == 4)
            {

            }
            #endregion

            #region EXPORTAMOS LA PARTE DE CASA DEL CONDUCTOR
            if (CoberturaSeleccionada == 5)
            {

            }
            #endregion

            #region EXPORTAMOS LA PARTE DE CEDENSA
            if (CoberturaSeleccionada == 6)
            {

            }
            #endregion


        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rbGenerarDataCompleta.Checked = true;
                rbExportarExel.Checked = true;
                rbGeberarTodo.Checked = true;
                CargarDrops();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListado();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            try {
                ExportarData();
            }
            catch (Exception) { }
        }

        protected void gvListadoCobertura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoCobertura.PageIndex = e.NewPageIndex;
            MostrarListado();
        }

        protected void gvListadoCobertura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rbGenerarDataRangoFecha_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        protected void rbGenerarDataCompleta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGenerarDataCompleta.Checked)
            {
                lbFechaDesde.Visible = false;
                txtFechaDesde.Visible = false;
                lbFechaHasta.Visible = false;
                txtFechaHasta.Visible = false;
            }
            else
            {
                lbFechaDesde.Visible = true;
                txtFechaDesde.Visible = true;
                lbFechaHasta.Visible = true;
                txtFechaHasta.Visible = true;
            }
        }

        protected void rbGenerarDataRangoFecha_CheckedChanged1(object sender, EventArgs e)
        {
            if (rbGenerarDataRangoFecha.Checked)
            {
                lbFechaDesde.Visible = true;
                txtFechaDesde.Visible = true;
                lbFechaHasta.Visible = true;
                txtFechaHasta.Visible = true;
            }
            else
            {
                lbFechaDesde.Visible = false;
                txtFechaDesde.Visible = false;
                lbFechaHasta.Visible = false;
                txtFechaHasta.Visible = false;
            }
        }

        protected void ddlSeleccionarCpbertura_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPlanCobertura, Objdata.Value.BuscaListas("PLANCOBERTURA", ddlSeleccionarCpbertura.SelectedValue, null), true);
        }
    }
}