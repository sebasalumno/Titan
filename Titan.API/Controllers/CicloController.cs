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

namespace Titan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CicloController : ControllerBase
    {
        public ICicloBL cicloBL { get; set; }
        public CicloController(ICicloBL cicloBL)
        {
            this.cicloBL = cicloBL;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<CicloDTO>> GetAll()
        {

            var usuario = cicloBL.GetAll();


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
