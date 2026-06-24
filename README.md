## 🚀 Api10-EF-Oracle
Exemplo de API relação 1-N em C# ASP.NET Core 10 com banco de dados Oracle.

#### 📋 O que você vai encontrar neste projeto
| Tecnologia | Descrição |
|-----------|-----------|
| **DTO** | Separação de responsabilidades, desacoplamento de modelos de entrada (Request) e saída (Response) |
| **Eager Loading** | Carregar entidades relacionadas na mesma consulta inicial |

 #### ⚠️ String de conexão do banco
- Modifique a string de conexão no arquivo **appsettings.json**, no trecho indicado:
```bash
"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=[SEU_NOMECOMPUTADOR].mshome.net)(PORT=1521))(CONNECT_DATA=[SEU_NOMECOMPUTADOR].mshome.net));User Id=[SEU_USUARIO];Password=[SUASENHA];"
```

#### 🔄 Executar a Aplicação
No Visual Studio Abra Ferramentas -> Gerenciador de Pacotes NuGet -> Console do Gerenciador de Pacotes Nuget  
Necessário para Atualizar o Depurador com a Solução. 

- Instalar pacotes necessários (Obrigatório)
```bash
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Design
```
* Usar o comando Add-Migration para Code First
```bash
Add-Migration InitialCreate -StartupProject "SimplesOracleEF"
```
- Aplicar criação das tabelas no Oracle

```bash
Update-Database -StartupProject "SimplesOracleEF"
```
As tabelas **Vendedores e Produtos ** são criada antes da execução.

- Após o Migrations, executa a aplicação **https://localhost:7232/Swagger/index.html** (ou na porta exibida no terminal). 

#### 🧪 Executar Endpoints
| Metodo | Descrição |
|-----------|-----------|
| GET/POST /api/Vendedor | Listar / Criar vendedores |
| GET/PUT/DELETE /api/Vendedor/{id} |  Obter / Atualizar / Excluir vendedor |
| GET/POST /api/Produtos | Listar / Criar produtos |
| GET/PUT/DELETE /api/Produtos/{id}  | Obter / Atualizar / Excluir produto |


