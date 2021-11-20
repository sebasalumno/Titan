using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Core.Security
{
    public interface IPasswordGenerator
    {
        public string Hash(string password);


    }
}
