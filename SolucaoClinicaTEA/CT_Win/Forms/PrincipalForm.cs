using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CT_Negocio.Mapeamento;
using CT_Win.Recursos;

namespace CT_Win.Forms
{
    public partial class PrincipalForm : Form
    {
        private readonly Usuario _usuarioLogado;

        private const int CardWidth       = 340;
        private const int CardHeight      = 200;
        private const int GapHorizontal   = 28;
        private const int GapVertical     = 28;
        private const int ColunasPorLinha = 3;
        private const int EspacoTopoCards = 110;

        public PrincipalForm(Usuario usuarioLogado)
        {
            if (usuarioLogado == null)
                throw new ArgumentNullException(nameof(usuarioLogado));

            _usuarioLogado = usuarioLogado;
            InitializeComponent();

            AplicarTemaCabecalho();
            PreencherDadosUsuario();
            MostrarDashboard();

            pnlConteudo.SizeChanged += (s, e) =>
            {
                bool estaNoDashboard = pnlConteudo.Controls.OfType<Label>()
                                                  .Any(l => l.Name == "lblSaudacao");
                if (estaNoDashboard) RepositionarTudo();
            };
        }

        private void AplicarTemaCabecalho()
        {
            this.BackColor         = Theme.Bg2;
            pnlCabecalho.BackColor = Theme.Primary;

            lblHeaderTitulo.Font      = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeaderTitulo.ForeColor = Color.White;

            lblHeaderSubtitulo.Font      = Theme.Caption;
            lblHeaderSubtitulo.ForeColor = Color.FromArgb(220, 230, 240);

            lblUsuarioLogado.Font      = Theme.Body;
            lblUsuarioLogado.ForeColor = Color.White;

            pnlConteudo.BackColor = Theme.Bg2;
        }

        private void PreencherDadosUsuario()
        {
            lblUsuarioLogado.Text = _usuarioLogado.Nome + "  •  Perfil: " + _usuarioLogado.Perfil;
        }

        public int IDUsuarioLogado => _usuarioLogado != null ? _usuarioLogado.ID : 1;

        public void MostrarDashboard()
        {
            pnlConteudo.Controls.Clear();
            ConstruirDashboard();
        }

        public void AbrirTela(UserControl tela)
        {
            pnlConteudo.Controls.Clear();
            tela.Dock = DockStyle.Fill;
            pnlConteudo.Controls.Add(tela);
        }

        private void ConstruirDashboard()
        {
            var lblSaudacao = new Label
            {
                Name      = "lblSaudacao",
                Text      = "Bem-vindo, " + _usuarioLogado.Nome,
                Font      = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Theme.TextStrong,
                AutoSize  = true
            };
            pnlConteudo.Controls.Add(lblSaudacao);

            var lblInstrucao = new Label
            {
                Name      = "lblInstrucao",
                Text      = "Escolha uma área para começar",
                Font      = new Font("Segoe UI", 10F),
                ForeColor = Theme.TextMuted,
                AutoSize  = true
            };
            pnlConteudo.Controls.Add(lblInstrucao);

            var dadosCards = new[]
            {
                new { Id = "pacientes",      Icone = "👤", Titulo = "Pacientes",      Descricao = "Cadastro e prontuário" },
                new { Id = "profissionais",  Icone = "👥", Titulo = "Profissionais",  Descricao = "Equipe clínica" },
                new { Id = "agenda",         Icone = "📅", Titulo = "Agenda",         Descricao = "Agendamentos" },
                new { Id = "especialidades", Icone = "🩺", Titulo = "Especialidades", Descricao = "Áreas clínicas" },
                new { Id = "salas",          Icone = "🚪", Titulo = "Salas",          Descricao = "Espaços físicos" },
                new { Id = "relatorios",     Icone = "📊", Titulo = "Relatórios",     Descricao = "Dashboards" }
            };

            foreach (var d in dadosCards)
                pnlConteudo.Controls.Add(CriarCard(d.Id, d.Icone, d.Titulo, d.Descricao));

            RepositionarTudo();
        }

