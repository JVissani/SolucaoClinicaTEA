using System;
using System.Drawing;
using System.Windows.Forms;
using CT_Negocio.DAO;
using CT_Negocio.Mapeamento;

namespace CT_Win.Forms
{
    public partial class EspecialidadeForm : Form
    {
        private readonly EspecialidadeDAO _dao = new EspecialidadeDAO();
        private readonly Especialidade    _especialidade;  // null = novo

        public EspecialidadeForm()
        {
            _especialidade = null;
            InitializeComponent();
        }

        public EspecialidadeForm(Especialidade especialidade)
        {
            _especialidade = especialidade ?? throw new ArgumentNullException(nameof(especialidade));
            InitializeComponent();
            PreencherFormulario();
        }

        private void PreencherFormulario()
        {
            lblTitulo.Text    = "Editar especialidade";
            this.Text         = "Editar especialidade";
            txtNome.Text      = _especialidade.Nome;
            txtConselho.Text  = _especialidade.ConselhoSigla ?? "";
            txtCorHex.Text    = _especialidade.CorHex ?? "";
            chkAtivo.Checked  = _especialidade.Ativo;

            AtualizarPreviewCor(txtCorHex.Text);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            var esp = LerFormulario();

            try
            {
                if (_especialidade == null)
                {
                    _dao.Inserir(esp);
                    MessageBox.Show("Especialidade cadastrada com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    esp.ID = _especialidade.ID;
                    _dao.Alterar(esp);
                    MessageBox.Show("Especialidade atualizada com sucesso!",
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
            return true;
        }

        private Especialidade LerFormulario()
        {
            return new Especialidade
            {
                Nome          = txtNome.Text.Trim(),
                ConselhoSigla = Nulo(txtConselho.Text),
                CorHex        = Nulo(txtCorHex.Text),
                Ativo         = chkAtivo.Checked
            };
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtCorHex_TextChanged(object sender, EventArgs e) =>
            AtualizarPreviewCor(txtCorHex.Text.Trim());

        private void AtualizarPreviewCor(string hex)
        {
            if (hex.StartsWith("#") && hex.Length == 7)
            {
                try
                {
                    pnlCorPreview.BackColor = ColorTranslator.FromHtml(hex);
                    return;
                }
                catch { /* hex inválido */ }
            }
            pnlCorPreview.BackColor = Color.FromArgb(237, 241, 244);
        }

        private static string Nulo(string texto) =>
            string.IsNullOrWhiteSpace(texto) ? null : texto.Trim();
    }
}
