using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace UtilidadesAmigos.Logica.Comunes
{
    public class Mail
    {
        MailMessage Mensaje = new MailMessage();
        SmtpClient smtp = new SmtpClient();

        public bool EnviarCorreo(string CorreoOrigen, string ClaveCorreo, string CorreoDestino, string Cuerpo)
        {
            try {
                Mensaje.From = new MailAddress(CorreoOrigen);
                Mensaje.To.Add(new MailAddress(CorreoDestino));
                Mensaje.Subject = "Veronica - Utilidades Amigos";
                Mensaje.Body = Cuerpo;

                smtp.Host="smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(CorreoOrigen, ClaveCorreo);
                smtp.EnableSsl = true;
                smtp.Send(Mensaje);
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
    }
}
