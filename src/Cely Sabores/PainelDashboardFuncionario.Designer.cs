namespace Cely_Sabores
{
    partial class PainelDashboardFuncionario
    {
        private System.Windows.Forms.Panel areaTopo;
        private System.Windows.Forms.FlowLayoutPanel cartoes;
        private System.Windows.Forms.TableLayoutPanel colunas;
        private System.Windows.Forms.Panel painelAtendimentos;
        private System.Windows.Forms.Label lblTituloAtendimentos;
        private System.Windows.Forms.DataGridView dgvAtendimentos;
        private System.Windows.Forms.Panel painelReservas;
        private System.Windows.Forms.Label lblTituloReservas;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.Label rodape;

        private void InitializeComponent()
        {
            this.areaTopo = new System.Windows.Forms.Panel();
            this.cartoes = new System.Windows.Forms.FlowLayoutPanel();
            this.colunas = new System.Windows.Forms.TableLayoutPanel();
            this.painelAtendimentos = new System.Windows.Forms.Panel();
            this.lblTituloAtendimentos = new System.Windows.Forms.Label();
            this.dgvAtendimentos = new System.Windows.Forms.DataGridView();
            this.painelReservas = new System.Windows.Forms.Panel();
            this.lblTituloReservas = new System.Windows.Forms.Label();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.rodape = new System.Windows.Forms.Label();
            this.cartoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtendimentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            //
            // areaTopo
            //
            this.areaTopo.AutoScroll = true;
            this.areaTopo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.areaTopo.Controls.Add(this.cartoes);
            this.areaTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.areaTopo.Location = new System.Drawing.Point(0, 0);
            this.areaTopo.Name = "areaTopo";
            this.areaTopo.Size = new System.Drawing.Size(940, 108);
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
            this.cartoes.Size = new System.Drawing.Size(940, 108);
            this.cartoes.TabIndex = 0;
            this.cartoes.WrapContents = false;
            //
            // colunas
            //
            this.colunas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.colunas.ColumnCount = 2;
            this.colunas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.colunas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.colunas.Controls.Add(this.painelAtendimentos, 0, 0);
            this.colunas.Controls.Add(this.painelReservas, 1, 0);
            this.colunas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colunas.Location = new System.Drawing.Point(0, 108);
            this.colunas.Name = "colunas";
            this.colunas.RowCount = 1;
            this.colunas.Size = new System.Drawing.Size(940, 440);
            this.colunas.TabIndex = 2;
            //
            // painelAtendimentos
            //
            this.painelAtendimentos.Controls.Add(this.dgvAtendimentos);
            this.painelAtendimentos.Controls.Add(this.lblTituloAtendimentos);
            this.painelAtendimentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painelAtendimentos.Location = new System.Drawing.Point(0, 0);
            this.painelAtendimentos.Name = "painelAtendimentos";
            this.painelAtendimentos.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.painelAtendimentos.Size = new System.Drawing.Size(545, 440);
            this.painelAtendimentos.TabIndex = 0;
            //
            // lblTituloAtendimentos
            //
            this.lblTituloAtendimentos.AutoSize = true;
            this.lblTituloAtendimentos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloAtendimentos.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloAtendimentos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblTituloAtendimentos.Location = new System.Drawing.Point(0, 0);
            this.lblTituloAtendimentos.Name = "lblTituloAtendimentos";
            this.lblTituloAtendimentos.Size = new System.Drawing.Size(535, 28);
            this.lblTituloAtendimentos.TabIndex = 0;
            this.lblTituloAtendimentos.Text = "Atendimentos em andamento";
            //
            // dgvAtendimentos
            //
            this.dgvAtendimentos.AllowUserToAddRows = false;
            this.dgvAtendimentos.AllowUserToDeleteRows = false;
            this.dgvAtendimentos.AllowUserToResizeRows = false;
            this.dgvAtendimentos.AutoGenerateColumns = false;
            this.dgvAtendimentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAtendimentos.BackgroundColor = System.Drawing.Color.White;
            this.dgvAtendimentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAtendimentos.ColumnHeadersHeight = 34;
            this.dgvAtendimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAtendimentos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvAtendimentos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvAtendimentos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAtendimentos.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvAtendimentos.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAtendimentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 10F,
                Name = "Mesa",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Mesa"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 38F,
                Name = "Cliente",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Cliente"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 18F,
                Name = "Total",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Total"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 20F,
                Name = "Aberto há",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Aberto há"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 14F,
                Name = "Pedido",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Pedido"
            }});
            this.dgvAtendimentos.Columns[2].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvAtendimentos.Columns[4].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvAtendimentos.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvAtendimentos.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvAtendimentos.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvAtendimentos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvAtendimentos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvAtendimentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAtendimentos.EnableHeadersVisualStyles = false;
            this.dgvAtendimentos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvAtendimentos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvAtendimentos.Location = new System.Drawing.Point(0, 28);
            this.dgvAtendimentos.MultiSelect = false;
            this.dgvAtendimentos.Name = "dgvAtendimentos";
            this.dgvAtendimentos.ReadOnly = true;
            this.dgvAtendimentos.RowHeadersVisible = false;
            this.dgvAtendimentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAtendimentos.Size = new System.Drawing.Size(535, 412);
            this.dgvAtendimentos.TabIndex = 1;
            //
            // painelReservas
            //
            this.painelReservas.Controls.Add(this.dgvReservas);
            this.painelReservas.Controls.Add(this.lblTituloReservas);
            this.painelReservas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painelReservas.Location = new System.Drawing.Point(0, 0);
            this.painelReservas.Name = "painelReservas";
            this.painelReservas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.painelReservas.Size = new System.Drawing.Size(395, 440);
            this.painelReservas.TabIndex = 1;
            //
            // lblTituloReservas
            //
            this.lblTituloReservas.AutoSize = true;
            this.lblTituloReservas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloReservas.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloReservas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblTituloReservas.Location = new System.Drawing.Point(0, 0);
            this.lblTituloReservas.Name = "lblTituloReservas";
            this.lblTituloReservas.Size = new System.Drawing.Size(385, 28);
            this.lblTituloReservas.TabIndex = 0;
            this.lblTituloReservas.Text = "Reservas próximas";
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
                FillWeight = 12F,
                Name = "Hora",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Hora"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 38F,
                Name = "Cliente",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Cliente"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 14F,
                Name = "Pessoas",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Pessoas"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 12F,
                Name = "Mesa",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Mesa"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 24F,
                Name = "Estado",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Estado"
            }});
            this.dgvReservas.Columns[2].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvReservas.Columns[3].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvReservas.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvReservas.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvReservas.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvReservas.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvReservas.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvReservas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReservas.EnableHeadersVisualStyles = false;
            this.dgvReservas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvReservas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvReservas.Location = new System.Drawing.Point(0, 28);
            this.dgvReservas.MultiSelect = false;
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.RowHeadersVisible = false;
            this.dgvReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservas.Size = new System.Drawing.Size(385, 412);
            this.dgvReservas.TabIndex = 1;
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
            // PainelDashboardFuncionario
            //
            this._conteudo.Controls.Add(this.colunas);
            this._conteudo.Controls.Add(this.rodape);
            this._conteudo.Controls.Add(this.areaTopo);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.Name = "PainelDashboardFuncionario";
            this.Size = new System.Drawing.Size(940, 660);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtendimentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.cartoes.ResumeLayout(false);
        }
    }
}
