namespace Cely_Sabores
{
    partial class FormularioShell
    {
        private System.Windows.Forms.Panel pnlConteudo;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblMenuTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.FlowLayoutPanel menuItens;

        private void InitializeComponent()
        {
            this.pnlConteudo = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblMenuTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.menuItens = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMenu.SuspendLayout();
            this.menuItens.SuspendLayout();
            //
            // pnlConteudo
            //
            this.pnlConteudo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Location = new System.Drawing.Point(224, 0);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Padding = new System.Windows.Forms.Padding(22);
            this.pnlConteudo.Size = new System.Drawing.Size(956, 720);
            this.pnlConteudo.TabIndex = 1;
            //
            // pnlMenu
            //
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.pnlMenu.Controls.Add(this.lblMenuTitulo);
            this.pnlMenu.Controls.Add(this.lblUsuario);
            this.pnlMenu.Controls.Add(this.btnSair);
            this.pnlMenu.Controls.Add(this.menuItens);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(224, 720);
            this.pnlMenu.TabIndex = 0;
            //
            // lblMenuTitulo
            //
            this.lblMenuTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMenuTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblMenuTitulo.ForeColor = System.Drawing.Color.White;
            this.lblMenuTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblMenuTitulo.Name = "lblMenuTitulo";
            this.lblMenuTitulo.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.lblMenuTitulo.Size = new System.Drawing.Size(224, 54);
            this.lblMenuTitulo.TabIndex = 0;
            this.lblMenuTitulo.Text = "Cely Sabores";
            this.lblMenuTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblUsuario
            //
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(130)))));
            this.lblUsuario.Location = new System.Drawing.Point(0, 54);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.lblUsuario.Size = new System.Drawing.Size(224, 48);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnSair
            //
            this.btnSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(58)))), ((int)(((byte)(42)))));
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(0, 674);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(224, 46);
            this.btnSair.TabIndex = 2;
            this.btnSair.Text = "Sair";
            //
            // menuItens
            //
            this.menuItens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(46)))), ((int)(((byte)(34)))));
            this.menuItens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuItens.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.menuItens.Location = new System.Drawing.Point(0, 102);
            this.menuItens.Name = "menuItens";
            this.menuItens.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.menuItens.Size = new System.Drawing.Size(224, 572);
            this.menuItens.TabIndex = 3;
            this.menuItens.WrapContents = false;
            //
            // FormularioShell
            //
            this.Controls.Add(this.pnlConteudo);
            this.Controls.Add(this.pnlMenu);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1180, 720);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1024, 640);
            this.Name = "FormularioShell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cely Sabores";
            this.menuItens.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
        }
    }
}
