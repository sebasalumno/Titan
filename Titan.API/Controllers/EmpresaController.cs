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
        public IEmpresaBL LoginBL { get; set; }
        public EmpresaController(IEmpresaBL empresaBL)
        {
            this.LoginBL = empresaBL;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<EmpresaDTO> Login(LoginDTO loginDTO)
        {
            return LoginBL.Login(loginDTO);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<EmpresaDTO> Create(EmpresaDTO empresaDTO)
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
    }
}
