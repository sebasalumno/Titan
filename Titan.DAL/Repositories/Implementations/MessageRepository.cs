using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.DAL.Repositories.Implementations
{


    public class MessageRepository : IMessageRepository
    {
        public pitufoContext _context { get; set; }
        public MessageRepository(pitufoContext context)
        {
            this._context = context;

        }
        public bool Contact(Mensaje mensaje)
        {
            var c = _context.Mensajes.Add(mensaje);
            _context.SaveChanges();
            if (c != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
