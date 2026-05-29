using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CT_Negocio.DAO;
using CT_Negocio.Mapeamento;

namespace CT_Win.Forms
{
    public partial class ObjetivoItemForm : Form
    {
        private readonly ObjetivoTerapeuticoDAO _dao    = new ObjetivoTerapeuticoDAO();
        private readonly EspecialidadeDAO       _espDao = new EspecialidadeDAO();
        private readonly int                    _idPaciente;
        private          ObjetivoTerapeutico    _objetivo;   // null = novo

        public ObjetivoItemForm(int idPaciente)
        {
            _idPaciente = idPaciente;
            _objetivo   = null;
            InitializeComponent();
            CarregarEspecialidades();
            cmbStatus.SelectedIndex = 0;
        }

        public ObjetivoItemForm(int idPaciente, ObjetivoTerapeutico objetivo)
        {
            _idPaciente = idPaciente;
            _objetivo   = objetivo ?? throw new ArgumentNullException(nameof(objetivo));
            InitializeComponent();
            CarregarEspecialidades();
            PreencherFormulario(objetivo);

            lblTitulo.Text = "Editar Objetivo Terapêutico";
            Text           = "Editar Objetivo Terapêutico";
        }

        private void CarregarEspecialidades()
        {
            try
            {
                List<Especialidade> lista = _espDao.Listar(soAtivas: true);
                cmbEspecialidade.DisplayMember = "Nome";
                cmbEspecialidade.ValueMember   = "ID";
                cmbEspecialidade.DataSource    = lista;
                if (lista.Count > 0) cmbEspecialidade.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar especialidades:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherFormulario(ObjetivoTerapeutico o)
        {
            foreach (Especialidade esp in cmbEspecialidade.Items)
            {
                if (esp.ID == o.IDEspecialidade)
                {
                    cmbEspecialidade.SelectedItem = esp;
                    break;
                }
            }

            txtDescricao.Text   = o.Descricao ?? "";
            dtpDataInicio.Value = o.DataInicio;

            if (o.DataPrevisaoFim.HasValue)
            {
                dtpDataPrevisao.Checked = true;
                dtpDataPrevisao.Value   = o.DataPrevisaoFim.Value;
            }
            else
            {
                dtpDataPrevisao.Checked = false;
            }

            string statusDisplay = StatusParaDisplay(o.Status);
            int idx = cmbStatus.Items.IndexOf(statusDisplay);
            cmbStatus.SelectedIndex = idx >= 0 ? idx : 0;

            nudPercentual.Value = Math.Min(100, Math.Max(0, (int)o.PercentualAtingimento));
        }

        private static string StatusParaDisplay(string status)
        {
            switch (status)
            {
                case "EmProgresso": return "Em Progresso";
                case "Concluido":   return "Concluído";
                case "Suspenso":    return "Suspenso";
                default:            return "Em Progresso";
            }
        }

        private static string DisplayParaStatus(string display)
        {
            switch (display)
            {
                case "Em Progresso": return "EmProgresso";
                case "Concluído":    return "Concluido";
                case "Suspenso":     return "Suspenso";
                default:             return "EmProgresso";
            }
        }

        private ObjetivoTerapeutico LerFormulario()
        {
            var esp = cmbEspecialidade.SelectedItem as Especialidade;
            var o   = _objetivo ?? new ObjetivoTerapeutico { IDPaciente = _idPaciente };

            o.IDEspecialidade       = esp != null ? esp.ID : 0;
            o.Descricao             = txtDescricao.Text.Trim();
            o.DataInicio            = dtpDataInicio.Value.Date;
            o.DataPrevisaoFim       = dtpDataPrevisao.Checked ? (DateTime?)dtpDataPrevisao.Value.Date : null;
            o.Status                = DisplayParaStatus(cmbStatus.SelectedItem?.ToString() ?? "Em Progresso");
            o.PercentualAtingimento = (byte)nudPercentual.Value;

            return o;
        }

        private bool Validar()
        {
            if (cmbEspecialidade.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma especialidade.", "Campo obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEspecialidade.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("A descrição do objetivo é obrigatória.", "Campo obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescricao.Focus();
                return false;
            }
            return true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                ObjetivoTerapeutico obj = LerFormulario();

                if (_objetivo == null) _dao.Inserir(obj);
                else                   _dao.Alterar(obj);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar objetivo:\n" + ex.Message,
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
