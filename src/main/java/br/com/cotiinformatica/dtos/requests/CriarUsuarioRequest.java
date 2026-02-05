package br.com.cotiinformatica.dtos.requests;

public record CriarUsuarioRequest(
        String nome, //nome do usuario
        String email, //email do usuario
        String senha //senha do usuario
) {
}
