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
    public class OfertaCicloController : ControllerBase
    {

        public IOfertaCicloBL ofertaCiclo { get; set; }

        public OfertaCicloController(IOfertaCicloBL ofertaCiclo)
        {
            this.ofertaCiclo = ofertaCiclo;
        }

        [HttpGet]
        [Route("GetCiclo")]
        public ActionResult<List<OfertaCicloDTO>> GetCiclo(int id)
        {
            var lista = ofertaCiclo.GetCiclo(id);
            if (lista != null)
            {
                return Ok(lista);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
