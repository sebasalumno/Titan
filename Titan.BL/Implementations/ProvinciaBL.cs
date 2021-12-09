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
    public class ProvinciaBL : IProvinciaBL
    {
        public IProvinciaRepository ProvinciaRepository { get; set; }
        public IMapper mapper { get; set; }
        public ProvinciaBL(IProvinciaRepository provinciaRepository, IMapper mapper)
        {
            this.ProvinciaRepository = provinciaRepository;
            this.mapper = mapper;
        }
        public ProvinciaDTO Get(int id)
        {
            var provincia = ProvinciaRepository.Get(id);

            
            return mapper.Map<Provincia,ProvinciaDTO>(provincia);
        }

        public List<ProvinciaDTO> GetAll()
        {
            var lista = ProvinciaRepository.GetAll();

            return mapper.Map<List<Provincia>, List<ProvinciaDTO>>(lista);
        }

        public List<ProvinciaDTO> Filter(ProvinciaCriteriaDTO criteriaDTO)
        {
            var criteria = mapper.Map<ProvinciaCriteriaDTO, Provincia>(criteriaDTO);

            var search = mapper.Map<List<Provincia>, List<ProvinciaDTO>>(ProvinciaRepository.Filter(criteria));
            return search;
        }
    }
}


