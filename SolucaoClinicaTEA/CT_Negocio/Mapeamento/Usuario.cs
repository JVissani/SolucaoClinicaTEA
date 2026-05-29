namespace CT_Negocio.Mapeamento
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string SenhaHash { get; set; }
        public string Salt { get; set; }
        public string Nome { get; set; }
        public string Perfil { get; set; }  // Admin | Recepcao | Profissional
        public bool Ativo { get; set; }
    }
}