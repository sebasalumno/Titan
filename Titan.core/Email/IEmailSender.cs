
using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.Core.Email
{
   public interface IEmailSender
    {
        void Send(string email,int codigo);
        void Contact(string email,Empresa empresa);
        void Contrasena(string email,int codigo);
    }
}
