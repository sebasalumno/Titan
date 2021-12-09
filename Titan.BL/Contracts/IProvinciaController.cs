using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.DTO;

namespace Titan.BL.Contracts
{
    public interface IProvinciaController
    {
        public ProvinciaDTO Get(int id);
    }
}
