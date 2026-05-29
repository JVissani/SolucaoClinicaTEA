namespace CT_Win.UserControls
{
    partial class AgendaUserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlNav               = new System.Windows.Forms.Panel();
            this.pnlNavBd             = new System.Windows.Forms.Panel();
            this.btnNavPacientes      = new System.Windows.Forms.Button();
            this.btnNavProfissionais  = new System.Windows.Forms.Button();
            this.btnNavAgenda         = new System.Windows.Forms.Button();
            this.btnNavEspecialidades = new System.Windows.Forms.Button();
            this.btnNavSalas          = new System.Windows.Forms.Button();
            this.btnNavRelatorios     = new System.Windows.Forms.Button();
            this.pnlFiltros           = new System.Windows.Forms.Panel();
            this.pnlBuscaContainer    = new System.Windows.Forms.Panel();
            this.lblLupa              = new System.Windows.Forms.Label();
            this.txtBusca             = new System.Windows.Forms.TextBox();
            this.btnPillProximos      = new System.Windows.Forms.Button();
            this.btnPillRealizados    = new System.Windows.Forms.Button();
            this.btnPillFaltas        = new System.Windows.Forms.Button();
            this.pnlFiltrosBd         = new System.Windows.Forms.Panel();
            this.pnlListaContainer    = new System.Windows.Forms.Panel();
            this.pnlBotoes            = new System.Windows.Forms.Panel();
            this.pnlBotoesBorder      = new System.Windows.Forms.Panel();
            this.btnInicio            = new System.Windows.Forms.Button();
            this.btnNovo              = new System.Windows.Forms.Button();
            this.btnEditar            = new System.Windows.Forms.Button();
            this.btnMudarStatus       = new System.Windows.Forms.Button();
            this.btnExcluir           = new System.Windows.Forms.Button();
            this.btnEvolucao          = new System.Windows.Forms.Button();

            this.pnlNav.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlBuscaContainer.SuspendLayout();
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
            this.pnlNav.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.Name     = "pnlNav";
            this.pnlNav.Size     = new System.Drawing.Size(1200, 44);
            this.pnlNav.TabIndex = 10;

            this.pnlNavBd.BackColor = System.Drawing.Color.FromArgb(224, 229, 235);
            this.pnlNavBd.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavBd.Name      = "pnlNavBd";
            this.pnlNavBd.Size      = new System.Drawing.Size(1200, 1);
            this.pnlNavBd.TabIndex  = 0;

            this.btnNavPacientes.FlatAppearance.BorderSize = 0;
            this.btnNavPacientes.FlatStyle    = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavPacientes.Font         = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavPacientes.BackColor    = System.Drawing.Color.White;
            this.btnNavPacientes.ForeColor    = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnNavPacientes.Location     = new System.Drawing.Point(16, 7);
            this.btnNavPacientes.Name         = "btnNavPacientes";
            this.btnNavPacientes.Size         = new System.Drawing.Size(90, 30);
            this.btnNavPacientes.Text         = "Pacientes";
            this.btnNavPacientes.UseVisualStyleBackColor = false;
            this.btnNavPacientes.Cursor       = System.Windows.Forms.Cursors.Hand;
            this.btnNavPacientes.TabIndex     = 1;

            this.btnNavProfissionais.FlatAppearance.BorderSize = 0;
            this.btnNavProfissionais.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavProfissionais.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavProfissionais.BackColor = System.Drawing.Color.White;
            this.btnNavProfissionais.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnNavProfissionais.Location  = new System.Drawing.Point(116, 7);
            this.btnNavProfissionais.Name      = "btnNavProfissionais";
            this.btnNavProfissionais.Size      = new System.Drawing.Size(115, 30);
            this.btnNavProfissionais.Text      = "Profissionais";
            this.btnNavProfissionais.UseVisualStyleBackColor = false;
            this.btnNavProfissionais.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnNavProfissionais.TabIndex  = 2;

            this.btnNavAgenda.FlatAppearance.BorderSize = 0;
            this.btnNavAgenda.FlatStyle    = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAgenda.Font         = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavAgenda.BackColor    = System.Drawing.Color.White;
            this.btnNavAgenda.ForeColor    = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnNavAgenda.Location     = new System.Drawing.Point(241, 7);
            this.btnNavAgenda.Name         = "btnNavAgenda";
            this.btnNavAgenda.Size         = new System.Drawing.Size(75, 30);
            this.btnNavAgenda.Text         = "Agenda";
            this.btnNavAgenda.UseVisualStyleBackColor = false;
            this.btnNavAgenda.Cursor       = System.Windows.Forms.Cursors.Hand;
            this.btnNavAgenda.TabIndex     = 3;

            this.btnNavEspecialidades.FlatAppearance.BorderSize = 0;
            this.btnNavEspecialidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavEspecialidades.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavEspecialidades.BackColor = System.Drawing.Color.White;
            this.btnNavEspecialidades.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnNavEspecialidades.Location  = new System.Drawing.Point(326, 7);
            this.btnNavEspecialidades.Name      = "btnNavEspecialidades";
            this.btnNavEspecialidades.Size      = new System.Drawing.Size(120, 30);
            this.btnNavEspecialidades.Text      = "Especialidades";
            this.btnNavEspecialidades.UseVisualStyleBackColor = false;
            this.btnNavEspecialidades.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnNavEspecialidades.TabIndex  = 4;

            this.btnNavSalas.FlatAppearance.BorderSize = 0;
            this.btnNavSalas.FlatStyle    = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSalas.Font         = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavSalas.BackColor    = System.Drawing.Color.White;
            this.btnNavSalas.ForeColor    = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnNavSalas.Location     = new System.Drawing.Point(456, 7);
            this.btnNavSalas.Name         = "btnNavSalas";
            this.btnNavSalas.Size         = new System.Drawing.Size(65, 30);
            this.btnNavSalas.Text         = "Salas";
            this.btnNavSalas.UseVisualStyleBackColor = false;
            this.btnNavSalas.Cursor       = System.Windows.Forms.Cursors.Hand;
            this.btnNavSalas.TabIndex     = 5;

            this.btnNavRelatorios.FlatAppearance.BorderSize = 0;
            this.btnNavRelatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavRelatorios.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavRelatorios.BackColor = System.Drawing.Color.White;
            this.btnNavRelatorios.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnNavRelatorios.Location  = new System.Drawing.Point(531, 7);
            this.btnNavRelatorios.Name      = "btnNavRelatorios";
            this.btnNavRelatorios.Size      = new System.Drawing.Size(100, 30);
            this.btnNavRelatorios.Text      = "Relatórios";
            this.btnNavRelatorios.UseVisualStyleBackColor = false;
            this.btnNavRelatorios.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnNavRelatorios.TabIndex  = 6;

            // ── pnlFiltros ────────────────────────────────────────────────────
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(247, 248, 250);
            this.pnlFiltros.Controls.Add(this.pnlBuscaContainer);
            this.pnlFiltros.Controls.Add(this.btnPillProximos);
            this.pnlFiltros.Controls.Add(this.btnPillRealizados);
            this.pnlFiltros.Controls.Add(this.btnPillFaltas);
            this.pnlFiltros.Controls.Add(this.pnlFiltrosBd);
            this.pnlFiltros.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Name     = "pnlFiltros";
            this.pnlFiltros.Size     = new System.Drawing.Size(1200, 52);
            this.pnlFiltros.TabIndex = 9;

            // pnlBuscaContainer
            this.pnlBuscaContainer.BackColor    = System.Drawing.Color.White;
            this.pnlBuscaContainer.BorderStyle  = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBuscaContainer.Controls.Add(this.lblLupa);
            this.pnlBuscaContainer.Controls.Add(this.txtBusca);
            this.pnlBuscaContainer.Location     = new System.Drawing.Point(16, 12);
            this.pnlBuscaContainer.Name         = "pnlBuscaContainer";
            this.pnlBuscaContainer.Size         = new System.Drawing.Size(290, 28);
            this.pnlBuscaContainer.TabIndex     = 0;

            this.lblLupa.AutoSize  = false;
            this.lblLupa.Font      = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.lblLupa.ForeColor = System.Drawing.Color.FromArgb(139, 150, 163);
            this.lblLupa.Location  = new System.Drawing.Point(2, 1);
            this.lblLupa.Name      = "lblLupa";
            this.lblLupa.Size      = new System.Drawing.Size(22, 24);
            this.lblLupa.Text      = "🔍";
            this.lblLupa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.txtBusca.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBusca.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBusca.Location    = new System.Drawing.Point(26, 5);
            this.txtBusca.Name        = "txtBusca";
            this.txtBusca.Size        = new System.Drawing.Size(256, 20);
            this.txtBusca.BackColor   = System.Drawing.Color.White;
            this.txtBusca.TabIndex    = 0;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);

            // Pills
            this.btnPillProximos.FlatStyle                    = System.Windows.Forms.FlatStyle.Flat;
            this.btnPillProximos.FlatAppearance.BorderSize    = 0;
            this.btnPillProximos.Font                         = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnPillProximos.BackColor                    = System.Drawing.Color.FromArgb(44, 95, 127);
            this.btnPillProximos.ForeColor                    = System.Drawing.Color.White;
            this.btnPillProximos.Location                     = new System.Drawing.Point(318, 14);
            this.btnPillProximos.Name                         = "btnPillProximos";
            this.btnPillProximos.Size                         = new System.Drawing.Size(86, 24);
            this.btnPillProximos.Text                         = "Próximos";
            this.btnPillProximos.UseVisualStyleBackColor      = false;
            this.btnPillProximos.Cursor                       = System.Windows.Forms.Cursors.Hand;
            this.btnPillProximos.TabIndex                     = 2;
            this.btnPillProximos.Click += new System.EventHandler(this.btnPillProximos_Click);

            this.btnPillRealizados.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnPillRealizados.FlatAppearance.BorderSize = 0;
            this.btnPillRealizados.Font                      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnPillRealizados.BackColor                 = System.Drawing.Color.Transparent;
            this.btnPillRealizados.ForeColor                 = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnPillRealizados.Location                  = new System.Drawing.Point(412, 14);
            this.btnPillRealizados.Name                      = "btnPillRealizados";
            this.btnPillRealizados.Size                      = new System.Drawing.Size(88, 24);
            this.btnPillRealizados.Text                      = "Realizados";
            this.btnPillRealizados.UseVisualStyleBackColor   = false;
            this.btnPillRealizados.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnPillRealizados.TabIndex                  = 3;
            this.btnPillRealizados.Click += new System.EventHandler(this.btnPillRealizados_Click);

            this.btnPillFaltas.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnPillFaltas.FlatAppearance.BorderSize = 0;
            this.btnPillFaltas.Font                      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnPillFaltas.BackColor                 = System.Drawing.Color.Transparent;
            this.btnPillFaltas.ForeColor                 = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnPillFaltas.Location                  = new System.Drawing.Point(508, 14);
            this.btnPillFaltas.Name                      = "btnPillFaltas";
            this.btnPillFaltas.Size                      = new System.Drawing.Size(65, 24);
            this.btnPillFaltas.Text                      = "Faltas";
            this.btnPillFaltas.UseVisualStyleBackColor   = false;
            this.btnPillFaltas.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnPillFaltas.TabIndex                  = 4;
            this.btnPillFaltas.Click += new System.EventHandler(this.btnPillFaltas_Click);

            this.pnlFiltrosBd.BackColor = System.Drawing.Color.FromArgb(224, 229, 235);
            this.pnlFiltrosBd.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFiltrosBd.Name      = "pnlFiltrosBd";
            this.pnlFiltrosBd.Size      = new System.Drawing.Size(1200, 1);

            // ── pnlListaContainer (Fill) ──────────────────────────────────────
            this.pnlListaContainer.AutoScroll = true;
            this.pnlListaContainer.BackColor  = System.Drawing.Color.FromArgb(247, 248, 250);
            this.pnlListaContainer.Dock       = System.Windows.Forms.DockStyle.Fill;
            this.pnlListaContainer.Name       = "pnlListaContainer";
            this.pnlListaContainer.TabIndex   = 1;

            // ── pnlBotoes (Bottom) ────────────────────────────────────────────
            this.pnlBotoes.BackColor = System.Drawing.Color.FromArgb(247, 248, 250);
            this.pnlBotoes.Controls.Add(this.btnEvolucao);
            this.pnlBotoes.Controls.Add(this.btnExcluir);
            this.pnlBotoes.Controls.Add(this.btnMudarStatus);
            this.pnlBotoes.Controls.Add(this.btnEditar);
            this.pnlBotoes.Controls.Add(this.btnNovo);
            this.pnlBotoes.Controls.Add(this.btnInicio);
            this.pnlBotoes.Controls.Add(this.pnlBotoesBorder);
            this.pnlBotoes.Dock     = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Name     = "pnlBotoes";
            this.pnlBotoes.Size     = new System.Drawing.Size(1200, 56);
            this.pnlBotoes.TabIndex = 2;

            this.pnlBotoesBorder.BackColor = System.Drawing.Color.FromArgb(224, 229, 235);
            this.pnlBotoesBorder.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlBotoesBorder.Name      = "pnlBotoesBorder";
            this.pnlBotoesBorder.Size      = new System.Drawing.Size(1200, 1);

            this.btnInicio.BackColor                  = System.Drawing.Color.White;
            this.btnInicio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(197, 205, 214);
            this.btnInicio.FlatAppearance.BorderSize  = 1;
            this.btnInicio.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font                       = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnInicio.ForeColor                  = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnInicio.Location                   = new System.Drawing.Point(16, 11);
            this.btnInicio.Name                       = "btnInicio";
            this.btnInicio.Size                       = new System.Drawing.Size(105, 34);
            this.btnInicio.Text                       = "Voltar";
            this.btnInicio.UseVisualStyleBackColor    = false;
            this.btnInicio.Cursor                     = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.TabIndex                   = 1;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);

            this.btnNovo.BackColor               = System.Drawing.Color.FromArgb(44, 95, 127);
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatStyle               = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Font                    = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNovo.ForeColor               = System.Drawing.Color.White;
            this.btnNovo.Location                = new System.Drawing.Point(133, 11);
            this.btnNovo.Name                    = "btnNovo";
            this.btnNovo.Size                    = new System.Drawing.Size(175, 34);
            this.btnNovo.Text                    = "+ Novo agendamento";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Cursor                  = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.TabIndex                = 2;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);

            this.btnEditar.BackColor                  = System.Drawing.Color.White;
            this.btnEditar.Enabled                    = false;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(197, 205, 214);
            this.btnEditar.FlatAppearance.BorderSize  = 1;
            this.btnEditar.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font                       = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnEditar.ForeColor                  = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnEditar.Location                   = new System.Drawing.Point(320, 11);
            this.btnEditar.Name                       = "btnEditar";
            this.btnEditar.Size                       = new System.Drawing.Size(105, 34);
            this.btnEditar.Text                       = "Editar";
            this.btnEditar.UseVisualStyleBackColor    = false;
            this.btnEditar.Cursor                     = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.TabIndex                   = 3;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnMudarStatus.BackColor                  = System.Drawing.Color.White;
            this.btnMudarStatus.Enabled                    = false;
            this.btnMudarStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(197, 205, 214);
            this.btnMudarStatus.FlatAppearance.BorderSize  = 1;
            this.btnMudarStatus.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            this.btnMudarStatus.Font                       = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnMudarStatus.ForeColor                  = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnMudarStatus.Location                   = new System.Drawing.Point(437, 11);
            this.btnMudarStatus.Name                       = "btnMudarStatus";
            this.btnMudarStatus.Size                       = new System.Drawing.Size(120, 34);
            this.btnMudarStatus.Text                       = "Mudar status";
            this.btnMudarStatus.UseVisualStyleBackColor    = false;
            this.btnMudarStatus.Cursor                     = System.Windows.Forms.Cursors.Hand;
            this.btnMudarStatus.TabIndex                   = 4;
            this.btnMudarStatus.Click += new System.EventHandler(this.btnMudarStatus_Click);

            this.btnExcluir.BackColor                  = System.Drawing.Color.White;
            this.btnExcluir.Enabled                    = false;
            this.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(197, 205, 214);
            this.btnExcluir.FlatAppearance.BorderSize  = 1;
            this.btnExcluir.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font                       = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnExcluir.ForeColor                  = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnExcluir.Location                   = new System.Drawing.Point(569, 11);
            this.btnExcluir.Name                       = "btnExcluir";
            this.btnExcluir.Size                       = new System.Drawing.Size(105, 34);
            this.btnExcluir.Text                       = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor    = false;
            this.btnExcluir.Cursor                     = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.TabIndex                   = 5;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            this.btnEvolucao.BackColor               = System.Drawing.Color.FromArgb(82, 168, 140);
            this.btnEvolucao.Enabled                 = false;
            this.btnEvolucao.FlatAppearance.BorderSize = 0;
            this.btnEvolucao.FlatStyle               = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvolucao.Font                    = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnEvolucao.ForeColor               = System.Drawing.Color.White;
            this.btnEvolucao.Location                = new System.Drawing.Point(690, 11);
            this.btnEvolucao.Name                    = "btnEvolucao";
            this.btnEvolucao.Size                    = new System.Drawing.Size(130, 34);
            this.btnEvolucao.Text                    = "Evolução";
            this.btnEvolucao.UseVisualStyleBackColor = false;
            this.btnEvolucao.Cursor                  = System.Windows.Forms.Cursors.Hand;
            this.btnEvolucao.TabIndex                = 6;
            this.btnEvolucao.Click += new System.EventHandler(this.btnEvolucao_Click);

            // ── AgendaUserControl ─────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(247, 248, 250);
            this.Controls.Add(this.pnlListaContainer);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlNav);
            this.Font    = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name    = "AgendaUserControl";
            this.Size    = new System.Drawing.Size(1200, 700);

            this.pnlNav.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlBuscaContainer.ResumeLayout(false);
            this.pnlBuscaContainer.PerformLayout();
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
        private System.Windows.Forms.Panel   pnlFiltros;
        private System.Windows.Forms.Panel   pnlBuscaContainer;
        private System.Windows.Forms.Label   lblLupa;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Button  btnPillProximos;
        private System.Windows.Forms.Button  btnPillRealizados;
        private System.Windows.Forms.Button  btnPillFaltas;
        private System.Windows.Forms.Panel   pnlFiltrosBd;
        private System.Windows.Forms.Panel   pnlListaContainer;
        private System.Windows.Forms.Panel   pnlBotoes;
        private System.Windows.Forms.Panel   pnlBotoesBorder;
        private System.Windows.Forms.Button  btnInicio;
        private System.Windows.Forms.Button  btnNovo;
        private System.Windows.Forms.Button  btnEditar;
        private System.Windows.Forms.Button  btnMudarStatus;
        private System.Windows.Forms.Button  btnExcluir;
        private System.Windows.Forms.Button  btnEvolucao;
    }
}
