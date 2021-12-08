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
            return _context.Usuarios.FirstOrDefault(u => u.Email == usuario.Email && u.Password == usuario.Password);
            
        }

        /*
         * Este metodo inserta en la base de datos el nuevo usuario que se quiere crear
         */
        public Usuario Create(Usuario usuario)
        {
           var u =  _context.Usuarios.Add(usuario);
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
    }
}
