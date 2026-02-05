using System;
using System.Collections.Generic;
using System.Text;

namespace UsuariosApp.Domain.Dtos.Requests
{
    public record CriarUsuarioRequest(
            string Nome,
            string Email,
            string Senha
        );
}
