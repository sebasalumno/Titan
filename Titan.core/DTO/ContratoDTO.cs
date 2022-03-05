using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.Core.DTO
{
    public class ContratoDTO
    {
        //idsuscripcion
        public string StripeId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
