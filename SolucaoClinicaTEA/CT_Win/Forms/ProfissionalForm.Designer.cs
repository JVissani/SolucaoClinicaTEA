namespace CT_Win.Forms
{
    partial class ProfissionalForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTitulo        = new System.Windows.Forms.Panel();
            this.lblTitulo        = new System.Windows.Forms.Label();
            this.pnlTituloBd      = new System.Windows.Forms.Panel();
            this.pnlCorpo         = new System.Windows.Forms.Panel();
            this.lblNome          = new System.Windows.Forms.Label();
            this.txtNome          = new System.Windows.Forms.TextBox();
            this.lblNomeSocial    = new System.Windows.Forms.Label();
            this.txtNomeSocial    = new System.Windows.Forms.TextBox();
            this.lblCPF           = new System.Windows.Forms.Label();
            this.mskCPF           = new System.Windows.Forms.MaskedTextBox();
            this.lblEspecialidade = new System.Windows.Forms.Label();
            this.cmbEspecialidade = new System.Windows.Forms.ComboBox();
            this.lblRegistro      = new System.Windows.Forms.Label();
            this.txtRegistro      = new System.Windows.Forms.TextBox();
            this.lblTelefone      = new System.Windows.Forms.Label();
            this.mskTelefone      = new System.Windows.Forms.MaskedTextBox();
            this.lblEmail         = new System.Windows.Forms.Label();
            this.txtEmail         = new System.Windows.Forms.TextBox();
            this.chkAtivo         = new System.Windows.Forms.CheckBox();
            this.pnlBotoes        = new System.Windows.Forms.Panel();
            this.btnSalvar        = new System.Windows.Forms.Button();
            this.btnCancelar      = new System.Windows.Forms.Button();

            this.pnlTitulo.SuspendLayout();
            this.pnlCorpo.SuspendLayout();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();

            // ── pnlTitulo ────────────────────────────────────────────────────
            this.pnlTitulo.BackColor = System.Drawing.Color.White;
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Controls.Add(this.pnlTituloBd);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(580, 44);

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Novo profissional";

            this.pnlTituloBd.BackColor = System.Drawing.Color.FromArgb(224, 229, 235);
            this.pnlTituloBd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTituloBd.Name = "pnlTituloBd";
            this.pnlTituloBd.Size = new System.Drawing.Size(580, 1);

            // ── pnlCorpo ─────────────────────────────────────────────────────
            // Coordenadas pré-calculadas (lx=20 fw=540 lh=18 fh=28 gap=8 rowH=54):
            //   Row1 y=16  Row2 y=70  Row3 y=124  Row4 y=178  Row5 y=232  chkAtivo y=290
            //   col1w=244  col2x=272  col2w=288
            this.pnlCorpo.BackColor = System.Drawing.Color.White;
            this.pnlCorpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCorpo.Name = "pnlCorpo";

            // Row 1 – Nome (full-width)
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNome.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblNome.Location = new System.Drawing.Point(20, 16);
            this.lblNome.Name = "lblNome";
            this.lblNome.Text = "Nome *";

            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNome.Location = new System.Drawing.Point(20, 36);
            this.txtNome.MaxLength = 150;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(540, 28);

            // Row 2 – Nome social (full-width)
            this.lblNomeSocial.AutoSize = true;
            this.lblNomeSocial.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNomeSocial.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblNomeSocial.Location = new System.Drawing.Point(20, 70);
            this.lblNomeSocial.Name = "lblNomeSocial";
            this.lblNomeSocial.Text = "Nome social";

            this.txtNomeSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeSocial.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNomeSocial.Location = new System.Drawing.Point(20, 90);
            this.txtNomeSocial.MaxLength = 150;
            this.txtNomeSocial.Name = "txtNomeSocial";
            this.txtNomeSocial.Size = new System.Drawing.Size(540, 28);

            // Row 3 – CPF col1(x=20 w=244) | Especialidade col2(x=272 w=288)
            this.lblCPF.AutoSize = true;
            this.lblCPF.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCPF.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblCPF.Location = new System.Drawing.Point(20, 124);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Text = "CPF";

            this.mskCPF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskCPF.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.mskCPF.Location = new System.Drawing.Point(20, 144);
            this.mskCPF.Mask = "000.000.000-00";
            this.mskCPF.Name = "mskCPF";
            this.mskCPF.Size = new System.Drawing.Size(244, 28);

            this.lblEspecialidade.AutoSize = true;
            this.lblEspecialidade.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEspecialidade.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblEspecialidade.Location = new System.Drawing.Point(272, 124);
            this.lblEspecialidade.Name = "lblEspecialidade";
            this.lblEspecialidade.Text = "Especialidade *";

            this.cmbEspecialidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbEspecialidade.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbEspecialidade.Location = new System.Drawing.Point(272, 144);
            this.cmbEspecialidade.Name = "cmbEspecialidade";
            this.cmbEspecialidade.Size = new System.Drawing.Size(288, 28);

            // Row 4 – Registro (full-width)
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRegistro.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblRegistro.Location = new System.Drawing.Point(20, 178);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Text = "Registro no conselho (CRP, CRFa, CREFITO…)";

            this.txtRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegistro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRegistro.Location = new System.Drawing.Point(20, 198);
            this.txtRegistro.MaxLength = 30;
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(540, 28);

            // Row 5 – Telefone col1(x=20 w=244) | Email col2(x=272 w=288)
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTelefone.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblTelefone.Location = new System.Drawing.Point(20, 232);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Text = "Telefone";

            this.mskTelefone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskTelefone.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.mskTelefone.Location = new System.Drawing.Point(20, 252);
            this.mskTelefone.Mask = "(00) 00000-0000";
            this.mskTelefone.Name = "mskTelefone";
            this.mskTelefone.Size = new System.Drawing.Size(244, 28);

            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblEmail.Location = new System.Drawing.Point(272, 232);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "E-mail";

            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmail.Location = new System.Drawing.Point(272, 252);
            this.txtEmail.MaxLength = 120;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(288, 28);

            // Row 6 – Ativo (y = 232+54+4 = 290)
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkAtivo.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.chkAtivo.Location = new System.Drawing.Point(20, 290);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Text = "Profissional ativo";

            this.pnlCorpo.Controls.Add(this.lblNome);
            this.pnlCorpo.Controls.Add(this.txtNome);
            this.pnlCorpo.Controls.Add(this.lblNomeSocial);
            this.pnlCorpo.Controls.Add(this.txtNomeSocial);
            this.pnlCorpo.Controls.Add(this.lblCPF);
            this.pnlCorpo.Controls.Add(this.mskCPF);
            this.pnlCorpo.Controls.Add(this.lblEspecialidade);
            this.pnlCorpo.Controls.Add(this.cmbEspecialidade);
            this.pnlCorpo.Controls.Add(this.lblRegistro);
            this.pnlCorpo.Controls.Add(this.txtRegistro);
            this.pnlCorpo.Controls.Add(this.lblTelefone);
            this.pnlCorpo.Controls.Add(this.mskTelefone);
            this.pnlCorpo.Controls.Add(this.lblEmail);
            this.pnlCorpo.Controls.Add(this.txtEmail);
            this.pnlCorpo.Controls.Add(this.chkAtivo);

            // ── pnlBotoes ─────────────────────────────────────────────────────
            this.pnlBotoes.BackColor = System.Drawing.Color.White;
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(580, 56);

            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(44, 95, 127);
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(335, 11);
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
            this.btnCancelar.Location = new System.Drawing.Point(452, 11);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 34);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ── ProfissionalForm ──────────────────────────────────────────────
            this.AcceptButton = this.btnSalvar;
            this.CancelButton = this.btnCancelar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 414);
            this.Controls.Add(this.pnlCorpo);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.pnlTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfissionalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profissional";

            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlCorpo.ResumeLayout(false);
            this.pnlCorpo.PerformLayout();
            this.pnlBotoes.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel         pnlTitulo;
        private System.Windows.Forms.Label         lblTitulo;
        private System.Windows.Forms.Panel         pnlTituloBd;
        private System.Windows.Forms.Panel         pnlCorpo;
        private System.Windows.Forms.Label         lblNome;
        private System.Windows.Forms.TextBox       txtNome;
        private System.Windows.Forms.Label         lblNomeSocial;
        private System.Windows.Forms.TextBox       txtNomeSocial;
        private System.Windows.Forms.Label         lblCPF;
        private System.Windows.Forms.MaskedTextBox mskCPF;
        private System.Windows.Forms.Label         lblEspecialidade;
        private System.Windows.Forms.ComboBox      cmbEspecialidade;
        private System.Windows.Forms.Label         lblRegistro;
        private System.Windows.Forms.TextBox       txtRegistro;
        private System.Windows.Forms.Label         lblTelefone;
        private System.Windows.Forms.MaskedTextBox mskTelefone;
        private System.Windows.Forms.Label         lblEmail;
        private System.Windows.Forms.TextBox       txtEmail;
        private System.Windows.Forms.CheckBox      chkAtivo;
        private System.Windows.Forms.Panel         pnlBotoes;
        private System.Windows.Forms.Button        btnSalvar;
        private System.Windows.Forms.Button        btnCancelar;
    }
}
