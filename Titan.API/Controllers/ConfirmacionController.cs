using AutoMapper;
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
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
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

        [HttpPost]
        [Route("Confirmacion")]
        public ActionResult<bool> ConfirmarUsuario(CodigoDTO codigo)
        {
             return usuarioBL.Confirmar( codigo.email, codigo.codigo);
           
        }

        [HttpPost]
        [Route("ConfirmacionEmpresa")]
        public ActionResult<bool> ConfirmarEmpresa(CodigoDTO codigo)
        {
            return empresaBL.Confirmar(codigo.email, codigo.codigo);

        }

        [HttpPost]
        [Route("IniciarContrasenaEmpresa")]
        public ActionResult<bool> IniciarContrasenaEmpresa(InicioDTO inicio)
        {
            return empresaBL.Iniciar(inicio.id);

        }

        [HttpPost]
        [Route("IniciarContrasenaUsuario")]
        public ActionResult<bool> IniciarContrasenaUsuario(InicioDTO inicio)
        {
            return usuarioBL.Iniciar(inicio.id);

        }

        [HttpPost]
        [Route("CambiarContrasenaEmpresa")]
        public ActionResult<bool> CambiarContrasenaEmpresa(CambioDTO cambio)
        {
            return empresaBL.Cambiar(cambio.password,cambio.codigo);

        }

        [HttpPost]
        [Route("CambiarContrasenaUsuario")]
        public ActionResult<bool> CambiarContrasenaUsuario(CambioDTO cambio)
        {
            return usuarioBL.Cambiar(cambio.password, cambio.codigo);

        }


    }
}
