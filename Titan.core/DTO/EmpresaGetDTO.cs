using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.Core.DTO
{
    public class EmpresaGetDTO
    {
        public String Email { get; set; }
        public String Name { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        public String localidad { get; set; }
        public String Direccion { get; set; }
    }
}
