using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Titan.DAL.Entities
{
   public class OfferEmpresa
    {
        [Key]
        public int id { get; set; }
        public int IdCiclo { get; set; }
        [ForeignKey("IdCiclo")]
        public Ciclo ciclo { get; set; }
        public int OfferId { get; set; }

    }
}
