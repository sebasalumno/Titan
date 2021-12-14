using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Titan.DAL.Entities
{
   public class OfferEmpresa
    {
        public int IdCiclo { get; set; }
        [ForeignKey("IdCiclo")]
        public Ciclo ciclo { get; set; }
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
    }
}
