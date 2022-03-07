using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.DAL.Repositories.Contracts
{
    public interface IContratoRepository
    {
        Contrato Get(int empresaid);
       
        void Update(Contrato contrato);
        Contrato Baja(int empresaid);
    }
}
