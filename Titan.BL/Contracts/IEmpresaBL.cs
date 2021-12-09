using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.DTO;

namespace Titan.BL.Contracts
{
   public interface IEmpresaBL
    {
        public EmpresaDTO Login(LoginDTO loginDTO);
        public EmpresaDTO Create(EmpresaDTO empresaDTO);
    }
}
