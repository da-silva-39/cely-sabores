using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cely_Sabores
{
    public static class Tema
    {
        public static readonly Color Menu = Color.FromArgb(56, 46, 34);
        public static readonly Color Laranja = Color.FromArgb(255, 152, 0);
        public static readonly Color LaranjaEscura = Color.FromArgb(230, 119, 0);
        public static readonly Color Fundo = Color.FromArgb(250, 248, 244);
        public static readonly Color Texto = Color.FromArgb(56, 46, 34);
        public static readonly Color TextoSuave = Color.FromArgb(130, 118, 106);
        public static readonly Color Perigo = Color.FromArgb(190, 50, 40);
        public static readonly Color Verde = Color.FromArgb(46, 125, 50);
        public static readonly Color CartaoSelecao = Color.FromArgb(255, 236, 205);
        public static readonly Color Borda = Color.FromArgb(238, 230, 222);

        public static string Moeda(decimal valor)
        {
            return valor.ToString("N2") + " MZN";
        }

        public static string DataHora(DateTime valor)
        {
            return valor.ToString("dd/MM/yyyy HH:mm");
        }

        public static Label Titulo(string texto, float tamanho, bool forte)
        {
            return new Label
            {
                Text = texto,
                AutoSize = true,
                ForeColor = Texto,
                Font = new Font("Segoe UI", tamanho, forte ? FontStyle.Bold : FontStyle.Regular)
            };
        }

        public static Label Subtitulo(string texto)
        {
            return new Label
            {
                Text = texto,
                AutoSize = true,
                ForeColor = TextoSuave,
                Font = new Font("Segoe UI", 9F)
            };
        }

        public static Button Botao(string texto, bool primario)
        {
            var botao = new Button
            {
                Text = texto,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                MinimumSize = new Size(96, 34),
                Padding = new Padding(10, 0, 10, 0),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = primario ? Color.White : Texto,
                BackColor = primario ? Laranja : Color.White,
                Margin = new Padding(0, 0, 8, 0)
            };
            botao.FlatAppearance.BorderSize = primario ? 0 : 1;
            botao.FlatAppearance.BorderColor = Borda;
            return botao;
        }

        public static Panel Cartao(string titulo, string valor, Color corValor)
        {
            var painel = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Color.White,
                Padding = new Padding(16, 12, 16, 12),
                Margin = new Padding(0, 0, 12, 12)
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                AutoSize = true,
                ForeColor = TextoSuave,
                Font = new Font("Segoe UI", 9F)
            };
            var lblValor = new Label
            {
                Text = valor,
                AutoSize = true,
                ForeColor = corValor,
                Font = new Font("Segoe UI", 17F, FontStyle.Bold),
                Location = new Point(16, 30)
            };

            painel.Controls.Add(lblTitulo);
            painel.Controls.Add(lblValor);
            return painel;
        }

        public static DataGridView Tabela(params string[] colunas)
        {
            var tabela = new DataGridView
            {
                AutoGenerateColumns = false,
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeight = 34,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 10F)
            };
            tabela.ColumnHeadersDefaultCellStyle.BackColor = Laranja;
            tabela.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            tabela.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabela.DefaultCellStyle.BackColor = Color.White;
            tabela.DefaultCellStyle.SelectionBackColor = CartaoSelecao;
            tabela.DefaultCellStyle.SelectionForeColor = Texto;
            tabela.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            tabela.GridColor = Borda;

            foreach (var coluna in colunas)
            {
                tabela.Columns.Add(coluna, coluna);
            }

            return tabela;
        }

        public static void Centralizar(System.Windows.Forms.Control pai, Control filho, int altura)
        {
            filho.Dock = DockStyle.Top;
            filho.Height = altura;
            pai.Controls.Add(filho);
        }
    }
}
