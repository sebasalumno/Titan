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
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public int Remuneracion { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }

        public String Horario { get; set; }
        public int Idciclo { get; set; }
        [ForeignKey("Idciclo")]
        public Ciclo ciclo { get; set; }


    }
}
