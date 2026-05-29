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
    public partial class ProfissionalUserControl : UserControl
    {
        private readonly PrincipalForm   _principal;
        private readonly ProfissionalDAO _dao = new ProfissionalDAO();
        private string _filtroStatus = "Todos";

        public ProfissionalUserControl(PrincipalForm principal)
        {
            _principal = principal ?? throw new ArgumentNullException(nameof(principal));
            InitializeComponent();

            AplicarEstiloGrid();
            AplicarHoverBotoes();
            CarregarGrid();
            ConfigurarNav();
        }

        private void AplicarEstiloGrid()
        {
            dgv.ColumnHeadersDefaultCellStyle.BackColor  = Theme.Bg3;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor  = Theme.TextStrong;
            dgv.ColumnHeadersDefaultCellStyle.Font       = Theme.BodyBold;
            dgv.ColumnHeadersDefaultCellStyle.Padding    = new Padding(8, 0, 8, 0);
            dgv.DefaultCellStyle.SelectionBackColor       = Theme.PrimaryLight;
            dgv.DefaultCellStyle.SelectionForeColor       = Theme.TextStrong;
            dgv.DefaultCellStyle.Padding                  = new Padding(8, 0, 8, 0);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        private void AplicarHoverBotoes()
        {
            btnNovo.MouseEnter  += (s, e) => btnNovo.BackColor = Theme.PrimaryHover;
            btnNovo.MouseLeave  += (s, e) => btnNovo.BackColor = Theme.Primary;
            btnNovo.Cursor       = Cursors.Hand;
            btnEditar.Cursor     = Cursors.Hand;
            btnInativar.Cursor   = Cursors.Hand;
            btnExcluir.Cursor    = Cursors.Hand;
            btnInicio.Cursor     = Cursors.Hand;
        }

        private void CarregarGrid(string filtro = "")
        {
            try
            {
                var lista = _dao.Listar(soAtivos: false);

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    var f = filtro.ToLowerInvariant();
                    lista = lista.Where(p =>
                        (p.Nome       ?? "").ToLowerInvariant().Contains(f) ||
                        (p.NomeSocial ?? "").ToLowerInvariant().Contains(f) ||
                        (p.CPF        ?? "").Contains(f) ||
                        (p.Especialidade?.Nome ?? "").ToLowerInvariant().Contains(f)
                    ).ToList();
                }

                if (_filtroStatus == "Ativos")
                    lista = lista.Where(p => p.Ativo).ToList();
                else if (_filtroStatus == "Inativos")
                    lista = lista.Where(p => !p.Ativo).ToList();

                PreencherGrid(lista);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar profissionais: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherGrid(List<Profissional> lista)
        {
            dgv.Rows.Clear();
            foreach (var p in lista)
            {
                string nomeEsp  = p.Especialidade?.Nome          ?? "—";
                string conselho = p.Especialidade?.ConselhoSigla ?? "—";
                string registro = string.IsNullOrWhiteSpace(p.RegistroConselho)
                                    ? "—"
                                    : conselho + " " + p.RegistroConselho;
                string status   = p.Ativo ? "Ativo" : "Inativo";

                int idx = dgv.Rows.Add(p.NomeExibicao, nomeEsp, registro, status);
                dgv.Rows[idx].Tag = p;
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e) =>
            CarregarGrid(txtBusca.Text);

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            bool temSelecao = dgv.SelectedRows.Count > 0;
            btnEditar.Enabled   = temSelecao;
            btnInativar.Enabled = temSelecao;
            btnExcluir.Enabled  = temSelecao;

            if (temSelecao)
            {
                string st = dgv.SelectedRows[0].Cells["colStatus"].Value?.ToString();
                btnInativar.Text = (st == "Ativo") ? "Inativar" : "Reativar";
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var prof = dgv.Rows[e.RowIndex].Tag as Profissional;
            if (prof != null) AbrirEdicao(prof.ID);
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0) return;

            if (e.RowIndex < 0)
            {
                e.Handled = true;
                using (var br = new SolidBrush(Theme.Bg3))
                    e.Graphics.FillRectangle(br, e.CellBounds);
                using (var pen = new Pen(Theme.Border2))
                    e.Graphics.DrawLine(pen, e.CellBounds.Right - 1, e.CellBounds.Top,
                        e.CellBounds.Right - 1, e.CellBounds.Bottom);
                using (var br = new SolidBrush(Theme.TextStrong))
                using (var sf = new StringFormat { LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap })
                {
                    var rect = new RectangleF(e.CellBounds.X + 8, e.CellBounds.Y, e.CellBounds.Width - 12, e.CellBounds.Height);
                    e.Graphics.DrawString(e.Value?.ToString() ?? "", Theme.BodyBold, br, rect, sf);
                }
                return;
            }

            e.Handled = true;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            bool selected = dgv.Rows[e.RowIndex].Selected;
            Color rowBase = e.RowIndex % 2 == 0 ? Color.White : Theme.Bg2;
            Color bg = selected ? Theme.PrimaryLight : rowBase;
            using (var br = new SolidBrush(bg))
                e.Graphics.FillRectangle(br, e.CellBounds);
            using (var pen = new Pen(Theme.Border1))
                e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                    e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);

            string val = e.Value?.ToString() ?? "";

            // Status chip
            if (e.ColumnIndex == colStatus.Index)
            {
                DesenharChipStatus(e.Graphics, e.CellBounds, val == "Ativo");
                return;
            }

            // Especialidade chip
            if (e.ColumnIndex == colEspecialidade.Index)
            {
                var prof = dgv.Rows[e.RowIndex].Tag as Profissional;
                if (prof?.Especialidade != null)
                    DesenharChip(e.Graphics, e.CellBounds, prof.Especialidade.Nome,
                        PastelDe(prof.Especialidade.CorHex), EscurecerHex(prof.Especialidade.CorHex));
                else
                    DesenharVazio(e.Graphics, e.CellBounds);
                return;
            }

            // Empty / dash
            if (string.IsNullOrEmpty(val) || val == "—")
            {
                DesenharVazio(e.Graphics, e.CellBounds);
                return;
            }

            // Normal text
            bool inativo = dgv.Rows[e.RowIndex].Cells["colStatus"].Value?.ToString() == "Inativo";
            Color fg = selected ? Theme.TextStrong : (inativo ? Theme.TextWeak : Theme.TextBody);
            using (var br = new SolidBrush(fg))
            using (var sf = new StringFormat { LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap })
            {
                var rect = new RectangleF(e.CellBounds.X + 8, e.CellBounds.Y, e.CellBounds.Width - 12, e.CellBounds.Height);
                e.Graphics.DrawString(val, e.CellStyle.Font ?? Font, br, rect, sf);
            }
        }

        private void btnPillTodos_Click(object sender, EventArgs e)
        {
            _filtroStatus = "Todos";
            AtivarPill(sender as Button);
            CarregarGrid(txtBusca.Text);
        }

        private void btnPillAtivos_Click(object sender, EventArgs e)
        {
            _filtroStatus = "Ativos";
            AtivarPill(sender as Button);
            CarregarGrid(txtBusca.Text);
        }

        private void btnPillInativos_Click(object sender, EventArgs e)
        {
            _filtroStatus = "Inativos";
            AtivarPill(sender as Button);
            CarregarGrid(txtBusca.Text);
        }

        private void AtivarPill(Button ativo)
        {
            foreach (var btn in new[] { btnPillTodos, btnPillAtivos, btnPillInativos })
            {
                if (btn == ativo)
                {
                    btn.BackColor = Theme.PrimaryDark;
                    btn.ForeColor = Color.White;
                    btn.Font      = new Font(btn.Font, FontStyle.Bold);
                }
                else
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Theme.TextMuted;
                    btn.Font      = new Font(btn.Font, FontStyle.Regular);
                }
            }
        }

        private void btnInicio_Click(object sender, EventArgs e) =>
            _principal.MostrarDashboard();

        private void btnNovo_Click(object sender, EventArgs e)
        {
            using (var form = new ProfissionalForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    CarregarGrid(txtBusca.Text);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            var prof = dgv.SelectedRows[0].Tag as Profissional;
            if (prof != null) AbrirEdicao(prof.ID);
        }

        private void AbrirEdicao(int id)
        {
            try
            {
                var p = _dao.Buscar(id);
                if (p == null) return;

                using (var form = new ProfissionalForm(p))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                        CarregarGrid(txtBusca.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir profissional: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInativar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            var row  = dgv.SelectedRows[0];
            var prof = row.Tag as Profissional;
            if (prof == null) return;

            string nome = row.Cells["colNome"].Value?.ToString();
            bool ativo  = row.Cells["colStatus"].Value?.ToString() == "Ativo";
            string acao = ativo ? "inativar" : "reativar";

            var resp = MessageBox.Show(
                "Deseja " + acao + " o profissional \"" + nome + "\"?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            try
            {
                if (ativo) _dao.Excluir(prof.ID);
                else       _dao.Reativar(prof.ID);
                CarregarGrid(txtBusca.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao " + acao + ": " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            var row  = dgv.SelectedRows[0];
            var prof = row.Tag as Profissional;
            if (prof == null) return;

            string nome = row.Cells["colNome"].Value?.ToString();
            var resp = MessageBox.Show(
                "Excluir permanentemente \"" + nome + "\"? Esta ação não pode ser desfeita.",
                "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resp != DialogResult.Yes) return;

            try
            {
                _dao.ExcluirFisico(prof.ID);
                CarregarGrid(txtBusca.Text);
            }
            catch (Exception ex)
            {
                string msg = ex.Message.Contains("REFERENCE") || ex.Message.Contains("FK") || ex.Message.Contains("foreign key")
                    ? "Não é possível excluir: profissional possui registros vinculados."
                    : "Erro ao excluir: " + ex.Message;
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void DesenharChipStatus(Graphics g, Rectangle bounds, bool ativo)
        {
            string texto  = ativo ? "Ativo" : "Inativo";
            Color bg      = ativo ? Color.FromArgb(231, 243, 238) : Color.FromArgb(252, 235, 235);
            Color cor     = ativo ? Color.FromArgb(15, 110, 86)   : Color.FromArgb(121, 31,  31);
            using (Font f  = new Font("Segoe UI", 8.5F))
            {
                SizeF sz  = g.MeasureString(texto, f);
                int chipW = (int)sz.Width + 22;
                int chipH = Math.Min((int)sz.Height + 6, bounds.Height - 6);
                int chipX = bounds.X + 8;
                int chipY = bounds.Y + (bounds.Height - chipH) / 2;
                var rc    = new Rectangle(chipX, chipY, chipW, chipH);
                using (var path = RoundedRect(rc, 10))
                using (var br   = new SolidBrush(bg))
                    g.FillPath(br, path);
                using (var br = new SolidBrush(cor))
                    g.FillEllipse(br, chipX + 6, chipY + (chipH - 7) / 2, 7, 7);
                using (var br = new SolidBrush(cor))
                    g.DrawString(texto, f, br, chipX + 17, chipY + (chipH - sz.Height) / 2f);
            }
        }

        private static void DesenharChip(Graphics g, Rectangle bounds, string texto, Color bg, Color fg)
        {
            if (string.IsNullOrEmpty(texto)) return;
            using (Font f = new Font("Segoe UI", 8.5F))
            {
                SizeF sz  = g.MeasureString(texto, f);
                int chipW = (int)sz.Width + 16;
                int chipH = Math.Min((int)sz.Height + 6, bounds.Height - 6);
                int chipX = bounds.X + 8;
                int chipY = bounds.Y + (bounds.Height - chipH) / 2;
                var rc    = new Rectangle(chipX, chipY, chipW, chipH);
                using (var path = RoundedRect(rc, 10))
                using (var br   = new SolidBrush(bg))
                    g.FillPath(br, path);
                using (var br = new SolidBrush(fg))
                    g.DrawString(texto, f, br, chipX + 7, chipY + (chipH - sz.Height) / 2f);
            }
        }

        private static void DesenharVazio(Graphics g, Rectangle bounds)
        {
            using (Font f  = new Font("Segoe UI", 8.5F, FontStyle.Italic))
            using (var br  = new SolidBrush(Theme.TextWeak))
            {
                float y = bounds.Y + (bounds.Height - f.Height) / 2f;
                g.DrawString("não informado", f, br, bounds.X + 8, y);
            }
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

        private static GraphicsPath RoundedRect(Rectangle b, int r)
        {
            int d = r * 2;
            var p = new GraphicsPath();
            p.AddArc(b.X, b.Y, d, d, 180, 90);
            p.AddArc(b.Right - d, b.Y, d, d, 270, 90);
            p.AddArc(b.Right - d, b.Bottom - d, d, d, 0, 90);
            p.AddArc(b.X, b.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        private void ConfigurarNav()
        {
            btnNavProfissionais.BackColor = System.Drawing.Color.FromArgb(44, 95, 127);
            btnNavProfissionais.ForeColor = System.Drawing.Color.White;
            btnNavProfissionais.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            btnNavPacientes.Click          += (s, e) => _principal.AbrirTela(new PacienteUserControl(_principal));
            btnNavAgenda.Click             += (s, e) => _principal.AbrirTela(new AgendaUserControl(_principal));
            btnNavEspecialidades.Click     += (s, e) => _principal.AbrirTela(new EspecialidadeUserControl(_principal));
            btnNavSalas.Click              += (s, e) => _principal.AbrirTela(new SalaUserControl(_principal));
            btnNavRelatorios.Click         += (s, e) => _principal.AbrirTela(new RelatorioUserControl(_principal));
        }
    }
}
