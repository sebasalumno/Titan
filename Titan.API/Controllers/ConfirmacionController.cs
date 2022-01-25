using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Titan.BL.Contracts;

namespace Titan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmacionController : ControllerBase
    {
        public IMapper mapper { get; set; }

        public IUsuarioBL usuarioBL { get; set; }

        public IEmpresaBL empresaBL { get; set; }

        public ConfirmacionController(IUsuarioBL usuarioBL,IEmpresaBL empresaBL,IMapper mapper)
        {
            this.usuarioBL = usuarioBL;
            this.empresaBL = empresaBL;
            this.mapper = mapper;

        }

        [HttpPut]
        [Route("Confirmacion")]
        public ActionResult<bool> ConfirmarUsuario(string email,int codigo)
        {
             return usuarioBL.Confirmar( email, codigo);
           
        }

        [HttpPut]
        [Route("ConfirmacionEmpresa")]
        public ActionResult<bool> ConfirmarEmpresa(string email, int codigo)
        {
            return empresaBL.Confirmar(email, codigo);

        }

        [HttpPut]
        [Route("IniciarContrasenaEmpresa")]
        public ActionResult<bool> IniciarContrasenaEmpresa(string email)
        {
            return empresaBL.Iniciar(email);

        }

        [HttpPut]
        [Route("IniciarContrasenaUsuario")]
        public ActionResult<bool> IniciarContrasenaUsuario(string email)
        {
            return usuarioBL.Iniciar(email);

        }

        [HttpPut]
        [Route("CambiarContrasenaEmpresa")]
        public ActionResult<bool> CambiarContrasenaEmpresa(string password, int codigo)
        {
            return empresaBL.Cambiar(password,codigo);

        }

        [HttpPut]
        [Route("CambiarContrasenaUsuario")]
        public ActionResult<bool> CambiarContrasenaUsuario(string password, int codigo)
        {
            return usuarioBL.Cambiar(password, codigo);

        }


    }
}
