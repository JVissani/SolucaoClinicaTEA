namespace CT_Win.Forms
{
    partial class EvolucaoSessaoForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTitulo             = new System.Windows.Forms.Panel();
            this.lblTitulo             = new System.Windows.Forms.Label();
            this.pnlTituloBd           = new System.Windows.Forms.Panel();
            this.pnlSessao             = new System.Windows.Forms.Panel();
            this.lblPacienteSessao     = new System.Windows.Forms.Label();
            this.lblDetalhesSessao     = new System.Windows.Forms.Label();
            this.pnlSessaoBd           = new System.Windows.Forms.Panel();
            this.pnlCorpo              = new System.Windows.Forms.Panel();
            this.lblHumor              = new System.Windows.Forms.Label();
            this.nudHumor              = new System.Windows.Forms.NumericUpDown();
            this.lblHumorDica          = new System.Windows.Forms.Label();
            this.lblEngajamento        = new System.Windows.Forms.Label();
            this.nudEngajamento        = new System.Windows.Forms.NumericUpDown();
            this.lblEngajamentoDica    = new System.Windows.Forms.Label();
            this.lblConteudo           = new System.Windows.Forms.Label();
            this.txtConteudo           = new System.Windows.Forms.TextBox();
            this.lblComportamentos     = new System.Windows.Forms.Label();
            this.txtComportamentos     = new System.Windows.Forms.TextBox();
            this.lblProximos           = new System.Windows.Forms.Label();
            this.txtProximosObjetivos  = new System.Windows.Forms.TextBox();
            this.pnlBotoes             = new System.Windows.Forms.Panel();
            this.btnSalvar             = new System.Windows.Forms.Button();
            this.btnCancelar           = new System.Windows.Forms.Button();

            this.pnlTitulo.SuspendLayout();
            this.pnlSessao.SuspendLayout();
            this.pnlCorpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHumor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEngajamento)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();

            // ── pnlTitulo ────────────────────────────────────────────────────
            this.pnlTitulo.BackColor = System.Drawing.Color.White;
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Controls.Add(this.pnlTituloBd);
            this.pnlTitulo.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Name     = "pnlTitulo";
            this.pnlTitulo.Size     = new System.Drawing.Size(640, 44);

            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblTitulo.Location  = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Text      = "Evolução da Sessão";

            this.pnlTituloBd.BackColor = System.Drawing.Color.FromArgb(224, 229, 235);
            this.pnlTituloBd.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTituloBd.Name      = "pnlTituloBd";
            this.pnlTituloBd.Size      = new System.Drawing.Size(640, 1);

            // ── pnlSessao (info da sessão, somente leitura) ───────────────────
            this.pnlSessao.BackColor = System.Drawing.Color.FromArgb(213, 225, 235);
            this.pnlSessao.Controls.Add(this.lblPacienteSessao);
            this.pnlSessao.Controls.Add(this.lblDetalhesSessao);
            this.pnlSessao.Controls.Add(this.pnlSessaoBd);
            this.pnlSessao.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlSessao.Name     = "pnlSessao";
            this.pnlSessao.Padding  = new System.Windows.Forms.Padding(20, 8, 20, 8);
            this.pnlSessao.Size     = new System.Drawing.Size(640, 64);

            this.lblPacienteSessao.AutoSize  = true;
            this.lblPacienteSessao.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPacienteSessao.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblPacienteSessao.Location  = new System.Drawing.Point(20, 10);
            this.lblPacienteSessao.Name      = "lblPacienteSessao";
            this.lblPacienteSessao.Text      = "—";

            this.lblDetalhesSessao.AutoSize  = true;
            this.lblDetalhesSessao.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDetalhesSessao.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblDetalhesSessao.Location  = new System.Drawing.Point(20, 32);
            this.lblDetalhesSessao.Name      = "lblDetalhesSessao";
            this.lblDetalhesSessao.Text      = "—";

            this.pnlSessaoBd.BackColor = System.Drawing.Color.FromArgb(197, 213, 226);
            this.pnlSessaoBd.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSessaoBd.Name      = "pnlSessaoBd";
            this.pnlSessaoBd.Size      = new System.Drawing.Size(640, 1);

            // ── pnlCorpo ─────────────────────────────────────────────────────
            // Coordenadas: lx=24 fw=592 lh=18 fh=28 nudW=68
            // Row escalas (two cols): y=14  lblHumor/nudHumor/dica | lblEng/nudEng/dica
            //   col1 x=24 w=270 | col2 x=334 w=282
            // Conteudo: y=96 txt(y=116 h=80)
            // Comportamentos: y=208 txt(y=228 h=60)
            // Proximos: y=300 txt(y=320 h=60)
            this.pnlCorpo.AutoScroll = true;
            this.pnlCorpo.BackColor  = System.Drawing.Color.White;
            this.pnlCorpo.Dock       = System.Windows.Forms.DockStyle.Fill;
            this.pnlCorpo.Name       = "pnlCorpo";
            this.pnlCorpo.Padding    = new System.Windows.Forms.Padding(0, 0, 0, 8);

            // ── Humor do Paciente (col1) ──
            this.lblHumor.AutoSize  = true;
            this.lblHumor.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHumor.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblHumor.Location  = new System.Drawing.Point(24, 14);
            this.lblHumor.Name      = "lblHumor";
            this.lblHumor.Text      = "Humor do paciente";

            this.nudHumor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudHumor.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudHumor.Location    = new System.Drawing.Point(24, 34);
            this.nudHumor.Maximum     = new decimal(new int[] { 5, 0, 0, 0 });
            this.nudHumor.Minimum     = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudHumor.Name        = "nudHumor";
            this.nudHumor.Size        = new System.Drawing.Size(60, 28);
            this.nudHumor.Value       = new decimal(new int[] { 3, 0, 0, 0 });

            this.lblHumorDica.AutoSize  = true;
            this.lblHumorDica.Font      = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblHumorDica.ForeColor = System.Drawing.Color.FromArgb(139, 150, 163);
            this.lblHumorDica.Location  = new System.Drawing.Point(92, 40);
            this.lblHumorDica.Name      = "lblHumorDica";
            this.lblHumorDica.Text      = "1 = Muito desregulado  |  5 = Muito regulado";

            // ── Nível de Engajamento (col2) ──
            this.lblEngajamento.AutoSize  = true;
            this.lblEngajamento.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEngajamento.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblEngajamento.Location  = new System.Drawing.Point(334, 14);
            this.lblEngajamento.Name      = "lblEngajamento";
            this.lblEngajamento.Text      = "Nível de engajamento";

            this.nudEngajamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudEngajamento.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudEngajamento.Location    = new System.Drawing.Point(334, 34);
            this.nudEngajamento.Maximum     = new decimal(new int[] { 5, 0, 0, 0 });
            this.nudEngajamento.Minimum     = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudEngajamento.Name        = "nudEngajamento";
            this.nudEngajamento.Size        = new System.Drawing.Size(60, 28);
            this.nudEngajamento.Value       = new decimal(new int[] { 3, 0, 0, 0 });

            this.lblEngajamentoDica.AutoSize  = true;
            this.lblEngajamentoDica.Font      = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblEngajamentoDica.ForeColor = System.Drawing.Color.FromArgb(139, 150, 163);
            this.lblEngajamentoDica.Location  = new System.Drawing.Point(402, 40);
            this.lblEngajamentoDica.Name      = "lblEngajamentoDica";
            this.lblEngajamentoDica.Text      = "1 = Sem engajamento  |  5 = Totalmente engajado";

            // ── Conteúdo ──
            this.lblConteudo.AutoSize  = true;
            this.lblConteudo.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblConteudo.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblConteudo.Location  = new System.Drawing.Point(24, 82);
            this.lblConteudo.Name      = "lblConteudo";
            this.lblConteudo.Text      = "Evolução / Conteúdo da sessão *";

            this.txtConteudo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConteudo.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtConteudo.Location    = new System.Drawing.Point(24, 102);
            this.txtConteudo.MaxLength   = 4000;
            this.txtConteudo.Multiline   = true;
            this.txtConteudo.Name        = "txtConteudo";
            this.txtConteudo.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConteudo.Size        = new System.Drawing.Size(592, 84);

            // ── Comportamentos ──
            this.lblComportamentos.AutoSize  = true;
            this.lblComportamentos.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblComportamentos.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblComportamentos.Location  = new System.Drawing.Point(24, 200);
            this.lblComportamentos.Name      = "lblComportamentos";
            this.lblComportamentos.Text      = "Comportamentos observados";

            this.txtComportamentos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComportamentos.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtComportamentos.Location    = new System.Drawing.Point(24, 220);
            this.txtComportamentos.MaxLength   = 2000;
            this.txtComportamentos.Multiline   = true;
            this.txtComportamentos.Name        = "txtComportamentos";
            this.txtComportamentos.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComportamentos.Size        = new System.Drawing.Size(592, 64);

            // ── Próximos objetivos ──
            this.lblProximos.AutoSize  = true;
            this.lblProximos.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblProximos.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblProximos.Location  = new System.Drawing.Point(24, 298);
            this.lblProximos.Name      = "lblProximos";
            this.lblProximos.Text      = "Próximos objetivos / Encaminhamentos";

            this.txtProximosObjetivos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProximosObjetivos.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtProximosObjetivos.Location    = new System.Drawing.Point(24, 318);
            this.txtProximosObjetivos.MaxLength   = 2000;
            this.txtProximosObjetivos.Multiline   = true;
            this.txtProximosObjetivos.Name        = "txtProximosObjetivos";
            this.txtProximosObjetivos.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProximosObjetivos.Size        = new System.Drawing.Size(592, 64);

            this.pnlCorpo.Controls.Add(this.lblHumor);
            this.pnlCorpo.Controls.Add(this.nudHumor);
            this.pnlCorpo.Controls.Add(this.lblHumorDica);
            this.pnlCorpo.Controls.Add(this.lblEngajamento);
            this.pnlCorpo.Controls.Add(this.nudEngajamento);
            this.pnlCorpo.Controls.Add(this.lblEngajamentoDica);
            this.pnlCorpo.Controls.Add(this.lblConteudo);
            this.pnlCorpo.Controls.Add(this.txtConteudo);
            this.pnlCorpo.Controls.Add(this.lblComportamentos);
            this.pnlCorpo.Controls.Add(this.txtComportamentos);
            this.pnlCorpo.Controls.Add(this.lblProximos);
            this.pnlCorpo.Controls.Add(this.txtProximosObjetivos);

            // ── pnlBotoes ─────────────────────────────────────────────────────
            this.pnlBotoes.BackColor = System.Drawing.Color.White;
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Dock     = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Name     = "pnlBotoes";
            this.pnlBotoes.Size     = new System.Drawing.Size(640, 56);

            this.btnSalvar.BackColor               = System.Drawing.Color.FromArgb(44, 95, 127);
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle               = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font                    = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSalvar.ForeColor               = System.Drawing.Color.White;
            this.btnSalvar.Location                = new System.Drawing.Point(418, 11);
            this.btnSalvar.Name                    = "btnSalvar";
            this.btnSalvar.Size                    = new System.Drawing.Size(105, 34);
            this.btnSalvar.Text                    = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            this.btnCancelar.BackColor                  = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(197, 205, 214);
            this.btnCancelar.FlatAppearance.BorderSize  = 1;
            this.btnCancelar.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font                       = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelar.ForeColor                  = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnCancelar.Location                   = new System.Drawing.Point(535, 11);
            this.btnCancelar.Name                       = "btnCancelar";
            this.btnCancelar.Size                       = new System.Drawing.Size(90, 34);
            this.btnCancelar.Text                       = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor    = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ── EvolucaoSessaoForm ────────────────────────────────────────────
            this.AcceptButton        = this.btnSalvar;
            this.CancelButton        = this.btnCancelar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(640, 560);
            this.Controls.Add(this.pnlCorpo);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.pnlSessao);
            this.Controls.Add(this.pnlTitulo);
            this.Font            = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.Name            = "EvolucaoSessaoForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Evolução da Sessão";

            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlSessao.ResumeLayout(false);
            this.pnlSessao.PerformLayout();
            this.pnlCorpo.ResumeLayout(false);
            this.pnlCorpo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHumor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEngajamento)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel         pnlTitulo;
        private System.Windows.Forms.Label         lblTitulo;
        private System.Windows.Forms.Panel         pnlTituloBd;
        private System.Windows.Forms.Panel         pnlSessao;
        private System.Windows.Forms.Label         lblPacienteSessao;
        private System.Windows.Forms.Label         lblDetalhesSessao;
        private System.Windows.Forms.Panel         pnlSessaoBd;
        private System.Windows.Forms.Panel         pnlCorpo;
        private System.Windows.Forms.Label         lblHumor;
        private System.Windows.Forms.NumericUpDown nudHumor;
        private System.Windows.Forms.Label         lblHumorDica;
        private System.Windows.Forms.Label         lblEngajamento;
        private System.Windows.Forms.NumericUpDown nudEngajamento;
        private System.Windows.Forms.Label         lblEngajamentoDica;
        private System.Windows.Forms.Label         lblConteudo;
        private System.Windows.Forms.TextBox       txtConteudo;
        private System.Windows.Forms.Label         lblComportamentos;
        private System.Windows.Forms.TextBox       txtComportamentos;
        private System.Windows.Forms.Label         lblProximos;
        private System.Windows.Forms.TextBox       txtProximosObjetivos;
        private System.Windows.Forms.Panel         pnlBotoes;
        private System.Windows.Forms.Button        btnSalvar;
        private System.Windows.Forms.Button        btnCancelar;
    }
}
