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

        public bool EnviarCorreo(string CorreoOrigen, string ClaveCorreo, string CorreoDestino, string Cuerpo, string Notificacion)
        {
            try {
                Mensaje.From = new MailAddress(CorreoOrigen);
                Mensaje.Bcc.Add(new MailAddress(CorreoDestino));
                Mensaje.Subject = "Utilidades Amigos (" + Notificacion + ")";
             //   string filename = @"C:\Users\Ing.Juan Marcelino\Pictures\Parte de Alante.jpg";
             //   Mensaje.Attachments.Add(new Attachment(filename));
                Mensaje.Body = Cuerpo;
           

                smtp.Host= "smtp.live.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(CorreoOrigen, ClaveCorreo);
                smtp.EnableSsl = true;
            //    smtp.Timeout = 999999999;
                smtp.Send(Mensaje);
                Mensaje.Bcc.Clear();
                return true; 
                
            }
            catch (Exception) {
                return false;
            }
        }
    }
}
