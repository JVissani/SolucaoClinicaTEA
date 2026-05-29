using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using CT_Negocio.Infraestrutura;
using CT_Negocio.Mapeamento;

namespace CT_Negocio.DAO
{
    public class UsuarioDAO
    {
        private readonly Conexao _conexao = new Conexao();

        public List<Usuario> Listar(bool soAtivos = false)
        {
            var sql = @"
                select ID, Login, SenhaHash, Salt, Nome, Perfil, Ativo
                from Usuarios
                where 1 = 1 ";

            if (soAtivos)
                sql += " and Ativo = 1 ";

            sql += " order by Nome";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Query<Usuario>(sql).ToList();
        }

        public Usuario Buscar(int id)
        {
            const string sql = @"
                select ID, Login, SenhaHash, Salt, Nome, Perfil, Ativo
                from Usuarios
                where ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.QueryFirstOrDefault<Usuario>(sql, new { ID = id });
        }

        public Usuario BuscarPorLogin(string login)
        {
            const string sql = @"
                select ID, Login, SenhaHash, Salt, Nome, Perfil, Ativo
                from Usuarios
                where Login = @Login";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.QueryFirstOrDefault<Usuario>(sql, new { Login = login });
        }

        public int Inserir(Usuario usuario, string senhaPlana)
        {
            usuario.Salt      = CriptografiaSenha.GerarSalt();
            usuario.SenhaHash = CriptografiaSenha.CalcularHash(usuario.Salt, senhaPlana);

            const string sql = @"
                insert into Usuarios (Login, SenhaHash, Salt, Nome, Perfil, Ativo)
                values (@Login, @SenhaHash, @Salt, @Nome, @Perfil, @Ativo);
                select cast(SCOPE_IDENTITY() as int);";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.QuerySingle<int>(sql, usuario);
        }

        public int Alterar(Usuario usuario)
        {
            const string sql = @"
                update Usuarios
                set Login  = @Login,
                    Nome   = @Nome,
                    Perfil = @Perfil,
                    Ativo  = @Ativo
                where ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, usuario);
        }

        public int AlterarSenha(int idUsuario, string novaSenhaPlana)
        {
            string novoSalt = CriptografiaSenha.GerarSalt();
            string novoHash = CriptografiaSenha.CalcularHash(novoSalt, novaSenhaPlana);

            const string sql = @"
                update Usuarios
                set SenhaHash = @SenhaHash,
                    Salt      = @Salt
                where ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
            {
                return conn.Execute(sql, new
                {
                    ID        = idUsuario,
                    SenhaHash = novoHash,
                    Salt      = novoSalt
                });
            }
        }

        // Soft-delete: usuário nunca é removido fisicamente
        public int Excluir(int id)
        {
            const string sql = "update Usuarios set Ativo = 0 where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, new { ID = id });
        }
    }
}
