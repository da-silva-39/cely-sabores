using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;

namespace Cely_Sabores
{
    public sealed class DialogoPrato : Form
    {
        private readonly ComboBox _categoria;
        private readonly TextBox _nome;
        private readonly TextBox _descricao;
        private readonly NumericUpDown _preco;
        private readonly CheckBox _disponivel;

        public Prato Prato { get; private set; }

        public DialogoPrato(CardapioService cardapioService, Prato prato)
        {
            Prato = prato == null ? new Prato() : prato;

            Text = prato == null ? "Novo prato" : "Editar prato";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(460, 320);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10F);

            _categoria = new ComboBox
            {
                Location = new Point(150, 24),
                Width = 280,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };
            foreach (var categoria in cardapioService.ListarCategorias(false))
            {
                _categoria.Items.Add(categoria);
            }

            _nome = new TextBox { Location = new Point(150, 64), Width = 280 };
            _descricao = new TextBox
            {
                Location = new Point(150, 104),
                Width = 280,
                Height = 70,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            _preco = new NumericUpDown
            {
                Location = new Point(150, 190),
                Width = 120,
                DecimalPlaces = 2,
                Maximum = 1000000,
                Font = new Font("Segoe UI", 10F)
            };
            _disponivel = new CheckBox
            {
                Text = "Disponível para pedidos",
                Location = new Point(150, 230),
                AutoSize = true,
                ForeColor = Tema.Texto
            };

            if (prato != null)
            {
                _nome.Text = prato.Nome;
                _descricao.Text = prato.Descricao ?? "";
                _preco.Value = Math.Max(0, Math.Min(1000000m, prato.Preco));
                _disponivel.Checked = prato.Disponivel;
                _categoria.SelectedItem = _categoria.Items.OfType<Categoria>()
                    .FirstOrDefault(c => c.Id == prato.CategoriaId);
            }
            else
            {
                _disponivel.Checked = true;
                if (_categoria.Items.Count > 0)
                {
                    _categoria.SelectedIndex = 0;
                }
            }

            var btnGuardar = new Button
            {
                Text = "Guardar", Size = new Size(110, 36), Location = new Point(200, 266),
                FlatStyle = FlatStyle.Flat, BackColor = Tema.Laranja, ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Cursor = Cursors.Hand
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += (s, ev) => Guardar();

            var btnCancelar = new Button
            {
                Text = "Cancelar", DialogResult = DialogResult.Cancel,
                Size = new Size(110, 36), Location = new Point(320, 266),
                FlatStyle = FlatStyle.Flat, BackColor = Color.White, ForeColor = Tema.Texto,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Cursor = Cursors.Hand
            };
            btnCancelar.FlatAppearance.BorderColor = Tema.Borda;

            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;

            Controls.Add(new Rotulo("Categoria", 24, 28));
            Controls.Add(_categoria);
            Controls.Add(new Rotulo("Nome", 24, 68));
            Controls.Add(_nome);
            Controls.Add(new Rotulo("Descrição", 24, 108));
            Controls.Add(_descricao);
            Controls.Add(new Rotulo("Preço (MZN)", 24, 194));
            Controls.Add(_preco);
            Controls.Add(_disponivel);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
        }

        private void Guardar()
        {
            var categoria = _categoria.SelectedItem as Categoria;
            if (categoria == null)
            {
                MessageBox.Show("Escolha a categoria do prato.", "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Prato.CategoriaId = categoria.Id;
            Prato.Nome = _nome.Text;
            Prato.Descricao = _descricao.Text;
            Prato.Preco = _preco.Value;
            Prato.Disponivel = _disponivel.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    public sealed class DialogoCliente : Form
    {
        private readonly TextBox _nome;
        private readonly TextBox _telefone;
        private readonly TextBox _email;
        private readonly TextBox _endereco;
        private readonly TextBox _observacoes;

        public Cliente Cliente { get; private set; }

        public DialogoCliente(Cliente cliente)
        {
            Cliente = cliente == null ? new Cliente() : cliente;

            Text = cliente == null ? "Novo cliente" : "Editar cliente";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(480, 330);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10F);

            _nome = new TextBox { Location = new Point(140, 24), Width = 310 };
            _telefone = new TextBox { Location = new Point(140, 64), Width = 310 };
            _email = new TextBox { Location = new Point(140, 104), Width = 310 };
            _endereco = new TextBox { Location = new Point(140, 144), Width = 310 };
            _observacoes = new TextBox
            {
                Location = new Point(140, 184), Width = 310, Height = 70,
                Multiline = true, ScrollBars = ScrollBars.Vertical
            };

            if (cliente != null)
            {
                _nome.Text = cliente.NomeCompleto ?? "";
                _telefone.Text = cliente.Telefone ?? "";
                _email.Text = cliente.Email ?? "";
                _endereco.Text = cliente.Endereco ?? "";
                _observacoes.Text = cliente.Observacoes ?? "";
            }

            var btnGuardar = new Button
            {
                Text = "Guardar", Size = new Size(110, 36), Location = new Point(220, 274),
                FlatStyle = FlatStyle.Flat, BackColor = Tema.Laranja, ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Cursor = Cursors.Hand
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += (s, ev) =>
            {
                Cliente.NomeCompleto = _nome.Text;
                Cliente.Telefone = _telefone.Text;
                Cliente.Email = _email.Text;
                Cliente.Endereco = _endereco.Text;
                Cliente.Observacoes = _observacoes.Text;
                DialogResult = DialogResult.OK;
                Close();
            };

            var btnCancelar = new Button
            {
                Text = "Cancelar", DialogResult = DialogResult.Cancel,
                Size = new Size(110, 36), Location = new Point(340, 274),
                FlatStyle = FlatStyle.Flat, BackColor = Color.White, ForeColor = Tema.Texto,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Cursor = Cursors.Hand
            };
            btnCancelar.FlatAppearance.BorderColor = Tema.Borda;

            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;

            Controls.Add(new Rotulo("Nome completo", 24, 28));
            Controls.Add(_nome);
            Controls.Add(new Rotulo("Telefone", 24, 68));
            Controls.Add(_telefone);
            Controls.Add(new Rotulo("E-mail", 24, 108));
            Controls.Add(_email);
            Controls.Add(new Rotulo("Endereço", 24, 148));
            Controls.Add(_endereco);
            Controls.Add(new Rotulo("Observações", 24, 188));
            Controls.Add(_observacoes);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
        }
    }

    public sealed class Rotulo : Label
    {
        public Rotulo(string texto, int x, int y)
        {
            Text = texto;
            Location = new Point(x, y);
            AutoSize = true;
            ForeColor = Tema.Texto;
        }
    }
}
