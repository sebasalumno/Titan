using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.DTO;

namespace Titan.BL.Contracts
{
   public interface ILoginBL
    {
        public bool Login(LoginDTO loginDTO);
    }
}
