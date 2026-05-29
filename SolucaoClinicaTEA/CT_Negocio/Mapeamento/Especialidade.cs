namespace CT_Negocio.Mapeamento
{
    public class Especialidade
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string ConselhoSigla { get; set; }

        // Cor #RRGGBB usada na Linha do Tempo Multidisciplinar
        public string CorHex { get; set; }

        public bool Ativo { get; set; }
    }
}