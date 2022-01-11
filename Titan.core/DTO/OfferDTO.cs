using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.Core.DTO
{
    public class OfferDTO
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public Double Remuneracion { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public int EmpresaId { get; set; }
        public Empresa empresa { get; set; }
        public String Horario { get; set; }

        public List<OfferEmpresa> listaCiclos { get; set; }

    }
}
