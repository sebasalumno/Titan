using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Titan.DAL.Entities
{
    public enum Estado
    {
        pendiente,
        seleccionado,
        no_seleccionado
    }
    public class Inscripciones
    {
        [Key]
        public int Id { get; set; }

        public int AlumnoId { get; set; }
       [ForeignKey("AlumnoId")]
        public Usuario Alumno { get; set; }

        public int OfertaId { get; set; }

        [ForeignKey("OfertaId")]

        public Offer Oferta { get; set; }
        
        public DateTime FechaInscripcion { get; set; }

        public Estado EstadoInscripcion { get;set; }
    }
}
