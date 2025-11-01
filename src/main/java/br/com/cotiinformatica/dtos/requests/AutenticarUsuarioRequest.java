package br.com.cotiinformatica.dtos.requests;

public record AutenticarUsuarioRequest(
        String email, //email do usuario
        String senha //senha do usuario
) {
}
