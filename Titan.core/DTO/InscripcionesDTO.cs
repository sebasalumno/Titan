using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.Core.DTO
{
   public class InscripcionesDTO
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public int OfertaId { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public Estado EstadoInscripcion { get; set; }
    }
}
