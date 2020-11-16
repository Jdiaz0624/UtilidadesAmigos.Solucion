using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes
{
    public static class SeguridadEncriptacion
    {
        /// <summary>
        /// Este metodo es para encriptar una cadena
        /// </summary>
        /// <param name="_cadenaAencriptar"></param>
        /// <returns></returns>
        public static string Encriptar(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// <summary>
        /// Este metodo es para desifrar una cadena de texto.
        /// </summary>
        /// <param name="_cadenaAdesencriptar"></param>
        /// <returns></returns>
        public static string DesEncriptar(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}
