namespace Cely_Sabores
{
    partial class PainelRelatorios
    {
        private System.Windows.Forms.FlowLayoutPanel filtros;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.FlowLayoutPanel pnlCartoes;
        private System.Windows.Forms.TabControl abas;
        private System.Windows.Forms.TabPage tabDia;
        private System.Windows.Forms.TabPage tabFuncionario;
        private System.Windows.Forms.TabPage tabPrato;
        private System.Windows.Forms.TabPage tabReservaDia;
        private System.Windows.Forms.TabPage tabReservaEstado;
        private System.Windows.Forms.TabPage tabMesa;
        private System.Windows.Forms.TabPage tabEstoque;
        private System.Windows.Forms.DataGridView dgvDia;
        private System.Windows.Forms.DataGridView dgvFuncionario;
        private System.Windows.Forms.DataGridView dgvPrato;
        private System.Windows.Forms.DataGridView dgvReservaDia;
        private System.Windows.Forms.DataGridView dgvReservaEstado;
        private System.Windows.Forms.DataGridView dgvMesa;
        private System.Windows.Forms.DataGridView dgvEstoque;
        private System.Windows.Forms.Label cabDia;
        private System.Windows.Forms.Label cabFuncionario;
        private System.Windows.Forms.Label cabPrato;
        private System.Windows.Forms.Label cabReservaDia;
        private System.Windows.Forms.Label cabReservaEstado;
        private System.Windows.Forms.Label cabMesa;
        private System.Windows.Forms.Label cabEstoque;

