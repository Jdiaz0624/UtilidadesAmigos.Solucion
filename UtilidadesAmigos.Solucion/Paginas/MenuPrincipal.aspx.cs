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
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas

{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objtata = new Lazy<Logica.Logica.LogicaSistema>();
        public UtilidadesAmigos.Logica.Comunes.VariablesGlobales VariablesGlobales = new Logica.Comunes.VariablesGlobales();

        #region CONTROL PARA MOSTRAR LA PAGINACION
        readonly PagedDataSource pagedDataSource = new PagedDataSource();
        int _PrimeraPagina, _UltimaPagina;
        private int _TamanioPagina = 10;
        private int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] == null)
                {
                    return 0;
                }
                return ((int)ViewState["CurrentPage"]);
            }
            set
            {
                ViewState["CurrentPage"] = value;
            }

        }
        private void HandlePaging(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina = CurrentPage - 5;
            if (CurrentPage > 5)
                _UltimaPagina = CurrentPage + 5;
            else
                _UltimaPagina = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina = _UltimaPagina - 10;
            }

            if (_PrimeraPagina < 0)
                _PrimeraPagina = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina; i < _UltimaPagina; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource.DataSource = Listado;
            pagedDataSource.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina : _NumeroRegistros);
            pagedDataSource.CurrentPageIndex = CurrentPage;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource.IsLastPage;

            RptGrid.DataSource = pagedDataSource;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
        {

            int PaginaActual = 0;
            switch (Accion)
            {

                case 1:
                    //PRIMERA PAGINA
                    lbPaginaActual.Text = "1";

                    break;

                case 2:
                    //SEGUNDA PAGINA
                    PaginaActual = Convert.ToInt32(lbPaginaActual.Text);
                    PaginaActual++;
                    lbPaginaActual.Text = PaginaActual.ToString();
                    break;

                case 3:
                    //PAGINA ANTERIOR
                    PaginaActual = Convert.ToInt32(lbPaginaActual.Text);
                    if (PaginaActual > 1)
                    {
                        PaginaActual--;
                        lbPaginaActual.Text = PaginaActual.ToString();
                    }
                    break;

                case 4:
                    //ULTIMA PAGINA
                    lbPaginaActual.Text = lbCantidadPaginas.Text;
                    break;


            }

        }
        #endregion

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


        private void MostrarListadoHeader() {

            var Data = Objtata.Value.BuscaNotificacionesReclamaciones();
            Paginar(ref rpNotificaciones, Data, 10, ref lbCantidadPagina, ref btnPrimeraPagina, ref btnPaginaAnterior, ref btnSiguientePagina, ref btnUltimaPagina);
            HandlePaging(ref dtPaginacion, ref lbPaginaActual);
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

                DIVBloqueImagen.Visible = true;
                DIvBloqueRemodelacion.Visible = false;
                DIVBloqueNotificacionesReclamaciones.Visible = false;

                var SacarPerfiles = Objtata.Value.BuscaUsuarios((decimal)Session["IdUsuario"]);
                foreach (var n in SacarPerfiles) {

                    IdPerfil = (int)n.IdPerfil;
                }

                switch (IdPerfil) {

                    case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.PerfilesUsuarios.ADMINISTRADOR:
 
                        DIVBloqueImagen.Visible = false;
                        DIvBloqueRemodelacion.Visible = false;
                        DIVBloqueNotificacionesReclamaciones.Visible = true;
                        CurrentPage = 0;
                        MostrarListadoHeader();

                       // ActualizarInformacionEstadistica();
                        break;

                    case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.PerfilesUsuarios.COBROS:
             
                        DIVBloqueImagen.Visible = false;
                        DIvBloqueRemodelacion.Visible = false;
                        DIVBloqueNotificacionesReclamaciones.Visible = false;


                       // ActualizarInformacionEstadistica();
                        break;

                    case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.PerfilesUsuarios.Cobros_Especial:
        
                        DIVBloqueImagen.Visible = false;
                        DIvBloqueRemodelacion.Visible = false;
                        DIVBloqueNotificacionesReclamaciones.Visible = false;

                        //ActualizarInformacionEstadistica();
                        break;

                    case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.PerfilesUsuarios.NEGOCIOS:

                        DIVBloqueImagen.Visible = false;
                        DIvBloqueRemodelacion.Visible = false;
                        DIVBloqueNotificacionesReclamaciones.Visible = false;


                        break;

                    case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.PerfilesUsuarios.RECLAMACIONES:
          
                        DIVBloqueImagen.Visible = true;
                        DIvBloqueRemodelacion.Visible = false;
                        DIVBloqueNotificacionesReclamaciones.Visible = true;
                        CurrentPage = 0;
                        MostrarListadoHeader();

                        break;
                }
             


                

          
            }
          
        }

        protected void btnExportarReclamaciones_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var IdEstatus = ((HiddenField)ItemSeleccionado.FindControl("hfCodigoEstatus")).Value.ToString();
            var NombreEstatus = ((HiddenField)ItemSeleccionado.FindControl("hfNombreEstatus")).Value.ToString();

            var Exportar = Objtata.Value.BuscaDetalleNotificacionesReclamaciones(Convert.ToInt32(IdEstatus));
            if (Exportar.Count() < 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "MensajeNotificacion()", "MensajeNotificacion();", true);
            }
            else {

                var Resultado = (from n in Exportar
                                 select new
                                 {
                                     Reclamacion = n.Reclamacion,
                                     Estatus = n.NombreEstatus,
                                     Monto_Reclamado = n.MontoReclamado,
                                     Monto_Ajustado = n.MontoAjustado,
                                     Monto_Reserva = n.MontoReserva,
                                     Monto_Salvamento = n.MontoSalvamento,
                                     Fecha_Apertura = n.FechaApertura,
                                     Hora_Apertura = n.HoraApertura,
                                     Fecha_Siniestro = n.FechaSiniestro,
                                     Hora_Siniestro = n.HoraSiniestro,
                                     Poliza = n.Poliza,
                                     CLiente = n.CLiente,
                                     Supervisor = n.Supervisor,
                                     Intermediario = n.Intermediario,
                                     Monto_Prima = n.MontoPrima,
                                     Monto_Asegurado = n.MontoAsegurado,
                                     Comentario = n.Comentario,
                                     Inicio_de_Vigencia = n.IniciodeVigencia,
                                     Fin_de_Vigencia = n.FindeVigencia,
                                     CreadaPor = n.CreadaPor,
                                     Fecha_Creada = n.FechaCreada,
                                     ModificadoPor = n.ModificadoPor,
                                     Fecha_Modificada = n.Fecha_Modificada
                                 }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Reclamaciones con Estatus " + NombreEstatus, Resultado);
            }
        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_CancelCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}