using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace Cely_Sabores
{
    public sealed class PainelMesas : PainelBase
    {
        private readonly MesaService _mesaService;
        private readonly DataGridView _tabela;
        private readonly CheckBox _mostrarInativas;

        public PainelMesas(MesaService mesaService) : base("Mesas", "Carregando...")
        {
            _mesaService = mesaService;

            _tabela = Tema.Tabela("Número", "Capacidade", "Estado", "Observações");
            _tabela.Columns[0].FillWeight = 18;
            _tabela.Columns[1].FillWeight = 18;
            _tabela.Columns[2].FillWeight = 26;
            _tabela.Columns[3].FillWeight = 38;
            _tabela.CellDoubleClick += (s, ev) => Executar(EditarSelecionada);

            _mostrarInativas = new CheckBox
            {
                Text = "Mostrar inativas",
                AutoSize = true,
                ForeColor = Tema.TextoSuave,
                Font = new Font("Segoe UI", 9F),
                Margin = new Padding(0, 10, 12, 0)
            };
            _mostrarInativas.CheckedChanged += (s, ev) => Executar(Recarregar);

            Conteudo.Controls.Add(_tabela);
            Conteudo.Controls.Add(_mostrarInativas);
            _mostrarInativas.BringToFront();
            _mostrarInativas.Dock = DockStyle.Top;
            _mostrarInativas.Height = 34;
            _mostrarInativas.Padding = new Padding(0, 8, 0, 0);

            AdicionarAcao("Actualizar", false, Recarregar);
            AdicionarAcao("Nova mesa", true, Nova);
            AdicionarAcao("Editar", false, EditarSelecionada);
            AdicionarAcao("Alterar estado", false, AlterarEstado);
            AdicionarAcao("Activar / Desactivar", false, AlternarAtivo);

            Recarregar();
        }

        public override void Recarregar()
        {
            var mesas = _mesaService.Listar(_mostrarInativas.Checked);
            _tabela.Rows.Clear();

            foreach (var mesa in mesas)
            {
                var indice = _tabela.Rows.Add(
                    mesa.Numero,
                    mesa.Capacidade,
                    DescreverEstado(mesa.Estado),
                    mesa.Ativo ? (mesa.Observacoes ?? "") : "(inactiva) " + (mesa.Observacoes ?? ""));

                _tabela.Rows[indice].Tag = mesa;
            }

            DefinirStatus(mesas.Count + " mesa(s) - " + Contar(mesas, EstadoMesa.Livre) + " livre(s), "
                + Contar(mesas, EstadoMesa.Ocupada) + " ocupada(s), "
                + Contar(mesas, EstadoMesa.Reservada) + " reservada(s)");
        }

        private static int Contar(IList<Mesa> mesas, EstadoMesa estado)
        {
            int total = 0;
            foreach (var mesa in mesas)
            {
                if (mesa.Estado == estado)
                {
                    total++;
                }
            }
            return total;
        }

        private static string DescreverEstado(EstadoMesa estado)
        {
            switch (estado)
            {
                case EstadoMesa.Livre: return "Livre";
                case EstadoMesa.Ocupada: return "Ocupada";
                case EstadoMesa.Reservada: return "Reservada";
                case EstadoMesa.EmAtendimento: return "Em atendimento";
                case EstadoMesa.AguardandoPagamento: return "Aguardando pagamento";
                default: return estado.ToString();
            }
        }

        private Mesa Selecionada()
        {
            if (_tabela.SelectedRows.Count == 0)
            {
                Aviso("Seleccione uma mesa.", MessageBoxIcon.Information);
                return null;
            }

            return _tabela.SelectedRows[0].Tag as Mesa;
        }

        private void Nova()
        {
            using (var dialogo = new DialogoMesa())
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                _mesaService.Inserir(dialogo.Mesa);
                Recarregar();
                Aviso("Mesa " + dialogo.Mesa.Numero + " criada.", MessageBoxIcon.Information);
            }
        }

        private void EditarSelecionada()
        {
            var mesa = Selecionada();
            if (mesa == null)
            {
                return;
            }

            if (!EhGerente)
            {
                Aviso("Apenas o gerente pode editar mesas.", MessageBoxIcon.Warning);
                return;
            }

            using (var dialogo = new DialogoMesa(mesa))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                _mesaService.Atualizar(dialogo.Mesa);
                Recarregar();
            }
        }

        private void AlterarEstado()
        {
            var mesa = Selecionada();
            if (mesa == null)
            {
                return;
            }

            using (var dialogo = new DialogoEstadoMesa(mesa))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                _mesaService.AlterarEstado(mesa.Id, dialogo.Estado);
                Recarregar();
            }
        }

        private void AlternarAtivo()
        {
            var mesa = Selecionada();
            if (mesa == null)
            {
                return;
            }

            if (!EhGerente)
            {
                Aviso("Apenas o gerente pode activar ou desactivar mesas.", MessageBoxIcon.Warning);
                return;
            }

            var acao = mesa.Ativo ? "desactivar" : "activar";
            if (Confirmar("Deseja " + acao + " a mesa " + mesa.Numero + "?") != DialogResult.Yes)
            {
                return;
            }

            _mesaService.AlterarAtivo(mesa.Id, !mesa.Ativo);
            Recarregar();
        }
    }
}
