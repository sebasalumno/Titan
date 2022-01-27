using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Titan.BL.Contracts;
using Titan.BL.Implementations;
using Titan.Core.DTO;
using Titan.Core.Security;
using Titan.DAL.Entities;

namespace Titan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EmpresaController : ControllerBase
    {
        public IMapper mapper { get; set; }
        public IEmpresaBL LoginBL { get; set; }
        public IJwtBearer JwtBearer { get; set; }
        public EmpresaController(IEmpresaBL empresaBL, IJwtBearer jwtBearer, IMapper mapper)
        {
            this.LoginBL = empresaBL;
            this.JwtBearer = jwtBearer;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<EmpresaDTO> Login(LoginDTO loginDTO)
        {
            EmpresaDTO empresa;

            if((empresa = LoginBL.Login(loginDTO)) != null)
            {
                var u = mapper.Map<EmpresaDTO, Empresa>(empresa);
                Response.Headers.Add("Authorization", JwtBearer.GenerateJWTTokenEmpresa(u));
                return Ok(empresa);
            }
            else
            {
                return Unauthorized() ;
            }



            
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<EmpresaCreateDTO> Create(EmpresaCreateDTO empresaDTO)
        {
            var usuario = LoginBL.Create(empresaDTO);
            if (usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Get")]
        public ActionResult<EmpresaGetDTO> Obtain(int id)
        {
            var empresa = LoginBL.Obtain(id);
            return empresa;
        }
        [HttpPost]
        [Route("Send")]
        public ActionResult<bool> Send(SendDTO send)
        {
            return LoginBL.Send(send.id,send.idempresa);
        }
    }
}
