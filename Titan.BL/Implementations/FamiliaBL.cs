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
    public class FamiliaBL : IFamiliaBL
    {
        public IFamiliaRepository familiaRepository { get; set; }
        public IMapper mapper { get; set; }

        public FamiliaBL(IFamiliaRepository familiaRepository, IMapper mapper)
        {
            this.familiaRepository = familiaRepository;
            this.mapper = mapper;
        }


        public List<FamiliaDTO> GetAll()
        {
            var u = mapper.Map<List<Familia>, List<FamiliaDTO>>(familiaRepository.GetAll());
            return u;
        }
    }
}
