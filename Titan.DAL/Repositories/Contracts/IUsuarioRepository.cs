using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.DAL.Repositories.Contracts
{
   public interface IUsuarioRepository
    {
        Usuario Login(Usuario u);
        Usuario Create(Usuario usuario);
        Usuario Obtain(Usuario usuario);
        List<Usuario> ObtainAll();
        bool Delete(Usuario usuario);
        Usuario Update(Usuario usuario);
        bool Exist(Usuario u);
        Usuario GetId(string email);
        Usuario GetUser(int id);
    }
}
