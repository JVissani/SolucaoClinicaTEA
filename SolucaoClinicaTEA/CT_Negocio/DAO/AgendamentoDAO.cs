using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using CT_Negocio.Infraestrutura;
using CT_Negocio.Mapeamento;

namespace CT_Negocio.DAO
{
    public class AgendamentoDAO
    {
        private readonly Conexao _conexao = new Conexao();

        private const string SqlComJoins = @"
            select
                a.ID, a.IDPaciente, a.IDProfissional, a.IDSala,
                a.DataHoraInicio, a.DataHoraFim, a.Status, a.Observacao,
                a.IDUsuarioCadastro, a.DataCadastro,
                p.ID,  p.Nome,  p.NomeSocial,
                pr.ID, pr.Nome, pr.NomeSocial, pr.IDEspecialidade, pr.RegistroConselho,
                e.ID,  e.Nome,  e.ConselhoSigla, e.CorHex,
                s.ID,  s.Nome
            from Agendamentos a
            inner join Pacientes     p  on p.ID  = a.IDPaciente
            inner join Profissionais pr on pr.ID = a.IDProfissional
            inner join Especialidades e on e.ID  = pr.IDEspecialidade
            inner join Salas          s on s.ID  = a.IDSala ";

        private static List<Agendamento> Mapear(IDbConnection conn, string sql, object param = null)
        {
            return conn.Query<Agendamento, Paciente, Profissional, Especialidade, Sala, Agendamento>(
                sql,
                (ag, pac, prof, esp, sala) =>
                {
                    prof.Especialidade = esp;
                    ag.Paciente        = pac;
                    ag.Profissional    = prof;
                    ag.Sala            = sala;
                    return ag;
                },
                param,
                splitOn: "ID,ID,ID,ID"
            ).ToList();
        }

        public List<Agendamento> ListarPorPeriodo(DateTime de, DateTime ate, string statusFiltro = null)
        {
            var sql = SqlComJoins + " where a.DataHoraInicio >= @De and a.DataHoraInicio < @Ate ";
            if (!string.IsNullOrEmpty(statusFiltro)) sql += " and a.Status = @Status ";
            sql += " order by a.DataHoraInicio";

            using (IDbConnection conn = _conexao.CriarConexao())
                return Mapear(conn, sql, new { De = de, Ate = ate, Status = statusFiltro });
        }

        public List<Agendamento> ListarProximos()
        {
            return ListarPorPeriodo(DateTime.Today, DateTime.Today.AddMonths(3));
        }

        public List<Agendamento> ListarRealizados()
        {
            return ListarPorPeriodo(DateTime.Today.AddMonths(-3), DateTime.Today.AddDays(1), "Realizado");
        }

        public List<Agendamento> ListarFaltas()
        {
            return ListarPorPeriodo(DateTime.Today.AddMonths(-3), DateTime.Today.AddDays(1), "Faltou");
        }

        // Retorna true se profissional ou sala já ocupados no intervalo
        public bool TemConflito(int idProfissional, int idSala, DateTime inicio, DateTime fim, int idIgnorar = 0)
        {
            const string sql = @"
                select count(1) from Agendamentos
                where Status not in ('Cancelado', 'Faltou')
                  and ID <> @IDIgnorar
                  and DataHoraInicio < @Fim
                  and DataHoraFim    > @Inicio
                  and (IDProfissional = @IDProf or IDSala = @IDSala)";

            using (IDbConnection conn = _conexao.CriarConexao())
            {
                return conn.QuerySingle<int>(sql, new
                {
                    IDProf    = idProfissional,
                    IDSala    = idSala,
                    Inicio    = inicio,
                    Fim       = fim,
                    IDIgnorar = idIgnorar
                }) > 0;
            }
        }

        public Agendamento Buscar(int id)
        {
            var sql = SqlComJoins + " where a.ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return Mapear(conn, sql, new { ID = id }).FirstOrDefault();
        }

        public int Inserir(Agendamento a)
        {
            const string sql = @"
                insert into Agendamentos
                    (IDPaciente, IDProfissional, IDSala, DataHoraInicio, DataHoraFim,
                     Status, Observacao, IDUsuarioCadastro)
                values
                    (@IDPaciente, @IDProfissional, @IDSala, @DataHoraInicio, @DataHoraFim,
                     @Status, @Observacao, @IDUsuarioCadastro);
                select cast(SCOPE_IDENTITY() as int);";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.QuerySingle<int>(sql, a);
        }

        public int Alterar(Agendamento a)
        {
            const string sql = @"
                update Agendamentos
                set IDPaciente     = @IDPaciente,
                    IDProfissional = @IDProfissional,
                    IDSala         = @IDSala,
                    DataHoraInicio = @DataHoraInicio,
                    DataHoraFim    = @DataHoraFim,
                    Status         = @Status,
                    Observacao     = @Observacao
                where ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, a);
        }

        public int AtualizarStatus(int id, string novoStatus)
        {
            const string sql = "update Agendamentos set Status = @Status where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, new { Status = novoStatus, ID = id });
        }

        // Delete físico — só deve ser chamado quando não há EvolucaoSessao vinculada
        public int Excluir(int id)
        {
            const string sql = "delete from Agendamentos where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, new { ID = id });
        }
    }
}
