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
Este desafio realmente me tirou da zona de conforto e também serviu como aprendizado, meu objetivo foi deixar o código limpo e desacoplado, seguindo as boas práticas de patterns como Domain Driven Desgin - DDD.<br/>
Também foi implementado testes unitários para garantir que as funcionalidades sejam íntegras.<br/>
Busquei automatizar o processo de criação de banco de dados e a disponibilização da api através de conteiners do docker.<br/>
Por limitação de hardware tive que aumentar o sleeptime do arquivo ```/BancoDeDados/entrypoint.sh ``` em 120 segundos, fiquem a vontade para modificar este parâmetro.<br/>
Infelizmente não consegui implementar a tempo o frontend, a construção da api literalmente consumiu todo tempo.
- Foram criados testes Unitários somente para usuário(por questões de tempo).
    - Testes unitários de atributos das funções.
    - Testes unitários de regras de negócio com mock(cenários).
- Exceptions Filters foram criadas, porém não foram aplicadas em todos os casos.


## Funcionalidades
Obs: As principais funcionalidades da aplicação são: 
- Gerenciar empréstimos de livros.
- Gerenciar  usuário.
- Gerenciar livro, autor e genero.
- Gerenciar instiuição de ensino.

## Implementações à fazer

### Funções
- Gerenciar reservas(Agendar, reagendar, cancelar reserva)
- Genrenciar Status de reservas, livros e empréstimos.
- Gerar Notificações.
- Gerar relatórios de empréstimos

### BackEnd
- Aplicar Exceptions para o restante dos casos.
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

 