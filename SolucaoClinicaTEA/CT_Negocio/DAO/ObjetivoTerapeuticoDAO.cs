using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using CT_Negocio.Infraestrutura;
using CT_Negocio.Mapeamento;

namespace CT_Negocio.DAO
{
    public class ObjetivoTerapeuticoDAO
    {
        private readonly Conexao _conexao = new Conexao();

        public List<ObjetivoTerapeutico> ListarPorPaciente(int idPaciente)
        {
            const string sql = @"
                select
                    o.ID, o.IDPaciente, o.IDEspecialidade, o.Descricao,
                    o.DataInicio, o.DataPrevisaoFim, o.Status, o.PercentualAtingimento,
                    e.ID, e.Nome, e.ConselhoSigla, e.CorHex, e.Ativo
                from ObjetivosTerapeuticos o
                inner join Especialidades e on e.ID = o.IDEspecialidade
                where o.IDPaciente = @IDPaciente
                order by o.DataInicio desc";

            using (IDbConnection conn = _conexao.CriarConexao())
            {
                return conn.Query<ObjetivoTerapeutico, Especialidade, ObjetivoTerapeutico>(
                    sql,
                    (obj, esp) => { obj.Especialidade = esp; return obj; },
                    new { IDPaciente = idPaciente },
                    splitOn: "ID"
                ).ToList();
            }
        }

        public ObjetivoTerapeutico Buscar(int id)
        {
            const string sql = @"
                select
                    o.ID, o.IDPaciente, o.IDEspecialidade, o.Descricao,
                    o.DataInicio, o.DataPrevisaoFim, o.Status, o.PercentualAtingimento,
                    e.ID, e.Nome, e.ConselhoSigla, e.CorHex, e.Ativo
                from ObjetivosTerapeuticos o
                inner join Especialidades e on e.ID = o.IDEspecialidade
                where o.ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
            {
                return conn.Query<ObjetivoTerapeutico, Especialidade, ObjetivoTerapeutico>(
                    sql,
                    (obj, esp) => { obj.Especialidade = esp; return obj; },
                    new { ID = id },
                    splitOn: "ID"
                ).FirstOrDefault();
            }
        }

        public int Inserir(ObjetivoTerapeutico o)
        {
            const string sql = @"
                insert into ObjetivosTerapeuticos
                    (IDPaciente, IDEspecialidade, Descricao,
                     DataInicio, DataPrevisaoFim, Status, PercentualAtingimento)
                values
                    (@IDPaciente, @IDEspecialidade, @Descricao,
                     @DataInicio, @DataPrevisaoFim, @Status, @PercentualAtingimento);
                select cast(SCOPE_IDENTITY() as int);";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.QuerySingle<int>(sql, o);
        }

        public void Alterar(ObjetivoTerapeutico o)
        {
            const string sql = @"
                update ObjetivosTerapeuticos
                set IDEspecialidade      = @IDEspecialidade,
                    Descricao            = @Descricao,
                    DataInicio           = @DataInicio,
                    DataPrevisaoFim      = @DataPrevisaoFim,
                    Status               = @Status,
                    PercentualAtingimento = @PercentualAtingimento
                where ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
                conn.Execute(sql, o);
        }

        public void Excluir(int id)
        {
            const string sql = "delete from ObjetivosTerapeuticos where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                conn.Execute(sql, new { ID = id });
        }
    }
}
