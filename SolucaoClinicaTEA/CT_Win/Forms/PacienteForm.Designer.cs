namespace CT_Win.Forms
{
    partial class PacienteForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlCabecalho    = new System.Windows.Forms.Panel();
            this.lblFormTitulo   = new System.Windows.Forms.Label();
            this.pnlFooter       = new System.Windows.Forms.Panel();
            this.pnlFooterBorder = new System.Windows.Forms.Panel();
            this.btnSalvar       = new System.Windows.Forms.Button();
            this.btnCancelar     = new System.Windows.Forms.Button();
            this.pnlScroll       = new System.Windows.Forms.Panel();
            this.lblNome         = new System.Windows.Forms.Label();
            this.txtNome         = new System.Windows.Forms.TextBox();
            this.lblNomeSocial   = new System.Windows.Forms.Label();
            this.txtNomeSocial   = new System.Windows.Forms.TextBox();
            this.lblCPF          = new System.Windows.Forms.Label();
            this.txtCPF          = new System.Windows.Forms.MaskedTextBox();
            this.lblNascimento   = new System.Windows.Forms.Label();
            this.dtpNascimento   = new System.Windows.Forms.DateTimePicker();
            this.lblSexo         = new System.Windows.Forms.Label();
            this.cmbSexo         = new System.Windows.Forms.ComboBox();
            this.lblNivel        = new System.Windows.Forms.Label();
            this.cmbNivel        = new System.Windows.Forms.ComboBox();
            this.lblDiagnostico  = new System.Windows.Forms.Label();
            this.dtpDiagnostico  = new System.Windows.Forms.DateTimePicker();
            this.lblCIPTEA       = new System.Windows.Forms.Label();
            this.txtCIPTEA       = new System.Windows.Forms.TextBox();
            this.lblCidade       = new System.Windows.Forms.Label();
            this.cmbCidade       = new System.Windows.Forms.ComboBox();
            this.lblTelefone     = new System.Windows.Forms.Label();
            this.txtTelefone     = new System.Windows.Forms.MaskedTextBox();
            this.lblEmail        = new System.Windows.Forms.Label();
            this.txtEmail        = new System.Windows.Forms.TextBox();
            this.lblSecaoResp    = new System.Windows.Forms.Label();
            this.lblNomeResp     = new System.Windows.Forms.Label();
            this.txtNomeResp     = new System.Windows.Forms.TextBox();
            this.lblCPFResp      = new System.Windows.Forms.Label();
            this.txtCPFResp      = new System.Windows.Forms.MaskedTextBox();
            this.lblTelResp      = new System.Windows.Forms.Label();
            this.txtTelResp      = new System.Windows.Forms.MaskedTextBox();
            this.lblObs          = new System.Windows.Forms.Label();
            this.txtObs          = new System.Windows.Forms.TextBox();
            this.chkAtivo        = new System.Windows.Forms.CheckBox();

            this.pnlCabecalho.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlScroll.SuspendLayout();
            this.SuspendLayout();

            // ── pnlCabecalho (Top, 56px) ─────────────────────────────────────
            this.pnlCabecalho.BackColor = System.Drawing.Color.FromArgb(44, 95, 127);
            this.pnlCabecalho.Controls.Add(this.lblFormTitulo);
            this.pnlCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecalho.Name = "pnlCabecalho";
            this.pnlCabecalho.Size = new System.Drawing.Size(820, 44);
            this.pnlCabecalho.TabIndex = 0;

            this.lblFormTitulo.AutoSize = true;
            this.lblFormTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblFormTitulo.ForeColor = System.Drawing.Color.White;
            this.lblFormTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblFormTitulo.Name = "lblFormTitulo";
            this.lblFormTitulo.TabIndex = 0;
            this.lblFormTitulo.Text = "Novo paciente";

            // ── pnlFooter (Bottom, 64px) ──────────────────────────────────────
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Controls.Add(this.btnSalvar);
            this.pnlFooter.Controls.Add(this.pnlFooterBorder);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(820, 64);
            this.pnlFooter.TabIndex = 1;

            this.pnlFooterBorder.BackColor = System.Drawing.Color.FromArgb(224, 229, 235);
            this.pnlFooterBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFooterBorder.Name = "pnlFooterBorder";
            this.pnlFooterBorder.Size = new System.Drawing.Size(820, 1);
            this.pnlFooterBorder.TabIndex = 0;

            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(44, 95, 127);
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(490, 14);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(145, 36);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(197, 205, 214);
            this.btnCancelar.FlatAppearance.BorderSize = 1;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(91, 101, 115);
            this.btnCancelar.Location = new System.Drawing.Point(647, 14);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(145, 36);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ── pnlScroll (Fill, AutoScroll) ──────────────────────────────────
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(247, 248, 250);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.TabIndex = 2;

            // ── Controles (coordenadas pré-calculadas) ────────────────────────
            // Grade 2 colunas: col1(x=20 w=375)  col2(x=405 w=375)  fw=760
            // lh=18  fh=28  rowH=54
            // y=14   y=68   y=122  y=176  y=230  y=284  y=338
            // Seção resp: y=398  y=420  y=474  y=528  chkAtivo y=618

            // Row 1 – Nome completo * (full width, y=14)
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblNome.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblNome.Location = new System.Drawing.Point(20, 14);
            this.lblNome.Name = "lblNome";
            this.lblNome.Text = "Nome completo *";

            this.txtNome.BackColor = System.Drawing.Color.White;
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNome.Location = new System.Drawing.Point(20, 32);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(760, 28);
            this.txtNome.TabIndex = 10;

            // Row 2 – Nome social (full width, y=68)
            this.lblNomeSocial.AutoSize = true;
            this.lblNomeSocial.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblNomeSocial.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblNomeSocial.Location = new System.Drawing.Point(20, 68);
            this.lblNomeSocial.Name = "lblNomeSocial";
            this.lblNomeSocial.Text = "Nome social (como prefere ser chamado)";

            this.txtNomeSocial.BackColor = System.Drawing.Color.White;
            this.txtNomeSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeSocial.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNomeSocial.Location = new System.Drawing.Point(20, 86);
            this.txtNomeSocial.Name = "txtNomeSocial";
            this.txtNomeSocial.Size = new System.Drawing.Size(760, 28);
            this.txtNomeSocial.TabIndex = 11;

            // Row 3 – CPF col1 | Data nascimento col2 (y=122)
            this.lblCPF.AutoSize = true;
            this.lblCPF.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCPF.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblCPF.Location = new System.Drawing.Point(20, 122);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Text = "CPF";

            this.txtCPF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCPF.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCPF.Location = new System.Drawing.Point(20, 140);
            this.txtCPF.Mask = "000.000.000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(375, 28);
            this.txtCPF.TabIndex = 12;

            this.lblNascimento.AutoSize = true;
            this.lblNascimento.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblNascimento.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblNascimento.Location = new System.Drawing.Point(405, 122);
            this.lblNascimento.Name = "lblNascimento";
            this.lblNascimento.Text = "Data de nascimento *";

            this.dtpNascimento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNascimento.Location = new System.Drawing.Point(405, 140);
            this.dtpNascimento.Name = "dtpNascimento";
            this.dtpNascimento.Size = new System.Drawing.Size(375, 28);
            this.dtpNascimento.TabIndex = 13;

            // Row 4 – Sexo col1 | Nível suporte col2 (y=176)
            this.lblSexo.AutoSize = true;
            this.lblSexo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSexo.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblSexo.Location = new System.Drawing.Point(20, 176);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Text = "Sexo";

            this.cmbSexo.BackColor = System.Drawing.Color.White;
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbSexo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbSexo.Items.AddRange(new object[] { "", "Masculino", "Feminino", "Outro" });
            this.cmbSexo.Location = new System.Drawing.Point(20, 194);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(375, 28);
            this.cmbSexo.TabIndex = 14;

            this.lblNivel.AutoSize = true;
            this.lblNivel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblNivel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblNivel.Location = new System.Drawing.Point(405, 176);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Text = "Nível de suporte (DSM-5) *";

            this.cmbNivel.BackColor = System.Drawing.Color.White;
            this.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbNivel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbNivel.Items.AddRange(new object[] {
                "— Selecione —",
                "Nível 1 – Exigindo apoio",
                "Nível 2 – Exigindo apoio substancial",
                "Nível 3 – Exigindo apoio muito substancial" });
            this.cmbNivel.Location = new System.Drawing.Point(405, 194);
            this.cmbNivel.Name = "cmbNivel";
            this.cmbNivel.Size = new System.Drawing.Size(375, 28);
            this.cmbNivel.TabIndex = 15;

            // Row 5 – Data diagnóstico col1 | CIPTEA col2 (y=230)
            this.lblDiagnostico.AutoSize = true;
            this.lblDiagnostico.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblDiagnostico.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblDiagnostico.Location = new System.Drawing.Point(20, 230);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Text = "Data do diagnóstico (opcional)";

            this.dtpDiagnostico.Checked = false;
            this.dtpDiagnostico.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDiagnostico.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDiagnostico.Location = new System.Drawing.Point(20, 248);
            this.dtpDiagnostico.Name = "dtpDiagnostico";
            this.dtpDiagnostico.ShowCheckBox = true;
            this.dtpDiagnostico.Size = new System.Drawing.Size(375, 28);
            this.dtpDiagnostico.TabIndex = 16;

            this.lblCIPTEA.AutoSize = true;
            this.lblCIPTEA.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCIPTEA.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblCIPTEA.Location = new System.Drawing.Point(405, 230);
            this.lblCIPTEA.Name = "lblCIPTEA";
            this.lblCIPTEA.Text = "Número CIPTEA (opcional)";

            this.txtCIPTEA.BackColor = System.Drawing.Color.White;
            this.txtCIPTEA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCIPTEA.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCIPTEA.Location = new System.Drawing.Point(405, 248);
            this.txtCIPTEA.Name = "txtCIPTEA";
            this.txtCIPTEA.Size = new System.Drawing.Size(375, 28);
            this.txtCIPTEA.TabIndex = 17;

            // Row 6 – Cidade col1 | Telefone col2 (y=284)
            this.lblCidade.AutoSize = true;
            this.lblCidade.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCidade.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblCidade.Location = new System.Drawing.Point(20, 284);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Text = "Cidade *";

            this.cmbCidade.BackColor = System.Drawing.Color.White;
            this.cmbCidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCidade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbCidade.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCidade.Location = new System.Drawing.Point(20, 302);
            this.cmbCidade.Name = "cmbCidade";
            this.cmbCidade.Size = new System.Drawing.Size(375, 28);
            this.cmbCidade.TabIndex = 18;

            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTelefone.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblTelefone.Location = new System.Drawing.Point(405, 284);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Text = "Telefone do paciente";

            this.txtTelefone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefone.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTelefone.Location = new System.Drawing.Point(405, 302);
            this.txtTelefone.Mask = "(00) 00000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(375, 28);
            this.txtTelefone.TabIndex = 19;

            // Row 7 – E-mail (full width, y=338)
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblEmail.Location = new System.Drawing.Point(20, 338);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "E-mail";

            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmail.Location = new System.Drawing.Point(20, 356);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(760, 28);
            this.txtEmail.TabIndex = 20;

            // Seção responsável (y = 338+54+6 = 398)
            this.lblSecaoResp.AutoSize = true;
            this.lblSecaoResp.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSecaoResp.ForeColor = System.Drawing.Color.FromArgb(139, 150, 163);
            this.lblSecaoResp.Location = new System.Drawing.Point(20, 398);
            this.lblSecaoResp.Name = "lblSecaoResp";
            this.lblSecaoResp.Text = "RESPONSÁVEL / ACOMPANHANTE";

            // Row 8 – Nome responsável (full width, y=420)
            this.lblNomeResp.AutoSize = true;
            this.lblNomeResp.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblNomeResp.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblNomeResp.Location = new System.Drawing.Point(20, 420);
            this.lblNomeResp.Name = "lblNomeResp";
            this.lblNomeResp.Text = "Nome do responsável";

            this.txtNomeResp.BackColor = System.Drawing.Color.White;
            this.txtNomeResp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeResp.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNomeResp.Location = new System.Drawing.Point(20, 438);
            this.txtNomeResp.Name = "txtNomeResp";
            this.txtNomeResp.Size = new System.Drawing.Size(760, 28);
            this.txtNomeResp.TabIndex = 21;

            // Row 9 – CPF resp col1 | Tel resp col2 (y=474)
            this.lblCPFResp.AutoSize = true;
            this.lblCPFResp.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCPFResp.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblCPFResp.Location = new System.Drawing.Point(20, 474);
            this.lblCPFResp.Name = "lblCPFResp";
            this.lblCPFResp.Text = "CPF do responsável";

            this.txtCPFResp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCPFResp.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCPFResp.Location = new System.Drawing.Point(20, 492);
            this.txtCPFResp.Mask = "000.000.000-00";
            this.txtCPFResp.Name = "txtCPFResp";
            this.txtCPFResp.Size = new System.Drawing.Size(375, 28);
            this.txtCPFResp.TabIndex = 22;

            this.lblTelResp.AutoSize = true;
            this.lblTelResp.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTelResp.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblTelResp.Location = new System.Drawing.Point(405, 474);
            this.lblTelResp.Name = "lblTelResp";
            this.lblTelResp.Text = "Telefone do responsável";

            this.txtTelResp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelResp.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTelResp.Location = new System.Drawing.Point(405, 492);
            this.txtTelResp.Mask = "(00) 00000-0000";
            this.txtTelResp.Name = "txtTelResp";
            this.txtTelResp.Size = new System.Drawing.Size(375, 28);
            this.txtTelResp.TabIndex = 23;

            // Row 10 – Observações (multiline, y=528)
            this.lblObs.AutoSize = true;
            this.lblObs.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblObs.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblObs.Location = new System.Drawing.Point(20, 528);
            this.lblObs.Name = "lblObs";
            this.lblObs.Text = "Observações";

            this.txtObs.BackColor = System.Drawing.Color.White;
            this.txtObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObs.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtObs.Location = new System.Drawing.Point(20, 546);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObs.Size = new System.Drawing.Size(760, 64);
            this.txtObs.TabIndex = 24;

            // Ativo (y = 546+64+8 = 618)
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkAtivo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.chkAtivo.Location = new System.Drawing.Point(20, 618);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.TabIndex = 25;
            this.chkAtivo.Text = "Paciente ativo";

            // ── Adicionar ao pnlScroll ─────────────────────────────────────────
            this.pnlScroll.Controls.Add(this.lblNome);
            this.pnlScroll.Controls.Add(this.txtNome);
            this.pnlScroll.Controls.Add(this.lblNomeSocial);
            this.pnlScroll.Controls.Add(this.txtNomeSocial);
            this.pnlScroll.Controls.Add(this.lblCPF);
            this.pnlScroll.Controls.Add(this.txtCPF);
            this.pnlScroll.Controls.Add(this.lblNascimento);
            this.pnlScroll.Controls.Add(this.dtpNascimento);
            this.pnlScroll.Controls.Add(this.lblSexo);
            this.pnlScroll.Controls.Add(this.cmbSexo);
            this.pnlScroll.Controls.Add(this.lblNivel);
            this.pnlScroll.Controls.Add(this.cmbNivel);
            this.pnlScroll.Controls.Add(this.lblDiagnostico);
            this.pnlScroll.Controls.Add(this.dtpDiagnostico);
            this.pnlScroll.Controls.Add(this.lblCIPTEA);
            this.pnlScroll.Controls.Add(this.txtCIPTEA);
            this.pnlScroll.Controls.Add(this.lblCidade);
            this.pnlScroll.Controls.Add(this.cmbCidade);
            this.pnlScroll.Controls.Add(this.lblTelefone);
            this.pnlScroll.Controls.Add(this.txtTelefone);
            this.pnlScroll.Controls.Add(this.lblEmail);
            this.pnlScroll.Controls.Add(this.txtEmail);
            this.pnlScroll.Controls.Add(this.lblSecaoResp);
            this.pnlScroll.Controls.Add(this.lblNomeResp);
            this.pnlScroll.Controls.Add(this.txtNomeResp);
            this.pnlScroll.Controls.Add(this.lblCPFResp);
            this.pnlScroll.Controls.Add(this.txtCPFResp);
            this.pnlScroll.Controls.Add(this.lblTelResp);
            this.pnlScroll.Controls.Add(this.txtTelResp);
            this.pnlScroll.Controls.Add(this.lblObs);
            this.pnlScroll.Controls.Add(this.txtObs);
            this.pnlScroll.Controls.Add(this.chkAtivo);

            // ── PacienteForm ──────────────────────────────────────────────────
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(820, 648);
            this.Controls.Add(this.pnlScroll);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlCabecalho);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PacienteForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Paciente";

            this.pnlCabecalho.ResumeLayout(false);
            this.pnlCabecalho.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlScroll.ResumeLayout(false);
            this.pnlScroll.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel          pnlCabecalho;
        private System.Windows.Forms.Label          lblFormTitulo;
        private System.Windows.Forms.Panel          pnlFooter;
        private System.Windows.Forms.Panel          pnlFooterBorder;
        private System.Windows.Forms.Button         btnSalvar;
        private System.Windows.Forms.Button         btnCancelar;
        private System.Windows.Forms.Panel          pnlScroll;
        private System.Windows.Forms.Label          lblNome;
        private System.Windows.Forms.TextBox        txtNome;
        private System.Windows.Forms.Label          lblNomeSocial;
        private System.Windows.Forms.TextBox        txtNomeSocial;
        private System.Windows.Forms.Label          lblCPF;
        private System.Windows.Forms.MaskedTextBox  txtCPF;
        private System.Windows.Forms.Label          lblNascimento;
        private System.Windows.Forms.DateTimePicker dtpNascimento;
        private System.Windows.Forms.Label          lblSexo;
        private System.Windows.Forms.ComboBox       cmbSexo;
        private System.Windows.Forms.Label          lblNivel;
        private System.Windows.Forms.ComboBox       cmbNivel;
        private System.Windows.Forms.Label          lblDiagnostico;
        private System.Windows.Forms.DateTimePicker dtpDiagnostico;
        private System.Windows.Forms.Label          lblCIPTEA;
        private System.Windows.Forms.TextBox        txtCIPTEA;
        private System.Windows.Forms.Label          lblCidade;
        private System.Windows.Forms.ComboBox       cmbCidade;
        private System.Windows.Forms.Label          lblTelefone;
        private System.Windows.Forms.MaskedTextBox  txtTelefone;
        private System.Windows.Forms.Label          lblEmail;
        private System.Windows.Forms.TextBox        txtEmail;
        private System.Windows.Forms.Label          lblSecaoResp;
        private System.Windows.Forms.Label          lblNomeResp;
        private System.Windows.Forms.TextBox        txtNomeResp;
        private System.Windows.Forms.Label          lblCPFResp;
        private System.Windows.Forms.MaskedTextBox  txtCPFResp;
        private System.Windows.Forms.Label          lblTelResp;
        private System.Windows.Forms.MaskedTextBox  txtTelResp;
        private System.Windows.Forms.Label          lblObs;
        private System.Windows.Forms.TextBox        txtObs;
        private System.Windows.Forms.CheckBox       chkAtivo;
    }
}
