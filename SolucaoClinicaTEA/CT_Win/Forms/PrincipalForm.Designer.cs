namespace CT_Win.Forms
{
    partial class PrincipalForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlCabecalho       = new System.Windows.Forms.Panel();
            this.lblUsuarioLogado   = new System.Windows.Forms.Label();
            this.lblHeaderSubtitulo = new System.Windows.Forms.Label();
            this.lblHeaderTitulo    = new System.Windows.Forms.Label();
            this.pnlConteudo        = new System.Windows.Forms.Panel();

            this.pnlCabecalho.SuspendLayout();
            this.SuspendLayout();

            // pnlCabecalho
            this.pnlCabecalho.Controls.Add(this.lblUsuarioLogado);
            this.pnlCabecalho.Controls.Add(this.lblHeaderSubtitulo);
            this.pnlCabecalho.Controls.Add(this.lblHeaderTitulo);
            this.pnlCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecalho.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecalho.Name = "pnlCabecalho";
            this.pnlCabecalho.Size = new System.Drawing.Size(1119, 80);
            this.pnlCabecalho.TabIndex = 0;

            this.lblUsuarioLogado.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.lblUsuarioLogado.AutoSize = true;
            this.lblUsuarioLogado.Location = new System.Drawing.Point(800, 20);
            this.lblUsuarioLogado.Name = "lblUsuarioLogado";
            this.lblUsuarioLogado.TabIndex = 2;
            this.lblUsuarioLogado.Text = "Usuário";
            this.lblUsuarioLogado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblHeaderSubtitulo.AutoSize = true;
            this.lblHeaderSubtitulo.Location = new System.Drawing.Point(24, 40);
            this.lblHeaderSubtitulo.Name = "lblHeaderSubtitulo";
            this.lblHeaderSubtitulo.TabIndex = 1;
            this.lblHeaderSubtitulo.Text = "Sistema de gestão clínica multidisciplinar";

            this.lblHeaderTitulo.AutoSize = true;
            this.lblHeaderTitulo.Location = new System.Drawing.Point(24, 12);
            this.lblHeaderTitulo.Name = "lblHeaderTitulo";
            this.lblHeaderTitulo.TabIndex = 0;
            this.lblHeaderTitulo.Text = "Clínica Acolher TEA";

            // pnlConteudo (Fill)
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Location = new System.Drawing.Point(0, 80);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Size = new System.Drawing.Size(1119, 650);
            this.pnlConteudo.TabIndex = 1;

            // PrincipalForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1119, 730);
            this.Controls.Add(this.pnlConteudo);
            this.Controls.Add(this.pnlCabecalho);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "PrincipalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clínica Acolher TEA — Sistema";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.pnlCabecalho.ResumeLayout(false);
            this.pnlCabecalho.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlCabecalho;
        private System.Windows.Forms.Label lblUsuarioLogado;
        private System.Windows.Forms.Label lblHeaderSubtitulo;
        private System.Windows.Forms.Label lblHeaderTitulo;
        private System.Windows.Forms.Panel pnlConteudo;
    }
}
