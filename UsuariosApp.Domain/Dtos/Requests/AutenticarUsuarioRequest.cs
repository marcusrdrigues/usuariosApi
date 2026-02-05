using System;
using System.Collections.Generic;
using System.Text;

namespace UsuariosApp.Domain.Dtos.Requests
{
    public record AutenticarUsuarioRequest(
            string Email,
            string Senha
        );
}
