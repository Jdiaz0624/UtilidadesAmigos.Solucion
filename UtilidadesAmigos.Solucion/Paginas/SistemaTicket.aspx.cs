using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class SistemaTicket : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region SACAR LOS DATOS DEL USUARIO
        private void SacarDatousuario(decimal IdUsuario)
        {
            try {
                var SacarDatosUsuario = ObjData.Value.BuscaUsuarios(IdUsuario);
                foreach (var n in SacarDatosUsuario)
                {
                    lbIdUsuarioTicket.Text = n.IdUsuario.ToString();
                    lbUsuarioVariable.Text = n.Persona;
                    lbDepartamentoVariable.Text = n.Departamento;
                    lbTipoVariable.Text = n.TipoPersona;
                }
            }
            catch (Exception) { }
        }
        #endregion
        #region SACAR NUMERO CONECTOR
        private void GenerarNumeroConector()
        {
            try {
                Random Numero = new Random();
                int Generar = Numero.Next(0, 999999999);

                lbNumeroConectorVariable.Text = lbIdUsuarioTicket.Text + Generar.ToString() + DateTime.Now.Second.ToString();
            }
            catch (Exception) { }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SacarDatousuario(Convert.ToDecimal(Session["IdUsuario"]));
                GenerarNumeroConector();
            }
        }

        protected void btnCompletarProceso_Click(object sender, EventArgs e)
        {

        }

        protected void cbAgregarCapture_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAgregarCapture.Checked)
            {
                lbImagenAgregada.Visible = true;
                ImageCaptureTicket.Visible = true;
                lbArchivo.Visible = true;
                fuImagenCapture.Visible = true;
                lbTituloImagen.Visible = true;
                txtTituloImagen.Visible = true;
            }
            else
            {
                lbImagenAgregada.Visible = false;
                ImageCaptureTicket.Visible = false;
                lbArchivo.Visible = false;
                fuImagenCapture.Visible = false;
                lbTituloImagen.Visible = false;
                txtTituloImagen.Visible = false;

            }
        }
    }
}