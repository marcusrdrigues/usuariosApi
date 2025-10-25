package br.com.cotiinformatica.entities;

import jakarta.persistence.*;
import lombok.Data;

import java.time.LocalDateTime;
import java.util.UUID;

@Data
@Entity //indica que a classe é uma entidade JPA
@Table(name = "tb_usuario") //indica o nome da tabela no banco de dados
public class Usuario {

    @Id //chave primária da tabela
    @GeneratedValue(strategy = GenerationType.UUID) //Gerando um id automaticamente
    @Column(name = "id")
    private UUID id;

    @Column(name = "nome", length = 150, nullable = false)
    private String nome;

    @Column(name = "email", length = 50, nullable = false, unique = true)
    private String email;

    @Column(name = "senha", length = 100, nullable = false)
    private String senha;

    @Temporal(TemporalType.TIMESTAMP) //TIMESTAMP para data e hora
    @Column(name = "data_hora_criacao", nullable = false)
    private LocalDateTime dataHoraCriacao;

    @ManyToOne //muitos usuários para 1 perfil
    @JoinColumn(name = "perfil_id", nullable = false) //chave estrangeira
    private Perfil perfil;
}
