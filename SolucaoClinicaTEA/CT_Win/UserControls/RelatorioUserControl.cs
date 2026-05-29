using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CT_Negocio.DAO;
using CT_Negocio.Mapeamento;
using CT_Win.Forms;
using CT_Win.Recursos;

namespace CT_Win.UserControls
{
    public partial class RelatorioUserControl : UserControl
    {
        private readonly PrincipalForm _principal;
        private readonly RelatorioDAO  _dao = new RelatorioDAO();

        public RelatorioUserControl(PrincipalForm principal)
        {
            _principal = principal ?? throw new ArgumentNullException(nameof(principal));
            InitializeComponent();
            ConfigurarNav();
            ConstruirCards();
        }

        private void ConstruirCards()
        {
            var flw = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents  = false,
                AutoSize      = true,
                AutoSizeMode  = AutoSizeMode.GrowAndShrink,
                Dock          = DockStyle.Top,
                BackColor     = Theme.Bg2,
                Padding       = new Padding(24, 20, 24, 24)
            };
            pnlConteudo.Controls.Add(flw);

            pnlConteudo.Resize += (s, e) =>
            {
                int w      = pnlConteudo.ClientSize.Width;
                flw.Width  = w;
                int innerW = w - flw.Padding.Horizontal;
                foreach (Control c in flw.Controls)
                    c.Width = innerW;
            };

            flw.Controls.Add(CriarHeaderSecao("PACIENTES"));
            flw.Controls.Add(CriarGridCards(new[]
            {
                new DadosCard("📈", "Linha do tempo",
                    "Evolução cronológica das sessões do paciente",
                    (s, e) => AbrirRelatorioComPaciente("Linha do Tempo",
                        (id, de, ate) => _dao.HistoricoPaciente(id, de, ate))),

                new DadosCard("📋", "Prontuário completo",
                    "Todas as sessões do paciente com observações",
                    (s, e) => AbrirRelatorioComPaciente("Prontuário Completo",
                        (id, de, ate) => _dao.HistoricoPaciente(id, de, ate))),

                new DadosCard("📅", "Frequência",
                    "Presenças, faltas e cancelamentos por paciente",
                    (s, e) => AbrirRelatorio("Frequência por Paciente",
                        (de, ate) => _dao.FrequenciaPorPaciente(de, ate))),

                new DadosCard("🎯", "Objetivos terapêuticos",
                    "Status e progresso dos objetivos por especialidade",
                    (s, e) => AbrirRelatorio("Objetivos Terapêuticos",
                        (de, ate) => _dao.ObjetivosTerapeuticos(de, ate))),
            }));

            flw.Controls.Add(CriarEspacador());

            flw.Controls.Add(CriarHeaderSecao("PROFISSIONAIS"));
            flw.Controls.Add(CriarGridCards(new[]
            {
                new DadosCard("👤", "Sessões por profissional",
                    "Total de sessões por período e status",
                    (s, e) => AbrirRelatorio("Sessões por Profissional",
                        (de, ate) => _dao.SessoesPorProfissional(de, ate))),

                new DadosCard("👥", "Pacientes atendidos",
                    "Lista de pacientes atendidos por profissional",
                    (s, e) => AbrirRelatorio("Pacientes Atendidos por Profissional",
                        (de, ate) => _dao.PacientesAtendidosPorProfissional(de, ate))),
            }));

            flw.Controls.Add(CriarEspacador());

            flw.Controls.Add(CriarHeaderSecao("OPERACIONAL"));
            flw.Controls.Add(CriarGridCards(new[]
            {
                new DadosCard("🚪", "Ocupação de salas",
                    "Percentual de aproveitamento por sala",
                    (s, e) => AbrirRelatorio("Ocupação de Salas",
                        (de, ate) => _dao.OcupacaoSalas(de, ate))),

                new DadosCard("📊", "Resumo geral",
                    "KPIs consolidados do período",
                    (s, e) => AbrirRelatorio("Resumo Geral",
                        (de, ate) => _dao.ResumoGeral(de, ate))),
            }));
        }

