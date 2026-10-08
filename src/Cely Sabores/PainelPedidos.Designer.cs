namespace Cely_Sabores
{
    partial class PainelPedidos
    {
        private System.Windows.Forms.FlowLayoutPanel filtros;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.DataGridView dgvPedidos;

        private void InitializeComponent()
        {
            this.filtros = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            //
            // filtros
            //
            this.filtros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.filtros.Controls.Add(this.cmbEstado);
            this.filtros.Dock = System.Windows.Forms.DockStyle.Top;
            this.filtros.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.filtros.Location = new System.Drawing.Point(0, 0);
            this.filtros.Name = "filtros";
            this.filtros.Size = new System.Drawing.Size(940, 42);
            this.filtros.TabIndex = 0;
            this.filtros.WrapContents = false;
            //
            // cmbEstado
            //
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {"Todos", "Abertos", "Fechados", "Cancelados"});
            this.cmbEstado.Location = new System.Drawing.Point(0, 0);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.SelectedIndex = 0;
            this.cmbEstado.Size = new System.Drawing.Size(170, 28);
            this.cmbEstado.TabIndex = 0;
            //
            // dgvPedidos
            //
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.AllowUserToResizeRows = false;
            this.dgvPedidos.AutoGenerateColumns = false;
            this.dgvPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPedidos.ColumnHeadersHeight = 34;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPedidos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvPedidos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvPedidos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPedidos.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvPedidos.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 8F,
                Name = "Nº",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Nº"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 10F,
                Name = "Mesa",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Mesa"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 26F,
                Name = "Cliente",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Cliente"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 22F,
                Name = "Aberto em",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Aberto em"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 16F,
                Name = "Estado",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Estado"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 18F,
                Name = "Total",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Total"
            }});
            this.dgvPedidos.Columns[5].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvPedidos.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvPedidos.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvPedidos.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvPedidos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvPedidos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidos.EnableHeadersVisualStyles = false;
            this.dgvPedidos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvPedidos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvPedidos.MultiSelect = false;
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowHeadersVisible = false;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.Size = new System.Drawing.Size(940, 540);
            this.dgvPedidos.TabIndex = 1;
            //
            // PainelPedidos
            //
            this._conteudo.Controls.Add(this.dgvPedidos);
            this._conteudo.Controls.Add(this.filtros);
            this.Name = "PainelPedidos";
            this.Size = new System.Drawing.Size(940, 660);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.filtros.ResumeLayout(false);
            this.filtros.PerformLayout();
        }
    }
}
