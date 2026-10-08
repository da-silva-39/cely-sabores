namespace Cely_Sabores
{
    partial class PainelDashboardGerente
    {
        private System.Windows.Forms.Panel areaTopo;
        private System.Windows.Forms.FlowLayoutPanel cartoes;
        private System.Windows.Forms.TableLayoutPanel colunas;
        private System.Windows.Forms.Panel painelPratos;
        private System.Windows.Forms.Label lblTituloPratos;
        private System.Windows.Forms.DataGridView dgvPratos;
        private System.Windows.Forms.Panel painelEstoque;
        private System.Windows.Forms.Label lblTituloEstoque;
        private System.Windows.Forms.DataGridView dgvEstoque;
        private System.Windows.Forms.Label rodape;

        private void InitializeComponent()
        {
            this.areaTopo = new System.Windows.Forms.Panel();
            this.cartoes = new System.Windows.Forms.FlowLayoutPanel();
            this.colunas = new System.Windows.Forms.TableLayoutPanel();
            this.painelPratos = new System.Windows.Forms.Panel();
            this.lblTituloPratos = new System.Windows.Forms.Label();
            this.dgvPratos = new System.Windows.Forms.DataGridView();
            this.painelEstoque = new System.Windows.Forms.Panel();
            this.lblTituloEstoque = new System.Windows.Forms.Label();
            this.dgvEstoque = new System.Windows.Forms.DataGridView();
            this.rodape = new System.Windows.Forms.Label();
            this.cartoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPratos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).BeginInit();
            //
            // areaTopo
            //
            this.areaTopo.AutoScroll = true;
            this.areaTopo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.areaTopo.Controls.Add(this.cartoes);
            this.areaTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.areaTopo.Location = new System.Drawing.Point(0, 0);
            this.areaTopo.Name = "areaTopo";
            this.areaTopo.Size = new System.Drawing.Size(940, 122);
            this.areaTopo.TabIndex = 0;
            //
            // cartoes
            //
            this.cartoes.AutoScroll = true;
            this.cartoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.cartoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartoes.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.cartoes.Location = new System.Drawing.Point(0, 0);
            this.cartoes.Name = "cartoes";
            this.cartoes.Size = new System.Drawing.Size(940, 122);
            this.cartoes.TabIndex = 0;
            this.cartoes.WrapContents = false;
            //
            // colunas
            //
            this.colunas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.colunas.ColumnCount = 2;
            this.colunas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.colunas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.colunas.Controls.Add(this.painelPratos, 0, 0);
            this.colunas.Controls.Add(this.painelEstoque, 1, 0);
            this.colunas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colunas.Location = new System.Drawing.Point(0, 122);
            this.colunas.Name = "colunas";
            this.colunas.RowCount = 1;
            this.colunas.Size = new System.Drawing.Size(940, 426);
            this.colunas.TabIndex = 2;
            //
            // painelPratos
            //
            this.painelPratos.Controls.Add(this.dgvPratos);
            this.painelPratos.Controls.Add(this.lblTituloPratos);
            this.painelPratos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painelPratos.Location = new System.Drawing.Point(0, 0);
            this.painelPratos.Name = "painelPratos";
            this.painelPratos.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.painelPratos.Size = new System.Drawing.Size(470, 426);
            this.painelPratos.TabIndex = 0;
            //
            // lblTituloPratos
            //
            this.lblTituloPratos.AutoSize = true;
            this.lblTituloPratos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPratos.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloPratos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblTituloPratos.Location = new System.Drawing.Point(0, 0);
            this.lblTituloPratos.Name = "lblTituloPratos";
            this.lblTituloPratos.Size = new System.Drawing.Size(460, 28);
            this.lblTituloPratos.TabIndex = 0;
            this.lblTituloPratos.Text = "Pratos mais vendidos";
            //
            // dgvPratos
            //
            this.dgvPratos.AllowUserToAddRows = false;
            this.dgvPratos.AllowUserToDeleteRows = false;
            this.dgvPratos.AllowUserToResizeRows = false;
            this.dgvPratos.AutoGenerateColumns = false;
            this.dgvPratos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPratos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPratos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPratos.ColumnHeadersHeight = 34;
            this.dgvPratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPratos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvPratos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvPratos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPratos.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvPratos.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvPratos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 55F,
                Name = "Prato",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Prato"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 15F,
                Name = "Qtd",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Qtd"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 30F,
                Name = "Faturamento",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Faturamento"
            }});
            this.dgvPratos.Columns[2].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvPratos.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvPratos.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvPratos.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvPratos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvPratos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvPratos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPratos.EnableHeadersVisualStyles = false;
            this.dgvPratos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvPratos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvPratos.Location = new System.Drawing.Point(0, 28);
            this.dgvPratos.MultiSelect = false;
            this.dgvPratos.Name = "dgvPratos";
            this.dgvPratos.ReadOnly = true;
            this.dgvPratos.RowHeadersVisible = false;
            this.dgvPratos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPratos.Size = new System.Drawing.Size(460, 398);
            this.dgvPratos.TabIndex = 1;
            //
            // painelEstoque
            //
            this.painelEstoque.Controls.Add(this.dgvEstoque);
            this.painelEstoque.Controls.Add(this.lblTituloEstoque);
            this.painelEstoque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painelEstoque.Location = new System.Drawing.Point(0, 0);
            this.painelEstoque.Name = "painelEstoque";
            this.painelEstoque.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.painelEstoque.Size = new System.Drawing.Size(470, 426);
            this.painelEstoque.TabIndex = 1;
            //
            // lblTituloEstoque
            //
            this.lblTituloEstoque.AutoSize = true;
            this.lblTituloEstoque.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloEstoque.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloEstoque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblTituloEstoque.Location = new System.Drawing.Point(0, 0);
            this.lblTituloEstoque.Name = "lblTituloEstoque";
            this.lblTituloEstoque.Size = new System.Drawing.Size(460, 28);
            this.lblTituloEstoque.TabIndex = 0;
            this.lblTituloEstoque.Text = "Estoque baixo";
            //
            // dgvEstoque
            //
            this.dgvEstoque.AllowUserToAddRows = false;
            this.dgvEstoque.AllowUserToDeleteRows = false;
            this.dgvEstoque.AllowUserToResizeRows = false;
            this.dgvEstoque.AutoGenerateColumns = false;
            this.dgvEstoque.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstoque.BackgroundColor = System.Drawing.Color.White;
            this.dgvEstoque.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEstoque.ColumnHeadersHeight = 34;
            this.dgvEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEstoque.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvEstoque.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvEstoque.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvEstoque.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvEstoque.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvEstoque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 50F,
                Name = "Ingrediente",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Ingrediente"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 15F,
                Name = "Un.",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Un."
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 17F,
                Name = "Disponível",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Disponível"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 18F,
                Name = "Mínimo",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Mínimo"
            }});
            this.dgvEstoque.Columns[1].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvEstoque.Columns[2].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvEstoque.Columns[3].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvEstoque.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvEstoque.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvEstoque.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvEstoque.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvEstoque.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvEstoque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEstoque.EnableHeadersVisualStyles = false;
            this.dgvEstoque.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvEstoque.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvEstoque.Location = new System.Drawing.Point(0, 28);
            this.dgvEstoque.MultiSelect = false;
            this.dgvEstoque.Name = "dgvEstoque";
            this.dgvEstoque.ReadOnly = true;
            this.dgvEstoque.RowHeadersVisible = false;
            this.dgvEstoque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstoque.Size = new System.Drawing.Size(460, 398);
            this.dgvEstoque.TabIndex = 1;
            //
            // rodape
            //
            this.rodape.AutoSize = false;
            this.rodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rodape.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rodape.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(118)))), ((int)(((byte)(106)))));
            this.rodape.Location = new System.Drawing.Point(0, 548);
            this.rodape.Name = "rodape";
            this.rodape.Size = new System.Drawing.Size(940, 26);
            this.rodape.TabIndex = 1;
            this.rodape.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // PainelDashboardGerente
            //
            this._conteudo.Controls.Add(this.colunas);
            this._conteudo.Controls.Add(this.rodape);
            this._conteudo.Controls.Add(this.areaTopo);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.Name = "PainelDashboardGerente";
            this.Size = new System.Drawing.Size(940, 660);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPratos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).EndInit();
            this.cartoes.ResumeLayout(false);
        }
    }
}
