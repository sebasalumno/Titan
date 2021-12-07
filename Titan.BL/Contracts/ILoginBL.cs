using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.DTO;

namespace Titan.BL.Contracts
{
   public interface ILoginBL
    {
        public LoginDTO Login(LoginDTO loginDTO);
        public LoginDTO Create(LoginDTO loginDTO);
    }
}
