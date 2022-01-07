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
    public class CicloBL : ICicloBL
    {
        public ICicloRepository cicloRepository { get; set; }
        public IMapper mapper { get; set; }
        public CicloBL(ICicloRepository cicloRepository, IMapper mapper)
        {
            this.cicloRepository = cicloRepository;
            this.mapper = mapper;
        }
        public List<CicloDTO> GetAll()
        {
           return  mapper.Map<List<Ciclo>, List<CicloDTO>>(cicloRepository.GetAll());

            
        }
    }
}
