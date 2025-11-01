package br.com.cotiinformatica.services;

import br.com.cotiinformatica.dtos.requests.AutenticarUsuarioRequest;
import br.com.cotiinformatica.dtos.requests.CriarUsuarioRequest;
import br.com.cotiinformatica.dtos.responses.AutenticarUsuarioResponse;
import br.com.cotiinformatica.dtos.responses.CriarUsuarioResponse;
import br.com.cotiinformatica.entities.Usuario;
import br.com.cotiinformatica.repositories.PerfilRepository;
import br.com.cotiinformatica.repositories.UsuarioRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;

@Service
public class UsuarioService {

    @Autowired
    private UsuarioRepository usuarioRepository;

    @Autowired
    private PerfilRepository perfilRepository;

    public CriarUsuarioResponse criarUsuario(CriarUsuarioRequest request) {

        //Criar um usuario com os dados obtidos do request (Record)
        var usuario = new Usuario();

        usuario.setNome(request.nome()); //preenchendo o nome
        usuario.setEmail(request.email()); //preenchendo o email
        usuario.setSenha(request.senha()); //preenchendo a senha
        usuario.setDataHoraCriacao(LocalDateTime.now()); //preenchendo a data e hora de criacao

        //Regra: Os usuarios deverão ser cadastrados para um perfil padrão chamado de "Operador"
        usuario.setPerfil(perfilRepository.findByNome("Operador"));

        //Salvar o usuario no banco de dados
        usuarioRepository.save(usuario);

        //Copiar as informações para o DTO de resposta (response)
        return new CriarUsuarioResponse(
                usuario.getId(),
                usuario.getNome(),
                usuario.getEmail(),
                usuario.getPerfil().getNome(),
                usuario.getDataHoraCriacao()
        );
    }

    public AutenticarUsuarioResponse autenticarUsuario(AutenticarUsuarioRequest request){
        //TODO
        return null;
    }
}
