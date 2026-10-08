namespace Cely_Sabores
{
    partial class DialogoIngrediente
    {
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblUnidade;
        private System.Windows.Forms.ComboBox cmbUnidade;
        private System.Windows.Forms.Label lblMinima;
        private System.Windows.Forms.NumericUpDown numMinima;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.NumericUpDown numPreco;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        private void InitializeComponent()
        {
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblUnidade = new System.Windows.Forms.Label();
            this.cmbUnidade = new System.Windows.Forms.ComboBox();
            this.lblMinima = new System.Windows.Forms.Label();
            this.numMinima = new System.Windows.Forms.NumericUpDown();
            this.lblPreco = new System.Windows.Forms.Label();
            this.numPreco = new System.Windows.Forms.NumericUpDown();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblNome
            //
            this.lblNome.AutoSize = true;
            this.lblNome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblNome.Location = new System.Drawing.Point(20, 28);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(42, 19);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome";
            //
            // txtNome
            //
            this.txtNome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNome.Location = new System.Drawing.Point(150, 24);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(250, 26);
            this.txtNome.TabIndex = 1;
            //
            // lblUnidade
            //
            this.lblUnidade.AutoSize = true;
            this.lblUnidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblUnidade.Location = new System.Drawing.Point(20, 68);
            this.lblUnidade.Name = "lblUnidade";
            this.lblUnidade.Size = new System.Drawing.Size(56, 19);
            this.lblUnidade.TabIndex = 2;
            this.lblUnidade.Text = "Unidade";
            //
            // cmbUnidade
            //
            this.cmbUnidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidade.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbUnidade.FormattingEnabled = true;
            this.cmbUnidade.Items.AddRange(new object[] {
            "kg",
            "g",
            "L",
            "ml",
            "un",
            "dz"});
            this.cmbUnidade.Location = new System.Drawing.Point(150, 64);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.SelectedIndex = 0;
            this.cmbUnidade.Size = new System.Drawing.Size(120, 28);
            this.cmbUnidade.TabIndex = 3;
            //
            // lblMinima
            //
            this.lblMinima.AutoSize = true;
            this.lblMinima.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblMinima.Location = new System.Drawing.Point(20, 110);
            this.lblMinima.Name = "lblMinima";
            this.lblMinima.Size = new System.Drawing.Size(103, 19);
            this.lblMinima.TabIndex = 4;
            this.lblMinima.Text = "Estoque mínimo";
            //
            // numMinima
            //
            this.numMinima.DecimalPlaces = 3;
            this.numMinima.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numMinima.Location = new System.Drawing.Point(150, 106);
            this.numMinima.Maximum = new decimal(new int[] { 999999, 0, 0, 196608 });
            this.numMinima.Name = "numMinima";
            this.numMinima.Size = new System.Drawing.Size(120, 26);
            this.numMinima.TabIndex = 5;
            //
            // lblPreco
            //
            this.lblPreco.AutoSize = true;
            this.lblPreco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblPreco.Location = new System.Drawing.Point(20, 152);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(94, 19);
            this.lblPreco.TabIndex = 6;
            this.lblPreco.Text = "Preço de custo";
            //
            // numPreco
            //
            this.numPreco.DecimalPlaces = 2;
            this.numPreco.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPreco.Location = new System.Drawing.Point(150, 148);
            this.numPreco.Maximum = new decimal(new int[] { 9999999, 0, 0, 131072 });
            this.numPreco.Name = "numPreco";
            this.numPreco.Size = new System.Drawing.Size(120, 26);
            this.numPreco.TabIndex = 7;
            //
            // chkAtivo
            //
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.chkAtivo.Location = new System.Drawing.Point(150, 190);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(113, 18);
            this.chkAtivo.TabIndex = 8;
            this.chkAtivo.Text = "Ingrediente activo";
            this.chkAtivo.Visible = false;
            //
            // lblSaldo
            //
            this.lblSaldo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(118)))), ((int)(((byte)(106)))));
            this.lblSaldo.Location = new System.Drawing.Point(20, 224);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(380, 40);
            this.lblSaldo.TabIndex = 9;
            //
            // btnGuardar
            //
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(170, 282);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 34);
            this.btnGuardar.TabIndex = 10;
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
            this.btnCancelar.Location = new System.Drawing.Point(290, 282);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 34);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            //
            // DialogoIngrediente
            //
            this.AcceptButton = this.btnGuardar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(440, 330);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.chkAtivo);
            this.Controls.Add(this.numPreco);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.numMinima);
            this.Controls.Add(this.lblMinima);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.lblUnidade);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogoIngrediente";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Novo ingrediente";
            this.ResumeLayout(false);
        }
    }
}
