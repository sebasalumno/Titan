using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Core.DTO
{
    public class OfertaCicloDTO
    {
        public int id {get;set;}
        public int IdCiclo { get; set; }
        public CicloDTO ciclo { get; set; }
        public int OfferId { get; set; }

    }
}
