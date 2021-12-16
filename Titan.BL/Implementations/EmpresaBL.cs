using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Titan.BL.Contracts;
using Titan.Core.DTO;
using Titan.DAL.Repositories.Contracts;
using Titan.Core.Security;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Implementations;

namespace Titan.BL.Implementations
{
    public class EmpresaBL : IEmpresaBL
    {
        public IPasswordGenerator passwordGenerator { get; set; }
        public ILoginRepository loginRepository { get; set; }
        public IMapper mapper { get; set; }

        public EmpresaBL(ILoginRepository loginRepository, IPasswordGenerator passwordGenerator, IMapper mapper)
        {
            this.loginRepository = loginRepository;
            this.passwordGenerator = passwordGenerator;
            this.mapper = mapper;
        }

        public EmpresaCreateDTO Create(EmpresaCreateDTO loginDTO)
        {
            loginDTO.Password = passwordGenerator.Hash(loginDTO.Password);
            var empresa = mapper.Map<EmpresaCreateDTO, Empresa>(loginDTO);



            if (!loginRepository.Exist(empresa))
            {


                var u = mapper.Map<Empresa, EmpresaCreateDTO>(loginRepository.Create(empresa));
                u.Password = null;
                return u;

            }


            return null;

        }

        public EmpresaDTO Login(LoginDTO loginDTO)
        {
            loginDTO.Password = passwordGenerator.Hash(loginDTO.Password);
            var empresa = mapper.Map<LoginDTO, Empresa>(loginDTO);



            if (loginRepository.Exist(empresa))
            {


                var u = mapper.Map<Empresa, EmpresaDTO>(loginRepository.Create(empresa));
                u.Password = null;
                return u;

            }


            return null;
        }

        public EmpresaGetDTO Obtain(int number)
        {
            var u = mapper.Map<Empresa, EmpresaGetDTO>(loginRepository.Obtain(number));

            return u;
        }
    }
    
}
