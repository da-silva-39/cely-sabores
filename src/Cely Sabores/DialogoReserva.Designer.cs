namespace Cely_Sabores
{
    partial class DialogoReserva
    {
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.ComboBox cmbMesa;
        private System.Windows.Forms.Label lblDataHora;
        private System.Windows.Forms.DateTimePicker dtDataHora;
        private System.Windows.Forms.Label lblPessoas;
        private System.Windows.Forms.NumericUpDown numPessoas;
        private System.Windows.Forms.Label lblObservacoes;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        private void InitializeComponent()
        {
            this.lblCliente = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblMesa = new System.Windows.Forms.Label();
            this.cmbMesa = new System.Windows.Forms.ComboBox();
            this.lblDataHora = new System.Windows.Forms.Label();
            this.dtDataHora = new System.Windows.Forms.DateTimePicker();
            this.lblPessoas = new System.Windows.Forms.Label();
            this.numPessoas = new System.Windows.Forms.NumericUpDown();
            this.lblObservacoes = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPessoas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblCliente.Location = new System.Drawing.Point(20, 26);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(72, 28);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(150, 22);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(290, 36);
            this.cmbCliente.TabIndex = 1;
            // 
            // lblMesa
            // 
            this.lblMesa.AutoSize = true;
            this.lblMesa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblMesa.Location = new System.Drawing.Point(20, 68);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(58, 28);
            this.lblMesa.TabIndex = 2;
            this.lblMesa.Text = "Mesa";
            // 
            // cmbMesa
            // 
            this.cmbMesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMesa.FormattingEnabled = true;
            this.cmbMesa.Location = new System.Drawing.Point(150, 64);
            this.cmbMesa.Name = "cmbMesa";
            this.cmbMesa.Size = new System.Drawing.Size(290, 36);
            this.cmbMesa.TabIndex = 3;
            // 
            // lblDataHora
            // 
            this.lblDataHora.AutoSize = true;
            this.lblDataHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblDataHora.Location = new System.Drawing.Point(20, 110);
            this.lblDataHora.Name = "lblDataHora";
            this.lblDataHora.Size = new System.Drawing.Size(113, 28);
            this.lblDataHora.TabIndex = 4;
            this.lblDataHora.Text = "Data e hora";
            // 
            // dtDataHora
            // 
            this.dtDataHora.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtDataHora.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtDataHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDataHora.Location = new System.Drawing.Point(150, 106);
            this.dtDataHora.Name = "dtDataHora";
            this.dtDataHora.ShowUpDown = true;
            this.dtDataHora.Size = new System.Drawing.Size(200, 34);
            this.dtDataHora.TabIndex = 5;
            // 
            // lblPessoas
            // 
            this.lblPessoas.AutoSize = true;
            this.lblPessoas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblPessoas.Location = new System.Drawing.Point(20, 152);
            this.lblPessoas.Name = "lblPessoas";
            this.lblPessoas.Size = new System.Drawing.Size(78, 28);
            this.lblPessoas.TabIndex = 6;
            this.lblPessoas.Text = "Pessoas";
            // 
            // numPessoas
            // 
            this.numPessoas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPessoas.Location = new System.Drawing.Point(150, 148);
            this.numPessoas.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numPessoas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPessoas.Name = "numPessoas";
            this.numPessoas.Size = new System.Drawing.Size(80, 34);
            this.numPessoas.TabIndex = 7;
            this.numPessoas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblObservacoes
            // 
            this.lblObservacoes.AutoSize = true;
            this.lblObservacoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblObservacoes.Location = new System.Drawing.Point(20, 194);
            this.lblObservacoes.Name = "lblObservacoes";
            this.lblObservacoes.Size = new System.Drawing.Size(123, 28);
            this.lblObservacoes.TabIndex = 8;
            this.lblObservacoes.Text = "Observações";
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Location = new System.Drawing.Point(150, 190);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacoes.Size = new System.Drawing.Size(290, 50);
            this.txtObservacoes.TabIndex = 9;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(130, 265);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 34);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
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
            this.btnCancelar.Location = new System.Drawing.Point(240, 265);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 34);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // DialogoReserva
            // 
            this.AcceptButton = this.btnGuardar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(557, 320);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.lblObservacoes);
            this.Controls.Add(this.numPessoas);
            this.Controls.Add(this.lblPessoas);
            this.Controls.Add(this.dtDataHora);
            this.Controls.Add(this.lblDataHora);
            this.Controls.Add(this.cmbMesa);
            this.Controls.Add(this.lblMesa);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.lblCliente);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogoReserva";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nova reserva";
            ((System.ComponentModel.ISupportInitialize)(this.numPessoas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
