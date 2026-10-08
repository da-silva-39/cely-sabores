using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CelySabores.Models.Entities;

namespace Cely_Sabores
{
    // O layout esta em DialogoReserva.Designer.cs, para se poder ajustar tudo
    // no designer do Visual Studio. Aqui fica apenas a logica.
    public sealed partial class DialogoReserva : Form
    {
        private readonly IList<Mesa> _mesas;

        public int ClienteId { get; private set; }
        public int? MesaId { get; private set; }
        public DateTime DataHora { get; private set; }
        public int NumeroPessoas { get; private set; }
        public string Observacoes { get; private set; }

        // Construtor usado pelo designer: nao carrega clientes nem mesas.
        public DialogoReserva()
        {
            InitializeComponent();

            btnGuardar.Click += (s, ev) => Guardar();
        }

        public DialogoReserva(IList<Cliente> clientes, IList<Mesa> mesas, int? pessoasSugeridos)
            : this()
        {
            _mesas = mesas;

            Carregar(clientes, mesas, pessoasSugeridos);
        }

        public DialogoReserva(Reserva reserva, IList<Cliente> clientes, IList<Mesa> mesas)
            : this(clientes, mesas, reserva.NumeroPessoas)
        {
            Text = "Editar reserva";
            dtDataHora.Value = reserva.DataHora;
            txtObservacoes.Text = reserva.Observacoes ?? "";

            var cliente = ProcurarCliente(clientes, reserva.ClienteId);
            if (cliente != null)
            {
                cmbCliente.SelectedItem = cliente;
            }

            if (reserva.MesaId.HasValue)
            {
                var mesa = ProcurarMesa(mesas, reserva.MesaId.Value);
                if (mesa != null)
                {
                    cmbMesa.SelectedItem = mesa;
                }
            }
        }

        // Preenche os controlos com os dados recebidos. Fica fora dos
        // construtores para o designer poder abrir o formulario sem a
        // base de dados.
        private void Carregar(IList<Cliente> clientes, IList<Mesa> mesas, int? pessoasSugeridos)
        {
            // tem de ficar antes de atribuir o valor ao date picker
            dtDataHora.MinDate = DateTime.Now.Date;

            foreach (var c in clientes)
            {
                cmbCliente.Items.Add(c);
            }
            if (cmbCliente.Items.Count > 0)
            {
                cmbCliente.SelectedIndex = 0;
            }

            cmbMesa.Items.Add("(sem mesa)");
            foreach (var m in mesas)
            {
                cmbMesa.Items.Add(m);
            }
            cmbMesa.SelectedIndex = 0;

            dtDataHora.Value = DateTime.Now.Date.AddDays(1).AddHours(19);

            numPessoas.Value = pessoasSugeridos.HasValue && pessoasSugeridos.Value > 0
                ? Math.Min(60, pessoasSugeridos.Value)
                : 2;
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
            var cliente = cmbCliente.SelectedItem as Cliente;
            if (cliente == null)
            {
                MessageBox.Show("Escolha o cliente da reserva.", "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ClienteId = cliente.Id;

            var mesa = cmbMesa.SelectedItem as Mesa;
            MesaId = mesa == null ? (int?)null : mesa.Id;

            DataHora = dtDataHora.Value;
            NumeroPessoas = (int)numPessoas.Value;
            Observacoes = txtObservacoes.Text;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
