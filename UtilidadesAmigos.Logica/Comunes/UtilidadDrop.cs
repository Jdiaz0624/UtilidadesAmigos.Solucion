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
    public class UtilidadDrop
    {
        public static void DropDownListSeleccionar(ref DropDownList drop, string valor)
        {
            var Index = drop.Items.IndexOf(drop.Items.FindByValue(valor));
            if (Index != null)
                drop.SelectedIndex = Index;
        }

        public static void DropDownListLlena(ref DropDownList drop, object lista, bool AgregarTexto = false, string texto = "")
        {
            drop.DataSource = lista;
            drop.DataTextField = "Descripcion";
            drop.DataValueField = "PrimerValor";
            drop.DataBind();

            if (AgregarTexto == true)
            {
                if (texto != string.Empty)
                    drop.Items.Insert(0, new ListItem(texto, "-1"));
                else
                    drop.Items.Insert(0, new ListItem(HttpContext.GetGlobalResourceObject("Traducciones", "NoFiltrar").ToString(), "-1"));
            }
        }
    }
}
