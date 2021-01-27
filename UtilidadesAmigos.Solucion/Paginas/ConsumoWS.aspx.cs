using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ConsumoWS : System.Web.UI.Page
    {
      //  UtilidadesAmigos.Solucion.WSConsultaSuperIntendencia.ConsultarInformacionPolizasSoapClient WSSuperIntenedencia = new WSConsultaSuperIntendencia.ConsultarInformacionPolizasSoapClient();
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


        private void HandlePaging(ref DataList NombreDataList, ref Label lbPaginaActual)
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
            lbPaginaActual.Text = (NumeroPagina + 1).ToString();
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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref LinkButton PrimeraPagina, ref LinkButton PaginaAnterior, ref LinkButton PaginaSiguiente, ref LinkButton UltimaPagina)
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
            PaginaSiguiente.Enabled = !pagedDataSource.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource.IsLastPage;

            RptGrid.DataSource = pagedDataSource;
            RptGrid.DataBind();


            //  divPaginacionBancos.Visible = true;
        }
        enum OpcionesPaginacionValores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion(int Accion, ref Label lbPaginaActual, ref Label CantidadPagina)
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
                    lbPaginaActual.Text = CantidadPagina.Text;
                    break;


            }

        }
        #endregion
        private void BloquearCOntroles() {

            lbNumeroPolizaControl.Enabled = false;
            txtPolizaControl.Enabled = false;
            lbNumeroItemControl.Enabled = false;
            txtItemControl.Enabled = false;
            lbNombreClienteControl.Enabled = false;
            txtNombreCLienteControl.Enabled = false;
            lbNumeroIdentificacionControl.Enabled = false;
            txtNumeroIdentificacionControl.Enabled = false;
            lbAseguradoCOntrol.Enabled = false;
            txtNombreAseguradoCOntrol.Enabled = false;
            lbMArcaControl.Enabled = false;
            txtMarcaControl.Enabled = false;
            lbModeloControl.Enabled = false;
            txtModeloControl.Enabled = false;
            lbChasisControl.Enabled = false;
            txtChasisControl.Enabled = false;
            lbPlacaControl.Enabled = false;
            txtPlacaControl.Enabled = false;


            DivBloqueIdentificarRamoPoliza.Visible = false;
        }

        enum OpcionesConsulta { 
        RamoPoliza=1,
        Vehiculo=2,
        Fianzas=3,
        IncencioLineasAliadas=4,
        RamosTecnicos=5,
        Salud=6,
        TransporteCarga=7,
        VidaIndividual=8,
        VidaColectivo=9,
        Odontologico=9,
        ConsultarDependientes=10
        }

     


        private void COnsultarRegistros(int Operacion) {
            
            string _Poliza = string.IsNullOrEmpty(txtPolizaControl.Text.Trim()) ? null : txtPolizaControl.Text.Trim();
            string _Item = string.IsNullOrEmpty(txtItemControl.Text.Trim()) ? null : txtItemControl.Text.Trim();
            string _NombreCliente = string.IsNullOrEmpty(txtNombreCLienteControl.Text.Trim()) ? null : txtNombreCLienteControl.Text.Trim();
            string _Numeroidentificacion = string.IsNullOrEmpty(txtNumeroIdentificacionControl.Text.Trim()) ? null : txtNumeroIdentificacionControl.Text.Trim();
            string _NombreAsegurado = string.IsNullOrEmpty(txtNombreAseguradoCOntrol.Text.Trim()) ? null : txtNombreAseguradoCOntrol.Text.Trim();
            string _Chasis = string.IsNullOrEmpty(txtChasisControl.Text.Trim()) ? null : txtChasisControl.Text.Trim();
            string _Placa = string.IsNullOrEmpty(txtPlacaControl.Text.Trim()) ? null : txtPlacaControl.Text.Trim();

            if (Operacion == (int)OpcionesConsulta.RamoPoliza)
            {

                //var Buscar = WSSuperIntenedencia.Buscar_Ramo_Poliza(_Poliza);
                //rpConsultaRamoPoliza.DataSource = Buscar;
                //rpConsultaRamoPoliza.DataBind();
            }
            else if (Operacion == (int)OpcionesConsulta.Vehiculo) {
                //var Buscar = WSSuperIntenedencia.Busca_Datos_Vehiculo_Motor(
                //    _Poliza,
                //    _Item,
                //    _NombreCliente,
                //    _Numeroidentificacion,
                //    _NombreAsegurado,
                //    _Chasis,
                //    _Placa);
                //if (Buscar.Count() < 1)
                //{
                //    lbCantidadregistrosvariableVehiculomotor.Text = "0";
                //    rpListadoVehiculomotor.DataSource = null;
                //    rpListadoVehiculomotor.DataBind();
                //}
                //else {
                //    int CantidadRegistros = 0;
                //    foreach (var n in Buscar) {
                //        CantidadRegistros = (int)n.CantidadRegistros;
                //    }
                //    lbCantidadregistrosvariableVehiculomotor.Text = CantidadRegistros.ToString("N0");
                //    Paginar(ref rpListadoVehiculomotor, Buscar, 10, ref lbCantidadPaginaVariableVehiculoMotor, ref LinkPrimeraVehiculoMotor, ref LinkAnteriorVehiculoMotor, ref LinkSiguienteVehiculoMotor, ref LinkUltimoVehiculoMotor);
                //    HandlePaging(ref dtPaginacionVehiculoMotor, ref lbPaginaActualVariableVehiculoMotor);
                //}
            }



        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BloquearCOntroles();
                rbBuscarRamoPoliza.Checked = true;
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
                DivBloqueIdentificarRamoPoliza.Visible = true;
               
            }
        }

        protected void rbBuscarRamoPoliza_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBuscarRamoPoliza.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
                DivBloqueIdentificarRamoPoliza.Visible = true;
            }
          
        }

        protected void rbBuscarDatosVehiculoMotor_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosVehiculoMotor.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();

                txtItemControl.Enabled = true;
                txtNombreCLienteControl.Enabled = true;
                txtNumeroIdentificacionControl.Enabled = true;
                txtNombreAseguradoCOntrol.Enabled = true;
                txtChasisControl.Enabled = true;
                txtPlacaControl.Enabled = true;
            }
        }

        protected void rbBuscarDatosFianzas_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosFianzas.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosFidelidad_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosFidelidad.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosIncendioAliadas_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosIncendioAliadas.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosNavesMaritimasAereas_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosNavesMaritimasAereas.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosRamosTecnicos_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosRamosTecnicos.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosSalud_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosSalud.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosTransporteCarga_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosTransporteCarga.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosVidaIndividual_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosVidaIndividual.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosVidaColectivo_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosVidaColectivo.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosOdontologico_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosOdontologico.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosDependientes_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosDependientes.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void gvListadoPantalla_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvListadoPantalla_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (rbBuscarRamoPoliza.Checked == true) { COnsultarRegistros((int)OpcionesConsulta.RamoPoliza); }
            else if (rbBuscarDatosVehiculoMotor.Checked == true) { COnsultarRegistros((int)OpcionesConsulta.Vehiculo); }
            
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {

        }

        protected void btnDetalleVehiculoMotor_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraVehiculoMotor_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            COnsultarRegistros((int)OpcionesConsulta.Vehiculo);
        }

        protected void LinkAnteriorVehiculoMotor_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            COnsultarRegistros((int)OpcionesConsulta.Vehiculo);
            MoverValoresPaginacion((int)OpcionesPaginacionValores.UltimaPagina, ref lbPaginaActualVariableVehiculoMotor, ref lbCantidadPaginaVariableVehiculoMotor);
        }

        protected void dtPaginacionVehiculoMotor_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionVehiculoMotor_CancelCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            COnsultarRegistros((int)OpcionesConsulta.Vehiculo);
        }

        protected void LinkSiguienteVehiculoMotor_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            COnsultarRegistros((int)OpcionesConsulta.Vehiculo);
        }

        protected void LinkUltimoVehiculoMotor_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            COnsultarRegistros((int)OpcionesConsulta.Vehiculo);
            MoverValoresPaginacion((int)OpcionesPaginacionValores.UltimaPagina, ref lbPaginaActualVariableVehiculoMotor, ref lbCantidadPaginaVariableVehiculoMotor);
        }
    }
}