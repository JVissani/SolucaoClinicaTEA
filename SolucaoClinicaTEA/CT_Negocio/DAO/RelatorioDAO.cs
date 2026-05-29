using System;
using System.Data;
using System.Data.SqlClient;
using CT_Negocio.Infraestrutura;

namespace CT_Negocio.DAO
{
    public class RelatorioDAO
    {
        private readonly Conexao _conexao = new Conexao();

        private DataTable Executar(string sql, params SqlParameter[] parametros)
        {
            using (var conn = (SqlConnection)_conexao.CriarConexao())
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    foreach (var p in parametros) cmd.Parameters.Add(p);
                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        private static SqlParameter P(string nome, object valor) =>
            new SqlParameter(nome, valor ?? (object)DBNull.Value);

        public DataTable FrequenciaPorPaciente(DateTime de, DateTime ate) =>
            Executar(@"
                SELECT
                    p.Nome + CASE WHEN p.NomeSocial IS NOT NULL AND p.NomeSocial <> ''
                              THEN ' (' + p.NomeSocial + ')' ELSE '' END AS [Paciente],
                    COUNT(*) AS [Total],
                    SUM(CASE WHEN a.Status = 'Realizado'  THEN 1 ELSE 0 END) AS [Realizados],
                    SUM(CASE WHEN a.Status = 'Faltou'     THEN 1 ELSE 0 END) AS [Faltas],
                    SUM(CASE WHEN a.Status = 'Agendado'   THEN 1 ELSE 0 END) AS [Agendados],
                    SUM(CASE WHEN a.Status = 'Cancelado'  THEN 1 ELSE 0 END) AS [Cancelados]
                FROM Agendamentos a
                INNER JOIN Pacientes p ON p.ID = a.IDPaciente
                WHERE a.DataHoraInicio >= @De AND a.DataHoraInicio < @Ate
                GROUP BY p.ID, p.Nome, p.NomeSocial
                ORDER BY p.Nome",
            P("@De", de), P("@Ate", ate));

        public DataTable SessoesPorProfissional(DateTime de, DateTime ate) =>
            Executar(@"
                SELECT
                    pr.Nome AS [Profissional],
                    e.Nome  AS [Especialidade],
                    COUNT(*) AS [Total],
                    SUM(CASE WHEN a.Status = 'Realizado'  THEN 1 ELSE 0 END) AS [Realizados],
                    SUM(CASE WHEN a.Status = 'Faltou'     THEN 1 ELSE 0 END) AS [Faltas],
                    SUM(CASE WHEN a.Status = 'Cancelado'  THEN 1 ELSE 0 END) AS [Cancelados]
                FROM Agendamentos a
                INNER JOIN Profissionais pr ON pr.ID = a.IDProfissional
                INNER JOIN Especialidades e ON e.ID = pr.IDEspecialidade
                WHERE a.DataHoraInicio >= @De AND a.DataHoraInicio < @Ate
                GROUP BY pr.ID, pr.Nome, e.Nome
                ORDER BY pr.Nome",
            P("@De", de), P("@Ate", ate));

        public DataTable OcupacaoSalas(DateTime de, DateTime ate) =>
            Executar(@"
                SELECT
                    s.Nome AS [Sala],
                    COUNT(*) AS [Total de Sessões],
                    SUM(CASE WHEN a.Status = 'Realizado'  THEN 1 ELSE 0 END) AS [Realizadas],
                    SUM(CASE WHEN a.Status = 'Faltou'     THEN 1 ELSE 0 END) AS [Faltas],
                    SUM(CASE WHEN a.Status = 'Cancelado'  THEN 1 ELSE 0 END) AS [Canceladas],
                    CASE WHEN COUNT(*) > 0
                         THEN CAST(ROUND(
                              100.0 * SUM(CASE WHEN a.Status = 'Realizado' THEN 1 ELSE 0 END)
                              / COUNT(*), 0) AS int)
                         ELSE 0 END AS [% Aproveitamento]
                FROM Agendamentos a
                INNER JOIN Salas s ON s.ID = a.IDSala
                WHERE a.DataHoraInicio >= @De AND a.DataHoraInicio < @Ate
                GROUP BY s.ID, s.Nome
                ORDER BY [Total de Sessões] DESC",
            P("@De", de), P("@Ate", ate));

        public DataTable ResumoGeral(DateTime de, DateTime ate) =>
            Executar(@"
                SELECT
                    (SELECT COUNT(*) FROM Pacientes     WHERE Ativo = 1) AS [Pacientes Ativos],
                    (SELECT COUNT(*) FROM Profissionais WHERE Ativo = 1) AS [Profissionais Ativos],
                    COUNT(*) AS [Total de Agendamentos],
                    SUM(CASE WHEN a.Status = 'Realizado'  THEN 1 ELSE 0 END) AS [Sessões Realizadas],
                    SUM(CASE WHEN a.Status = 'Faltou'     THEN 1 ELSE 0 END) AS [Faltas],
                    SUM(CASE WHEN a.Status = 'Agendado'   THEN 1 ELSE 0 END) AS [Aguardando],
                    SUM(CASE WHEN a.Status = 'Cancelado'  THEN 1 ELSE 0 END) AS [Cancelados],
                    CASE WHEN COUNT(*) > 0
                         THEN CAST(ROUND(
                              100.0 * SUM(CASE WHEN a.Status = 'Realizado' THEN 1 ELSE 0 END)
                              / COUNT(*), 1) AS decimal(5, 1))
                         ELSE 0.0 END AS [Taxa de Realização (%)]
                FROM Agendamentos a
                WHERE a.DataHoraInicio >= @De AND a.DataHoraInicio < @Ate",
            P("@De", de), P("@Ate", ate));

        public DataTable PacientesAtendidosPorProfissional(DateTime de, DateTime ate) =>
            Executar(@"
                SELECT
                    pr.Nome AS [Profissional],
                    e.Nome  AS [Especialidade],
                    p.Nome  + CASE WHEN p.NomeSocial IS NOT NULL AND p.NomeSocial <> ''
                              THEN ' (' + p.NomeSocial + ')' ELSE '' END AS [Paciente],
                    COUNT(*) AS [Sessões Realizadas]
                FROM Agendamentos a
                INNER JOIN Profissionais pr ON pr.ID = a.IDProfissional
                INNER JOIN Especialidades e ON e.ID = pr.IDEspecialidade
                INNER JOIN Pacientes p ON p.ID = a.IDPaciente
                WHERE a.DataHoraInicio >= @De AND a.DataHoraInicio < @Ate
                  AND a.Status = 'Realizado'
                GROUP BY pr.ID, pr.Nome, e.Nome, p.ID, p.Nome, p.NomeSocial
                ORDER BY pr.Nome, p.Nome",
            P("@De", de), P("@Ate", ate));

        public DataTable ObjetivosTerapeuticos(DateTime de, DateTime ate) =>
            Executar(@"
                SELECT
                    p.Nome + CASE WHEN p.NomeSocial IS NOT NULL AND p.NomeSocial <> ''
                              THEN ' (' + p.NomeSocial + ')' ELSE '' END  AS [Paciente],
                    e.Nome          AS [Especialidade],
                    o.Descricao     AS [Objetivo],
                    CONVERT(varchar(10), o.DataInicio, 103)                AS [Início],
                    CASE WHEN o.DataPrevisaoFim IS NOT NULL
                         THEN CONVERT(varchar(10), o.DataPrevisaoFim, 103)
                         ELSE '—' END                                     AS [Previsão],
                    CASE o.Status
                        WHEN 'EmProgresso' THEN 'Em Progresso'
                        WHEN 'Concluido'   THEN 'Concluído'
                        ELSE o.Status END                                 AS [Status],
                    CAST(o.PercentualAtingimento AS varchar) + '%'         AS [% Atingido]
                FROM ObjetivosTerapeuticos o
                INNER JOIN Pacientes p     ON p.ID = o.IDPaciente
                INNER JOIN Especialidades e ON e.ID = o.IDEspecialidade
                WHERE o.DataInicio >= @De AND o.DataInicio < @Ate
                ORDER BY p.Nome, o.DataInicio",
            P("@De", de), P("@Ate", ate));

        public DataTable HistoricoPaciente(int idPaciente, DateTime de, DateTime ate) =>
            Executar(@"
                SELECT
                    CONVERT(varchar, a.DataHoraInicio, 103) + ' ' +
                    CONVERT(varchar(5), a.DataHoraInicio, 108)  AS [Data / Hora],
                    CONVERT(varchar(5), a.DataHoraFim, 108)     AS [Fim],
                    pr.Nome  AS [Profissional],
                    e.Nome   AS [Especialidade],
                    s.Nome   AS [Sala],
                    a.Status AS [Status],
                    ISNULL(a.Observacao, '') AS [Observação]
                FROM Agendamentos a
                INNER JOIN Profissionais pr ON pr.ID = a.IDProfissional
                INNER JOIN Especialidades e ON e.ID = pr.IDEspecialidade
                INNER JOIN Salas s ON s.ID = a.IDSala
                WHERE a.IDPaciente = @IDPaciente
                  AND a.DataHoraInicio >= @De AND a.DataHoraInicio < @Ate
                ORDER BY a.DataHoraInicio",
            P("@IDPaciente", idPaciente), P("@De", de), P("@Ate", ate));
    }
}
