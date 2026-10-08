using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace Cely_Sabores
{
    // O layout está em PainelReservas.Designer.cs, para se poder ajustar tudo
    // no designer do Visual Studio. Aqui fica apenas a lógica.
    public sealed partial class PainelReservas : PainelBase
    {
        private readonly ReservaService _reservaService;
        private readonly ClienteService _clienteService;

        // Construtor usado pelo designer: não toca na base de dados.
        public PainelReservas()
            : base("Reservas", "Carregando...")
        {
            InitializeComponent();
        }

        public PainelReservas(ReservaService reservaService, ClienteService clienteService)
            : this()
        {
            _reservaService = reservaService;
            _clienteService = clienteService;

            // a combo fica no Designer com o "(todos)"; os estados do enum só
            // podem ser acrescentados aqui
            foreach (EstadoReserva estado in Enum.GetValues(typeof(EstadoReserva)))
            {
                cmbEstado.Items.Add(estado);
            }
            cmbEstado.SelectedIndex = 0;

            dtpData.ValueChanged += (s, ev) => Executar(Recarregar);
            cmbEstado.SelectedIndexChanged += (s, ev) => Executar(Recarregar);
            dgvReservas.CellDoubleClick += (s, ev) => Executar(EditarSelecionado);

            AdicionarAcao("Actualizar", false, Recarregar);
            AdicionarAcao("Nova reserva", true, Nova);
            AdicionarAcao("Editar", false, EditarSelecionado);
            AdicionarAcao("Confirmar", false, ConfirmarSelecionada);
            AdicionarAcao("Iniciar", false, IniciarSelecionada);
            AdicionarAcao("Concluir", false, ConcluirSelecionada);
            AdicionarAcao("Cancelar", false, CancelarSelecionada);

            // no designer não se toca na base de dados
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                Recarregar();
            }
        }

        public override void Recarregar()
        {
            var dia = dtpData.Value.Date;
            var estado = FiltroEstado();

            var reservas = _reservaService.Listar(
                dia, dia.AddDays(1).AddSeconds(-1), estado);

            dgvReservas.Rows.Clear();

            foreach (var reserva in reservas)
            {
                var indice = dgvReservas.Rows.Add(
                    reserva.DataHora.ToString("HH:mm"),
                    reserva.ClienteNome,
                    reserva.MesaNumero.HasValue ? reserva.MesaNumero.Value.ToString() : "-",
                    reserva.NumeroPessoas.ToString(),
                    reserva.Estado.ToString(),
                    reserva.Observacoes ?? "");

                dgvReservas.Rows[indice].Tag = reserva;
                dgvReservas.Rows[indice].DefaultCellStyle.ForeColor = CorDoEstado(reserva.Estado);
            }

            DefinirStatus(reservas.Count + " reserva(s) em " + dia.ToString("dd/MM/yyyy"));
        }

        private EstadoReserva? FiltroEstado()
        {
            var seleccionado = cmbEstado.SelectedItem;
            if (seleccionado is EstadoReserva)
            {
                return (EstadoReserva)seleccionado;
            }

            return null;
        }

        private static Color CorDoEstado(EstadoReserva estado)
        {
            if (estado == EstadoReserva.Cancelada)
            {
                return Tema.TextoSuave;
            }

            if (estado == EstadoReserva.Concluida)
            {
                return Tema.Verde;
            }

            if (estado == EstadoReserva.EmAtendimento)
            {
                return Tema.LaranjaEscura;
            }

            return Tema.Texto;
        }

        private Reserva Selecionada()
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                Aviso("Seleccione uma reserva.", MessageBoxIcon.Information);
                return null;
            }

            return dgvReservas.SelectedRows[0].Tag as Reserva;
        }

        private IList<Mesa> MesasSugeridas(int pessoas)
        {
            var alvo = dgvReservas.SelectedRows.Count > 0 ? Selecionada() : null;
            var quando = alvo != null ? alvo.DataHora : dtpData.Value.Date.AddHours(19);

            return _reservaService.ListarMesasLivresPara(quando, pessoas);
        }

        private void Nova()
        {
            var pessoas = 2;
            using (var dialogo = new DialogoReserva(_clienteService.Listar(null), MesasSugeridas(pessoas), pessoas))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                _reservaService.Criar(dialogo.ClienteId, dialogo.MesaId, dialogo.DataHora,
                    dialogo.NumeroPessoas, dialogo.Observacoes);
                dtpData.Value = dialogo.DataHora.Date;
                Recarregar();
            }
        }

        private void EditarSelecionado()
        {
            var reserva = Selecionada();
            if (reserva == null)
            {
                return;
            }

            var clientes = _clienteService.Listar(null);

            using (var dialogo = new DialogoReserva(reserva, clientes, MesasSugeridas(reserva.NumeroPessoas)))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                _reservaService.Atualizar(reserva.Id, dialogo.MesaId, dialogo.DataHora,
                    dialogo.NumeroPessoas, dialogo.Observacoes);
                Recarregar();
            }
        }

        private void ConfirmarSelecionada()
        {
            var reserva = Selecionada();
            if (reserva == null)
            {
                return;
            }

            _reservaService.Confirmar(reserva.Id);
            Recarregar();
        }

        private void IniciarSelecionada()
        {
            var reserva = Selecionada();
            if (reserva == null)
            {
                return;
            }

            _reservaService.IniciarAtendimento(reserva.Id);
            Recarregar();
        }

        private void ConcluirSelecionada()
        {
            var reserva = Selecionada();
            if (reserva == null)
            {
                return;
            }

            _reservaService.Concluir(reserva.Id);
            Recarregar();
        }

        private void CancelarSelecionada()
        {
            var reserva = Selecionada();
            if (reserva == null)
            {
                return;
            }

            if (Confirmar("Cancelar a reserva de " + reserva.ClienteNome + "?") != DialogResult.Yes)
            {
                return;
            }

            _reservaService.Cancelar(reserva.Id);
            Recarregar();
        }
    }
}
