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
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliasController : ControllerBase
    {

        public IFamiliaBL familiaBL { get; set; }

        public FamiliasController(IFamiliaBL familiaBL)
        {
            this.familiaBL = familiaBL;

        }


        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<FamiliaDTO>> GetAll()
        {

            var usuario = familiaBL.GetAll();

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
