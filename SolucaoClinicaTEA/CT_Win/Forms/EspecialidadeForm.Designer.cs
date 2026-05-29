namespace CT_Win.Forms
{
    partial class EspecialidadeForm
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
            this.lblConselho   = new System.Windows.Forms.Label();
            this.txtConselho   = new System.Windows.Forms.TextBox();
            this.lblCorHex     = new System.Windows.Forms.Label();
            this.txtCorHex     = new System.Windows.Forms.TextBox();
            this.pnlCorPreview = new System.Windows.Forms.Panel();
            this.lblCorDica    = new System.Windows.Forms.Label();
            this.chkAtivo      = new System.Windows.Forms.CheckBox();
            this.pnlBotoes     = new System.Windows.Forms.Panel();
            this.btnSalvar     = new System.Windows.Forms.Button();
            this.btnCancelar   = new System.Windows.Forms.Button();

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
            this.pnlTitulo.Size = new System.Drawing.Size(460, 44);

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Nova especialidade";

            this.pnlTituloBd.BackColor = System.Drawing.Color.FromArgb(224, 229, 235);
            this.pnlTituloBd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTituloBd.Name = "pnlTituloBd";
            this.pnlTituloBd.Size = new System.Drawing.Size(460, 1);

            // ── pnlCorpo ─────────────────────────────────────────────────────
            // Coordenadas pré-calculadas (lx=20 fw=420 lh=18 fh=28 rowH=54):
            //   Nome y=16  Conselho/Cor y=70  lblCorDica y=124  chkAtivo y=146
            //   col1w=180  col2x=208  col2w=232
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
            this.txtNome.Size = new System.Drawing.Size(420, 28);

            // Conselho col1(x=20 w=180) | Cor hex col2(x=208 w=196+preview28)
            this.lblConselho.AutoSize = true;
            this.lblConselho.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblConselho.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblConselho.Location = new System.Drawing.Point(20, 70);
            this.lblConselho.Name = "lblConselho";
            this.lblConselho.Text = "Sigla do conselho";

            this.txtConselho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConselho.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtConselho.Location = new System.Drawing.Point(20, 90);
            this.txtConselho.MaxLength = 20;
            this.txtConselho.Name = "txtConselho";
            this.txtConselho.Size = new System.Drawing.Size(180, 28);

            this.lblCorHex.AutoSize = true;
            this.lblCorHex.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCorHex.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblCorHex.Location = new System.Drawing.Point(208, 70);
            this.lblCorHex.Name = "lblCorHex";
            this.lblCorHex.Text = "Cor (ex: #4A7CA8)";

            this.txtCorHex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorHex.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCorHex.Location = new System.Drawing.Point(208, 90);
            this.txtCorHex.MaxLength = 7;
            this.txtCorHex.Name = "txtCorHex";
            this.txtCorHex.Size = new System.Drawing.Size(196, 28);
            this.txtCorHex.TextChanged += new System.EventHandler(this.txtCorHex_TextChanged);

            this.pnlCorPreview.BackColor = System.Drawing.Color.FromArgb(237, 241, 244);
            this.pnlCorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCorPreview.Location = new System.Drawing.Point(408, 90);
            this.pnlCorPreview.Name = "pnlCorPreview";
            this.pnlCorPreview.Size = new System.Drawing.Size(28, 28);

            // Dica cor (y = 70+54 = 124)
            this.lblCorDica.AutoSize = true;
            this.lblCorDica.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblCorDica.ForeColor = System.Drawing.Color.FromArgb(139, 150, 163);
            this.lblCorDica.Location = new System.Drawing.Point(20, 124);
            this.lblCorDica.Name = "lblCorDica";
            this.lblCorDica.Text = "A cor é usada na agenda para identificar a especialidade visualmente.";

            // Ativo (y = 124+22 = 146)
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkAtivo.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.chkAtivo.Location = new System.Drawing.Point(20, 150);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Text = "Especialidade ativa";

            this.pnlCorpo.Controls.Add(this.lblNome);
            this.pnlCorpo.Controls.Add(this.txtNome);
            this.pnlCorpo.Controls.Add(this.lblConselho);
            this.pnlCorpo.Controls.Add(this.txtConselho);
            this.pnlCorpo.Controls.Add(this.lblCorHex);
            this.pnlCorpo.Controls.Add(this.txtCorHex);
            this.pnlCorpo.Controls.Add(this.pnlCorPreview);
            this.pnlCorpo.Controls.Add(this.lblCorDica);
            this.pnlCorpo.Controls.Add(this.chkAtivo);

            // ── pnlBotoes ─────────────────────────────────────────────────────
            this.pnlBotoes.BackColor = System.Drawing.Color.White;
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(460, 56);

            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(44, 95, 127);
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(218, 11);
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
            this.btnCancelar.Location = new System.Drawing.Point(335, 11);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 34);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ── EspecialidadeForm ─────────────────────────────────────────────
            this.AcceptButton = this.btnSalvar;
            this.CancelButton = this.btnCancelar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 344);
            this.Controls.Add(this.pnlCorpo);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.pnlTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EspecialidadeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Especialidade";

            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlCorpo.ResumeLayout(false);
            this.pnlCorpo.PerformLayout();
            this.pnlBotoes.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel    pnlTitulo;
        private System.Windows.Forms.Label    lblTitulo;
        private System.Windows.Forms.Panel    pnlTituloBd;
        private System.Windows.Forms.Panel    pnlCorpo;
        private System.Windows.Forms.Label    lblNome;
        private System.Windows.Forms.TextBox  txtNome;
        private System.Windows.Forms.Label    lblConselho;
        private System.Windows.Forms.TextBox  txtConselho;
        private System.Windows.Forms.Label    lblCorHex;
        private System.Windows.Forms.TextBox  txtCorHex;
        private System.Windows.Forms.Panel    pnlCorPreview;
        private System.Windows.Forms.Label    lblCorDica;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Panel    pnlBotoes;
        private System.Windows.Forms.Button   btnSalvar;
        private System.Windows.Forms.Button   btnCancelar;
    }
}
