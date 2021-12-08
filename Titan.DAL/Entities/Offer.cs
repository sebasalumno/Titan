using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Titan.DAL.Entities
{
   public class Offer
   {
        [Key]
        public int id { get; set; }
        
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Provincia Empresa { get; set; }
        public Ciclo ciclo { get; set; }
        public String name { get; set; }

        public String Descripcion { get; set; }

        public String Horario { get; set; }
        public int Remuneracion { get; set; }



    }
}
