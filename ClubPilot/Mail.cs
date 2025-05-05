using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Net.Mail;
using System;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace ClubPilot
{
    class Mail
    {
        public static void EnviarCorreo(string correoDestino, string asunto, string cuerpo)
        {
            try
            {
                var mensaje = new MimeMessage();
                mensaje.From.Add(new MailboxAddress("ClubPilot", "clubpilotapp@gmail.com"));
                mensaje.To.Add(MailboxAddress.Parse(correoDestino));
                mensaje.Subject = asunto;
                mensaje.Body = new TextPart("plain") { Text = cuerpo };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    smtp.Authenticate("clubpilotapp@gmail.com", "rbjwgomhfsjlunbd"); // contraseña de aplicación
                    smtp.Send(mensaje);
                    smtp.Disconnect(true);
                }

                Console.WriteLine("Correo enviado correctamente con MailKit.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar con MailKit: " + ex.Message);
            }
        }
    }
}
