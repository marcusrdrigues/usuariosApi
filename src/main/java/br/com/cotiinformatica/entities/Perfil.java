package br.com.cotiinformatica.entities;

import jakarta.persistence.*;
import lombok.Data;

import java.util.List;
import java.util.UUID;

@Data
@Entity //indica que a classe é uma entidade JPA
@Table(name = "tb_perfil") //nome da tabela no banco de dados
public class Perfil {

    @Id
    @GeneratedValue(strategy = GenerationType.UUID) //Gerando um id automaticamente
    @Column(name = "id")
    private UUID id;

    @Column(name = "nome", length = 25, nullable = false, unique = true)
    private String nome;

    //1 perfil para MUITOS usuários
    //mappedBy = nome do atributo na classe Usuario onde foi mapeada a chave estrangeira
    @OneToMany(mappedBy = "perfil")
    private List<Usuario> usuarios;
}
