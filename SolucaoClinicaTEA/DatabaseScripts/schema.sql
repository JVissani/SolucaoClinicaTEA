-- =============================================================================
-- ClinicaTEA -- Schema do Banco de Dados
-- SQL Server Express  |  Banco: ClinicaTEA
-- Gerado a partir do código-fonte do projeto CT_Negocio
-- =============================================================================

USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'ClinicaTEA')
    CREATE DATABASE ClinicaTEA
        COLLATE Latin1_General_CI_AS;
GO

USE ClinicaTEA;
GO

-- ─── Cidades ──────────────────────────────────────────────────────────────────
CREATE TABLE Cidades (
    ID    INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Nome  NVARCHAR(100) NOT NULL,
    UF    CHAR(2)       NOT NULL
);
GO

-- ─── Especialidades ───────────────────────────────────────────────────────────
-- ConselhoSigla: ex. CRP, CREFITO, CRM ...
-- CorHex       : cor #RRGGBB para exibição visual (chips coloridos na agenda)
CREATE TABLE Especialidades (
    ID            INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Nome          NVARCHAR(100) NOT NULL,
    ConselhoSigla NVARCHAR(20)  NULL,
    CorHex        NVARCHAR(7)   NULL,
    Ativo         BIT           NOT NULL DEFAULT 1
);
GO

-- ─── Usuarios ─────────────────────────────────────────────────────────────────
-- Perfil: Admin | Recepcao | Profissional
-- SenhaHash: SHA-256 hexadecimal uppercase (salt + senha, Unicode/UTF-16 LE)
-- Salt     : GUID gerado aleatoriamente por CriptografiaSenha.GerarSalt()
CREATE TABLE Usuarios (
    ID        INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Login     NVARCHAR(60)  NOT NULL UNIQUE,
    SenhaHash NVARCHAR(64)  NOT NULL,
    Salt      NVARCHAR(50)  NOT NULL,
    Nome      NVARCHAR(150) NOT NULL,
    Perfil    NVARCHAR(20)  NOT NULL,
    Ativo     BIT           NOT NULL DEFAULT 1
);
GO

-- ─── Pacientes ────────────────────────────────────────────────────────────────
-- NivelSuporte : 1 = Exigindo apoio | 2 = Apoio substancial | 3 = Apoio muito substancial (DSM-5)
-- NumeroCIPTEA : Certificado de Identificação da Pessoa com TEA
-- Ativo        : soft-delete — histórico clínico é preservado
CREATE TABLE Pacientes (
    ID                  INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    IDCidade            INT           NULL REFERENCES Cidades(ID),
    Nome                NVARCHAR(150) NOT NULL,
    NomeSocial          NVARCHAR(150) NULL,
    CPF                 CHAR(11)      NULL UNIQUE,
    DataNascimento      DATE          NOT NULL,
    Sexo                CHAR(1)       NULL,           -- M | F | O
    NivelSuporte        TINYINT       NULL,
    DataDiagnostico     DATE          NULL,
    NumeroCIPTEA        NVARCHAR(30)  NULL,
    Telefone            NVARCHAR(20)  NULL,
    Email               NVARCHAR(200) NULL,
    NomeResponsavel     NVARCHAR(150) NULL,
    CPFResponsavel      CHAR(11)      NULL,
    TelefoneResponsavel NVARCHAR(20)  NULL,
    Observacoes         NVARCHAR(MAX) NULL,
    Ativo               BIT           NOT NULL DEFAULT 1,
    DataCadastro        DATETIME      NOT NULL DEFAULT GETDATE()
);
GO

-- ─── Profissionais ────────────────────────────────────────────────────────────
-- IDUsuario: opcional — nem todo profissional precisa logar no sistema
CREATE TABLE Profissionais (
    ID               INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    IDUsuario        INT           NULL REFERENCES Usuarios(ID),
    IDEspecialidade  INT           NOT NULL REFERENCES Especialidades(ID),
    Nome             NVARCHAR(150) NOT NULL,
    NomeSocial       NVARCHAR(150) NULL,
    CPF              CHAR(11)      NULL,
    RegistroConselho NVARCHAR(30)  NULL,
    Telefone         NVARCHAR(20)  NULL,
    Email            NVARCHAR(200) NULL,
    Ativo            BIT           NOT NULL DEFAULT 1
);
GO

