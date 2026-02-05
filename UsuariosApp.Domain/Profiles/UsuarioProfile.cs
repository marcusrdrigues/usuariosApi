using AutoMapper;
using UsuariosApp.Domain.Dtos.Requests;
using UsuariosApp.Domain.Dtos.Responses;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Helpers;

namespace UsuariosApp.Domain.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        //DE -> PARA: CriarUsuarioRequest -> Usuario
        CreateMap<CriarUsuarioRequest, Usuario>()
            .AfterMap((request, entity) =>
            {
                entity.DataHoraCriacao = DateTime.Now;
            });
        
        //DE -> PARA: Usuario -> CriarUsuarioResponse
        CreateMap<Usuario, CriarUsuarioResponse>();
        
        //DE -> PARA: Usuario -> AutenticarUsuarioResponse
        CreateMap<Usuario, AutenticarUsuarioResponse>();
    }
}