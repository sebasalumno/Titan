using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Titan.BL.Contracts;
using Titan.Core.DTO;

namespace Titan.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TipoCicloController : ControllerBase
    {

        public ITipoCicloBL tipoCicloBL { get; set; }

        public TipoCicloController(ITipoCicloBL tipoCicloBL)
        {
            this.tipoCicloBL = tipoCicloBL;

        }


        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<TipoCicloDTO>> GetAll()
        {

            var usuario = tipoCicloBL.GetAll();
            

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
