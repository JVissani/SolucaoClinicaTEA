namespace CT_Win.UserControls
{
    partial class RelatorioUserControl
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
            this.pnlConteudo          = new System.Windows.Forms.Panel();
            this.pnlBotoes            = new System.Windows.Forms.Panel();
            this.pnlBotoesBorder      = new System.Windows.Forms.Panel();
            this.btnInicio            = new System.Windows.Forms.Button();

            this.pnlNav.SuspendLayout();
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

            // ── pnlConteudo (Fill, AutoScroll) ────────────────────────────────
            this.pnlConteudo.AutoScroll = true;
            this.pnlConteudo.BackColor  = System.Drawing.Color.FromArgb(247, 248, 250);
            this.pnlConteudo.Dock       = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Name       = "pnlConteudo";
            this.pnlConteudo.TabIndex   = 1;

            // ── pnlBotoes (Bottom) ────────────────────────────────────────────
            this.pnlBotoes.BackColor = System.Drawing.Color.White;
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

            // ── RelatorioUserControl ──────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(247, 248, 250);
            this.Controls.Add(this.pnlConteudo);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.pnlNav);
            this.Font    = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name    = "RelatorioUserControl";
            this.Size    = new System.Drawing.Size(1200, 700);

            this.pnlNav.ResumeLayout(false);
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
        private System.Windows.Forms.Panel   pnlConteudo;
        private System.Windows.Forms.Panel   pnlBotoes;
        private System.Windows.Forms.Panel   pnlBotoesBorder;
        private System.Windows.Forms.Button  btnInicio;
    }
}
