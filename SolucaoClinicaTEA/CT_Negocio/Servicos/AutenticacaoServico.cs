using CT_Negocio.DAO;
using CT_Negocio.Infraestrutura;
using CT_Negocio.Mapeamento;

namespace CT_Negocio.Servicos
{
    public class AutenticacaoServico
    {
        private readonly UsuarioDAO _usuarioDao;

        public AutenticacaoServico()
        {
            _usuarioDao = new UsuarioDAO();
        }

        public ResultadoAutenticacao Autenticar(string login, string senhaPlana)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senhaPlana))
                return ResultadoAutenticacao.DeFalha(MotivoFalhaAutenticacao.DadosInvalidos);

            Usuario usuario = _usuarioDao.BuscarPorLogin(login.Trim());
            if (usuario == null)
                return ResultadoAutenticacao.DeFalha(MotivoFalhaAutenticacao.UsuarioNaoEncontrado);

            if (!usuario.Ativo)
                return ResultadoAutenticacao.DeFalha(MotivoFalhaAutenticacao.UsuarioInativo);

            bool senhaValida = CriptografiaSenha.Verificar(senhaPlana, usuario.Salt, usuario.SenhaHash);
            if (!senhaValida)
                return ResultadoAutenticacao.DeFalha(MotivoFalhaAutenticacao.SenhaIncorreta);

            return ResultadoAutenticacao.DeSucesso(usuario);
        }
    }
}
