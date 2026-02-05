using System;
using System.Collections.Generic;
using System.Text;

namespace UsuariosApp.Domain.Entities
{
    public class Usuario
    {
        #region Propriedades

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public DateTime DataHoraCriacao { get; set; }
        public Perfil Perfil { get; set; } = Perfil.Usuario;

        #endregion
    }

    public enum Perfil
    {
        Usuario,
        Administrador
    }
}
