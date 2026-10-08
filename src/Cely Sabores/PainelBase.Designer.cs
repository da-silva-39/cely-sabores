namespace Cely_Sabores
{
    partial class PainelBase
    {
        private System.Windows.Forms.Panel _cabecalho;
        private System.Windows.Forms.FlowLayoutPanel _acoes;
        private System.Windows.Forms.Label _titulo;
        private System.Windows.Forms.Label _status;

        // Campo (e nao propriedade) para os ficheiros Designer dos paineis
        // derivados lhe poderem acrescentar controlos: e assim que o designer
        // do Visual Studio referencia contentores herdados.
        protected System.Windows.Forms.Panel _conteudo;

        private void InitializeComponent()
        {
            this._cabecalho = new System.Windows.Forms.Panel();
            this._titulo = new System.Windows.Forms.Label();
            this._status = new System.Windows.Forms.Label();
            this._acoes = new System.Windows.Forms.FlowLayoutPanel();
            this._conteudo = new System.Windows.Forms.Panel();
            this._cabecalho.SuspendLayout();
            this.SuspendLayout();
            //
            // _cabecalho
            //
            this._cabecalho.Controls.Add(this._titulo);
            this._cabecalho.Controls.Add(this._status);
            this._cabecalho.Controls.Add(this._acoes);
            this._cabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this._cabecalho.Location = new System.Drawing.Point(0, 0);
            this._cabecalho.Name = "_cabecalho";
            this._cabecalho.Size = new System.Drawing.Size(940, 78);
            this._cabecalho.TabIndex = 0;
            //
            // _titulo
            //
            this._titulo.AutoSize = true;
            this._titulo.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this._titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this._titulo.Location = new System.Drawing.Point(0, 0);
            this._titulo.Name = "_titulo";
            this._titulo.Size = new System.Drawing.Size(400, 32);
            this._titulo.TabIndex = 0;
            this._titulo.Text = "Painel";
            //
            // _status
            //
            this._status.AutoSize = true;
            this._status.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(118)))), ((int)(((byte)(106)))));
            this._status.Location = new System.Drawing.Point(0, 30);
            this._status.Name = "_status";
            this._status.Size = new System.Drawing.Size(400, 19);
            this._status.TabIndex = 1;
            this._status.Text = "";
            //
            // _acoes
            //
            this._acoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this._acoes.Dock = System.Windows.Forms.DockStyle.Right;
            this._acoes.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this._acoes.Location = new System.Drawing.Point(380, 0);
            this._acoes.Name = "_acoes";
            this._acoes.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this._acoes.Size = new System.Drawing.Size(560, 78);
            this._acoes.TabIndex = 2;
            this._acoes.WrapContents = true;
            //
            // _conteudo
            //
            this._conteudo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this._conteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._conteudo.Location = new System.Drawing.Point(0, 78);
            this._conteudo.Name = "_conteudo";
            this._conteudo.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this._conteudo.Size = new System.Drawing.Size(940, 582);
            this._conteudo.TabIndex = 1;
            //
            // PainelBase
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.Controls.Add(this._conteudo);
            this.Controls.Add(this._cabecalho);
            this.Name = "PainelBase";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.Size = new System.Drawing.Size(940, 660);
            this._cabecalho.ResumeLayout(false);
            this._cabecalho.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
