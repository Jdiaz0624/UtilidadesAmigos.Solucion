using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ProcesarDataAsegurado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscarRuta_Click(object sender, EventArgs e)
        {
            var CSVFile = File.ReadAllLines(Server.MapPath(@"ASE_AMSEG_NEW_20200805.csv"));
          //  var CSVFile = File.ReadAllLines(System.Web.ht Server.MapPath(@"~C:\Users\Ing. Juan Marcelino\Desktop\Archivo\ASE_AMSEG_NEW_20200805.csv"));
            var Consulta = (from n in CSVFile
                            let fila = n.Split(',')
                            select new
                            {
                                nombres = fila[0],
                                apellidos = fila[1],
                                poliza = fila[18],
                                fechaInicial = fila[19],
                                fechaFinal = fila[20],
                                prima = fila[22],
                                id = fila[24]
                            }).Skip(1);

            gvDataAsegurado.DataSource = Consulta;
            gvDataAsegurado.DataBind();
        }

        protected void gvAsegurado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvAsegurado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvDataAsegurado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvDataAsegurado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}