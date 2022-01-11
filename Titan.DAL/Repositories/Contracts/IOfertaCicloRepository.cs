using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.DAL.Repositories.Contracts
{
    public interface IOfertaCicloRepository
    {
        public List<OfferEmpresa> GetCiclo(int id);

    }
}
