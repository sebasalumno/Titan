using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.DAL.Repositories.Contracts
{
   public interface ILoginRepository
    {
        Empresa Login(Empresa empresa);
        Empresa Create(Empresa empresa,int Codigo);
        Empresa Obtain(int number);
        List<Empresa> ObtainAll();
        bool Delete(Empresa empresa);
        Empresa Update(Empresa empresa);
        bool Exist(Empresa u);
        Usuario Send(int id);
        bool Confirmar(string email, int codigo);
        bool Iniciar(string email,int codigo);

        bool Cambiar(string password, int codigo);
    }
}
