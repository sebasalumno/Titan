    using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.Core.Security
{
    public interface IJwtBearer
    {

        public string GenerateJWTToken(Usuario usuario);
        public string GenerateJWTTokenEmpresa(Empresa empresa);

        public int GetUsuarioIdFromToken(string token);
    }
}
