using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using CT_Negocio.Infraestrutura;
using CT_Negocio.Mapeamento;

namespace CT_Negocio.DAO
{
    public class ProfissionalDAO
    {
        private readonly Conexao _conexao = new Conexao();

        public List<Profissional> Listar(bool soAtivos = true)
        {
            var sql = @"
                select
                    p.ID, p.IDUsuario, p.IDEspecialidade, p.Nome, p.NomeSocial,
                    p.CPF, p.RegistroConselho, p.Telefone, p.Email, p.Ativo,
                    e.ID, e.Nome, e.ConselhoSigla, e.CorHex, e.Ativo
                from Profissionais p
                left join Especialidades e on e.ID = p.IDEspecialidade
                where 1 = 1 ";

            if (soAtivos) sql += " and p.Ativo = 1 ";
            sql += " order by p.Nome";

            using (IDbConnection conn = _conexao.CriarConexao())
            {
                return conn.Query<Profissional, Especialidade, Profissional>(
                    sql,
                    (prof, esp) => { prof.Especialidade = esp; return prof; },
                    splitOn: "ID"
                ).ToList();
            }
        }

        public Profissional Buscar(int id)
        {
            const string sql = @"
                select
                    p.ID, p.IDUsuario, p.IDEspecialidade, p.Nome, p.NomeSocial,
                    p.CPF, p.RegistroConselho, p.Telefone, p.Email, p.Ativo,
                    e.ID, e.Nome, e.ConselhoSigla, e.CorHex, e.Ativo
                from Profissionais p
                left join Especialidades e on e.ID = p.IDEspecialidade
                where p.ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
            {
                return conn.Query<Profissional, Especialidade, Profissional>(
                    sql,
                    (prof, esp) => { prof.Especialidade = esp; return prof; },
                    new { ID = id },
                    splitOn: "ID"
                ).FirstOrDefault();
            }
        }

        public int Inserir(Profissional profissional)
        {
            const string sql = @"
                insert into Profissionais
                    (IDUsuario, IDEspecialidade, Nome, NomeSocial, CPF,
                     RegistroConselho, Telefone, Email, Ativo)
                values
                    (@IDUsuario, @IDEspecialidade, @Nome, @NomeSocial, @CPF,
                     @RegistroConselho, @Telefone, @Email, @Ativo);
                select cast(SCOPE_IDENTITY() as int);";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.QuerySingle<int>(sql, profissional);
        }

        public int Alterar(Profissional profissional)
        {
            const string sql = @"
                update Profissionais
                set IDUsuario        = @IDUsuario,
                    IDEspecialidade  = @IDEspecialidade,
                    Nome             = @Nome,
                    NomeSocial       = @NomeSocial,
                    CPF              = @CPF,
                    RegistroConselho = @RegistroConselho,
                    Telefone         = @Telefone,
                    Email            = @Email,
                    Ativo            = @Ativo
                where ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, profissional);
        }

        public int Reativar(int id)
        {
            const string sql = "update Profissionais set Ativo = 1 where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, new { ID = id });
        }

        // Soft-delete: preserva histórico de agendamentos já realizados
        public int Excluir(int id)
        {
            const string sql = "update Profissionais set Ativo = 0 where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, new { ID = id });
        }

        // Delete físico: falhará com FK exception se houver agendamentos vinculados
        public int ExcluirFisico(int id)
        {
            const string sql = "delete from Profissionais where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, new { ID = id });
        }
    }
}
