using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using Titan.DAL.Entities;

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



        public void Contact(string email,Empresa empresa )
        {
            var fromAddress = new MailAddress("botseas1@gmail.com", "Equipo de desarrollo");
            var toAddress = new MailAddress(email, "To Name");
            const string fromPassword = "P@ssW0rd";
            const string subject = "Contacto";
            string body = "Bienvenido " + empresa.Name +" se ha puesto en contacto contigo, puedes ponerte en contacto con ellos a traves del siguiente correo : " + empresa.Email ;

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
            const string subject = "Cambio de contraseña";
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