        private void AbrirRelatorio(string titulo, Func<DateTime, DateTime, System.Data.DataTable> loader)
        {
            using (var form = new RelatorioViewerForm(titulo, loader))
                form.ShowDialog(this);
        }

        private void AbrirRelatorioComPaciente(string titulo,
            Func<int, DateTime, DateTime, System.Data.DataTable> loader)
        {
            var pacientes = new PacienteDAO().Listar(soAtivos: false);
            if (pacientes.Count == 0)
            {
                MessageBox.Show("Nenhum paciente cadastrado.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dlg = CriarDialogSelecionarPaciente(pacientes))
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                var pac = dlg.Tag as Paciente;
                if (pac == null) return;

                string tituloCompleto = titulo + " — " + pac.NomeExibicao;
                AbrirRelatorio(tituloCompleto, (de, ate) => loader(pac.ID, de, ate));
            }
        }

        private static Form CriarDialogSelecionarPaciente(List<Paciente> pacientes)
        {
            var dlg = new Form
            {
                Text            = "Selecionar Paciente",
                ClientSize      = new Size(420, 130),
                StartPosition   = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox     = false,
                MinimizeBox     = false,
                BackColor       = Color.White,
                Font            = new Font("Segoe UI", 9F)
            };

            var lbl = new Label
            {
                Text      = "Selecione o paciente:",
                AutoSize  = true,
                Font      = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(55, 65, 81),
                Location  = new Point(20, 18)
            };

            var cmb = new ComboBox
            {
                Location      = new Point(20, 38),
                Width         = 380,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font          = new Font("Segoe UI", 9.5F)
            };
            foreach (var p in pacientes) cmb.Items.Add(p);
            cmb.DisplayMember = "NomeExibicao";
            if (cmb.Items.Count > 0) cmb.SelectedIndex = 0;

            var btnOK = new Button
            {
                Text         = "Confirmar",
                DialogResult = DialogResult.OK,
                Location     = new Point(220, 80),
                Size         = new Size(90, 32),
                Font         = new Font("Segoe UI", 9F),
                BackColor    = Color.FromArgb(44, 95, 127),
                ForeColor    = Color.White,
                FlatStyle    = FlatStyle.Flat,
                Cursor       = Cursors.Hand
            };
            btnOK.FlatAppearance.BorderSize = 0;

            var btnCancelar = new Button
            {
                Text         = "Cancelar",
                DialogResult = DialogResult.Cancel,
                Location     = new Point(318, 80),
                Size         = new Size(82, 32),
                Font         = new Font("Segoe UI", 9F),
                BackColor    = Color.White,
                ForeColor    = Color.FromArgb(91, 101, 115),
                FlatStyle    = FlatStyle.Flat,
                Cursor       = Cursors.Hand
            };
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(197, 205, 214);
            btnCancelar.FlatAppearance.BorderSize  = 1;

            dlg.AcceptButton = btnOK;
            dlg.CancelButton = btnCancelar;
            btnOK.Click += (s, e) => dlg.Tag = cmb.SelectedItem as Paciente;

            dlg.Controls.AddRange(new Control[] { lbl, cmb, btnOK, btnCancelar });
            return dlg;
        }

        private Label CriarHeaderSecao(string texto)
        {
            return new Label
            {
                Text      = texto,
                Font      = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Theme.TextWeak,
                AutoSize  = false,
                Height    = 28,
                Margin    = new Padding(0, 0, 0, 4),
                TextAlign = System.Drawing.ContentAlignment.BottomLeft,
                BackColor = Color.Transparent
            };
        }

        private Panel CriarEspacador()
        {
            return new Panel { Height = 12, BackColor = Color.Transparent };
        }

        private TableLayoutPanel CriarGridCards(DadosCard[] cards)
        {
            const int colunas = 2;
            int linhas = (int)Math.Ceiling(cards.Length / (double)colunas);

            var tbl = new TableLayoutPanel
            {
                ColumnCount = colunas,
                RowCount    = linhas,
                AutoSize    = false,
                BackColor   = Color.Transparent,
                Margin      = new Padding(0),
                Padding     = new Padding(0),
                Height      = linhas * 96
            };

            for (int c = 0; c < colunas; c++)
                tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            for (int r = 0; r < linhas; r++)
                tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));

