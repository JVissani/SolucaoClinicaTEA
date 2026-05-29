using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using CT_Win.Recursos;

namespace CT_Win.Forms
{
    public class RelatorioViewerForm : Form
    {
        private readonly string                         _titulo;
        private readonly Func<DateTime, DateTime, DataTable> _carregarDados;

        private readonly DateTimePicker _dtpDe;
        private readonly DateTimePicker _dtpAte;
        private readonly DataGridView   _dgv;

        public RelatorioViewerForm(string titulo, Func<DateTime, DateTime, DataTable> carregarDados)
        {
            _titulo        = titulo;
            _carregarDados = carregarDados;

            Text          = titulo;
            ClientSize    = new Size(960, 580);
            StartPosition = FormStartPosition.CenterParent;
            Font          = new Font("Segoe UI", 9F);
            BackColor     = Color.White;
            MinimumSize   = new Size(700, 400);

            var pnlHeader = new Panel { Dock = DockStyle.Top, Height = 44, BackColor = Color.White };
            var lblTitulo = new Label
            {
                Text      = titulo,
                Font      = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Theme.TextStrong,
                Location  = new Point(20, 10),
                AutoSize  = true
            };
            var pnlHBd = new Panel { Dock = DockStyle.Bottom, Height = 1, BackColor = Theme.Border1 };
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(pnlHBd);

            var pnlFiltros = new Panel { Dock = DockStyle.Top, Height = 52, BackColor = Theme.Bg2 };

            var lblDe = new Label
            {
                Text = "De:", AutoSize = true,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Theme.TextBody, Location = new Point(16, 17)
            };
            _dtpDe = new DateTimePicker
            {
                Format   = DateTimePickerFormat.Short,
                Value    = DateTime.Today.AddMonths(-1),
                Location = new Point(42, 14),
                Width    = 120,
                Font     = new Font("Segoe UI", 9F)
            };

            var lblAte = new Label
            {
                Text = "Até:", AutoSize = true,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Theme.TextBody, Location = new Point(178, 17)
            };
            _dtpAte = new DateTimePicker
            {
                Format   = DateTimePickerFormat.Short,
                Value    = DateTime.Today,
                Location = new Point(208, 14),
                Width    = 120,
                Font     = new Font("Segoe UI", 9F)
            };

            var btnAtualizar = new Button
            {
                Text      = "Atualizar",
                Location  = new Point(344, 13),
                Size      = new Size(88, 28),
                Font      = new Font("Segoe UI", 8.5F),
                BackColor = Theme.Primary,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand
            };
            btnAtualizar.FlatAppearance.BorderSize = 0;
            btnAtualizar.Click += (s, e) => CarregarDados();
            btnAtualizar.MouseEnter += (s, e) => btnAtualizar.BackColor = Theme.PrimaryHover;
            btnAtualizar.MouseLeave += (s, e) => btnAtualizar.BackColor = Theme.Primary;

            var pnlFBd = new Panel { Dock = DockStyle.Bottom, Height = 1, BackColor = Theme.Border1 };
            pnlFiltros.Controls.AddRange(new Control[] { lblDe, _dtpDe, lblAte, _dtpAte, btnAtualizar, pnlFBd });

            _dgv = new DataGridView
            {
                Dock                              = DockStyle.Fill,
                ReadOnly                          = true,
                AllowUserToAddRows                = false,
                AllowUserToDeleteRows             = false,
                SelectionMode                     = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode               = DataGridViewAutoSizeColumnsMode.AllCells,
                BorderStyle                       = BorderStyle.None,
                RowHeadersVisible                 = false,
                BackgroundColor                   = Color.White,
                GridColor                         = Theme.Border1,
                CellBorderStyle                   = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersHeightSizeMode       = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            };
            _dgv.ColumnHeadersDefaultCellStyle.BackColor = Theme.Bg3;
            _dgv.ColumnHeadersDefaultCellStyle.ForeColor = Theme.TextStrong;
            _dgv.ColumnHeadersDefaultCellStyle.Font      = Theme.BodyBold;
            _dgv.DefaultCellStyle.SelectionBackColor      = Theme.PrimaryLight;
            _dgv.DefaultCellStyle.SelectionForeColor      = Theme.TextStrong;
            _dgv.DefaultCellStyle.Padding                 = new Padding(8, 0, 8, 0);
            _dgv.DefaultCellStyle.Font                    = new Font("Segoe UI", 9F);

            var pnlBotoes = new Panel { Dock = DockStyle.Bottom, Height = 56, BackColor = Color.White };
            var pnlBBd    = new Panel { Dock = DockStyle.Top, Height = 1, BackColor = Theme.Border1 };

            var btnImprimir = new Button
            {
                Text      = "Imprimir",
                Size      = new Size(105, 34),
                Location  = new Point(740, 11),
                Font      = new Font("Segoe UI", 9.5F),
                BackColor = Theme.Primary,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand
            };
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.Click       += btnImprimir_Click;
            btnImprimir.MouseEnter  += (s, e) => btnImprimir.BackColor = Theme.PrimaryHover;
            btnImprimir.MouseLeave  += (s, e) => btnImprimir.BackColor = Theme.Primary;

            var btnFechar = new Button
            {
                Text      = "Fechar",
                Size      = new Size(105, 34),
                Location  = new Point(851, 11),
                Font      = new Font("Segoe UI", 9.5F),
                BackColor = Color.White,
                ForeColor = Theme.TextMuted,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand
            };
            btnFechar.FlatAppearance.BorderColor = Theme.Border2;
            btnFechar.FlatAppearance.BorderSize  = 1;
            btnFechar.Click += (s, e) => Close();

            pnlBotoes.Controls.AddRange(new Control[] { pnlBBd, btnImprimir, btnFechar });
            CancelButton = btnFechar;

            Controls.Add(_dgv);
            Controls.Add(pnlBotoes);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlHeader);

