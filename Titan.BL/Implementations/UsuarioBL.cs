﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Titan.BL.Contracts;
using Titan.Core.DTO;
using Titan.Core.Email;
using Titan.Core.Security;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.BL.Implementations
{
    public class UsuarioBL : IUsuarioBL
    {
        public IPasswordGenerator passwordGenerator { get; set; }
        public IUsuarioRepository usuarioRepository { get; set; }
        public IMapper mapper { get; set; }
        public IEmailSender emailSender { get; set; }

        public UsuarioBL(IUsuarioRepository usuarioRepository, IPasswordGenerator passwordGenerator,IMapper mapper, IEmailSender emailSender)
        {
            this.usuarioRepository = usuarioRepository;
            this.passwordGenerator = passwordGenerator;
            this.mapper = mapper;
            this.emailSender = emailSender;
            }
        /*
         * Este metodo encripta la contraseña y pasa el usuario que se ha comprobado si existe en la bd a un usuarioDTO para devolver
         */
        public UsuarioDTO Login(LoginDTO loginDTO)
        {
            loginDTO.Password = passwordGenerator.Hash(loginDTO.Password);
            var usuario = mapper.Map<LoginDTO, Usuario>(loginDTO);
            var usuarioDTO = mapper.Map<Usuario, UsuarioDTO>(usuarioRepository.Login(usuario));
            if (usuarioDTO != null)
            {
                usuarioDTO.Password = null;
            }

            return  usuarioDTO;


        }

            /*
             * Este metodo encripta la contraseña del nuevo usuario y comprueba que el usuario no exista en la base de datos
             */
            public UsuarioDTO Create(UsuarioDTO usuarioDTO)
            {
            usuarioDTO.Password = passwordGenerator.Hash(usuarioDTO.Password);
            var usuario = mapper.Map<UsuarioDTO, Usuario>(usuarioDTO);



            if(!usuarioRepository.Exist(usuario)){

                
                 var u =    mapper.Map<Usuario, UsuarioDTO>(usuarioRepository.Create(usuario));
                u.Password = null;
                this.emailSender.Send(usuario.Email);
                return u;

            }


                return null;
            }

        public UsuarioDTO GetId(string email)
        {
            return mapper.Map<Usuario, UsuarioDTO>(usuarioRepository.GetId(email));
        }

        public UsuarioDTO GetUser(int id)
        {
            return mapper.Map<Usuario, UsuarioDTO>(usuarioRepository.GetUser(id));
        }
    }
} 
