# ClinicaTEA — Sistema de Gestão para Clínica de TEA

Sistema desktop desenvolvido em **C# Windows Forms (.NET Framework 4.7.2)** para gerenciamento de clínicas especializadas em Transtorno do Espectro Autista (TEA). Inclui controle de pacientes, equipe multidisciplinar, agenda com verificação de conflitos, registro de evoluções de sessão, objetivos terapêuticos e relatórios gerenciais.

---

## Pré-requisitos

| Ferramenta | Versão mínima | Observação |
|---|---|---|
| Windows | 10 / 11 | Compatível com 7 e 8.1 |
| Visual Studio | 2022 (Community) | Com workload **".NET desktop development"** |
| .NET Framework | 4.7.2 | Já incluso no Windows 10+ |
| SQL Server Express | 2019 ou 2022 | Instância padrão `.\SQLEXPRESS` |

> **Atenção:** O projeto **não** usa LocalDB. Certifique-se de que o serviço `MSSQL$SQLEXPRESS` está instalado e **em execução** antes de abrir a aplicação.

---

## Configuração do Banco de Dados

### 1. Criar o banco e as tabelas

Abra o **SQL Server Management Studio (SSMS)** ou o terminal `sqlcmd` e execute o script de schema:

```sql
-- Via SSMS: Arquivo → Abrir → Arquivo... → selecione o arquivo abaixo
-- Via sqlcmd:
sqlcmd -S .\SQLEXPRESS -E -i "DatabaseScripts\schema.sql"
```

O script está em:
```
SolucaoClinicaTEA\DatabaseScripts\schema.sql
```

Ele cria automaticamente o banco `ClinicaTEA` com todas as 9 tabelas, índices e dados iniciais de especialidades e cidades.

### 2. Criar o usuário administrador

Após executar o schema, crie o primeiro usuário administrador executando a aplicação uma vez e acessando diretamente o banco, ou utilize o seguinte script de exemplo (substitua o hash pelo gerado pela classe `CriptografiaSenha`):

```sql
USE ClinicaTEA;

-- Exemplo de seed manual (hash e salt de EXEMPLO — não use em produção)
-- O hash correto deve ser gerado pela própria aplicação via CriptografiaSenha.CalcularHash()
INSERT INTO Usuarios (Login, SenhaHash, Salt, Nome, Perfil, Ativo)
VALUES (
    'admin',
    'SEU_HASH_AQUI',   -- CriptografiaSenha.CalcularHash(salt, "suaSenha")
    'SEU_SALT_AQUI',   -- CriptografiaSenha.GerarSalt()
    'Administrador',
    'Admin',
    1
);
```

---

## Compilação e Execução

### Via Visual Studio (recomendado)

1. Clone ou descompacte o repositório.
2. Abra o arquivo de solução:
   ```
   SolucaoClinicaTEA\SolucaoClinicaTEA\SolucaoClinicaTEA.slnx
   ```
3. Verifique que o projeto **CT_Win** está configurado como projeto de inicialização (negrito no Solution Explorer).
4. Pressione **F5** (Debug) ou **Ctrl+F5** (sem debug) para compilar e executar.

### Via linha de comando (MSBuild)

```powershell
# Localizar o MSBuild (caminho padrão VS 2022)
$msbuild = "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe"

# Compilar em Release
& $msbuild "SolucaoClinicaTEA\SolucaoClinicaTEA\SolucaoClinicaTEA.slnx" /p:Configuration=Release /v:minimal

# Executável gerado em:
# SolucaoClinicaTEA\CT_Win\bin\Release\CT_Win.exe
```

---

## String de Conexão

A string de conexão está em `CT_Win\App.config`:

```xml
<add name="ClinicaTEA"
     connectionString="Data Source=.\SQLEXPRESS;
                       Initial Catalog=ClinicaTEA;
                       Integrated Security=true;"
     providerName="System.Data.SqlClient" />
```

Se a sua instância do SQL Server Express tiver um nome diferente (ex.: `SQLEXPRESS2022`), altere o valor de `Data Source` para `.\SQLEXPRESS2022`.

---

## Estrutura do Repositório

```
ClinicaTEA/
├── SolucaoClinicaTEA/
│   ├── CT_Negocio/          ← Camada de negócio (DAOs, modelos, serviços)
│   ├── CT_Win/              ← Camada de apresentação (Windows Forms)
│   └── DatabaseScripts/
│       └── schema.sql       ← Script de criação do banco de dados ⬅ COMECE AQUI
├── relatorio_final.md       ← Documentação ABNT do projeto
├── .gitignore
└── README.md
```

---

## Dependências NuGet

| Pacote | Versão | Uso |
|---|---|---|
| Dapper | 2.1.72 | ORM leve para mapeamento SQL → POCO |
| FontAwesome.Sharp | 6.6.0 | Ícones vetoriais na interface |
| Microsoft.Bcl.AsyncInterfaces | 9.0.1 | Dependência transitiva do Dapper |

As dependências são restauradas automaticamente pelo Visual Studio ou via MSBuild:
```powershell
$msbuild = "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe"
& $msbuild "SolucaoClinicaTEA\SolucaoClinicaTEA\SolucaoClinicaTEA.slnx" /t:Restore /p:RestorePackagesConfig=true /v:minimal
```

> **Atenção:** O comando `nuget restore` requer o `nuget.exe` instalado separadamente. O comando MSBuild acima funciona sem instalação adicional.

---

## Funcionalidades Principais

- ✅ Autenticação com hash SHA-256 + salt por usuário
- ✅ Cadastro completo de pacientes com dados clínicos do TEA (nível DSM-5, CIPTEA)
- ✅ Gestão de equipe multidisciplinar por especialidade
- ✅ Agenda com verificação automática de conflitos de horário
- ✅ Registro de evolução de sessão (humor, engajamento, conteúdo clínico)
- ✅ Objetivos terapêuticos por paciente/especialidade com percentual de atingimento
- ✅ 7 tipos de relatórios com filtro de período e impressão

---

## Licença

Projeto acadêmico — Disciplina: Tópicos em Linguagem de Programação I  
Curso: Engenharia de Computação | Professor: Prof. Datorre  
Aluno: João Vitor Vissani da Silva Siani — 2026
