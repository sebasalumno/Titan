using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Titan.BL.Contracts;
using Titan.Core.DTO;
using Titan.Core.Security;
using Titan.DAL.Entities;

namespace Titan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsuarioController : ControllerBase
    {
        public IMapper mapper { get; set; }
        public IJwtBearer JwtBearer { get; set; }
        public IUsuarioBL usuarioBL { get; set; }

        public UsuarioController(IUsuarioBL usuarioBL, IJwtBearer jwtBearer, IMapper mapper)
        {
            this.usuarioBL = usuarioBL;
            this.JwtBearer = jwtBearer;
            this.mapper = mapper;

        }



        [HttpPost]
        [Route ("Login")]
        /*
         * Este metodo inicia el proceso de login, para comprobar que el usuario esta en la base de datos
         */
        public ActionResult<UsuarioDTO> Login(LoginDTO loginDTO)
        {
            UsuarioDTO usuario;
            usuario = usuarioBL.Login(loginDTO);
            if (( usuario != null ))
            {
                var u = mapper.Map<UsuarioDTO, Usuario>(usuario);

                Response.Headers.Add("Authorization", JwtBearer.GenerateJWTToken(u));

            return Ok(usuario);
            }
                
            else
                return Unauthorized();

            

        }
        [HttpPost]
        [Route ("Actualizar")]

        public ActionResult<bool> Update(UpdateUsuarioDTO update)
        {
             bool usuario = usuarioBL.Update(update);
            if(usuario != false)
            {
                return Ok(usuario);

            }
            else
            {
                return Unauthorized();
            }

            
        }
        [HttpPost]
        [Route("Create")]
        /*
         * Este metodo inicia el proceso para crear un usuario e insertarlo en la base de datos
         */
        public ActionResult<UsuarioDTO> Create(UsuarioDTO usuarioDTO)
        {

            var usuario = usuarioBL.Create(usuarioDTO);

            if (usuario !=null)
            {
                return Ok(usuario);
            }
            else
            {
                return BadRequest();
            }
            

        }
        [HttpGet]
        [Route("GetId")]
        /*
         * Este metodo se encargará de devolver el id al que pertenece un email
         */
        public ActionResult<UsuarioDTO> GetId (string email)
        {
            return usuarioBL.GetId(email);
        }

        [HttpGet]
        [Route("GetUser")]
        /*
         * Este metodo se encargará de devolver el id al que pertenece un email
         */
        public ActionResult<UsuarioDTO> GetUser(int id)
        {
            return usuarioBL.GetUser(id);
        }
    }
}
