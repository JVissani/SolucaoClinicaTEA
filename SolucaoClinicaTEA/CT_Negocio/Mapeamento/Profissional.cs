namespace CT_Negocio.Mapeamento
{
    public class Profissional
    {
        public int ID { get; set; }
        public int? IDUsuario { get; set; }       // opcional (nem todo profissional acessa o sistema)
        public int IDEspecialidade { get; set; }
        public string Nome { get; set; }
        public string NomeSocial { get; set; }
        public string CPF { get; set; }
        public string RegistroConselho { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

        // Virtuais - nao persistem no banco
        public Especialidade Especialidade { get; set; }
        public Usuario Usuario { get; set; }

        // Nome para exibicao em listas (prefere social se houver)
        public string NomeExibicao
        {
            get { return string.IsNullOrWhiteSpace(NomeSocial) ? Nome : NomeSocial; }
        }
    }
}