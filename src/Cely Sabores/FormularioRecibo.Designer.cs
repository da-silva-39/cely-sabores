namespace Cely_Sabores
{
    partial class FormularioRecibo
    {
        private System.Windows.Forms.Panel papel;
        private System.Windows.Forms.PictureBox previa;
        private System.Windows.Forms.FlowLayoutPanel barra;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label ajuda;

        private void InitializeComponent()
        {
            this.papel = new System.Windows.Forms.Panel();
            this.previa = new System.Windows.Forms.PictureBox();
            this.barra = new System.Windows.Forms.FlowLayoutPanel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.ajuda = new System.Windows.Forms.Label();
            this.papel.SuspendLayout();
            this.barra.SuspendLayout();
            //
            // papel
            //
            this.papel.AutoScroll = true;
            this.papel.BackColor = System.Drawing.Color.White;
            this.papel.Controls.Add(this.previa);
            this.papel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.papel.Location = new System.Drawing.Point(0, 40);
            this.papel.Name = "papel";
            this.papel.Padding = new System.Windows.Forms.Padding(14);
            this.papel.Size = new System.Drawing.Size(520, 598);
            this.papel.TabIndex = 0;
            //
            // previa
            //
            this.previa.BackColor = System.Drawing.Color.White;
            this.previa.Dock = System.Windows.Forms.DockStyle.Top;
            this.previa.Location = new System.Drawing.Point(0, 0);
            this.previa.Name = "previa";
            this.previa.Size = new System.Drawing.Size(420, 30);
            this.previa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.previa.TabIndex = 0;
            //
            // barra
            //
            this.barra.BackColor = System.Drawing.Color.White;
            this.barra.Controls.Add(this.btnFechar);
            this.barra.Controls.Add(this.btnImprimir);
            this.barra.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barra.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.barra.Location = new System.Drawing.Point(0, 638);
            this.barra.Name = "barra";
            this.barra.Padding = new System.Windows.Forms.Padding(12, 12, 12, 0);
            this.barra.Size = new System.Drawing.Size(520, 62);
            this.barra.TabIndex = 1;
            this.barra.WrapContents = false;
            //
            // btnImprimir
            //
            this.btnImprimir.AutoSize = true;
            this.btnImprimir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(0, 0);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnImprimir.MinimumSize = new System.Drawing.Size(96, 34);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnImprimir.Size = new System.Drawing.Size(96, 34);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.Text = "Imprimir";
            //
            // btnFechar
            //
            this.btnFechar.AutoSize = true;
            this.btnFechar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFechar.BackColor = System.Drawing.Color.White;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.btnFechar.FlatAppearance.BorderSize = 1;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnFechar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.btnFechar.Location = new System.Drawing.Point(0, 0);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnFechar.MinimumSize = new System.Drawing.Size(96, 34);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnFechar.Size = new System.Drawing.Size(96, 34);
            this.btnFechar.TabIndex = 1;
            this.btnFechar.Text = "Fechar";
            //
            // ajuda
            //
            this.ajuda.Dock = System.Windows.Forms.DockStyle.Top;
            this.ajuda.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ajuda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(118)))), ((int)(((byte)(106)))));
            this.ajuda.Location = new System.Drawing.Point(0, 0);
            this.ajuda.Name = "ajuda";
            this.ajuda.Padding = new System.Windows.Forms.Padding(18, 12, 18, 0);
            this.ajuda.Size = new System.Drawing.Size(520, 40);
            this.ajuda.TabIndex = 2;
            this.ajuda.Text = "O recibo não indica a forma de pagamento, apenas os valores registados.";
            //
            // FormularioRecibo
            //
            this.Controls.Add(this.papel);
            this.Controls.Add(this.barra);
            this.Controls.Add(this.ajuda);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(520, 700);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(420, 460);
            this.Name = "FormularioRecibo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recibo";
            this.papel.ResumeLayout(false);
            this.barra.ResumeLayout(false);
            this.barra.PerformLayout();
        }
    }
}
