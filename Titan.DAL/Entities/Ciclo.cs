using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Titan.DAL.Entities
{
   public class Ciclo
   {
        [Key]
       
        public int Id { get; set; }
        public String Name { get; set; }

        public int TipoCicloId { get; set; }
        [ForeignKey("TipoCicloId")]
        public TipoCiclo TipoCiclo { get; set; }

        public int FamiliaId { get; set; }
        [ForeignKey("FamiliaId")]
        public Familia Familia { get; set; }

    }
}
