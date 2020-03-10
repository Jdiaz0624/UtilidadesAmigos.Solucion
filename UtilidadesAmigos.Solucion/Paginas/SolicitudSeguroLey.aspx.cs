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

        #region CARGAR LOS DROPS
        private void CargarDrops()
        {
            //MOSTRAMOS LAS PROVINCIAS Y LOS MUNICIPIOS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarProdincia, ObjData.BuscaListas("PROVINCIAS", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMunicipio, ObjData.BuscaListas("MUNICIPIOS", ddlSeleccionarProdincia.SelectedValue.ToString(), null));

            //CARGAMOS LOS DROPS CORRESPONDIENTE A LOS TIPOS DE IDENTIFICACION Y LOS TIPOS DE COMPROBANTES
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoIdentificacion, ObjData.BuscaListas("TIPOIDENTIFICACION", null, null));
            txtNumeroIdentificacion.Text = string.Empty;
            int TipoIdentificacionSeleccionado = Convert.ToInt32(ddlSeleccionarTipoIdentificacion.SelectedValue);
            if (TipoIdentificacionSeleccionado == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "MascaraRNC", "MascaraRNC();", true);
            }
            else if (TipoIdentificacionSeleccionado == 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "MascaraCedula", "MascaraCedula();", true);
            }
            else if (TipoIdentificacionSeleccionado == 2)
            {

            }

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoComprobante, ObjData.BuscaListas("TIPOCOMPROBANTE", ddlSeleccionarTipoIdentificacion.SelectedValue.ToString(), null));

            //CARGAMOS LOS DROPS CORRESPONDIENTE A LOS DATOS DEL VEHICULO
            //MARCA
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccioanrMarcas, ObjData.BuscaListas("MARCAVEHICULO", null, null));
            //MODELOS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarModelo, ObjData.BuscaListas("MODELOVEHICULO", ddlSeleccioanrMarcas.SelectedValue.ToString(), null));
            //COLORES
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarColor, ObjData.BuscaListas("COLORVEHICULO", null, null));
            //USO
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarUso, ObjData.BuscaListas("USOVEHICULO", null, null));
        }
        #endregion

        enum Enumeracion
        {
            SeguroLey = 1,
            SeguroFull=2
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try {
                    CargarDrops();
                    lbProductoSeleccionado.Text = Session["ProductoSeleccionado"].ToString();

                    //SACAMOS LOS DATOS DEL PRODUCTO SELECCIONADO

                    var SacarSubRamo = ObjData.SacarDescripcionProducto(
                       1, Convert.ToInt32(lbProductoSeleccionado.Text));
                    foreach (var n in SacarSubRamo)
                    {
                        lbProductoSeleccionadonombre.Text = n.DescripcionSubramo;
                        lbDescripcioNproducto.Text = n.Descripcion;
                    }
                }
                catch (Exception) { }
            }
        }

        protected void brnSiguienteCliente_Click(object sender, EventArgs e)
        {

        }

        protected void btnSiguienteDatosVehiculo_Click(object sender, EventArgs e)
        {

        }

        protected void ddlSeleccionarProdincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMunicipio, ObjData.BuscaListas("MUNICIPIOS", ddlSeleccionarProdincia.SelectedValue.ToString(), null));
        }

        protected void ddlSeleccionarTipoIdentificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumeroIdentificacion.Text = string.Empty;
            int TipoIdentificacionSeleccionado = Convert.ToInt32(ddlSeleccionarTipoIdentificacion.SelectedValue);
            if (TipoIdentificacionSeleccionado == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "MascaraRNC", "MascaraRNC();", true);
            }
            else if (TipoIdentificacionSeleccionado == 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "MascaraCedula", "MascaraCedula();", true);
            }
            else if (TipoIdentificacionSeleccionado == 2)
            {

            }
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoComprobante, ObjData.BuscaListas("TIPOCOMPROBANTE", ddlSeleccionarTipoIdentificacion.SelectedValue.ToString(), null));
        }

        protected void ddlSeleccionarTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlSeleccioanrMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarModelo, ObjData.BuscaListas("MODELOVEHICULO", ddlSeleccioanrMarcas.SelectedValue.ToString(), null));
        }
    }
}