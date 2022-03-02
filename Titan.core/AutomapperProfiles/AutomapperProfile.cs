using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.DTO;
using Titan.DAL.Entities;

namespace Titan.Core.AutomapperProfiles
{
    public class AutomapperProfile : Profile
    {
            public AutomapperProfile()
        {
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<UpdateUsuarioDTO, Usuario>();
            CreateMap<Usuario, UpdateUsuarioDTO>();
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<EmpresaDTO, Empresa>();
            CreateMap<Empresa, EmpresaDTO>();
            CreateMap<EmpresaCreateDTO, Empresa>();
            CreateMap<Empresa, EmpresaCreateDTO>();
            CreateMap<Empresa, EmpresaGetDTO>();
            CreateMap<ProvinciaDTO, Provincia>();
            CreateMap<Provincia, ProvinciaDTO>();
            CreateMap<LoginDTO, Usuario>();
            CreateMap<LoginDTO, Empresa>();
            CreateMap<ProvinciaCriteriaDTO, Provincia >();
            CreateMap<OfferDTO, Offer>();
            CreateMap<Offer, OfferDTO>();
            CreateMap<Inscripciones, InscripcionesDTO>();
            CreateMap<InscripcionesDTO, Inscripciones>();
            CreateMap<FamiliaDTO, Familia>();
            CreateMap<Familia, FamiliaDTO>();
            CreateMap<TipoCicloDTO, TipoCiclo>();
            CreateMap<TipoCiclo, TipoCicloDTO>();
            CreateMap<Ciclo, CicloDTO>();
            CreateMap<CicloDTO, Ciclo>();
            CreateMap<OfertaCicloDTO, OfferEmpresa>();
            CreateMap<OfferEmpresa, OfertaCicloDTO>();
            CreateMap<OfferEmpresa, OfferEmpresaDTO>();
            CreateMap<OfferEmpresaDTO, OfferEmpresa>();


        }
    }
}
