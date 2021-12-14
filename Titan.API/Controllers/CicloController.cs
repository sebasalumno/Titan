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
    public class CicloController : ControllerBase
    {
        public ICicloBL cicloBL { get; set; }
        public CicloController(ICicloBL cicloBL)
        {
            this.cicloBL = cicloBL;
        }

    }
}
