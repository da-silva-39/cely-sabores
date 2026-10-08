namespace Cely_Sabores
{
    partial class PainelReservas
    {
        private System.Windows.Forms.FlowLayoutPanel filtros;
        private System.Windows.Forms.Label lblDia;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.DataGridView dgvReservas;

        private void InitializeComponent()
        {
            this.filtros = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDia = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            //
            // filtros
            //
            this.filtros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.filtros.Controls.Add(this.lblDia);
            this.filtros.Controls.Add(this.dtpData);
            this.filtros.Controls.Add(this.cmbEstado);
            this.filtros.Dock = System.Windows.Forms.DockStyle.Top;
            this.filtros.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.filtros.Location = new System.Drawing.Point(0, 0);
            this.filtros.Name = "filtros";
            this.filtros.Size = new System.Drawing.Size(940, 42);
            this.filtros.TabIndex = 0;
            this.filtros.WrapContents = false;
            //
            // lblDia
            //
            this.lblDia.AutoSize = true;
            this.lblDia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(118)))), ((int)(((byte)(106)))));
            this.lblDia.Location = new System.Drawing.Point(0, 7);
            this.lblDia.Margin = new System.Windows.Forms.Padding(0, 7, 6, 0);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(26, 20);
            this.lblDia.TabIndex = 0;
            this.lblDia.Text = "Dia:";
            //
            // dtpData
            //
            this.dtpData.CustomFormat = "dd/MM/yyyy";
            this.dtpData.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpData.Location = new System.Drawing.Point(32, 5);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(140, 26);
            this.dtpData.TabIndex = 1;
            //
            // cmbEstado
            //
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {"(todos)"});
            this.cmbEstado.Location = new System.Drawing.Point(178, 5);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.SelectedIndex = 0;
            this.cmbEstado.Size = new System.Drawing.Size(170, 26);
            this.cmbEstado.TabIndex = 2;
            //
            // dgvReservas
            //
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.AllowUserToDeleteRows = false;
            this.dgvReservas.AllowUserToResizeRows = false;
            this.dgvReservas.AutoGenerateColumns = false;
            this.dgvReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservas.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReservas.ColumnHeadersHeight = 34;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReservas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvReservas.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvReservas.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReservas.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvReservas.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvReservas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 9F,
                Name = "Hora",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Hora"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 24F,
                Name = "Cliente",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Cliente"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 8F,
                Name = "Mesa",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Mesa"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 8F,
                Name = "Pessoas",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Pessoas"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 13F,
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
            this.dgvReservas.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvReservas.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvReservas.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvReservas.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvReservas.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvReservas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReservas.EnableHeadersVisualStyles = false;
            this.dgvReservas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvReservas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvReservas.MultiSelect = false;
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.RowHeadersVisible = false;
            this.dgvReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservas.Size = new System.Drawing.Size(940, 540);
            this.dgvReservas.TabIndex = 1;
            //
            // PainelReservas
            //
            this._conteudo.Controls.Add(this.dgvReservas);
            this._conteudo.Controls.Add(this.filtros);
            this.Name = "PainelReservas";
            this.Size = new System.Drawing.Size(940, 660);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.filtros.ResumeLayout(false);
            this.filtros.PerformLayout();
        }
    }
}
