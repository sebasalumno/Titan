using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Titan.DAL.Entities
{
   public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Username { get; set; }
        public String Name { get; set; }
        public String Localidad { get; set; }
        public int ProvinciaId { get; set; }
        [ForeignKey("ProvinciaId")]
        public Provincia Provincia { get; set; }
        public int TipoCicloId { get; set; }
        [ForeignKey("TipoCicloId")]
        public TipoCiclo tipoCiclo { get; set; }
        public int CicloId { get; set;}
        [ForeignKey("CicloId")]
        public Ciclo ciclo { get; set; }
        public double nota { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