            for (int i = 0; i < cards.Length; i++)
            {
                int col  = i % colunas;
                int row  = i / colunas;
                var card = CriarCard(cards[i]);
                card.Margin = new Padding(col == 0 ? 0 : 6, 10, col == 0 ? 6 : 0, 0);
                tbl.Controls.Add(card, col, row);
            }

            return tbl;
        }

        private Panel CriarCard(DadosCard dados)
        {
            var pnl = new Panel
            {
                BackColor   = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Dock        = DockStyle.Fill,
                Padding     = new Padding(14, 10, 14, 10)
            };

            var lblIcone = new Label
            {
                Text      = dados.Icone,
                Font      = new Font("Segoe UI Emoji", 18F),
                AutoSize  = false,
                Size      = new Size(44, 52),
                Location  = new Point(14, 12),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };

            var lblTitulo = new Label
            {
                Text      = dados.Titulo,
                Font      = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Theme.TextStrong,
                AutoSize  = false,
                Location  = new Point(64, 14),
                Size      = new Size(300, 20),
                BackColor = Color.Transparent
            };

            var lblDesc = new Label
            {
                Text      = dados.Descricao,
                Font      = new Font("Segoe UI", 8.5F),
                ForeColor = Theme.TextMuted,
                AutoSize  = false,
                Location  = new Point(64, 36),
                Size      = new Size(300, 18),
                BackColor = Color.Transparent
            };

            var btn = new Button
            {
                Text      = "Gerar",
                Font      = new Font("Segoe UI", 8.5F),
                BackColor = Theme.Primary,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand,
                Size      = new Size(72, 28),
                Anchor    = AnchorStyles.Bottom | AnchorStyles.Right
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => btn.BackColor = Theme.PrimaryHover;
            btn.MouseLeave += (s, e) => btn.BackColor = Theme.Primary;
            btn.Click      += dados.OnGerar;

            pnl.Resize += (s, e) =>
            {
                btn.Location    = new Point(pnl.Width - btn.Width - 14, (pnl.Height - btn.Height) / 2);
                int maxW        = btn.Location.X - 64 - 8;
                lblTitulo.Width = maxW;
                lblDesc.Width   = maxW;
            };

            pnl.Controls.Add(lblIcone);
            pnl.Controls.Add(lblTitulo);
            pnl.Controls.Add(lblDesc);
            pnl.Controls.Add(btn);

            return pnl;
        }

        private void btnInicio_Click(object sender, EventArgs e) => _principal.MostrarDashboard();

        private void ConfigurarNav()
        {
            btnNavRelatorios.BackColor = Color.FromArgb(44, 95, 127);
            btnNavRelatorios.ForeColor = Color.White;
            btnNavRelatorios.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);

            btnNavPacientes.Click      += (s, e) => _principal.AbrirTela(new PacienteUserControl(_principal));
            btnNavProfissionais.Click  += (s, e) => _principal.AbrirTela(new ProfissionalUserControl(_principal));
            btnNavAgenda.Click         += (s, e) => _principal.AbrirTela(new AgendaUserControl(_principal));
            btnNavEspecialidades.Click += (s, e) => _principal.AbrirTela(new EspecialidadeUserControl(_principal));
            btnNavSalas.Click          += (s, e) => _principal.AbrirTela(new SalaUserControl(_principal));
        }

        private struct DadosCard
        {
            public string       Icone;
            public string       Titulo;
            public string       Descricao;
            public EventHandler OnGerar;

            public DadosCard(string icone, string titulo, string descricao, EventHandler onGerar)
            {
                Icone     = icone;
                Titulo    = titulo;
                Descricao = descricao;
                OnGerar   = onGerar;
            }
        }
    }
}
