using System;

namespace CT_Negocio.Mapeamento
{
    public class EvolucaoSessao
    {
        public int ID { get; set; }
        public int IDAgendamento { get; set; }
        public string Conteudo { get; set; }
        public string Comportamentos { get; set; }
        public string ProximosObjetivos { get; set; }
        public byte? HumorPaciente { get; set; }      // 1 (muito desregulado) a 5 (muito regulado)
        public byte? NivelEngajamento { get; set; }   // 1 (sem engajamento) a 5 (totalmente engajado)
        public DateTime DataCadastro { get; set; }

        // Virtual
        public Agendamento Agendamento { get; set; }
    }
}