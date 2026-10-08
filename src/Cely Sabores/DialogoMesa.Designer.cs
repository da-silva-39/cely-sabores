namespace Cely_Sabores
{
    partial class DialogoMesa
    {
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.NumericUpDown numNumero;
        private System.Windows.Forms.Label lblCapacidade;
        private System.Windows.Forms.NumericUpDown numCapacidade;
        private System.Windows.Forms.Label lblObservacoes;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        private void InitializeComponent()
        {
            this.lblNumero = new System.Windows.Forms.Label();
            this.numNumero = new System.Windows.Forms.NumericUpDown();
            this.lblCapacidade = new System.Windows.Forms.Label();
            this.numCapacidade = new System.Windows.Forms.NumericUpDown();
            this.lblObservacoes = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblNumero
            //
            this.lblNumero.AutoSize = true;
            this.lblNumero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblNumero.Location = new System.Drawing.Point(20, 26);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(58, 19);
            this.lblNumero.TabIndex = 0;
            this.lblNumero.Text = "Número";
            //
            // numNumero
            //
            this.numNumero.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numNumero.Location = new System.Drawing.Point(140, 22);
            this.numNumero.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            this.numNumero.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numNumero.Name = "numNumero";
            this.numNumero.Size = new System.Drawing.Size(90, 26);
            this.numNumero.TabIndex = 1;
            //
            // lblCapacidade
            //
            this.lblCapacidade.AutoSize = true;
            this.lblCapacidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblCapacidade.Location = new System.Drawing.Point(20, 68);
            this.lblCapacidade.Name = "lblCapacidade";
            this.lblCapacidade.Size = new System.Drawing.Size(80, 19);
            this.lblCapacidade.TabIndex = 2;
            this.lblCapacidade.Text = "Capacidade";
            //
            // numCapacidade
            //
            this.numCapacidade.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numCapacidade.Location = new System.Drawing.Point(140, 64);
            this.numCapacidade.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numCapacidade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numCapacidade.Name = "numCapacidade";
            this.numCapacidade.Size = new System.Drawing.Size(90, 26);
            this.numCapacidade.TabIndex = 3;
            this.numCapacidade.Value = new decimal(new int[] { 4, 0, 0, 0 });
            //
            // lblObservacoes
            //
            this.lblObservacoes.AutoSize = true;
            this.lblObservacoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblObservacoes.Location = new System.Drawing.Point(20, 110);
            this.lblObservacoes.Name = "lblObservacoes";
            this.lblObservacoes.Size = new System.Drawing.Size(84, 19);
            this.lblObservacoes.TabIndex = 4;
            this.lblObservacoes.Text = "Observações";
            //
            // txtObservacoes
            //
            this.txtObservacoes.Location = new System.Drawing.Point(140, 106);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacoes.Size = new System.Drawing.Size(230, 50);
            this.txtObservacoes.TabIndex = 5;
            //
            // btnGuardar
            //
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(160, 180);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 34);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            //
            // btnCancelar
            //
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.btnCancelar.Location = new System.Drawing.Point(270, 180);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 34);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            //
            // DialogoMesa
            //
            this.AcceptButton = this.btnGuardar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(400, 240);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.lblObservacoes);
            this.Controls.Add(this.numCapacidade);
            this.Controls.Add(this.lblCapacidade);
            this.Controls.Add(this.numNumero);
            this.Controls.Add(this.lblNumero);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogoMesa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nova mesa";
            this.ResumeLayout(false);
        }
    }
}
