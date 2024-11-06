# Lead Management API

Bem-vindo(a) ao projeto de Gerenciamento de Leads em .NET! Aqui, você encontra tudo que precisa para rodar o projeto no seu ambiente.

## Pré-requisitos

- [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/) – escolhe o que te deixa mais confortável!
- [.NET SDK 8.0](https://dotnet.microsoft.com/download) ou superior – quanto mais recente, melhor.
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) ou [SQL Server no Docker](https://learn.microsoft.com/pt-br/sql/linux/quickstart-install-connect-docker?view=sql-server-ver16&tabs=cli&pivots=cs1-bash) – essencial para o nosso banco de dados.

> **Observação:** Estamos usando o .NET SDK 8.0, então vale conferir se você está com essa versão ou superior pra evitar conflitos.

## Configuração do Ambiente

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/MarcelleTabosa/lead-management-api.git
   cd repositorio
   ```

## Configuração do Banco de Dados

1. **Crie uma instância SQL Server:**
   - Se ainda não instalou o SQL Server, use o link acima e instale ou siga o tutorial para criar um container do SQL Server no Docker.
   - Crie uma nova instância SQL e configure seu usuário e senha de acesso.
   - Use um cliente SQL (pode ser o SQL Server Management Studio ou Azure Data Studio) para criar o banco de dados que vamos usar – por exemplo, `NomeDoBanco`.

2. **Configure a conexão com o banco de dados no projeto:**
   - No arquivo **appsettings.json** (ou **appsettings.Development.json**, se preferir), adicione a string de conexão com o banco de dados que você acabou de criar:

     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=127.0.0.1,1433;Database=NomeDoBanco;User ID=SeuUsuario;Password=SuaSenha;Trusted_Connection=False; TrustServerCertificate=True;"
       }
     }
     ```

## Configuração e Aplicação das Migrations

1. **Atualize a base de dados:**
   - Navegue até o projeto `LeadManagement.Infrastructure.csproj` e execute o comando:

     ```bash
     dotnet ef database update
     ```
> **Observação:** Você não precisa criar as migrations pois estão disponíveis na pasta Migrations no projeto de Infraestrutura.

## Executando o Projeto

Banco de dados pronto? Então bora rodar o projeto com:

1. **Atualize a base de dados:**
   - Navegue até o projeto `LeadManagement.WebApi.csproj` e execute o comando:

```bash
dotnet run
```
