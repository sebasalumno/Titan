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

    public class LoginController : ControllerBase
    {
        public ILoginBL LoginBL { get; set; }
        public LoginController(ILoginBL loginBL)
        {
            this.LoginBL = loginBL;
        }

        [HttpPost]
        public bool Login(LoginDTO loginDTO)
        {
            return LoginBL.Login(loginDTO);
        }
        
    }
}
