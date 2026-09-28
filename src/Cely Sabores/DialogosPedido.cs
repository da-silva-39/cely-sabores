using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;

namespace Cely_Sabores
{
    public sealed class DialogoAbrirPedido : Form
    {
        private readonly ComboBox _mesa;
        private readonly ComboBox _cliente;
        private readonly TextBox _observacao;

        public Pedido Pedido { get; private set; }

        public DialogoAbrirPedido(PedidoService pedidoService)
        {
            Text = "Abrir pedido";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(430, 270);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10F);

            _mesa = new ComboBox
            {
                Location = new Point(150, 24),
                Width = 250,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };
            foreach (var mesa in pedidoService.ListarMesasLivres())
            {
                _mesa.Items.Add(mesa);
            }
            if (_mesa.Items.Count > 0)
            {
                _mesa.SelectedIndex = 0;
            }

            _cliente = new ComboBox
            {
                Location = new Point(150, 66),
                Width = 250,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };
            _cliente.Items.Add("(balcão - sem cliente)");
            foreach (var c in pedidoService.ListarClientes())
            {
                _cliente.Items.Add(c);
            }
            _cliente.SelectedIndex = 0;

            _observacao = new TextBox
            {
                Location = new Point(150, 110),
                Width = 250,
                Height = 56,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };

            var btnAbrir = new Button
            {
                Text = "Abrir", Size = new Size(110, 36), Location = new Point(180, 200),
                FlatStyle = FlatStyle.Flat, BackColor = Tema.Laranja, ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Cursor = Cursors.Hand
            };
            btnAbrir.FlatAppearance.BorderSize = 0;
            btnAbrir.Click += (s, ev) => Abrir(pedidoService);

            var btnCancelar = new Button
            {
                Text = "Cancelar", DialogResult = DialogResult.Cancel,
                Size = new Size(110, 36), Location = new Point(300, 200),
                FlatStyle = FlatStyle.Flat, BackColor = Color.White, ForeColor = Tema.Texto,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Cursor = Cursors.Hand
            };
            btnCancelar.FlatAppearance.BorderColor = Tema.Borda;

            AcceptButton = btnAbrir;
            CancelButton = btnCancelar;

            Controls.Add(new Rotulo("Mesa", 24, 28));
            Controls.Add(_mesa);
            Controls.Add(new Rotulo("Cliente", 24, 70));
            Controls.Add(_cliente);
            Controls.Add(new Rotulo("Observação", 24, 114));
            Controls.Add(_observacao);
            Controls.Add(btnAbrir);
            Controls.Add(btnCancelar);
        }

