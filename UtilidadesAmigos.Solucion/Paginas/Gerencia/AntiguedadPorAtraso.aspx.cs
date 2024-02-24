﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Gerencia
{
    public partial class AntiguedadPorAtraso : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaGerencia.LogicaGerencia> ObjData = new Lazy<Logica.Logica.LogicaGerencia.LogicaGerencia>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataComun = new Lazy<Logica.Logica.LogicaSistema>();

        private void CargarRamos() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlRamo, ObjDataComun.Value.BuscaListas("RAMO", null, null), true);
        }
        private void CargarSubRamo() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSubRamo, ObjDataComun.Value.BuscaListas("SUBRAMO", ddlRamo.SelectedValue.ToString(), null), true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Informacion = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                System.Web.UI.WebControls.Label lbusuarioConectado = (System.Web.UI.WebControls.Label)Master.FindControl("lbUsuarioConectado");
                lbusuarioConectado.Text = Informacion.SacarNombreUsuarioConectado();

                System.Web.UI.WebControls.Label lbPantalla = (System.Web.UI.WebControls.Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "REPORTE DE ANTIGUEDAD POR ATRASO";

                CargarRamos();
                CargarSubRamo();

                UtilidadesAmigos.Logica.Comunes.Rangofecha Rango = new Logica.Comunes.Rangofecha();
                Rango.FechaMes(ref txtFechaDesde, ref txtFechaHasta);
            }
        }

        protected void txtSupervisor_Codigo_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Supervisor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtSupervisor_Codigo.Text);
            txtNombre_Supervisor.Text = Supervisor.SacarNombreSupervisor();
        }

        protected void txtIntermediario_Codigo_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Intermediario = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtIntermediario_Codigo.Text);
            txtNombre_Intermediario.Text = Intermediario.SacarNombreIntermediario();
        }

        protected void btnGenerarReporte_Click(object sender, ImageClickEventArgs e)
        {
            decimal IdUsuario = (decimal)Session["IdUsuario"];
            string Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _Ramo = ddlRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlRamo.SelectedValue) : new Nullable<int>();
            int? _SubRamoo = ddlSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSubRamo.SelectedValue) : new Nullable<int>();
            int? _Supervisor = string.IsNullOrEmpty(txtSupervisor_Codigo.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtSupervisor_Codigo.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtIntermediario_Codigo.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtIntermediario_Codigo.Text);
            DateTime? _FechaDesde = cbNoAgregarRangoFecha.Checked == true ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesde.Text);
            DateTime? _FechaHasta = cbNoAgregarRangoFecha.Checked == true ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHasta.Text);

            //BORRAMOS LOS DATOS DE LA TABLA MEDIANTE EL USUARIO CONECTADO
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Gerencia.ProcesarInformacionPolizasConAtraso Eliminar = new Logica.Comunes.ProcesarMantenimientos.Gerencia.ProcesarInformacionPolizasConAtraso(
                IdUsuario,
                "", 0, "", 0, "", 0, "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, "", "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, 0, "DELETE");
            Eliminar.ProcesarInformacion();

            var Data = ObjData.Value.ReporteAntiguedadPorAtraso(
                Poliza,
                _FechaDesde,
                _FechaHasta,
                _Ramo,
                _SubRamoo);
            foreach (var n in Data) {

                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Gerencia.ProcesarInformacionPolizasConAtraso Procesar = new Logica.Comunes.ProcesarMantenimientos.Gerencia.ProcesarInformacionPolizasConAtraso(
                    IdUsuario,
                    n.Poliza,
                    (int)n.Codigo_Intermediario,
                    n.Intermediario,
                    (int)n.Codigo_Supervisor,
                    n.Supervisor,
                    (decimal)n.Codigo,
                    n.Cliente,
                    n.Direccion,
                    n.Telefonos,
                    n.Concepto,
                    n.Fecha_Facturacion,
                    n.Inicio_Vigencia,
                    n.Fin_Vigencia,
                    n.Fecha_Ultimo_Pago,
                    (int)n.DiasTranscurridos,
                    (int)n.Dias_Transcurridos_Pago,
                    (decimal)n.Valor_Poliza,
                    (decimal)n.Total_Pagado,
                    (decimal)n.Balance_Pendiente,
                    (int)n.Ramo,
                    (int)n.SubRamo,
                    n.NombreRamo,
                    n.NombreSubRamo,
                    (decimal)n.Inicial,
                    n.Inicial_Pagado,
                    (decimal)n.Cuota,
                    n.C1_Pagada,
                    (decimal)n.C1,
                    n.C2_Pagada,
                    (decimal)n.C2,
                    n.C3_Pagada,
                    (decimal)n.C3,
                    n.C4_Pagada,
                    (decimal)n.C4,
                    n.C5_Pagada,
                    (decimal)n.C5,
                    (decimal)n.TotalDescuento,
                    "INSERT");
                Procesar.ProcesarInformacion();
            }


            //EXPORTAMOS EL RESULTADO A EXCEL
            var Exportar = (from n in ObjData.Value.ReporteAntiguedadPorAtrasoResultado(
                _Supervisor,
                _Intermediario,
                IdUsuario)
                            select new
                            {
                                Poliza = n.Poliza,
                                Fecha_Facturacion = n.Fecha_Facturacion,
                                Inicio_Vigencia = n.Inicio_Vigencia,
                                Fin_Vigencia = n.Fin_Vigencia,
                                Fecha_Ultimo_Pago = n.Fecha_Ultimo_Pago,
                                Supervisor = n.Supervisor,
                                Intermediario = n.Intermediario,
                                Cliente = n.Cliente,
                                Concepto = n.Concepto,
                                Valor_Poliza = n.Valor_Poliza,
                                Total_Pagado = n.Total_Pagado,
                                Balance_Pendiente = n.Balance_Pendiente,
                                Ramo = n.NombreRamo,
                                SubRamo = n.NombreSubRamo,
                                Estatus = n.Estatus,
                                Balance_En_Atraso = n.Balance_En_Atraso,
                                Inicial = n.Inicial,
                                Cuota_Estimada = n.Cuota,
                                Pago_0_10 = n.Pago_0_10,
                                Pago_0_30 = n.Pago_0_30,
                                Pago_31_60 = n.Pago_31_60,
                                Pago_61_90 = n.Pago_61_90,
                                Pago_91_120 = n.Pago_91_120,
                                Pago_121_Mas = n.Pago_121_Mas,
                                DiasTranscurridos = n.DiasTranscurridos,
                                Atraso_0_30 = n.Atraso_0_30,
                                Atraso_31_60 = n.Atraso_31_60,
                                Atraso_61_90 = n.Atraso_61_90,
                                Atraso_91_120 = n.Atraso_91_120,
                                Atraso_Mas_120_Dias = n.Atraso_Mas_120_Dias
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Reporte de Polizas en Atraso", Exportar);
        }

        protected void ddlRamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSubRamo();
        }
    }
}