using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.DTO;

namespace Titan.BL.Contracts
{
    public interface IOfferBL
    {
        public OfferDTO Create(OfferDTO offer);
        public OfferDTO Get(OfferDTO offer);

        public List<OfferDTO> GetAll();

        public bool Delete(OfferDTO offer);

        public OfferDTO Update(OfferDTO offer);
    }
}
