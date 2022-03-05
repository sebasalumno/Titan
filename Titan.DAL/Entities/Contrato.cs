using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Titan.DAL.Entities
{
    public class Contrato
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }

        public int ContratoEstadoId { get; set; }
        [ForeignKey("ContratoEstadoId")]
        public ContratoEstado ContratoEstado  { get; set; }
        public int StripeId { get; set; }

    }
}
