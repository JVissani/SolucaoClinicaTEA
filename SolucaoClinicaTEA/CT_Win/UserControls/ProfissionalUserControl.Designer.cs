namespace CT_Win.UserControls
{
    partial class ProfissionalUserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlNav              = new System.Windows.Forms.Panel();
            this.pnlNavBd            = new System.Windows.Forms.Panel();
            this.btnNavPacientes     = new System.Windows.Forms.Button();
            this.btnNavProfissionais = new System.Windows.Forms.Button();
            this.btnNavAgenda        = new System.Windows.Forms.Button();
            this.btnNavEspecialidades= new System.Windows.Forms.Button();
            this.btnNavSalas         = new System.Windows.Forms.Button();
            this.btnNavRelatorios    = new System.Windows.Forms.Button();
            this.pnlTopo             = new System.Windows.Forms.Panel();
            this.pnlBuscaContainer   = new System.Windows.Forms.Panel();
            this.lblLupa             = new System.Windows.Forms.Label();
            this.txtBusca            = new System.Windows.Forms.TextBox();
            this.btnPillTodos        = new System.Windows.Forms.Button();
            this.btnPillAtivos       = new System.Windows.Forms.Button();
            this.btnPillInativos     = new System.Windows.Forms.Button();
            this.pnlTopoBorder       = new System.Windows.Forms.Panel();
            this.dgv                 = new System.Windows.Forms.DataGridView();
            this.colNome             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspecialidade    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConselho         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBotoes           = new System.Windows.Forms.Panel();
            this.pnlBotoesBorder     = new System.Windows.Forms.Panel();
            this.btnInicio           = new System.Windows.Forms.Button();
            this.btnNovo             = new System.Windows.Forms.Button();
            this.btnEditar           = new System.Windows.Forms.Button();
            this.btnInativar         = new System.Windows.Forms.Button();
            this.btnExcluir          = new System.Windows.Forms.Button();

            this.pnlNav.SuspendLayout();
            this.pnlTopo.SuspendLayout();
            this.pnlBuscaContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();

            // ── pnlNav ───────────────────────────────────────────────────────
            this.pnlNav.BackColor = System.Drawing.Color.White;
            this.pnlNav.Controls.Add(this.btnNavPacientes);
            this.pnlNav.Controls.Add(this.btnNavProfissionais);
            this.pnlNav.Controls.Add(this.btnNavAgenda);
            this.pnlNav.Controls.Add(this.btnNavEspecialidades);
            this.pnlNav.Controls.Add(this.btnNavSalas);
            this.pnlNav.Controls.Add(this.btnNavRelatorios);
            this.pnlNav.Controls.Add(this.pnlNavBd);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(1200, 44);
            this.pnlNav.TabIndex = 10;

            this.pnlNavBd.BackColor = System.Drawing.Color.FromArgb(224, 229, 235);
            this.pnlNavBd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavBd.Name = "pnlNavBd";
            this.pnlNavBd.Size = new System.Drawing.Size(1200, 1);
            this.pnlNavBd.TabIndex = 0;

            this.btnNavPacientes.FlatAppearance.BorderSize = 0;
            this.btnNavPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavPacientes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavPacientes.BackColor = System.Drawing.Color.White;
            this.btnNavPacientes.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnNavPacientes.Location = new System.Drawing.Point(16, 7);
            this.btnNavPacientes.Name = "btnNavPacientes";
            this.btnNavPacientes.Size = new System.Drawing.Size(90, 30);
            this.btnNavPacientes.Text = "Pacientes";
            this.btnNavPacientes.UseVisualStyleBackColor = false;
            this.btnNavPacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavPacientes.TabIndex = 1;

            this.btnNavProfissionais.FlatAppearance.BorderSize = 0;
            this.btnNavProfissionais.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavProfissionais.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavProfissionais.BackColor = System.Drawing.Color.White;
            this.btnNavProfissionais.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnNavProfissionais.Location = new System.Drawing.Point(116, 7);
            this.btnNavProfissionais.Name = "btnNavProfissionais";
            this.btnNavProfissionais.Size = new System.Drawing.Size(115, 30);
            this.btnNavProfissionais.Text = "Profissionais";
            this.btnNavProfissionais.UseVisualStyleBackColor = false;
            this.btnNavProfissionais.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavProfissionais.TabIndex = 2;

            this.btnNavAgenda.FlatAppearance.BorderSize = 0;
            this.btnNavAgenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAgenda.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavAgenda.BackColor = System.Drawing.Color.White;
            this.btnNavAgenda.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnNavAgenda.Location = new System.Drawing.Point(241, 7);
            this.btnNavAgenda.Name = "btnNavAgenda";
            this.btnNavAgenda.Size = new System.Drawing.Size(75, 30);
            this.btnNavAgenda.Text = "Agenda";
            this.btnNavAgenda.UseVisualStyleBackColor = false;
            this.btnNavAgenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavAgenda.TabIndex = 3;

            this.btnNavEspecialidades.FlatAppearance.BorderSize = 0;
            this.btnNavEspecialidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavEspecialidades.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavEspecialidades.BackColor = System.Drawing.Color.White;
            this.btnNavEspecialidades.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnNavEspecialidades.Location = new System.Drawing.Point(326, 7);
            this.btnNavEspecialidades.Name = "btnNavEspecialidades";
            this.btnNavEspecialidades.Size = new System.Drawing.Size(120, 30);
            this.btnNavEspecialidades.Text = "Especialidades";
            this.btnNavEspecialidades.UseVisualStyleBackColor = false;
            this.btnNavEspecialidades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavEspecialidades.TabIndex = 4;

            this.btnNavSalas.FlatAppearance.BorderSize = 0;
            this.btnNavSalas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSalas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavSalas.BackColor = System.Drawing.Color.White;
            this.btnNavSalas.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnNavSalas.Location = new System.Drawing.Point(456, 7);
            this.btnNavSalas.Name = "btnNavSalas";
            this.btnNavSalas.Size = new System.Drawing.Size(65, 30);
            this.btnNavSalas.Text = "Salas";
            this.btnNavSalas.UseVisualStyleBackColor = false;
            this.btnNavSalas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavSalas.TabIndex = 5;

            this.btnNavRelatorios.FlatAppearance.BorderSize = 0;
            this.btnNavRelatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavRelatorios.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavRelatorios.BackColor = System.Drawing.Color.White;
            this.btnNavRelatorios.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnNavRelatorios.Location = new System.Drawing.Point(531, 7);
            this.btnNavRelatorios.Name = "btnNavRelatorios";
            this.btnNavRelatorios.Size = new System.Drawing.Size(100, 30);
            this.btnNavRelatorios.Text = "Relatórios";
            this.btnNavRelatorios.UseVisualStyleBackColor = false;
            this.btnNavRelatorios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavRelatorios.TabIndex = 6;

            // ── pnlTopo ───────────────────────────────────────────────────────
            this.pnlTopo.BackColor = System.Drawing.Color.FromArgb(247, 248, 250);
            this.pnlTopo.Controls.Add(this.pnlBuscaContainer);
            this.pnlTopo.Controls.Add(this.btnPillTodos);
            this.pnlTopo.Controls.Add(this.btnPillAtivos);
            this.pnlTopo.Controls.Add(this.btnPillInativos);
            this.pnlTopo.Controls.Add(this.pnlTopoBorder);
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Size = new System.Drawing.Size(1200, 52);
            this.pnlTopo.TabIndex = 0;

            // pnlBuscaContainer (search box with border)
            this.pnlBuscaContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBuscaContainer.Controls.Add(this.lblLupa);
            this.pnlBuscaContainer.Controls.Add(this.txtBusca);
            this.pnlBuscaContainer.Location = new System.Drawing.Point(16, 12);
            this.pnlBuscaContainer.Name = "pnlBuscaContainer";
            this.pnlBuscaContainer.Size = new System.Drawing.Size(340, 28);
            this.pnlBuscaContainer.TabIndex = 0;
            this.pnlBuscaContainer.BackColor = System.Drawing.Color.White;

            this.lblLupa.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.lblLupa.Location = new System.Drawing.Point(4, 0);
            this.lblLupa.Name = "lblLupa";
            this.lblLupa.Size = new System.Drawing.Size(22, 26);
            this.lblLupa.Text = "\U0001F50D";
            this.lblLupa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.txtBusca.BackColor = System.Drawing.Color.White;
            this.txtBusca.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBusca.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBusca.Location = new System.Drawing.Point(28, 5);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(306, 20);
            this.txtBusca.TabIndex = 1;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);

            // Pill buttons
            this.btnPillTodos.FlatAppearance.BorderSize = 0;
            this.btnPillTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPillTodos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPillTodos.BackColor = System.Drawing.Color.FromArgb(31, 72, 96);
            this.btnPillTodos.ForeColor = System.Drawing.Color.White;
            this.btnPillTodos.Location = new System.Drawing.Point(368, 13);
            this.btnPillTodos.Name = "btnPillTodos";
            this.btnPillTodos.Size = new System.Drawing.Size(66, 26);
            this.btnPillTodos.Text = "Todos";
            this.btnPillTodos.UseVisualStyleBackColor = false;
            this.btnPillTodos.TabIndex = 2;
            this.btnPillTodos.Click += new System.EventHandler(this.btnPillTodos_Click);

            this.btnPillAtivos.FlatAppearance.BorderSize = 0;
            this.btnPillAtivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPillAtivos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPillAtivos.BackColor = System.Drawing.Color.White;
            this.btnPillAtivos.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnPillAtivos.Location = new System.Drawing.Point(442, 13);
            this.btnPillAtivos.Name = "btnPillAtivos";
            this.btnPillAtivos.Size = new System.Drawing.Size(58, 26);
            this.btnPillAtivos.Text = "Ativos";
            this.btnPillAtivos.UseVisualStyleBackColor = false;
            this.btnPillAtivos.TabIndex = 3;
            this.btnPillAtivos.Click += new System.EventHandler(this.btnPillAtivos_Click);

            this.btnPillInativos.FlatAppearance.BorderSize = 0;
            this.btnPillInativos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPillInativos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPillInativos.BackColor = System.Drawing.Color.White;
            this.btnPillInativos.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnPillInativos.Location = new System.Drawing.Point(508, 13);
            this.btnPillInativos.Name = "btnPillInativos";
            this.btnPillInativos.Size = new System.Drawing.Size(70, 26);
            this.btnPillInativos.Text = "Inativos";
            this.btnPillInativos.UseVisualStyleBackColor = false;
            this.btnPillInativos.TabIndex = 4;
            this.btnPillInativos.Click += new System.EventHandler(this.btnPillInativos_Click);

            this.pnlTopoBorder.BackColor = System.Drawing.Color.FromArgb(224, 229, 235);
            this.pnlTopoBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTopoBorder.Name = "pnlTopoBorder";
            this.pnlTopoBorder.Size = new System.Drawing.Size(1200, 1);

            // ── dgv (Fill) ────────────────────────────────────────────────────
            this.dgv.AllowUserToAddRows    = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor       = System.Drawing.Color.FromArgb(247, 248, 250);
            this.dgv.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle       = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv.ColumnHeadersHeight   = 36;
            this.dgv.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Dock              = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Font              = new System.Drawing.Font("Segoe UI", 9F);
            this.dgv.GridColor         = System.Drawing.Color.FromArgb(224, 229, 235);
            this.dgv.MultiSelect       = false;
            this.dgv.Name              = "dgv";
            this.dgv.ReadOnly          = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 32;
            this.dgv.SelectionMode     = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.TabIndex          = 1;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNome, this.colEspecialidade, this.colConselho, this.colStatus });
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            this.dgv.CellDoubleClick  += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.CellPainting     += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);

            this.colNome.FillWeight = 40F;          this.colNome.MinimumWidth = 140;
            this.colNome.HeaderText = "NOME";        this.colNome.Name = "colNome"; this.colNome.ReadOnly = true;
            this.colEspecialidade.FillWeight = 28F;  this.colEspecialidade.MinimumWidth = 120;
            this.colEspecialidade.HeaderText = "ESPECIALIDADE"; this.colEspecialidade.Name = "colEspecialidade"; this.colEspecialidade.ReadOnly = true;
            this.colConselho.FillWeight = 20F;       this.colConselho.MinimumWidth = 90;
            this.colConselho.HeaderText = "CONSELHO"; this.colConselho.Name = "colConselho"; this.colConselho.ReadOnly = true;
            this.colStatus.FillWeight = 12F;         this.colStatus.MinimumWidth = 70;
            this.colStatus.HeaderText = "STATUS";    this.colStatus.Name = "colStatus"; this.colStatus.ReadOnly = true;

            // ── pnlBotoes (Bottom) ────────────────────────────────────────────
            this.pnlBotoes.BackColor = System.Drawing.Color.FromArgb(247, 248, 250);
            this.pnlBotoes.Controls.Add(this.btnExcluir);
            this.pnlBotoes.Controls.Add(this.btnInativar);
            this.pnlBotoes.Controls.Add(this.btnEditar);
            this.pnlBotoes.Controls.Add(this.btnNovo);
            this.pnlBotoes.Controls.Add(this.btnInicio);
            this.pnlBotoes.Controls.Add(this.pnlBotoesBorder);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(1200, 56);
            this.pnlBotoes.TabIndex = 2;

            this.pnlBotoesBorder.BackColor = System.Drawing.Color.FromArgb(224, 229, 235);
            this.pnlBotoesBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotoesBorder.Name = "pnlBotoesBorder";
            this.pnlBotoesBorder.Size = new System.Drawing.Size(1200, 1);

            this.btnInicio.BackColor = System.Drawing.Color.White;
            this.btnInicio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(197, 205, 214);
            this.btnInicio.FlatAppearance.BorderSize = 1;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnInicio.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnInicio.Location = new System.Drawing.Point(16, 11);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(105, 34);
            this.btnInicio.Text = "Voltar";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);

            this.btnNovo.BackColor = System.Drawing.Color.FromArgb(44, 95, 127);
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNovo.ForeColor = System.Drawing.Color.White;
            this.btnNovo.Location = new System.Drawing.Point(133, 11);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(165, 34);
            this.btnNovo.Text = "+ Novo profissional";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);

            this.btnEditar.BackColor = System.Drawing.Color.White;
            this.btnEditar.Enabled = false;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(197, 205, 214);
            this.btnEditar.FlatAppearance.BorderSize = 1;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnEditar.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnEditar.Location = new System.Drawing.Point(310, 11);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(105, 34);
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnInativar.BackColor = System.Drawing.Color.White;
            this.btnInativar.Enabled = false;
            this.btnInativar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(197, 205, 214);
            this.btnInativar.FlatAppearance.BorderSize = 1;
            this.btnInativar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInativar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnInativar.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnInativar.Location = new System.Drawing.Point(427, 11);
            this.btnInativar.Name = "btnInativar";
            this.btnInativar.Size = new System.Drawing.Size(105, 34);
            this.btnInativar.Text = "Inativar";
            this.btnInativar.UseVisualStyleBackColor = false;
            this.btnInativar.Click += new System.EventHandler(this.btnInativar_Click);

            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.Enabled = false;
            this.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(197, 205, 214);
            this.btnExcluir.FlatAppearance.BorderSize = 1;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnExcluir.ForeColor = System.Drawing.Color.FromArgb(184, 58, 48);
            this.btnExcluir.Location = new System.Drawing.Point(544, 11);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(105, 34);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            // ── ProfissionalUserControl ───────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(247, 248, 250);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.pnlTopo);
            this.Controls.Add(this.pnlNav);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProfissionalUserControl";
            this.Size = new System.Drawing.Size(1200, 700);

            this.pnlNav.ResumeLayout(false);
            this.pnlBuscaContainer.ResumeLayout(false);
            this.pnlBuscaContainer.PerformLayout();
            this.pnlTopo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel   pnlNav;
        private System.Windows.Forms.Panel   pnlNavBd;
        private System.Windows.Forms.Button  btnNavPacientes;
        private System.Windows.Forms.Button  btnNavProfissionais;
        private System.Windows.Forms.Button  btnNavAgenda;
        private System.Windows.Forms.Button  btnNavEspecialidades;
        private System.Windows.Forms.Button  btnNavSalas;
        private System.Windows.Forms.Button  btnNavRelatorios;
        private System.Windows.Forms.Panel   pnlTopo;
        private System.Windows.Forms.Panel   pnlBuscaContainer;
        private System.Windows.Forms.Label   lblLupa;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Button  btnPillTodos;
        private System.Windows.Forms.Button  btnPillAtivos;
        private System.Windows.Forms.Button  btnPillInativos;
        private System.Windows.Forms.Panel   pnlTopoBorder;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEspecialidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConselho;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Panel   pnlBotoes;
        private System.Windows.Forms.Panel   pnlBotoesBorder;
        private System.Windows.Forms.Button  btnInicio;
        private System.Windows.Forms.Button  btnNovo;
        private System.Windows.Forms.Button  btnEditar;
        private System.Windows.Forms.Button  btnInativar;
        private System.Windows.Forms.Button  btnExcluir;
    }
}
