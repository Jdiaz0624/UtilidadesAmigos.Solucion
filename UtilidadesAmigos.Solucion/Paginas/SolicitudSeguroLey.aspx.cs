using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class SolicitudSeguroLey : System.Web.UI.Page
    {
        UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.Logica.LogicaSistema();

        enum TipoIdentificacionMascaras {
            RNC = 0,
            Cedula = 1,
            Pasaporte =2
        }
        #region GENERAR EL NUMERO DE SOLICITUD
        private void GenerarNumeroSolicitud()
        {
            Random Numero = new Random();
            int Aleatorio = Numero.Next(0, 999999999);
            lbNumeroSolicitudVariable.Text = Aleatorio.ToString();
        }
        #endregion
        #region CARGAR LOS DROP DE LA PARTE DEL CLIENTE
        private void CargarDropsCliente()
        {
            //CARGAMOS EL TIPO DE IDENTIFICACION
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoIdentificacion, ObjData.BuscaListas("TIPOIDENTIFICACION", null, null));
            DefinirMarcara();
            //CARGAMOS LOS TIPOS DE COMPROBANTES
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoComprobante,ObjData.BuscaListas("TIPOCOMPROBANTE",ddlSeleccionarTipoIdentificacion.SelectedValue.ToString(),null));
            //CARGAMOS LOS SEXOS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSexo, ObjData.BuscaListas("SEXO", null, null));
            //CARGAMOS LOS ESTADOS CIVILES
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarEstadoCivil, ObjData.BuscaListas("ESTADOCIVIL", null, null));
            //CARGAMOS LAS PROVINCIAS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarProvincia, ObjData.BuscaListas("PROVINCIAS", null, null));
            //CARGAMOS LOS MINICIPIOS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMunicipio, ObjData.BuscaListas("MUNICIPIOS", ddlSeleccionarProvincia.SelectedValue.ToString(), null));
        }
        #endregion
        #region DEFINIMOS EL TIPO DE IDENTIFICACION PARA SELECCIONAR LA MASCARA CORRESPONDIENTE
        private void DefinirMarcara()
        {
            int TipoIdentificacionSeleccionado = Convert.ToInt32(ddlSeleccionarTipoIdentificacion.SelectedValue);

            if (TipoIdentificacionSeleccionado == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "MascaraRnc", "MascaraRnc();", true);
            }
            else if (TipoIdentificacionSeleccionado == 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "MascaraCedula", "MascaraCedula();", true);
            }
            else if (TipoIdentificacionSeleccionado == 2)
            {

            }
        }
        #endregion
        #region SACAR LOS DATOS DEL INTERMEDIARIO Y DE COBRADOR
        private void SacarDatosIntermediario(string CodigoIntermediario)
        {
            var SacarDatos = ObjData.SacarDatosIntermediarios(
                null,
                CodigoIntermediario);
            if (SacarDatos.Count() < 1)
            {
                lbCodigoIntermediario.Text = "Codigo de Vendedor";
            }
            else
            {
                foreach (var n in SacarDatos)
                {
                    lbCodigoIntermediario.Text = "Codigo de Vendedor ( " + n.Codigo + " - " + n.NombreVendedor + " )";
                }
            }
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }
        private void SacarDatosCobrador(decimal CodigoCobrador)
        {
            var SacarNombre = ObjData.SacarNombreCobrador(CodigoCobrador);
            if (SacarNombre.Count() < 1)
            {
                lbCodigoCobrador.Text = "Codigo de Cobrador";
            }
            else
            {
                foreach (var n in SacarNombre)
                {
                    lbCodigoCobrador.Text = "Codigo de Cobrador ( " + txtCodigoCobrador.Text + " - " + n.NombreCobrador + " )";
                }
            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
                GenerarNumeroSolicitud();
                CargarDropsCliente();
            }
        }

        protected void ddlSeleccionarTipoIdentificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefinirMarcara();
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoComprobante, ObjData.BuscaListas("TIPOCOMPROBANTE", ddlSeleccionarTipoIdentificacion.SelectedValue.ToString(), null));
        }

        protected void ddlSeleccionarProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMunicipio, ObjData.BuscaListas("MUNICIPIOS", ddlSeleccionarProvincia.SelectedValue.ToString(), null));
        }

        protected void btnSiguienteCliente_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "DesbloquearControles", "DesbloquearControles();", true);
        }

        protected void ddlSeleccionarMarcavehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            SacarDatosIntermediario(txtCodigoIntermediario.Text);
        }

        protected void txtCodigoCobrador_TextChanged(object sender, EventArgs e)
        {
            SacarDatosCobrador(Convert.ToDecimal(txtCodigoCobrador.Text));
        }
    }
}