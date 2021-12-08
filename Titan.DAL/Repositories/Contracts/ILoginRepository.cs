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
        Empresa Obtain(Empresa empresa);
        List<Empresa> ObtainAll();
        bool Delete(Empresa empresa);
        Empresa Update(Empresa empresa);
        bool Exist(Empresa u);
    }
}
