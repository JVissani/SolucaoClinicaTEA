using System;
using System.Linq;
using System.Windows.Forms;
using CT_Negocio.DAO;
using CT_Negocio.Mapeamento;

namespace CT_Win.Forms
{
    public partial class PacienteForm : Form
    {
        private readonly PacienteDAO _dao      = new PacienteDAO();
        private readonly CidadeDAO   _cidadeDAO = new CidadeDAO();

        private int _idEditando = 0;

        public PacienteForm()
        {
            InitializeComponent();
            CarregarCombos();
        }

        public PacienteForm(Paciente paciente) : this()
        {
            if (paciente == null) return;
            _idEditando       = paciente.ID;
            lblFormTitulo.Text = "Editando: " + paciente.NomeExibicao;
            PreencherFormulario(paciente);
        }

        private void CarregarCombos()
        {
            cmbSexo.SelectedIndex  = 0;
            cmbNivel.SelectedIndex = 0;
            dtpNascimento.Value    = DateTime.Today.AddYears(-5);

            CarregarComboCidades();
        }

        private void CarregarComboCidades()
        {
            try
            {
                cmbCidade.Items.Clear();
                cmbCidade.Items.Add(new ComboItem(0, "— Selecione —"));
                foreach (var c in _cidadeDAO.Listar())
                    cmbCidade.Items.Add(new ComboItem(c.ID, c.Nome + " / " + c.UF));
                cmbCidade.DisplayMember = "Texto";
                cmbCidade.ValueMember   = "Id";
                cmbCidade.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar cidades: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherFormulario(Paciente p)
        {
            txtNome.Text        = p.Nome        ?? "";
            txtNomeSocial.Text  = p.NomeSocial  ?? "";
            txtCPF.Text         = p.CPF         ?? "";
            dtpNascimento.Value = p.DataNascimento;
            cmbSexo.SelectedIndex = IndexSexo(p.Sexo);
            cmbNivel.SelectedIndex = p.NivelSuporte.HasValue ? (int)p.NivelSuporte.Value : 0;

            if (p.DataDiagnostico.HasValue)
            { dtpDiagnostico.Checked = true;  dtpDiagnostico.Value = p.DataDiagnostico.Value; }
            else
            { dtpDiagnostico.Checked = false; }

            txtCIPTEA.Text     = p.NumeroCIPTEA ?? "";
            SelecionarCidade(p.IDCidade);
            txtTelefone.Text   = p.Telefone    ?? "";
            txtEmail.Text      = p.Email       ?? "";
            txtNomeResp.Text   = p.NomeResponsavel ?? "";
            txtCPFResp.Text    = p.CPFResponsavel  ?? "";
            txtTelResp.Text    = p.TelefoneResponsavel ?? "";
            txtObs.Text        = p.Observacoes ?? "";
            chkAtivo.Checked   = p.Ativo;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string erro = Validar();
            if (erro != null)
            {
                MessageBox.Show(erro, "Dados inválidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var p  = LerFormulario();
                p.ID   = _idEditando;

                if (p.ID == 0) _dao.Inserir(p);
                else           _dao.Alterar(p);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private Paciente LerFormulario()
        {
            return new Paciente
            {
                Nome                = txtNome.Text.Trim(),
                NomeSocial          = Nulo(txtNomeSocial.Text),
                CPF                 = LimparMascara(txtCPF.Text),
                DataNascimento      = dtpNascimento.Value.Date,
                Sexo                = SexoSelecionado(),
                NivelSuporte        = cmbNivel.SelectedIndex > 0
                                        ? (byte?)cmbNivel.SelectedIndex : null,
                DataDiagnostico     = dtpDiagnostico.Checked
                                        ? (DateTime?)dtpDiagnostico.Value.Date : null,
                NumeroCIPTEA        = Nulo(txtCIPTEA.Text),
                IDCidade            = CidadeSelecionadaId(),
                Telefone            = LimparMascara(txtTelefone.Text),
                Email               = Nulo(txtEmail.Text),
                NomeResponsavel     = Nulo(txtNomeResp.Text),
                CPFResponsavel      = LimparMascara(txtCPFResp.Text),
                TelefoneResponsavel = LimparMascara(txtTelResp.Text),
                Observacoes         = Nulo(txtObs.Text),
                Ativo               = chkAtivo.Checked
            };
        }

        private string Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
                return "O nome completo é obrigatório.";

            if (dtpNascimento.Value.Date > DateTime.Today)
                return "A data de nascimento não pode ser no futuro.";

            if (dtpNascimento.Value.Date < new DateTime(1900, 1, 1))
                return "Data de nascimento inválida (anterior a 1900).";

            if (cmbNivel.SelectedIndex <= 0)
                return "O nível de suporte (DSM-5) é obrigatório.";

            if (CidadeSelecionadaId() <= 0)
                return "A cidade é obrigatória.";

            string cpf = LimparMascara(txtCPF.Text);
            if (!string.IsNullOrEmpty(cpf))
            {
                if (cpf.Length != 11)
                    return "CPF incompleto. Preencha por completo ou deixe em branco.";
                if (!ValidarCPF(cpf))
                    return "CPF inválido. Verifique os dígitos.";

                var dup = _dao.BuscarPorCPF(cpf);
                if (dup != null && dup.ID != _idEditando)
                    return "CPF já cadastrado para: " + dup.NomeExibicao + ".";
            }

            return null;
        }

        private static bool ValidarCPF(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());
            if (cpf.Length != 11 || cpf.Distinct().Count() == 1) return false;

            int[] m1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] m2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string t = cpf.Substring(0, 9);
            int s = 0;
            for (int i = 0; i < 9; i++) s += int.Parse(t[i].ToString()) * m1[i];
            int r = s % 11; int d1 = r < 2 ? 0 : 11 - r;
            t += d1; s = 0;
            for (int i = 0; i < 10; i++) s += int.Parse(t[i].ToString()) * m2[i];
            r = s % 11; int d2 = r < 2 ? 0 : 11 - r;
            return cpf.EndsWith(d1.ToString() + d2.ToString());
        }

        private static string LimparMascara(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return null;
            string d = new string(texto.Where(char.IsDigit).ToArray());
            return string.IsNullOrEmpty(d) ? null : d;
        }

        private static string Nulo(string texto) =>
            string.IsNullOrWhiteSpace(texto) ? null : texto.Trim();

        private static int IndexSexo(string sexo)
        {
            switch (sexo)
            { case "M": return 1; case "F": return 2; case "O": return 3; default: return 0; }
        }

        private string SexoSelecionado()
        {
            switch (cmbSexo.SelectedIndex)
            { case 1: return "M"; case 2: return "F"; case 3: return "O"; default: return null; }
        }

        private int CidadeSelecionadaId()
        {
            var item = cmbCidade.SelectedItem as ComboItem;
            return item != null ? item.Id : 0;
        }

        private void SelecionarCidade(int idCidade)
        {
            for (int i = 0; i < cmbCidade.Items.Count; i++)
            {
                var item = cmbCidade.Items[i] as ComboItem;
                if (item != null && item.Id == idCidade) { cmbCidade.SelectedIndex = i; return; }
            }
            cmbCidade.SelectedIndex = 0;
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
