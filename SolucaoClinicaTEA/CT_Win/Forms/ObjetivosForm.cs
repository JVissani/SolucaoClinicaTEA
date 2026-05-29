using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CT_Negocio.DAO;
using CT_Negocio.Mapeamento;
using CT_Win.Recursos;

namespace CT_Win.Forms
{
    public class ObjetivosForm : Form
    {
        private readonly ObjetivoTerapeuticoDAO _dao = new ObjetivoTerapeuticoDAO();
        private readonly Paciente               _paciente;

        private DataGridView _dgv;
        private Button       _btnNovo;
        private Button       _btnEditar;
        private Button       _btnExcluir;

        private List<ObjetivoTerapeutico> _lista = new List<ObjetivoTerapeutico>();

        public ObjetivosForm(Paciente paciente)
        {
            _paciente = paciente ?? throw new ArgumentNullException(nameof(paciente));

            Text          = "Objetivos Terapêuticos — " + paciente.NomeExibicao;
            ClientSize    = new Size(820, 560);
            StartPosition = FormStartPosition.CenterParent;
            Font          = new Font("Segoe UI", 9F);
            BackColor     = Color.White;
            MinimumSize   = new Size(640, 420);

            ConstruirInterface();
            CarregarLista();
        }

        private void ConstruirInterface()
        {
            var pnlHeader = new Panel { Dock = DockStyle.Top, Height = 44, BackColor = Color.White };
            var lblTitulo = new Label
            {
                Text      = "Objetivos Terapêuticos",
                Font      = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Theme.TextStrong,
                Location  = new Point(20, 10),
                AutoSize  = true
            };
            var lblPaciente = new Label
            {
                Text      = _paciente.NomeExibicao,
                Font      = new Font("Segoe UI", 9F),
                ForeColor = Theme.TextMuted,
                Location  = new Point(240, 14),
                AutoSize  = true
            };
            var pnlHBd = new Panel { Dock = DockStyle.Bottom, Height = 1, BackColor = Theme.Border1 };
            pnlHeader.Controls.AddRange(new Control[] { lblTitulo, lblPaciente, pnlHBd });

            _dgv = new DataGridView
            {
                Dock                        = DockStyle.Fill,
                ReadOnly                    = true,
                AllowUserToAddRows          = false,
                AllowUserToDeleteRows       = false,
                SelectionMode               = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect                 = false,
                BorderStyle                 = BorderStyle.None,
                RowHeadersVisible           = false,
                BackgroundColor             = Color.White,
                GridColor                   = Theme.Border1,
                CellBorderStyle             = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                AutoSizeColumnsMode         = DataGridViewAutoSizeColumnsMode.AllCells
            };
            _dgv.ColumnHeadersDefaultCellStyle.BackColor = Theme.Bg3;
            _dgv.ColumnHeadersDefaultCellStyle.ForeColor = Theme.TextStrong;
            _dgv.ColumnHeadersDefaultCellStyle.Font      = Theme.BodyBold;
            _dgv.DefaultCellStyle.SelectionBackColor      = Theme.PrimaryLight;
            _dgv.DefaultCellStyle.SelectionForeColor      = Theme.TextStrong;
            _dgv.DefaultCellStyle.Padding                 = new Padding(6, 0, 6, 0);
            _dgv.DefaultCellStyle.Font                    = new Font("Segoe UI", 9F);
            _dgv.SelectionChanged += (s, e) => AtualizarBotoes();
            _dgv.CellDoubleClick  += (s, e) => EditarSelecionado();

            var pnlBotoes = new Panel { Dock = DockStyle.Bottom, Height = 56, BackColor = Color.White };
            var pnlBBd    = new Panel { Dock = DockStyle.Top, Height = 1, BackColor = Theme.Border1 };

            _btnNovo = CriarBotaoPrimario("+ Novo objetivo", 16);
            _btnNovo.Click += (s, e) => NovoObjetivo();

            _btnEditar = CriarBotaoSecundario("Editar", 196);
            _btnEditar.Enabled = false;
            _btnEditar.Click += (s, e) => EditarSelecionado();

            _btnExcluir = CriarBotaoSecundario("Excluir", 313);
            _btnExcluir.Enabled = false;
            _btnExcluir.Click += (s, e) => ExcluirSelecionado();

            var btnFechar = CriarBotaoSecundario("Fechar", 704);
            btnFechar.Click += (s, e) => Close();
            CancelButton = btnFechar;

            pnlBotoes.Controls.AddRange(new Control[] { pnlBBd, _btnNovo, _btnEditar, _btnExcluir, btnFechar });

            Controls.Add(_dgv);
            Controls.Add(pnlBotoes);
            Controls.Add(pnlHeader);
        }

