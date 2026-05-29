using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using CT_Negocio.Infraestrutura;
using CT_Negocio.Mapeamento;

namespace CT_Negocio.DAO
{
    public class EspecialidadeDAO
    {
        private readonly Conexao _conexao = new Conexao();

        public List<Especialidade> Listar(bool soAtivas = false)
        {
            var sql = @"
                select ID, Nome, ConselhoSigla, CorHex, Ativo
                from Especialidades
                where 1 = 1 ";

            if (soAtivas)
                sql += " and Ativo = 1 ";

            sql += " order by Nome";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Query<Especialidade>(sql).ToList();
        }

        public Especialidade Buscar(int id)
        {
            const string sql = @"
                select ID, Nome, ConselhoSigla, CorHex, Ativo
                from Especialidades
                where ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.QueryFirstOrDefault<Especialidade>(sql, new { ID = id });
        }

        public int Inserir(Especialidade especialidade)
        {
            const string sql = @"
                insert into Especialidades (Nome, ConselhoSigla, CorHex, Ativo)
                values (@Nome, @ConselhoSigla, @CorHex, @Ativo);
                select cast(SCOPE_IDENTITY() as int);";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.QuerySingle<int>(sql, especialidade);
        }

        public int Alterar(Especialidade especialidade)
        {
            const string sql = @"
                update Especialidades
                set Nome          = @Nome,
                    ConselhoSigla = @ConselhoSigla,
                    CorHex        = @CorHex,
                    Ativo         = @Ativo
                where ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, especialidade);
        }

        public int Reativar(int id)
        {
            const string sql = "update Especialidades set Ativo = 1 where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, new { ID = id });
        }

        // Soft-delete: inativa em vez de deletar, preservando histórico de profissionais e objetivos
        public int Excluir(int id)
        {
            const string sql = "update Especialidades set Ativo = 0 where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, new { ID = id });
        }

        // Delete físico: falhará com FK exception se houver profissionais vinculados
        public int ExcluirFisico(int id)
        {
            const string sql = "delete from Especialidades where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, new { ID = id });
        }
    }
}
