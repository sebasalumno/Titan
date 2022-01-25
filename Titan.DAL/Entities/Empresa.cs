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
        public string Email { get; set; }
        public string Name { get; set; }
        public int ProvinciaId { get; set; }
        [ForeignKey("ProvinciaId")]
        public Provincia Provincia { get; set; }
        public string localidad { get; set; }
        public string Direccion { get; set; }
        public string Password { get; set; }
        public bool Confirmado { get; set; }


    }
}
