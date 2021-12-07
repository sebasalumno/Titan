using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Core.DTO
{
    public class LoginDTO
    {
        public int Id { get; set; }
        public String Email{ get; set; }

        public String Password { get; set; }
        public String Name { get; set; }
    }
}
