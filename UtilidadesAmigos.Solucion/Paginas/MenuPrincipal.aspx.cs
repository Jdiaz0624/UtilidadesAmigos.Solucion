using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Speech.Synthesis;
using System.Threading;
using System.Web.Security;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas

{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objtata = new Lazy<Logica.Logica.LogicaSistema>();
        public UtilidadesAmigos.Logica.Comunes.VariablesGlobales VariablesGlobales = new Logica.Comunes.VariablesGlobales();

        enum OpcionesEstadisticaPolizasSinPagos
        {
            PolizasSinPagoInicialPrimero=1, 
            PolizasSinPagoInicialSegundo=2, 
            PolizasSinPagoInicialTercero=3, 
            PolizasConUnPrimerPagoAplicado=4,
            PolizasConUnSegundoPagoAplicado=5,
            PolizasConUnTercerPagoAplicado=6, 
            PolizasConUnCuartoPagoAplicado=7, 
            PolizasConUnQuintoPagoAplicado=8, 
            PolizasConMasDeCintoPagosAplicados=9
        }
        private int MostrarEstadisticaPolizasSinPolizaCantidad(int Codigoproceso, int Ramo) {

            int Cantidad = 0;
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);

            var SacarInformacion = Objtata.Value.BuscaEstadisticaPolizasSinPagosCantidad(Codigoproceso, Ramo, _Supervisor, _Intermediario);
            if (SacarInformacion.Count() < 1) {

                Cantidad = 0;
            }
            else {
                foreach (var n in SacarInformacion) {

                    Cantidad = (int)n.Cantidad;
                }
            }
            return Cantidad;

        }

        private void ExportarInformacionEstadisticaPolizasSinPagosRegistros(int CodigoProceso, int Ramo, string Nombre) {

            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);

            var Exportar = (from n in Objtata.Value.BuscaEstadisticaPolizaSinPagosRegistros(CodigoProceso, Ramo,_Supervisor,_Intermediario)
                            select new
                            {
                                Poliza = n.Poliza,
                                InicioVigencia=n.InicioVigencia,
                                FinVigencia=n.FinVigencia,
                                No_Factura = n.Numero,
                                Codigo_Ramo = n.CodigoRamo,
                                Ramo = n.Ramo,
                                Codigo_SubRamo = n.CodigoSubRamo,
                                SubRamo = n.SubRamo,
                                Codigo_Asegurado = n.CodigoAsegurado,
                                Asegurado = n.Asegurado,
                                Codigo_Vendedor = n.CodigoVendedor,
                                Vendedor = n.Vendedor,
                                Codigo_Supervisor = n.CodigoSupervisor,
                                Supervisor = n.Supervisor,
                                Oficina = n.Oficina,
                                Fecha = n.Fecha,
                                Hora = n.Hora,
                                Dias_Transcurridos = n.DiasTranscurridos,
                                Ncf = n.Ncf,
                                Monto_Bruto = n.MontoBruto,
                                ISC = n.ISC,
                                Monto_Neto = n.MontoNeto,
                                Cobrado = n.Cobrado,
                                Moneda = n.Moneda,
                                Siglas = n.Siglas,
                                Factura=n.Numero,
                                BalancePendiente=n.Balance,
                                Concepto = n.Concepto
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(Nombre, Exportar);

        }

        private void ProcesarInformacionEstadisticaPolizasSinPagos(int Codigoproceso, int Ramo, decimal IdUsuario, int CodigoEstatus, string Accion) {

            
            //BUSCAMOS LA INFORMACION A PROCESAR

            var Informacion = Objtata.Value.BuscaEstadisticaPolizaSinPagosRegistros(Codigoproceso, Ramo);
            foreach (var n in Informacion) {

                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteEstadisticaPolizasSinPagos Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteEstadisticaPolizasSinPagos(
                    IdUsuario,
                    n.Poliza,
                    (decimal)n.Numero,
                    (int)n.Tipo,
                    (int)n.CodigoRamo,
                    n.Ramo,
                    (int)n.CodigoSubRamo,
                    n.SubRamo,
                    (decimal)n.CodigoAsegurado,
                    n.Asegurado,
                    (int)n.CodigoVendedor,
                    n.Vendedor,
                    (int)n.CodigoSupervisor,
                    n.Supervisor,
                    (int)n.Codigooficina,
                    n.Oficina,
                    (DateTime)n.Fecha0,
                    n.Fecha,
                    n.Hora,
                    (int)n.DiasTranscurridos,
                    n.Ncf,
                    (decimal)n.MontoBruto,
                    (decimal)n.ISC,
                    (decimal)n.MontoNeto,
                    (decimal)n.Cobrado,
                    (int)n.CodMoneda,
                    n.Moneda,
                    n.Siglas,
                    n.Concepto,
                    CodigoEstatus,
                    Accion);
                Guardar.ProcesarInformacion();
            }
        }

        private void EliminarInformacion(decimal IdUsuario, string Accion) {
            //ELIMIMSMOS LOS REGISTROS
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteEstadisticaPolizasSinPagos Eliminar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteEstadisticaPolizasSinPagos(
                IdUsuario,
                "", 0, 0, 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", DateTime.Now, "", "", 0, "", 0, 0, 0, 0, 0, "", "", "",0, Accion);
            Eliminar.ProcesarInformacion();
        }

        private void GenerarReporteEstadisticaPolizasSinPagos() {

            decimal IdUsuario = (decimal)Session["IdUsuario"];
            string RutaReporte = Server.MapPath("ReporteEstadisticaPolizaSinPago.rpt");

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@IdUsuario", IdUsuario);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");
            Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Reporte Polizas Sin Pagos");

            Reporte.Clone();
            Reporte.Dispose();
        }

        private void ActualizarInformacionEstadistica() {

            int PolizasSinInicialPrimero = 0, PolizasSinInicialSegundo = 0, PolizasSinInicialTercero = 0, PrimerPago = 0, SegundoPago = 0, TercerPago = 0, CuartoPago = 0, QuintoPago = 0, MasDeCincoPago = 0;

            PolizasSinInicialPrimero = MostrarEstadisticaPolizasSinPolizaCantidad((int)OpcionesEstadisticaPolizasSinPagos.PolizasSinPagoInicialPrimero, 106);
            PolizasSinInicialSegundo = MostrarEstadisticaPolizasSinPolizaCantidad((int)OpcionesEstadisticaPolizasSinPagos.PolizasSinPagoInicialSegundo, 106);
            PolizasSinInicialTercero = MostrarEstadisticaPolizasSinPolizaCantidad((int)OpcionesEstadisticaPolizasSinPagos.PolizasSinPagoInicialTercero, 106);
            PrimerPago = MostrarEstadisticaPolizasSinPolizaCantidad((int)OpcionesEstadisticaPolizasSinPagos.PolizasConUnPrimerPagoAplicado, 106);
            SegundoPago = MostrarEstadisticaPolizasSinPolizaCantidad((int)OpcionesEstadisticaPolizasSinPagos.PolizasConUnSegundoPagoAplicado, 106);
            TercerPago = MostrarEstadisticaPolizasSinPolizaCantidad((int)OpcionesEstadisticaPolizasSinPagos.PolizasConUnTercerPagoAplicado, 106);
            CuartoPago = MostrarEstadisticaPolizasSinPolizaCantidad((int)OpcionesEstadisticaPolizasSinPagos.PolizasConUnCuartoPagoAplicado, 106);
            QuintoPago = MostrarEstadisticaPolizasSinPolizaCantidad((int)OpcionesEstadisticaPolizasSinPagos.PolizasConUnQuintoPagoAplicado, 106);
            MasDeCincoPago = MostrarEstadisticaPolizasSinPolizaCantidad((int)OpcionesEstadisticaPolizasSinPagos.PolizasConMasDeCintoPagosAplicados, 106);


            btnSinInicialPrimero.Text = PolizasSinInicialPrimero.ToString("N0");
            btnSinInicialSegundo.Text = PolizasSinInicialSegundo.ToString("N0");
            btnSinInicialTercero.Text = PolizasSinInicialTercero.ToString("N0");
            btnPrimerPAgoAplicado.Text = PrimerPago.ToString("N0");
            btnSegundoPagoAplicado.Text = SegundoPago.ToString("N0");
            btnTercerPagoAplicado.Text = TercerPago.ToString("N0");
            btnCuartoPago.Text = CuartoPago.ToString("N0");
            btnQuintoPago.Text = QuintoPago.ToString("N0");
            btnMasDeCincoPagos.Text = MasDeCincoPago.ToString("N0");

            AntigudadPrimerPago();
            AntiguedadSegundoPago();
            AntiguedadTercerPago();
            AntiguedadCuartoPago();
            AntiguedadQuintoPago();
            AntiguedadMasDeCincoPagos();
        }


        #region INFORMACION DE ANTIGUEDAD
        private void AntigudadPrimerPago() {

            int E_0_30 = 0, E_31_60 = 0, E_61_90 = 0, E_91_120 = 0, E_121_150 = 0, E_151_MAS = 0, DiasNegativos = 0;
            decimal CantidadAcumulada = 0;
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);

            var SacarInformacion = Objtata.Value.BuscaEstadisticaCobrosAntiguedad((int)OpcionesEstadisticaPolizasSinPagos.PolizasConUnPrimerPagoAplicado, 106, _Supervisor, _Intermediario);
            foreach (var n in SacarInformacion) {
                E_0_30 = (int)n.E_0_30;
                E_31_60 = (int)n.E_31_60;
                E_61_90 = (int)n.E_61_90;
                E_91_120 = (int)n.E_91_120;
                E_121_150 = (int)n.E_121_150;
                E_151_MAS = (int)n.E_151_MAS;
                DiasNegativos = (int)n.E_DIAS_NEGATIVOS;
                CantidadAcumulada = (decimal)n.CantidadAcumulada;
            }

            lb0_30_PrimerPago.Text = E_0_30.ToString("N0");
            lb31_60_PrimerPago.Text = E_31_60.ToString("N0");
            lb61_90_PrimerPago.Text = E_61_90.ToString("N0");
            lb91_120_PrimerPago.Text = E_91_120.ToString("N0");
            lb121_150_PrimerPago.Text = E_121_150.ToString("N0");
            lbMas_150_Dias_PrimerPago.Text = E_151_MAS.ToString("N0");
            lbDiasNegativosPrimerPago.Text = DiasNegativos.ToString("N0");
            lbCantidadAcumuladaPrimerPago.Text = CantidadAcumulada.ToString("N2");
        }

        private void AntiguedadSegundoPago() {

            int E_0_30 = 0, E_31_60 = 0, E_61_90 = 0, E_91_120 = 0, E_121_150 = 0, E_151_MAS = 0, DiasNegativos = 0;
            decimal CantidadAcumulada = 0;
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);

            var SacarInformacion = Objtata.Value.BuscaEstadisticaCobrosAntiguedad((int)OpcionesEstadisticaPolizasSinPagos.PolizasConUnSegundoPagoAplicado, 106, _Supervisor, _Intermediario);
            foreach (var n in SacarInformacion)
            {
                E_0_30 = (int)n.E_0_30;
                E_31_60 = (int)n.E_31_60;
                E_61_90 = (int)n.E_61_90;
                E_91_120 = (int)n.E_91_120;
                E_121_150 = (int)n.E_121_150;
                E_151_MAS = (int)n.E_151_MAS;
                DiasNegativos = (int)n.E_DIAS_NEGATIVOS;
                CantidadAcumulada = (decimal)n.CantidadAcumulada;
            }

            lb0_30_SegundoPago.Text = E_0_30.ToString("N0");
            lb31_60_SegundoPago.Text = E_31_60.ToString("N0");
            lb61_90_SegundoPago.Text = E_61_90.ToString("N0");
            lb91_120_SegundoPago.Text = E_91_120.ToString("N0");
            lb121_150_SegundoPago.Text = E_121_150.ToString("N0");
            lb151_Mas_SegundoPago.Text = E_151_MAS.ToString("N0");
            lbDiasNegativosSegundoPago.Text = DiasNegativos.ToString("N0");
            lbCantidadAcumulada_SegundoPago.Text = CantidadAcumulada.ToString("N2");
        }
        private void AntiguedadTercerPago() {
            int E_0_30 = 0, E_31_60 = 0, E_61_90 = 0, E_91_120 = 0, E_121_150 = 0, E_151_MAS = 0, DiasNegativos = 0;
            decimal CantidadAcumulada = 0;
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);

            var SacarInformacion = Objtata.Value.BuscaEstadisticaCobrosAntiguedad((int)OpcionesEstadisticaPolizasSinPagos.PolizasConUnTercerPagoAplicado, 106, _Supervisor, _Intermediario);
            foreach (var n in SacarInformacion)
            {
                E_0_30 = (int)n.E_0_30;
                E_31_60 = (int)n.E_31_60;
                E_61_90 = (int)n.E_61_90;
                E_91_120 = (int)n.E_91_120;
                E_121_150 = (int)n.E_121_150;
                E_151_MAS = (int)n.E_151_MAS;
                DiasNegativos = (int)n.E_DIAS_NEGATIVOS;
                CantidadAcumulada = (decimal)n.CantidadAcumulada;
            }

            lb0_30_TercerPago.Text = E_0_30.ToString("N0");
            lb31_60_TercerPago.Text = E_31_60.ToString("N0");
            lb61_90_TercerPago.Text = E_61_90.ToString("N0");
            lb91_120_TercerPago.Text = E_91_120.ToString("N0");
            lb121_150_TercerPago.Text = E_121_150.ToString("N0");
            lb151_Mas_TercerPago.Text = E_151_MAS.ToString("N0");
            lbDiasNegativosTercerPago.Text = DiasNegativos.ToString("N0");
            lbCantidadAcumulada_TercerPago.Text = CantidadAcumulada.ToString("N2");
        }
        private void AntiguedadCuartoPago() {
            int E_0_30 = 0, E_31_60 = 0, E_61_90 = 0, E_91_120 = 0, E_121_150 = 0, E_151_MAS = 0, DiasNegativos = 0;
            decimal CantidadAcumulada = 0;
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);

            var SacarInformacion = Objtata.Value.BuscaEstadisticaCobrosAntiguedad((int)OpcionesEstadisticaPolizasSinPagos.PolizasConUnCuartoPagoAplicado, 106, _Supervisor, _Intermediario);
            foreach (var n in SacarInformacion)
            {
                E_0_30 = (int)n.E_0_30;
                E_31_60 = (int)n.E_31_60;
                E_61_90 = (int)n.E_61_90;
                E_91_120 = (int)n.E_91_120;
                E_121_150 = (int)n.E_121_150;
                E_151_MAS = (int)n.E_151_MAS;
                DiasNegativos = (int)n.E_DIAS_NEGATIVOS;
                CantidadAcumulada = (decimal)n.CantidadAcumulada;
            }

            lb0_30_CuartoPago.Text = E_0_30.ToString("N0");
            lb31_60_CuartoPago.Text = E_31_60.ToString("N0");
            lb61_90_CuartoPago.Text = E_61_90.ToString("N0");
            lb91_120_CuartoPago.Text = E_91_120.ToString("N0");
            lb121_150_CuartoPago.Text = E_121_150.ToString("N0");
            lb151_Mas_CuartoPago.Text = E_151_MAS.ToString("N0");
            lbDiasNegativosCuartoPago.Text = DiasNegativos.ToString("N0");
            lbCantidadAcumulada_CuartoPago.Text = CantidadAcumulada.ToString("N2");
        }
        private void AntiguedadQuintoPago() {
            int E_0_30 = 0, E_31_60 = 0, E_61_90 = 0, E_91_120 = 0, E_121_150 = 0, E_151_MAS = 0, DiasNegativos = 0;
            decimal CantidadAcumulada = 0;
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);

            var SacarInformacion = Objtata.Value.BuscaEstadisticaCobrosAntiguedad((int)OpcionesEstadisticaPolizasSinPagos.PolizasConUnQuintoPagoAplicado, 106, _Supervisor, _Intermediario);
            foreach (var n in SacarInformacion)
            {
                E_0_30 = (int)n.E_0_30;
                E_31_60 = (int)n.E_31_60;
                E_61_90 = (int)n.E_61_90;
                E_91_120 = (int)n.E_91_120;
                E_121_150 = (int)n.E_121_150;
                E_151_MAS = (int)n.E_151_MAS;
                DiasNegativos = (int)n.E_DIAS_NEGATIVOS;
                CantidadAcumulada = (decimal)n.CantidadAcumulada;
            }

            lb0_30_QuintoPago.Text = E_0_30.ToString("N0");
            lb31_60_QuintoPago.Text = E_31_60.ToString("N0");
            lb61_90_QuintoPago.Text = E_61_90.ToString("N0");
            lb91_120_QuintoPago.Text = E_91_120.ToString("N0");
            lb121_150_QuintoPago.Text = E_121_150.ToString("N0");
            lb151_Mas_QuintoPago.Text = E_151_MAS.ToString("N0");
            lbDiasNegativosQuintoPago.Text = DiasNegativos.ToString("N0");
            lbCantidadAcumulada_QuintoPago.Text = CantidadAcumulada.ToString("N2");
        }
        private void AntiguedadMasDeCincoPagos() {
            int E_0_30 = 0, E_31_60 = 0, E_61_90 = 0, E_91_120 = 0, E_121_150 = 0, E_151_MAS = 0, DiasNegativos = 0;
            decimal CantidadAcumulada = 0;
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);

            var SacarInformacion = Objtata.Value.BuscaEstadisticaCobrosAntiguedad((int)OpcionesEstadisticaPolizasSinPagos.PolizasConMasDeCintoPagosAplicados, 106, _Supervisor, _Intermediario);
            foreach (var n in SacarInformacion)
            {
                E_0_30 = (int)n.E_0_30;
                E_31_60 = (int)n.E_31_60;
                E_61_90 = (int)n.E_61_90;
                E_91_120 = (int)n.E_91_120;
                E_121_150 = (int)n.E_121_150;
                E_151_MAS = (int)n.E_151_MAS;
                DiasNegativos = (int)n.E_DIAS_NEGATIVOS;
                CantidadAcumulada = (decimal)n.CantidadAcumulada;
            }

            lb0_30_Mas_Cinco_Pagos.Text = E_0_30.ToString("N0");
            lb31_60_Mas_Cinco_Pagos.Text = E_31_60.ToString("N0");
            lb61_90_Mas_Cinco_Pagos.Text = E_61_90.ToString("N0");
            lb91_120_Mas_Cinco_Pagos.Text = E_91_120.ToString("N0");
            lb121_150_Mas_Cinco_Pagos.Text = E_121_150.ToString("N0");
            lb151_Mas_Mas_Cinco_Pagos.Text = E_151_MAS.ToString("N0");
            lbDiasNegativosMasDeCincoPagos.Text = DiasNegativos.ToString("N0");
            lbCantidadAcumulada_Mas_Cinco_Pagos.Text = CantidadAcumulada.ToString("N2");
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                Label lbUsuarioConectado = (Label)Master.FindControl("lbUsuarioConectado");
                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbUsuarioConectado.Text = Nombre.SacarNombreUsuarioConectado();
                lbPantalla.Text = "Menu Principal";


                int IdPerfil = 0;
                DivBloqueEstadistica.Visible = false;
                DIVBloqueImagen.Visible = true;
                DIvBloqueRemodelacion.Visible = false;
                DIVBloqueNotificacionesReclamaciones.Visible = false;

                var SacarPerfiles = Objtata.Value.BuscaUsuarios((decimal)Session["IdUsuario"]);
                foreach (var n in SacarPerfiles) {

                    IdPerfil = (int)n.IdPerfil;
                }

                switch (IdPerfil) {

                    case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.PerfilesUsuarios.ADMINISTRADOR:
                        DivBloqueEstadistica.Visible = true;
                        DIVBloqueImagen.Visible = false;
                        DIvBloqueRemodelacion.Visible = false;
                        DIVBloqueNotificacionesReclamaciones.Visible = true;

                       // ActualizarInformacionEstadistica();
                        break;

                    case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.PerfilesUsuarios.COBROS:
                        DivBloqueEstadistica.Visible = true;
                        DIVBloqueImagen.Visible = false;
                        DIvBloqueRemodelacion.Visible = false;
                        DIVBloqueNotificacionesReclamaciones.Visible = false;


                       // ActualizarInformacionEstadistica();
                        break;

                    case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.PerfilesUsuarios.Cobros_Especial:
                        DivBloqueEstadistica.Visible = true;
                        DIVBloqueImagen.Visible = false;
                        DIvBloqueRemodelacion.Visible = false;
                        DIVBloqueNotificacionesReclamaciones.Visible = false;

                        //ActualizarInformacionEstadistica();
                        break;

                    case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.PerfilesUsuarios.NEGOCIOS:
                        DivBloqueEstadistica.Visible = true;
                        DIVBloqueImagen.Visible = false;
                        DIvBloqueRemodelacion.Visible = false;
                        DIVBloqueNotificacionesReclamaciones.Visible = false;


                        break;

                    case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.PerfilesUsuarios.RECLAMACIONES:
                        DivBloqueEstadistica.Visible = false;
                        DIVBloqueImagen.Visible = true;
                        DIvBloqueRemodelacion.Visible = false;
                        DIVBloqueNotificacionesReclamaciones.Visible = true;


                        break;
                }
                DivBloqueCheck.Visible = false;
                cbSinInicial.Checked = true;
                cbPrimerPago.Checked = true;
                cbSegundoPago.Checked = true;
                cbTercerpago.Checked = true;
                cbCuartoPago.Checked = true;
                cbQuintoPago.Checked = true;
                //ActualizarInformacionEstadistica();


                decimal IdUsuario = (decimal)Session["IdUsuario"];
            
                var ValidarInformmacion = Objtata.Value.BuscaSupervisoresPorDefectoPolizasSinPagos(IdUsuario);
                if (ValidarInformmacion.Count() < 1) {
                
                }
                else {
                    foreach (var n in ValidarInformmacion) {

                        txtCodigoSupervisor.Text = n.CodigoSupervisor.ToString();
                        txtNombreSupervisor.Text = n.Supervisor;
                    }

                    ActualizarInformacionEstadistica();
                }
            }
          
        }

        protected void LinkSinPagoInicial_Click(object sender, EventArgs e)
        {
        //    ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.Poliza_Sin_Pago_Inicial, 106,"Polizas SIn Pago Inicial");
        }

        protected void btnSinPagoInicial_Click(object sender, EventArgs e)
        {
            //ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.Poliza_Sin_Pago_Inicial, 106,"Polizas Sin Pago Inicial");
        }

        protected void btnPrimerPagoSinCobros_Click(object sender, EventArgs e)
        {
            //ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.Polzias_11_30,106,"Polizas Sin Pagos de 11 a 30 Dias");
        }

        protected void btnSegundoPagoSinCobros_Click(object sender, EventArgs e)
        {
            //ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.Polizas_31_60,106, "Polizas Sin Pagos de 31 a 60 Dias");
        }

        protected void btnTercerPagoSinCobros_Click(object sender, EventArgs e)
        {
            //ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.Polizas_61_90,106, "Polizas Sin Pagos de 61 a 90 Dias");
        }

        protected void btnCuartoPagoSinCobros_Click(object sender, EventArgs e)
        {
            //ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.Polizas_91_120, 106, "Polizas Sin Pagos de 91 a 120 Dias");
        }

        protected void btnMasDeCientoVeinteDiasSinCobros_Click(object sender, EventArgs e)
        {
          //  ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.Polizas_121_mas, 106, "Polizas Sin Pagos mas de 120 Dias");
        }

        protected void btnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ActualizarInformacionEstadistica();
        }

        protected void cbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodos.Checked == true) {

                cbSinInicial.Checked = true;
                cbPrimerPago.Checked = true;
                cbSegundoPago.Checked = true;
                cbTercerpago.Checked = true;
                cbCuartoPago.Checked = true;
                cbQuintoPago.Checked = true;
            }
            else if (cbTodos.Checked == false) {
                cbSinInicial.Checked = false;
                cbPrimerPago.Checked = false;
                cbSegundoPago.Checked = false;
                cbTercerpago.Checked = false;
                cbCuartoPago.Checked = false;
                cbQuintoPago.Checked = false;
            }
        }

        protected void cbSinInicial_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSinInicial.Checked == true) {

                if (cbSinInicial.Checked == true &&
                    cbPrimerPago.Checked == true &&
                    cbSegundoPago.Checked == true &&
                    cbTercerpago.Checked == true &&
                    cbCuartoPago.Checked == true &&
                    cbQuintoPago.Checked == true)
                {
                    cbTodos.Checked = true;
                }
            }
            else {
                cbTodos.Checked = false;
            }
        }

        protected void cbPrimerPago_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPrimerPago.Checked == true)
            {

                if (cbSinInicial.Checked == true &&
                    cbPrimerPago.Checked == true &&
                    cbSegundoPago.Checked == true &&
                    cbTercerpago.Checked == true &&
                    cbCuartoPago.Checked == true &&
                    cbQuintoPago.Checked == true)
                {
                    cbTodos.Checked = true;
                }
            }
            else
            {
                cbTodos.Checked = false;
            }
        }

        protected void cbSegundoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSegundoPago.Checked == true)
            {

                if (cbSinInicial.Checked == true &&
                    cbPrimerPago.Checked == true &&
                    cbSegundoPago.Checked == true &&
                    cbTercerpago.Checked == true &&
                    cbCuartoPago.Checked == true &&
                    cbQuintoPago.Checked == true)
                {
                    cbTodos.Checked = true;
                }
            }
            else
            {
                cbTodos.Checked = false;
            }
        }

        protected void cbTercerpago_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTercerpago.Checked == true)
            {

                if (cbSinInicial.Checked == true &&
                    cbPrimerPago.Checked == true &&
                    cbSegundoPago.Checked == true &&
                    cbTercerpago.Checked == true &&
                    cbCuartoPago.Checked == true &&
                    cbQuintoPago.Checked == true)
                {
                    cbTodos.Checked = true;
                }
            }
            else
            {
                cbTodos.Checked = false;
            }
        }

        protected void cbCuartoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCuartoPago.Checked == true)
            {

                if (cbSinInicial.Checked == true &&
                    cbPrimerPago.Checked == true &&
                    cbSegundoPago.Checked == true &&
                    cbTercerpago.Checked == true &&
                    cbCuartoPago.Checked == true &&
                    cbQuintoPago.Checked == true)
                {
                    cbTodos.Checked = true;
                }
            }
            else
            {
                cbTodos.Checked = false;
            }
        }

        protected void cbQuintoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (cbQuintoPago.Checked == true)
            {

                if (cbSinInicial.Checked == true &&
                    cbPrimerPago.Checked == true &&
                    cbSegundoPago.Checked == true &&
                    cbTercerpago.Checked == true &&
                    cbCuartoPago.Checked == true &&
                    cbQuintoPago.Checked == true)
                {
                    cbTodos.Checked = true;
                }
            }
            else
            {
                cbTodos.Checked = false;
            }
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            if (cbSinInicial.Checked == false &&
                cbPrimerPago.Checked == false &&
                cbSegundoPago.Checked == false &&
                cbTercerpago.Checked == false &&
                cbCuartoPago.Checked == false &&
                cbQuintoPago.Checked == false)
            {
                ClientScript.RegisterStartupScript(GetType(), "Mensaje()", "Mensaje();", true);
            }
            else
            {

                //decimal IdUsuario = (decimal)Session["IdUsuario"];
                //int CodigoEstatus = 0;

                //EliminarInformacion(IdUsuario, "DELETE");

                //if (cbSinInicial.Checked == true)
                //{
                //    CodigoEstatus = (int)OpcionesEstadisticaPolizasSinPagos.Poliza_Sin_Pago_Inicial;
                //    ProcesarInformacionEstadisticaPolizasSinPagos(CodigoEstatus, 106, IdUsuario, CodigoEstatus, "INSERT");
                //}

                //if (cbPrimerPago.Checked == true)
                //{
                //    CodigoEstatus = (int)OpcionesEstadisticaPolizasSinPagos.Polzias_11_30;
                //    ProcesarInformacionEstadisticaPolizasSinPagos((int)OpcionesEstadisticaPolizasSinPagos.Polzias_11_30, 106, IdUsuario, CodigoEstatus, "INSERT");
                //}

                //if (cbSegundoPago.Checked == true)
                //{
                //    CodigoEstatus = (int)OpcionesEstadisticaPolizasSinPagos.Polizas_31_60;
                //    ProcesarInformacionEstadisticaPolizasSinPagos((int)OpcionesEstadisticaPolizasSinPagos.Polizas_31_60, 106, IdUsuario, CodigoEstatus, "INSERT");
                //}

                //if (cbTercerpago.Checked == true)
                //{
                //    CodigoEstatus = (int)OpcionesEstadisticaPolizasSinPagos.Polizas_61_90;
                //    ProcesarInformacionEstadisticaPolizasSinPagos((int)OpcionesEstadisticaPolizasSinPagos.Polizas_61_90, 106, IdUsuario, CodigoEstatus, "INSERT");
                //}

                //if (cbCuartoPago.Checked == true)
                //{
                //    CodigoEstatus = (int)OpcionesEstadisticaPolizasSinPagos.Polizas_91_120;
                //    ProcesarInformacionEstadisticaPolizasSinPagos((int)OpcionesEstadisticaPolizasSinPagos.Polizas_91_120, 106, IdUsuario, CodigoEstatus, "INSERT");
                //}

                //if (cbQuintoPago.Checked == true)
                //{
                //    CodigoEstatus = (int)OpcionesEstadisticaPolizasSinPagos.Polizas_121_mas;
                //    ProcesarInformacionEstadisticaPolizasSinPagos((int)OpcionesEstadisticaPolizasSinPagos.Polizas_121_mas, 106, IdUsuario, CodigoEstatus, "INSERT");
                //}
                //GenerarReporteEstadisticaPolizasSinPagos();
            }
        }

        protected void btnTercerPagoAplicado_Click(object sender, EventArgs e)
        {
            ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.PolizasConUnTercerPagoAplicado, 106, "Polizas Con un Tercer Pago Aplicado");
        }

        protected void btnSegundoPagoAplicado_Click(object sender, EventArgs e)
        {
            ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.PolizasConUnSegundoPagoAplicado, 106, "Polizas Con un Segundo Pago Aplicado");
        }

        protected void btnPrimerPAgoAplicado_Click(object sender, EventArgs e)
        {
            ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.PolizasConUnPrimerPagoAplicado, 106, "Polizas Con un Primer Pago Aplicado");
            


        }

        protected void btnSinInicialTercero_Click(object sender, EventArgs e)
        {
            ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.PolizasSinPagoInicialTercero, 106, "Polizas Sin Pagos de Mas de 30 Dias");
        }

        protected void btnSinInicialSegundo_Click(object sender, EventArgs e)
        {
            ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.PolizasSinPagoInicialSegundo, 106, "Polizas Sin Pagos de 11 a 30 Dias");
        }

        protected void btnSinInicialPrimero_Click(object sender, EventArgs e)
        {
            ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.PolizasSinPagoInicialPrimero, 106, "Polizas Sin Pagos de 0 a 11 Dias");
        }

        protected void btnCuartoPago_Click(object sender, EventArgs e)
        {
            ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.PolizasConUnCuartoPagoAplicado, 106, "Polizas Con un Cuarto Pago Aplicado");
        }

        protected void btnQuintoPago_Click(object sender, EventArgs e)
        {
            ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.PolizasConUnQuintoPagoAplicado, 106, "Polizas Con un Quinto Pago Aplicado");
        }

        protected void btnMasDeCincoPagos_Click(object sender, EventArgs e)
        {
            ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.PolizasConMasDeCintoPagosAplicados, 106, "Polizas Con Mas de Cinco Pagos Aplicados");
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreSupervisor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisor.Text);
            txtNombreSupervisor.Text = NombreSupervisor.SacarNombreSupervisor();
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreIntermediario = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediario.Text);
            txtNombreIntermediario.Text = NombreIntermediario.SacarNombreIntermediario();
        }
    }
}