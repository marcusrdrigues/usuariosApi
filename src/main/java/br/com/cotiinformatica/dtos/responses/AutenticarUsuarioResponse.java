package br.com.cotiinformatica.dtos.responses;

import java.time.LocalDateTime;
import java.util.UUID;

public record AutenticarUsuarioResponse(
        UUID id, //Id do usuario autenticado
        String nome, //Nome do usuario
        String email, //Email do usuario
        String perfil, //Perfil de acesso do usuario
        LocalDateTime dataHoraAcesso, //Data e hora do acesso
        String acessToken //TOKEN JWT (credencial)
) {
}
