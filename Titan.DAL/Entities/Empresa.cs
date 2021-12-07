using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Titan.DAL.Entities
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
    }
}
