using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Core.DTO
{
   public class MensajeDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int EmpresaId { get; set; }
        public string Message { get; set; }

    }
}