        private void InitializeComponent()
        {
            this.filtros = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDe = new System.Windows.Forms.Label();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.lblAte = new System.Windows.Forms.Label();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.lblNota = new System.Windows.Forms.Label();
            this.pnlCartoes = new System.Windows.Forms.FlowLayoutPanel();
            this.abas = new System.Windows.Forms.TabControl();
            this.tabDia = new System.Windows.Forms.TabPage();
            this.tabFuncionario = new System.Windows.Forms.TabPage();
            this.tabPrato = new System.Windows.Forms.TabPage();
            this.tabReservaDia = new System.Windows.Forms.TabPage();
            this.tabReservaEstado = new System.Windows.Forms.TabPage();
            this.tabMesa = new System.Windows.Forms.TabPage();
            this.tabEstoque = new System.Windows.Forms.TabPage();
            this.dgvDia = new System.Windows.Forms.DataGridView();
            this.dgvFuncionario = new System.Windows.Forms.DataGridView();
            this.dgvPrato = new System.Windows.Forms.DataGridView();
            this.dgvReservaDia = new System.Windows.Forms.DataGridView();
            this.dgvReservaEstado = new System.Windows.Forms.DataGridView();
            this.dgvMesa = new System.Windows.Forms.DataGridView();
            this.dgvEstoque = new System.Windows.Forms.DataGridView();
            this.cabDia = new System.Windows.Forms.Label();
            this.cabFuncionario = new System.Windows.Forms.Label();
            this.cabPrato = new System.Windows.Forms.Label();
            this.cabReservaDia = new System.Windows.Forms.Label();
            this.cabReservaEstado = new System.Windows.Forms.Label();
            this.cabMesa = new System.Windows.Forms.Label();
            this.cabEstoque = new System.Windows.Forms.Label();
            this.filtros.SuspendLayout();
            this.pnlCartoes.SuspendLayout();
            this.abas.SuspendLayout();
            this.tabDia.SuspendLayout();
            this.tabFuncionario.SuspendLayout();
            this.tabPrato.SuspendLayout();
            this.tabReservaDia.SuspendLayout();
            this.tabReservaEstado.SuspendLayout();
            this.tabMesa.SuspendLayout();
            this.tabEstoque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservaDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservaEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).BeginInit();
            //
            // filtros
            //
            this.filtros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.filtros.Controls.Add(this.lblDe);
            this.filtros.Controls.Add(this.dtpDe);
            this.filtros.Controls.Add(this.lblAte);
            this.filtros.Controls.Add(this.dtpAte);
            this.filtros.Controls.Add(this.lblNota);
            this.filtros.Dock = System.Windows.Forms.DockStyle.Top;
            this.filtros.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.filtros.Location = new System.Drawing.Point(0, 0);
            this.filtros.Name = "filtros";
            this.filtros.Size = new System.Drawing.Size(940, 46);
            this.filtros.TabIndex = 0;
            this.filtros.WrapContents = false;
            //
            // lblDe
            //
            this.lblDe.AutoSize = true;
            this.lblDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(118)))), ((int)(((byte)(106)))));
            this.lblDe.Location = new System.Drawing.Point(0, 7);
            this.lblDe.Margin = new System.Windows.Forms.Padding(0, 7, 6, 0);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(22, 20);
            this.lblDe.TabIndex = 0;
            this.lblDe.Text = "De:";
            //
            // dtpDe
            //
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.Location = new System.Drawing.Point(28, 11);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(120, 26);
            this.dtpDe.TabIndex = 1;
            //
            // lblAte
            //
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(118)))), ((int)(((byte)(106)))));
            this.lblAte.Location = new System.Drawing.Point(162, 7);
            this.lblAte.Margin = new System.Windows.Forms.Padding(14, 7, 6, 0);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(24, 20);
            this.lblAte.TabIndex = 2;
            this.lblAte.Text = "até:";
            //
            // dtpAte
            //
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(192, 11);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.Size = new System.Drawing.Size(120, 26);
            this.dtpAte.TabIndex = 3;
            //
            // lblNota
            //
            this.lblNota.AutoSize = true;
            this.lblNota.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(118)))), ((int)(((byte)(106)))));
            this.lblNota.Location = new System.Drawing.Point(330, 9);
            this.lblNota.Margin = new System.Windows.Forms.Padding(18, 7, 0, 0);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(378, 19);
            this.lblNota.TabIndex = 4;
            this.lblNota.Text = "Reservas e mesas respeitam o intervalo; o estoque baixo é a fotografia de hoje.";
            //
            // pnlCartoes
            //
            this.pnlCartoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.pnlCartoes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCartoes.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlCartoes.Location = new System.Drawing.Point(0, 46);
            this.pnlCartoes.Name = "pnlCartoes";
            this.pnlCartoes.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.pnlCartoes.Size = new System.Drawing.Size(940, 186);
            this.pnlCartoes.TabIndex = 1;
            this.pnlCartoes.WrapContents = true;
            //
            // abas
            //
            this.abas.Controls.Add(this.tabDia);
            this.abas.Controls.Add(this.tabFuncionario);
            this.abas.Controls.Add(this.tabPrato);
            this.abas.Controls.Add(this.tabReservaDia);
            this.abas.Controls.Add(this.tabReservaEstado);
            this.abas.Controls.Add(this.tabMesa);
            this.abas.Controls.Add(this.tabEstoque);
            this.abas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.abas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.abas.Location = new System.Drawing.Point(0, 232);
            this.abas.Name = "abas";
            this.abas.Padding = new System.Drawing.Point(12, 6);
            this.abas.Size = new System.Drawing.Size(940, 342);
            this.abas.TabIndex = 2;
            //
            // tabDia
            //
            this.tabDia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.tabDia.Controls.Add(this.dgvDia);
            this.tabDia.Controls.Add(this.cabDia);
            this.tabDia.Location = new System.Drawing.Point(4, 28);
            this.tabDia.Name = "tabDia";
            this.tabDia.Padding = new System.Windows.Forms.Padding(3);
            this.tabDia.Size = new System.Drawing.Size(932, 310);
            this.tabDia.TabIndex = 0;
            this.tabDia.Text = "Por dia";
            this.tabDia.UseVisualStyleBackColor = false;
            //
            // tabFuncionario
            //
            this.tabFuncionario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.tabFuncionario.Controls.Add(this.dgvFuncionario);
            this.tabFuncionario.Controls.Add(this.cabFuncionario);
            this.tabFuncionario.Location = new System.Drawing.Point(4, 28);
            this.tabFuncionario.Name = "tabFuncionario";
            this.tabFuncionario.Padding = new System.Windows.Forms.Padding(3);
            this.tabFuncionario.Size = new System.Drawing.Size(932, 310);
            this.tabFuncionario.TabIndex = 1;
            this.tabFuncionario.Text = "Por funcionário";
            this.tabFuncionario.UseVisualStyleBackColor = false;
            //
            // tabPrato
            //
            this.tabPrato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.tabPrato.Controls.Add(this.dgvPrato);
            this.tabPrato.Controls.Add(this.cabPrato);
            this.tabPrato.Location = new System.Drawing.Point(4, 28);
            this.tabPrato.Name = "tabPrato";
            this.tabPrato.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrato.Size = new System.Drawing.Size(932, 310);
            this.tabPrato.TabIndex = 2;
            this.tabPrato.Text = "Por prato";
            this.tabPrato.UseVisualStyleBackColor = false;
            //
            // tabReservaDia
            //
            this.tabReservaDia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.tabReservaDia.Controls.Add(this.dgvReservaDia);
            this.tabReservaDia.Controls.Add(this.cabReservaDia);
            this.tabReservaDia.Location = new System.Drawing.Point(4, 28);
            this.tabReservaDia.Name = "tabReservaDia";
            this.tabReservaDia.Padding = new System.Windows.Forms.Padding(3);
            this.tabReservaDia.Size = new System.Drawing.Size(932, 310);
            this.tabReservaDia.TabIndex = 3;
            this.tabReservaDia.Text = "Reservas por dia";
            this.tabReservaDia.UseVisualStyleBackColor = false;
            //
            // tabReservaEstado
            //
            this.tabReservaEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.tabReservaEstado.Controls.Add(this.dgvReservaEstado);
            this.tabReservaEstado.Controls.Add(this.cabReservaEstado);
            this.tabReservaEstado.Location = new System.Drawing.Point(4, 28);
            this.tabReservaEstado.Name = "tabReservaEstado";
            this.tabReservaEstado.Padding = new System.Windows.Forms.Padding(3);
            this.tabReservaEstado.Size = new System.Drawing.Size(932, 310);
            this.tabReservaEstado.TabIndex = 4;
            this.tabReservaEstado.Text = "Reservas por estado";
            this.tabReservaEstado.UseVisualStyleBackColor = false;
            //
            // tabMesa
            //
            this.tabMesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.tabMesa.Controls.Add(this.dgvMesa);
            this.tabMesa.Controls.Add(this.cabMesa);
            this.tabMesa.Location = new System.Drawing.Point(4, 28);
            this.tabMesa.Name = "tabMesa";
            this.tabMesa.Padding = new System.Windows.Forms.Padding(3);
            this.tabMesa.Size = new System.Drawing.Size(932, 310);
            this.tabMesa.TabIndex = 5;
            this.tabMesa.Text = "Mesas utilizadas";
            this.tabMesa.UseVisualStyleBackColor = false;
            //
            // tabEstoque
            //
            this.tabEstoque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.tabEstoque.Controls.Add(this.dgvEstoque);
            this.tabEstoque.Controls.Add(this.cabEstoque);
            this.tabEstoque.Location = new System.Drawing.Point(4, 28);
            this.tabEstoque.Name = "tabEstoque";
            this.tabEstoque.Padding = new System.Windows.Forms.Padding(3);
            this.tabEstoque.Size = new System.Drawing.Size(932, 310);
            this.tabEstoque.TabIndex = 6;
            this.tabEstoque.Text = "Estoque baixo";
            this.tabEstoque.UseVisualStyleBackColor = false;
            //
            // dgvDia
            //
            this.dgvDia.AllowUserToAddRows = false;
            this.dgvDia.AllowUserToDeleteRows = false;
            this.dgvDia.AllowUserToResizeRows = false;
            this.dgvDia.AutoGenerateColumns = false;
            this.dgvDia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDia.BackgroundColor = System.Drawing.Color.White;
            this.dgvDia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDia.ColumnHeadersHeight = 34;
            this.dgvDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDia.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvDia.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvDia.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDia.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvDia.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 30F,
                Name = "Dia",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Dia"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 18F,
                Name = "Pedidos",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Pedidos"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 28F,
                Name = "Faturamento",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Faturamento"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 24F,
                Name = "Ticket médio",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Ticket médio"
            }});
            this.dgvDia.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvDia.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvDia.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvDia.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvDia.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvDia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDia.EnableHeadersVisualStyles = false;
            this.dgvDia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvDia.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvDia.MultiSelect = false;
            this.dgvDia.Name = "dgvDia";
            this.dgvDia.ReadOnly = true;
            this.dgvDia.RowHeadersVisible = false;
            this.dgvDia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDia.Size = new System.Drawing.Size(926, 273);
            this.dgvDia.TabIndex = 1;
            //
            // dgvFuncionario
            //
            this.dgvFuncionario.AllowUserToAddRows = false;
            this.dgvFuncionario.AllowUserToDeleteRows = false;
            this.dgvFuncionario.AllowUserToResizeRows = false;
            this.dgvFuncionario.AutoGenerateColumns = false;
            this.dgvFuncionario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFuncionario.BackgroundColor = System.Drawing.Color.White;
            this.dgvFuncionario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFuncionario.ColumnHeadersHeight = 34;
            this.dgvFuncionario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFuncionario.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvFuncionario.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvFuncionario.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvFuncionario.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvFuncionario.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvFuncionario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 34F,
                Name = "Funcionário",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Funcionário"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 14F,
                Name = "Pedidos",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Pedidos"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 20F,
                Name = "Faturamento",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Faturamento"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 18F,
                Name = "Recebido",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Recebido"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 14F,
                Name = "Troco",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Troco"
            }});
            this.dgvFuncionario.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvFuncionario.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvFuncionario.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvFuncionario.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvFuncionario.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvFuncionario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFuncionario.EnableHeadersVisualStyles = false;
            this.dgvFuncionario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvFuncionario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvFuncionario.MultiSelect = false;
            this.dgvFuncionario.Name = "dgvFuncionario";
            this.dgvFuncionario.ReadOnly = true;
            this.dgvFuncionario.RowHeadersVisible = false;
            this.dgvFuncionario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFuncionario.Size = new System.Drawing.Size(926, 273);
            this.dgvFuncionario.TabIndex = 1;
            //
            // dgvPrato
            //
            this.dgvPrato.AllowUserToAddRows = false;
            this.dgvPrato.AllowUserToDeleteRows = false;
            this.dgvPrato.AllowUserToResizeRows = false;
            this.dgvPrato.AutoGenerateColumns = false;
            this.dgvPrato.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrato.BackgroundColor = System.Drawing.Color.White;
            this.dgvPrato.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPrato.ColumnHeadersHeight = 34;
            this.dgvPrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPrato.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvPrato.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvPrato.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPrato.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvPrato.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvPrato.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 50F,
                Name = "Prato",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Prato"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 20F,
                Name = "Quantidade",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Quantidade"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 30F,
                Name = "Faturamento",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Faturamento"
            }});
            this.dgvPrato.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvPrato.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvPrato.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvPrato.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvPrato.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvPrato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrato.EnableHeadersVisualStyles = false;
            this.dgvPrato.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvPrato.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvPrato.MultiSelect = false;
            this.dgvPrato.Name = "dgvPrato";
            this.dgvPrato.ReadOnly = true;
            this.dgvPrato.RowHeadersVisible = false;
            this.dgvPrato.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrato.Size = new System.Drawing.Size(926, 273);
            this.dgvPrato.TabIndex = 1;
            //
            // dgvReservaDia
            //
            this.dgvReservaDia.AllowUserToAddRows = false;
            this.dgvReservaDia.AllowUserToDeleteRows = false;
            this.dgvReservaDia.AllowUserToResizeRows = false;
            this.dgvReservaDia.AutoGenerateColumns = false;
            this.dgvReservaDia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservaDia.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservaDia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReservaDia.ColumnHeadersHeight = 34;
            this.dgvReservaDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReservaDia.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvReservaDia.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvReservaDia.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReservaDia.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvReservaDia.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvReservaDia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 24F,
                Name = "Dia",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Dia"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 15F,
                Name = "Reservas",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Reservas"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 14F,
                Name = "Pessoas",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Pessoas"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 16F,
                Name = "Confirmadas",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Confirmadas"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 16F,
                Name = "Compareceram",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Compareceram"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 15F,
                Name = "Canceladas",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Canceladas"
            }});
            this.dgvReservaDia.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvReservaDia.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvReservaDia.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvReservaDia.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvReservaDia.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvReservaDia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReservaDia.EnableHeadersVisualStyles = false;
            this.dgvReservaDia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvReservaDia.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvReservaDia.MultiSelect = false;
            this.dgvReservaDia.Name = "dgvReservaDia";
            this.dgvReservaDia.ReadOnly = true;
            this.dgvReservaDia.RowHeadersVisible = false;
            this.dgvReservaDia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservaDia.Size = new System.Drawing.Size(926, 273);
            this.dgvReservaDia.TabIndex = 1;
            //
            // dgvReservaEstado
            //
            this.dgvReservaEstado.AllowUserToAddRows = false;
            this.dgvReservaEstado.AllowUserToDeleteRows = false;
            this.dgvReservaEstado.AllowUserToResizeRows = false;
            this.dgvReservaEstado.AutoGenerateColumns = false;
            this.dgvReservaEstado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservaEstado.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservaEstado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReservaEstado.ColumnHeadersHeight = 34;
            this.dgvReservaEstado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReservaEstado.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvReservaEstado.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvReservaEstado.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReservaEstado.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvReservaEstado.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvReservaEstado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 50F,
                Name = "Estado",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Estado"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 25F,
                Name = "Reservas",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Reservas"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 25F,
                Name = "Pessoas",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Pessoas"
            }});
            this.dgvReservaEstado.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvReservaEstado.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvReservaEstado.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvReservaEstado.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvReservaEstado.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvReservaEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReservaEstado.EnableHeadersVisualStyles = false;
            this.dgvReservaEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvReservaEstado.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvReservaEstado.MultiSelect = false;
            this.dgvReservaEstado.Name = "dgvReservaEstado";
            this.dgvReservaEstado.ReadOnly = true;
            this.dgvReservaEstado.RowHeadersVisible = false;
            this.dgvReservaEstado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservaEstado.Size = new System.Drawing.Size(926, 273);
            this.dgvReservaEstado.TabIndex = 1;
            //
            // dgvMesa
            //
            this.dgvMesa.AllowUserToAddRows = false;
            this.dgvMesa.AllowUserToDeleteRows = false;
            this.dgvMesa.AllowUserToResizeRows = false;
            this.dgvMesa.AutoGenerateColumns = false;
            this.dgvMesa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMesa.BackgroundColor = System.Drawing.Color.White;
            this.dgvMesa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMesa.ColumnHeadersHeight = 34;
            this.dgvMesa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMesa.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvMesa.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvMesa.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMesa.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.dgvMesa.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMesa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 20F,
                Name = "Mesa",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Mesa"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 16F,
                Name = "Lugares",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Lugares"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 18F,
                Name = "Pedidos",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Pedidos"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 28F,
                Name = "Faturamento",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Faturamento"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 18F,
                Name = "Ticket médio",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Ticket médio"
            }});
            this.dgvMesa.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvMesa.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvMesa.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvMesa.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvMesa.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvMesa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMesa.EnableHeadersVisualStyles = false;
            this.dgvMesa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvMesa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvMesa.MultiSelect = false;
            this.dgvMesa.Name = "dgvMesa";
            this.dgvMesa.ReadOnly = true;
            this.dgvMesa.RowHeadersVisible = false;
            this.dgvMesa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMesa.Size = new System.Drawing.Size(926, 273);
            this.dgvMesa.TabIndex = 1;
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
                FillWeight = 28F,
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
                FillWeight = 14F,
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
                FillWeight = 12F,
                Name = "Falta",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Falta"
            },
            new System.Windows.Forms.DataGridViewTextBoxColumn() {
                FillWeight = 24F,
                Name = "Custo reposição",
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                HeaderText = "Custo reposição"
            }});
            this.dgvEstoque.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvEstoque.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvEstoque.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvEstoque.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(205)))));
            this.dgvEstoque.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.dgvEstoque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEstoque.EnableHeadersVisualStyles = false;
            this.dgvEstoque.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvEstoque.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.dgvEstoque.MultiSelect = false;
            this.dgvEstoque.Name = "dgvEstoque";
            this.dgvEstoque.ReadOnly = true;
            this.dgvEstoque.RowHeadersVisible = false;
            this.dgvEstoque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstoque.Size = new System.Drawing.Size(926, 273);
            this.dgvEstoque.TabIndex = 1;
            //
            // cabDia
            //
            this.cabDia.AutoEllipsis = true;
            this.cabDia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.cabDia.Dock = System.Windows.Forms.DockStyle.Top;
            this.cabDia.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.cabDia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.cabDia.Location = new System.Drawing.Point(0, 0);
            this.cabDia.Name = "cabDia";
            this.cabDia.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.cabDia.Size = new System.Drawing.Size(926, 34);
            this.cabDia.TabIndex = 0;
            this.cabDia.Text = "";
            this.cabDia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cabFuncionario
            //
            this.cabFuncionario.AutoEllipsis = true;
            this.cabFuncionario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.cabFuncionario.Dock = System.Windows.Forms.DockStyle.Top;
            this.cabFuncionario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.cabFuncionario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.cabFuncionario.Location = new System.Drawing.Point(0, 0);
            this.cabFuncionario.Name = "cabFuncionario";
            this.cabFuncionario.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.cabFuncionario.Size = new System.Drawing.Size(926, 34);
            this.cabFuncionario.TabIndex = 0;
            this.cabFuncionario.Text = "";
            this.cabFuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cabPrato
            //
            this.cabPrato.AutoEllipsis = true;
            this.cabPrato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.cabPrato.Dock = System.Windows.Forms.DockStyle.Top;
            this.cabPrato.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.cabPrato.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.cabPrato.Location = new System.Drawing.Point(0, 0);
            this.cabPrato.Name = "cabPrato";
            this.cabPrato.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.cabPrato.Size = new System.Drawing.Size(926, 34);
            this.cabPrato.TabIndex = 0;
            this.cabPrato.Text = "";
            this.cabPrato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cabReservaDia
            //
            this.cabReservaDia.AutoEllipsis = true;
            this.cabReservaDia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.cabReservaDia.Dock = System.Windows.Forms.DockStyle.Top;
            this.cabReservaDia.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.cabReservaDia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.cabReservaDia.Location = new System.Drawing.Point(0, 0);
            this.cabReservaDia.Name = "cabReservaDia";
            this.cabReservaDia.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.cabReservaDia.Size = new System.Drawing.Size(926, 34);
            this.cabReservaDia.TabIndex = 0;
            this.cabReservaDia.Text = "";
            this.cabReservaDia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cabReservaEstado
            //
            this.cabReservaEstado.AutoEllipsis = true;
            this.cabReservaEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.cabReservaEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.cabReservaEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.cabReservaEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.cabReservaEstado.Location = new System.Drawing.Point(0, 0);
            this.cabReservaEstado.Name = "cabReservaEstado";
            this.cabReservaEstado.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.cabReservaEstado.Size = new System.Drawing.Size(926, 34);
            this.cabReservaEstado.TabIndex = 0;
            this.cabReservaEstado.Text = "";
            this.cabReservaEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cabMesa
            //
            this.cabMesa.AutoEllipsis = true;
            this.cabMesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.cabMesa.Dock = System.Windows.Forms.DockStyle.Top;
            this.cabMesa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.cabMesa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.cabMesa.Location = new System.Drawing.Point(0, 0);
            this.cabMesa.Name = "cabMesa";
            this.cabMesa.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.cabMesa.Size = new System.Drawing.Size(926, 34);
            this.cabMesa.TabIndex = 0;
            this.cabMesa.Text = "";
            this.cabMesa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cabEstoque
            //
            this.cabEstoque.AutoEllipsis = true;
            this.cabEstoque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.cabEstoque.Dock = System.Windows.Forms.DockStyle.Top;
            this.cabEstoque.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.cabEstoque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.cabEstoque.Location = new System.Drawing.Point(0, 0);
            this.cabEstoque.Name = "cabEstoque";
            this.cabEstoque.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.cabEstoque.Size = new System.Drawing.Size(926, 34);
            this.cabEstoque.TabIndex = 0;
            this.cabEstoque.Text = "";
            this.cabEstoque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // PainelRelatorios
            //
            this._conteudo.Controls.Add(this.abas);
            this._conteudo.Controls.Add(this.pnlCartoes);
            this._conteudo.Controls.Add(this.filtros);
            this.Name = "PainelRelatorios";
            this.Size = new System.Drawing.Size(940, 660);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservaDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservaEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).EndInit();
            this.tabDia.ResumeLayout(false);
            this.tabFuncionario.ResumeLayout(false);
            this.tabPrato.ResumeLayout(false);
            this.tabReservaDia.ResumeLayout(false);
            this.tabReservaEstado.ResumeLayout(false);
            this.tabMesa.ResumeLayout(false);
            this.tabEstoque.ResumeLayout(false);
            this.abas.ResumeLayout(false);
            this.pnlCartoes.ResumeLayout(false);
            this.filtros.ResumeLayout(false);
            this.filtros.PerformLayout();
        }
    }
}
