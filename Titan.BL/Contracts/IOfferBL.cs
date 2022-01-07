using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.DTO;

namespace Titan.BL.Contracts
{
    public interface IOfferBL
    {
        public OfferDTO Create(OfferDTO offer);
        public List<OfferDTO> Get(int id);

        public List<OfferDTO> GetAll();

        public bool Delete(int Id);

        public OfferDTO Update(OfferDTO offer);

        public List<OfferDTO> Activas(DateTime date);
        public List<OfferDTO> SearchNombre(string nombre);
    }
}
