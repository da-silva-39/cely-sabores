using System;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace Cely_Sabores
{
    public sealed class DialogoMesa : Form
    {
        private readonly NumericUpDown _numero;
        private readonly NumericUpDown _capacidade;
        private readonly TextBox _observacoes;

        public Mesa Mesa { get; private set; }

        public DialogoMesa()
        {
            Mesa = new Mesa();

            Text = "Nova mesa";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(400, 240);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10F);

            var lblNumero = Rotulo("Número", 20, 26);
            _numero = new NumericUpDown
            {
                Location = new Point(140, 22),
                Width = 90,
                Minimum = 1,
                Maximum = 999,
                Font = new Font("Segoe UI", 10F)
            };

            var lblCapacidade = Rotulo("Capacidade", 20, 68);
            _capacidade = new NumericUpDown
            {
                Location = new Point(140, 64),
                Width = 90,
                Minimum = 1,
                Maximum = 100,
                Value = 4,
                Font = new Font("Segoe UI", 10F)
            };

            var lblObs = Rotulo("Observações", 20, 110);
            _observacoes = new TextBox
            {
                Location = new Point(140, 106),
                Width = 230,
                Multiline = true,
                Height = 50,
                ScrollBars = ScrollBars.Vertical
            };

            var btnGuardar = new Button
            {
                Text = "Guardar",
                DialogResult = DialogResult.None,
                Size = new Size(100, 34),
                Location = new Point(160, 180),
                FlatStyle = FlatStyle.Flat,
                BackColor = Tema.Laranja,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += Guardar;

            var btnCancelar = new Button
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel,
                Size = new Size(100, 34),
                Location = new Point(270, 180),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Tema.Texto,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCancelar.FlatAppearance.BorderColor = Tema.Borda;

            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;

            Controls.Add(lblNumero);
            Controls.Add(_numero);
            Controls.Add(lblCapacidade);
            Controls.Add(_capacidade);
            Controls.Add(lblObs);
            Controls.Add(_observacoes);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
        }

        public DialogoMesa(Mesa mesa) : this()
        {
            Text = "Editar mesa " + mesa.Numero;
            _numero.Value = Math.Max(1, Math.Min(999, mesa.Numero));
            _capacidade.Value = Math.Max(1, Math.Min(100, mesa.Capacidade));
            _observacoes.Text = mesa.Observacoes ?? "";
            Mesa.Id = mesa.Id;
            Mesa.Ativo = mesa.Ativo;
            Mesa.Estado = mesa.Estado;
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

        private void Guardar(object sender, EventArgs ev)
        {
            Mesa.Numero = (int)_numero.Value;
            Mesa.Capacidade = (int)_capacidade.Value;
            Mesa.Observacoes = _observacoes.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    public sealed class DialogoEstadoMesa : Form
    {
        private readonly ComboBox _estado;

        public EstadoMesa Estado { get; private set; }

        public DialogoEstadoMesa(Mesa mesa)
        {
            Text = "Estado da mesa " + mesa.Numero;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(340, 170);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10F);

            Estado = mesa.Estado;

            var lbl = new Label
            {
                Text = "Novo estado:",
                Location = new Point(20, 30),
                AutoSize = true,
                ForeColor = Tema.Texto
            };

            _estado = new ComboBox
            {
                Location = new Point(20, 54),
                Width = 290,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };
            _estado.Items.AddRange(new object[]
            {
                "Livre", "Ocupada", "Reservada", "Em atendimento", "Aguardando pagamento"
            });
            _estado.SelectedIndex = (int)mesa.Estado;

            var btnGuardar = new Button
            {
                Text = "Guardar",
                Size = new Size(100, 34),
                Location = new Point(100, 110),
                FlatStyle = FlatStyle.Flat,
                BackColor = Tema.Laranja,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += (s, ev) =>
            {
                Estado = (EstadoMesa)_estado.SelectedIndex;
                DialogResult = DialogResult.OK;
                Close();
            };

            var btnCancelar = new Button
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel,
                Size = new Size(100, 34),
                Location = new Point(210, 110),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Tema.Texto,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCancelar.FlatAppearance.BorderColor = Tema.Borda;

            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;

            Controls.Add(lbl);
            Controls.Add(_estado);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
        }
    }
}
