using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UsuariosApp.Domain.Dtos.Requests;
using UsuariosApp.Domain.Dtos.Responses;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Helpers;
using UsuariosApp.Domain.Interfaces;
using UsuariosApp.Domain.Validators;

namespace UsuariosApp.Domain.Services
{
    public class UsuarioService (IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        public CriarUsuarioResponse Criar(CriarUsuarioRequest request)
        {
            #region Copiar os dados do request para a entidade

            var usuario = mapper.Map<Usuario>(request);

            #endregion

            #region Validar os dados do usuário

            var validator = new UsuarioValidator();
            var result = validator.Validate(usuario);

            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            #endregion

            #region Email deve ser unico para cada usuário

            if(usuarioRepository.GetByEmail(usuario.Email) != null)
            {
                throw new ApplicationException("O email informado já está cadastrado, tente outro.");
            }

            #endregion

            #region Cadastrar o usuário e retornar os dados

            usuarioRepository.Add(usuario);

            return mapper.Map<CriarUsuarioResponse>(usuario);

            #endregion
        }

        public AutenticarUsuarioResponse Autenticar(AutenticarUsuarioRequest request)
        {
            #region Buscar o usuário no banco de dados

            var usuario = usuarioRepository.GetByEmail(request.Email);

            if (usuario == null)
            {
                throw new ApplicationException("Usuário não encontrado.");
            }

            if (usuario.Senha.Equals(CryptoHelper.GetSHA256(request.Senha)))
            {
                throw new ApplicationException("Acesso negado.");
            }

            #endregion

            #region Gerar o TOKEN JWT e retornar os dados do usuário

            var expiration = DateTime.Now.AddHours(24);
            var token = JwtTokenHelper.GenerateToken(usuario.Email, usuario.Perfil.ToString(), expiration);

            return new AutenticarUsuarioResponse
            (
                usuario.Id,
                usuario.Nome,
                usuario.Email,                
                DateTime.Now,
                expiration,
                token,
                usuario.Perfil.ToString()
            );

            #endregion
        }
    }
}