            _dgv.DataBindingComplete += (s, e) =>
            {
                if (_dgv.Columns.Count > 0)
                {
                    _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    _dgv.Columns[_dgv.Columns.Count - 1].AutoSizeMode =
                        System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                }
            };

            CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {
                DateTime de  = _dtpDe.Value.Date;
                DateTime ate = _dtpAte.Value.Date.AddDays(1);   // inclusivo no final

                if (de > _dtpAte.Value.Date)
                {
                    MessageBox.Show("A data 'De' não pode ser posterior à data 'Até'.",
                        "Período inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = _carregarDados(de, ate);
                _dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (_dgv.RowCount == 0)
            {
                MessageBox.Show("Não há dados para imprimir no período selecionado.",
                    "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int nextRow = 0;   // controla paginação entre eventos PrintPage

            var pd = new PrintDocument { DocumentName = _titulo };
            pd.PrintPage += (s, ev) =>
            {
                Graphics      g     = ev.Graphics;
                RectangleF    mb    = ev.MarginBounds;
                float         x     = mb.Left;
                float         y     = mb.Top;
                float         pageW = mb.Width;
                int           cols  = _dgv.ColumnCount;
                const float   rowH  = 18f;

                if (nextRow == 0)
                {
                    using (Font fT = new Font("Segoe UI", 14F, FontStyle.Bold))
                        g.DrawString(_titulo, fT, Brushes.Black, x, y);
                    y += 28;

                    string periodo = "Período: " + _dtpDe.Value.ToShortDateString()
                                   + " a " + _dtpAte.Value.ToShortDateString()
                                   + "   |   Gerado em: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    using (Font fP = new Font("Segoe UI", 8.5F))
                        g.DrawString(periodo, fP, Brushes.Gray, x, y);
                    y += 22;
                    g.DrawLine(Pens.LightGray, x, y, x + pageW, y);
                    y += 10;
                }

                float[] colW  = new float[cols];
                float   total = 0f;
                for (int c = 0; c < cols; c++) { colW[c] = Math.Max(_dgv.Columns[c].Width, 50); total += colW[c]; }
                float sc = pageW / total;
                for (int c = 0; c < cols; c++) colW[c] *= sc;

                using (Font fH = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                {
                    float cx = x;
                    for (int c = 0; c < cols; c++)
                    {
                        var rc = new RectangleF(cx, y, colW[c] - 4, rowH);
                        g.DrawString(_dgv.Columns[c].HeaderText, fH, Brushes.Black, rc);
                        cx += colW[c];
                    }
                }
                y += rowH;
                g.DrawLine(Pens.Gray, x, y - 2, x + pageW, y - 2);

                using (Font fD = new Font("Segoe UI", 8F))
                {
                    while (nextRow < _dgv.RowCount)
                    {
                        if (y + rowH > mb.Bottom) { ev.HasMorePages = true; return; }

                        float cx = x;
                        for (int c = 0; c < cols; c++)
                        {
                            string val = _dgv.Rows[nextRow].Cells[c].FormattedValue?.ToString() ?? "";
                            var rc = new RectangleF(cx + 2, y, colW[c] - 6, rowH);
                            g.DrawString(val, fD, Brushes.Black, rc,
                                new StringFormat { Trimming = StringTrimming.EllipsisCharacter,
                                                   FormatFlags = StringFormatFlags.NoWrap });
                            cx += colW[c];
                        }

                        if (nextRow % 2 == 0)
                            using (var br = new SolidBrush(Color.FromArgb(8, 0, 0, 0)))
                                g.FillRectangle(br, x, y, pageW, rowH);

                        y += rowH;
                        nextRow++;
                    }
                }

                ev.HasMorePages = false;
            };

            using (var ppd = new PrintPreviewDialog())
            {
                ppd.Document    = pd;
                ppd.WindowState = FormWindowState.Maximized;
                ppd.ShowDialog(this);
            }
        }
    }
}
