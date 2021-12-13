using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Titan.BL.Contracts;
using Titan.Core.DTO;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.BL.Implementations
{
    public class OfferBL : IOfferBL
    {
        public IOfferRepository offerRepository { get; set; }
        public IMapper mapper { get; set; }

        public OfferBL(IOfferRepository offerRepository, IMapper mapper)
        {
            this.offerRepository = offerRepository;
            this.mapper = mapper;
        }
        public OfferDTO Create(OfferDTO offer)
        {
            var offerC = mapper.Map<OfferDTO, Offer>(offer);

            if (!offerRepository.Exist(offerC))
            {


                var u = mapper.Map<Offer, OfferDTO>(offerRepository.Create(offerC));

                return u;

            }


            return null;
        }

        public OfferDTO Get(OfferDTO offer)
        {
            var offerC = mapper.Map<OfferDTO, Offer>(offer);
            if (!offerRepository.Exist(offerC))
            {


                var u = mapper.Map<Offer, OfferDTO>(offerRepository.Obtain(offerC));

                return u;

            }


            return null;
        }

        public List<OfferDTO> GetAll()
        {

            var u = mapper.Map<List<Offer>, List<OfferDTO>>(offerRepository.ObtainAll());
            return u;
        }

        public bool Delete(OfferDTO offer)
        {
            var offerC = mapper.Map<OfferDTO, Offer>(offer);

            if (offerRepository.Exist(offerC))
            {


                var result = offerRepository.Delete(offerC);

                return result;

            }
            return false;
        }

        public OfferDTO Update(OfferDTO offer)
        {
            var offerC = mapper.Map<OfferDTO, Offer>(offer);

            if (offerRepository.Exist(offerC))
            {



                var u = mapper.Map<Offer, OfferDTO>(offerRepository.Update(offerC));


                return u;

            }
            return null;
        }
    }


}
