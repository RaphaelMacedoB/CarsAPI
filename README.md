# README: Sistema Simplificado de Venda de Carros API

## Visão Geral

Este documento descreve a API do Sistema Simplificado de Venda de Carros, projetada para facilitar a gestão e operação de vendas de carros. A API é desenvolvida usando C# e ASP.NET Core, aderindo aos princípios de design RESTful. Ela é estruturada em torno de quatro entidades principais: `Cars`, `Client`, `Seller`, e `Sale`.

## Entidades e Estrutura

### Cars (Carros)
Representa os carros disponíveis para venda. Atributos incluem identificador único, modelo, e quantidade.

### Client (Clientes)
Detalha os clientes potenciais ou existentes, incluindo informações como identificador único, nome, endereço de e-mail.

### Seller (Vendedores)
Define os vendedores da concessionária, abrangendo detalhes como identificador único, nome e email.

### Sale (Vendas)
Registra as vendas realizadas, associando carros, clientes e vendedores. Contém informações como identificador único da venda, identificador do carro, identificador do cliente, identificador do vendedor e a data da venda.

## Tecnologias e Padrões Utilizados

- **C# e ASP.NET Core**: Linguagem e framework escolhidos para o desenvolvimento da API.
- **Swagger/OpenAPI**: Utilizado para documentar a API, proporcionando uma interface interativa para explorar seus endpoints e a estrutura de dados. A documentação é automaticamente gerada e pode ser acessada navegando até `/swagger` no servidor da aplicação.
- **Padrão Repository**: Implementado para abstrair a camada de acesso a dados, facilitando a manutenção e testabilidade do código. Cada entidade possui seu próprio repositório.
- **DTO (Data Transfer Objects)**: Usado para transferir dados entre o cliente e o servidor de forma eficiente, contendo apenas os dados necessários para uma operação específica. Os DTOs são utilizados tanto para a entrada de dados nos endpoints quanto para a resposta da API.

## Iniciando

Para executar a API localmente, você precisará do .NET Core SDK instalado em sua máquina. Clone o repositório, navegue até o diretório do projeto e execute o comando `dotnet run`. A aplicação estará acessível via `localhost` na porta especificada, e a documentação do Swagger pode ser visualizada acessando `/swagger`.
