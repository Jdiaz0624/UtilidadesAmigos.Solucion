using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ProcesarDataPowerBi : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        UtilidadesAmigos.Logica.Comunes.VariablesPowerBi VariablespowerBi = new Logica.Comunes.VariablesPowerBi();
        #region MANTENIMIENTO DE PRODUCCION 
        private void MAMProduccion(string Accion)
        {
            UtilidadesAmigos.Logica.Entidades.ECargarDatosTablaProduccionPowerBi Produccion = new Logica.Entidades.ECargarDatosTablaProduccionPowerBi();

            Produccion.Supervisor = VariablespowerBi.Supervisor;
            Produccion.Intermediario = VariablespowerBi.Intermediario;
            Produccion.Mes = VariablespowerBi.Mes;
            Produccion.Año = VariablespowerBi.Año;
            Produccion.Facturado = VariablespowerBi.Facturado;
            Produccion.FacturadoNeto = VariablespowerBi.FacturadoNeto;
            Produccion.Cobrado = VariablespowerBi.Cobrado;
            Produccion.CobradoNeto = VariablespowerBi.CobradoNeto;
            Produccion.Poliza = VariablespowerBi.Poliza;
            Produccion.Ramo = VariablespowerBi.Ramo;
            Produccion.Prima = VariablespowerBi.Prima;
            Produccion.ValorAsegurado = VariablespowerBi.ValorAsegurado;
            Produccion.ValorFianza = VariablespowerBi.ValorFianza;
            Produccion.ValorVehiculo = VariablespowerBi.ValorVehiculo;
            Produccion.Marca = VariablespowerBi.Marca;
            Produccion.Modelo = VariablespowerBi.Modelo;
            Produccion.AñoVehiculo = VariablespowerBi.AñoVehiculo;

            var MAn = ObjData.Value.CargarDatosTablaProduccionPowerBi(Produccion, Accion);

            
        }
        #endregion
        #region MANTENIMIENTO DE PRODUCCION
        private void MANReclamacion(string Accion)
        {
            UtilidadesAmigos.Logica.Entidades.ECargarDatosTablaReclamacionpowerBi Reclamacion = new Logica.Entidades.ECargarDatosTablaReclamacionpowerBi();

            Reclamacion.Supervisor = VariablespowerBi.SupervisorReclamacion;
            Reclamacion.Intermediario = VariablespowerBi.intermediarioReclamacion;
            Reclamacion.Mes = VariablespowerBi.MesReclamacion;
            Reclamacion.ano = VariablespowerBi.AnoReclamacion;
            Reclamacion.Reclamacion = VariablespowerBi.ReclamacionReclamacion;
            Reclamacion.MontoReclamado = VariablespowerBi.MontoReclamadoReclamacion;
            Reclamacion.MontoAjustado = VariablespowerBi.MontoAjustadoReclamacion;
            Reclamacion.Estatus = VariablespowerBi.EstatusReclamacion;
            Reclamacion.Marca = VariablespowerBi.MarcaReclamacion;
            Reclamacion.Modelo = VariablespowerBi.ModeloReclamacion;
            Reclamacion.Anovehiculo = VariablespowerBi.AnovehiculoReclamacion;

            var MAn = ObjData.Value.CargarDatosTablaReclamacionPowerBi(Reclamacion, Accion);
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                lbListo.Text = "LISTO";
                lbListo.ForeColor = System.Drawing.Color.ForestGreen;
                rbSinCargarTabla.Checked = true;
            }
        }

        protected void ddlSeleccionarData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            try {
                //declaramos una variable y le pasamos el valor del drop
                int TipoProceso = 0;
                TipoProceso = Convert.ToInt32(ddlSeleccionarData.SelectedValue);

                //SI EL VALOR PASADO ES UN 1 ENTONCES SE VA A EJECUTAR LA PRODUCCION
                if (TipoProceso == 1)
                {
                    if (rbSinCargarTabla.Checked == true)
                    {
                        var ExportarSincargar = (from n in ObjData.Value.CargarTablaProduccionPowerBi(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text))
                                                 select new
                                                 {
                                                     Supervisor = n.Supervisor,
                                                     Intermediario = n.Intermediario,
                                                     Mes = n.Mes.ToString(),
                                                     Año = n.Ano,
                                                     Facturado = n.Facturado,
                                                     FacturadoNeto = n.FacturadoNeto,
                                                     Cobrado = n.Cobrado,
                                                     CobradoNeto = n.CobradoNeto,
                                                     Poliza = n.Poliza,
                                                     Ramo = n.Ramo,
                                                     Prima = n.Prima,
                                                     ValorAsegurado = n.ValorAsegurado,
                                                     FianzaJudicial = n.Fianza,
                                                     ValorVehiculo = n.ValorVehiculo,
                                                     MarcaVehiculo = n.Marca,
                                                     ModeloVehiculo = n.Modelo,
                                                     AñoVehiculo = n.Año
                                                 }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("PRODUCCION", ExportarSincargar);
                    }
                    else if (rbCargarTabla.Checked == true)
                    {
                        lbListo.Text = "PROCESANDO";
                        lbListo.ForeColor = System.Drawing.Color.Red;
                        MAMProduccion("DELETE");
                        //CARGAMOS LA DATA
                        var CargarDatos = ObjData.Value.CargarTablaProduccionPowerBi(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text));
                        foreach (var n in CargarDatos)
                        {
                            VariablespowerBi.Supervisor = n.Supervisor;
                            VariablespowerBi.Intermediario = n.Intermediario;
                            VariablespowerBi.Mes = n.Mes;
                            VariablespowerBi.Año = n.Ano;
                            VariablespowerBi.Facturado = Convert.ToDecimal(n.Facturado);
                            VariablespowerBi.FacturadoNeto = Convert.ToDecimal(n.FacturadoNeto);
                            VariablespowerBi.Cobrado = Convert.ToDecimal(n.Cobrado);
                            VariablespowerBi.CobradoNeto = Convert.ToDecimal(n.CobradoNeto);
                            VariablespowerBi.Poliza = n.Poliza;
                            VariablespowerBi.Ramo = n.Ramo;
                            VariablespowerBi.Prima = Convert.ToDecimal(n.Prima);
                            VariablespowerBi.ValorAsegurado = Convert.ToDecimal(n.ValorAsegurado);
                            VariablespowerBi.ValorFianza = n.Fianza;
                            VariablespowerBi.ValorVehiculo = Convert.ToDecimal(n.ValorVehiculo);
                            VariablespowerBi.Marca = n.Marca;
                            VariablespowerBi.Modelo = n.Modelo;
                            VariablespowerBi.AñoVehiculo = n.Año;
                            MAMProduccion("INSERT");
                        }
                        var ExportarExel = (from n in ObjData.Value.CargarDataProduccionpowerBi()
                                            select new
                                            {
                                                Supervisor = n.Supervisor,
                                                Intermediario = n.Intermediario,
                                                Mes = n.Mes.ToString(),
                                                Facturado = n.Facturado,
                                                FacturadoNeto = n.FacturadoNeto,
                                                Cobrado = n.Cobrado,
                                                CobradoNeto = n.CobradoNeto,
                                                Poliza = n.Poliza,
                                                Ramo = n.Ramo,
                                                Prima = n.Prima,
                                                ValorAsegurado = n.ValorAsegurado,
                                                FianzaJudicial = n.ValorFianza,
                                                ValorVehiculo = n.ValorVehiculo,
                                                MarcaVehiculo = n.Marca,
                                                ModeloVehiculo = n.Modelo,
                                                AñoVehiculo = n.AñoVehiculo
                                            }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("PRODUCCION", ExportarExel);
                        lbListo.Text = "LISTO";
                        lbListo.ForeColor = System.Drawing.Color.ForestGreen;
                    }
                }
                else if (TipoProceso == 2)
                {
                    //VERIFICAMOS SI EL PROCESO QUE SE VA A REALIZAR ES CARGANDO LA TABLA O NO
                    if (rbSinCargarTabla.Checked == true)
                    {
                        //EXECUTAMOS LA CONSULTA PASANDOLE EL RANGO DE FECHA Y LO MANDAMOS A EXEL
                        var ExportarSinCargartabla = (from n in ObjData.Value.CargarTablaReclamacionpowerBi(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text))
                                                      select new
                                                      {
                                                          Supervisor = n.Supervisor,
                                                          Intermediario = n.intermediario,
                                                          Mes = n.Mes,
                                                          Año = n.Ano,
                                                          Poliza =n.Poliza,
                                                          Reclamacion =n.Reclamacion,
                                                          MontoReclamado =n.MontoReclamado,
                                                          Montoajustado =n.MontoAjustado,
                                                          Estatus =n.Estatus,
                                                          MarcaVehiculo =n.Marca,
                                                          ModeloVehiculo =n.Modelo,
                                                          AñoVehiculo =n.Año
                                                      }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("RECLAMACION", ExportarSinCargartabla);
                    }
                    else if (rbCargarTabla.Checked == true)
                    {
                        //ELIMINAMOS TODOS LOS DATOS DE LA TABLA
                        MANReclamacion("DELETE");
                        //EJECUTAMOS EL PROCEDURE PASANDOLE EL RANGO FECHA CORRESPONDIENTE
                        var CargarData = ObjData.Value.CargarTablaReclamacionpowerBi(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text));
                        //RECORREMOS LA DATA 
                        foreach (var n in CargarData)
                        {
                            //MANDAMOS LOS DATOS A LAS VARIABLES DE LA CLASE PARA PROCEDER A INSERTAR
                            VariablespowerBi.SupervisorReclamacion = n.Supervisor;
                            VariablespowerBi.intermediarioReclamacion = n.intermediario;
                            VariablespowerBi.MesReclamacion = n.Mes;
                            VariablespowerBi.AnoReclamacion = n.Ano;
                            VariablespowerBi.PolizaReclamacion = n.Poliza;
                            VariablespowerBi.ReclamacionReclamacion = Convert.ToDecimal(n.Reclamacion);
                            VariablespowerBi.MontoReclamadoReclamacion = Convert.ToDecimal(n.MontoReclamado);
                            VariablespowerBi.MontoAjustadoReclamacion = Convert.ToDecimal(n.MontoAjustado);
                            VariablespowerBi.EstatusReclamacion = n.Estatus;
                            VariablespowerBi.MarcaReclamacion = n.Marca;
                            VariablespowerBi.ModeloReclamacion = n.Modelo;
                            VariablespowerBi.AnovehiculoReclamacion = n.Año;

                            //PROCEDEMOS A INSERTAR LOS REGISTROS
                            MANReclamacion("INSERT");
                        }
                        //PARA TERMINAR, PROCEDEMOS A ESCRIBIR EL ARCHIVO DE EXEL CON LOS REGISTROS INGRESADOS EN LA TABLA
                        var CargarExelGuardandoEnTabla = (from n in ObjData.Value.CargarDataReclamacionPowerBi()
                                                          select new
                                                          {
                                                              Supervisor =n.Supervisor,
                                                              Intermediario = n.Intermediario,
                                                              Mes =n.Mes,
                                                              Poliza = n.Poliza,
                                                              Reclamacion = n.Reclamacion,
                                                              MontoReclamado =n.MontoReclamado,
                                                              MontoAjustado =n.MontoAjustado,
                                                              Estatus =n.Estatus,
                                                              Marca =n.Marca,
                                                              Modelo =n.Modelo,
                                                              AñoVehiculo =n.Anovehiculo
                                                          }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("RECLAMACION", CargarExelGuardandoEnTabla);
                    }
                }

                
            }
            catch (Exception) { }
        }
    }
}