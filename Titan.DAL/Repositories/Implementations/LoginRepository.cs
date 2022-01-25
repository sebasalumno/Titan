using Microsoft.EntityFrameworkCore;
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

        public Empresa Create(Empresa empresa,int codigo)
        {
            empresa.Confirmado = false;
            var u = _context.Empresas.Add(empresa);
            _context.SaveChanges();

            ConfirmacionE conf = new ConfirmacionE
            {
                IdEmpresa = empresa.Id,
                Codigo = codigo
            };

            _context.ConfirmacionesE.Add(conf);

            _context.SaveChanges();
            return u.Entity;
        }
        /*
         * Este metodo comprueba que si existe una empresa en la base de datos
         */
        public bool Exist(Empresa empresa)
        {
            return _context.Empresas.Any(u => u.Email == empresa.Email );
        }

        public Empresa Obtain(int id)
        {
            return _context.Empresas.Include(u => u.Provincia).FirstOrDefault(e => e.Id == id);
        }

        public List<Empresa> ObtainAll()
        {
            return _context.Empresas.ToList();
        }

        public bool Delete(Empresa empresa)
        {
            _context.Empresas.Remove(empresa);
            _context.SaveChanges();
            return true;
            
        }

        public Empresa Update(Empresa empresa)
        {
            var update = _context.Empresas.Update(empresa);
            _context.SaveChanges();
            return update.Entity;

        }

        public Usuario Send(int id)
        {
            var a = _context.Usuarios.FirstOrDefault(i => i.Id == id);
            if (a !=null)
            {
                return a;
            }
            else
            {
                return null;
            }
        }

        public bool Confirmar(string email, int codigo)
        {
            var u = _context.ConfirmacionesE.FirstOrDefault(c => c.Empresa.Email.Equals(email) && c.Codigo == codigo);

            if (u != null)
            {
                var us = _context.Empresas.FirstOrDefault(user => user.Id == u.IdEmpresa);

                us.Confirmado = true;
                _context.Empresas.Update(us);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool Iniciar(string email, int codigo)
        {
            var u = _context.ConfirmacionesE.FirstOrDefault(c => c.Empresa.Email.Equals(email));

            if (u != null)
            {
                u.Codigo = codigo;
                _context.ConfirmacionesE.Update(u);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool Cambiar(string password, int codigo)
        {
            var u = _context.ConfirmacionesE.FirstOrDefault(c => c.Codigo == codigo);
            if(u != null && u.Codigo != 0)
            {
                var emp = _context.Empresas.FirstOrDefault(e => e.Id == u.IdEmpresa);
                emp.Password = password;
                _context.Empresas.Update(emp);
                u.Codigo = 0;
                _context.ConfirmacionesE.Update(u);

                _context.SaveChanges();
                return true;
                
            }
            else { 

            return false; 


                 }
        }
    }
}
