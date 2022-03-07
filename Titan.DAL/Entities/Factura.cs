using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Titan.DAL.Entities
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaPago { get; set; }
        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
        public int StripePriceId { get; set; }
        public int ContratoId{get;set;}
        [ForeignKey("ContratoId")]
        public Contrato Contrato { get; set; }
    }
}
