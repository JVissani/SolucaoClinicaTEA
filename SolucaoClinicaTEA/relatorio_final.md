<!--
  INSTRUÇÕES PARA CONVERSÃO EM PDF:
  1. Abra este arquivo em um editor Markdown (VS Code + extensão "Markdown PDF",
     Typora, ou pandoc via linha de comando).
  2. Insira os prints de tela nos locais marcados com <img src="prints/3_01_login.png" alt="3.1 Tela de Login" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">.
  3. Exporte para PDF mantendo margens de 3 cm (superior/esquerda) e 2 cm (inferior/direita)
     conforme ABNT NBR 14724.
-->

---

<div align="center">

# CENTRO UNIVERSITÁRIO DE VOTUPORANGA – UNIFEV

**Curso:** Engenharia de Computação

**Disciplina:** Tópicos em Linguagem de Programação I

**Professor:** Prof. Datorre

**Aluno:** João Vitor Vissani da Silva Siani

**Local:** Votuporanga, SP

**Ano:** 2026

</div>

---

<div style="page-break-after: always;"></div>

## SUMÁRIO

1. [Introdução](#1-introdução)
2. [Desenvolvimento](#2-desenvolvimento)
   - 2.1 [Estrutura Geral do Projeto](#21-estrutura-geral-do-projeto)
   - 2.2 [Linguagem e Framework](#22-linguagem-e-framework)
   - 2.3 [Banco de Dados e Justificativa](#23-banco-de-dados-e-justificativa)
   - 2.4 [Principais Funcionalidades](#24-principais-funcionalidades)
   - 2.5 [Regras de Negócio](#25-regras-de-negócio)
3. [Telas do Sistema](#3-telas-do-sistema)
4. [Envio da Solução](#4-envio-da-solução)

---

<div style="page-break-after: always;"></div>

## 1. Introdução

O Transtorno do Espectro Autista (TEA) é uma condição neurológica permanente que afeta o desenvolvimento da comunicação, da interação social e do comportamento. No Brasil, estima-se que mais de dois milhões de pessoas sejam diagnosticadas com TEA, número que vem crescendo à medida que os critérios diagnósticos do DSM-5 se consolidam na prática clínica. Clínicas especializadas no atendimento a essas pessoas enfrentam um desafio operacional específico: gerenciar equipes multidisciplinares — psicólogos, fonoaudiólogos, terapeutas ocupacionais, fisioterapeutas e psicopedagogos — que atendem o mesmo paciente de forma simultânea e integrada.

A motivação deste projeto surgiu da observação de que clínicas de pequeno e médio porte frequentemente utilizam planilhas eletrônicas ou agendas em papel para controlar consultas, registrar evoluções e acompanhar objetivos terapêuticos. Esse modelo fragmentado dificulta a comunicação entre especialidades, aumenta o risco de erros de agendamento por sobreposição de horários e impossibilita uma visão gerencial integrada dos atendimentos.

A solução proposta é o **ClinicaTEA**, um sistema desktop de gestão clínica desenvolvido em C# Windows Forms com banco de dados relacional. O sistema cobre o ciclo completo de um atendimento: desde o cadastro do paciente com dados clínicos específicos do TEA, passando pelo agendamento com verificação automática de conflitos, até o registro de evoluções de sessão e acompanhamento de objetivos terapêuticos por especialidade. Um módulo de relatórios fornece indicadores quantitativos sobre frequência, faltas, ocupação de salas e progresso dos objetivos, apoiando decisões de gestão.

O público-alvo são clínicas de reabilitação e centros terapêuticos especializados em TEA. Os usuários diretos do sistema são recepcionistas (responsáveis pelo agendamento e cadastro de pacientes), profissionais de saúde (que registram evoluções e objetivos terapêuticos) e administradores (que gerenciam equipe, salas e relatórios). O cenário de uso típico inicia com a chegada de um novo paciente: a recepcionista cadastra seus dados clínicos, o profissional responsável define objetivos terapêuticos e, a cada sessão realizada, registra uma evolução estruturada. O gestor, ao final do mês, consulta os relatórios para analisar taxa de realização e desempenho da equipe.

---

<div style="page-break-after: always;"></div>

## 2. Desenvolvimento

### 2.1 Estrutura Geral do Projeto

O projeto foi organizado em duas camadas separadas dentro da mesma solução Visual Studio (arquivo `.slnx`):

```
SolucaoClinicaTEA/
├── CT_Negocio/              ← Camada de negócio e dados
│   ├── Infraestrutura/
│   │   ├── Conexao.cs           (fábrica de conexões, lê App.config)
│   │   └── CriptografiaSenha.cs (SHA-256 + salt para senhas)
│   ├── Mapeamento/              (classes POCO — espelham as tabelas do banco)
│   │   ├── Agendamento.cs
│   │   ├── Cidade.cs
│   │   ├── Especialidade.cs
│   │   ├── EvolucaoSessao.cs
│   │   ├── ObjetivoTerapeutico.cs
│   │   ├── Paciente.cs
│   │   ├── Profissional.cs
│   │   ├── Sala.cs
│   │   └── Usuario.cs
│   ├── DAO/                     (acesso a dados via Dapper)
│   │   ├── AgendamentoDAO.cs
│   │   ├── CidadeDAO.cs
│   │   ├── EspecialidadeDAO.cs
│   │   ├── EvolucaoSessaoDAO.cs
│   │   ├── ObjetivoTerapeuticoDAO.cs
│   │   ├── PacienteDAO.cs
│   │   ├── ProfissionalDAO.cs
│   │   ├── RelatorioDAO.cs
│   │   ├── SalaDAO.cs
│   │   └── UsuarioDAO.cs
│   └── Servicos/
│       ├── AutenticacaoServico.cs
│       └── ResultadoAutenticacao.cs
│
└── CT_Win/                  ← Camada de apresentação (Windows Forms)
    ├── Forms/
    │   ├── LoginForm              (autenticação)
    │   ├── PrincipalForm          (janela principal / dashboard)
    │   ├── AgendamentoForm        (modal de novo/editar agendamento)
    │   ├── PacienteForm           (modal de cadastro/edição de paciente)
    │   ├── ProfissionalForm       (modal de cadastro/edição de profissional)
    │   ├── SalaForm               (modal de cadastro/edição de sala)
    │   ├── EspecialidadeForm      (modal de especialidade com preview de cor)
    │   ├── EvolucaoSessaoForm     (modal de registro de evolução)
    │   ├── ObjetivoItemForm       (modal de objetivo terapêutico)
    │   ├── ObjetivosForm          (lista de objetivos de um paciente)
    │   └── RelatorioViewerForm    (visualizador genérico com impressão)
    ├── UserControls/
    │   ├── AgendaUserControl      (módulo de agenda — tela cheia)
    │   ├── PacienteUserControl    (módulo de pacientes)
    │   ├── ProfissionalUserControl
    │   ├── EspecialidadeUserControl
    │   ├── SalaUserControl
    │   └── RelatorioUserControl   (painel de seleção de relatórios)
    └── Recursos/
        └── Theme.cs               (paleta de cores e fontes centralizada)
```

A separação em dois projetos garante que a camada `CT_Negocio` não possui nenhuma dependência da camada de apresentação, tornando-a reutilizável em outros tipos de interface (web, mobile) sem modificação.

### 2.2 Linguagem e Framework

O sistema foi desenvolvido em **C# com .NET Framework 4.7.2**, utilizando o modelo de interface gráfica **Windows Forms**. A escolha do .NET Framework 4.7.2 (em vez de .NET 6+) garante compatibilidade máxima com o parque de computadores de clínicas que ainda operam com Windows 7 ou Windows 8.1, comum em ambientes de saúde de menor porte.

O Windows Forms foi adotado por permitir construção rápida de interfaces de desktop ricas, com controles familiares ao usuário final (grades, formulários modais, menus de contexto), sem exigir infraestrutura de servidor web ou acesso à internet. A experiência de uso é completamente local, o que é um requisito de segurança importante para dados clínicos sensíveis.

A biblioteca **Dapper 2.1.72** foi utilizada como ORM leve sobre o `System.Data.SqlClient`. O Dapper mapeia automaticamente os resultados das consultas SQL para as classes POCO de mapeamento, eliminando código repetitivo de leitura de `DataReader`, mas mantendo controle total sobre as queries — importante para consultas com múltiplos JOINs como as da agenda. A biblioteca **FontAwesome.Sharp 6.6.0** fornece ícones vetoriais para a interface.

### 2.3 Banco de Dados e Justificativa

O banco de dados utilizado é o **Microsoft SQL Server Express** (instância `.\SQLEXPRESS`), com autenticação integrada do Windows (Integrated Security). A conexão é configurada no arquivo `CT_Win/App.config`:

```xml
<add name="ClinicaTEA"
     connectionString="Data Source=.\SQLEXPRESS;
                       Initial Catalog=ClinicaTEA;
                       Integrated Security=true;"
     providerName="System.Data.SqlClient" />
```

A escolha do SQL Server Express se justifica por três motivos principais:

1. **Gratuidade e integração nativa:** O SQL Server Express é distribuído gratuitamente pela Microsoft e se integra nativamente com o ecossistema .NET/C#, sem necessidade de drivers adicionais além do `System.Data.SqlClient`.
2. **Confiabilidade como serviço Windows:** Diferentemente de instâncias LocalDB (que são iniciadas por usuário e podem parar automaticamente por inatividade), o SQL Server Express roda como serviço do Windows com início automático, garantindo disponibilidade permanente da aplicação em produção.
3. **Capacidade suficiente para o porte:** O limite de 10 GB por banco de dados do Express é mais que suficiente para o volume de dados de uma clínica de pequeno e médio porte.

O banco possui **9 tabelas** com o seguinte diagrama de entidades:

```
Cidades ←── Pacientes ──→ Agendamentos ──→ EvolucoesSessao
                │               │
                │               └──→ Profissionais ──→ Especialidades
                │               └──→ Salas
                │               └──→ Usuarios
                └──→ ObjetivosTerapeuticos ──→ Especialidades
```

### 2.4 Principais Funcionalidades

**Autenticação e controle de acesso**
O sistema exige login com usuário e senha. Senhas nunca são armazenadas em texto plano: a classe `CriptografiaSenha` gera um salt aleatório (GUID) por usuário e computa `SHA-256(salt + senha)` em UTF-16 LE para compatibilidade com a função `HASHBYTES` do SQL Server. O resultado é armazenado como hexadecimal de 64 caracteres. Três perfis de acesso são suportados: `Admin`, `Recepcao` e `Profissional`.

**Cadastro de Pacientes**
O formulário de paciente coleta dados gerais (nome, nome social, CPF com validação de dígitos verificadores, data de nascimento, sexo) e dados clínicos específicos do TEA: nível de suporte DSM-5 (1, 2 ou 3), data do diagnóstico e número do CIPTEA. Também registra dados do responsável legal. O sistema implementa *soft-delete*: ao "excluir" um paciente, apenas o campo `Ativo` é definido como `0`, preservando todo o histórico clínico e de agendamentos.

**Agenda e Agendamentos**
A tela de agenda exibe agendamentos agrupados por data, com filtros rápidos de "Próximos" (até 3 meses à frente), "Realizados" e "Faltas" (últimos 3 meses). Cada agendamento exibe o chip colorido da especialidade do profissional. O formulário de novo agendamento valida, antes de salvar, se o profissional ou a sala já possuem outro agendamento ativo no mesmo intervalo de tempo — regra implementada na query `TemConflito` do `AgendamentoDAO`.

**Evolução de Sessão**
Ao marcar um agendamento como "Realizado", o botão "Registrar evolução" é habilitado. O formulário de evolução registra: conteúdo da sessão, comportamentos observados, próximos objetivos planejados, humor do paciente (escala 1–5) e nível de engajamento (escala 1–5). Cada agendamento permite no máximo uma evolução (constraint `UNIQUE` na FK `IDAgendamento`).

**Objetivos Terapêuticos**
Acessados pelo prontuário do paciente, os objetivos são organizados por especialidade e possuem status (`Em Progresso`, `Concluído`, `Suspenso`) e percentual de atingimento (0–100%). Isso permite acompanhar a evolução do paciente ao longo do tempo em cada área clínica.

**Relatórios**
O módulo de relatórios oferece sete tipos de análise com filtro de período (data inicial e final):

| Relatório | Descrição |
|---|---|
| Frequência por Paciente | Total de sessões, realizadas, faltas, canceladas |
| Sessões por Profissional | Produtividade de cada membro da equipe |
| Ocupação de Salas | Taxa de aproveitamento (%) por sala |
| Resumo Geral | Indicadores consolidados do período |
| Pacientes por Profissional | Quais pacientes cada profissional atendeu |
| Objetivos Terapêuticos | Status e percentual de todos os objetivos no período |
| Histórico do Paciente | Timeline completa de agendamentos de um paciente |

Todos os relatórios são exibidos em grade e podem ser impressos via `PrintPreviewDialog`, com layout paginado e geração dinâmica das larguras de coluna.

### 2.5 Regras de Negócio

As principais regras implementadas no código são:

**RN01 — Verificação de conflito de agendamento:**
Antes de inserir ou alterar um agendamento, o sistema executa:
```sql
SELECT COUNT(1) FROM Agendamentos
WHERE Status NOT IN ('Cancelado', 'Faltou')
  AND ID <> @IDIgnorar
  AND DataHoraInicio < @Fim
  AND DataHoraFim    > @Inicio
  AND (IDProfissional = @IDProf OR IDSala = @IDSala)
```
Se o resultado for maior que zero, o cadastro é bloqueado com mensagem ao usuário.

**RN02 — Soft-delete com FK:**
Pacientes e profissionais são desativados (campo `Ativo = 0`) em vez de excluídos. A exclusão física (`ExcluirFisico`) é oferecida apenas para registros sem vínculos, e falha naturalmente por violação de FK caso existam agendamentos associados.

**RN03 — Nome social:**
Toda listagem e exibição utiliza a propriedade calculada `NomeExibicao`, que retorna `NomeSocial` quando preenchido e `Nome` caso contrário, respeitando a identidade do paciente e do profissional.

**RN04 — Evolução vinculada a sessão realizada:**
O botão "Registrar evolução" na agenda só é habilitado quando `Status == "Realizado"`. A tentativa de acessar a evolução de um agendamento não realizado é bloqueada na camada de interface.

**RN05 — Validação de CPF:**
O formulário de paciente implementa a validação completa dos dois dígitos verificadores do CPF (módulo 11), rejeita CPFs com todos os dígitos iguais e verifica duplicidade no banco antes de salvar.

**RN06 — Perfis de usuário:**
O campo `Perfil` (`Admin`, `Recepcao`, `Profissional`) é exibido no cabeçalho da janela principal para indicar o contexto do usuário logado. O ID do usuário logado é propagado como `IDUsuarioCadastro` em todos os agendamentos criados, garantindo rastreabilidade.

---

<div style="page-break-after: always;"></div>

## 3. Telas do Sistema

---

### 3.1 Tela de Login

<img src="prints/3_01_login.png" alt="3.1 Tela de Login" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">

**Objetivo:** Autenticar o usuário antes de conceder acesso ao sistema.

**Interação:** O usuário informa login e senha e clica em "Entrar" (ou pressiona Enter, pois o botão é definido como `AcceptButton` do formulário). Em caso de erro, uma mensagem específica é exibida: "Senha incorreta" limpa apenas o campo de senha; "Usuário não encontrado" limpa ambos os campos. A tela possui fundo branco com campos centralizados e logomarca da clínica, aplicando o tema visual definido em `Theme.cs`.

**Funcionamentos importantes:**
- A senha é validada por `AutenticacaoServico.Autenticar()`, que delega o cálculo do hash a `CriptografiaSenha.Verificar()`.
- Ao logar com sucesso, o `PrincipalForm` é aberto e o `LoginForm` é ocultado (não fechado), retornando ao login ao encerrar a sessão.
- Usuários com `Ativo = 0` no banco recebem a mensagem "Este usuário foi desativado".

---

### 3.2 Dashboard Principal

<img src="prints/3_02_dashboard.png" alt="3.2 Dashboard Principal" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">

**Objetivo:** Servir como ponto de navegação central do sistema, exibindo as seis áreas funcionais disponíveis.

**Interação:** O usuário vê seis cards clicáveis: Pacientes, Profissionais, Agenda, Especialidades, Salas e Relatórios. Ao clicar em um card, o `UserControl` correspondente é carregado no painel de conteúdo da janela, sem abrir uma nova janela. O nome e perfil do usuário logado são exibidos no cabeçalho.

**Funcionamentos importantes:**
- Os cards possuem efeito de hover (fundo azul claro ao passar o mouse).
- O layout dos cards se reposiciona automaticamente quando a janela é redimensionada (`RepositionarTudo`).
- O botão "Início" presente em todos os módulos retorna a este dashboard.

---

### 3.3 Módulo de Pacientes

<img src="prints/3_03_pacientes_lista.png" alt="3.3 Modulo de Pacientes" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">

**Objetivo:** Listar, buscar, cadastrar, editar e inativar pacientes.

**Interação:** A tela exibe uma grade com colunas personalizadas (nome, CPF, idade, cidade, nível de suporte). Um campo de busca filtra em tempo real por nome, nome social ou CPF. Pills (botões de filtro) permitem ver "Todos", "Ativos" ou "Inativos". Os botões "Editar", "Inativar/Reativar" e "Excluir" ficam habilitados apenas quando há uma linha selecionada.

**Funcionamentos importantes:**
- Duplo-clique em uma linha abre o formulário de edição diretamente.
- "Inativar" executa soft-delete (`Ativo = 0`); "Reativar" reverte essa ação.
- "Excluir" realiza exclusão física — falhará se houver agendamentos vinculados.
- O botão "Objetivos" abre a tela `ObjetivosForm` com os objetivos terapêuticos do paciente selecionado.

---

### 3.4 Formulário de Cadastro/Edição de Paciente

<img src="prints/3_04_paciente_form.png" alt="3.4 Formulario de Paciente" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">

**Objetivo:** Registrar ou atualizar os dados completos de um paciente.

**Interação:** O formulário é aberto como janela modal (`ShowDialog`). Contém campos distribuídos em grupos: dados pessoais, dados clínicos do TEA, dados de contato e dados do responsável legal. O botão "Salvar" valida os dados e fecha o formulário com `DialogResult.OK`.

**Funcionamentos importantes:**
- A validação inclui: nome obrigatório, data de nascimento não futura, nível de suporte DSM-5 obrigatório, cidade obrigatória, CPF com dígitos verificadores corretos e verificação de CPF duplicado.
- `NomeSocial` é opcional; quando preenchido, substitui o nome em todas as listagens.
- `NumeroCIPTEA` armazena o número do Certificado de Identificação da Pessoa com TEA, documento regulamentado pela Lei 13.977/2020.

---

### 3.5 Módulo de Profissionais

<img src="prints/3_05_profissionais_lista.png" alt="3.5 Modulo de Profissionais" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">

**Objetivo:** Gerenciar a equipe clínica do estabelecimento.

**Interação:** Estrutura idêntica ao módulo de pacientes: grade com busca, pills de filtro por status e botões de ação. A coluna "Especialidade" exibe um chip colorido com o nome da área de atuação, usando a cor configurada em `Especialidades.CorHex`.

**Funcionamentos importantes:**
- Cada profissional é vinculado obrigatoriamente a uma especialidade ativa.
- O campo `IDUsuario` é opcional — um profissional pode ter acesso ao sistema (com login próprio) ou não.
- A exclusão física falha por FK se o profissional possui agendamentos.

---

### 3.6 Formulário de Cadastro/Edição de Profissional

<img src="prints/3_06_profissional_form.png" alt="3.6 Formulario de Profissional" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">

**Objetivo:** Registrar ou atualizar os dados de um membro da equipe clínica.

**Interação:** Modal com campos para nome, nome social, CPF, registro de conselho (ex.: CRP, CREFITO), telefone, e-mail, especialidade e status ativo/inativo. A especialidade é selecionada por ComboBox, filtrada para exibir apenas especialidades ativas.

**Funcionamentos importantes:**
- Nome e especialidade são campos obrigatórios.
- O campo "Registro no Conselho" é livre, permitindo formatos variados por especialidade.

---

### 3.7 Módulo de Especialidades

<img src="prints/3_07_especialidades_lista.png" alt="3.7 Modulo de Especialidades" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">

**Objetivo:** Gerenciar as especialidades clínicas cadastradas (ex.: Psicologia, Fonoaudiologia).

**Interação:** Grade com chips coloridos na coluna "Nome", refletindo a cor configurada para cada especialidade. A coluna "Conselho" exibe a sigla do conselho profissional correspondente.

**Funcionamentos importantes:**
- A cor (`CorHex`) é usada em toda a interface para identificar visualmente a especialidade (chips na agenda, grade de profissionais).
- Inativar uma especialidade a remove dos ComboBoxes de seleção, impedindo novos vínculos sem apagar histórico.

---

### 3.8 Formulário de Cadastro/Edição de Especialidade

<img src="prints/3_08_especialidade_form.png" alt="3.8 Formulario de Especialidade" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">

**Objetivo:** Registrar ou atualizar uma especialidade clínica.

**Interação:** Modal com campos para nome, sigla do conselho profissional e cor em formato hexadecimal (#RRGGBB). Ao digitar uma cor válida, um painel de preview exibe a cor em tempo real.

**Funcionamentos importantes:**
- O preview de cor usa `ColorTranslator.FromHtml()` e atualiza a cada tecla digitada no campo `txtCorHex`.
- A cor é usada como identificador visual da especialidade em toda a aplicação.

---

### 3.9 Módulo de Salas

<img src="prints/3_09_salas_lista.png" alt="3.9 Modulo de Salas" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">

**Objetivo:** Gerenciar os espaços físicos disponíveis para atendimento.

**Interação:** Grade com nome, capacidade e recursos sensoriais de cada sala. Mesma estrutura de busca, filtros e botões dos demais módulos de cadastro.

**Funcionamentos importantes:**
- O campo "Recursos Sensoriais" registra adaptações do ambiente (ex.: "Isolamento acústico, iluminação regulável"), informação relevante para o perfil sensorial de pacientes com TEA.
- Salas inativas não aparecem nos ComboBoxes de novo agendamento.

---

### 3.10 Módulo de Agenda

<img src="prints/3_10_agenda.png" alt="3.10 Modulo de Agenda" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">

**Objetivo:** Visualizar, criar, editar e gerenciar o status dos agendamentos.

**Interação:** A lista exibe os agendamentos agrupados por data, com cabeçalhos "Hoje" e "Amanhã" destacados. Cada item mostra horário de início/fim, nome do paciente, nome do profissional e chip da especialidade. Pills permitem alternar entre "Próximos" (até 3 meses à frente), "Realizados" (últimos 3 meses) e "Faltas". Um campo de busca filtra por paciente, profissional ou especialidade.

**Funcionamentos importantes:**
- Um dot colorido indica o status: verde (Agendado), verde escuro (Realizado), vermelho (Faltou), cinza (Cancelado).
- O botão "Mudar Status" abre um menu de contexto com as quatro opções de status.
- O botão "Registrar/Ver evolução" só fica ativo quando o agendamento está com status "Realizado".

---

### 3.11 Formulário de Novo/Editar Agendamento

<img src="prints/3_11_agendamento_form.png" alt="3.11 Formulario de Agendamento" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">

**Objetivo:** Cadastrar um novo agendamento ou editar um existente.

**Interação:** Modal com seletores de paciente, profissional e sala (ComboBoxes), campos de data e hora de início/fim e status. O botão "Salvar" executa a validação antes de persistir.

**Funcionamentos importantes:**
- A validação verifica: todos os campos obrigatórios selecionados, horário de fim posterior ao de início, e ausência de conflito de horário (profissional ou sala já ocupados no intervalo).
- Em modo de edição, o ID do agendamento atual é excluído da verificação de conflito para permitir ajustes sem gerar falso positivo.

---

### 3.12 Formulário de Evolução de Sessão

<img src="prints/3_12_evolucao.png" alt="3.12 Evolucao de Sessao" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">

**Objetivo:** Registrar o relato clínico de uma sessão realizada.

**Interação:** Modal que exibe no cabeçalho o nome do paciente, dados do profissional, sala e duração. Os campos principais são: evolução/conteúdo da sessão (obrigatório), comportamentos observados e próximos objetivos. Escalas de humor (1–5) e engajamento (1–5) são inseridas por campos numéricos.

**Funcionamentos importantes:**
- O campo "Evolução/Conteúdo" é o único obrigatório; os demais são facultativos.
- A constraint `UNIQUE` na tabela `EvolucoesSessao` (coluna `IDAgendamento`) garante no banco que um agendamento não possa ter mais de uma evolução.
- Ao acessar um agendamento que já possui evolução, o formulário carrega os dados existentes para edição.

---

### 3.13 Tela de Objetivos Terapêuticos

<img src="prints/3_13_objetivos_lista.png" alt="3.13 Objetivos Terapeuticos" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">

**Objetivo:** Listar e gerenciar os objetivos terapêuticos de um paciente específico.

**Interação:** Grade com colunas de especialidade, descrição, data de início, previsão de conclusão, status e percentual atingido. Botões "Novo objetivo", "Editar" e "Excluir" na barra inferior.

**Funcionamentos importantes:**
- Os objetivos são organizados por especialidade, refletindo a natureza multidisciplinar do atendimento a pacientes com TEA.
- O status pode ser "Em Progresso", "Concluído" ou "Suspenso".
- Ao fechar esta tela e reabrir, os dados são recarregados do banco para refletir alterações concorrentes.

---

### 3.14 Formulário de Objetivo Terapêutico

<img src="prints/3_14_objetivo_form.png" alt="3.14 Formulario de Objetivo" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">

**Objetivo:** Criar ou editar um objetivo terapêutico vinculado a um paciente e especialidade.

**Interação:** Modal com seletor de especialidade, campo de descrição livre, datas de início e previsão de conclusão, status e percentual de atingimento (0–100).

**Funcionamentos importantes:**
- Especialidade e descrição são campos obrigatórios.
- A data de previsão de fim é opcional (campo `DateTimePicker` com `Checked`); se desmarcado, é gravado como `NULL`.

---

### 3.15 Módulo de Relatórios

<img src="prints/3_15_relatorios.png" alt="3.15 Modulo de Relatorios" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">

**Objetivo:** Oferecer ao gestor uma visão analítica dos atendimentos por período.

**Interação:** A tela exibe cards de seleção para sete tipos de relatório. Ao clicar em um tipo, a janela `RelatorioViewerForm` abre com o relatório já carregado para o período padrão (mês corrente). Relatórios que exigem seleção de paciente (Histórico) abrem um seletor intermediário.

**Funcionamentos importantes:**
- Cada tipo de relatório tem sua própria query SQL parametrizada com `@De` e `@Ate`, executada via `RelatorioDAO`.
- O visualizador exibe os dados em `DataGridView` com a última coluna expandida para preencher a largura disponível.
- O botão "Imprimir" abre o `PrintPreviewDialog` com layout paginado, cabeçalho com título e período, colunas proporcionais ao espaço da página e zebra leve nas linhas.

---

### 3.16 Visualizador de Relatórios

<img src="prints/3_16_visualizador.png" alt="3.16 Visualizador de Relatorios" style="max-width:100%; margin: 12px 0; border: 1px solid #ddd; border-radius: 4px;">

**Objetivo:** Exibir o resultado de um relatório em formato tabular com opção de impressão.

**Interação:** Filtros de período "De" e "Até" permitem refinar o intervalo. O botão "Atualizar" recarrega os dados. O botão "Imprimir" abre o preview de impressão. "Fechar" retorna ao módulo de relatórios.

**Funcionamentos importantes:**
- A impressão é implementada manualmente via `PrintDocument.PrintPage`, com paginação automática e larguras de coluna escalonadas proporcionalmente ao tamanho da página física.
- O cabeçalho impresso inclui título do relatório, período filtrado e data/hora de geração.

---

<div style="page-break-after: always;"></div>

## 4. Envio da Solução

O código-fonte completo deste projeto, incluindo os arquivos de banco de dados, scripts SQL de criação do schema, os binários necessários para compilação e este documento PDF, estão disponíveis no repositório GitHub abaixo:

> **Link do repositório:** [https://github.com/JVissani/SolucaoClinicaTEA](https://github.com/JVissani/SolucaoClinicaTEA)

O repositório foi configurado para acesso público e compartilhado com o e-mail **datorre@gmail.com**. Os arquivos estão organizados na branch `main` e incluem:

- `/SolucaoClinicaTEA/` — código-fonte completo dos projetos `CT_Negocio` e `CT_Win`
- `/DatabaseScripts/schema.sql` — script de criação de todas as tabelas, índices e dados iniciais
- `/relatorio_final.md` e `/relatorio_final.pdf` — este documento de entrega
- `README.md` — instruções de compilação e configuração do ambiente

---

*Documento gerado conforme ABNT NBR 14724:2011 — Informação e documentação — Trabalhos acadêmicos — Apresentação.*
