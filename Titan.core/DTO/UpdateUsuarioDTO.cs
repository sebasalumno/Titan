using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Core.DTO
{
   public class UpdateUsuarioDTO
    {
        public int id { get; set; }
        public String Name { get; set; }

        public String Username { get; set; }

        public String Email { get; set; }

        public String Localidad { get; set; }

        public int ProvinciaId { get; set; }

        public double nota { get; set; }

    }
}
