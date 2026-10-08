namespace Cely_Sabores
{
    partial class PainelEstoque
    {
        private System.Windows.Forms.FlowLayoutPanel filtros;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.CheckBox chkInativos;
        private System.Windows.Forms.DataGridView dgvIngredientes;

        private void InitializeComponent()
        {
            this.filtros = new System.Windows.Forms.FlowLayoutPanel();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.chkInativos = new System.Windows.Forms.CheckBox();
            this.dgvIngredientes = new System.Windows.Forms.DataGridView();
            this.filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).BeginInit();
            //
            // filtros
            //
            this.filtros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.filtros.Controls.Add(this.txtPesquisa);
            this.filtros.Controls.Add(this.chkInativos);
            this.filtros.Dock = System.Windows.Forms.DockStyle.Top;
            this.filtros.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.filtros.Location = new System.Drawing.Point(0, 0);
            this.filtros.Name = "filtros";
            this.filtros.Size = new System.Drawing.Size(940, 42);
            this.filtros.TabIndex = 0;
            this.filtros.WrapContents = false;
            //
            // txtPesquisa
            //
            this.txtPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPesquisa.Location = new System.Drawing.Point(0, 7);
            this.txtPesquisa.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(260, 26);
            this.txtPesquisa.TabIndex = 0;
            //
            // chkInativos
            //
            this.chkInativos.AutoSize = true;
            this.chkInativos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkInativos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.chkInativos.Location = new System.Drawing.Point(270, 7);
            this.chkInativos.Margin = new System.Windows.Forms.Padding(4, 8, 0, 0);
            this.chkInativos.Name = "chkInativos";
            this.chkInativos.Size = new System.Drawing.Size(127, 22);
            this.chkInativos.TabIndex = 1;
            this.chkInativos.Text = "Mostrar inactivos";
            this.chkInativos.UseVisualStyleBackColor = true;
            //
            // dgvIngredientes
            //
            this.dgvIngredientes.AllowUserToAddRows = false;
            this.dgvIngredientes.AllowUserToDeleteRows = false;
            this.dgvIngredientes.AllowUserToResizeRows = false;
            this.dgvIngredientes.AutoGenerateColumns = false;
            this.dgvIngredientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngredientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvIngredientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvIngredientes.ColumnHeadersHeight = 34;
            this.dgvIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvIngredientes.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvIngredientes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvIngredientes.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvIngredientes.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvIngredientes.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvIngredientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 30F,
                Name = "Ingrediente",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Ingrediente"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 10F,
                Name = "Unidade",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Unidade"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 16F,
                Name = "Disponível",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Disponível"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 12F,
                Name = "Mínimo",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Mínimo"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 18F,
                Name = "Preço custo",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Preço custo"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 14F,
                Name = "Estado",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Estado"
            }});
            this.dgvIngredientes.Columns[2].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvIngredientes.Columns[3].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvIngredientes.Columns[4].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvIngredientes.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvIngredientes.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvIngredientes.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvIngredientes.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvIngredientes.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvIngredientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIngredientes.EnableHeadersVisualStyles = false;
            this.dgvIngredientes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvIngredientes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvIngredientes.MultiSelect = false;
            this.dgvIngredientes.Name = "dgvIngredientes";
            this.dgvIngredientes.ReadOnly = true;
            this.dgvIngredientes.RowHeadersVisible = false;
            this.dgvIngredientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredientes.Size = new System.Drawing.Size(940, 540);
            this.dgvIngredientes.TabIndex = 1;
            //
            // PainelEstoque
            //
            this._conteudo.Controls.Add(this.dgvIngredientes);
            this._conteudo.Controls.Add(this.filtros);
            this.Name = "PainelEstoque";
            this.Size = new System.Drawing.Size(940, 660);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).EndInit();
            this.filtros.ResumeLayout(false);
            this.filtros.PerformLayout();
        }
    }
}
