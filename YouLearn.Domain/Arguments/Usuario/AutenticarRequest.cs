﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.Arguments.Usuario
{
    public class AutenticarRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
