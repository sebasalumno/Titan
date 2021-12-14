using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.Core.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Username { get; set; }
        public String Name { get; set; }
        public String Localidad { get; set; }
        public int ProvinciaId { get; set; }
        public ProvinciaDTO Provincia {get ;set ;}
        public int TipoCicloId { get; set; }
        public TipoCiclo tipoCiclo { get; set; }
        public int CicloId { get; set; }
        public Ciclo ciclo { get; set; }
        public double nota { get; set; }
        public DateTime nacimiento { get; set; }
    }
}
