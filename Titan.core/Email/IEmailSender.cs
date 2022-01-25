
using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Core.Email
{
   public interface IEmailSender
    {
        void Send(string email,int codigo);
        void Contact(string email);
        void Contrasena(string email,int codigo);
    }
}
