namespace Cely_Sabores
{
    partial class DialogoAbrirPedido
    {
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblValorRecebido;
        private System.Windows.Forms.NumericUpDown numRecebido;
        private System.Windows.Forms.Button btnExacto;
        private System.Windows.Forms.Label lblTroco;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;

        private void InitializeComponent()
        {
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblValorRecebido = new System.Windows.Forms.Label();
            this.numRecebido = new System.Windows.Forms.NumericUpDown();
            this.btnExacto = new System.Windows.Forms.Button();
            this.lblTroco = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTotal
            //
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblTotal.Location = new System.Drawing.Point(20, 22);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(120, 24);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total a pagar:";
            //
            // lblValorRecebido
            //
            this.lblValorRecebido.AutoSize = true;
            this.lblValorRecebido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblValorRecebido.Location = new System.Drawing.Point(24, 72);
            this.lblValorRecebido.Name = "lblValorRecebido";
            this.lblValorRecebido.Size = new System.Drawing.Size(93, 19);
            this.lblValorRecebido.TabIndex = 1;
            this.lblValorRecebido.Text = "Valor recebido";
            //
            // numRecebido
            //
            this.numRecebido.DecimalPlaces = 2;
            this.numRecebido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numRecebido.Location = new System.Drawing.Point(150, 68);
            this.numRecebido.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numRecebido.Name = "numRecebido";
            this.numRecebido.Size = new System.Drawing.Size(140, 26);
            this.numRecebido.TabIndex = 2;
            //
            // btnExacto
            //
            this.btnExacto.BackColor = System.Drawing.Color.White;
            this.btnExacto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExacto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.btnExacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExacto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExacto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.btnExacto.Location = new System.Drawing.Point(300, 68);
            this.btnExacto.Name = "btnExacto";
            this.btnExacto.Size = new System.Drawing.Size(110, 32);
            this.btnExacto.TabIndex = 3;
            this.btnExacto.Text = "Valor exacto";
            //
            // lblTroco
            //
            this.lblTroco.AutoSize = true;
            this.lblTroco.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTroco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblTroco.Location = new System.Drawing.Point(20, 110);
            this.lblTroco.Name = "lblTroco";
            this.lblTroco.Size = new System.Drawing.Size(135, 24);
            this.lblTroco.TabIndex = 4;
            //
            // btnConfirmar
            //
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(160, 180);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(120, 36);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "Confirmar";
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
            this.btnCancelar.Location = new System.Drawing.Point(290, 180);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 36);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            //
            // DialogoPagamento
            //
            this.AcceptButton = this.btnConfirmar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(420, 250);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblTroco);
            this.Controls.Add(this.btnExacto);
            this.Controls.Add(this.numRecebido);
            this.Controls.Add(this.lblValorRecebido);
            this.Controls.Add(this.lblTotal);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogoPagamento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pagamento do pedido";
            this.ResumeLayout(false);
        }
    }
}
