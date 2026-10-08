using System;
using System.Windows.Forms;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace Cely_Sabores
{
    // O layout esta em DialogoMesa.Designer.cs, para se poder ajustar tudo
    // no designer do Visual Studio. Aqui fica apenas a logica.
    public sealed partial class DialogoMesa : Form
    {
        public Mesa Mesa { get; private set; }

        // Construtor usado pelo designer (e tambem o de "nova mesa").
        public DialogoMesa()
        {
            InitializeComponent();
            Mesa = new Mesa();

            btnGuardar.Click += Guardar;
        }

        public DialogoMesa(Mesa mesa)
            : this()
        {
            Text = "Editar mesa " + mesa.Numero;
            numNumero.Value = Math.Max(1, Math.Min(999, mesa.Numero));
            numCapacidade.Value = Math.Max(1, Math.Min(100, mesa.Capacidade));
            txtObservacoes.Text = mesa.Observacoes ?? "";
            Mesa.Id = mesa.Id;
            Mesa.Ativo = mesa.Ativo;
            Mesa.Estado = mesa.Estado;
        }

        private void Guardar(object sender, EventArgs ev)
        {
            Mesa.Numero = (int)numNumero.Value;
            Mesa.Capacidade = (int)numCapacidade.Value;
            Mesa.Observacoes = txtObservacoes.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    // O layout esta em DialogoEstadoMesa.Designer.cs.
    public sealed partial class DialogoEstadoMesa : Form
    {
        public EstadoMesa Estado { get; private set; }

        // Construtor usado pelo designer: nao preenche o estado da mesa.
        public DialogoEstadoMesa()
        {
            InitializeComponent();

            btnGuardar.Click += (s, ev) =>
            {
                Estado = (EstadoMesa)cmbEstado.SelectedIndex;
                DialogResult = DialogResult.OK;
                Close();
            };
        }

        public DialogoEstadoMesa(Mesa mesa)
            : this()
        {
            Text = "Estado da mesa " + mesa.Numero;
            Estado = mesa.Estado;
            cmbEstado.SelectedIndex = (int)mesa.Estado;
        }
    }
}
