using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using CT_Negocio.Infraestrutura;
using CT_Negocio.Mapeamento;

namespace CT_Negocio.DAO
{
    public class CidadeDAO
    {
        private readonly Conexao _conexao = new Conexao();

        public List<Cidade> Listar()
        {
            const string sql = @"
                select ID, Nome, UF
                from Cidades
                order by UF, Nome";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Query<Cidade>(sql).ToList();
        }

        public Cidade Buscar(int id)
        {
            const string sql = @"
                select ID, Nome, UF
                from Cidades
                where ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.QueryFirstOrDefault<Cidade>(sql, new { ID = id });
        }

        public int Inserir(Cidade cidade)
        {
            const string sql = @"
                insert into Cidades (Nome, UF)
                values (@Nome, @UF);
                select cast(SCOPE_IDENTITY() as int);";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.QuerySingle<int>(sql, cidade);
        }

        public int Alterar(Cidade cidade)
        {
            const string sql = @"
                update Cidades
                set Nome = @Nome,
                    UF   = @UF
                where ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, cidade);
        }

        public int Excluir(int id)
        {
            const string sql = "delete from Cidades where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, new { ID = id });
        }
    }
}
