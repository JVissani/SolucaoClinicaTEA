namespace CT_Win.Forms
{
    partial class AgendamentoForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblFormTitulo   = new System.Windows.Forms.Label();
            this.lblPaciente     = new System.Windows.Forms.Label();
            this.cmbPaciente     = new System.Windows.Forms.ComboBox();
            this.lblProfissional = new System.Windows.Forms.Label();
            this.cmbProfissional = new System.Windows.Forms.ComboBox();
            this.lblSala         = new System.Windows.Forms.Label();
            this.cmbSala         = new System.Windows.Forms.ComboBox();
            this.lblData         = new System.Windows.Forms.Label();
            this.dtpData         = new System.Windows.Forms.DateTimePicker();
            this.lblHoraInicio   = new System.Windows.Forms.Label();
            this.dtpHoraInicio   = new System.Windows.Forms.DateTimePicker();
            this.lblHoraFim      = new System.Windows.Forms.Label();
            this.dtpHoraFim      = new System.Windows.Forms.DateTimePicker();
            this.lblStatus       = new System.Windows.Forms.Label();
            this.cmbStatus       = new System.Windows.Forms.ComboBox();
            this.lblObservacao   = new System.Windows.Forms.Label();
            this.txtObservacao   = new System.Windows.Forms.TextBox();
            this.pnlBotoes       = new System.Windows.Forms.Panel();
            this.btnSalvar       = new System.Windows.Forms.Button();
            this.btnCancelar     = new System.Windows.Forms.Button();
            this.pnlBotoesBd     = new System.Windows.Forms.Panel();

            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();

            // ── lblFormTitulo ─────────────────────────────────────────────────
            this.lblFormTitulo.AutoSize  = true;
            this.lblFormTitulo.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblFormTitulo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblFormTitulo.Location  = new System.Drawing.Point(24, 18);
            this.lblFormTitulo.Name      = "lblFormTitulo";
            this.lblFormTitulo.Text      = "Novo Agendamento";

            // ── Paciente ──────────────────────────────────────────────────────
            this.lblPaciente.AutoSize  = true;
            this.lblPaciente.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPaciente.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblPaciente.Location  = new System.Drawing.Point(24, 62);
            this.lblPaciente.Text      = "Paciente *";

            this.cmbPaciente.DropDownStyle      = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaciente.Font               = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPaciente.FormattingEnabled  = true;
            this.cmbPaciente.Location           = new System.Drawing.Point(24, 80);
            this.cmbPaciente.Name               = "cmbPaciente";
            this.cmbPaciente.Size               = new System.Drawing.Size(456, 28);
            this.cmbPaciente.TabIndex           = 1;

            // ── Profissional ──────────────────────────────────────────────────
            this.lblProfissional.AutoSize  = true;
            this.lblProfissional.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProfissional.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblProfissional.Location  = new System.Drawing.Point(24, 120);
            this.lblProfissional.Text      = "Profissional *";

            this.cmbProfissional.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfissional.Font              = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbProfissional.FormattingEnabled = true;
            this.cmbProfissional.Location          = new System.Drawing.Point(24, 138);
            this.cmbProfissional.Name              = "cmbProfissional";
            this.cmbProfissional.Size              = new System.Drawing.Size(456, 28);
            this.cmbProfissional.TabIndex          = 2;

            // ── Sala ──────────────────────────────────────────────────────────
            this.lblSala.AutoSize  = true;
            this.lblSala.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSala.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblSala.Location  = new System.Drawing.Point(24, 178);
            this.lblSala.Text      = "Sala *";

            this.cmbSala.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSala.Font              = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSala.FormattingEnabled = true;
            this.cmbSala.Location          = new System.Drawing.Point(24, 196);
            this.cmbSala.Name              = "cmbSala";
            this.cmbSala.Size              = new System.Drawing.Size(220, 28);
            this.cmbSala.TabIndex          = 3;

            // ── Data / Hora ───────────────────────────────────────────────────
            this.lblData.AutoSize  = true;
            this.lblData.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblData.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblData.Location  = new System.Drawing.Point(24, 236);
            this.lblData.Text      = "Data *";

            this.dtpData.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpData.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(24, 254);
            this.dtpData.Name     = "dtpData";
            this.dtpData.Size     = new System.Drawing.Size(140, 28);
            this.dtpData.TabIndex = 4;

            this.lblHoraInicio.AutoSize  = true;
            this.lblHoraInicio.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHoraInicio.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblHoraInicio.Location  = new System.Drawing.Point(178, 236);
            this.lblHoraInicio.Text      = "Início *";

            this.dtpHoraInicio.Font       = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHoraInicio.Format     = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicio.ShowUpDown = true;
            this.dtpHoraInicio.Location   = new System.Drawing.Point(178, 254);
            this.dtpHoraInicio.Name       = "dtpHoraInicio";
            this.dtpHoraInicio.Size       = new System.Drawing.Size(110, 28);
            this.dtpHoraInicio.TabIndex   = 5;

            this.lblHoraFim.AutoSize  = true;
            this.lblHoraFim.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHoraFim.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblHoraFim.Location  = new System.Drawing.Point(306, 236);
            this.lblHoraFim.Text      = "Fim *";

            this.dtpHoraFim.Font       = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHoraFim.Format     = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraFim.ShowUpDown = true;
            this.dtpHoraFim.Location   = new System.Drawing.Point(306, 254);
            this.dtpHoraFim.Name       = "dtpHoraFim";
            this.dtpHoraFim.Size       = new System.Drawing.Size(110, 28);
            this.dtpHoraFim.TabIndex   = 6;

            // ── Status ────────────────────────────────────────────────────────
            this.lblStatus.AutoSize  = true;
            this.lblStatus.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblStatus.Location  = new System.Drawing.Point(24, 294);
            this.lblStatus.Text      = "Status";

            this.cmbStatus.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font              = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] { "Agendado", "Realizado", "Faltou", "Cancelado" });
            this.cmbStatus.Location          = new System.Drawing.Point(24, 312);
            this.cmbStatus.Name              = "cmbStatus";
            this.cmbStatus.Size              = new System.Drawing.Size(180, 28);
            this.cmbStatus.SelectedIndex     = 0;
            this.cmbStatus.TabIndex          = 7;

            // ── Observação ────────────────────────────────────────────────────
            this.lblObservacao.AutoSize  = true;
            this.lblObservacao.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblObservacao.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblObservacao.Location  = new System.Drawing.Point(24, 352);
            this.lblObservacao.Text      = "Observação";

            this.txtObservacao.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservacao.Location  = new System.Drawing.Point(24, 370);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name      = "txtObservacao";
            this.txtObservacao.Size      = new System.Drawing.Size(456, 72);
            this.txtObservacao.TabIndex  = 8;

            // ── pnlBotoes ─────────────────────────────────────────────────────
            this.pnlBotoes.BackColor = System.Drawing.Color.FromArgb(247, 248, 250);
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Controls.Add(this.pnlBotoesBd);
            this.pnlBotoes.Dock     = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Name     = "pnlBotoes";
            this.pnlBotoes.Size     = new System.Drawing.Size(504, 56);
            this.pnlBotoes.TabIndex = 20;

            this.pnlBotoesBd.BackColor = System.Drawing.Color.FromArgb(224, 229, 235);
            this.pnlBotoesBd.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlBotoesBd.Name      = "pnlBotoesBd";
            this.pnlBotoesBd.Size      = new System.Drawing.Size(504, 1);

            this.btnCancelar.BackColor                    = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderColor   = System.Drawing.Color.FromArgb(197, 205, 214);
            this.btnCancelar.FlatAppearance.BorderSize    = 1;
            this.btnCancelar.FlatStyle                    = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font                         = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelar.ForeColor                    = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnCancelar.Location                     = new System.Drawing.Point(16, 12);
            this.btnCancelar.Name                         = "btnCancelar";
            this.btnCancelar.Size                         = new System.Drawing.Size(105, 34);
            this.btnCancelar.Text                         = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor      = false;
            this.btnCancelar.Cursor                       = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.btnSalvar.BackColor               = System.Drawing.Color.FromArgb(44, 95, 127);
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle               = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font                    = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSalvar.ForeColor               = System.Drawing.Color.White;
            this.btnSalvar.Location                = new System.Drawing.Point(133, 12);
            this.btnSalvar.Name                    = "btnSalvar";
            this.btnSalvar.Size                    = new System.Drawing.Size(120, 34);
            this.btnSalvar.Text                    = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Cursor                  = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // ── AgendamentoForm ───────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(504, 520);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.lblObservacao);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dtpHoraFim);
            this.Controls.Add(this.lblHoraFim);
            this.Controls.Add(this.dtpHoraInicio);
            this.Controls.Add(this.lblHoraInicio);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.cmbSala);
            this.Controls.Add(this.lblSala);
            this.Controls.Add(this.cmbProfissional);
            this.Controls.Add(this.lblProfissional);
            this.Controls.Add(this.cmbPaciente);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.lblFormTitulo);
            this.Font                = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.Name                = "AgendamentoForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "Agendamento";

            this.pnlBotoes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label          lblFormTitulo;
        private System.Windows.Forms.Label          lblPaciente;
        private System.Windows.Forms.ComboBox       cmbPaciente;
        private System.Windows.Forms.Label          lblProfissional;
        private System.Windows.Forms.ComboBox       cmbProfissional;
        private System.Windows.Forms.Label          lblSala;
        private System.Windows.Forms.ComboBox       cmbSala;
        private System.Windows.Forms.Label          lblData;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label          lblHoraInicio;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.Label          lblHoraFim;
        private System.Windows.Forms.DateTimePicker dtpHoraFim;
        private System.Windows.Forms.Label          lblStatus;
        private System.Windows.Forms.ComboBox       cmbStatus;
        private System.Windows.Forms.Label          lblObservacao;
        private System.Windows.Forms.TextBox        txtObservacao;
        private System.Windows.Forms.Panel          pnlBotoes;
        private System.Windows.Forms.Button         btnSalvar;
        private System.Windows.Forms.Button         btnCancelar;
        private System.Windows.Forms.Panel          pnlBotoesBd;
    }
}
