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
    public class InscripcionesBL : IInscripcionesBL
    {
        public IInscripcionesRepository inscripcionesRepository { get; set; }
        public IMapper mapper { get; set; }
        public InscripcionesBL(IInscripcionesRepository inscripcionesRepository, IMapper mapper)
        {
            this.inscripcionesRepository = inscripcionesRepository;
            this.mapper = mapper;
        }
        public InscripcionesDTO Create(InscripcionesDTO inscripcionDTO)
        {
            var inscripcion = mapper.Map<InscripcionesDTO, Inscripciones>(inscripcionDTO);
            var inscDTO = mapper.Map<Inscripciones, InscripcionesDTO>(inscripcionesRepository.Create(inscripcion));
            return inscDTO;
        }

        public List<InscripcionesDTO> GetAll()
        {
            var lista = inscripcionesRepository.GetAll();
            var ret = mapper.Map<List<Inscripciones>, List<InscripcionesDTO>>(lista);
            return ret;

        }

        public List<InscripcionesDTO> SearchEmpresas(int id)
        {
            var lista = inscripcionesRepository.SearchEmpresas(id);
            var ret = mapper.Map<List<Inscripciones>, List<InscripcionesDTO>>(lista);
            return ret;
        }

        public List<InscripcionesDTO> SearchFamilias(string Familia)
        {
            var lista = inscripcionesRepository.SearchFamilias(Familia);
            var ret = mapper.Map<List<Inscripciones>, List<InscripcionesDTO>>(lista);
            return ret;
        }
    }
}
