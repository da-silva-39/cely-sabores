using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Models.Entities;

namespace Cely_Sabores
{
    public sealed class DialogoReserva : Form
    {
        private readonly ComboBox _cliente;
        private readonly ComboBox _mesa;
        private readonly DateTimePicker _dataHora;
        private readonly NumericUpDown _pessoas;
        private readonly TextBox _observacoes;
        private readonly IList<Mesa> _mesas;

        public int ClienteId { get; private set; }
        public int? MesaId { get; private set; }
        public DateTime DataHora { get; private set; }
        public int NumeroPessoas { get; private set; }
        public string Observacoes { get; private set; }

        public DialogoReserva(IList<Cliente> clientes, IList<Mesa> mesas, int? pessoasSugeridos)
        {
            _mesas = mesas;

            Text = "Nova reserva";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(470, 320);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10F);

            _cliente = new ComboBox
            {
                Location = new Point(150, 22),
                Width = 290,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };
            foreach (var c in clientes)
            {
                _cliente.Items.Add(c);
            }
            if (_cliente.Items.Count > 0)
            {
                _cliente.SelectedIndex = 0;
            }

            _mesa = new ComboBox
            {
                Location = new Point(150, 64),
                Width = 290,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };
            _mesa.Items.Add("(sem mesa)");
            foreach (var m in mesas)
            {
                _mesa.Items.Add(m);
            }
            _mesa.SelectedIndex = 0;

            _dataHora = new DateTimePicker
            {
                Location = new Point(150, 106),
                Width = 200,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy HH:mm",
                ShowUpDown = true,
                MinDate = DateTime.Now.Date,
                Font = new Font("Segoe UI", 10F)
            };
            _dataHora.Value = DateTime.Now.Date.AddDays(1).AddHours(19);

            _pessoas = new NumericUpDown
            {
                Location = new Point(150, 148),
                Width = 80,
                Minimum = 1,
                Maximum = 60,
                Value = pessoasSugeridos.HasValue && pessoasSugeridos.Value > 0
                    ? Math.Min(60, pessoasSugeridos.Value)
                    : 2,
                Font = new Font("Segoe UI", 10F)
            };

            _observacoes = new TextBox
            {
                Location = new Point(150, 190),
                Width = 290,
                Multiline = true,
                Height = 50,
                ScrollBars = ScrollBars.Vertical
            };

            var btnGuardar = Botao("Guardar", true, 130);
            btnGuardar.Click += (s, ev) => Guardar();
            var btnCancelar = Botao("Cancelar", false, 240);
            btnCancelar.DialogResult = DialogResult.Cancel;

            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;

            Controls.Add(Rotulo("Cliente", 20, 26));
            Controls.Add(_cliente);
            Controls.Add(Rotulo("Mesa", 20, 68));
            Controls.Add(_mesa);
            Controls.Add(Rotulo("Data e hora", 20, 110));
            Controls.Add(_dataHora);
            Controls.Add(Rotulo("Pessoas", 20, 152));
            Controls.Add(_pessoas);
            Controls.Add(Rotulo("Observações", 20, 194));
            Controls.Add(_observacoes);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
        }

        public DialogoReserva(Reserva reserva, IList<Cliente> clientes, IList<Mesa> mesas)
            : this(clientes, mesas, reserva.NumeroPessoas)
        {
            Text = "Editar reserva";
            _dataHora.Value = reserva.DataHora;
            _observacoes.Text = reserva.Observacoes ?? "";

            var cliente = ProcurarCliente(clientes, reserva.ClienteId);
            if (cliente != null)
            {
                _cliente.SelectedItem = cliente;
            }

            if (reserva.MesaId.HasValue)
            {
                var mesa = ProcurarMesa(mesas, reserva.MesaId.Value);
                if (mesa != null)
                {
                    _mesa.SelectedItem = mesa;
                }
            }
        }

        private static Cliente ProcurarCliente(IList<Cliente> clientes, int id)
        {
            foreach (var c in clientes)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }

            return null;
        }

        private static Mesa ProcurarMesa(IList<Mesa> mesas, int id)
        {
            foreach (var m in mesas)
            {
                if (m.Id == id)
                {
                    return m;
                }
            }

            return null;
        }

        private void Guardar()
        {
            var cliente = _cliente.SelectedItem as Cliente;
            if (cliente == null)
            {
                MessageBox.Show("Escolha o cliente da reserva.", "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ClienteId = cliente.Id;

            var mesa = _mesa.SelectedItem as Mesa;
            MesaId = mesa == null ? (int?)null : mesa.Id;

            DataHora = _dataHora.Value;
            NumeroPessoas = (int)_pessoas.Value;
            Observacoes = _observacoes.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private static Label Rotulo(string texto, int x, int y)
        {
            return new Label
            {
                Text = texto,
                Location = new Point(x, y),
                AutoSize = true,
                ForeColor = Tema.Texto
            };
        }

        private static Button Botao(string texto, bool primario, int x)
        {
            var botao = new Button
            {
                Text = texto,
                DialogResult = DialogResult.None,
                Size = new Size(100, 34),
                Location = new Point(x, 265),
                FlatStyle = FlatStyle.Flat,
                BackColor = primario ? Tema.Laranja : Color.White,
                ForeColor = primario ? Color.White : Tema.Texto,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            botao.FlatAppearance.BorderSize = primario ? 0 : 1;
            if (!primario)
            {
                botao.FlatAppearance.BorderColor = Tema.Borda;
            }

            return botao;
        }
    }
}
