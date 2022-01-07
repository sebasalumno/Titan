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
    public class TipoCicloBL : ITipoCicloBL
    {

        public ITipoCicloRepository tipoCicloRepository { get; set; }
        public IMapper mapper { get; set; }

        public TipoCicloBL(ITipoCicloRepository tipoCicloRepository, IMapper mapper)
        {
            this.tipoCicloRepository = tipoCicloRepository;
            this.mapper = mapper;
        }

        public List<TipoCicloDTO> GetAll()
        {

            var u = mapper.Map<List<TipoCiclo>, List<TipoCicloDTO>>(tipoCicloRepository.GetAll());

            return u;
        }
    }
}
