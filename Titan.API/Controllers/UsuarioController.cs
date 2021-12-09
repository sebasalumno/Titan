using Microsoft.AspNetCore.Cors;
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
    public class UsuarioController : ControllerBase
    {

        public IUsuarioBL usuarioBL { get; set; }

        public UsuarioController(IUsuarioBL usuarioBL)
        {
            this.usuarioBL = usuarioBL;

        }



        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Route ("Login")]
        /*
         * Este metodo inicia el proceso de login, para comprobar que el usuario esta en la base de datos
         */
        public ActionResult<UsuarioDTO> Login(LoginDTO loginDTO)
        {
            UsuarioDTO usuario;

            if ((usuario = usuarioBL.Login(loginDTO)) != null )
                return Ok(usuario);
            else
                return Unauthorized();

            

        }
        [HttpPost]
        /*
         * Este metodo inicia el proceso para crear un usuario e insertarlo en la base de datos
         */
        public ActionResult<UsuarioDTO> Create(UsuarioDTO usuarioDTO)
        {

            var usuario = usuarioBL.Create(usuarioDTO);

            if (usuario !=null)
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
