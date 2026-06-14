## 🚀 Api10-EF-Oracle
Exemplo de criação de API relação 1-N com banco de dados Oracle.

#### 📋 O que você vai encontrar neste projeto
| Tecnologia | Descrição |
|-----------|-----------|
| **DTO** | Separação de responsabilidades, desacoplamento de modelos de entrada (Request) e saída (Response) |
| **Eager Loading** | Carregar entidades relacionadas na mesma consulta inicial |

#### Requisitos do Projeto
No Visual Studio Abra (Ferramentas) > (Gerenciador de Pacotes NuGet) > (Console do Gerenciador de Pacotes Nuget)  
Necessário para Atualizar o Depurador com a Solução. 

Certificar em Definir o Projeto Padrão como (SistemaERPOnlineForcaDeVendasAPI.WebAPI)

* Instalar pacotes necessários (Obrigatório)
```bash
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Design
```
* Usar o comando Add-Migration para Code First

```bash
Add-Migration InitialCreate -StartupProject "SimplesOracleEF"
```
* Aplicar criação das tabelas no Oracle

```bash
Update-Database -StartupProject "SimplesOracleEF"
```
As tabelas **Vendedores e Produtos ** são criada antes da execução.

 #### ⚠️ String de conexão do banco
- Modifique a string de conexão no arquivo **appsettings.json**, no trecho indicado:
```bash
"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=[SEU_NOMECOMPUTADOR].mshome.net)(PORT=1521))(CONNECT_DATA=[SEU_NOMECOMPUTADOR].mshome.net));User Id=[SEU_USUARIO];Password=[SUASENHA];"
```

#### 🔄 Executar a Aplicação

- Após o Migrations, executa a aplicação **https://localhost:7232/Swagger/index.html** (ou na porta exibida no terminal). 

#### 🧪 Executar Endpoints
| Metodo | Descrição |
|-----------|-----------|
| Metodo: GET/POST /api/Vendedor | Função: Listar / Criar vendedores |
| Metodo: GET/PUT/DELETE /api/Vendedor/{id} | Função: Obter / Atualizar / Excluir vendedor |
| Metodo: GET/POST /api/Produtos | Função: Listar / Criar produtos |
| Metodo: GET/PUT/DELETE /api/Produtos/{id}  | Função: Obter / Atualizar / Excluir produto |


