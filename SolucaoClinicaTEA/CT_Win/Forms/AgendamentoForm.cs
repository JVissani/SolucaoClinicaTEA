using System;
using System.Windows.Forms;
using CT_Negocio.DAO;
using CT_Negocio.Mapeamento;

namespace CT_Win.Forms
{
    public partial class AgendamentoForm : Form
    {
        private readonly AgendamentoDAO  _dao     = new AgendamentoDAO();
        private readonly PacienteDAO     _pacDao  = new PacienteDAO();
        private readonly ProfissionalDAO _profDao = new ProfissionalDAO();
        private readonly SalaDAO         _salaDao = new SalaDAO();

        private readonly int _idUsuarioCadastro;
        private int _idEditando = 0;

        public AgendamentoForm(int idUsuarioCadastro)
        {
            _idUsuarioCadastro = idUsuarioCadastro;
            InitializeComponent();
            CarregarCombos();
            dtpData.Value       = DateTime.Today;
            dtpHoraInicio.Value = DateTime.Today.AddHours(8);
            dtpHoraFim.Value    = DateTime.Today.AddHours(9);
        }

        public AgendamentoForm(Agendamento ag, int idUsuarioCadastro) : this(idUsuarioCadastro)
        {
            if (ag == null) return;
            _idEditando        = ag.ID;
            lblFormTitulo.Text = "Editando agendamento";
            PreencherFormulario(ag);
        }

        private void CarregarCombos()
        {
            try
            {
                cmbPaciente.Items.Clear();
                cmbPaciente.Items.Add(new ComboItem(0, "— Selecione o paciente —"));
                foreach (var p in _pacDao.Listar(soAtivos: true))
                    cmbPaciente.Items.Add(new ComboItem(p.ID, p.NomeExibicao));
                cmbPaciente.DisplayMember = "Texto";
                cmbPaciente.SelectedIndex = 0;

                cmbProfissional.Items.Clear();
                cmbProfissional.Items.Add(new ComboItem(0, "— Selecione o profissional —"));
                foreach (var pr in _profDao.Listar(soAtivos: true))
                {
                    string esp  = pr.Especialidade != null ? " (" + pr.Especialidade.Nome + ")" : "";
                    cmbProfissional.Items.Add(new ComboItem(pr.ID, pr.NomeExibicao + esp));
                }
                cmbProfissional.DisplayMember = "Texto";
                cmbProfissional.SelectedIndex = 0;

                cmbSala.Items.Clear();
                cmbSala.Items.Add(new ComboItem(0, "— Selecione a sala —"));
                foreach (var s in _salaDao.Listar(soAtivas: true))
                    cmbSala.Items.Add(new ComboItem(s.ID, s.Nome));
                cmbSala.DisplayMember = "Texto";
                cmbSala.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherFormulario(Agendamento ag)
        {
            SelecionarCombo(cmbPaciente,     ag.IDPaciente);
            SelecionarCombo(cmbProfissional, ag.IDProfissional);
            SelecionarCombo(cmbSala,         ag.IDSala);
            dtpData.Value       = ag.DataHoraInicio.Date;
            dtpHoraInicio.Value = ag.DataHoraInicio;
            dtpHoraFim.Value    = ag.DataHoraFim;
            int idxStatus = cmbStatus.Items.IndexOf(ag.Status);
            cmbStatus.SelectedIndex = idxStatus >= 0 ? idxStatus : 0;
            txtObservacao.Text  = ag.Observacao ?? "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string erro = Validar();
            if (erro != null)
            {
                MessageBox.Show(erro, "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var ag = LerFormulario();
                ag.ID = _idEditando;

                if (ag.ID == 0) _dao.Inserir(ag);
                else            _dao.Alterar(ag);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private Agendamento LerFormulario()
        {
            DateTime inicio = dtpData.Value.Date.Add(dtpHoraInicio.Value.TimeOfDay);
            DateTime fim    = dtpData.Value.Date.Add(dtpHoraFim.Value.TimeOfDay);

            return new Agendamento
            {
                IDPaciente        = IdCombo(cmbPaciente),
                IDProfissional    = IdCombo(cmbProfissional),
                IDSala            = IdCombo(cmbSala),
                DataHoraInicio    = inicio,
                DataHoraFim       = fim,
                Status            = cmbStatus.Text,
                Observacao        = string.IsNullOrWhiteSpace(txtObservacao.Text) ? null : txtObservacao.Text.Trim(),
                IDUsuarioCadastro = _idUsuarioCadastro,
                DataCadastro      = DateTime.Now
            };
        }

        private string Validar()
        {
            if (IdCombo(cmbPaciente)     <= 0) return "Selecione o paciente.";
            if (IdCombo(cmbProfissional) <= 0) return "Selecione o profissional.";
            if (IdCombo(cmbSala)         <= 0) return "Selecione a sala.";

            DateTime inicio = dtpData.Value.Date.Add(dtpHoraInicio.Value.TimeOfDay);
            DateTime fim    = dtpData.Value.Date.Add(dtpHoraFim.Value.TimeOfDay);

            if (fim <= inicio)
                return "O horário de fim deve ser posterior ao início.";

            if (_dao.TemConflito(IdCombo(cmbProfissional), IdCombo(cmbSala), inicio, fim, _idEditando))
                return "Conflito de horário: profissional ou sala já estão agendados neste período.";

            return null;
        }

        private static int IdCombo(ComboBox cbo)
        {
            var item = cbo.SelectedItem as ComboItem;
            return item != null ? item.Id : 0;
        }

        private void SelecionarCombo(ComboBox cbo, int id)
        {
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                var item = cbo.Items[i] as ComboItem;
                if (item != null && item.Id == id) { cbo.SelectedIndex = i; return; }
            }
            cbo.SelectedIndex = 0;
        }

        private class ComboItem
        {
            public int    Id    { get; }
            public string Texto { get; }
            public ComboItem(int id, string texto) { Id = id; Texto = texto; }
            public override string ToString() => Texto;
        }
    }
}
