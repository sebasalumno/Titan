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
    public class InscripcionesController : ControllerBase
    {
        public IInscripcionesBL inscripcionesBL { get; set; }

        public InscripcionesController(IInscripcionesBL inscripcionesBL)
        {
            this.inscripcionesBL = inscripcionesBL;
        }

        [HttpPost]
        [Route("Create")]

        public ActionResult<InscripcionesDTO> Create(InscripcionesDTO inscripciones)
        {
            var inscripcion = inscripcionesBL.Create(inscripciones);
            if (inscripcion != null)
            {
                return Ok(inscripcion);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetEmpresa")]
        public ActionResult<List<InscripcionesDTO>> GetEmpresa(int id)
        {
            var lista = inscripcionesBL.SearchEmpresas(id);
            if(lista != null)
            {
                return Ok(lista);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<InscripcionesDTO>> GetAll()
        {
            var lista = inscripcionesBL.GetAll();
            if (lista != null)
            {
                return Ok(lista);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("Search")]
        public ActionResult<List<InscripcionesDTO>> Filter(string  filter)
        {

        }

    }
}
