﻿using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.DTO;

namespace Titan.BL.Contracts
{
    public interface IUsuarioBL
    {

        public UsuarioDTO Login(LoginDTO loginDTO);
        public UsuarioDTO Create(UsuarioDTO usuarioDTO);

    }
}
