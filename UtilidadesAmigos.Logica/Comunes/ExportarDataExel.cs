using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace UtilidadesAmigos.Logica.Comunes
{

   
    public class ExportarDataExel


    {
        public static void exporttoexcel(string filename, object datos)
        {
            GridView gv = new GridView();
            gv.DataSource = datos;
            gv.DataBind();

            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
            HttpContext.Current.Response.ContentType = "applicatio/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm = new HtmlTextWriter(sw);
            gv.RenderControl(htm);
            HttpContext.Current.Response.Write(sw.ToString());
            HttpContext.Current.Response.End();
        }

        public static void ExportarTXT(string NombreArchivo, Object Data)
        {
           // Cadena = n.Oficina + " | " + n.Departamento;
            StreamWriter file = new StreamWriter(@"C:\Users\Ing.Juan Marcelino\Desktop\Sistema\" + NombreArchivo +".txt", true);
            file.WriteLine(Data);
            file.Close();
        }

        public static void ExportarCSV(string NombreArchivo, Object Data)
        {
            // Cadena = n.Oficina + " | " + n.Departamento;
            StreamWriter file = new StreamWriter(@"C:\Users\Ing.Juan Marcelino\Desktop\Sistema\" + NombreArchivo + ".csv", true);
            file.WriteLine(Data);
            file.Close();
        }
    }
}
