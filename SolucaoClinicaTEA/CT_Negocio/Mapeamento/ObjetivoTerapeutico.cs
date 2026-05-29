using System;

namespace CT_Negocio.Mapeamento
{
    public class ObjetivoTerapeutico
    {
        public int ID { get; set; }
        public int IDPaciente { get; set; }
        public int IDEspecialidade { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataPrevisaoFim { get; set; }
        public string Status { get; set; }              // EmProgresso | Concluido | Suspenso
        public byte PercentualAtingimento { get; set; }

        // Virtuais
        public Paciente Paciente { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}