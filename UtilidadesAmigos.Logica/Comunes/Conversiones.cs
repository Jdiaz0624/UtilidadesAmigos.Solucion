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
    public class Conversiones
    {
        public static double IsDoubleReturnDouble(string valor)
        {
            double v = 0;
            var res = double.TryParse(valor.Replace(",", ""), out v);
            //var res = double.TryParse(valor, NumberStyles.Any, new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["NumberLanguage"]), out v);
            if (res)
                return double.Parse(valor.Replace(",", ""), CultureInfo.InvariantCulture);
            else
                return 0;

        }
        public static decimal IsDecimalReturnDecimal(string valor)
        {
            decimal v = 0;
            var res = decimal.TryParse(valor.Replace(",", ""), out v);
            //var res = Decimal.TryParse(valor, NumberStyles.Any, new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["NumberLanguage"]), out v);
            if (res)
                return decimal.Parse(valor.Replace(",", ""), CultureInfo.InvariantCulture);
            else
                return 0;

        }
        public static int IsIntReturnInt(string valor)
        {
            int v = 0;
            var res = int.TryParse(valor.Replace(",", ""), out v);
            //var res = int.TryParse(valor, NumberStyles.Any, new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["NumberLanguage"]), out v);
            if (res)
                return v;
            else
                return 0;

        }
        public static short IsShortReturnShort(string valor)
        {
            short v = 0;
            var res = short.TryParse(valor.Replace(",", ""), out v);
            if (res)
                return v;
            else
                return 0;
        }
        public static long IsLongReturLong(string valor)
        {
            long v = 0;
            var res = long.TryParse(valor.Replace(",", ""), out v);
            //var res = long.TryParse(valor, NumberStyles.Any, new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["NumberLanguage"]), out v);
            if (res)
                return v;
            else
                return 0;

        }
        public static DateTime? IsDateReturnDate(string valor)
        {
            DateTime v;
            var res = DateTime.TryParse(valor.Replace(",", ""), out v);
            //var res = DateTime.TryParse(valor, new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["NumberLanguage"]), DateTimeStyles.None, out v);
            if (res)
                return v;
            else
                return new Nullable<DateTime>();

        }
    }
}
