# ListaDeTarefas.Api

## 📌 Descrição

API REST desenvolvida em .NET para gerenciamento de tarefas.
O projeto foi criado como parte de um desafio técnico e permite realizar operações completas de CRUD (Create, Read, Update, Delete), além de possibilitar o filtro de tarefas por status.

A aplicação foi estruturada seguindo uma organização em camadas (Controller, Service e Repository), com o objetivo de manter separação de responsabilidades e facilitar manutenção e entendimento do código.

## 🚀 Funcionalidades

A API oferece as seguintes funcionalidades:
- **Criação de tarefas:** permite cadastrar novas tarefas informando título e descrição
- **Listagem de tarefas:** retorna todas as tarefas cadastradas no sistema
- **Consulta por ID:** possibilita buscar uma tarefa específica
- **Atualização de tarefas:** permite alterar dados e status de uma tarefa existente
- **Remoção de tarefas:** exclui uma tarefa do banco de dados
- **Filtro por status:** permite consultar tarefas com base no seu estado (ex: pendente, em andamento, concluída)
- **Documentação interativa:** interface Swagger para teste dos endpoints

## 🛠️ Tecnologias Utilizadas

O projeto foi desenvolvido utilizando as seguintes tecnologias:

- **.NET 10 / ASP.NET Core Web API:** utilizado para construção da API REST 
- **Entity Framework Core:** ORM responsável pelo mapeamento objeto-relacional 
- **PostgreSQL:** banco de dados relacional utilizado para persistência dos dados 
- **Docker:** utilizado para execução do banco de dados em container 
- **Swagger / OpenAPI:** utilizado para documentação e testes da API 

## ⚙️ Como executar o projeto

### 📋 Pré-requisitos
Antes de iniciar, é necessário ter instalado:
- .NET SDK
- Docker Desktop

### 🐘 Subindo o banco de dados (PostgreSQL)
Para iniciar o banco de dados, execute o comando abaixo:
```bash
docker run --name postgres-listatarefas \
-e POSTGRES_PASSWORD=postgres \
-e POSTGRES_DB=listatarefasdb \
-p 5432:5432 \
-d postgres
```
Caso o container já tenha sido criado anteriormente, utilize:
```bash
docker start postgres-listatarefas
```

### ▶️ Executando a aplicação
Com o banco em execução, navegue até a pasta do projeto e execute:
```bash
dotnet restore
```
```bash
dotnet ef database update
```
```bash
dotnet run
```
Esses comandos irão restaurar dependências, aplicar as migrations no banco de dados e iniciar a aplicação.

## 📄 Documentação da API
Após iniciar a aplicação, a documentação interativa pode ser acessada em:
[http://localhost:5007/swagger](http://localhost:5007/swagger)
Através do Swagger é possível visualizar todos os endpoints disponíveis e realizar testes diretamente pela interface.

## 📂 Estrutura do projeto
O projeto está organizado nas seguintes camadas:
- **Controllers:** responsáveis por receber as requisições HTTP e retornar as respostas.
- **Services:** concentram as regras de negócio da aplicação.
- **Repositories:** responsáveis pela comunicação com o banco de dados.
- **Data:** contém a configuração do DbContext e conexão com o banco.
- **Models:** representam as entidades do sistema.
- **DTOs:** utilizados para transferência de dados entre as camadas.
- **Enums:** definem valores fixos, como o status das tarefas.
e essa organização foi adotada para manter o código mais estruturado e de fácil manutenção.

## 📌 Observações
a) As datas são armazenadas em UTC para evitar problemas com fuso horário;
b) O banco de dados é executado em container Docker;
c) A aplicação segue uma arquitetura simples em camadas;
d) O projeto foi desenvolvido com foco no backend, conforme o escopo do desafio.

## 👨‍💻 Autor 
João Vitor Souza
