﻿using AutoMapper;
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
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<EmpresaDTO, Empresa>();
            CreateMap<Empresa, EmpresaDTO>();
            CreateMap<ProvinciaDTO, Provincia>();
            CreateMap<Provincia, ProvinciaDTO>();
            CreateMap<LoginDTO, Usuario>();
            CreateMap<LoginDTO, Empresa>();
            CreateMap<ProvinciaCriteriaDTO, Provincia >();
            CreateMap<OfferDTO, Offer>();
            CreateMap<Offer, OfferDTO>();

        }
    }
}
