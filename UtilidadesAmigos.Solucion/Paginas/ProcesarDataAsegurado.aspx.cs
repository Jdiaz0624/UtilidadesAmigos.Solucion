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

            var Consulta = (from n in CSVFile
                            let fila = n.Split(',')
                            select new
                            {
                                Nombre=fila[0],
                                Apellido=fila[1],
                                Cedula=fila[2]
                            }).Skip(1);

            //GridView1.DataSource = Consulta;
            //GridView1.DataBind();
        }
    }
}