using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Reportes
{
    public partial class AntiguedadSaldo : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataComun = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDataReporte = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();

        #region CARGAR LOS RAMOS
        private void CargarRamos() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlRamo, ObjDataComun.Value.BuscaListas("RAMO", null, null), true);
        }
        #endregion


        #region PROCESO DE ANTIGEUDAD DE SALDO CRUZADO
        private void GenerarSaldoAntigeudadCruzado() {

            //VALIDAMSO TODOS LOS FILTROS
            if (string.IsNullOrEmpty(txtPoliza.Text.Trim()) && string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) && string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposVacios()", "CamposVacios();", true);
            }
            else {
                decimal UsuarioConectado = (decimal)Session["IdUsuario"];
                string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
                int? _Ramo = ddlRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlRamo.SelectedValue) : new Nullable<int>();
                int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
                int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);
                string EstatusPolizaTransito = "";

                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionAntiguedadSaldoCruzado Eliminar = new Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionAntiguedadSaldoCruzado(
                    UsuarioConectado,
                    "", "", "", 0, "", 0, "", 0, "", "", 0, 0, "", 0, "", 0, "", "", "", "", "", "", 0, 0, 0, 0, "", 0, "", 0, 0, 0, 0, 0, 0, "DELETE");
                Eliminar.ProcesarInformacion();

                //CARGAMOS LOS DATOS DE LAS POLIZAS EMITIDAS
                var PolizasEmitidas = ObjDataReporte.Value.BuscaAntiguedadSaldoPolizasEmitidas(
                    _Poliza,
                    _Ramo,
                    _Supervisor,
                    _Intermediario);
                foreach (var Emitidas in PolizasEmitidas) {
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionAntiguedadSaldoCruzado Proceso1 = new Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionAntiguedadSaldoCruzado(
                        UsuarioConectado,
                        Emitidas.Poliza,
                        Emitidas.Origen,
                        Emitidas.EstatusSistema,
                        (int)Emitidas.CodigoRamo,
                        Emitidas.Ramo,
                        (int)Emitidas.CodigoSubRamo,
                        Emitidas.Subramo,
                        (int)Emitidas.Item,
                        Emitidas.InicioVigencia,
                        Emitidas.FinVigencia,
                        (decimal)Emitidas.MontoNeto,
                        (int)Emitidas.CodigoSupervisor,
                        Emitidas.Supervisor,
                        (int)Emitidas.CodigoIntermediario,
                        Emitidas.Intermediario,
                        (decimal)Emitidas.CodigoCliente,
                        Emitidas.Cliente,
                        Emitidas.NumeroIdentificacionCliente,
                        Emitidas.TelefonoOficinaCliente,
                        Emitidas.TelefonoResidenciaCliente,
                        Emitidas.CelularCliente,
                        Emitidas.FaxCliente,
                        (decimal)Emitidas.Facturado,
                        (decimal)Emitidas.Balance,
                        (int)Emitidas.CantidadDias,
                        (decimal)Emitidas.ValorPorDia,
                        Emitidas.UltimaFechaPago,
                        (decimal)Emitidas.MontoUltimoPago,
                        Emitidas.FinVigencia,
                        (decimal)Emitidas.A_0_30,
                        (decimal)Emitidas.A_31_60,
                        (decimal)Emitidas.A_61_90,
                        (decimal)Emitidas.A_91_120,
                        (decimal)Emitidas.A_121_150,
                        (decimal)Emitidas.A_151_MAS,
                        "INSERT");
                    Proceso1.ProcesarInformacion();

                }
                //CARGAMOS LOS DATOS DE LAS POLIZAS EMITIDAS
                var PolizasEmitidasProcesoAntetrior = ObjDataReporte.Value.BuscaAntiguedadSaldoPolizasProcesoAnterior(
                    _Poliza,
                    _Ramo,
                    _Supervisor,
                    _Intermediario);
                foreach (var Emitidas in PolizasEmitidasProcesoAntetrior)
                {
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionAntiguedadSaldoCruzado Proceso_Anterior = new Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionAntiguedadSaldoCruzado(
                        UsuarioConectado,
                        Emitidas.Poliza,
                        Emitidas.Origen,
                        Emitidas.EstatusSistema,
                        (int)Emitidas.CodigoRamo,
                        Emitidas.Ramo,
                        (int)Emitidas.CodigoSubRamo,
                        Emitidas.Subramo,
                        (int)Emitidas.Item,
                        Emitidas.InicioVigencia,
                        Emitidas.FinVigencia,
                        (decimal)Emitidas.MontoNeto,
                        (int)Emitidas.CodigoSupervisor,
                        Emitidas.Supervisor,
                        (int)Emitidas.CodigoIntermediario,
                        Emitidas.Intermediario,
                        (decimal)Emitidas.CodigoCliente,
                        Emitidas.Cliente,
                        Emitidas.NumeroIdentificacionCliente,
                        Emitidas.TelefonoOficinaCliente,
                        Emitidas.TelefonoResidenciaCliente,
                        Emitidas.CelularCliente,
                        Emitidas.FaxCliente,
                        (decimal)Emitidas.Facturado,
                        (decimal)Emitidas.Balance,
                        (int)Emitidas.CantidadDias,
                        (decimal)Emitidas.ValorPorDia,
                        Emitidas.UltimaFechaPago,
                        (decimal)Emitidas.MontoUltimoPago,
                        Emitidas.FinVigencia,
                        (decimal)Emitidas.A_0_30,
                        (decimal)Emitidas.A_31_60,
                        (decimal)Emitidas.A_61_90,
                        (decimal)Emitidas.A_91_120,
                        (decimal)Emitidas.A_121_150,
                        (decimal)Emitidas.A_151_MAS,
                        "INSERT");
                    Proceso_Anterior.ProcesarInformacion();

                }
                //-----------------

                //CARGAMOS LOS DATOS DE LAS POLIZAS EMITIDAS EN TRANSITO
                var PolizasEmitidas_Transito = ObjDataReporte.Value.BuscaAntiguedadSaldoPolizasEmitidasTransito(
                    _Poliza,
                    _Ramo,
                    _Supervisor,
                    _Intermediario);
                foreach (var Transito in PolizasEmitidas_Transito) {

                    EstatusPolizaTransito = Transito.Estatus;

                    if (EstatusPolizaTransito == "ACTIVO") {
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionAntiguedadSaldoCruzado Proceso2 = new Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionAntiguedadSaldoCruzado(
                               UsuarioConectado,
                               Transito.Poliza,
                               Transito.Origen,
                               Transito.Estatus,
                               (int)Transito.CodigoRamo,
                               Transito.Ramo,
                               (int)Transito.CodigoSubramo,
                               Transito.SubRamo,
                               (int)Transito.Item,
                               Transito.InicioVigencia,
                               Transito.FinVigencia,
                               (decimal)Transito.MontoNeto,
                               (int)Transito.CodigoSupervisor,
                               Transito.Supervisor,
                               (int)Transito.CodigoIntermediario,
                               Transito.Intermediario,
                               (decimal)Transito.CodigoCliente,
                               Transito.Cliente,
                               Transito.NumeroIdentificacionCliente,
                               Transito.TelefonoOficinaCliente,
                               Transito.TelefonoResidenciaCliente,
                               Transito.CelularCliente,
                               Transito.FaxCliente,
                               (decimal)Transito.MontoNeto,
                               (decimal)Transito.MontoMov,
                               (int)Transito.CantidadDias,
                               0,
                               "",
                               0,
                               "",
                               (decimal)Transito.A_0_30,
                               (decimal)Transito.A_31_60,
                               (decimal)Transito.A_61_90,
                               (decimal)Transito.A_91_120,
                               (decimal)Transito.A_121_150,
                               (decimal)Transito.A_151_MAS,
                               "INSERT");
                        Proceso2.ProcesarInformacion();
                    }
                }

                //EXPORTAR INFORMACION A EXCEL
                var Exportar = (from n in ObjDataReporte.Value.ExportarAntiguedadCruzadoExcel(UsuarioConectado)
                                select new
                                {
                                    Poliza = n.Poliza,
                                    Origen = n.Origen,
                                    EstatusSistema = n.EstatusSistema,
                                    CodigoRamo = n.CodigoRamo,
                                    Ramo = n.Ramo,
                                    CodigoSubRamo = n.CodigoSubRamo,
                                    SubRamo = n.SubRamo,
                                    Item = n.Item,
                                    InicioVigencia = n.InicioVigencia,
                                    FInVigencia = n.FInVigencia,
                                    MontoNeto = n.MontoNeto,
                                    CodigoSupervisor = n.CodigoSupervisor,
                                    NombreSupervisor = n.NombreSupervisor,
                                    CodigoIntermediario = n.CodigoIntermediario,
                                    NombreIntermediario = n.NombreIntermediario,
                                    Codigocliente = n.Codigocliente,
                                    NombreCliente = n.NombreCliente,
                                    NumeroIdentificacionCliente = n.NumeroIdentificacionCliente,
                                    TelefonoOficinaCliente = n.TelefonoOficinaCliente,
                                    TelefonoResidenciaCliente = n.TelefonoResidenciaCliente,
                                    CelularCliente = n.CelularCliente,
                                    FaxCliente = n.FaxCliente,
                                    Facturado = n.Facturado,
                                    Balance = n.Balance,
                                    CantidadDias = n.CantidadDias,
                                    ValorPorDia = n.ValorPorDia,
                                    UltimaFechaPago = n.UltimaFechaPago,
                                    MontoUltimoPago = n.MontoUltimoPago,
                                    _0_30 = n.__0_30,
                                    _31_60 = n.__31_60,
                                    _61_90 = n.__61_90,
                                    _91_120 = n.__91_120,
                                    _121_150 = n.__121_150,
                                    _151_MAS = n.__151_MAS
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Antiguedad de Saldo Cruzado", Exportar);
            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {


                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Informacion = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbusuarioConectado = (Label)Master.FindControl("lbUsuarioConectado");
                lbusuarioConectado.Text = Informacion.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "ANTIGUEDAD DE SALDO CRUZADO";

                CargarRamos();
            }
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Informacion = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisor.Text);
            txtNombreSupervisor.Text = Informacion.SacarNombreSupervisor();
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Informacion = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediario.Text);
            txtNombreIntermediario.Text = Informacion.SacarNombreIntermediario();
        }

        protected void btnExportar_Click(object sender, ImageClickEventArgs e)
        {
            GenerarSaldoAntigeudadCruzado();
        }
    }
}