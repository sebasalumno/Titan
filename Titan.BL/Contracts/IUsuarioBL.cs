using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.DTO;

namespace Titan.BL.Contracts
{
    public interface IUsuarioBL
    {

        public UsuarioDTO Login(LoginDTO loginDTO);
        public UsuarioDTO Create(UsuarioDTO usuarioDTO);
        public UsuarioDTO GetId(string email);
        public UsuarioDTO GetUser(int id);
        public bool Confirmar(string email,int codigo);
        public bool Iniciar(int id);
        public bool Cambiar(string password, int codigo);

        public bool Update(UpdateUsuarioDTO update);

    }
}