        private void RepositionarTudo()
        {
            var lblSaudacao = pnlConteudo.Controls.OfType<Label>()
                                         .FirstOrDefault(l => l.Name == "lblSaudacao");
            if (lblSaudacao == null) return;

            int larguraDosCards = ColunasPorLinha * CardWidth + (ColunasPorLinha - 1) * GapHorizontal;
            int margemLateral   = Math.Max(32, (pnlConteudo.Width - larguraDosCards) / 2);

            var lblInstrucao = pnlConteudo.Controls.OfType<Label>()
                                          .FirstOrDefault(l => l.Name == "lblInstrucao");

            lblSaudacao.Location = new Point(margemLateral, 28);
            if (lblInstrucao != null) lblInstrucao.Location = new Point(margemLateral, 64);

            var cards = pnlConteudo.Controls.OfType<Panel>().ToList();
            for (int i = 0; i < cards.Count; i++)
            {
                int linha  = i / ColunasPorLinha;
                int coluna = i % ColunasPorLinha;
                cards[i].Location = new Point(
                    margemLateral + coluna * (CardWidth + GapHorizontal),
                    EspacoTopoCards + linha * (CardHeight + GapVertical));
            }
        }

        private Panel CriarCard(string id, string icone, string titulo, string descricao)
        {
            var card = new Panel
            {
                Size        = new Size(CardWidth, CardHeight),
                BackColor   = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor      = Cursors.Hand,
                Tag         = id
            };

            var lblIcone = new Label
            {
                Text      = icone,
                Font      = new Font("Segoe UI Emoji", 36F),
                TextAlign = ContentAlignment.MiddleCenter,
                Location  = new Point(0, 24),
                Size      = new Size(CardWidth, 72),
                AutoSize  = false
            };
            card.Controls.Add(lblIcone);

            var lblTitulo = new Label
            {
                Text      = titulo,
                Font      = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Theme.TextStrong,
                TextAlign = ContentAlignment.MiddleCenter,
                Location  = new Point(0, 108),
                Size      = new Size(CardWidth, 28),
                AutoSize  = false
            };
            card.Controls.Add(lblTitulo);

            var lblDesc = new Label
            {
                Text      = descricao,
                Font      = new Font("Segoe UI", 10F),
                ForeColor = Theme.TextMuted,
                TextAlign = ContentAlignment.MiddleCenter,
                Location  = new Point(0, 142),
                Size      = new Size(CardWidth, 22),
                AutoSize  = false
            };
            card.Controls.Add(lblDesc);

            void AcenderHover(object s, EventArgs e) => card.BackColor = Theme.PrimaryLight;
            void ApagarHover(object s, EventArgs e)
            {
                Point pos = card.PointToClient(Cursor.Position);
                if (!card.ClientRectangle.Contains(pos)) card.BackColor = Color.White;
            }

            foreach (Control c in new Control[] { card, lblIcone, lblTitulo, lblDesc })
            {
                c.MouseEnter += AcenderHover;
                c.MouseLeave += ApagarHover;
            }

            void OnClick(object s, EventArgs e)
            {
                switch (id)
                {
                    case "pacientes":      AbrirTela(new UserControls.PacienteUserControl(this));      break;
                    case "profissionais":  AbrirTela(new UserControls.ProfissionalUserControl(this));  break;
                    case "agenda":         AbrirTela(new UserControls.AgendaUserControl(this));         break;
                    case "especialidades": AbrirTela(new UserControls.EspecialidadeUserControl(this)); break;
                    case "salas":          AbrirTela(new UserControls.SalaUserControl(this));          break;
                    case "relatorios":     AbrirTela(new UserControls.RelatorioUserControl(this));     break;
                }
            }

            foreach (Control c in new Control[] { card, lblIcone, lblTitulo, lblDesc })
                c.Click += OnClick;

            return card;
        }
    }
}
