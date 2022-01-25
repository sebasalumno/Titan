using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Titan.Core.Email
{
    public class EmailSender : IEmailSender
    {
        public void Send(string email,int codigo)
        {
            var fromAddress = new MailAddress("botseas1@gmail.com", "Equipo de desarrollo");
            var toAddress = new MailAddress(email, "To Name");
            const string fromPassword = "P@ssW0rd";
            const string subject = "Hola";
             string body = "Bienvenido!!!" + " Su codigo de confirmacion es :" + codigo ;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }



        public void Contact(string email )
        {
            var fromAddress = new MailAddress("botseas1@gmail.com", "Equipo de desarrollo");
            var toAddress = new MailAddress(email, "To Name");
            const string fromPassword = "P@ssW0rd";
            const string subject = "Hola";
            string body = "Bienvenido" ;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        public void Contrasena(string email ,int codigo)
        {
            var fromAddress = new MailAddress("botseas1@gmail.com", "Equipo de desarrollo");
            var toAddress = new MailAddress(email, "To Name");
            const string fromPassword = "P@ssW0rd";
            const string subject = "Hola";
            string body = "Ha pedido cambiar su contraseña. Puede usar el siguiente codigo : " + codigo;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
