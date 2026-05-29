namespace CT_Win.Forms
{
    partial class ObjetivoItemForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTitulo          = new System.Windows.Forms.Panel();
            this.lblTitulo          = new System.Windows.Forms.Label();
            this.pnlTituloBd        = new System.Windows.Forms.Panel();
            this.pnlCorpo           = new System.Windows.Forms.Panel();
            this.lblEspecialidade   = new System.Windows.Forms.Label();
            this.cmbEspecialidade   = new System.Windows.Forms.ComboBox();
            this.lblDescricao       = new System.Windows.Forms.Label();
            this.txtDescricao       = new System.Windows.Forms.TextBox();
            this.lblDataInicio      = new System.Windows.Forms.Label();
            this.dtpDataInicio      = new System.Windows.Forms.DateTimePicker();
            this.lblDataPrevisao    = new System.Windows.Forms.Label();
            this.dtpDataPrevisao    = new System.Windows.Forms.DateTimePicker();
            this.lblStatus          = new System.Windows.Forms.Label();
            this.cmbStatus          = new System.Windows.Forms.ComboBox();
            this.lblPercentual      = new System.Windows.Forms.Label();
            this.nudPercentual      = new System.Windows.Forms.NumericUpDown();
            this.lblPercentualSufixo = new System.Windows.Forms.Label();
            this.pnlBotoes          = new System.Windows.Forms.Panel();
            this.btnSalvar          = new System.Windows.Forms.Button();
            this.btnCancelar        = new System.Windows.Forms.Button();

            this.pnlTitulo.SuspendLayout();
            this.pnlCorpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentual)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();

            // ── pnlTitulo ────────────────────────────────────────────────────
            this.pnlTitulo.BackColor = System.Drawing.Color.White;
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Controls.Add(this.pnlTituloBd);
            this.pnlTitulo.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Name     = "pnlTitulo";
            this.pnlTitulo.Size     = new System.Drawing.Size(520, 44);

            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblTitulo.Location  = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Text      = "Objetivo Terapêutico";

            this.pnlTituloBd.BackColor = System.Drawing.Color.FromArgb(224, 229, 235);
            this.pnlTituloBd.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTituloBd.Name      = "pnlTituloBd";
            this.pnlTituloBd.Size      = new System.Drawing.Size(520, 1);

            // ── pnlCorpo ─────────────────────────────────────────────────────
            this.pnlCorpo.AutoScroll = true;
            this.pnlCorpo.BackColor  = System.Drawing.Color.White;
            this.pnlCorpo.Dock       = System.Windows.Forms.DockStyle.Fill;
            this.pnlCorpo.Name       = "pnlCorpo";

            // Especialidade — y=16
            this.lblEspecialidade.AutoSize  = true;
            this.lblEspecialidade.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEspecialidade.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblEspecialidade.Location  = new System.Drawing.Point(24, 16);
            this.lblEspecialidade.Name      = "lblEspecialidade";
            this.lblEspecialidade.Text      = "Especialidade *";

            this.cmbEspecialidade.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidade.Font              = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbEspecialidade.FlatStyle         = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEspecialidade.Location          = new System.Drawing.Point(24, 36);
            this.cmbEspecialidade.Name              = "cmbEspecialidade";
            this.cmbEspecialidade.Size              = new System.Drawing.Size(472, 28);

            // Descrição — y=80
            this.lblDescricao.AutoSize  = true;
            this.lblDescricao.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDescricao.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblDescricao.Location  = new System.Drawing.Point(24, 80);
            this.lblDescricao.Name      = "lblDescricao";
            this.lblDescricao.Text      = "Descrição do objetivo *";

            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescricao.Location    = new System.Drawing.Point(24, 100);
            this.txtDescricao.MaxLength   = 2000;
            this.txtDescricao.Multiline   = true;
            this.txtDescricao.Name        = "txtDescricao";
            this.txtDescricao.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricao.Size        = new System.Drawing.Size(472, 80);

            // Data Início — y=196
            this.lblDataInicio.AutoSize  = true;
            this.lblDataInicio.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDataInicio.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblDataInicio.Location  = new System.Drawing.Point(24, 196);
            this.lblDataInicio.Name      = "lblDataInicio";
            this.lblDataInicio.Text      = "Data de início";

            this.dtpDataInicio.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInicio.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDataInicio.Location = new System.Drawing.Point(24, 216);
            this.dtpDataInicio.Name     = "dtpDataInicio";
            this.dtpDataInicio.Size     = new System.Drawing.Size(140, 28);

            // Data Previsão Fim — y=196 (col2 x=220)
            this.lblDataPrevisao.AutoSize  = true;
            this.lblDataPrevisao.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDataPrevisao.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblDataPrevisao.Location  = new System.Drawing.Point(220, 196);
            this.lblDataPrevisao.Name      = "lblDataPrevisao";
            this.lblDataPrevisao.Text      = "Previsão de conclusão";

            this.dtpDataPrevisao.Checked    = false;
            this.dtpDataPrevisao.Format     = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataPrevisao.Font       = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDataPrevisao.Location   = new System.Drawing.Point(220, 216);
            this.dtpDataPrevisao.Name       = "dtpDataPrevisao";
            this.dtpDataPrevisao.ShowCheckBox = true;
            this.dtpDataPrevisao.Size       = new System.Drawing.Size(160, 28);

            // Status — y=260
            this.lblStatus.AutoSize  = true;
            this.lblStatus.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblStatus.Location  = new System.Drawing.Point(24, 260);
            this.lblStatus.Name      = "lblStatus";
            this.lblStatus.Text      = "Status";

            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font          = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbStatus.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatus.Items.AddRange(new object[] { "Em Progresso", "Concluído", "Suspenso" });
            this.cmbStatus.Location      = new System.Drawing.Point(24, 280);
            this.cmbStatus.Name          = "cmbStatus";
            this.cmbStatus.Size          = new System.Drawing.Size(180, 28);

            // Percentual — y=260 (col2 x=220)
            this.lblPercentual.AutoSize  = true;
            this.lblPercentual.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPercentual.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblPercentual.Location  = new System.Drawing.Point(220, 260);
            this.lblPercentual.Name      = "lblPercentual";
            this.lblPercentual.Text      = "% Atingimento";

            this.nudPercentual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudPercentual.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudPercentual.Location    = new System.Drawing.Point(220, 280);
            this.nudPercentual.Maximum     = new decimal(new int[] { 100, 0, 0, 0 });
            this.nudPercentual.Minimum     = new decimal(new int[] { 0, 0, 0, 0 });
            this.nudPercentual.Name        = "nudPercentual";
            this.nudPercentual.Size        = new System.Drawing.Size(70, 28);
            this.nudPercentual.Value       = new decimal(new int[] { 0, 0, 0, 0 });

            this.lblPercentualSufixo.AutoSize  = true;
            this.lblPercentualSufixo.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPercentualSufixo.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.lblPercentualSufixo.Location  = new System.Drawing.Point(298, 284);
            this.lblPercentualSufixo.Name      = "lblPercentualSufixo";
            this.lblPercentualSufixo.Text      = "%";

            this.pnlCorpo.Controls.Add(this.lblEspecialidade);
            this.pnlCorpo.Controls.Add(this.cmbEspecialidade);
            this.pnlCorpo.Controls.Add(this.lblDescricao);
            this.pnlCorpo.Controls.Add(this.txtDescricao);
            this.pnlCorpo.Controls.Add(this.lblDataInicio);
            this.pnlCorpo.Controls.Add(this.dtpDataInicio);
            this.pnlCorpo.Controls.Add(this.lblDataPrevisao);
            this.pnlCorpo.Controls.Add(this.dtpDataPrevisao);
            this.pnlCorpo.Controls.Add(this.lblStatus);
            this.pnlCorpo.Controls.Add(this.cmbStatus);
            this.pnlCorpo.Controls.Add(this.lblPercentual);
            this.pnlCorpo.Controls.Add(this.nudPercentual);
            this.pnlCorpo.Controls.Add(this.lblPercentualSufixo);

            // ── pnlBotoes ─────────────────────────────────────────────────────
            this.pnlBotoes.BackColor = System.Drawing.Color.White;
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Dock     = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Name     = "pnlBotoes";
            this.pnlBotoes.Size     = new System.Drawing.Size(520, 56);

            this.btnSalvar.BackColor               = System.Drawing.Color.FromArgb(44, 95, 127);
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle               = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font                    = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSalvar.ForeColor               = System.Drawing.Color.White;
            this.btnSalvar.Location                = new System.Drawing.Point(304, 11);
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
            this.btnCancelar.Location                   = new System.Drawing.Point(421, 11);
            this.btnCancelar.Name                       = "btnCancelar";
            this.btnCancelar.Size                       = new System.Drawing.Size(90, 34);
            this.btnCancelar.Text                       = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor    = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ── ObjetivoItemForm ──────────────────────────────────────────────
            this.AcceptButton        = this.btnSalvar;
            this.CancelButton        = this.btnCancelar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(520, 420);
            this.Controls.Add(this.pnlCorpo);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.pnlTitulo);
            this.Font            = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.Name            = "ObjetivoItemForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Objetivo Terapêutico";

            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlCorpo.ResumeLayout(false);
            this.pnlCorpo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentual)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel        pnlTitulo;
        private System.Windows.Forms.Label        lblTitulo;
        private System.Windows.Forms.Panel        pnlTituloBd;
        private System.Windows.Forms.Panel        pnlCorpo;
        private System.Windows.Forms.Label        lblEspecialidade;
        private System.Windows.Forms.ComboBox     cmbEspecialidade;
        private System.Windows.Forms.Label        lblDescricao;
        private System.Windows.Forms.TextBox      txtDescricao;
        private System.Windows.Forms.Label        lblDataInicio;
        private System.Windows.Forms.DateTimePicker dtpDataInicio;
        private System.Windows.Forms.Label        lblDataPrevisao;
        private System.Windows.Forms.DateTimePicker dtpDataPrevisao;
        private System.Windows.Forms.Label        lblStatus;
        private System.Windows.Forms.ComboBox     cmbStatus;
        private System.Windows.Forms.Label        lblPercentual;
        private System.Windows.Forms.NumericUpDown nudPercentual;
        private System.Windows.Forms.Label        lblPercentualSufixo;
        private System.Windows.Forms.Panel        pnlBotoes;
        private System.Windows.Forms.Button       btnSalvar;
        private System.Windows.Forms.Button       btnCancelar;
    }
}
