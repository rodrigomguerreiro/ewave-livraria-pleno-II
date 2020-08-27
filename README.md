# Processo Seletivo Pleno II - Ewave <g-emoji class="g-emoji" alias="computer" fallback-src="https://github.githubassets.com/images/icons/emoji/unicode/1f4bb.png">💻</g-emoji> 


### Back-End
- .Net Core 3.1
- Swagger
- DDD
- EntityFramework
- UnitOfWork 
- Xunit

### Database
- Sql Server 
- Verifique a Modelagem clicando [aqui](https://dbdesigner.page.link/3ewUebnKJSJX1wCy9).

## Desafio
Meu objetivo foi deixar o código limpo e desacoplado, seguindo as boas práticas de patterns como Domain Driven Desgin - DDD.<br/>
Também foi implementado testes unitários para garantir que as funcionalidades sejam íntegras.<br/>
Busquei automatizar o processo de criação de banco de dados e a disponibilização da api através de conteiners do docker.<br/>
Por limitação de hardware tive que aumentar o sleep time do arquivo ```/BancoDeDados/entrypoint.sh ``` em 120 segundos, fiquem a vontade para modificar este parâmetro.<br/>
Infelizmente não consegui implementar a tempo o frontend.
- Foram criados testes Unitários somente para usuário.
    - Testes unitários de atributos das funções.
    - Testes unitários de regras de negócio com mock(cenários).
- Exceptions Filters foram criadas, porém não foram aplicadas em todos os casos.


## Funcionalidades
As principais funcionalidades da aplicação são: 
- Gerenciar empréstimos de livros.
    - Incluir Empréstimo
    - Encerrar Empréstimo
    
- Gerenciar  usuário.
    - Incluir, alterar e inativar.
    
- Gerenciar livro, autor e genero.
    - Incluir, alterar e inativar.

- Gerenciar instiuição de ensino.
    - Incluir, alterar e inativar

## Regras Aplicadas
- Um usuário só poderá emprestar no máximo 2 livros
- Empréstimos são limitados a 30 dias.
- Se o usuário possuir empréstimo em atraso, fica impossibilitado de fazer novos empréstimos.
- O Livro emprestado fica indisponível para outros usuários.
- Ao encerrar um empréstimo, o livro ficará disponível para os usuários.

## Orientações para teste interarivo da API com Swagger
- Durante o build do projeto, é executado um script sql para popular o banco de dados:
    - Tabela Endereco: 4 registros.
    - Tabela InstituicaoEnsino: 2 registros.
    - Tabela Usuario: 2 registros.
    - Tabela Autor: 4 registros.
    - Tabela Genero: 3 registros.
    - Tabela SituacaoLivro: 2 registros.
    - Tabela Livro: 4 registros.
    - Tabela Emprestimo: 1 registro.

- Existem dois usuários cadastrados respectivamente com id(1) e id(2).
- UsuarioId(1) não possui empréstimo.
    - Usuário fica limitado a 2 empréstimos.

- UsuarioId(2) possui um empréstimo atrasado com o livroId(1).
    - Tentar efetuar um novo empréstimo: retorna se usuário possui empréstimo atrasado.
    - Tentar emprestar o livroId(1) para outro usuário: retorna situação do livro (emprestado).

- É preciso registrar um autor, genero e situação do livro para registrar um livro.
- É preciso registrar uma instituiçao de ensino para registrar um usuário.
- É preciso um usuário para registrar o endereço.
- É preciso um usuário e um livro para incluir um empréstimo.

## Implementações Futuras

### Funções
- Gerenciar reservas(Agendar, reagendar, cancelar reserva)
- Genrenciar Status de reservas.
- Gerar Notificações.
- Gerar relatórios de empréstimos.

### BackEnd
- Aplicar Testes Unitários no restante das funcionalidades.

### FrontEnd
Implementar FrontEnd.

# Siga estes passos para executar o Projeto

Alguns requisitos são necessãrios para executar o projeto:
- [docker](https://www.docker.com/get-started  "docker") instalado
- Portas 1433 e 3000 liberadas.
```
> git clone https://github.com/rodrigomguerreiro/ewave-livraria-pleno-II.git
> cd ewave-livraria-pleno-II
> docker-compose up --build
```
Acessar api:
- [clique aqui](http://localhost:3000/swagger  "aqui").

 