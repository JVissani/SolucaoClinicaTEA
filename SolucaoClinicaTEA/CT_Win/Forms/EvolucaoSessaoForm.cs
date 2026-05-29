using System;
using System.Windows.Forms;
using CT_Negocio.DAO;
using CT_Negocio.Mapeamento;

namespace CT_Win.Forms
{
    public partial class EvolucaoSessaoForm : Form
    {
        private readonly EvolucaoSessaoDAO _dao = new EvolucaoSessaoDAO();
        private readonly Agendamento       _agendamento;
        private          EvolucaoSessao    _evolucao;   // null = novo registro

        public EvolucaoSessaoForm(Agendamento ag)
        {
            _agendamento = ag ?? throw new ArgumentNullException(nameof(ag));
            _evolucao    = null;
            InitializeComponent();
            PreencherSessao(ag);
        }

        public EvolucaoSessaoForm(Agendamento ag, EvolucaoSessao evolucao)
        {
            _agendamento = ag       ?? throw new ArgumentNullException(nameof(ag));
            _evolucao    = evolucao ?? throw new ArgumentNullException(nameof(evolucao));
            InitializeComponent();
            PreencherSessao(ag);
            PreencherFormulario(evolucao);
        }

        private void PreencherSessao(Agendamento ag)
        {
            string paciente = ag.Paciente != null ? ag.Paciente.NomeExibicao : "—";
            lblPacienteSessao.Text = paciente;

            string prof = ag.Profissional != null ? ag.Profissional.NomeExibicao : "—";
            string esp  = (ag.Profissional != null && ag.Profissional.Especialidade != null)
                              ? ag.Profissional.Especialidade.Nome
                              : "";
            string sala = ag.Sala != null ? ag.Sala.Nome : "—";

            lblDetalhesSessao.Text = string.Format(
                "{0}  ·  {1}  ·  Sala: {2}  ·  {3}",
                ag.DataHoraInicio.ToString("dd/MM/yyyy HH:mm"),
                string.IsNullOrEmpty(esp) ? prof : prof + " (" + esp + ")",
                sala,
                ag.DuracaoMinutos + " min");

            Text           = (_evolucao == null ? "Nova Evolução — " : "Editar Evolução — ")
                             + ag.DataHoraInicio.ToString("dd/MM/yyyy");
            lblTitulo.Text = _evolucao == null
                ? "Registrar Evolução da Sessão"
                : "Editar Evolução da Sessão";
        }

        private void PreencherFormulario(EvolucaoSessao e)
        {
            nudHumor.Value              = e.HumorPaciente      ?? 3;
            nudEngajamento.Value        = e.NivelEngajamento   ?? 3;
            txtConteudo.Text            = e.Conteudo           ?? "";
            txtComportamentos.Text      = e.Comportamentos     ?? "";
            txtProximosObjetivos.Text   = e.ProximosObjetivos  ?? "";
        }

        private EvolucaoSessao LerFormulario()
        {
            var e = _evolucao ?? new EvolucaoSessao
            {
                IDAgendamento = _agendamento.ID,
                DataCadastro  = DateTime.Now
            };

            e.HumorPaciente     = (byte)nudHumor.Value;
            e.NivelEngajamento  = (byte)nudEngajamento.Value;
            e.Conteudo          = txtConteudo.Text.Trim();
            e.Comportamentos    = string.IsNullOrWhiteSpace(txtComportamentos.Text)
                                      ? null : txtComportamentos.Text.Trim();
            e.ProximosObjetivos = string.IsNullOrWhiteSpace(txtProximosObjetivos.Text)
                                      ? null : txtProximosObjetivos.Text.Trim();
            return e;
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtConteudo.Text))
            {
                MessageBox.Show(
                    "O campo \"Evolução / Conteúdo da sessão\" é obrigatório.",
                    "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConteudo.Focus();
                return false;
            }
            return true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                EvolucaoSessao ev = LerFormulario();

                if (_evolucao == null) _dao.Inserir(ev);
                else                  _dao.Alterar(ev);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar evolução:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
