using System;
using System.Windows.Forms;
using CT_Negocio.DAO;
using CT_Negocio.Mapeamento;

namespace CT_Win.Forms
{
    public partial class SalaForm : Form
    {
        private readonly SalaDAO _dao = new SalaDAO();
        private readonly Sala    _sala;  // null = novo

        public SalaForm()
        {
            _sala = null;
            InitializeComponent();
        }

        public SalaForm(Sala sala)
        {
            _sala = sala ?? throw new ArgumentNullException(nameof(sala));
            InitializeComponent();
            PreencherFormulario();
        }

        private void PreencherFormulario()
        {
            lblTitulo.Text       = "Editar sala";
            this.Text            = "Editar sala";
            txtNome.Text         = _sala.Nome;
            nudCapacidade.Value  = _sala.Capacidade > 0 ? _sala.Capacidade : 1;
            txtRecursos.Text     = _sala.RecursosSensoriais ?? "";
            chkAtivo.Checked     = _sala.Ativo;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            var sala = LerFormulario();

            try
            {
                if (_sala == null)
                {
                    _dao.Inserir(sala);
                    MessageBox.Show("Sala cadastrada com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sala.ID = _sala.ID;
                    _dao.Alterar(sala);
                    MessageBox.Show("Sala atualizada com sucesso!",
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

        private Sala LerFormulario()
        {
            return new Sala
            {
                Nome               = txtNome.Text.Trim(),
                Capacidade         = (int)nudCapacidade.Value,
                RecursosSensoriais = Nulo(txtRecursos.Text),
                Ativo              = chkAtivo.Checked
            };
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private static string Nulo(string texto) =>
            string.IsNullOrWhiteSpace(texto) ? null : texto.Trim();
    }
}