        private void Abrir(PedidoService pedidoService)
        {
            var mesa = _mesa.SelectedItem as Mesa;
            if (mesa == null)
            {
                MessageBox.Show("Não há mesas disponíveis.", "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? clienteId = null;
            var cliente = _cliente.SelectedItem as Cliente;
            if (cliente != null)
            {
                clienteId = cliente.Id;
            }

            Pedido = pedidoService.Abrir(mesa.Id, clienteId, _observacao.Text);
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    public sealed class DialogoQuantidade : Form
    {
        private readonly NumericUpDown _quantidade;
        private readonly TextBox _observacao;

        public int Quantidade { get; private set; }
        public string Observacao { get; private set; }

        public DialogoQuantidade(Prato prato) : this(prato, 1)
        {
        }

        public DialogoQuantidade(Prato prato, int quantidadeInicial) : this()
        {
            if (prato != null)
            {
                Text = "Adicionar " + prato.Nome;
                _lblPreco.Text = "Preço: " + Tema.Moeda(prato.Preco);
            }

            _quantidade.Value = System.Math.Max(1, System.Math.Min(999, quantidadeInicial));
        }

        private readonly Label _lblPreco = new Label
        {
            AutoSize = true,
            ForeColor = Tema.TextoSuave,
            Font = new Font("Segoe UI", 9F),
            Location = new Point(150, 26)
        };

        private DialogoQuantidade()
        {
            Text = "Quantidade";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(400, 210);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10F);

            _quantidade = new NumericUpDown
            {
                Location = new Point(150, 58),
                Width = 90,
                Minimum = 0,
                Maximum = 999,
                Font = new Font("Segoe UI", 10F)
            };

            _observacao = new TextBox
            {
                Location = new Point(150, 98),
                Width = 220,
                Font = new Font("Segoe UI", 10F)
            };

            var btnOk = new Button
            {
                Text = "Confirmar", Size = new Size(110, 36), Location = new Point(150, 146),
                FlatStyle = FlatStyle.Flat, BackColor = Tema.Laranja, ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Cursor = Cursors.Hand
            };
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Click += (s, ev) =>
            {
                Quantidade = (int)_quantidade.Value;
                Observacao = _observacao.Text;
                DialogResult = DialogResult.OK;
                Close();
            };

            var btnCancelar = new Button
            {
                Text = "Cancelar", DialogResult = DialogResult.Cancel,
                Size = new Size(110, 36), Location = new Point(270, 146),
                FlatStyle = FlatStyle.Flat, BackColor = Color.White, ForeColor = Tema.Texto,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Cursor = Cursors.Hand
            };
            btnCancelar.FlatAppearance.BorderColor = Tema.Borda;

            AcceptButton = btnOk;
            CancelButton = btnCancelar;

            Controls.Add(_lblPreco);
            Controls.Add(new Rotulo("Quantidade", 24, 62));
            Controls.Add(_quantidade);
            Controls.Add(new Rotulo("Observação", 24, 102));
            Controls.Add(_observacao);
            Controls.Add(btnOk);
            Controls.Add(btnCancelar);
        }
    }

    public sealed class DialogoPagamento : Form
    {
        private readonly NumericUpDown _recebido;
        private readonly Label _troco;
        private readonly decimal _total;

        public decimal ValorRecebido { get; private set; }

        public DialogoPagamento(Pedido pedido)
        {
            _total = pedido.ValorTotal;
            ValorRecebido = pedido.ValorTotal;

            Text = "Pagamento do pedido " + pedido.Id;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(420, 250);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10F);

            var lblTotal = new Label
            {
                Text = "Total a pagar: " + Tema.Moeda(_total),
                AutoSize = true,
                ForeColor = Tema.Texto,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(20, 22)
            };

            _recebido = new NumericUpDown
            {
                Location = new Point(150, 68),
                Width = 140,
                DecimalPlaces = 2,
                Maximum = 10000000m,
                Value = System.Math.Min(10000000m, _total),
                Font = new Font("Segoe UI", 10F)
            };
            _recebido.ValueChanged += (s, ev) => ActualizarTroco();

            _troco = new Label
            {
                AutoSize = true,
                ForeColor = Tema.Verde,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(20, 110)
            };
            ActualizarTroco();

            var btnExacto = new Button
            {
                Text = "Valor exacto", Size = new Size(110, 32), Location = new Point(300, 68),
                FlatStyle = FlatStyle.Flat, BackColor = Color.White, ForeColor = Tema.Texto,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold), Cursor = Cursors.Hand
            };
            btnExacto.FlatAppearance.BorderColor = Tema.Borda;
            btnExacto.Click += (s, ev) => { _recebido.Value = _total; };

            var btnConfirmar = new Button
            {
                Text = "Confirmar", Size = new Size(120, 36), Location = new Point(160, 180),
                FlatStyle = FlatStyle.Flat, BackColor = Tema.Laranja, ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Cursor = Cursors.Hand
            };
            btnConfirmar.FlatAppearance.BorderSize = 0;
            btnConfirmar.Click += (s, ev) =>
            {
                ValorRecebido = _recebido.Value;
                DialogResult = DialogResult.OK;
                Close();
            };

            var btnCancelar = new Button
            {
                Text = "Cancelar", DialogResult = DialogResult.Cancel,
                Size = new Size(110, 36), Location = new Point(290, 180),
                FlatStyle = FlatStyle.Flat, BackColor = Color.White, ForeColor = Tema.Texto,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Cursor = Cursors.Hand
            };
            btnCancelar.FlatAppearance.BorderColor = Tema.Borda;

            AcceptButton = btnConfirmar;
            CancelButton = btnCancelar;

            Controls.Add(lblTotal);
            Controls.Add(new Rotulo("Valor recebido", 24, 72));
            Controls.Add(_recebido);
            Controls.Add(btnExacto);
            Controls.Add(_troco);
            Controls.Add(btnConfirmar);
            Controls.Add(btnCancelar);
        }

        private void ActualizarTroco()
        {
            var troco = _recebido.Value - _total;
            _troco.Text = troco < 0
                ? "Falta: " + Tema.Moeda(-troco)
                : "Troco: " + Tema.Moeda(troco);
            _troco.ForeColor = troco < 0 ? Tema.Perigo : Tema.Verde;
        }
    }
}
