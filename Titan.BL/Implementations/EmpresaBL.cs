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
using Titan.Core.Email;

namespace Titan.BL.Implementations
{
    public class EmpresaBL : IEmpresaBL
    {
        public IPasswordGenerator passwordGenerator { get; set; }

        public ILoginRepository loginRepository { get; set; }
        public IMessageRepository messageRepository { get; set; }
        public IMapper mapper { get; set; }
        public IEmailSender emailSender { get; set; }

        public EmpresaBL(ILoginRepository loginRepository, IPasswordGenerator passwordGenerator, IMapper mapper, IEmailSender emailSender, IMessageRepository messageRepository)
        {
            this.loginRepository = loginRepository;
            this.passwordGenerator = passwordGenerator;
            this.mapper = mapper;
            this.emailSender = emailSender;
            this.messageRepository = messageRepository;
        }

        public EmpresaCreateDTO Create(EmpresaCreateDTO loginDTO)
        {
            Random num = new Random();
            int a = num.Next(1, 10);
            int b = num.Next(1, 10);
            int c = num.Next(1, 10);
            int d = num.Next(1, 10);
            string codigo = a + "" + b + "" + c + "" + d;
            loginDTO.Password = passwordGenerator.Hash(loginDTO.Password);
            var empresa = mapper.Map<EmpresaCreateDTO, Empresa>(loginDTO);



            if (!loginRepository.Exist(empresa))
            {


                var u = mapper.Map<Empresa, EmpresaCreateDTO>(loginRepository.Create(empresa,int.Parse(codigo)));
                u.Password = null;
                this.emailSender.Send(empresa.Email, int.Parse(codigo));
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
                var a = loginRepository.Login(empresa);

                var u = mapper.Map<Empresa, EmpresaDTO>(a);
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

        public bool Send(int id,int idempresa)
        {

            var u = loginRepository.Send(id);
            var e = loginRepository.Obtain(idempresa);
            if(u != null)
            {
                this.emailSender.Contact(u.Email,e);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Confirmar(string email, int codigo)
        {
            return loginRepository.Confirmar(email, codigo);
        }

        public bool Iniciar(int id)
        {
            Random num = new Random();
            int a = num.Next(1, 10);
            int b = num.Next(1, 10);
            int c = num.Next(1, 10);
            int d = num.Next(1, 10);
            string codigo = a + "" + b + "" + c + "" + d;

            

            var u = loginRepository.Iniciar(id,int.Parse(codigo));
            if (u != null)
            {
            this.emailSender.Contrasena(u.Email, int.Parse(codigo));

            return true;
            }
            else
            {
            return false;
            }





        }

        public bool Cambiar(string password, int codigo)
        {

            password = passwordGenerator.Hash(password);
            return loginRepository.Cambiar(password,codigo);
        }

        public EmpresaDTO GetId(LoginDTO loginDTO)
        {
            var empresa = mapper.Map<LoginDTO, Empresa>(loginDTO);

            if (loginRepository.Exist(empresa))
            {
                var a = loginRepository.GetId(empresa);

                var u = mapper.Map<Empresa, EmpresaDTO>(a);
                u.Password = null;

                return u;

            }
            else
            {
                return null;
            }


        }

        public bool Contact(MensajeDTO mensaje)
        {
            return messageRepository.Contact(mapper.Map<MensajeDTO, Mensaje>(mensaje));
        }
    }
    
}
