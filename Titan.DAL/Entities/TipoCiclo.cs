using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Titan.DAL.Entities
{
    public class TipoCiclo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
