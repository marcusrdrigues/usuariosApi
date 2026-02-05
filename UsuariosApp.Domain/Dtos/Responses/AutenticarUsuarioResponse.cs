using System;
using System.Collections.Generic;
using System.Text;

namespace UsuariosApp.Domain.Dtos.Responses
{
    public record AutenticarUsuarioResponse(
            Guid Id,
            string Nome,
            string Email,
            DateTime DataHoraAcesso,
            DateTime DataHoraExpiracao,
            string AccessToken,
            string Perfil
        );
}
