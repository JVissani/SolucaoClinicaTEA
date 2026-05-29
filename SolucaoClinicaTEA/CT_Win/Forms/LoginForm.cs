using CT_Negocio.Mapeamento;
using CT_Negocio.Servicos;
using CT_Win.Recursos;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CT_Win.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // Abre o PrincipalForm e fecha este quando ele for encerrado
        private void AbrirPrincipalForm(Usuario usuario)
        {
            var principal = new PrincipalForm(usuario);
            principal.FormClosed += (s, e) => this.Close();
            this.Hide();
            principal.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            AplicarTema();
        }

        private void AplicarTema()
        {
            this.AcceptButton  = btnEntrar;
            this.ActiveControl = txtUsuario;
            this.BackColor     = Theme.Bg1;

            lblIcone.ForeColor = Theme.Primary;
            lblIcone.Font      = new Font("Segoe UI Symbol", 36F, FontStyle.Regular);

            lblTitulo.Font     = Theme.H1;
            lblTitulo.ForeColor = Theme.TextStrong;

            lblSubtitulo.Font      = Theme.Caption;
            lblSubtitulo.ForeColor = Theme.TextMuted;

            lblUsuario.Font      = Theme.Caption;
            lblUsuario.ForeColor = Theme.TextMuted;
            lblSenha.Font        = Theme.Caption;
            lblSenha.ForeColor   = Theme.TextMuted;

            EstilizarTextBox(txtUsuario);
            EstilizarTextBox(txtSenha);

            btnEntrar.FlatStyle                  = FlatStyle.Flat;
            btnEntrar.FlatAppearance.BorderSize   = 0;
            btnEntrar.BackColor                   = Theme.Primary;
            btnEntrar.ForeColor                   = Color.White;
            btnEntrar.Font                        = Theme.Button;
            btnEntrar.Cursor                      = Cursors.Hand;
            btnEntrar.MouseEnter += (s, e) => btnEntrar.BackColor = Theme.PrimaryHover;
            btnEntrar.MouseLeave += (s, e) => btnEntrar.BackColor = Theme.Primary;

            lblVersao.Font      = Theme.Caption;
            lblVersao.ForeColor = Theme.TextWeak;

            CentralizarHorizontal(lblIcone);
            ConfigurarLabelFullWidth(lblTitulo);
            ConfigurarLabelFullWidth(lblSubtitulo);
            ConfigurarLabelFullWidth(lblVersao);
        }

        private void EstilizarTextBox(TextBox txt)
        {
            txt.Font        = Theme.Body;
            txt.ForeColor   = Theme.TextStrong;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor   = Theme.Bg1;
        }

        private void CentralizarHorizontal(Control c)
        {
            c.Left = (this.ClientSize.Width - c.Width) / 2;
        }

        private void ConfigurarLabelFullWidth(Label lbl)
        {
            lbl.AutoSize  = false;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Left      = 40;
            lbl.Width     = this.ClientSize.Width - 80;
            lbl.Height    = lbl.Font.Height + 8;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string login = txtUsuario.Text.Trim();
            string senha = txtSenha.Text;

            var servico = new AutenticacaoServico();
            ResultadoAutenticacao resultado = servico.Autenticar(login, senha);

            if (resultado.Sucesso)
            {
                AbrirPrincipalForm(resultado.Usuario);
                return;
            }

            MessageBox.Show(resultado.MensagemAmigavel(), "Falha no login",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (resultado.MotivoFalha == MotivoFalhaAutenticacao.SenhaIncorreta)
            {
                txtSenha.Clear();
                txtSenha.Focus();
            }
            else if (resultado.MotivoFalha == MotivoFalhaAutenticacao.UsuarioNaoEncontrado)
            {
                txtUsuario.Clear();
                txtSenha.Clear();
                txtUsuario.Focus();
            }
        }
    }
}
