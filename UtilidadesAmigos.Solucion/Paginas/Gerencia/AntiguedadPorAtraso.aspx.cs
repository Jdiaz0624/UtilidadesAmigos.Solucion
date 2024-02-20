using System;
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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtSupervisor_Codigo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtIntermediario_Codigo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporte_Click(object sender, ImageClickEventArgs e)
        {
            decimal IdUsuario = (decimal)Session["IdUsuario"];

            var Data = ObjData.Value.ReporteAntiguedadPorAtraso(null, null, null, 106);
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
        }
    }
}