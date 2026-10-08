using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace Cely_Sabores
{
    // O layout esta em PainelMesas.Designer.cs, para se poder ajustar tudo
    // no designer do Visual Studio. Aqui fica apenas a logica.
    public sealed partial class PainelMesas : PainelBase
    {
        private readonly MesaService _mesaService;

        // Construtor usado pelo designer: nao toca na base de dados.
        public PainelMesas()
            : base("Mesas", "Carregando...")
        {
            InitializeComponent();
        }

        public PainelMesas(MesaService mesaService)
            : this()
        {
            _mesaService = mesaService;

            dgvMesas.CellDoubleClick += (s, ev) => Executar(EditarSelecionada);
            chkMostrarInativas.CheckedChanged += (s, ev) => Executar(Recarregar);

            AdicionarAcao("Actualizar", false, Recarregar);
            AdicionarAcao("Nova mesa", true, Nova);
            AdicionarAcao("Editar", false, EditarSelecionada);
            AdicionarAcao("Alterar estado", false, AlterarEstado);
            AdicionarAcao("Activar / Desactivar", false, AlternarAtivo);

            // no designer nao se toca na base de dados
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                Recarregar();
            }
        }

        public override void Recarregar()
        {
            var mesas = _mesaService.Listar(chkMostrarInativas.Checked);
            dgvMesas.Rows.Clear();

            foreach (var mesa in mesas)
            {
                var indice = dgvMesas.Rows.Add(
                    mesa.Numero,
                    mesa.Capacidade,
                    DescreverEstado(mesa.Estado),
                    mesa.Ativo ? (mesa.Observacoes ?? "") : "(inactiva) " + (mesa.Observacoes ?? ""));

                dgvMesas.Rows[indice].Tag = mesa;
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
            if (dgvMesas.SelectedRows.Count == 0)
            {
                Aviso("Seleccione uma mesa.", MessageBoxIcon.Information);
                return null;
            }

            return dgvMesas.SelectedRows[0].Tag as Mesa;
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
