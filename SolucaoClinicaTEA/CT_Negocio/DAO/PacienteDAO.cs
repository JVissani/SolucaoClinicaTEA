using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using CT_Negocio.Infraestrutura;
using CT_Negocio.Mapeamento;

namespace CT_Negocio.DAO
{
    public class PacienteDAO
    {
        private readonly Conexao _conexao = new Conexao();

        public List<Paciente> Listar(bool soAtivos = true)
        {
            var sql = @"
                select
                    p.ID, p.IDCidade, p.Nome, p.NomeSocial, p.CPF, p.DataNascimento,
                    p.Sexo, p.NivelSuporte, p.DataDiagnostico, p.NumeroCIPTEA,
                    p.Telefone, p.Email, p.NomeResponsavel, p.CPFResponsavel,
                    p.TelefoneResponsavel, p.Observacoes, p.Ativo, p.DataCadastro,
                    c.ID, c.Nome, c.UF
                from Pacientes p
                left join Cidades c on c.ID = p.IDCidade
                where 1 = 1 ";

            if (soAtivos)
                sql += " and p.Ativo = 1 ";

            sql += " order by p.Nome";

            using (IDbConnection conn = _conexao.CriarConexao())
            {
                return conn.Query<Paciente, Cidade, Paciente>(
                    sql,
                    (paciente, cidade) =>
                    {
                        paciente.Cidade = cidade;
                        return paciente;
                    },
                    splitOn: "ID"
                ).ToList();
            }
        }

        public Paciente Buscar(int id)
        {
            const string sql = @"
                select
                    p.ID, p.IDCidade, p.Nome, p.NomeSocial, p.CPF, p.DataNascimento,
                    p.Sexo, p.NivelSuporte, p.DataDiagnostico, p.NumeroCIPTEA,
                    p.Telefone, p.Email, p.NomeResponsavel, p.CPFResponsavel,
                    p.TelefoneResponsavel, p.Observacoes, p.Ativo, p.DataCadastro,
                    c.ID, c.Nome, c.UF
                from Pacientes p
                left join Cidades c on c.ID = p.IDCidade
                where p.ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
            {
                return conn.Query<Paciente, Cidade, Paciente>(
                    sql,
                    (paciente, cidade) =>
                    {
                        paciente.Cidade = cidade;
                        return paciente;
                    },
                    new { ID = id },
                    splitOn: "ID"
                ).FirstOrDefault();
            }
        }

        public Paciente BuscarPorCPF(string cpf)
        {
            const string sql = @"
                select ID, IDCidade, Nome, NomeSocial, CPF, DataNascimento, Sexo,
                       NivelSuporte, DataDiagnostico, NumeroCIPTEA, Telefone, Email,
                       NomeResponsavel, CPFResponsavel, TelefoneResponsavel,
                       Observacoes, Ativo, DataCadastro
                from Pacientes
                where CPF = @CPF";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.QueryFirstOrDefault<Paciente>(sql, new { CPF = cpf });
        }

        public List<Paciente> Pesquisar(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
                return Listar(soAtivos: true);

            const string sql = @"
                select
                    p.ID, p.IDCidade, p.Nome, p.NomeSocial, p.CPF, p.DataNascimento,
                    p.Sexo, p.NivelSuporte, p.DataDiagnostico, p.NumeroCIPTEA,
                    p.Telefone, p.Email, p.NomeResponsavel, p.CPFResponsavel,
                    p.TelefoneResponsavel, p.Observacoes, p.Ativo, p.DataCadastro,
                    c.ID, c.Nome, c.UF
                from Pacientes p
                left join Cidades c on c.ID = p.IDCidade
                where p.Ativo = 1
                  and (p.Nome like @Termo or p.NomeSocial like @Termo or p.CPF like @Termo)
                order by p.Nome";

            using (IDbConnection conn = _conexao.CriarConexao())
            {
                return conn.Query<Paciente, Cidade, Paciente>(
                    sql,
                    (paciente, cidade) =>
                    {
                        paciente.Cidade = cidade;
                        return paciente;
                    },
                    new { Termo = "%" + termo + "%" },
                    splitOn: "ID"
                ).ToList();
            }
        }

        public int Inserir(Paciente paciente)
        {
            const string sql = @"
                insert into Pacientes
                    (Nome, NomeSocial, CPF, DataNascimento, Sexo, NivelSuporte,
                     DataDiagnostico, NumeroCIPTEA, IDCidade, Telefone, Email,
                     NomeResponsavel, CPFResponsavel, TelefoneResponsavel,
                     Observacoes, Ativo)
                values
                    (@Nome, @NomeSocial, @CPF, @DataNascimento, @Sexo, @NivelSuporte,
                     @DataDiagnostico, @NumeroCIPTEA, @IDCidade, @Telefone, @Email,
                     @NomeResponsavel, @CPFResponsavel, @TelefoneResponsavel,
                     @Observacoes, @Ativo);
                select cast(SCOPE_IDENTITY() as int);";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.QuerySingle<int>(sql, paciente);
        }

        public int Alterar(Paciente paciente)
        {
            const string sql = @"
                update Pacientes
                set Nome                = @Nome,
                    NomeSocial          = @NomeSocial,
                    CPF                 = @CPF,
                    DataNascimento      = @DataNascimento,
                    Sexo                = @Sexo,
                    NivelSuporte        = @NivelSuporte,
                    DataDiagnostico     = @DataDiagnostico,
                    NumeroCIPTEA        = @NumeroCIPTEA,
                    IDCidade            = @IDCidade,
                    Telefone            = @Telefone,
                    Email               = @Email,
                    NomeResponsavel     = @NomeResponsavel,
                    CPFResponsavel      = @CPFResponsavel,
                    TelefoneResponsavel = @TelefoneResponsavel,
                    Observacoes         = @Observacoes,
                    Ativo               = @Ativo
                where ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, paciente);
        }

        public int Reativar(int id)
        {
            const string sql = "update Pacientes set Ativo = 1 where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, new { ID = id });
        }

        // Soft-delete: inativa em vez de deletar, preservando histórico clínico
        public int Excluir(int id)
        {
            const string sql = "update Pacientes set Ativo = 0 where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, new { ID = id });
        }

        // Delete físico: falhará com FK exception se houver agendamentos vinculados
        public int ExcluirFisico(int id)
        {
            const string sql = "delete from Pacientes where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.Execute(sql, new { ID = id });
        }
    }
}
