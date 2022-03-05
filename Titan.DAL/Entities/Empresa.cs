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

        public int RolId { get; set; }
        [ForeignKey("RolId")]
        //Todavia no esta creada la tabla asi que la migracion de mensaje no la ha vinculado.
        //Mirar en el txt guardado.
        public Rol Rol { get; set; }
        public string StripeId { get; set; }


    }
}
