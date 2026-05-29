using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using CT_Negocio.Infraestrutura;
using CT_Negocio.Mapeamento;

namespace CT_Negocio.DAO
{
    public class SalaDAO
    {
        private readonly Conexao _conexao = new Conexao();

        public List<Sala> Listar(bool soAtivas = false)
        {
            var sql = @"
                select ID, Nome, Capacidade, RecursosSensoriais, Ativo
                from Salas
                where 1 = 1 ";

            if (soAtivas)
                sql += " and Ativo = 1 ";

            sql += " order by Nome";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Query<Sala>(sql).ToList();
        }

        public Sala Buscar(int id)
        {
            const string sql = @"
                select ID, Nome, Capacidade, RecursosSensoriais, Ativo
                from Salas
                where ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.QueryFirstOrDefault<Sala>(sql, new { ID = id });
        }

        public int Inserir(Sala sala)
        {
            const string sql = @"
                insert into Salas (Nome, Capacidade, RecursosSensoriais, Ativo)
                values (@Nome, @Capacidade, @RecursosSensoriais, @Ativo);
                select cast(SCOPE_IDENTITY() as int);";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.QuerySingle<int>(sql, sala);
        }

        public int Alterar(Sala sala)
        {
            const string sql = @"
                update Salas
                set Nome               = @Nome,
                    Capacidade         = @Capacidade,
                    RecursosSensoriais = @RecursosSensoriais,
                    Ativo              = @Ativo
                where ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, sala);
        }

        public int Reativar(int id)
        {
            const string sql = "update Salas set Ativo = 1 where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, new { ID = id });
        }

        // Soft-delete: preserva histórico de agendamentos vinculados
        public int Excluir(int id)
        {
            const string sql = "update Salas set Ativo = 0 where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, new { ID = id });
        }

        // Delete físico: falhará com FK exception se houver agendamentos vinculados
        public int ExcluirFisico(int id)
        {
            const string sql = "delete from Salas where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, new { ID = id });
        }
    }
}
