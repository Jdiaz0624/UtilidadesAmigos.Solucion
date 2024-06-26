﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mime;
using System.Net;
using System.Net.Mail;

namespace UtilidadesAmigos.Logica.Comunes
{
    public class EnvioCorreos
    {
        public string Mail { get; set; } //CORREO DESDE DONDE SE ENVIARA
        public string Alias { get; set; } //EL ALIAS
        public string Clave { get; set; } //LA CLAVE DEL CORREO
        public int Puerto { get; set; } //EL PUERTO
        public string smtp { get; set; } //SMTP
        public string Asunto { get; set; } //EL ASUNTO
        public string Cuerpo { get; set; } //EL CUERPO
        public List<string> Destinatarios { get; set; } //EL LISTADO DE TODOS LOS DESTINATARIOS
        public List<string> Adjuntos { get; set; } //EL LISTADO DE TODOS LOS ADJUNTOS
        public string RutaImagen { get; set; } //LA RUTA DE LAS IMAGENES A ENVIAR

        public bool Enviar(EnvioCorreos correo)
        {
            SmtpClient Cliente = new SmtpClient(correo.smtp, correo.Puerto);
            MailMessage Mail = new MailMessage();
            Mail.From = new MailAddress(correo.Mail, correo.Alias);

            Mail.BodyEncoding = System.Text.Encoding.UTF8;
            Mail.IsBodyHtml = true;

            if (!string.IsNullOrEmpty(correo.RutaImagen))
            {
                AlternateView avHTML = AlternateView.CreateAlternateViewFromString(correo.Cuerpo + "<br/><img src=cid:Imagen1>", null, "text/html");
                LinkedResource lr = new LinkedResource(correo.RutaImagen, MediaTypeNames.Image.Jpeg);
                lr.ContentId = "Imagen1";
                avHTML.LinkedResources.Add(lr);
                Mail.AlternateViews.Add(avHTML);
                Mail.Body = lr.ContentId;
            }
            else
            {
                Mail.Body = correo.Cuerpo;
            }

            Mail.Subject = correo.Asunto;
            Mail.SubjectEncoding = System.Text.Encoding.UTF8;

            //AGREGAMOS LOS DESTINATARIOS
            foreach (var Destinos in correo.Destinatarios)
            {
                if (!string.IsNullOrEmpty(Destinos))
                {
                    Mail.Bcc.Add(Destinos);
                }
            }

            //ADJUNTOS
            foreach (var Adjuntos in correo.Adjuntos)
            {
                if (!string.IsNullOrEmpty(Adjuntos))
                {
                    Mail.Attachments.Add(new Attachment(Adjuntos));
                }
            }
            Cliente.Credentials = new NetworkCredential(correo.Mail, correo.Clave);
            Cliente.EnableSsl = true;
            Cliente.Send(Mail);
            return true;
        }
    }
}
