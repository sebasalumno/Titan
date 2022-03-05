using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.Core.DTO
{
    public class EmpresaDTO
    {
        public int Id { get; set; }
        public String Email{ get; set; }
        public String Name { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        public String localidad { get; set; }
        public String Direccion { get; set; }
        public String Password { get; set; }
        public int RolId { get; set; }
        public int StripeId { get; set; } 

    }
}
