using System;
using System.Collections.Generic;
using System.Text;

namespace UsuariosApp.Domain.Dtos.Responses
{
    public record CriarUsuarioResponse(
            Guid Id,
            string Nome, 
            string Email,
            DateTime DataHoraCriacao,
            string Perfil
        );
}
