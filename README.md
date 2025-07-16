# InvestTrack API
API RESTful para agregação e gerenciamento de portfólios de investimentos, desenvolvida com .NET 8 e C#.


## Tabela de Conteúdos

<a href="#Sobre">Sobre o Projeto</a>

<a href="#funcionalidades">Principais Funcionalidades</a>

<a href="#tecnologias">Tecnologias utilizadas</a>

<a href="#conceitos">Conceitos e Arquitetura</a>

<a href="#executar">Como Executar o Projeto</a>


<a href="#documentacao">Documentação da API</a>


<div class="Sobre">
        <p>O InvestTrack API é um projeto de backend que simula um agregador de investimentos. <br>Ele permite que usuários cadastrem seus ativos financeiros (como ações e fundos) e obtenham uma visão consolidada do seu patrimônio.</p>
        <p>Este projeto foi desenvolvido como parte dos meus estudos em desenvolvimento backend com .NET, com o objetivo de aplicar conceitos modernos e boas práticas de mercado para criar uma API RESTful robusta, testável e escalável.</p>
</div>

## Principais Funcionalidades
- Gerenciamento completo (CRUD - Criar, Ler, Atualizar, Deletar) de Usuários.
- Gerenciamento completo (CRUD) de Ativos Financeiros, sempre associados a um usuário.
- Endpoint de consolidação que calcula o valor total do portfólio de um usuário com base em cotações simuladas.
- Validação de dados de entrada utilizando DTOs (Data Transfer Objects).
- Tratamento de erros e retornos com status codes HTTP consistentes.


## Tecnologias Utilizadas

### Backend
- .NET 8 e ASP.NET Core 8: Framework para construção da API.
- C#: Linguagem de programação principal.
- Entity Framework Core 8: ORM para comunicação com o banco de dados (abordagem Code-First).

### Banco de Dados
- SQL Server: Banco de dados relacional.
- Docker: Utilizado para criar um ambiente de banco de dados conteinerizado e portável.

### Ferramentas
- Swagger (OpenAPI): Documentação interativa da API.
- Git & GitHub: Controle de versão e hospedagem do código.

## Conceitos e Arquitetura Aplicados
- **RESTful Design:** A API segue os princípios REST, utilizando verbos HTTP (GET, POST, PUT, DELETE), status codes padrão e uma estrutura de rotas baseada em recursos.
- **Repository Pattern:** Abstrai a camada de acesso a dados, desacoplando a lógica de negócio das consultas ao Entity Framework.
- **Injeção de Dependência (DI):** Utilizada extensivamente pelo ASP.NET Core para gerenciar o ciclo de vida de serviços e repositórios, promovendo um código de baixo acoplamento e mais testável.
- **DTOs (Data Transfer Objects):** Usados para modelar os dados de entrada (Create, Update) e para formatar os dados de saída, evitando referências circulares e expondo apenas as informações necessárias.
- **Programação Assíncrona (async/await):** Empregada em todas as operações de I/O (principalmente com o banco de dados) para garantir que a API seja performática e não bloqueie threads.


## Como Executar o projeto
Pré-requisitos
- .NET 8 SDK
- Docker
- Git

Passo a Passo
1. Clone o Repositório
```bash
git clone https://github.com/josiasdev/InvestTrackAPI
cd InvestTrackAPI
```

2. Inicie o Banco de Dados com Docker:
Execute o comando abaixo no terminal para criar o contêiner do SQL Server. Lembre-se de trocar a senha!
```bash
    docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=SuaSenhaForte#123" -p 1433:1433 --name sql-invest-track -d mcr.microsoft.com/mssql/server:2022-latest
```

3. Configure a String de Conexão
   Abra o arquivo InvestTrack.API/appsettings.Development.json e garanta que a senha na DefaultConnection é a mesma que você definiu no comando Docker.
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=127.0.0.1;Database=InvestTrackDb;User Id=sa;Password=SuaSenhaForte#123;TrustServerCertificate=True"
  }
}
```

4. Aplique as Migrations do Entity Framework:
   Este comando criará o banco de dados e as tabelas dentro do contêiner.
```bash
dotnet ef database update
```

5. Execute a API:
```bash
dotnet run
```

A API e a documentaçao do swagger estará rodando em https://localhost:7252/swagger/index.html