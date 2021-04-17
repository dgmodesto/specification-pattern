# SPECIFICATION PATTERN

## Aplicando o Padrão Specification com C#, mostrando como este padrão pode ser aplicado.

![diagrama-classe-specification](https://user-images.githubusercontent.com/29544464/115096582-2e42a980-9efc-11eb-9de5-c34a8bf04b04.PNG) 


- Na programação de computadores, o padrão de especificação é um padrão de design de software específico , por meio do qual as regras de negócios podem ser recombinadas encadeando as regras de negócios usando a lógica booleana. O padrão é freqüentemente usado no contexto de design orientado a domínio

### Explicação
 - Um padrão de especificação descreve uma regra de negócios que pode ser combinada com outras regras de negócios. Nesse padrão, uma unidade de lógica de negócios herda sua funcionalidade da classe abstrata Composite Specification agregada. A classe Composite Specification tem uma função chamada IsSatisfiedBy que retorna um valor booleano. Após a instanciação, a especificação é "encadeada" com outras especificações, tornando as novas especificações de fácil manutenção, mas com lógica de negócios altamente personalizável. Além disso, na instanciação, a lógica de negócios pode, por meio da invocação de método ou inversão de controle , ter seu estado alterado para se tornar um delegado de outras classes, como um repositório de persistência.

 - Como consequência da composição do tempo de execução da lógica de negócios / domínio de alto nível, o padrão de especificação é uma ferramenta conveniente para converter critérios de pesquisa de usuário ad-hoc em lógica de baixo nível para serem processados ​​por repositórios.

 - Outro ponto forte dessa ideia é a facilidade de tornar o código compreensível pelo especialista do domínio.

 
 ### Conclusão
 
  - "Specification é um padrão bastante flexível, tornando as regras de negócio do domínio mais claras. Entretanto, as validações podem ser simplificadas, usando pacotes de terceiros, como por exemplo o Flunt, que une esta abordagem com a Domain Notification, e pode residir em uma camada transversal do projeto." (Artigo de exemplo nas referências)
    
 
#### Veja os exemplos na implementação.

Fontes:
  - https://blog.tiagopariz.com/c-with-patterns-specification/
  - https://en.wikipedia.org/wiki/Specification_pattern#:~:text=In%20computer%20programming%2C%20the%20specification,context%20of%20domain%2Ddriven%20design.
  - https://www.eximiaco.tech/pt/2019/10/28/usando-specification-pattern-para-respeitar-o-open-closed-principle/
