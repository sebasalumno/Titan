using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.DTO;

namespace Titan.BL.Contracts
{
   public interface IEmpresaBL
    {
        public EmpresaDTO Login(LoginDTO loginDTO);
        public EmpresaCreateDTO Create(EmpresaCreateDTO empresaDTO);
        public EmpresaGetDTO Obtain(int number);
        public bool Send(int id);
        public bool Confirmar(string email, int codigo);
        public bool Iniciar(string email);
        public bool Cambiar(string password, int codigo);
    }
}
