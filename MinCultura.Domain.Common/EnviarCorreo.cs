using MinCultura.Domain.Common.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MinCultura.Domain.Common
{
    public class EnviarCorreo
    {

        private readonly ConexionEnvioCorreo conexion;

        /// <summary>
        /// Constructor del servicio
        /// </summary>
        /// <param name="configuration"></param>
        public EnviarCorreo(ConexionEnvioCorreo configuration)
        {
            conexion = configuration;
        }

        /// <summary>
        /// Enviar un correo electrónico
        /// </summary>
        /// <param name="destinatario"></param>
        /// <param name="asunto"></param>
        /// <param name="cuerpo"></param>
        /// <returns></returns>
        public bool EnviarCorreoElectronico(string destinatario, string asunto, string cuerpo, string pathSaveReport, ICollection<AdjuntoCorreoDto> adjuntoCorreo)
        {
            try
            {
                string rutaCompleta = string.Empty;
                using (var message = new MailMessage())
                {
                    var fromAddress = new MailAddress(conexion.FromAddress, conexion.FromName, Encoding.UTF8);
                    foreach (var correo in destinatario.Split(','))
                    {
                        message.To.Add(new MailAddress(correo));
                    }
                    message.From = fromAddress;
                    message.Subject = asunto;
                    message.Body = cuerpo;
                    message.IsBodyHtml = true;

                    foreach(var adj in adjuntoCorreo)
                    {
                        rutaCompleta = string.Format("{0}{1}{2}", pathSaveReport, adj.RutaAdjunto, adj.NombreAdjunto);
                        if (File.Exists(rutaCompleta))
                            message.Attachments.Add(new Attachment(rutaCompleta));
                    }

                    using (var smtp = new SmtpClient(conexion.Host, conexion.Port))
                    {
                        smtp.Credentials = new NetworkCredential(fromAddress.Address, conexion.FromPassword);
                        smtp.EnableSsl = true;
                        smtp.Send(message);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

    }
}
