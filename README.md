# ListaDeTarefas.Api

## Descrição

Esta é uma aplicação fullstack desenvolvida para gerenciamento de tarefas. O projeto foi criado como parte de um desafio técnico e permite realizar operações completas de CRUD (Create, Read, Update e Delete), além de possibilitar o filtro de tarefas por status.

A solução é composta por um backend em .NET e um frontend em Angular, com comunicação via API REST. A arquitetura foi organizada em camadas para garantir separação de responsabilidades, facilitar a manutenção e melhorar a legibilidade do código.

## Funcionalidades

A aplicação oferece as seguintes funcionalidades:
- Criação de tarefas
  - Permite cadastrar novas tarefas informando título e descrição. O status inicial da tarefa é definido como pendente.
- Listagem de tarefas
  - Exibe todas as tarefas cadastradas no sistema.
- Consulta por ID
  - Permite buscar uma tarefa específica pelo identificador.
- Atualização de tarefas
  - Permite editar título, descrição e status de uma tarefa existente.
- Remoção de tarefas
  - Possibilita excluir tarefas do banco de dados.
- Filtro por status
  - Permite visualizar tarefas com base no status (pendente, em andamento ou concluída).
- Interface web
  - O frontend permite interação completa com a API, incluindo criação, edição, exclusão e filtragem de tarefas.

## Tecnologias utilizadas
### Backend
- .NET / ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- Docker
### Frontend
- Angular
- TypeScript
- HTML / CSS 
### Ferramentas adicionais 
- Swagger / OpenAPI para documentação da API 
- Node.js e npm para gerenciamento do frontend 

## Como executar o projeto
### Pré-requisitos 
Antes de iniciar, é necessário ter instalado:
- .NET SDK 
- Docker Desktop 
- Node.js 
- Angular CLI 
### Backend (API)
#### Subindo o banco de dados (PostgreSQL)
```bash
docker run --name postgres-listatarefas 
e POSTGRES_PASSWORD=postgres 
e POSTGRES_DB=listatarefasdb 
p 5432:5432 
d postgres
```

Caso o container já tenha sido criado anteriormente, utilize:
```bash
docker start postgres-listatarefas
```

#### Executando o backend
```bash
dotnet restore
dotnet ef database update
dotnet run
```

Esses comandos irão restaurar as dependências, aplicar as migrations no banco de dados e iniciar a aplicação.
A API estará disponível em:

http://localhost:5007

### Documentação da API
Após iniciar o backend, a documentação interativa pode ser acessada em:

http://localhost:5007/swagger

Através do Swagger é possível visualizar todos os endpoints disponíveis e realizar testes diretamente pela interface.

### Frontend (Angular)

O frontend da aplicação foi desenvolvido em Angular e é responsável por consumir a API do backend e permitir a interação do usuário com a lista de tarefas.

#### Funcionalidades do frontend

def listagem de tarefas
def criação de tarefas
def edição de tarefas
def exclusão de tarefas
def filtro por status
def exibição de mensagens de sucesso
def feedback visual de carregamento

#### Executando o frontend
```bash
cd lista-de-tarefas-ui
npm install
ng serve
```

Após isso, o frontend estará disponível em:

http://localhost:4200

Integração entre frontend e backend
O frontend está configurado para consumir a API em:

http://localhost:5007

Por isso, é necessário que o backend esteja em execução para que a aplicação funcione corretamente.

## Estrutura do projeto
### Backend

- Controllers
  - Responsáveis por receber as requisições HTTP e retornar as respostas.

- Services
  - Contêm as regras de negócio da aplicação.

- Repositories
  - Responsáveis pela comunicação com o banco de dados.

- Data
  - Configuração do DbContext e conexão com o banco.

- Models
  - Representação das entidades do sistema.

- DTOs
  - Objetos utilizados para transferência de dados entre as camadas.

- Enums
  - Definem valores fixos, como o status das tarefas.

### Frontend

- Component principal
  - Responsável pela interface e interação com o usuário.

- Serviços HTTP
  - Responsáveis por consumir a API.

- Templates HTML
  - Estrutura visual da aplicação.

## Observações
- As datas são armazenadas em UTC para evitar problemas com fuso horário.
- O banco de dados é executado em container Docker.
- A aplicação segue uma arquitetura em camadas no backend.
- O frontend consome a API diretamente via HTTP.
- O projeto foi desenvolvido com foco em backend, mas inclui um frontend funcional para interação completa com a API.

## Desenvolvido por João Vitor
