using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas.Procesos
{
    public partial class VolantesDePagos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjDataProceso = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();


        private string GenerarNombreArchivo(string NombreEmpleado) {
            string Intervalo = "";
            Random Numero = new Random();
            string PrimerIntervalo = Numero.Next(0, 999999999).ToString();
            string SegundoIntervalo = Numero.Next(0, 999999999).ToString();
            string Year = DateTime.Now.Year.ToString();
            string Month = DateTime.Now.Year.ToString();
            string Day = DateTime.Now.Year.ToString();

            Intervalo = PrimerIntervalo + Year + Month + Day + SegundoIntervalo + " - " + NombreEmpleado;
            return Intervalo;

        }
        
        string NombreArchivo="JUAN MARCELINO MEDINA DIAZ";
        string VolantePagoPDF = "";

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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref LinkButton PrimeraPagina, ref LinkButton PaginaAnterior, ref LinkButton SiguientePagina, ref LinkButton UltimaPagina)
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

        #region BUSCAR EL LISTADO DE LOS CODIGOS
        private void BuscarCodigosEmpleados() {
            string _NombreEmpleado = string.IsNullOrEmpty(txtNombreEmpleadoConsulta.Text.Trim()) ? null : txtNombreEmpleadoConsulta.Text.Trim();

            var BuscarEmpleado = ObjDataProceso.Value.BuscaInformacionEmpleados(
                new Nullable<int>(),
                _NombreEmpleado,
                null, null, null, null, null, null);
            Paginar(ref rpListadoCodigos, BuscarEmpleado, 10, ref lbCantidadPaginaVariableVolantePago, ref LinkPrimeraPaginaVolantePago, ref LinkAnteriorVolantePago, ref LinkSiguienteVolantePago, ref LinkUltimoVolantePago);
            HandlePaging(ref dtPaginacionVolantePago, ref lbPaginaActualVariavleVolantePago);
        }
        #endregion

   

        #region CARGAR LOS TIPOS DE NOMINA
        private void CargarTipoNomina() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoNomina, ObjData.Value.BuscaListas("TIPONOMINA", null, null));
        }
        #endregion

        #region SACAR EL MES Y EL AÑO ACTUAL
        private void SacarMesAnoActual() {
            DateTime Year = DateTime.Now;
            DateTime Month = DateTime.Now;

            txtAno.Text = Year.Year.ToString();
            txtMes.Text = Month.Month.ToString();
        }
        #endregion

        #region GENERAR VOLANTE DE PAGO
        private void GenerarVolantePago(string RutaReporte, string NombreArchivo,string UsuarioBD, string ClaveBD) {
            //DECLARAMOS LOS PARAMETROS NECESARIOS PARA ESTA PROCESO
            int? _CodigoEmpleado = string.IsNullOrEmpty(txtCodigoEmpleado.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoEmpleado.Text.Trim());
            int? _Oficina =  new Nullable<int>();
            int? _Ano = string.IsNullOrEmpty(txtAno.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtAno.Text.Trim());
            byte? _Mes = string.IsNullOrEmpty(txtMes.Text.Trim()) ? new Nullable<byte>() : Convert.ToByte(txtMes.Text.Trim());
            int _NoPago = 0;

            if (rbPrimeraQuincena.Checked == true) { _NoPago = 1; }
            else if (rbSegundaQuincena.Checked == true) { _NoPago = 2; }

            int? _TipoMovimiento = new Nullable<int>();
            byte? _TipoNomina = ddlTipoNomina.SelectedValue != "-1" ? Convert.ToByte(ddlTipoNomina.SelectedValue) : new Nullable<byte>();
            int? _CodigoDepartamento = new Nullable<int>();
            string _NombreEmpleado = string.IsNullOrEmpty(txtNombreEmpleado.Text.Trim()) ? null : txtNombreEmpleado.Text.Trim();


            ReportDocument Volante = new ReportDocument();

            Volante.Load(RutaReporte);
            Volante.Refresh();

            Volante.SetParameterValue("@CodigoEmpleado", _CodigoEmpleado);
            Volante.SetParameterValue("@Ano", _Ano);
            Volante.SetParameterValue("@Mes", _Mes);
            Volante.SetParameterValue("@TipoMovimiento", _TipoMovimiento);
            Volante.SetParameterValue("@TipoNomina", _TipoNomina);
            Volante.SetParameterValue("@NoPago", _NoPago);
            Volante.SetParameterValue("@CodigoSucursal", _Oficina);
            Volante.SetParameterValue("@CodigoDepartamento", _CodigoDepartamento);
            Volante.SetParameterValue("@NombreEmpleado", _NombreEmpleado);

            Volante.SetDatabaseLogon(UsuarioBD, ClaveBD);
            //Volante.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Prueba");
            NombreArchivo = GenerarNombreArchivo("GRACY LINETTE FELIZ SANCHEZ");
            VolantePagoPDF = "C:\\Users\\Ing. Juan Marcelino\\Desktop\\Prueba\\" + NombreArchivo + ".PDF";
            Volante.ExportToDisk(ExportFormatType.PortableDocFormat, VolantePagoPDF);



        }
        #endregion

        #region ENVIO DE CORREO
        private void EnvioCorreo(string CorreoEmisor, string Alias, string Asunto, string ClaveCorreo, int Puerto, string SMTP, string Cuerpo) {
            UtilidadesAmigos.Logica.Comunes.EnvioCorreos MAil = new Logica.Comunes.EnvioCorreos
            {
                Mail = CorreoEmisor,
                Alias = Alias,
                Asunto = Asunto,
                Clave = ClaveCorreo,
                Puerto = Puerto,
                smtp = SMTP,
                RutaImagen = Server.MapPath("LogoReducido.jpg"),
                Cuerpo=Cuerpo,
                Destinatarios=new List<string>(),
                Adjuntos=new List<string>()
            };

            MAil.Destinatarios.Add("jmdiaz@amigosseguros.com");
            MAil.Adjuntos.Add(VolantePagoPDF);

            if (MAil.Enviar(MAil))
            {

            }
        }
