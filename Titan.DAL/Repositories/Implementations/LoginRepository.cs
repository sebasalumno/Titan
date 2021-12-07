using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.DAL.Repositories.Implementations
{
   public class LoginRepository : ILoginRepository
    {
        public pitufoContext _context { get; set; }
        public LoginRepository(pitufoContext context)
        {
            this._context = context;

        }

        public Empresa Login(Empresa empresa)
        {
            return _context.Empresas.FirstOrDefault(u => u.Email == empresa.Email && u.Password == empresa.Password);

        }

        public Empresa Create(Empresa empresa)
        {
            var u = _context.Empresas.Add(empresa);
            _context.SaveChanges();
            return u.Entity;
        }
        /*
         * Este metodo comprueba que si existe una empresa en la base de datos
         */
        public bool Exist(Empresa empresa)
        {
            return _context.Empresas.Any(u => u.Email == empresa.Email || u.Name == empresa.Name);
        }


    }
}
