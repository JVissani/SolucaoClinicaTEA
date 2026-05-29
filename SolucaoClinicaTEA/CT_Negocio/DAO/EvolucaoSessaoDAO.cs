using System.Data;
using Dapper;
using CT_Negocio.Infraestrutura;
using CT_Negocio.Mapeamento;

namespace CT_Negocio.DAO
{
    public class EvolucaoSessaoDAO
    {
        private readonly Conexao _conexao = new Conexao();

        public EvolucaoSessao BuscarPorAgendamento(int idAgendamento)
        {
            const string sql = @"
                select ID, IDAgendamento, Conteudo, Comportamentos, ProximosObjetivos,
                       HumorPaciente, NivelEngajamento, DataCadastro
                from EvolucoesSessao
                where IDAgendamento = @IDAgendamento";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.QueryFirstOrDefault<EvolucaoSessao>(sql, new { IDAgendamento = idAgendamento });
        }

        public int Inserir(EvolucaoSessao e)
        {
            const string sql = @"
                insert into EvolucoesSessao
                    (IDAgendamento, Conteudo, Comportamentos, ProximosObjetivos,
                     HumorPaciente, NivelEngajamento, DataCadastro)
                values
                    (@IDAgendamento, @Conteudo, @Comportamentos, @ProximosObjetivos,
                     @HumorPaciente, @NivelEngajamento, @DataCadastro);
                select cast(SCOPE_IDENTITY() as int);";

            using (IDbConnection conn = _conexao.CriarConexao())
                return conn.QuerySingle<int>(sql, e);
        }

        public void Alterar(EvolucaoSessao e)
        {
            const string sql = @"
                update EvolucoesSessao
                set Conteudo           = @Conteudo,
                    Comportamentos     = @Comportamentos,
                    ProximosObjetivos  = @ProximosObjetivos,
                    HumorPaciente      = @HumorPaciente,
                    NivelEngajamento   = @NivelEngajamento
                where ID = @ID";

            using (IDbConnection conn = _conexao.CriarConexao())
                conn.Execute(sql, e);
        }

        public void Excluir(int id)
        {
            const string sql = "delete from EvolucoesSessao where ID = @ID";
            using (IDbConnection conn = _conexao.CriarConexao())
                conn.Execute(sql, new { ID = id });
        }
    }
}
