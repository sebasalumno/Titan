using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Titan.DAL.Entities
{
    public class ConfirmacionE
    {
        [Key]
        public int Id { get; set; }

        public int IdEmpresa { get; set; }

        [ForeignKey("IdEmpresa")]
        public Empresa Empresa { get; set; }

        public int Codigo { get; set; }
    }
}
