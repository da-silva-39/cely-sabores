namespace Cely_Sabores
{
    partial class PainelCardapio
    {
        private System.Windows.Forms.FlowLayoutPanel filtros;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.CheckBox chkDisponiveis;
        private System.Windows.Forms.DataGridView dgvCardapio;

        private void InitializeComponent()
        {
            this.filtros = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.chkDisponiveis = new System.Windows.Forms.CheckBox();
            this.dgvCardapio = new System.Windows.Forms.DataGridView();
            this.filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardapio)).BeginInit();
            //
            // filtros
            //
            this.filtros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.filtros.Controls.Add(this.cmbCategoria);
            this.filtros.Controls.Add(this.chkDisponiveis);
            this.filtros.Dock = System.Windows.Forms.DockStyle.Top;
            this.filtros.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.filtros.Location = new System.Drawing.Point(0, 0);
            this.filtros.Name = "filtros";
            this.filtros.Size = new System.Drawing.Size(940, 42);
            this.filtros.TabIndex = 0;
            this.filtros.WrapContents = false;
            //
            // cmbCategoria
            //
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(0, 0);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(190, 28);
            this.cmbCategoria.TabIndex = 0;
            //
            // chkDisponiveis
            //
            this.chkDisponiveis.AutoSize = true;
            this.chkDisponiveis.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkDisponiveis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(118)))), ((int)(((byte)(106)))));
            this.chkDisponiveis.Location = new System.Drawing.Point(200, 7);
            this.chkDisponiveis.Margin = new System.Windows.Forms.Padding(0, 7, 12, 0);
            this.chkDisponiveis.Name = "chkDisponiveis";
            this.chkDisponiveis.Size = new System.Drawing.Size(108, 22);
            this.chkDisponiveis.TabIndex = 1;
            this.chkDisponiveis.Text = "Só disponíveis";
            this.chkDisponiveis.UseVisualStyleBackColor = true;
            //
            // dgvCardapio
            //
            this.dgvCardapio.AllowUserToAddRows = false;
            this.dgvCardapio.AllowUserToDeleteRows = false;
            this.dgvCardapio.AllowUserToResizeRows = false;
            this.dgvCardapio.AutoGenerateColumns = false;
            this.dgvCardapio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCardapio.BackgroundColor = System.Drawing.Color.White;
            this.dgvCardapio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCardapio.ColumnHeadersHeight = 34;
            this.dgvCardapio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCardapio.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvCardapio.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvCardapio.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCardapio.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvCardapio.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCardapio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 26F,
                Name = "Prato",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Prato"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 18F,
                Name = "Categoria",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Categoria"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 14F,
                Name = "Preço",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Preço"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 30F,
                Name = "Descrição",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Descrição"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 12F,
                Name = "Estado",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Estado"
            }});
            this.dgvCardapio.Columns[2].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvCardapio.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvCardapio.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvCardapio.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvCardapio.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvCardapio.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvCardapio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCardapio.EnableHeadersVisualStyles = false;
            this.dgvCardapio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvCardapio.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvCardapio.MultiSelect = false;
            this.dgvCardapio.Name = "dgvCardapio";
            this.dgvCardapio.ReadOnly = true;
            this.dgvCardapio.RowHeadersVisible = false;
            this.dgvCardapio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCardapio.Size = new System.Drawing.Size(940, 540);
            this.dgvCardapio.TabIndex = 1;
            //
            // PainelCardapio
            //
            this._conteudo.Controls.Add(this.dgvCardapio);
            this._conteudo.Controls.Add(this.filtros);
            this.Name = "PainelCardapio";
            this.Size = new System.Drawing.Size(940, 660);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardapio)).EndInit();
            this.filtros.ResumeLayout(false);
            this.filtros.PerformLayout();
        }
    }
}
