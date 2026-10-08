namespace Cely_Sabores
{
    partial class FormularioLogin
    {
        private System.Windows.Forms.Panel painel;
        private System.Windows.Forms.TableLayoutPanel tabela;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnEntrar;

        private void InitializeComponent()
        {
            this.painel = new System.Windows.Forms.Panel();
            this.tabela = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.painel.SuspendLayout();
            this.tabela.SuspendLayout();
            //
            // painel
            //
            this.painel.Controls.Add(this.tabela);
            this.painel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painel.Location = new System.Drawing.Point(0, 0);
            this.painel.Name = "painel";
            this.painel.Padding = new System.Windows.Forms.Padding(40);
            this.painel.Size = new System.Drawing.Size(420, 360);
            this.painel.TabIndex = 0;
            //
            // tabela
            //
            this.tabela.ColumnCount = 1;
            this.tabela.Controls.Add(this.lblTitulo, 0, 0);
            this.tabela.Controls.Add(this.lblSubtitulo, 0, 1);
            this.tabela.Controls.Add(this.lblUsuario, 0, 2);
            this.tabela.Controls.Add(this.txtUsuario, 0, 3);
            this.tabela.Controls.Add(this.lblSenha, 0, 4);
            this.tabela.Controls.Add(this.txtSenha, 0, 5);
            this.tabela.Controls.Add(this.lblStatus, 0, 6);
            this.tabela.Controls.Add(this.btnEntrar, 0, 7);
            this.tabela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabela.Location = new System.Drawing.Point(0, 0);
            this.tabela.Name = "tabela";
            this.tabela.Padding = new System.Windows.Forms.Padding(0);
            this.tabela.RowCount = 8;
            this.tabela.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tabela.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tabela.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tabela.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tabela.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tabela.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tabela.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tabela.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tabela.Size = new System.Drawing.Size(340, 324);
            this.tabela.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(119)))), ((int)(((byte)(0)))));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(340, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Cely Sabores";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(110)))), ((int)(((byte)(100)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(0, 46);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(191, 19);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Entre com suas credenciais";
            //
            // lblUsuario
            //
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(0, 70);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(59, 19);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuário:";
            //
            // txtUsuario
            //
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsuario.Location = new System.Drawing.Point(0, 102);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(340, 29);
            this.txtUsuario.TabIndex = 3;
            //
            // lblSenha
            //
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(0, 146);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(44, 19);
            this.lblSenha.TabIndex = 4;
            this.lblSenha.Text = "Senha:";
            //
            // txtSenha
            //
            this.txtSenha.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSenha.Location = new System.Drawing.Point(0, 178);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(340, 29);
            this.txtSenha.TabIndex = 5;
            this.txtSenha.UseSystemPasswordChar = true;
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(40)))));
            this.lblStatus.Location = new System.Drawing.Point(0, 226);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(200, 19);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "";
            //
            // btnEntrar
            //
            this.btnEntrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEntrar.FlatAppearance.BorderSize = 0;
            this.btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEntrar.ForeColor = System.Drawing.Color.White;
            this.btnEntrar.Location = new System.Drawing.Point(0, 284);
            this.btnEntrar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(334, 38);
            this.btnEntrar.TabIndex = 7;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            //
            // FormularioLogin
            //
            this.AcceptButton = this.btnEntrar;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(420, 404);
            this.Controls.Add(this.painel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormularioLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cely Sabores - Acesso";
            this.painel.ResumeLayout(false);
            this.tabela.ResumeLayout(false);
            this.tabela.PerformLayout();
        }
    }
}
