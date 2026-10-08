namespace Cely_Sabores
{
    partial class PainelPedidoDetalhe
    {
        private System.Windows.Forms.Label cabecalho;
        private System.Windows.Forms.TableLayoutPanel corpo;
        private System.Windows.Forms.Panel esquerda;
        private System.Windows.Forms.Label lblCardapio;
        private System.Windows.Forms.DataGridView dgvCardapio;
        private System.Windows.Forms.Panel direita;
        private System.Windows.Forms.Label lblItens;
        private System.Windows.Forms.DataGridView dgvItens;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.FlowLayoutPanel barra;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnRecibo;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnQuantidade;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAdicionar;

        private void InitializeComponent()
        {
            this.cabecalho = new System.Windows.Forms.Label();
            this.corpo = new System.Windows.Forms.TableLayoutPanel();
            this.esquerda = new System.Windows.Forms.Panel();
            this.lblCardapio = new System.Windows.Forms.Label();
            this.dgvCardapio = new System.Windows.Forms.DataGridView();
            this.direita = new System.Windows.Forms.Panel();
            this.lblItens = new System.Windows.Forms.Label();
            this.dgvItens = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.barra = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnRecibo = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnQuantidade = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.corpo.SuspendLayout();
            this.barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardapio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).BeginInit();
            //
            // cabecalho
            //
            this.cabecalho.AutoSize = false;
            this.cabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.cabecalho.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.cabecalho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.cabecalho.Location = new System.Drawing.Point(0, 0);
            this.cabecalho.Name = "cabecalho";
            this.cabecalho.Padding = new System.Windows.Forms.Padding(0);
            this.cabecalho.Size = new System.Drawing.Size(940, 56);
            this.cabecalho.TabIndex = 0;
            this.cabecalho.Text = "";
            this.cabecalho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // corpo
            //
            this.corpo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.corpo.ColumnCount = 2;
            this.corpo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.corpo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.corpo.Controls.Add(this.esquerda, 0, 0);
            this.corpo.Controls.Add(this.direita, 1, 0);
            this.corpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.corpo.Location = new System.Drawing.Point(0, 56);
            this.corpo.Name = "corpo";
            this.corpo.RowCount = 1;
            this.corpo.Size = new System.Drawing.Size(940, 470);
            this.corpo.TabIndex = 1;
            //
            // esquerda
            //
            this.esquerda.Controls.Add(this.dgvCardapio);
            this.esquerda.Controls.Add(this.lblCardapio);
            this.esquerda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.esquerda.Location = new System.Drawing.Point(0, 0);
            this.esquerda.Name = "esquerda";
            this.esquerda.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.esquerda.Size = new System.Drawing.Size(423, 470);
            this.esquerda.TabIndex = 0;
            //
            // lblCardapio
            //
            this.lblCardapio.AutoSize = true;
            this.lblCardapio.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCardapio.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCardapio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblCardapio.Location = new System.Drawing.Point(0, 0);
            this.lblCardapio.Name = "lblCardapio";
            this.lblCardapio.Size = new System.Drawing.Size(276, 26);
            this.lblCardapio.TabIndex = 0;
            this.lblCardapio.Text = "Cardápio (duplo clique para adicionar)";
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
                FillWeight = 70F,
                Name = "Prato",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Prato"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 30F,
                Name = "Preço",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Preço"
            }});
            this.dgvCardapio.Columns[1].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvCardapio.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvCardapio.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvCardapio.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvCardapio.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvCardapio.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvCardapio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCardapio.EnableHeadersVisualStyles = false;
            this.dgvCardapio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvCardapio.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvCardapio.Location = new System.Drawing.Point(0, 26);
            this.dgvCardapio.MultiSelect = false;
            this.dgvCardapio.Name = "dgvCardapio";
            this.dgvCardapio.ReadOnly = true;
            this.dgvCardapio.RowHeadersVisible = false;
            this.dgvCardapio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCardapio.Size = new System.Drawing.Size(423, 444);
            this.dgvCardapio.TabIndex = 1;
            //
            // direita
            //
            this.direita.Controls.Add(this.dgvItens);
            this.direita.Controls.Add(this.lblItens);
            this.direita.Controls.Add(this.lblTotal);
            this.direita.Dock = System.Windows.Forms.DockStyle.Fill;
            this.direita.Location = new System.Drawing.Point(423, 0);
            this.direita.Name = "direita";
            this.direita.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.direita.Size = new System.Drawing.Size(517, 470);
            this.direita.TabIndex = 1;
            //
            // lblItens
            //
            this.lblItens.AutoSize = true;
            this.lblItens.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblItens.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblItens.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.lblItens.Location = new System.Drawing.Point(0, 0);
            this.lblItens.Name = "lblItens";
            this.lblItens.Size = new System.Drawing.Size(133, 26);
            this.lblItens.TabIndex = 0;
            this.lblItens.Text = "Itens do pedido";
            //
            // dgvItens
            //
            this.dgvItens.AllowUserToAddRows = false;
            this.dgvItens.AllowUserToDeleteRows = false;
            this.dgvItens.AllowUserToResizeRows = false;
            this.dgvItens.AutoGenerateColumns = false;
            this.dgvItens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItens.BackgroundColor = System.Drawing.Color.White;
            this.dgvItens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItens.ColumnHeadersHeight = 34;
            this.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItens.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvItens.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvItens.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvItens.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvItens.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 50F,
                Name = "Item",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Item"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 12F,
                Name = "Qtd",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Qtd"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 18F,
                Name = "P. Unit.",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "P. Unit."
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 20F,
                Name = "Subtotal",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Subtotal"
            }});
            this.dgvItens.Columns[1].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvItens.Columns[2].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvItens.Columns[3].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvItens.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvItens.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvItens.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvItens.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvItens.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvItens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItens.EnableHeadersVisualStyles = false;
            this.dgvItens.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvItens.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvItens.Location = new System.Drawing.Point(0, 26);
            this.dgvItens.MultiSelect = false;
            this.dgvItens.Name = "dgvItens";
            this.dgvItens.ReadOnly = true;
            this.dgvItens.RowHeadersVisible = false;
            this.dgvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItens.Size = new System.Drawing.Size(517, 410);
            this.dgvItens.TabIndex = 1;
            //
            // lblTotal
            //
            this.lblTotal.AutoSize = false;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(119)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(0, 436);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(517, 34);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // barra
            //
            this.barra.BackColor = System.Drawing.Color.White;
            this.barra.Controls.Add(this.btnFechar);
            this.barra.Controls.Add(this.btnRecibo);
            this.barra.Controls.Add(this.btnPagar);
            this.barra.Controls.Add(this.btnCancelar);
            this.barra.Controls.Add(this.btnQuantidade);
            this.barra.Controls.Add(this.btnRemover);
            this.barra.Controls.Add(this.btnAdicionar);
            this.barra.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barra.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.barra.Location = new System.Drawing.Point(0, 526);
            this.barra.Name = "barra";
            this.barra.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.barra.Size = new System.Drawing.Size(940, 56);
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
            this.btnFechar.Location = new System.Drawing.Point(0, 0);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnFechar.MinimumSize = new System.Drawing.Size(96, 34);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnFechar.Size = new System.Drawing.Size(96, 34);
            this.btnFechar.TabIndex = 0;
            this.btnFechar.Text = "Fechar";
            //
            // btnRecibo
            //
            this.btnRecibo.AutoSize = true;
            this.btnRecibo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRecibo.BackColor = System.Drawing.Color.White;
            this.btnRecibo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecibo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.btnRecibo.FlatAppearance.BorderSize = 1;
            this.btnRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecibo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRecibo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.btnRecibo.Location = new System.Drawing.Point(0, 0);
            this.btnRecibo.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnRecibo.MinimumSize = new System.Drawing.Size(96, 34);
            this.btnRecibo.Name = "btnRecibo";
            this.btnRecibo.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnRecibo.Size = new System.Drawing.Size(96, 34);
            this.btnRecibo.TabIndex = 1;
            this.btnRecibo.Text = "Recibo";
            //
            // btnPagar
            //
            this.btnPagar.AutoSize = true;
            this.btnPagar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnPagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagar.FlatAppearance.BorderSize = 0;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.Location = new System.Drawing.Point(0, 0);
            this.btnPagar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnPagar.MinimumSize = new System.Drawing.Size(96, 34);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnPagar.Size = new System.Drawing.Size(96, 34);
            this.btnPagar.TabIndex = 2;
            this.btnPagar.Text = "Registar pagamento";
            //
            // btnCancelar
            //
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.btnCancelar.FlatAppearance.BorderSize = 1;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.btnCancelar.Location = new System.Drawing.Point(0, 0);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnCancelar.MinimumSize = new System.Drawing.Size(96, 34);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnCancelar.Size = new System.Drawing.Size(96, 34);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar pedido";
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
            this.btnQuantidade.Location = new System.Drawing.Point(0, 0);
            this.btnQuantidade.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnQuantidade.MinimumSize = new System.Drawing.Size(96, 34);
            this.btnQuantidade.Name = "btnQuantidade";
            this.btnQuantidade.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnQuantidade.Size = new System.Drawing.Size(96, 34);
            this.btnQuantidade.TabIndex = 4;
            this.btnQuantidade.Text = "+/- quantidade";
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
            this.btnRemover.Location = new System.Drawing.Point(0, 0);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnRemover.MinimumSize = new System.Drawing.Size(96, 34);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnRemover.Size = new System.Drawing.Size(96, 34);
            this.btnRemover.TabIndex = 5;
            this.btnRemover.Text = "Remover item";
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
            this.btnAdicionar.Location = new System.Drawing.Point(0, 0);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnAdicionar.MinimumSize = new System.Drawing.Size(96, 34);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnAdicionar.Size = new System.Drawing.Size(96, 34);
            this.btnAdicionar.TabIndex = 6;
            this.btnAdicionar.Text = "Adicionar item";
            //
            // PainelPedidoDetalhe
            //
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(940, 582);
            this.Controls.Add(this.corpo);
            this.Controls.Add(this.cabecalho);
            this.Controls.Add(this.barra);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "PainelPedidoDetalhe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalhe do pedido";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardapio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).EndInit();
            this.barra.ResumeLayout(false);
            this.barra.PerformLayout();
            this.corpo.ResumeLayout(false);
        }
    }
}
