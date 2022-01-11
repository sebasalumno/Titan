using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.DTO;

namespace Titan.BL.Contracts
{
    public interface IOfertaCicloBL
    {
        public List<OfertaCicloDTO> GetCiclo(int id);

    }
}
