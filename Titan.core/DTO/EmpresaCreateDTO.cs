using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Core.DTO
{
    public class EmpresaCreateDTO
    {
        public String Email { get; set; }
        public String Name { get; set; }
        public int ProvinciaId { get; set; }

        public String localidad { get; set; }
        public String Direccion { get; set; }
        public String Password { get; set; }
    }
}
