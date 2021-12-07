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
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<LoginDTO, Empresa>();
            CreateMap<Empresa, LoginDTO>();
        }
    }
}
