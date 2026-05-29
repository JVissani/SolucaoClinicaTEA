using System;

namespace CT_Negocio.Mapeamento
{
    public class Paciente
    {
        public int ID { get; set; }
        public int IDCidade { get; set; }
        public string Nome { get; set; }
        public string NomeSocial { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public byte? NivelSuporte { get; set; }         // DSM-5: 1, 2 ou 3
        public DateTime? DataDiagnostico { get; set; }
        public string NumeroCIPTEA { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string NomeResponsavel { get; set; }
        public string CPFResponsavel { get; set; }
        public string TelefoneResponsavel { get; set; }
        public string Observacoes { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }

        // Virtuais
        public Cidade Cidade { get; set; }

        // Prefere NomeSocial quando preenchido
        public string NomeExibicao
        {
            get { return string.IsNullOrWhiteSpace(NomeSocial) ? Nome : NomeSocial; }
        }

        public int Idade
        {
            get
            {
                DateTime hoje = DateTime.Today;
                if (DataNascimento > hoje) return -1;

                int anos = hoje.Year - DataNascimento.Year;
                if (hoje.Month < DataNascimento.Month ||
                   (hoje.Month == DataNascimento.Month && hoje.Day < DataNascimento.Day))
                {
                    anos--;
                }
                return anos;
            }
        }

        public string NivelSuporteDescricao
        {
            get
            {
                if (NivelSuporte == null) return "Nao informado";
                switch (NivelSuporte.Value)
                {
                    case 1: return "Nivel 1 - Exigindo apoio";
                    case 2: return "Nivel 2 - Exigindo apoio substancial";
                    case 3: return "Nivel 3 - Exigindo apoio muito substancial";
                    default: return "Invalido";
                }
            }
        }
    }
}
