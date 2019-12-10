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
                try {
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
                catch (Exception) {
                    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true);
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
               // try {
                    //GENERAMOS TODA LA DATA
                    if (rbGeberarTodo.Checked)
                    {
                        //GENERAMOS LA CONSULTA POR RANGO DE FECHA
                        if (rbGenerarDataRangoFecha.Checked)
                        {
                            string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();

                            var Buscar = Objdata.Value.GenerarDataCedensa(
                                _Poliza,
                                null,
                                Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text));
                            gvListadoCobertura.DataSource = Buscar;
                            gvListadoCobertura.DataBind();
                        }
                        //GENERAMOS LA DATA COMPLETA
                        else if (rbGenerarDataCompleta.Checked)
                        {
                            string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();

                            var Buscar = Objdata.Value.GenerarDataCedensa(
                                _Poliza,
                                null,
                                Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue));
                            gvListadoCobertura.DataSource = Buscar;
                            gvListadoCobertura.DataBind();
                        }
                    }

                    //GENERAMOS SOLO LAS POLIZAS ACTIVAS
                    else if (rbGenerarPolizasActivas.Checked)
                    {
                        //GENERAMOS LA CONSULTA POR RANGO DE FECHA
                        if (rbGenerarDataRangoFecha.Checked)
                        {
                            string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();

                            var Buscar = Objdata.Value.GenerarDataCedensa(
                                _Poliza,
                                "ACTIVO",
                                Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text));
                            gvListadoCobertura.DataSource = Buscar;
                            gvListadoCobertura.DataBind();
                        }
                        //GENERAMOS LA DATA COMPLETA
                        else if (rbGenerarDataCompleta.Checked)
                        {
                            string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();

                            var Buscar = Objdata.Value.GenerarDataCedensa(
                                _Poliza,
                                "ACTIVO",
                                Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue));
                            gvListadoCobertura.DataSource = Buscar;
                            gvListadoCobertura.DataBind();
                        }
                    }

                    //GENERAMOS SOLO LAS POLIZAS CANCELADAS
                    else if (rbGenerarPolizasCanceladas.Checked)
                    {
                        //GENERAMOS LA CONSULTA POR RANGO DE FECHA
                        if (rbGenerarDataRangoFecha.Checked)
                        {
                            string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();

                            var Buscar = Objdata.Value.GenerarDataCedensa(
                                _Poliza,
                                "CANCELADA",
                                Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text));
                            gvListadoCobertura.DataSource = Buscar;
                            gvListadoCobertura.DataBind();
                        }
                        //GENERAMOS LA DATA COMPLETA
                        else if (rbGenerarDataCompleta.Checked)
                        {
                            string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();

                            var Buscar = Objdata.Value.GenerarDataCedensa(
                                _Poliza,
                                "CANCELADA",
                                Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue));
                            gvListadoCobertura.DataSource = Buscar;
                            gvListadoCobertura.DataBind();
                        }
                    }

                //}
                //catch (Exception) {
                //    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true);
                //}
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

            //PENDIENTE
            #region EXPORTAMOS LA PARTE DE TU ASISTENCIA
            if (CoberturaSeleccionada == 1)
            {

            }
            #endregion

            //COMPLETO
            #region EXPORTAMOS LA PARTE DE AEROAMBULANCIA
            else if (CoberturaSeleccionada == 2)
            {
                //VALIDAMOS EL ESTATUS
                //EXPORTAMOS TODA LA DATA
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

                //EXPORTAMOS SOLAMENTE LAS POLIZAS ACTIVAS
                else if (rbGenerarPolizasActivas.Checked)
                {
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        if (rbExportarExel.Checked)
                        {
                            //EXPORTAMOS LAS POLIZAS ACTIVAS MEDIANTE RANGO DE FECHA A EXEL
                            string _poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();
                            string _Chasis = string.IsNullOrEmpty(txtChasisFiltro.Text.Trim()) ? null : txtChasisFiltro.Text.Trim();

                            var Exportar = (from n in Objdata.Value.GenerarDataAeroAmbulancia(
                                Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                                _poliza,
                                _Chasis,
                                "ACTIVO",
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
                        else if (rbExportarcsv.Checked)
                        {

                        }
                        else if (rbExportartxt.Checked)
                        {

                        }
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        if (rbExportarExel.Checked)
                        {
                            //EXPORTAMOS LAS POLIZAS ACTIVAS MEDIANTE RANGO DE FECHA A EXEL
                            string _poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();
                            string _Chasis = string.IsNullOrEmpty(txtChasisFiltro.Text.Trim()) ? null : txtChasisFiltro.Text.Trim();

                            var Exportar = (from n in Objdata.Value.GenerarDataAeroAmbulancia(
                                Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                                _poliza,
                                _Chasis,
                                "ACTIVO",
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
                        else if (rbExportarcsv.Checked)
                        {

                        }
                        else if (rbExportartxt.Checked)
                        {

                        }
                    }
                }

                //EXPORTAMOS SOLAMENTE LAS POLIZAS CANCELADAS
                else if (rbGenerarPolizasCanceladas.Checked)
                {
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        if (rbExportarExel.Checked)
                        {
                            string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();
                            string _Chasis = string.IsNullOrEmpty(txtChasisFiltro.Text.Trim()) ? null : txtChasisFiltro.Text.Trim();

                            var Exportar = (from n in Objdata.Value.GenerarDataAeroAmbulancia(
                                Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                                _Poliza,
                                _Chasis,
                                "CANCELADA",
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
                        else if (rbExportarcsv.Checked)
                        {

                        }
                        else if (rbExportartxt.Checked)
                        {

                        }
                    }
                    else if (rbGenerarDataCompleta.Checked)
                    {
                        if (rbExportarExel.Checked)
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
                        else if (rbExportarcsv.Checked)
                        {

                        }
                        else if (rbExportartxt.Checked)
                        {

                        }
                    }

                }
            }
            #endregion

            //PENDIENTE
            #region EXPORTAMOS LA PARTE DE SERVI GRUA
            if (CoberturaSeleccionada == 3)
            {

            }
            #endregion

            //PENDIENTE
            #region EXPORAMOS LA PARTE DE CARIBE ASISTENCIA
            if (CoberturaSeleccionada == 4)
            {

            }
            #endregion

            //PENDIENTE
            #region EXPORTAMOS LA PARTE DE CASA DEL CONDUCTOR
            if (CoberturaSeleccionada == 5)
            {

            }
            #endregion

            //PENDIENTE
            #region EXPORTAMOS LA PARTE DE CEDENSA
            if (CoberturaSeleccionada == 6)
            {
                //VERIFICAMOS SI SE VA A EXPORTAR TODA LA DATA
                if (rbGeberarTodo.Checked)
                {
                    //EXPORTAMOS MEDIANTE RANGO FECHA
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //EXPORTAMOS LA DATA A EXEL
                        if (rbExportarExel.Checked)
                        {
                            string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();

                            var Exportar = (from n in Objdata.Value.GenerarDataCedensa(
                                _Poliza,
                                null,
                                Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text))
                                            select new
                                            {
                                                Poliza=n.Poliza,
                                                Cotizacion=n.Cotizacion,
                                                CodRamo=n.CodRamo,
                                                Ramo=n.Ramo,
                                                FechaAdiciona=n.FechaAdiciona,
                                                Codigo=n.Codigo,
                                                InicioVigencia=n.InicioVigencia,
                                                FinVigencia=n.FinVigencia,
                                                TipoPlan =n.TipoPlan,
                                                Estatus=n.Estatus,
                                                Parentezco=n.Parentezco,
                                                Nombre=n.Nombre,
                                                Provincia=n.Provincia,
                                                Direccion=n.Direccion,
                                                Telefono=n.Telefono,
                                                Cedula=n.Cedula,
                                                FechaNacimiento=n.FechadeNacimiento,
                                                Edad=n.Edad,
                                                Prima=n.Prima,
                                                Cobertura=n.Cobertura
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Data Cedensa Completa", Exportar);
                        }
                        //EXPORTAMOS A CSV
                        if (rbExportarcsv.Checked)
                        {

                        }
                        //EXPORTAMOS A TXT
                        if (rbExportartxt.Checked)
                        {

                        }
                    }

                    //EXPORTAMOS SIN RANGO DE FECHA
                    if (rbGenerarDataCompleta.Checked)
                    {
                        //EXPORTAMOS LA DATA A EXEL
                        if (rbExportarExel.Checked)
                        {
                            string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();

                            var Exportar = (from n in Objdata.Value.GenerarDataCedensa(
                                _Poliza,
                                null,
                                Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                                null,
                                null)
                                            select new
                                            {
                                                Poliza = n.Poliza,
                                                Cotizacion = n.Cotizacion,
                                                CodRamo = n.CodRamo,
                                                Ramo = n.Ramo,
                                                FechaAdiciona = n.FechaAdiciona,
                                                Codigo = n.Codigo,
                                                InicioVigencia = n.InicioVigencia,
                                                FinVigencia = n.FinVigencia,
                                                TipoPlan = n.TipoPlan,
                                                Estatus = n.Estatus,
                                                Parentezco = n.Parentezco,
                                                Nombre = n.Nombre,
                                                Provincia = n.Provincia,
                                                Direccion = n.Direccion,
                                                Telefono = n.Telefono,
                                                Cedula = n.Cedula,
                                                FechaNacimiento = n.FechadeNacimiento,
                                                Edad = n.Edad,
                                                Prima = n.Prima,
                                                Cobertura = n.Cobertura
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Data Cedensa Completa", Exportar);
                        }
                        //EXPORTAMOS A CSV
                        if (rbExportarcsv.Checked)
                        {

                        }
                        //EXPORTAMOS A TXT
                        if (rbExportartxt.Checked)
                        {

                        }

                    }
                }

                //EXPORTAMOS SOLO LAS POLIZAS ACTIVAS
                else if (rbGenerarPolizasActivas.Checked)
                {
                    //EXPORTAMOS MEDIANTE RANGO FECHA
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //EXPORTAMOS LA DATA A EXEL
                        if (rbExportarExel.Checked)
                        {
                            string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();

                            var Exportar = (from n in Objdata.Value.GenerarDataCedensa(
                                _Poliza,
                                "ACTIVO",
                                Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text))
                                            select new
                                            {
                                                Poliza = n.Poliza,
                                                Cotizacion = n.Cotizacion,
                                                CodRamo = n.CodRamo,
                                                Ramo = n.Ramo,
                                                FechaAdiciona = n.FechaAdiciona,
                                                Codigo = n.Codigo,
                                                InicioVigencia = n.InicioVigencia,
                                                FinVigencia = n.FinVigencia,
                                                TipoPlan = n.TipoPlan,
                                                Estatus = n.Estatus,
                                                Parentezco = n.Parentezco,
                                                Nombre = n.Nombre,
                                                Provincia = n.Provincia,
                                                Direccion = n.Direccion,
                                                Telefono = n.Telefono,
                                                Cedula = n.Cedula,
                                                FechaNacimiento = n.FechadeNacimiento,
                                                Edad = n.Edad,
                                                Prima = n.Prima,
                                                Cobertura = n.Cobertura
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Data Cedensa Completa", Exportar);
                        }
                        //EXPORTAMOS A CSV
                        if (rbExportarcsv.Checked)
                        {

                        }
                        //EXPORTAMOS A TXT
                        if (rbExportartxt.Checked)
                        {

                        }
                    }

                    //EXPORTAMOS SIN RANGO DE FECHA
                    if (rbGenerarDataCompleta.Checked)
                    {
                        //EXPORTAMOS LA DATA A EXEL
                        if (rbExportarExel.Checked)
                        {
                            string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();

                            var Exportar = (from n in Objdata.Value.GenerarDataCedensa(
                                _Poliza,
                                "ACTIVO",
                                Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue))
                                            select new
                                            {
                                                Poliza = n.Poliza,
                                                Cotizacion = n.Cotizacion,
                                                CodRamo = n.CodRamo,
                                                Ramo = n.Ramo,
                                                FechaAdiciona = n.FechaAdiciona,
                                                Codigo = n.Codigo,
                                                InicioVigencia = n.InicioVigencia,
                                                FinVigencia = n.FinVigencia,
                                                TipoPlan = n.TipoPlan,
                                                Estatus = n.Estatus,
                                                Parentezco = n.Parentezco,
                                                Nombre = n.Nombre,
                                                Provincia = n.Provincia,
                                                Direccion = n.Direccion,
                                                Telefono = n.Telefono,
                                                Cedula = n.Cedula,
                                                FechaNacimiento = n.FechadeNacimiento,
                                                Edad = n.Edad,
                                                Prima = n.Prima,
                                                Cobertura = n.Cobertura
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Data Cedensa Activas", Exportar);
                        }
                        //EXPORTAMOS A CSV
                        if (rbExportarcsv.Checked)
                        {

                        }
                        //EXPORTAMOS A TXT
                        if (rbExportartxt.Checked)
                        {

                        }

                    }
                }

                //EXPORTAMOS SOLO LAS POLIZAS CANCELADAS
                else if (rbGenerarPolizasCanceladas.Checked)
                {
                    //EXPORTAMOS MEDIANTE RANGO FECHA
                    if (rbGenerarDataRangoFecha.Checked)
                    {
                        //EXPORTAMOS LA DATA A EXEL
                        if (rbExportarExel.Checked)
                        {
                            string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();

                            var Exportar = (from n in Objdata.Value.GenerarDataCedensa(
                                _Poliza,
                                "CANCELADA",
                                Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue),
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text))
                                            select new
                                            {
                                                Poliza = n.Poliza,
                                                Cotizacion = n.Cotizacion,
                                                CodRamo = n.CodRamo,
                                                Ramo = n.Ramo,
                                                FechaAdiciona = n.FechaAdiciona,
                                                Codigo = n.Codigo,
                                                InicioVigencia = n.InicioVigencia,
                                                FinVigencia = n.FinVigencia,
                                                TipoPlan = n.TipoPlan,
                                                Estatus = n.Estatus,
                                                Parentezco = n.Parentezco,
                                                Nombre = n.Nombre,
                                                Provincia = n.Provincia,
                                                Direccion = n.Direccion,
                                                Telefono = n.Telefono,
                                                Cedula = n.Cedula,
                                                FechaNacimiento = n.FechadeNacimiento,
                                                Edad = n.Edad,
                                                Prima = n.Prima,
                                                Cobertura = n.Cobertura
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Data Cedensa Canceladas", Exportar);
                        }
                        //EXPORTAMOS A CSV
                        if (rbExportarcsv.Checked)
                        {

                        }
                        //EXPORTAMOS A TXT
                        if (rbExportartxt.Checked)
                        {

                        }
                    }

                    //EXPORTAMOS SIN RANGO DE FECHA
                    if (rbGenerarDataCompleta.Checked)
                    {
                        //EXPORTAMOS LA DATA A EXEL
                        if (rbExportarExel.Checked)
                        {
                            string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();

                            var Exportar = (from n in Objdata.Value.GenerarDataCedensa(
                                _Poliza,
                                "CANCELADA",
                                Convert.ToDecimal(ddlSeleccionarPlanCobertura.SelectedValue))
                                            select new
                                            {
                                                Poliza = n.Poliza,
                                                Cotizacion = n.Cotizacion,
                                                CodRamo = n.CodRamo,
                                                Ramo = n.Ramo,
                                                FechaAdiciona = n.FechaAdiciona,
                                                Codigo = n.Codigo,
                                                InicioVigencia = n.InicioVigencia,
                                                FinVigencia = n.FinVigencia,
                                                TipoPlan = n.TipoPlan,
                                                Estatus = n.Estatus,
                                                Parentezco = n.Parentezco,
                                                Nombre = n.Nombre,
                                                Provincia = n.Provincia,
                                                Direccion = n.Direccion,
                                                Telefono = n.Telefono,
                                                Cedula = n.Cedula,
                                                FechaNacimiento = n.FechadeNacimiento,
                                                Edad = n.Edad,
                                                Prima = n.Prima,
                                                Cobertura = n.Cobertura
                                            }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Data Cedensa Completa", Exportar);
                        }
                        //EXPORTAMOS A CSV
                        if (rbExportarcsv.Checked)
                        {

                        }
                        //EXPORTAMOS A TXT
                        if (rbExportartxt.Checked)
                        {

                        }

                    }
                }
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
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPlanCobertura, Objdata.Value.BuscaListas("PLANCOBERTURA", ddlSeleccionarCpbertura.SelectedValue, null));
        }
    }
}