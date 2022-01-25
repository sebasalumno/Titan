using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Email.Template
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(string email,string subject,string htmlMessage);
    }
}
