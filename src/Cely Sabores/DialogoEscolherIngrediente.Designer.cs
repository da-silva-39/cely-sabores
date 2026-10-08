namespace Cely_Sabores
{
    partial class DialogoEscolherIngrediente
    {
        private System.Windows.Forms.Label lblIngrediente;
        private System.Windows.Forms.ComboBox cmbIngrediente;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;

        private void InitializeComponent()
        {
            this.lblIngrediente = new System.Windows.Forms.Label();
            this.cmbIngrediente = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblIngrediente
            //
            this.lblIngrediente.AutoSize = true;
            this.lblIngrediente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblIngrediente.Location = new System.Drawing.Point(20, 30);
            this.lblIngrediente.Name = "lblIngrediente";
            this.lblIngrediente.Size = new System.Drawing.Size(75, 19);
            this.lblIngrediente.TabIndex = 0;
            this.lblIngrediente.Text = "Ingrediente";
            //
            // cmbIngrediente
            //
            this.cmbIngrediente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIngrediente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbIngrediente.FormattingEnabled = true;
            this.cmbIngrediente.Location = new System.Drawing.Point(150, 26);
            this.cmbIngrediente.Name = "cmbIngrediente";
            this.cmbIngrediente.Size = new System.Drawing.Size(220, 28);
            this.cmbIngrediente.TabIndex = 1;
            //
            // btnOk
            //
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(170, 130);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 34);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Guardar";
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
            this.btnCancelar.Location = new System.Drawing.Point(280, 130);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 34);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            //
            // DialogoEscolherIngrediente
            //
            this.AcceptButton = this.btnOk;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(400, 190);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbIngrediente);
            this.Controls.Add(this.lblIngrediente);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogoEscolherIngrediente";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adicionar ingrediente à receita";
            this.ResumeLayout(false);
        }
    }
}
