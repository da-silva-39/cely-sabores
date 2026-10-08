namespace Cely_Sabores
{
    partial class DialogoReceitaPrato
    {
        private System.Windows.Forms.FlowLayoutPanel filtros;
        private System.Windows.Forms.Label lblPrato;
        private System.Windows.Forms.ComboBox cmbPrato;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnQuantidade;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvReceita;
        private System.Windows.Forms.FlowLayoutPanel barra;
        private System.Windows.Forms.Button btnFechar;

        private void InitializeComponent()
        {
            this.filtros = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPrato = new System.Windows.Forms.Label();
            this.cmbPrato = new System.Windows.Forms.ComboBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnQuantidade = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvReceita = new System.Windows.Forms.DataGridView();
            this.barra = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.filtros.SuspendLayout();
            this.barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceita)).BeginInit();
            this.SuspendLayout();
            //
            // filtros
            //
            this.filtros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.filtros.Controls.Add(this.lblPrato);
            this.filtros.Controls.Add(this.cmbPrato);
            this.filtros.Controls.Add(this.btnAdicionar);
            this.filtros.Controls.Add(this.btnQuantidade);
            this.filtros.Controls.Add(this.btnRemover);
            this.filtros.Controls.Add(this.btnGuardar);
            this.filtros.Dock = System.Windows.Forms.DockStyle.Top;
            this.filtros.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.filtros.Location = new System.Drawing.Point(0, 0);
            this.filtros.Name = "filtros";
            this.filtros.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.filtros.Size = new System.Drawing.Size(720, 68);
            this.filtros.TabIndex = 0;
            this.filtros.WrapContents = true;
            //
            // lblPrato
            //
            this.lblPrato.AutoSize = true;
            this.lblPrato.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrato.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(118)))), ((int)(((byte)(106)))));
            this.lblPrato.Location = new System.Drawing.Point(0, 6);
            this.lblPrato.Name = "lblPrato";
            this.lblPrato.Size = new System.Drawing.Size(33, 17);
            this.lblPrato.TabIndex = 0;
            this.lblPrato.Text = "Prato";
            //
            // cmbPrato
            //
            this.cmbPrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrato.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPrato.FormattingEnabled = true;
            this.cmbPrato.Location = new System.Drawing.Point(39, 12);
            this.cmbPrato.Name = "cmbPrato";
            this.cmbPrato.Size = new System.Drawing.Size(260, 26);
            this.cmbPrato.TabIndex = 1;
            //
            // btnAdicionar
            //
            this.btnAdicionar.AutoSize = true;
            this.btnAdicionar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdicionar.BackColor = System.Drawing.Color.White;
            this.btnAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.btnAdicionar.FlatAppearance.BorderSize = 1;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAdicionar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.btnAdicionar.Location = new System.Drawing.Point(311, 9);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnAdicionar.MinimumSize = new System.Drawing.Size(96, 34);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnAdicionar.Size = new System.Drawing.Size(170, 34);
            this.btnAdicionar.TabIndex = 2;
            this.btnAdicionar.Text = "Adicionar ingrediente";
            //
            // btnQuantidade
            //
            this.btnQuantidade.AutoSize = true;
            this.btnQuantidade.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuantidade.BackColor = System.Drawing.Color.White;
            this.btnQuantidade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuantidade.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.btnQuantidade.FlatAppearance.BorderSize = 1;
            this.btnQuantidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuantidade.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnQuantidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.btnQuantidade.Location = new System.Drawing.Point(489, 9);
            this.btnQuantidade.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnQuantidade.MinimumSize = new System.Drawing.Size(96, 34);
            this.btnQuantidade.Name = "btnQuantidade";
            this.btnQuantidade.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnQuantidade.Size = new System.Drawing.Size(153, 34);
            this.btnQuantidade.TabIndex = 3;
            this.btnQuantidade.Text = "Alterar quantidade";
            //
            // btnRemover
            //
            this.btnRemover.AutoSize = true;
            this.btnRemover.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemover.BackColor = System.Drawing.Color.White;
            this.btnRemover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemover.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.btnRemover.FlatAppearance.BorderSize = 1;
            this.btnRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemover.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRemover.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.btnRemover.Location = new System.Drawing.Point(650, 9);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnRemover.MinimumSize = new System.Drawing.Size(96, 34);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnRemover.Size = new System.Drawing.Size(125, 34);
            this.btnRemover.TabIndex = 4;
            this.btnRemover.Text = "Remover linha";
            //
            // btnGuardar
            //
            this.btnGuardar.AutoSize = true;
            this.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(783, 9);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnGuardar.MinimumSize = new System.Drawing.Size(96, 34);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnGuardar.Size = new System.Drawing.Size(131, 34);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar receita";
            //
            // dgvReceita
            //
            this.dgvReceita.AllowUserToAddRows = false;
            this.dgvReceita.AllowUserToDeleteRows = false;
            this.dgvReceita.AllowUserToResizeRows = false;
            this.dgvReceita.AutoGenerateColumns = false;
            this.dgvReceita.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReceita.BackgroundColor = System.Drawing.Color.White;
            this.dgvReceita.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReceita.ColumnHeadersHeight = 34;
            this.dgvReceita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReceita.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvReceita.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvReceita.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReceita.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvReceita.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvReceita.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 55F,
                HeaderText = "Ingrediente",
                Name = "Ingrediente",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 25F,
                HeaderText = "Quantidade",
                Name = "Quantidade",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 20F,
                HeaderText = "Unidade",
                Name = "Unidade",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            }});
            this.dgvReceita.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvReceita.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvReceita.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvReceita.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvReceita.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvReceita.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceita.EnableHeadersVisualStyles = false;
            this.dgvReceita.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvReceita.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvReceita.Location = new System.Drawing.Point(0, 68);
            this.dgvReceita.MultiSelect = false;
            this.dgvReceita.Name = "dgvReceita";
            this.dgvReceita.ReadOnly = true;
            this.dgvReceita.RowHeadersVisible = false;
            this.dgvReceita.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceita.Size = new System.Drawing.Size(720, 394);
            this.dgvReceita.TabIndex = 1;
            //
            // barra
            //
            this.barra.BackColor = System.Drawing.Color.White;
            this.barra.Controls.Add(this.btnFechar);
            this.barra.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barra.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.barra.Location = new System.Drawing.Point(0, 462);
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(720, 58);
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
            this.btnFechar.Location = new System.Drawing.Point(612, 12);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnFechar.MinimumSize = new System.Drawing.Size(96, 34);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnFechar.Size = new System.Drawing.Size(96, 34);
            this.btnFechar.TabIndex = 0;
            this.btnFechar.Text = "Fechar";
            //
            // DialogoReceitaPrato
            //
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(720, 520);
            this.Controls.Add(this.dgvReceita);
            this.Controls.Add(this.filtros);
            this.Controls.Add(this.barra);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(620, 420);
            this.Name = "DialogoReceitaPrato";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Receitas dos pratos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceita)).EndInit();
            this.filtros.ResumeLayout(false);
            this.filtros.PerformLayout();
            this.barra.ResumeLayout(false);
            this.barra.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
