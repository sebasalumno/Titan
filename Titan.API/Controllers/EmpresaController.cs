using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Titan.BL.Contracts;
using Titan.BL.Implementations;
using Titan.Core.DTO;

namespace Titan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmpresaController : ControllerBase
    {
        public ILoginBL LoginBL { get; set; }
        public EmpresaController(ILoginBL loginBL)
        {
            this.LoginBL = loginBL;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<LoginDTO> Login(LoginDTO loginDTO)
        {
            return LoginBL.Login(loginDTO);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<LoginDTO> Create(LoginDTO loginDTO)
        {
            var usuario = LoginBL.Create(loginDTO);
            if (usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
