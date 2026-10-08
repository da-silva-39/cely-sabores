namespace Cely_Sabores
{
    partial class PainelFuncionarios
    {
        private System.Windows.Forms.FlowLayoutPanel filtros;
        private System.Windows.Forms.CheckBox chkInactivos;
        private System.Windows.Forms.DataGridView dgvFuncionarios;

        private void InitializeComponent()
        {
            this.filtros = new System.Windows.Forms.FlowLayoutPanel();
            this.chkInactivos = new System.Windows.Forms.CheckBox();
            this.dgvFuncionarios = new System.Windows.Forms.DataGridView();
            this.filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionarios)).BeginInit();
            //
            // filtros
            //
            this.filtros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.filtros.Controls.Add(this.chkInactivos);
            this.filtros.Dock = System.Windows.Forms.DockStyle.Top;
            this.filtros.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.filtros.Location = new System.Drawing.Point(0, 0);
            this.filtros.Name = "filtros";
            this.filtros.Size = new System.Drawing.Size(940, 42);
            this.filtros.TabIndex = 0;
            this.filtros.WrapContents = false;
            //
            // chkInactivos
            //
            this.chkInactivos.AutoSize = true;
            this.chkInactivos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkInactivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.chkInactivos.Location = new System.Drawing.Point(0, 7);
            this.chkInactivos.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.chkInactivos.Name = "chkInactivos";
            this.chkInactivos.Size = new System.Drawing.Size(127, 22);
            this.chkInactivos.TabIndex = 0;
            this.chkInactivos.Text = "Mostrar inactivos";
            this.chkInactivos.UseVisualStyleBackColor = true;
            //
            // dgvFuncionarios
            //
            this.dgvFuncionarios.AllowUserToAddRows = false;
            this.dgvFuncionarios.AllowUserToDeleteRows = false;
            this.dgvFuncionarios.AllowUserToResizeRows = false;
            this.dgvFuncionarios.AutoGenerateColumns = false;
            this.dgvFuncionarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFuncionarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvFuncionarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFuncionarios.ColumnHeadersHeight = 34;
            this.dgvFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFuncionarios.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvFuncionarios.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvFuncionarios.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvFuncionarios.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvFuncionarios.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvFuncionarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 28F,
                Name = "Nome",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Nome"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 18F,
                Name = "Cargo",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Cargo"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 14F,
                Name = "Telefone",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Telefone"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 22F,
                Name = "E-mail",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "E-mail"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 10F,
                Name = "Desde",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Desde"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 8F,
                Name = "Ativo",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Ativo"
            }});
            this.dgvFuncionarios.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvFuncionarios.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvFuncionarios.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvFuncionarios.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvFuncionarios.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvFuncionarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFuncionarios.EnableHeadersVisualStyles = false;
            this.dgvFuncionarios.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvFuncionarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvFuncionarios.MultiSelect = false;
            this.dgvFuncionarios.Name = "dgvFuncionarios";
            this.dgvFuncionarios.ReadOnly = true;
            this.dgvFuncionarios.RowHeadersVisible = false;
            this.dgvFuncionarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFuncionarios.Size = new System.Drawing.Size(940, 540);
            this.dgvFuncionarios.TabIndex = 1;
            //
            // PainelFuncionarios
            //
            this._conteudo.Controls.Add(this.dgvFuncionarios);
            this._conteudo.Controls.Add(this.filtros);
            this.Name = "PainelFuncionarios";
            this.Size = new System.Drawing.Size(940, 660);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionarios)).EndInit();
            this.filtros.ResumeLayout(false);
            this.filtros.PerformLayout();
        }
    }
}
