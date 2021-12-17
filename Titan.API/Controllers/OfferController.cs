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
    public class OfferController : ControllerBase
    {
        public IOfferBL offerBL { get; set; }

        public OfferController(IOfferBL offerBL)
        {
            this.offerBL = offerBL;

        }
        [HttpPost]
        public ActionResult<OfferDTO> Create(OfferDTO offerDTO)
        {

            var usuario = offerBL.Create(offerDTO);

            if (usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                return BadRequest();
            }


        }
        [HttpDelete]
        [Route("Delete")]
        public ActionResult<bool> Delete(OfferDTO offer)
        {

            var usuario = offerBL.Delete(offer);

            if (usuario ==true)
            {
                return Ok(usuario);
            }
            else
            {
                return BadRequest();
            }


        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<OfferDTO>> GetAll()
        {

            var usuario = offerBL.GetAll();

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
        public ActionResult<List<OfferDTO>> Get(int id)
        {

            var usuario = offerBL.Get(id);

            if (usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                return BadRequest();
            }


        }
        [HttpPut]
        [Route("Update")]
        public ActionResult<List<OfferDTO>> Update(OfferDTO offer)
        {

            var usuario = offerBL.Update(offer);

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
