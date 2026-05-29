using CT_Negocio.Mapeamento;

namespace CT_Negocio.Servicos
{
    public enum MotivoFalhaAutenticacao
    {
        Nenhum = 0,
        UsuarioNaoEncontrado,
        UsuarioInativo,
        SenhaIncorreta,
        DadosInvalidos
    }

    public class ResultadoAutenticacao
    {
        public bool Sucesso { get; private set; }
        public Usuario Usuario { get; private set; }
        public MotivoFalhaAutenticacao MotivoFalha { get; private set; }

        private ResultadoAutenticacao() { }

        public static ResultadoAutenticacao DeSucesso(Usuario usuario)
        {
            return new ResultadoAutenticacao
            {
                Sucesso     = true,
                Usuario     = usuario,
                MotivoFalha = MotivoFalhaAutenticacao.Nenhum
            };
        }

        public static ResultadoAutenticacao DeFalha(MotivoFalhaAutenticacao motivo)
        {
            return new ResultadoAutenticacao
            {
                Sucesso     = false,
                Usuario     = null,
                MotivoFalha = motivo
            };
        }

        public string MensagemAmigavel()
        {
            switch (MotivoFalha)
            {
                case MotivoFalhaAutenticacao.UsuarioNaoEncontrado:
                    return "Usuario nao encontrado. Verifique se digitou corretamente.";
                case MotivoFalhaAutenticacao.UsuarioInativo:
                    return "Este usuario foi desativado. Procure o administrador do sistema.";
                case MotivoFalhaAutenticacao.SenhaIncorreta:
                    return "Senha incorreta. Tente novamente.";
                case MotivoFalhaAutenticacao.DadosInvalidos:
                    return "Informe usuario e senha.";
                case MotivoFalhaAutenticacao.Nenhum:
                    return "Autenticacao realizada com sucesso.";
                default:
                    return "Falha desconhecida na autenticacao.";
            }
        }
    }
}
