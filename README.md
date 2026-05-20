## 🚀 WebApi-Simples-Oracle-EF10

Exemplo de criação de WebAPI relação 1-N com banco de dados Oracle.

#### O que você vai encontrar neste projeto

| Tecnologia | Descrição |
|-----------|-----------|
| **Eager Loading** | Carregar entidades relacionadas na mesma consulta inicial |
| **DTO** | Separação de responsabilidades, desacoplamento de modelos de entrada (Request) e saída (Response) |

#### Requisitos e Detalhe do uso de EntityFrameworkCore 10

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
  
#### Execução da Aplicação

- Após o Migrations, executa a aplicação **https://localhost:7232/Swagger/index.html** (ou na porta exibida no terminal). 

#### 🧪 Execução de Endpoints
| Metodo | Descrição |
|-----------|-----------|
| Metodo: GET/POST /api/Vendedores | Função: Listar / Criar produtos |
| Metodo: GET/PUT/DELETE /api/Vendedores/{id} | Função: Obter / Atualizar / Excluir produto |
| Metodo: GET/POST /api/Produtos | Função: Listar / Criar produtos |
| Metodo: GET/PUT/DELETE /api/Produtos/{id}  | Função: Obter / Atualizar / Excluir produto |

⚠️ String de conexão do banco
Modifique a string de conexão no arquivo **appsettings.json**, no trecho indicado:

```bash
"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=[SEU_NOMECOMPUTADOR].mshome.net)(PORT=1521))(CONNECT_DATA=[SEU_NOMECOMPUTADOR].mshome.net));User Id=[SEU_USUARIO];Password=[SUASENHA];"
```


