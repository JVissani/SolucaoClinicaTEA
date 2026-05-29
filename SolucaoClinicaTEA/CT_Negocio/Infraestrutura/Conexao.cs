using System.Configuration;
using System.Data.SqlClient;

namespace CT_Negocio.Infraestrutura
{
    public class Conexao
    {
        private const string NomeConexao = "ClinicaTEA";

        public SqlConnection CriarConexao()
        {
            var settings = ConfigurationManager.ConnectionStrings[NomeConexao];
            if (settings == null)
            {
                throw new ConfigurationErrorsException(
                    "Connection string '" + NomeConexao + "' nao encontrada no App.config. " +
                    "Verifique se o App.config esta no projeto de inicializacao (CT_Win).");
            }
            return new SqlConnection(settings.ConnectionString);
        }
    }
}
