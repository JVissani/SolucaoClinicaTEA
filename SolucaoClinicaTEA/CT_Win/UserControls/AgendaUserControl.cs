using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using CT_Negocio.DAO;
using CT_Negocio.Mapeamento;
using CT_Win.Forms;
using CT_Win.Recursos;

namespace CT_Win.UserControls
{
    public partial class AgendaUserControl : UserControl
    {
        private readonly PrincipalForm  _principal;
        private readonly AgendamentoDAO _dao = new AgendamentoDAO();

        private List<Agendamento> _lista          = new List<Agendamento>();
        private Agendamento       _selecionado    = null;
        private Panel             _rowSelecionado = null;
        private string            _filtroAtivo    = "Proximos";

        private FlowLayoutPanel _flwLista;

        public AgendaUserControl(PrincipalForm principal)
        {
            _principal = principal ?? throw new ArgumentNullException(nameof(principal));
            InitializeComponent();
            ConfigurarNav();
            InicializarFlowPanel();
            CarregarLista();
            pnlListaContainer.Resize += (s, e) => AtualizarLarguraItens();
        }

        private void InicializarFlowPanel()
        {
            _flwLista = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents  = false,
                AutoSize      = true,
                AutoSizeMode  = AutoSizeMode.GrowAndShrink,
                Dock          = DockStyle.Top,
                BackColor     = Theme.Bg2,
                Padding       = new Padding(16, 12, 16, 16)
            };
            pnlListaContainer.Controls.Add(_flwLista);
        }

