using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.DAL.Repositories.Contracts
{
    public interface ICicloRepository
    {
        List<Ciclo> GetAll();
    }
}
