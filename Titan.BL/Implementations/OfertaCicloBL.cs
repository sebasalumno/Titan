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
    public class OfertaCicloBL : IOfertaCicloBL
    {
        public IOfertaCicloRepository OfertaCicloRepository { get; set; }
        public IMapper mapper { get; set; }
        public OfertaCicloBL(IOfertaCicloRepository ofertaCicloRepository,IMapper mapper) 
        {
            this.OfertaCicloRepository = ofertaCicloRepository;
            this.mapper = mapper;

        }

        public List<OfertaCicloDTO> GetCiclo(int id)
        {
            return mapper.Map<List<OfferEmpresa>, List<OfertaCicloDTO>>(OfertaCicloRepository.GetCiclo(id));
        }
    }
}
