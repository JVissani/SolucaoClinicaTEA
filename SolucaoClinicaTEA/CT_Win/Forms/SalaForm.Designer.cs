namespace CT_Win.Forms
{
    partial class SalaForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTitulo     = new System.Windows.Forms.Panel();
            this.lblTitulo     = new System.Windows.Forms.Label();
            this.pnlTituloBd   = new System.Windows.Forms.Panel();
            this.pnlCorpo      = new System.Windows.Forms.Panel();
            this.lblNome       = new System.Windows.Forms.Label();
            this.txtNome       = new System.Windows.Forms.TextBox();
            this.lblCapacidade = new System.Windows.Forms.Label();
            this.nudCapacidade = new System.Windows.Forms.NumericUpDown();
            this.lblRecursos   = new System.Windows.Forms.Label();
            this.txtRecursos   = new System.Windows.Forms.TextBox();
            this.chkAtivo      = new System.Windows.Forms.CheckBox();
            this.pnlBotoes     = new System.Windows.Forms.Panel();
            this.btnSalvar     = new System.Windows.Forms.Button();
            this.btnCancelar   = new System.Windows.Forms.Button();

            this.pnlTitulo.SuspendLayout();
            this.pnlCorpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacidade)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();

            // ── pnlTitulo ────────────────────────────────────────────────────
            this.pnlTitulo.BackColor = System.Drawing.Color.White;
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Controls.Add(this.pnlTituloBd);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(500, 44);

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Nova sala";

            this.pnlTituloBd.BackColor = System.Drawing.Color.FromArgb(224, 229, 235);
            this.pnlTituloBd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTituloBd.Name = "pnlTituloBd";
            this.pnlTituloBd.Size = new System.Drawing.Size(500, 1);

            // ── pnlCorpo ─────────────────────────────────────────────────────
            // Coordenadas pré-calculadas (lx=20 fw=460 lh=18 fh=28 rowH=54):
            //   Nome y=16  Capacidade y=70  Recursos y=124  chkAtivo y=224
            this.pnlCorpo.BackColor = System.Drawing.Color.White;
            this.pnlCorpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCorpo.Name = "pnlCorpo";

            // Nome (full-width)
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNome.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblNome.Location = new System.Drawing.Point(20, 16);
            this.lblNome.Name = "lblNome";
            this.lblNome.Text = "Nome *";

            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNome.Location = new System.Drawing.Point(20, 36);
            this.txtNome.MaxLength = 80;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(460, 28);

            // Capacidade (col1 w=130)
            this.lblCapacidade.AutoSize = true;
            this.lblCapacidade.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCapacidade.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblCapacidade.Location = new System.Drawing.Point(20, 70);
            this.lblCapacidade.Name = "lblCapacidade";
            this.lblCapacidade.Text = "Capacidade (pessoas)";

            this.nudCapacidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudCapacidade.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudCapacidade.Location = new System.Drawing.Point(20, 90);
            this.nudCapacidade.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            this.nudCapacidade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudCapacidade.Name = "nudCapacidade";
            this.nudCapacidade.Size = new System.Drawing.Size(130, 28);
            this.nudCapacidade.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // Recursos sensoriais (multiline, y=124)
            this.lblRecursos.AutoSize = true;
            this.lblRecursos.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRecursos.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblRecursos.Location = new System.Drawing.Point(20, 124);
            this.lblRecursos.Name = "lblRecursos";
            this.lblRecursos.Text = "Recursos sensoriais";

            this.txtRecursos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecursos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRecursos.Location = new System.Drawing.Point(20, 144);
            this.txtRecursos.MaxLength = 500;
            this.txtRecursos.Multiline = true;
            this.txtRecursos.Name = "txtRecursos";
            this.txtRecursos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRecursos.Size = new System.Drawing.Size(460, 72);

            // Ativo (y = 144+72+8 = 224)
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkAtivo.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.chkAtivo.Location = new System.Drawing.Point(20, 224);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Text = "Sala ativa";

            this.pnlCorpo.Controls.Add(this.lblNome);
            this.pnlCorpo.Controls.Add(this.txtNome);
            this.pnlCorpo.Controls.Add(this.lblCapacidade);
            this.pnlCorpo.Controls.Add(this.nudCapacidade);
            this.pnlCorpo.Controls.Add(this.lblRecursos);
            this.pnlCorpo.Controls.Add(this.txtRecursos);
            this.pnlCorpo.Controls.Add(this.chkAtivo);

            // ── pnlBotoes ─────────────────────────────────────────────────────
            this.pnlBotoes.BackColor = System.Drawing.Color.White;
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(500, 56);

            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(44, 95, 127);
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(258, 11);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(105, 34);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(197, 205, 214);
            this.btnCancelar.FlatAppearance.BorderSize = 1;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnCancelar.Location = new System.Drawing.Point(375, 11);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 34);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ── SalaForm ─────────────────────────────────────────────────────
            this.AcceptButton = this.btnSalvar;
            this.CancelButton = this.btnCancelar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 374);
            this.Controls.Add(this.pnlCorpo);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.pnlTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sala";

            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlCorpo.ResumeLayout(false);
            this.pnlCorpo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacidade)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel         pnlTitulo;
        private System.Windows.Forms.Label         lblTitulo;
        private System.Windows.Forms.Panel         pnlTituloBd;
        private System.Windows.Forms.Panel         pnlCorpo;
        private System.Windows.Forms.Label         lblNome;
        private System.Windows.Forms.TextBox       txtNome;
        private System.Windows.Forms.Label         lblCapacidade;
        private System.Windows.Forms.NumericUpDown nudCapacidade;
        private System.Windows.Forms.Label         lblRecursos;
        private System.Windows.Forms.TextBox       txtRecursos;
        private System.Windows.Forms.CheckBox      chkAtivo;
        private System.Windows.Forms.Panel         pnlBotoes;
        private System.Windows.Forms.Button        btnSalvar;
        private System.Windows.Forms.Button        btnCancelar;
    }
}
