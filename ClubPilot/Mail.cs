using System;
using System.Net;
using System.Net.Mail;

namespace ClubPilot
{
    class Mail
    {
        public static void EnviarCorreo(string correoDestino, string asunto, string cuerpo)
        {
            try
            {
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress("clubpilotapp@gmail.com", "ClubPilot");
                mensaje.To.Add(correoDestino);
                mensaje.Subject = asunto;
                mensaje.Body = cuerpo;
                mensaje.IsBodyHtml = false; 

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("clubpilotapp@gmail.com", "rbjwgomhfsjlunbd"); 
                smtp.EnableSsl = true;

                smtp.Send(mensaje);

                Console.WriteLine("Correo enviado correctamente con SmtpClient.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar con SmtpClient: " + ex.Message);
            }
        }
    }
}
