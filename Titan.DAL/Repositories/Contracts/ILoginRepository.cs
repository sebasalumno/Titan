using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.DAL.Repositories.Contracts
{
   public interface ILoginRepository
    {
        Empresa Login(Empresa empresa);
        Empresa GetId(Empresa empresa);
        Empresa Create(Empresa empresa,int Codigo);
        Empresa Obtain(int number);
        List<Empresa> ObtainAll();
        bool Delete(Empresa empresa);
        Empresa Update(Empresa empresa);
        bool Exist(Empresa u);
        Usuario Send(int id);
        bool Confirmar(string email, int codigo);
        Empresa Iniciar(int id,int codigo);

        bool Cambiar(string password, int codigo);
        Empresa Get(String stripeId);
        string PosiblePagoCancelacion(PaymentIntent paymentIntent);

        string PagoSuccess(Invoice invoice);
        
    }
}
