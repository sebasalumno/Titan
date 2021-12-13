using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.Core.DTO
{
   public class CicloDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TipoCicloId { get; set; }
        public TipoCiclo TipoCiclo { get; set; }
        public int FamiliaId { get; set; }
        public Familia Familia { get; set; }

    }
}
