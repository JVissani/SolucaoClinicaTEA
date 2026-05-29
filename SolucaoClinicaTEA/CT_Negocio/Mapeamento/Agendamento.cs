using System;

namespace CT_Negocio.Mapeamento
{
    public class Agendamento
    {
        public int ID { get; set; }
        public int IDPaciente { get; set; }
        public int IDProfissional { get; set; }
        public int IDSala { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public string Status { get; set; }              // Agendado | Realizado | Faltou | Cancelado
        public string Observacao { get; set; }
        public int IDUsuarioCadastro { get; set; }
        public DateTime DataCadastro { get; set; }

        // Virtuais
        public Paciente Paciente { get; set; }
        public Profissional Profissional { get; set; }
        public Sala Sala { get; set; }
        public EvolucaoSessao Evolucao { get; set; }    // null se ainda nao registrou evolucao

        // Util na UI (label da agenda, exportacao, etc.)
        public int DuracaoMinutos
        {
            get { return (int)(DataHoraFim - DataHoraInicio).TotalMinutes; }
        }

        public bool JaOcorreu
        {
            get { return DataHoraFim < DateTime.Now; }
        }
    }
}