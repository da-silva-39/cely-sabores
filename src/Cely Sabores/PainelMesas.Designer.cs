namespace Cely_Sabores
{
    partial class PainelMesas
    {
        private System.Windows.Forms.DataGridView dgvMesas;
        private System.Windows.Forms.CheckBox chkMostrarInativas;

        private void InitializeComponent()
        {
            this.dgvMesas = new System.Windows.Forms.DataGridView();
            this.chkMostrarInativas = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMesas)).BeginInit();
            //
            // dgvMesas
            //
            this.dgvMesas.AllowUserToAddRows = false;
            this.dgvMesas.AllowUserToDeleteRows = false;
            this.dgvMesas.AllowUserToResizeRows = false;
            this.dgvMesas.AutoGenerateColumns = false;
            this.dgvMesas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMesas.BackgroundColor = System.Drawing.Color.White;
            this.dgvMesas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMesas.ColumnHeadersHeight = 34;
            this.dgvMesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMesas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvMesas.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvMesas.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMesas.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvMesas.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMesas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 18F,
                Name = "Número",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Número"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 18F,
                Name = "Capacidade",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Capacidade"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 26F,
                Name = "Estado",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Estado"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 38F,
                Name = "Observações",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Observações"
            }});
            this.dgvMesas.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvMesas.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvMesas.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvMesas.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvMesas.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvMesas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMesas.EnableHeadersVisualStyles = false;
            this.dgvMesas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvMesas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvMesas.MultiSelect = false;
            this.dgvMesas.Name = "dgvMesas";
            this.dgvMesas.ReadOnly = true;
            this.dgvMesas.RowHeadersVisible = false;
            this.dgvMesas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMesas.Size = new System.Drawing.Size(940, 540);
            this.dgvMesas.TabIndex = 1;
            //
            // chkMostrarInativas
            //
            this.chkMostrarInativas.AutoSize = true;
            this.chkMostrarInativas.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkMostrarInativas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkMostrarInativas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(118)))), ((int)(((byte)(106)))));
            this.chkMostrarInativas.Height = 34;
            this.chkMostrarInativas.Location = new System.Drawing.Point(0, 0);
            this.chkMostrarInativas.Margin = new System.Windows.Forms.Padding(0, 10, 12, 0);
            this.chkMostrarInativas.Name = "chkMostrarInativas";
            this.chkMostrarInativas.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.chkMostrarInativas.Size = new System.Drawing.Size(940, 34);
            this.chkMostrarInativas.TabIndex = 0;
            this.chkMostrarInativas.Text = "Mostrar inativas";
            this.chkMostrarInativas.UseVisualStyleBackColor = true;
            //
            // PainelMesas
            //
            this._conteudo.Controls.Add(this.dgvMesas);
            this._conteudo.Controls.Add(this.chkMostrarInativas);
            this.Name = "PainelMesas";
            this.Size = new System.Drawing.Size(940, 660);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMesas)).EndInit();
        }
    }
}
