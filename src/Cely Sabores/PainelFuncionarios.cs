using System;
using System.ComponentModel;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;

namespace Cely_Sabores
{
    // O layout esta em PainelFuncionarios.Designer.cs, para se poder ajustar
    // tudo no designer do Visual Studio. Aqui fica apenas a logica.
    public sealed partial class PainelFuncionarios : PainelBase
    {
        private readonly FuncionarioService _funcionarioService;

        // Construtor usado pelo designer: nao toca na base de dados.
        public PainelFuncionarios()
            : base("Funcionários", "Carregando...")
        {
            InitializeComponent();
        }

        public PainelFuncionarios(FuncionarioService funcionarioService)
            : this()
        {
            _funcionarioService = funcionarioService;

            chkInactivos.CheckedChanged += (s, ev) => Executar(Recarregar);
            dgvFuncionarios.CellDoubleClick += (s, ev) => Executar(EditarSelecionado);

            AdicionarAcao("Actualizar", false, Recarregar);
            AdicionarAcao("Novo funcionário", true, Novo);
            AdicionarAcao("Editar", false, EditarSelecionado);
            AdicionarAcao("Desativar", false, () => AlterarAtivo(false));
            AdicionarAcao("Ativar", false, () => AlterarAtivo(true));

            // no designer nao se toca na base de dados
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                Recarregar();
            }
        }

        public override void Recarregar()
        {
            var funcionarios = _funcionarioService.Listar(!chkInactivos.Checked);
            dgvFuncionarios.Rows.Clear();

            foreach (var funcionario in funcionarios)
            {
                var indice = dgvFuncionarios.Rows.Add(
                    funcionario.NomeCompleto,
                    funcionario.Cargo,
                    funcionario.Telefone ?? "",
                    funcionario.Email ?? "",
                    Tema.DataHora(funcionario.DataCadastro).Substring(0, 10),
                    funcionario.Ativo ? "Sim" : "Não");

                dgvFuncionarios.Rows[indice].Tag = funcionario;

                if (!funcionario.Ativo)
                {
                    dgvFuncionarios.Rows[indice].DefaultCellStyle.ForeColor = Tema.TextoSuave;
                }
            }

            DefinirStatus(funcionarios.Count + " funcionário(s)"
                + (chkInactivos.Checked ? "" : " activo(s)"));
        }

        private Funcionario Selecionado()
        {
            if (dgvFuncionarios.SelectedRows.Count == 0)
            {
                Aviso("Seleccione um funcionário.", MessageBoxIcon.Information);
                return null;
            }

            return dgvFuncionarios.SelectedRows[0].Tag as Funcionario;
        }

        private void Novo()
        {
            using (var dialogo = new DialogoFuncionario())
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                _funcionarioService.Inserir(dialogo.Funcionario);
                Recarregar();
            }
        }

        private void EditarSelecionado()
        {
            var funcionario = Selecionado();
            if (funcionario == null)
            {
                return;
            }

            using (var dialogo = new DialogoFuncionario(funcionario))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                _funcionarioService.Atualizar(dialogo.Funcionario);
                Recarregar();
            }
        }

        private void AlterarAtivo(bool ativo)
        {
            var funcionario = Selecionado();
            if (funcionario == null)
            {
                return;
            }

            if (funcionario.Ativo == ativo)
            {
                return;
            }

            if (!ativo
                && Confirmar("Desativar " + funcionario.NomeCompleto
                    + "? O acesso ao sistema será bloqueado.") != DialogResult.Yes)
            {
                return;
            }

            _funcionarioService.AlterarAtivo(funcionario.Id, ativo);
            Recarregar();
        }
    }
}