-- ─── Salas ────────────────────────────────────────────────────────────────────
CREATE TABLE Salas (
    ID                  INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Nome                NVARCHAR(80)  NOT NULL,
    Capacidade          INT           NOT NULL DEFAULT 0,
    RecursosSensoriais  NVARCHAR(500) NULL,
    Ativo               BIT           NOT NULL DEFAULT 1
);
GO

-- ─── Agendamentos ─────────────────────────────────────────────────────────────
-- Status: Agendado | Realizado | Faltou | Cancelado
-- Conflito: profissional ou sala não podem ter sobreposição de horário
CREATE TABLE Agendamentos (
    ID               INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    IDPaciente       INT           NOT NULL REFERENCES Pacientes(ID),
    IDProfissional   INT           NOT NULL REFERENCES Profissionais(ID),
    IDSala           INT           NOT NULL REFERENCES Salas(ID),
    DataHoraInicio   DATETIME      NOT NULL,
    DataHoraFim      DATETIME      NOT NULL,
    Status           NVARCHAR(20)  NOT NULL DEFAULT 'Agendado',
    Observacao       NVARCHAR(500) NULL,
    IDUsuarioCadastro INT          NOT NULL REFERENCES Usuarios(ID),
    DataCadastro     DATETIME      NOT NULL DEFAULT GETDATE()
);
GO

-- ─── EvolucoesSessao ──────────────────────────────────────────────────────────
-- HumorPaciente    : 1 (muito desregulado) a 5 (muito regulado)
-- NivelEngajamento : 1 (sem engajamento) a 5 (totalmente engajado)
CREATE TABLE EvolucoesSessao (
    ID               INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    IDAgendamento    INT           NOT NULL UNIQUE REFERENCES Agendamentos(ID),
    Conteudo         NVARCHAR(MAX) NOT NULL,
    Comportamentos   NVARCHAR(MAX) NULL,
    ProximosObjetivos NVARCHAR(MAX) NULL,
    HumorPaciente    TINYINT       NULL,
    NivelEngajamento TINYINT       NULL,
    DataCadastro     DATETIME      NOT NULL DEFAULT GETDATE()
);
GO

-- ─── ObjetivosTerapeuticos ────────────────────────────────────────────────────
-- Status: EmProgresso | Concluido | Suspenso
CREATE TABLE ObjetivosTerapeuticos (
    ID                    INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    IDPaciente            INT           NOT NULL REFERENCES Pacientes(ID),
    IDEspecialidade       INT           NOT NULL REFERENCES Especialidades(ID),
    Descricao             NVARCHAR(MAX) NOT NULL,
    DataInicio            DATE          NOT NULL,
    DataPrevisaoFim       DATE          NULL,
    Status                NVARCHAR(20)  NOT NULL DEFAULT 'EmProgresso',
    PercentualAtingimento TINYINT       NOT NULL DEFAULT 0
);
GO

-- =============================================================================
-- ÍNDICES
-- =============================================================================

CREATE INDEX IX_Agendamentos_DataHoraInicio ON Agendamentos(DataHoraInicio);
CREATE INDEX IX_Agendamentos_IDPaciente     ON Agendamentos(IDPaciente);
CREATE INDEX IX_Agendamentos_IDProfissional ON Agendamentos(IDProfissional);
CREATE INDEX IX_Agendamentos_IDSala         ON Agendamentos(IDSala);
CREATE INDEX IX_Pacientes_Nome              ON Pacientes(Nome);
CREATE INDEX IX_ObjetivosTerapeuticos_IDPaciente ON ObjetivosTerapeuticos(IDPaciente);
GO

-- =============================================================================
-- SEED INICIAL — usuário administrador (senha: admin123)
-- Salt e hash gerados por CriptografiaSenha.GerarSalt() / CalcularHash()
-- Substitua pelo hash real calculado pela aplicação antes de usar em produção
-- =============================================================================

INSERT INTO Cidades (Nome, UF) VALUES
    ('Macaubal',         'SP'),
    ('São José do Rio Preto', 'SP'),
    ('Votuporanga',      'SP'),
    ('Nhandeara',        'SP');
GO

INSERT INTO Especialidades (Nome, ConselhoSigla, CorHex, Ativo) VALUES
    ('Psicologia',             'CRP',     '#3B82F6', 1),
    ('Fonoaudiologia',         'CRFa',    '#10B981', 1),
    ('Terapia Ocupacional',    'CREFITO', '#F59E0B', 1),
    ('Fisioterapia',           'CREFITO', '#EF4444', 1),
    ('Psicopedagogia',         'ABPp',    '#8B5CF6', 1),
    ('Neurologia',             'CFM',     '#EC4899', 1);
GO
