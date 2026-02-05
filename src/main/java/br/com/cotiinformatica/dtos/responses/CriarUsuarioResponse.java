package br.com.cotiinformatica.dtos.responses;

import java.time.LocalDateTime;
import java.util.UUID;

public record CriarUsuarioResponse(
        UUID id,    //Id do usuário cadastrado
        String nome, //Nome do usuário
        String email,   //Email do usuário
        String perfil,  //Perfil do usuário
        LocalDateTime dataHoraCriacao   //Data e hora de cadastro
) {
}