/* private void EnvioCorreo(string CorreoEmisor, string Alias, string Asunto, string ClaveCorreo, int Puerto, string SMTP, string Cuerpo) {


    UtilidadesAmigos.Logica.Comunes.EnvioCorreos Mail = new Logica.Comunes.EnvioCorreos
    {
        Mail = CorreoEmisor,
        Alias = Alias,
        Asunto = Asunto,
        Clave = ClaveCorreo,
        Puerto = Puerto,
        smtp = SMTP,
        RutaImagen = Server.MapPath("LogoReducido.jpg"),
        Cuerpo = Cuerpo,
        Destinatarios = new List<string>(),
        Adjuntos = new List<string>()
    };


    var MandarCorreos = ObjDataAdministrador.Value.BuscaCorreosEnviar(
                new Nullable<decimal>(),
                1, null, true);
    foreach (var n in MandarCorreos) {
        Mail.Destinatarios.Add(n.Correo);
    }

    //List<string> Logo = new List<string>();
    //Logo.Add(Server.MapPath("Logo.jpg"));

    //foreach (var n2 in Logo) {
    //    Mail.Adjuntos.Add(n2);
    //}



    if (Mail.Enviar(Mail)) {

    }
}*/
            #endregion

            private void IniciarPantalla() {
    DivBloqueProceso.Visible = true;
    DivBloqueBuscarCodigo.Visible = false;
    CurrentPage = 0;
    BuscarCodigosEmpleados();

    CargarTipoNomina();
    rbPrimeraQuincena.Checked = true;
    SacarMesAnoActual();
}
protected void Page_Load(object sender, EventArgs e)
{
    MaintainScrollPositionOnPostBack = true;
    if (!IsPostBack) {
        UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario SacarNombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
        Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
        lbNombreUsuario.Text = SacarNombre.SacarNombreUsuarioConectado();
        Label lbPantallaActual = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
        lbPantallaActual.Text = "GENERAR VOLANTES DE PAGOS";
        IniciarPantalla();

    }

}

protected void txtCodigoEmpleado_TextChanged(object sender, EventArgs e)
{
    try {
        int CodigoEmpleado = Convert.ToInt32(txtCodigoEmpleado.Text);

        var SacarNombreEmpleado = ObjDataProceso.Value.BuscaInformacionEmpleados(CodigoEmpleado, null, null, null, null, null, null, "A");
        if (SacarNombreEmpleado.Count() < 1)
        {
            txtNombreEmpleado.Text = "EL CODIGO DE EMPLEADO INGRSADO NO ES VALIDO O ESTA CANCELADO";
        }
        else {
            foreach (var n in SacarNombreEmpleado)
            {
                txtNombreEmpleado.Text = n.Nombre;
            }
        }

    }
    catch (Exception) {
        txtNombreEmpleado.Text = "";
    }
}

protected void btnProcesar_Click(object sender, EventArgs e)
{
            
            GenerarVolantePago(Server.MapPath("VolantePagos.rpt"), "d", "sa", "!@Pa$$W0rd!@0624");
            EnvioCorreo(
                "ing.juanmarcelinom.diaz@hotmail.com",
                "Utilidades Amigos",
                "Volante de Pago",
                "!@Pa$$W0rd!@0624",
                587,
                "smtp.live.com",
                "Plantilla de Prueba de Volante de Pago");
        }

        protected void btnCodigos_Click(object sender, EventArgs e)
{
    DivBloqueProceso.Visible = false;
    DivBloqueBuscarCodigo.Visible = true;
    txtNombreEmpleadoConsulta.Text = string.Empty;
    CurrentPage = 0;
    BuscarCodigosEmpleados();
}



protected void btnBuscarCodigo_Click(object sender, EventArgs e)
{
    CurrentPage = 0;
    BuscarCodigosEmpleados();
}

protected void btnSeleccionar_Click(object sender, EventArgs e)
{

}

protected void LinkPrimeraPaginaVolantePago_Click(object sender, EventArgs e)
{
    CurrentPage = 0;
    BuscarCodigosEmpleados();
}

protected void LinkAnteriorVolantePago_Click(object sender, EventArgs e)
{
    CurrentPage += -1;
    BuscarCodigosEmpleados();
    MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleVolantePago, ref lbCantidadPaginaVariableVolantePago);
}

protected void dtPaginacionVolantePago_ItemDataBound(object sender, DataListItemEventArgs e)
{

}

protected void dtPaginacionVolantePago_ItemCommand(object source, DataListCommandEventArgs e)
{
    if (!e.CommandName.Equals("newPage")) return;
    CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
    BuscarCodigosEmpleados();
}

protected void LinkSiguienteVolantePago_Click(object sender, EventArgs e)
{
    CurrentPage += 1;
    BuscarCodigosEmpleados();
}

protected void LinkUltimoVolantePago_Click(object sender, EventArgs e)
{
    CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
    BuscarCodigosEmpleados();
    MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleVolantePago, ref lbCantidadPaginaVariableVolantePago);
}



protected void btnVolverVolantePago_Click(object sender, EventArgs e)
{
    IniciarPantalla();
}
}
}