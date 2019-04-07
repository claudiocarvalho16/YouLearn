using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Arguments.Usuario;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceUsuario
    {
        AdicionarResponse Adicionar(AdicionarRequest request);
        AutenticarResponse Autenticar(AutenticarRequest request);
    }
}
