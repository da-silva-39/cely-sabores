namespace Cely_Sabores
{
    partial class DialogoHistoricoEstoque
    {
        private System.Windows.Forms.FlowLayoutPanel filtros;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.DateTimePicker dtDe;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.DateTimePicker dtAte;
        private System.Windows.Forms.ComboBox cmbIngrediente;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvMovimentos;
        private System.Windows.Forms.FlowLayoutPanel barra;
        private System.Windows.Forms.Button btnFechar;

        private void InitializeComponent()
        {
            this.filtros = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDe = new System.Windows.Forms.Label();
            this.dtDe = new System.Windows.Forms.DateTimePicker();
            this.lblAte = new System.Windows.Forms.Label();
            this.dtAte = new System.Windows.Forms.DateTimePicker();
            this.cmbIngrediente = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dgvMovimentos = new System.Windows.Forms.DataGridView();
            this.barra = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.filtros.SuspendLayout();
            this.barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentos)).BeginInit();
            this.SuspendLayout();
            //
            // filtros
            //
            this.filtros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.filtros.Controls.Add(this.lblDe);
            this.filtros.Controls.Add(this.dtDe);
            this.filtros.Controls.Add(this.lblAte);
            this.filtros.Controls.Add(this.dtAte);
            this.filtros.Controls.Add(this.cmbIngrediente);
            this.filtros.Controls.Add(this.btnFiltrar);
            this.filtros.Dock = System.Windows.Forms.DockStyle.Top;
            this.filtros.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.filtros.Location = new System.Drawing.Point(0, 0);
            this.filtros.Name = "filtros";
            this.filtros.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.filtros.Size = new System.Drawing.Size(760, 68);
            this.filtros.TabIndex = 0;
            this.filtros.WrapContents = true;
            //
            // lblDe
            //
            this.lblDe.AutoSize = true;
            this.lblDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(118)))), ((int)(((byte)(106)))));
            this.lblDe.Location = new System.Drawing.Point(0, 4);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(20, 17);
            this.lblDe.TabIndex = 0;
            this.lblDe.Text = "De";
            //
            // dtDe
            //
            this.dtDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDe.Location = new System.Drawing.Point(28, 12);
            this.dtDe.Name = "dtDe";
            this.dtDe.Size = new System.Drawing.Size(120, 24);
            this.dtDe.TabIndex = 1;
            //
            // lblAte
            //
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(118)))), ((int)(((byte)(106)))));
            this.lblAte.Location = new System.Drawing.Point(130, 4);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(23, 17);
            this.lblAte.TabIndex = 2;
            this.lblAte.Text = "Até";
            //
            // dtAte
            //
            this.dtAte.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAte.Location = new System.Drawing.Point(162, 12);
            this.dtAte.Name = "dtAte";
            this.dtAte.Size = new System.Drawing.Size(120, 24);
            this.dtAte.TabIndex = 3;
            //
            // cmbIngrediente
            //
            this.cmbIngrediente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIngrediente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbIngrediente.FormattingEnabled = true;
            this.cmbIngrediente.Location = new System.Drawing.Point(294, 12);
            this.cmbIngrediente.Name = "cmbIngrediente";
            this.cmbIngrediente.Size = new System.Drawing.Size(210, 26);
            this.cmbIngrediente.TabIndex = 4;
            //
            // btnFiltrar
            //
            this.btnFiltrar.AutoSize = true;
            this.btnFiltrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(516, 9);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnFiltrar.MinimumSize = new System.Drawing.Size(96, 34);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnFiltrar.Size = new System.Drawing.Size(96, 34);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.Text = "Filtrar";
            //
            // dgvMovimentos
            //
            this.dgvMovimentos.AllowUserToAddRows = false;
            this.dgvMovimentos.AllowUserToDeleteRows = false;
            this.dgvMovimentos.AllowUserToResizeRows = false;
            this.dgvMovimentos.AutoGenerateColumns = false;
            this.dgvMovimentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimentos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMovimentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMovimentos.ColumnHeadersHeight = 34;
            this.dgvMovimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMovimentos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvMovimentos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvMovimentos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMovimentos.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvMovimentos.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMovimentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 16F,
                HeaderText = "Data",
                Name = "Data",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 22F,
                HeaderText = "Ingrediente",
                Name = "Ingrediente",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 12F,
                HeaderText = "Tipo",
                Name = "Tipo",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle() {
                    Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
                },
                FillWeight = 14F,
                HeaderText = "Quantidade",
                Name = "Quantidade",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 36F,
                HeaderText = "Observação",
                Name = "Observação",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            }});
            this.dgvMovimentos.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvMovimentos.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvMovimentos.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvMovimentos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvMovimentos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvMovimentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovimentos.EnableHeadersVisualStyles = false;
            this.dgvMovimentos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvMovimentos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvMovimentos.Location = new System.Drawing.Point(0, 68);
            this.dgvMovimentos.MultiSelect = false;
            this.dgvMovimentos.Name = "dgvMovimentos";
            this.dgvMovimentos.ReadOnly = true;
            this.dgvMovimentos.RowHeadersVisible = false;
            this.dgvMovimentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimentos.Size = new System.Drawing.Size(760, 394);
            this.dgvMovimentos.TabIndex = 1;
            //
            // barra
            //
            this.barra.BackColor = System.Drawing.Color.White;
            this.barra.Controls.Add(this.btnFechar);
            this.barra.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barra.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.barra.Location = new System.Drawing.Point(0, 462);
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(760, 58);
            this.barra.TabIndex = 2;
            this.barra.WrapContents = true;
            //
            // btnFechar
            //
            this.btnFechar.AutoSize = true;
            this.btnFechar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFechar.BackColor = System.Drawing.Color.White;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.btnFechar.FlatAppearance.BorderSize = 1;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnFechar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.btnFechar.Location = new System.Drawing.Point(652, 12);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnFechar.MinimumSize = new System.Drawing.Size(96, 34);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnFechar.Size = new System.Drawing.Size(96, 34);
            this.btnFechar.TabIndex = 0;
            this.btnFechar.Text = "Fechar";
            //
            // DialogoHistoricoEstoque
            //
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(760, 520);
            this.Controls.Add(this.dgvMovimentos);
            this.Controls.Add(this.filtros);
            this.Controls.Add(this.barra);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(640, 400);
            this.Name = "DialogoHistoricoEstoque";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Movimentos de estoque";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentos)).EndInit();
            this.filtros.ResumeLayout(false);
            this.filtros.PerformLayout();
            this.barra.ResumeLayout(false);
            this.barra.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
