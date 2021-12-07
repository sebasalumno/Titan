using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.DAL.Repositories.Contracts
{
   public interface ILoginRepository
    {
        Empresa Login(Empresa u);
        Empresa Create(Empresa usuario);
        bool Exist(Empresa u);
    }
}
