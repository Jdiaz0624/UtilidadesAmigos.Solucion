using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class CotizadorAmigos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objdata = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaCotizador.LogicaCotizador> ObjDataCotizador = new Lazy<Logica.Logica.LogicaCotizador.LogicaCotizador>();

        #region CARGAR LOS LAS LISTAS DESPLEGABLES
        private void CargarLosDropPadres()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoCotizador, Objdata.Value.BuscaListas("TIPOCOTIZADOR", null, null), true);
            //UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlImpuesto, Objdata.Value.BuscaListas("IMPUESTO", null, null));
            
        }
        private void CargarDatosTipoCotizador()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlValorVehiculo, Objdata.Value.BuscaListas("VALORVEHICULO", ddlTipoCotizador.SelectedValue, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlAnoVehiculo, Objdata.Value.BuscaListas("ANOVEHICULO", ddlTipoCotizador.SelectedValue, ddlValorVehiculo.SelectedValue), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlCoalicion, Objdata.Value.BuscaListas("COMPRENSIVOINCENDIOROBO", ddlTipoCotizador.SelectedValue, ddlValorVehiculo.SelectedValue, ddlAnoVehiculo.SelectedValue), true);
        }
        private void CargarDatosValorVehiculo()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlAnoVehiculo, Objdata.Value.BuscaListas("ANOVEHICULO", ddlTipoCotizador.SelectedValue, ddlValorVehiculo.SelectedValue), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlCoalicion, Objdata.Value.BuscaListas("COMPRENSIVOINCENDIOROBO", ddlTipoCotizador.SelectedValue, ddlValorVehiculo.SelectedValue, ddlAnoVehiculo.SelectedValue), true);
        }
        private void CargarDatosAnoVehiculo()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlCoalicion, Objdata.Value.BuscaListas("COMPRENSIVOINCENDIOROBO", ddlTipoCotizador.SelectedValue, ddlValorVehiculo.SelectedValue, ddlAnoVehiculo.SelectedValue), true);
        }
        #endregion
        #region VERIFICAR EL PERMISO DE LA COBERTURA
        private void VerificarPermiso()
        {
            decimal TipoCotizacion = 0;
            decimal Contador = 0;
            bool CasaConductor = false;
            bool ServicioGrua = false;
            bool VehiculoRenado = false;
            bool FuturoExequial = false;
            bool AeroAmbulancia = false;

            TipoCotizacion = Convert.ToDecimal(ddlTipoCotizador.SelectedValue);

            for (Contador = 0; Contador <= 5; Contador++)
            {
                var ValidarPermiso = ObjDataCotizador.Value.VerificarTipoCbertura(
                    TipoCotizacion,
                    Contador);
                foreach (var n in ValidarPermiso)
                {
                    if (Contador == 1)
                    {
                        CasaConductor = Convert.ToBoolean(n.TieneAcceso0);
                    }
                    else if (Contador == 2)
                    {
                        ServicioGrua = Convert.ToBoolean(n.TieneAcceso0);
                    }
                    else if (Contador == 3)
                    {
                        VehiculoRenado = Convert.ToBoolean(n.TieneAcceso0);
                    }
                    else if (Contador == 4)
                    {
                        FuturoExequial = Convert.ToBoolean(n.TieneAcceso0);
                    }
                    else if (Contador == 5)
                    {
                        AeroAmbulancia = Convert.ToBoolean(n.TieneAcceso0);
                    }
                }

                //VALIDAMOS LA CASA DEL CONDUCTOR
                if (CasaConductor == true)
                {
                    lbCasaConductorCoiador.Visible = true;
                    txtCasaConductor.Visible = true;
                }
                else
                {
                    lbCasaConductorCoiador.Visible = false;
                    txtCasaConductor.Visible = false;
                }
                //VALIDAMOS EL SERVICIO DE LAS GRUAS
                if (ServicioGrua == true)
                {
                    lbGruaCotizador.Visible = true;
                    txtServicioGrua.Visible = true;
                }
                else
                {
                    lbGruaCotizador.Visible = false;
                    txtServicioGrua.Visible = false;
                }
                //VALIDAMOS LOS SERVICIOS DE VEHICULO RENTADO
                if (VehiculoRenado == true)
                {
                    lbRentaCotizador.Visible = true;
                    txtRentaVehiculo.Visible = true;
                }
                else
                {
                    lbRentaCotizador.Visible = false;
                    txtRentaVehiculo.Visible = false;
                }
                //VALIDAMOS LOS SERVICIOS DE FUTURO EXEQUIAL
                if (FuturoExequial == true)
                {
                    lbFurutoExequial.Visible = true;
                    txtFuturoExequial.Visible = true;
                }
                else
                {
                    lbFurutoExequial.Visible = false;
                    txtFuturoExequial.Visible = false;
                }
                //VALIDAMOS LOS SERVICIOS DE AEROAMBULANCIA
                if (AeroAmbulancia == true)
                {
                    lbAeroAmbulancia.Visible = true;
                    txtAeroAmbulacia.Visible = true;
                }
                else
                {
                    lbAeroAmbulancia.Visible = false;
                    txtAeroAmbulacia.Visible = false;
                }
            }
        }
        #endregion
        #region OCULTAR Y MOSTRAR CONTROLES
        private void OcultarControlesPrincipales()
        {
            lbTipoCotizadorCotizador.Visible = false;
            ddlTipoCotizador.Visible = false;
            lbValorVehiculoCotizador.Visible = false;
            ddlValorVehiculo.Visible = false;
            lbanovehiculoCotizador.Visible = false;
            ddlAnoVehiculo.Visible = false;
            lbImpuestoCotizador.Visible = false;
            txtImpuesto.Visible = false;
            lbIncendioRobo.Visible = false;
            ddlCoalicion.Visible = false;
            lbCasaConductorCoiador.Visible = false;
            txtCasaConductor.Visible = false;
            lbGruaCotizador.Visible = false;
            txtServicioGrua.Visible = false;
            lbRentaCotizador.Visible = false;
            txtRentaVehiculo.Visible = false;
            lbTotal.Visible = false;
            txtTotal.Visible = false;
            //lbPrima.Visible = false;
            //txtPrima.Visible = false;
            btnTipoCotizador.Visible = false;
            btnValorVehiculo.Visible = false;
            btnAnoVehiculo.Visible = false;
            btnImpuesto.Visible = false;
            btnCoalicion.Visible = false;
        }
        private void MostrarControlesPrincipales()
        {
            lbTipoCotizadorCotizador.Visible = true;
            ddlTipoCotizador.Visible = true;
            lbValorVehiculoCotizador.Visible = true;
            ddlValorVehiculo.Visible = true;
            lbanovehiculoCotizador.Visible = true;
            ddlAnoVehiculo.Visible = true;
            lbImpuestoCotizador.Visible = true;
            txtImpuesto.Visible = true;
            lbIncendioRobo.Visible = true;
            ddlCoalicion.Visible = true;
            lbCasaConductorCoiador.Visible = true;
            txtCasaConductor.Visible = true;
            lbGruaCotizador.Visible = true;
            txtServicioGrua.Visible = true;
            lbRentaCotizador.Visible = true;
            txtRentaVehiculo.Visible = true;
            lbTotal.Visible = true;
            txtTotal.Visible = true;
            //lbPrima.Visible = true;
            //txtPrima.Visible = true;
            btnTipoCotizador.Visible = true;
            btnValorVehiculo.Visible = true;
            btnAnoVehiculo.Visible = true;
            btnImpuesto.Visible = true;
            btnCoalicion.Visible = true;
        }
        private void MostrarControlesTipoCotizador()
        {
            //lbEncabezadoTipoCotizador.Visible = true;
            lblabelControlConsulta.Visible = true;
            txtControlBusqueda.Visible = true;
        }
        private void OcultarControlesTipoCotizador()
        {
           // lbEncabezadoTipoCotizador.Visible = false;
            lblabelControlConsulta.Visible = false;
            txtControlBusqueda.Visible = false;
        }
        #endregion
        #region SACAR LOS DATOS FIJOS
        private void SacarServicioFijo(decimal IdServicioFijo)
        {
            bool Impuesto = true, CasaConductor = true, ServicioGrua = true, VehiculoRentado = true, FuturoExequial = true, AeroAmbulancia = true;
            var Sacar = ObjDataCotizador.Value.BuscaServiciosFijos(IdServicioFijo);
            foreach (var n in Sacar)
            {
                txtImpuesto.Text = n.Impuesto.ToString();
                txtCasaConductor.Text = n.CasaConductor.ToString();
                txtServicioGrua.Text = n.ServicioGrua.ToString();
                txtRentaVehiculo.Text = n.VehiculoRentado.ToString();
                txtFuturoExequial.Text = n.FuturoExequial.ToString();
                txtAeroAmbulacia.Text = n.AeroAmbulancia.ToString();
                Impuesto = Convert.ToBoolean(n.ImpuestoFijo0);
                CasaConductor = Convert.ToBoolean(n.CasaConductorFijo0);
                ServicioGrua = Convert.ToBoolean(n.ServicioGruaFijo0);
                VehiculoRentado = Convert.ToBoolean(n.VehiculoRentadoFijo0);
                FuturoExequial = Convert.ToBoolean(n.FuturoExequialFijo0);
                AeroAmbulancia = Convert.ToBoolean(n.AeroAmbulanciaFijo0);
            }
            //VALIDAMOS SI EL IMPUESTO ESTA FIJO
            if (Impuesto == true)
            {
                txtImpuesto.Enabled = false;
            }
            else
            {
                txtImpuesto.Enabled = true;
            }

            //VALIDAMOS SI LA CASA DEL CONDUCTOR ESTA FIJA
            if (CasaConductor == true)
            {
                txtCasaConductor.Enabled = false;
            }
            else
            {
                txtCasaConductor.Enabled = true;
            }

            //VALIDAMOS SI EL SERVICIO DE GRUA STA FIJO
            if (ServicioGrua == true)
            {
                txtServicioGrua.Enabled = false;
            }
            else
            {
                txtServicioGrua.Enabled = true;
            }

            //VALIDAMOS SI EL VEHICULO RENTADO ESTA FIJO
            if (VehiculoRentado == true)
            {
                txtRentaVehiculo.Enabled = false;
            }
            else
            {
                txtRentaVehiculo.Enabled = true;
            }
            //VALIDAMOS SI EL FUTURO EXEQUIAL ESTA FIJO
            if (FuturoExequial == true)
            {
                txtFuturoExequial.Enabled = false;
            }
            else
            {
                txtFuturoExequial.Enabled = true;
            }
            //VALIDAMOS SI AERO AMBULANCIA ESTA FIJO
            if (AeroAmbulancia == true)
            {
                txtAeroAmbulacia.Enabled = false;
            }
            else
            {
                txtAeroAmbulacia.Enabled = true;
            }
        }
        #endregion
        #region CALCULAR
        private void Calcular()
        {
            /*
            SERVICIOS        --> CASA DEL CONDUCTOR + SERVICIO DE GRUA + VEHICULO RENTADO
            PRIMA BRUTA      --> (VALOR DE VEHICULO * (COALICION INCENDIO Y ROBO / IMPUESTO)) + SERVICIOS
            IMPUESTO         --> PRIMA BRUTA * IMPUESTO
            TOTAL            --> PRIMA BRUTA + IMPUESTO

            * */

            try
            {

                //CALCULAMOS LOS SERVICIOS
                decimal CasaConductor = 0, ServicioGrua = 0, VehiculoRentado = 0, FuturoExequial = 0, Aeroambulancia = 0, TotalServicios;

                switch (txtCasaConductor.Visible)
                {
                    case true:
                        CasaConductor = Convert.ToDecimal(txtCasaConductor.Text);
                        break;
                    case false:
                        CasaConductor = 0;
                        break;
                }

                switch (txtServicioGrua.Visible)
                {
                    case true:
                        ServicioGrua = Convert.ToDecimal(txtServicioGrua.Text);
                        break;
                    case false:
                        ServicioGrua = 0;
                        break;
                }
                switch (txtRentaVehiculo.Visible)
                {
                    case true:
                        VehiculoRentado = Convert.ToDecimal(txtRentaVehiculo.Text);
                        break;
                    case false:
                        VehiculoRentado = 0;
                        break;
                }
                switch (txtFuturoExequial.Visible)
                {
                    case true:
                        FuturoExequial = Convert.ToDecimal(txtFuturoExequial.Text);
                        break;
                    case false:
                        FuturoExequial = 0;
                        break;
                }
                switch (txtAeroAmbulacia.Visible)
                {
                    case true:
                        Aeroambulancia = Convert.ToDecimal(txtAeroAmbulacia.Text);
                        break;
                    case false:
                        Aeroambulancia = 0;
                        break;
                }
                TotalServicios = CasaConductor + ServicioGrua + VehiculoRentado + FuturoExequial + Aeroambulancia;
                txtServicios.Text = TotalServicios.ToString();

                //CALCULAMOS EL TOTAL
                decimal ValorVehiculo = 0, Coalicion = 0, CoalicionConvertido = 0, Impusto = 0, Total;

                ValorVehiculo = Convert.ToDecimal(ddlValorVehiculo.SelectedItem.Text);
                Coalicion = Convert.ToDecimal(ddlCoalicion.SelectedItem.Text);
                CoalicionConvertido = Coalicion / 100;
                Impusto = Convert.ToDecimal(txtImpuesto.Text);

                Total = (ValorVehiculo * CoalicionConvertido) * (Impusto) + TotalServicios;

                txtTotal.Text = Math.Round(Total, 2).ToString();



            }
            catch (Exception)
            {
                txtTotal.Text = string.Empty;
                txtTotal.Text = "0";
                txtServicios.Text = string.Empty;
                txtServicios.Text = "0";
            }

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                //CARGAMOS EL TIPO DE COTIZADOR
                CargarLosDropPadres();
                CargarDatosTipoCotizador();
                SacarServicioFijo(1);
    
            }
        }

        protected void ddlTipoCotizador_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarPermiso();
            CargarDatosTipoCotizador();
            Calcular();
        }

        protected void btnTipoCotizador_Click(object sender, EventArgs e)
        {

        }

        protected void btnValorVehiculo_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>window.open('Login.aspx','popup','width=800,height=500') </script>");


            string vtn = "window.open('ValorVehiculo.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }

        protected void cbRefrescar_CheckedChanged(object sender, EventArgs e)
        {
            ddlTipoCotizador.AutoPostBack = true;
        }

        protected void btnRefrescar_Click(object sender, EventArgs e)
        {
            try {
                string vtn = "window.open('prueba.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
            }
            catch (Exception) { }
        }

        protected void ddlValorVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosValorVehiculo();
            Calcular();
            //var CargarPrueba = Objdata.Value.BuscaListas(
            //    "",
            //    ddlTipoCotizador.SelectedValue,
            //    ddlValorVehiculo.SelectedValue);
            //ddlAnoVehiculo.DataSource = CargarPrueba;
            //ddlAnoVehiculo.DataValueField = "IdAnoVehiculo";
            //ddlAnoVehiculo.DataTextField = "AnoVehiculo";
            //ddlAnoVehiculo.DataBind();
        }

        protected void btnAnoVehiculo_Click(object sender, EventArgs e)
        {
            string vtn = "window.open('AnoVehiculo.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }

        protected void ddlAnoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosAnoVehiculo();
            Calcular();
        }

        protected void btnImpuesto_Click(object sender, EventArgs e)
        {
            string vtn = "window.open('ServiciosFijos.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }

        protected void btnCoalicion_Click(object sender, EventArgs e)
        {
            string vtn = "window.open('ComprensivoIncendioRoboPoPup.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnCotizar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlCoalicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calcular();
        }
    }
}