        private Button CriarBotaoPrimario(string texto, int x)
        {
            var btn = new Button
            {
                Text      = texto,
                Location  = new Point(x, 11),
                Size      = new Size(164, 34),
                Font      = new Font("Segoe UI", 9.5F),
                BackColor = Theme.Primary,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => btn.BackColor = Theme.PrimaryHover;
            btn.MouseLeave += (s, e) => btn.BackColor = Theme.Primary;
            return btn;
        }

        private Button CriarBotaoSecundario(string texto, int x)
        {
            var btn = new Button
            {
                Text      = texto,
                Location  = new Point(x, 11),
                Size      = new Size(105, 34),
                Font      = new Font("Segoe UI", 9.5F),
                BackColor = Color.White,
                ForeColor = Theme.TextMuted,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand
            };
            btn.FlatAppearance.BorderColor = Theme.Border2;
            btn.FlatAppearance.BorderSize  = 1;
            return btn;
        }

        private void CarregarLista()
        {
            try
            {
                _lista = _dao.ListarPorPaciente(_paciente.ID);
                PopularGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar objetivos:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopularGrid()
        {
            _dgv.Rows.Clear();
            _dgv.Columns.Clear();

            _dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID",            HeaderText = "ID",           Visible = false });
            _dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Especialidade", HeaderText = "Especialidade" });
            _dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Descricao",     HeaderText = "Descrição" });
            _dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataInicio",    HeaderText = "Início" });
            _dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Previsao",      HeaderText = "Previsão" });
            _dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status",        HeaderText = "Status" });
            _dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Percentual",    HeaderText = "%" });

            _dgv.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (var o in _lista)
            {
                _dgv.Rows.Add(
                    o.ID,
                    o.Especialidade != null ? o.Especialidade.Nome : "—",
                    o.Descricao,
                    o.DataInicio.ToString("dd/MM/yyyy"),
                    o.DataPrevisaoFim.HasValue ? o.DataPrevisaoFim.Value.ToString("dd/MM/yyyy") : "—",
                    StatusParaDisplay(o.Status),
                    o.PercentualAtingimento + "%");
            }

            AtualizarBotoes();
        }

        private static string StatusParaDisplay(string status)
        {
            switch (status)
            {
                case "EmProgresso": return "Em Progresso";
                case "Concluido":   return "Concluído";
                case "Suspenso":    return "Suspenso";
                default:            return status;
            }
        }

        private void AtualizarBotoes()
        {
            bool tem = _dgv.SelectedRows.Count > 0;
            _btnEditar.Enabled  = tem;
            _btnExcluir.Enabled = tem;
        }

        private ObjetivoTerapeutico ObjetivoSelecionado()
        {
            if (_dgv.SelectedRows.Count == 0) return null;
            int id = (int)_dgv.SelectedRows[0].Cells["ID"].Value;
            return _lista.Find(o => o.ID == id);
        }

        private void NovoObjetivo()
        {
            using (var form = new ObjetivoItemForm(_paciente.ID))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    CarregarLista();
            }
        }

        private void EditarSelecionado()
        {
            var obj = ObjetivoSelecionado();
            if (obj == null) return;

            using (var form = new ObjetivoItemForm(_paciente.ID, obj))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    CarregarLista();
            }
        }

        private void ExcluirSelecionado()
        {
            var obj = ObjetivoSelecionado();
            if (obj == null) return;

            string resumo = obj.Descricao.Length > 60
                ? obj.Descricao.Substring(0, 57) + "..."
                : obj.Descricao;

            var resp = MessageBox.Show(
                "Excluir o objetivo:\n\"" + resumo + "\"?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resp != DialogResult.Yes) return;

            try
            {
                _dao.Excluir(obj.ID);
                CarregarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
