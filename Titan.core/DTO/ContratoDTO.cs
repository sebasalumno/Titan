using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.Core.DTO
{
    public class ContratoDTO
    {
        //idsuscripcion
        public int id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public int EmpresaId { get; set; }
        public DateTime FechaAlta { get; set; }
        public int ContratoEstadoId { get; set; }
        public string StripeId { get; set; }

    }
}
