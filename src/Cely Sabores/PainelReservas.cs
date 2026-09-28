using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace Cely_Sabores
{
    public sealed class PainelReservas : PainelBase
    {
        private readonly ReservaService _reservaService;
        private readonly ClienteService _clienteService;
        private readonly DataGridView _tabela;
        private readonly DateTimePicker _data;
        private readonly ComboBox _filtroEstado;

        public PainelReservas(ReservaService reservaService, ClienteService clienteService)
            : base("Reservas", "Carregando...")
        {
            _reservaService = reservaService;
            _clienteService = clienteService;

            _data = new DateTimePicker
            {
                Width = 140,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Font = new Font("Segoe UI", 9.5F)
            };
            _data.ValueChanged += (s, ev) => Executar(Recarregar);

            _filtroEstado = new ComboBox
            {
                Width = 170,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9.5F)
            };
            _filtroEstado.Items.Add("(todos)");
            foreach (EstadoReserva e in Enum.GetValues(typeof(EstadoReserva)))
            {
                _filtroEstado.Items.Add(e);
            }
            _filtroEstado.SelectedIndex = 0;
            _filtroEstado.SelectedIndexChanged += (s, ev) => Executar(Recarregar);

            var filtros = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 42,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Tema.Fundo
            };
            filtros.Controls.Add(new Label
            {
                Text = "Dia:",
                AutoSize = true,
                ForeColor = Tema.TextoSuave,
                Font = new Font("Segoe UI", 9.5F),
                Margin = new Padding(0, 7, 6, 0)
            });
            filtros.Controls.Add(_data);
            filtros.Controls.Add(_filtroEstado);

            _tabela = Tema.Tabela("Hora", "Cliente", "Mesa", "Pessoas", "Estado", "Observações");
            _tabela.Columns[0].FillWeight = 9;
            _tabela.Columns[1].FillWeight = 24;
            _tabela.Columns[2].FillWeight = 8;
            _tabela.Columns[3].FillWeight = 8;
            _tabela.Columns[4].FillWeight = 13;
            _tabela.Columns[5].FillWeight = 38;
            _tabela.CellDoubleClick += (s, ev) => Executar(EditarSelecionado);

            Conteudo.Controls.Add(_tabela);
            Conteudo.Controls.Add(filtros);

            AdicionarAcao("Actualizar", false, Recarregar);
            AdicionarAcao("Nova reserva", true, Nova);
            AdicionarAcao("Editar", false, EditarSelecionado);
            AdicionarAcao("Confirmar", false, ConfirmarSelecionada);
            AdicionarAcao("Iniciar", false, IniciarSelecionada);
            AdicionarAcao("Concluir", false, ConcluirSelecionada);
            AdicionarAcao("Cancelar", false, CancelarSelecionada);

            Recarregar();
        }

        public override void Recarregar()
        {
            var dia = _data.Value.Date;
            var estado = FiltroEstado();

            var reservas = _reservaService.Listar(
                dia, dia.AddDays(1).AddSeconds(-1), estado);

            _tabela.Rows.Clear();

            foreach (var reserva in reservas)
            {
                var indice = _tabela.Rows.Add(
                    reserva.DataHora.ToString("HH:mm"),
                    reserva.ClienteNome,
                    reserva.MesaNumero.HasValue ? reserva.MesaNumero.Value.ToString() : "-",
                    reserva.NumeroPessoas.ToString(),
                    reserva.Estado.ToString(),
                    reserva.Observacoes ?? "");

                _tabela.Rows[indice].Tag = reserva;
                _tabela.Rows[indice].DefaultCellStyle.ForeColor = CorDoEstado(reserva.Estado);
            }

            DefinirStatus(reservas.Count + " reserva(s) em " + dia.ToString("dd/MM/yyyy"));
        }

        private EstadoReserva? FiltroEstado()
        {
            var seleccionado = _filtroEstado.SelectedItem;
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
            if (_tabela.SelectedRows.Count == 0)
            {
                Aviso("Seleccione uma reserva.", MessageBoxIcon.Information);
                return null;
            }

            return _tabela.SelectedRows[0].Tag as Reserva;
        }

        private IList<Mesa> MesasSugeridas(int pessoas)
        {
            var alvo = _tabela.SelectedRows.Count > 0 ? Selecionada() : null;
            var quando = alvo != null ? alvo.DataHora : _data.Value.Date.AddHours(19);

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
                _data.Value = dialogo.DataHora.Date;
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
