using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Data;


namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarMarbetes : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjdataProcesos = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();
        #region MOSTRAR EL LISTADO DE LOS REGISTROS
        private void MostrarListadoPolizasMarbete()
        {
            if (cbOtrosFiltros.Checked)
            {
                //BUSCAMOS POR CHASIS O POR PLACA (SI AMBOS CAMPOS ESTAN VACIOS NO BUSCA NADA)
                if (string.IsNullOrEmpty(txtChasisConsulta.Text.Trim()) && string.IsNullOrEmpty(txtPlacaConsulta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CamposChasisPlacaVacios()", "CamposChasisPlacaVacios();", true);
                }
                else
                {
                    string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
                    string _Item = string.IsNullOrEmpty(txtItemConsulta.Text.Trim()) ? null : txtItemConsulta.Text.Trim();
                    string _Chasis = string.IsNullOrEmpty(txtChasisConsulta.Text.Trim()) ? null : txtChasisConsulta.Text.Trim();
                    string _Placa = string.IsNullOrEmpty(txtPlacaConsulta.Text.Trim()) ? null : txtPlacaConsulta.Text.Trim();

                    var BuscarRegistros = ObjdataProcesos.Value.GenerarDatosParaMarbeteVehiculos(
                        _Poliza,
                        _Item,
                        _Chasis,
                        _Placa);
                    if (BuscarRegistros.Count() < 1)
                    {
                        lbCantidadRegistrosVariable.Text = "0";
                    }
                    else
                    {
                        gvListadoPoliza.DataSource = BuscarRegistros;
                        gvListadoPoliza.DataBind();

                        int CantidadRegistros = 0;
                        foreach (var n in BuscarRegistros)
                        {
                            CantidadRegistros = Convert.ToInt32(n.CantidadRegistros);
                            lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                        }
                    }
                }
            }
            else
            {
                //BUSCMAOS POR POLIZA E ITEM (CAMPO POLIZA OBLIGATORIO)
                if (string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoPolizaVacio()", "CampoPolizaVacio();", true);
                }
                else
                {
                    string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
                    string _Item = string.IsNullOrEmpty(txtItemConsulta.Text.Trim()) ? null : txtItemConsulta.Text.Trim();

                    var Buscarregistros = ObjdataProcesos.Value.GenerarDatosParaMarbeteVehiculos(
                        _Poliza,
                        _Item,
                        null,
                        null);
                    if (Buscarregistros.Count() < 1)
                    {
                        lbCantidadRegistrosVariable.Text = "0";
                    }
                    else
                    {
                        gvListadoPoliza.DataSource = Buscarregistros;
                        gvListadoPoliza.DataBind();

                        int CantidadRegistros = 0;
                        foreach (var n in Buscarregistros)
                        {
                            CantidadRegistros = Convert.ToInt32(n.CantidadRegistros);
                            lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                        }
                    }
                }

            }
        }
        #endregion
        #region MOSTRAR Y OCULTAR CONTROLES
        private void MostrarControles()
        {
            lbTituloDatosPolizas.Visible = true;
            lbPolizaMantenimiento.Visible = true;
            txtPolizaMantenimiento.Visible = true;
            lbCotizacionMantenimiento.Visible = true;
            txtCotizacionMantenimeinto.Visible = true;
            lbCodigoClienteMantenimiento.Visible = true;
            txtCodigoClienteMantenimiento.Visible = true;
            lbItemMantenimiento.Visible = true;
            txtItemMantenimiento.Visible = true;
            lbNombreClienteMantenimiento.Visible = true;
            txtNombreClienteMantenimiento.Visible = true;
            lbNombreAseguradoMantenimiento.Visible = true;
            txtNombreAseguradoMantenimiento.Visible = true;
            lbInicioVigenciaMantenimeinto.Visible = true;
            txtInicioVigenciaMantenimiento.Visible = true;
            lbFinVigenciaMantenimiento.Visible = true;
            txtFinVigenciaMantenimiento.Visible = true;
            lbTipoVehiculoMantenimiento.Visible = true;
            txtTipoVehiculoMantenimiento.Visible = true;
            lbMarcaMantenimiento.Visible = true;
            txtMarcaMantenimeinto.Visible = true;
            lbModeloMantenimiento.Visible = true;
            txtModeloMantenimeinto.Visible = true;
            lbCapacidadMantenimiento.Visible = true;
            txtCapacidadMantenimeinto.Visible = true;
            lbChasisMantenimiento.Visible = true;
            txtChasisMantenimiento.Visible = true;
            lbPlacaMantenimiento.Visible = true;
            txtPlacaMantenimiento.Visible = true;
            lbColorMantenimiento.Visible = true;
            txtColorMantenimiento.Visible = true;
            lbAnoMantenimiento.Visible = true;
            txtAnoMantenimiento.Visible = true;
            lbUsoMantenimiento.Visible = true;
            txtUsoMantenimiento.Visible = true;
            lbValorVehiculo.Visible = true;
            txtValorVehiculo.Visible = true;
            lbFianzaJudicialMantenimiento.Visible = true;
            txtFianzaJudicialMantenimiento.Visible = true;
            lbVendedorMantenimiento.Visible = true;
            txtVendedorMantenimiento.Visible = true;
            lbGruaMantenimiento.Visible = true;
            txtGruaMantenimiento.Visible = true;
            lbAeroAmbulanciaMantenimiento.Visible = true;
            txtAeroAmbulancia.Visible = true;
            lbOtrosServiciosMantenimiento.Visible = true;
            txtOtrosServiciosMantenimiento.Visible = true;
            btnImprimirMarbete.Visible = true;
            btnRestablecer.Visible = true;
        }
        private void OcultarControles()
        {
            lbTituloDatosPolizas.Visible = false;
            lbPolizaMantenimiento.Visible = false;
            txtPolizaMantenimiento.Visible = false;
            lbCotizacionMantenimiento.Visible = false;
            txtCotizacionMantenimeinto.Visible = false;
            lbCodigoClienteMantenimiento.Visible = false;
            txtCodigoClienteMantenimiento.Visible = false;
            lbItemMantenimiento.Visible = false;
            txtItemMantenimiento.Visible = false;
            lbNombreClienteMantenimiento.Visible = false;
            txtNombreClienteMantenimiento.Visible = false;
            lbNombreAseguradoMantenimiento.Visible = false;
            txtNombreAseguradoMantenimiento.Visible = false;
            lbInicioVigenciaMantenimeinto.Visible = false;
            txtInicioVigenciaMantenimiento.Visible = false;
            lbFinVigenciaMantenimiento.Visible = false;
            txtFinVigenciaMantenimiento.Visible = false;
            lbTipoVehiculoMantenimiento.Visible = false;
            txtTipoVehiculoMantenimiento.Visible = false;
            lbMarcaMantenimiento.Visible = false;
            txtMarcaMantenimeinto.Visible = false;
            lbModeloMantenimiento.Visible = false;
            txtModeloMantenimeinto.Visible = false;
            lbCapacidadMantenimiento.Visible = false;
            txtCapacidadMantenimeinto.Visible = false;
            lbChasisMantenimiento.Visible = false;
            txtChasisMantenimiento.Visible = false;
            lbPlacaMantenimiento.Visible = false;
            txtPlacaMantenimiento.Visible = false;
            lbColorMantenimiento.Visible = false;
            txtColorMantenimiento.Visible = false;
            lbAnoMantenimiento.Visible = false;
            txtAnoMantenimiento.Visible = false;
            lbUsoMantenimiento.Visible = false;
            txtUsoMantenimiento.Visible = false;
            lbValorVehiculo.Visible = false;
            txtValorVehiculo.Visible = false;
            lbFianzaJudicialMantenimiento.Visible = false;
            txtFianzaJudicialMantenimiento.Visible = false;
            lbVendedorMantenimiento.Visible = false;
            txtVendedorMantenimiento.Visible = false;
            lbGruaMantenimiento.Visible = false;
            txtGruaMantenimiento.Visible = false;
            lbAeroAmbulanciaMantenimiento.Visible = false;
            txtAeroAmbulancia.Visible = false;
            lbOtrosServiciosMantenimiento.Visible = false;
            txtOtrosServiciosMantenimiento.Visible = false;
            btnImprimirMarbete.Visible = false;
            btnRestablecer.Visible = false;
        }
        private void LimpiarControles()
        {
            txtPolizaMantenimiento.Text = string.Empty;
            txtCotizacionMantenimeinto.Text = string.Empty;
            txtCodigoClienteMantenimiento.Text = string.Empty;
            txtItemMantenimiento.Text = string.Empty;
            txtNombreClienteMantenimiento.Text = string.Empty;
            txtNombreAseguradoMantenimiento.Text = string.Empty;
            txtInicioVigenciaMantenimiento.Text = string.Empty;
            txtFinVigenciaMantenimiento.Text = string.Empty;
            txtTipoVehiculoMantenimiento.Text = string.Empty;
            txtMarcaMantenimeinto.Text = string.Empty;
            txtModeloMantenimeinto.Text = string.Empty;
            txtCapacidadMantenimeinto.Text = string.Empty;
            txtChasisMantenimiento.Text = string.Empty;
            txtPlacaMantenimiento.Text = string.Empty;
            txtColorMantenimiento.Text = string.Empty;
            txtAnoMantenimiento.Text = string.Empty;
            txtUsoMantenimiento.Text = string.Empty;
            txtValorVehiculo.Text = string.Empty;
            txtFianzaJudicialMantenimiento.Text = string.Empty;
            txtVendedorMantenimiento.Text = string.Empty;
            txtGruaMantenimiento.Text = string.Empty;
            txtAeroAmbulancia.Text = string.Empty;
            txtOtrosServiciosMantenimiento.Text = string.Empty;

        }
        #endregion
        #region IMPRIMIR REPORTE
        private void ImprimirMarbete(decimal IdUsuario, string RutaReporte, string UsuaruoBD, string ClaveBD/*, string NombreArchivo*/)
        {
            try
            {
                ReportDocument Factura = new ReportDocument();

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "EXEC [Utililades].[SP_GENERAR_REPORTE_MARBETE] @IdUsuario";
                comando.Connection = UtilidadesAmigos.Data.Conexiones.ADO.BDConexion.ObtenerConexion();

                comando.Parameters.Add("@IdUsuario", SqlDbType.Decimal);
                comando.Parameters["@IdUsuario"].Value = IdUsuario;

                Factura.Load(RutaReporte);
                Factura.Refresh();
                Factura.SetParameterValue("@IdUsuario", IdUsuario);
                Factura.SetDatabaseLogon(UsuaruoBD, ClaveBD);
                //Factura.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);

                Factura.PrintToPrinter(1, true, 0, 2);
                //  crystalReportViewer1.ReportSource = Factura;
            }
            catch (Exception) { }

        }

        private void ImprimirMarbeteHoja(decimal IdUsuario, string RutaReporte, string UsuarioBD, string ClaveBD, string Nombrearchivo) {
            try
            {
                ReportDocument Factura = new ReportDocument();

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "EXEC [Utililades].[SP_GENERAR_REPORTE_MARBETE] @IdUsuario";
                comando.Connection = UtilidadesAmigos.Data.Conexiones.ADO.BDConexion.ObtenerConexion();

                comando.Parameters.Add("@IdUsuario", SqlDbType.Decimal);
                comando.Parameters["@IdUsuario"].Value = IdUsuario;

                Factura.Load(RutaReporte);
                Factura.Refresh();
                Factura.SetParameterValue("@IdUsuario", IdUsuario);
                Factura.SetDatabaseLogon(UsuarioBD, ClaveBD);
                Factura.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, Nombrearchivo);

                //Factura.PrintToPrinter(1, true, 0, 2);
                //  crystalReportViewer1.ReportSource = Factura;
            }
            catch (Exception) { }
        }
        #endregion
        #region GUARDAR LOS DATOS DEL HISTORIAL
        private void GuardarHistorial(int TipoImpresion) {
            string NombreUsuario = "";
            string Accion = "";
            

            //SACAR EL NOMBRE DEL USUARIO
            var SacarNombreusuario = ObjDataGeneral.Value.BuscaUsuarios(Convert.ToDecimal(lbIdusuario.Text));
            foreach (var n in SacarNombreusuario) {
                NombreUsuario = n.Persona;
            }


            //VALIDAMOS SI EL REGISTRO EXISTE PARA DETERMINAR SI SE INSERTA O SE ACTUALIZA
            var Validar = ObjdataProcesos.Value.BuscaHistoricoImpresionMarbetes(
                new Nullable<decimal>(),
                txtPolizaMantenimiento.Text,
                Convert.ToInt32(txtItemMantenimiento.Text),
                txtInicioVigenciaMantenimiento.Text,
                txtFinVigenciaMantenimiento.Text,
                Convert.ToDecimal(txtCotizacionMantenimeinto.Text),null,null,null,null,null,null,null,null,null,
                TipoImpresion);
            if (Validar.Count() < 1) {
                Accion = "INSERT";
            }
            else {
                Accion = "UPDATE";
            }

            UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarHistoricoImpresionMarbetes ProcesarHistorico = new Logica.Comunes.Reportes.ProcesarHistoricoImpresionMarbetes(
                0,
                txtPolizaMantenimiento.Text,
                Convert.ToDecimal(txtCotizacionMantenimeinto.Text),
                Convert.ToDecimal(txtCodigoClienteMantenimiento.Text),
                Convert.ToInt32(txtItemMantenimiento.Text),
                txtNombreClienteMantenimiento.Text,
                txtInicioVigenciaMantenimiento.Text,
                txtFinVigenciaMantenimiento.Text,
                txtNombreAseguradoMantenimiento.Text,
                txtTipoVehiculoMantenimiento.Text,
                txtMarcaMantenimeinto.Text,
                txtModeloMantenimeinto.Text,
                txtChasisConsulta.Text,
                txtPlacaConsulta.Text,
                txtColorMantenimiento.Text,
                txtUsoMantenimiento.Text,
                txtAnoMantenimiento.Text,
                txtCapacidadMantenimeinto.Text,
                Convert.ToDecimal(txtValorVehiculo.Text),
                txtFianzaJudicialMantenimiento.Text,
                txtVendedorMantenimiento.Text,
                txtGruaMantenimiento.Text,
                txtAeroAmbulancia.Text,
                txtOtrosServiciosMantenimiento.Text,
                NombreUsuario,
                TipoImpresion,
                0,
                Accion);
            ProcesarHistorico.ProcesarInformacion();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                cbOtrosFiltros.Checked = false;
                rbMarbetePVC.Checked = true;
                lbIdusuario.Text = Session["IdUsuario"].ToString();
                rbImprimirPVC.Checked = true;
            }
        }
      

        protected void cbOtrosFiltros_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOtrosFiltros.Checked)
            {
                rbBuscarPorChasis.Visible = true;
                rbBuscarPorPlaca.Visible = true;
                rbBuscarPorChasis.Checked = true;
            }
            else {
                rbBuscarPorChasis.Visible = false;
                rbBuscarPorPlaca.Visible = false;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoPolizasMarbete();
            LimpiarControles();
            OcultarControles();
        }

        protected void gvListadoPoliza_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoPoliza.PageIndex = e.NewPageIndex;
            MostrarListadoPolizasMarbete();
        }

        protected void gvListadoPoliza_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow GV = gvListadoPoliza.SelectedRow;

            MostrarControles();
            var BuscarRegistroSeleccionado = ObjdataProcesos.Value.GenerarDatosParaMarbeteVehiculos(
                GV.Cells[0].Text,
                GV.Cells[1].Text,
                null, null);
            foreach (var n in BuscarRegistroSeleccionado) {
                txtPolizaMantenimiento.Text = n.Poliza;
                txtCotizacionMantenimeinto.Text = n.Cotizacion.ToString();
                txtCodigoClienteMantenimiento.Text = n.CodigoCliente.ToString();
                txtItemMantenimiento.Text = n.Secuencia.ToString();
                txtNombreClienteMantenimiento.Text = n.NombreCliente;
                txtNombreAseguradoMantenimiento.Text = n.Asegurado;
                txtInicioVigenciaMantenimiento.Text = n.InicioVigencia;
                txtFinVigenciaMantenimiento.Text = n.FinVigencia;
                txtTipoVehiculoMantenimiento.Text = n.TipoVehiculo;
                txtMarcaMantenimeinto.Text = n.Marca;
                txtModeloMantenimeinto.Text = n.Modelo;
                txtCapacidadMantenimeinto.Text = n.Capacidad;
                txtChasisMantenimiento.Text = n.Chasis;
                txtPlacaMantenimiento.Text = n.Placa;
                txtColorMantenimiento.Text = n.Color;
                txtAnoMantenimiento.Text = n.Ano;
                txtUsoMantenimiento.Text = n.Uso;
                decimal ValorVehiculo = Convert.ToDecimal(n.ValorVehiculo);
                txtValorVehiculo.Text = ValorVehiculo.ToString("N2");
                txtFianzaJudicialMantenimiento.Text = n.FianzaJudicial;
                txtVendedorMantenimiento.Text = n.Vendedor;
                txtGruaMantenimiento.Text = n.Grua;
                txtAeroAmbulancia.Text = n.AeroAmbulancia;
                txtOtrosServiciosMantenimiento.Text = n.OtrosServicios;
            }
            gvListadoPoliza.DataSource = BuscarRegistroSeleccionado;
            gvListadoPoliza.DataBind();
        }

        protected void btnImprimirMarbete_Click(object sender, EventArgs e)
        {
            //VERIFICAMOS SI EL USUAIRO TIENE PERMISO PARA IMPRIMI MARBETES
            bool PermisoImpresionMarbete = false;

            var Validar = ObjDataGeneral.Value.BuscaUsuarios(Convert.ToDecimal(lbIdusuario.Text), null, null, null, null, null, null, null, null);
            foreach (var n in Validar) {
                PermisoImpresionMarbete = Convert.ToBoolean(n.PermisoImpresionMarbete0);
            }
            if (PermisoImpresionMarbete == false) {
                //NO TIENE PERMISO
                ClientScript.RegisterStartupScript(GetType(), "PermisoDenegado()", "PermisoDenegado();", true);
            }
            else {
                //TIENE PERMISO
                //ELIMINAMOS LOS DATOS DEL USUARIO
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionImpresionMarbetes Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionImpresionMarbetes(
                    Convert.ToDecimal(lbIdusuario.Text), "", 0, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "", "", 0, "DELETE");
                Procesar.ProcesarInformacion();

                //GUARDAR LOS DATOS ITERANDO LOS DATOS DEL MARBETE
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionImpresionMarbetes Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionImpresionMarbetes(
                        Convert.ToDecimal(lbIdusuario.Text),
                        txtPolizaMantenimiento.Text,
                        Convert.ToDecimal(txtCotizacionMantenimeinto.Text),
                        Convert.ToDecimal(txtCodigoClienteMantenimiento.Text),
                        Convert.ToInt32(txtItemMantenimiento.Text),
                        txtNombreClienteMantenimiento.Text,
                        txtInicioVigenciaMantenimiento.Text,
                        txtFinVigenciaMantenimiento.Text,
                        txtNombreAseguradoMantenimiento.Text,
                        txtTipoVehiculoMantenimiento.Text,
                        txtMarcaMantenimeinto.Text,
                        txtModeloMantenimeinto.Text,
                       txtChasisMantenimiento.Text,
                       txtPlacaMantenimiento.Text,
                       txtColorMantenimiento.Text,
                       txtUsoMantenimiento.Text,
                       txtAnoMantenimiento.Text,
                       txtCapacidadMantenimeinto.Text,
                       Convert.ToDecimal(txtValorVehiculo.Text),
                       txtFianzaJudicialMantenimiento.Text,
                       txtVendedorMantenimiento.Text,
                       txtGruaMantenimiento.Text,
                       txtAeroAmbulancia.Text,
                       txtOtrosServiciosMantenimiento.Text,
                       1, "INSERT");
                Guardar.ProcesarInformacion();

                // 

              

                if (rbImprimirPVC.Checked == true && rbImprimirHoja.Checked==false) {
                    //GUARDMOS LOS DATOS DEL HISTORIAL
                    GuardarHistorial(1);
                   ImprimirMarbete(Convert.ToDecimal(lbIdusuario.Text), Server.MapPath("Marbete.rpt"), "sa", "Pa$$W0rd");
                }
                else if (rbImprimirHoja.Checked == true && rbImprimirPVC.Checked==false) {
                    GuardarHistorial(2);
                    string NombreArchivo = "";
                    NombreArchivo = "Marbete " + txtPolizaMantenimiento.Text + " Item " + txtItemMantenimiento.Text;
                    ImprimirMarbeteHoja(Convert.ToDecimal(lbIdusuario.Text), Server.MapPath("Marbete.rpt"), "sa", "Pa$$W0rd", NombreArchivo);
                   // ImprimirMarbete(Convert.ToDecimal(lbIdusuario.Text), Server.MapPath("Marbete.rpt"), "sa", "Pa$$W0rd");
                }
            }
        }

        protected void btnRestablecer_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OcultarControles();
        }

        protected void rbImprimirPVC_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}