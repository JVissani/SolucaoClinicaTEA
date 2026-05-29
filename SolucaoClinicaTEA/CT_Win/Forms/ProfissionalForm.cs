using System;
using System.Windows.Forms;
using CT_Negocio.DAO;
using CT_Negocio.Mapeamento;

namespace CT_Win.Forms
{
    public partial class ProfissionalForm : Form
    {
        private readonly ProfissionalDAO  _dao    = new ProfissionalDAO();
        private readonly EspecialidadeDAO _espDao = new EspecialidadeDAO();
        private readonly Profissional     _profissional;  // null = novo

        public ProfissionalForm()
        {
            _profissional = null;
            InitializeComponent();
            CarregarCombos();
        }

        public ProfissionalForm(Profissional profissional)
        {
            _profissional = profissional ?? throw new ArgumentNullException(nameof(profissional));
            InitializeComponent();
            CarregarCombos();
            PreencherFormulario();
        }

        private void CarregarCombos()
        {
            var especialidades = _espDao.Listar(soAtivas: true);
            cmbEspecialidade.Items.Clear();
            cmbEspecialidade.Items.Add(new ComboItem(0, "— Selecione —"));
            foreach (var e in especialidades)
                cmbEspecialidade.Items.Add(new ComboItem(e.ID, e.Nome));
            cmbEspecialidade.DisplayMember = "Texto";
            cmbEspecialidade.SelectedIndex = 0;
        }

        private void PreencherFormulario()
        {
            lblTitulo.Text         = "Editar profissional";
            this.Text              = "Editar profissional";
            txtNome.Text           = _profissional.Nome;
            txtNomeSocial.Text     = _profissional.NomeSocial ?? "";
            mskCPF.Text            = _profissional.CPF ?? "";
            txtRegistro.Text       = _profissional.RegistroConselho ?? "";
            mskTelefone.Text       = _profissional.Telefone ?? "";
            txtEmail.Text          = _profissional.Email ?? "";
            chkAtivo.Checked       = _profissional.Ativo;

            for (int i = 0; i < cmbEspecialidade.Items.Count; i++)
            {
                if (((ComboItem)cmbEspecialidade.Items[i]).Id == _profissional.IDEspecialidade)
                {
                    cmbEspecialidade.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            var prof = LerFormulario();

            try
            {
                if (_profissional == null)
                {
                    _dao.Inserir(prof);
                    MessageBox.Show("Profissional cadastrado com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    prof.ID = _profissional.ID;
                    _dao.Alterar(prof);
                    MessageBox.Show("Profissional atualizado com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O campo \"Nome\" é obrigatório.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            if (!(cmbEspecialidade.SelectedItem is ComboItem item) || item.Id == 0)
            {
                MessageBox.Show("Selecione uma especialidade.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEspecialidade.Focus();
                return false;
            }

            return true;
        }

        private Profissional LerFormulario()
        {
            int idEsp = ((ComboItem)cmbEspecialidade.SelectedItem).Id;

            return new Profissional
            {
                IDUsuario        = null,
                IDEspecialidade  = idEsp,
                Nome             = txtNome.Text.Trim(),
                NomeSocial       = Nulo(txtNomeSocial.Text),
                CPF              = LimparMascara(mskCPF.Text),
                RegistroConselho = Nulo(txtRegistro.Text),
                Telefone         = LimparMascara(mskTelefone.Text),
                Email            = Nulo(txtEmail.Text),
                Ativo            = chkAtivo.Checked
            };
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private static string LimparMascara(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return null;
            var digits = new string(System.Array.FindAll(texto.ToCharArray(), char.IsDigit));
            return string.IsNullOrEmpty(digits) ? null : digits;
        }

        private static string Nulo(string texto) =>
            string.IsNullOrWhiteSpace(texto) ? null : texto.Trim();

        private class ComboItem
        {
            public int    Id    { get; }
            public string Texto { get; }
            public ComboItem(int id, string texto) { Id = id; Texto = texto; }
            public override string ToString() => Texto;
        }
    }
}
