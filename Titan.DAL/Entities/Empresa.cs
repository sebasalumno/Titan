using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Titan.DAL.Entities
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }
        public String Email { get; set; }
        public String Name { get; set; }
        public int ProvinciaId { get; set; }
        [ForeignKey("ProvinciaId")]
        public Provincia Provincia { get; set; }
        public String localidad { get; set; }
        public String Direccion { get; set; }
        public String Password { get; set; }


    }
}