        private void CarregarLista()
        {
            try
            {
                switch (_filtroAtivo)
                {
                    case "Realizados": _lista = _dao.ListarRealizados(); break;
                    case "Faltas":     _lista = _dao.ListarFaltas();     break;
                    default:           _lista = _dao.ListarProximos();   break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar agenda: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _lista = new List<Agendamento>();
            }
            PopularLista();
        }

        private void PopularLista()
        {
            _selecionado    = null;
            _rowSelecionado = null;
            AtualizarBotoes();

            var filtrado = FiltrarBusca(_lista);

            _flwLista.SuspendLayout();
            _flwLista.Controls.Clear();

            if (filtrado.Count == 0)
            {
                var lbl = new Label
                {
                    Text      = "Nenhum agendamento encontrado.",
                    Font      = new Font("Segoe UI", 10F),
                    ForeColor = Theme.TextWeak,
                    AutoSize  = false,
                    Size      = new Size(Math.Max(200, pnlListaContainer.ClientSize.Width - 32), 40),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                _flwLista.Controls.Add(lbl);
                _flwLista.ResumeLayout();
                return;
            }

            DateTime? diaAtual = null;
            int largura = Math.Max(100, pnlListaContainer.ClientSize.Width - _flwLista.Padding.Horizontal);

            foreach (var ag in filtrado.OrderBy(a => a.DataHoraInicio))
            {
                if (diaAtual == null || ag.DataHoraInicio.Date != diaAtual.Value)
                {
                    diaAtual = ag.DataHoraInicio.Date;
                    var header = CriarHeaderDia(diaAtual.Value);
                    header.Width = largura;
                    _flwLista.Controls.Add(header);
                }

                var row = CriarLinhaAgendamento(ag);
                row.Width = largura;
                _flwLista.Controls.Add(row);
            }

            _flwLista.ResumeLayout();
            AtualizarLarguraItens();
        }

        private List<Agendamento> FiltrarBusca(List<Agendamento> lista)
        {
            string termo = txtBusca.Text.Trim().ToLowerInvariant();
            if (string.IsNullOrEmpty(termo)) return lista;

            return lista.Where(a =>
            {
                string pacNome  = a.Paciente      != null ? a.Paciente.NomeExibicao.ToLowerInvariant()     : "";
                string profNome = a.Profissional   != null ? a.Profissional.NomeExibicao.ToLowerInvariant() : "";
                string esp      = (a.Profissional != null && a.Profissional.Especialidade != null)
                                      ? a.Profissional.Especialidade.Nome.ToLowerInvariant()
                                      : "";
                return pacNome.Contains(termo) || profNome.Contains(termo) || esp.Contains(termo);
            }).ToList();
        }

        private Panel CriarHeaderDia(DateTime dia)
        {
            bool ehHoje   = dia.Date == DateTime.Today;
            bool ehAmanha = dia.Date == DateTime.Today.AddDays(1);

            string texto;
            if (ehHoje)        texto = "Hoje  —  " + dia.ToString("dddd, dd/MM/yyyy");
            else if (ehAmanha) texto = "Amanhã  —  " + dia.ToString("dddd, dd/MM/yyyy");
            else               texto = dia.ToString("dddd, dd/MM/yyyy");

            texto = char.ToUpper(texto[0]) + texto.Substring(1);

            var pnl = new Panel
            {
                Height    = 36,
                BackColor = Theme.Bg2,
                Margin    = new Padding(0, ehHoje ? 0 : 16, 0, 4)
            };

            var lbl = new Label
            {
                Text      = texto,
                Font      = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = ehHoje ? Theme.Primary : Theme.TextMuted,
                Location  = new Point(0, 8),
                AutoSize  = true
            };
            pnl.Controls.Add(lbl);

            var sep = new Panel { BackColor = Theme.Border1, Height = 1, Dock = DockStyle.Bottom };
            pnl.Controls.Add(sep);

            return pnl;
        }

        private Panel CriarLinhaAgendamento(Agendamento ag)
        {
            var pnlOuter = new Panel
            {
                Height    = 58,
                BackColor = Color.White,
                Margin    = new Padding(0, 1, 0, 0),
                Cursor    = Cursors.Hand,
                Tag       = ag
            };

            pnlOuter.Paint += (s, e) =>
            {
                using (var pen = new Pen(Theme.Border1))
                    e.Graphics.DrawRectangle(pen, 0, 0, pnlOuter.Width - 1, pnlOuter.Height - 1);
            };

            var tbl = new TableLayoutPanel
            {
                Dock        = DockStyle.Fill,
                ColumnCount = 4,
                RowCount    = 1,
                BackColor   = Color.Transparent,
                Padding     = new Padding(0)
            };
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,  72F)); // hora
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,  100F)); // nomes
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 138F)); // chip
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,  30F)); // dot

            var pnlHora = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent };
            var lblInicio = new Label
            {
                Text      = ag.DataHoraInicio.ToString("HH:mm"),
                Font      = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Theme.TextStrong,
                AutoSize  = false,
                TextAlign = ContentAlignment.BottomCenter,
                Dock      = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            var lblFim = new Label
            {
                Text      = ag.DataHoraFim.ToString("HH:mm"),
                Font      = new Font("Segoe UI", 7.5F),
                ForeColor = Theme.TextWeak,
                AutoSize  = false,
                TextAlign = ContentAlignment.TopCenter,
                Height    = 18,
                Dock      = DockStyle.Bottom,
                BackColor = Color.Transparent
            };
            pnlHora.Controls.Add(lblInicio);
            pnlHora.Controls.Add(lblFim);

            var pnlNomes = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent, Padding = new Padding(10, 0, 8, 0) };
            var lblPac = new Label
            {
                Text      = ag.Paciente != null ? ag.Paciente.NomeExibicao : "—",
                Font      = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Theme.TextStrong,
                AutoSize  = false,
                TextAlign = ContentAlignment.BottomLeft,
                Dock      = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            var lblProf = new Label
            {
                Text      = ag.Profissional != null ? ag.Profissional.NomeExibicao : "—",
                Font      = new Font("Segoe UI", 8.5F),
                ForeColor = Theme.TextMuted,
                AutoSize  = false,
                TextAlign = ContentAlignment.TopLeft,
                Height    = 20,
                Dock      = DockStyle.Bottom,
                BackColor = Color.Transparent
            };
            pnlNomes.Controls.Add(lblPac);
            pnlNomes.Controls.Add(lblProf);

            var pnlChip = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent };
            if (ag.Profissional != null && ag.Profissional.Especialidade != null)
            {
                var chip = CriarChip(ag.Profissional.Especialidade);
                pnlChip.Controls.Add(chip);
                pnlChip.Resize += (s, e) =>
                {
                    chip.Location = new Point(
                        (pnlChip.Width  - chip.Width)  / 2,
                        (pnlChip.Height - chip.Height) / 2);
                };
            }

            var pnlDot = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent };
            Color dotCor = CorDot(ag.Status);
            var dot = new Panel { Size = new Size(10, 10), BackColor = Color.Transparent };
            dot.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var br = new SolidBrush(dotCor))
                    e.Graphics.FillEllipse(br, 0, 0, 9, 9);
            };
            pnlDot.Controls.Add(dot);
            pnlDot.Resize += (s, e) =>
            {
                dot.Location = new Point(
                    (pnlDot.Width  - dot.Width)  / 2,
                    (pnlDot.Height - dot.Height) / 2);
            };

            tbl.Controls.Add(pnlHora,  0, 0);
            tbl.Controls.Add(pnlNomes, 1, 0);
            tbl.Controls.Add(pnlChip,  2, 0);
            tbl.Controls.Add(pnlDot,   3, 0);

            pnlOuter.Controls.Add(tbl);

            var filhos = new Control[] { tbl, pnlHora, lblInicio, lblFim, pnlNomes, lblPac, lblProf, pnlChip, pnlDot };
            pnlOuter.Click += (s, e) => SelecionarLinha(pnlOuter, ag);
            foreach (var c in filhos)
                c.Click += (s, e) => SelecionarLinha(pnlOuter, ag);

            return pnlOuter;
        }

        private Label CriarChip(Especialidade esp)
        {
            Color bg = PastelDe(esp.CorHex);
            Color fg = EscurecerHex(esp.CorHex);

            return new Label
            {
                Text      = esp.Nome,
                Font      = new Font("Segoe UI", 7.5F),
                ForeColor = fg,
                BackColor = bg,
                AutoSize  = false,
                Size      = new Size(118, 22),
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private static Color PastelDe(string hex)
        {
            if (string.IsNullOrEmpty(hex)) return Color.FromArgb(220, 230, 240);
            try
            {
                Color c = ColorTranslator.FromHtml(hex);
                return Color.FromArgb(
                    (int)(c.R + (255 - c.R) * 0.75f),
                    (int)(c.G + (255 - c.G) * 0.75f),
                    (int)(c.B + (255 - c.B) * 0.75f));
            }
            catch { return Color.FromArgb(220, 230, 240); }
        }

        private static Color EscurecerHex(string hex)
        {
            if (string.IsNullOrEmpty(hex)) return Color.FromArgb(50, 70, 90);
            try
            {
                Color c = ColorTranslator.FromHtml(hex);
                return Color.FromArgb(
                    (int)(c.R * 0.55f),
                    (int)(c.G * 0.55f),
                    (int)(c.B * 0.55f));
            }
            catch { return Color.FromArgb(50, 70, 90); }
        }

        private static Color CorDot(string status)
        {
            switch (status)
            {
                case "Realizado": return Theme.Success;
                case "Faltou":    return Theme.Danger;
                case "Cancelado": return Theme.TextWeak;
                default:          return Color.FromArgb(34, 197, 94);
            }
        }

        private void SelecionarLinha(Panel row, Agendamento ag)
        {
            if (_rowSelecionado != null && _rowSelecionado != row)
                _rowSelecionado.BackColor = Color.White;

            _selecionado    = ag;
            _rowSelecionado = row;
            row.BackColor   = Theme.PrimaryLight;
            AtualizarBotoes();
        }

        private void AtualizarBotoes()
        {
            bool tem       = _selecionado != null;
            bool realizado = tem && _selecionado.Status == "Realizado";

            btnEditar.Enabled      = tem;
            btnMudarStatus.Enabled = tem;
            btnExcluir.Enabled     = tem;
            btnEvolucao.Enabled    = realizado;

            btnEvolucao.Text = realizado && _selecionado.Evolucao != null
                ? "Ver evolução"
                : "Registrar evolução";
        }

        private void AtualizarLarguraItens()
        {
            if (_flwLista == null) return;
            int w = Math.Max(100, pnlListaContainer.ClientSize.Width - _flwLista.Padding.Horizontal);
            foreach (Control c in _flwLista.Controls)
                c.Width = w;
        }

        private void btnPillProximos_Click(object sender, EventArgs e)
        {
            _filtroAtivo = "Proximos";
            AtivarPill(btnPillProximos);
            CarregarLista();
        }

        private void btnPillRealizados_Click(object sender, EventArgs e)
        {
            _filtroAtivo = "Realizados";
            AtivarPill(btnPillRealizados);
            CarregarLista();
        }

        private void btnPillFaltas_Click(object sender, EventArgs e)
        {
            _filtroAtivo = "Faltas";
            AtivarPill(btnPillFaltas);
            CarregarLista();
        }

        private void AtivarPill(Button ativo)
        {
            var pills = new[] { btnPillProximos, btnPillRealizados, btnPillFaltas };
            foreach (var p in pills)
            {
                bool isAtivo = (p == ativo);
                p.BackColor = isAtivo ? Theme.Primary : Color.Transparent;
                p.ForeColor = isAtivo ? Color.White   : Theme.TextMuted;
                p.Font      = new Font("Segoe UI", 8.5F, isAtivo ? FontStyle.Bold : FontStyle.Regular);
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e) => PopularLista();

        private void btnNovo_Click(object sender, EventArgs e)
        {
            using (var form = new AgendamentoForm(_principal.IDUsuarioLogado))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    CarregarLista();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_selecionado == null) return;
            using (var form = new AgendamentoForm(_selecionado, _principal.IDUsuarioLogado))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    CarregarLista();
            }
        }

        private void btnMudarStatus_Click(object sender, EventArgs e)
        {
            if (_selecionado == null) return;

            var menu = new ContextMenuStrip();
            menu.Closed += (s2, e2) => menu.Dispose();

            foreach (var status in new[] { "Agendado", "Realizado", "Faltou", "Cancelado" })
            {
                string localStatus = status;
                var item = new ToolStripMenuItem(status)
                {
                    Font    = _selecionado.Status == status
                                  ? new Font("Segoe UI", 9F, FontStyle.Bold)
                                  : new Font("Segoe UI", 9F),
                    Checked = _selecionado.Status == status
                };
                item.Click += (s2, e2) =>
                {
                    try
                    {
                        _dao.AtualizarStatus(_selecionado.ID, localStatus);
                        CarregarLista();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao atualizar status: " + ex.Message, "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
                menu.Items.Add(item);
            }

            menu.Show(btnMudarStatus, new Point(0, btnMudarStatus.Height));
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_selecionado == null) return;

            string nomePac = _selecionado.Paciente != null
                                 ? _selecionado.Paciente.NomeExibicao
                                 : "este agendamento";

            var resp = MessageBox.Show(
                "Excluir o agendamento de " + nomePac +
                " em " + _selecionado.DataHoraInicio.ToString("dd/MM/yyyy HH:mm") + "?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resp != DialogResult.Yes) return;

            try
            {
                _dao.Excluir(_selecionado.ID);
                CarregarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEvolucao_Click(object sender, EventArgs e)
        {
            if (_selecionado == null || _selecionado.Status != "Realizado") return;

            try
            {
                var evolucaoDao = new EvolucaoSessaoDAO();
                EvolucaoSessao evolucao = evolucaoDao.BuscarPorAgendamento(_selecionado.ID);

                Form form = evolucao == null
                    ? new EvolucaoSessaoForm(_selecionado)
                    : new EvolucaoSessaoForm(_selecionado, evolucao);

                using (form)
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                        CarregarLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir evolução:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInicio_Click(object sender, EventArgs e) => _principal.MostrarDashboard();

        private void ConfigurarNav()
        {
            btnNavAgenda.BackColor = Color.FromArgb(44, 95, 127);
            btnNavAgenda.ForeColor = Color.White;
            btnNavAgenda.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);

            btnNavPacientes.Click      += (s, e) => _principal.AbrirTela(new PacienteUserControl(_principal));
            btnNavProfissionais.Click  += (s, e) => _principal.AbrirTela(new ProfissionalUserControl(_principal));
            btnNavEspecialidades.Click += (s, e) => _principal.AbrirTela(new EspecialidadeUserControl(_principal));
            btnNavSalas.Click          += (s, e) => _principal.AbrirTela(new SalaUserControl(_principal));
            btnNavRelatorios.Click     += (s, e) => _principal.AbrirTela(new RelatorioUserControl(_principal));
        }
    }
}
