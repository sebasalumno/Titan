﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.DAL.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public pitufoContext _context { get; set; }
        public UsuarioRepository(pitufoContext context)
        {
            this._context = context;

        }
        /*
         * Este metodo comprueba si el usuario existe en la bd y coge el primero que cumple los requisitos
         */
        public Usuario Login(Usuario usuario)
        {
            if(usuario.Confirmado == true)
            {
                return _context.Usuarios.Include(u => u.Provincia).FirstOrDefault(u => u.Email == usuario.Email && u.Password == usuario.Password);
            }

            return null;
            
        }

        /*
         * Este metodo inserta en la base de datos el nuevo usuario que se quiere crear
         */
        public Usuario Create(Usuario usuario,int codigo)
        {
           usuario.Confirmado = false;
           var u =  _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            Confirmacion conf = new Confirmacion
            {
                IdUsuario = usuario.Id,
                Codigo = codigo
            };

            _context.Confirmaciones.Add(conf);

            _context.SaveChanges();
            return u.Entity;
        }
        /*
         * Este metodo comprueba que si existe un usuario en la base de datos
         */
        public bool Exist(Usuario usuario)
        {
            return _context.Usuarios.Any(u => u.Email == usuario.Email );
        }

        public Usuario Obtain(Usuario usuario)
        {
            return _context.Usuarios.FirstOrDefault(e => e.Id == usuario.Id);
        }

        public List<Usuario> ObtainAll()
        {
            return _context.Usuarios.ToList();
        }

        public bool Delete(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return true;
        }

        public Usuario Update(Usuario usuario)
        {
            var update = _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            return update.Entity;
        }

        public Usuario GetId(string email)
        {
            var a = _context.Usuarios.FirstOrDefault(e => e.Email.Equals(email));
            return a;
        }
        
        public Usuario GetUser(int id)
        {
            var a = _context.Usuarios.FirstOrDefault(e => e.Id == id);
            return a;
        }

        public bool Confirmacion(string email, int codigo)
        {
            var u = _context.Confirmaciones.FirstOrDefault(c => c.Usuario.Email.Equals(email) && c.Codigo == codigo);

            if(u != null)
            {
                var us = _context.Usuarios.FirstOrDefault(user => user.Id == u.IdUsuario);

                us.Confirmado = true;
                _context.Usuarios.Update(us);
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
            var u = _context.Confirmaciones.FirstOrDefault(c => c.Usuario.Email.Equals(email));

            if (u != null)
            {
                u.Codigo = codigo;
                _context.Confirmaciones.Update(u);
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
            var u = _context.Confirmaciones.FirstOrDefault(c => c.Codigo == codigo);
            if (u != null && u.Codigo != 0)
            {
                var us = _context.Usuarios.FirstOrDefault(e => e.Id == u.IdUsuario);
                us.Password = password;
                _context.Usuarios.Update(us);
                u.Codigo = 0;
                _context.Confirmaciones.Update(u);

                _context.SaveChanges();
                return true;

            }
            else
            {

                return false;


            }
        }

        }
}
