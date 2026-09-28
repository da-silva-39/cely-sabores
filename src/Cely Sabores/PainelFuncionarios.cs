using System;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;

namespace Cely_Sabores
{
    public sealed class PainelFuncionarios : PainelBase
    {
        private readonly FuncionarioService _funcionarioService;
        private readonly DataGridView _tabela;
        private readonly CheckBox _mostrarInactivos;

        public PainelFuncionarios(FuncionarioService funcionarioService)
            : base("Funcionários", "Carregando...")
        {
            _funcionarioService = funcionarioService;

            _mostrarInactivos = new CheckBox
            {
                Text = "Mostrar inactivos",
                AutoSize = true,
                ForeColor = Tema.Texto,
                Font = new Font("Segoe UI", 9.5F),
                Margin = new Padding(0, 7, 0, 0)
            };
            _mostrarInactivos.CheckedChanged += (s, ev) => Executar(Recarregar);

            var filtros = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 42,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Tema.Fundo
            };
            filtros.Controls.Add(_mostrarInactivos);

            _tabela = Tema.Tabela("Nome", "Cargo", "Telefone", "E-mail", "Desde", "Ativo");
            _tabela.Columns[0].FillWeight = 28;
            _tabela.Columns[1].FillWeight = 18;
            _tabela.Columns[2].FillWeight = 14;
            _tabela.Columns[3].FillWeight = 22;
            _tabela.Columns[4].FillWeight = 10;
            _tabela.Columns[5].FillWeight = 8;
            _tabela.CellDoubleClick += (s, ev) => Executar(EditarSelecionado);

            Conteudo.Controls.Add(_tabela);
            Conteudo.Controls.Add(filtros);

            AdicionarAcao("Actualizar", false, Recarregar);
            AdicionarAcao("Novo funcionário", true, Novo);
            AdicionarAcao("Editar", false, EditarSelecionado);
            AdicionarAcao("Desativar", false, () => AlterarAtivo(false));
            AdicionarAcao("Ativar", false, () => AlterarAtivo(true));

            Recarregar();
        }

        public override void Recarregar()
        {
            var funcionarios = _funcionarioService.Listar(!_mostrarInactivos.Checked);
            _tabela.Rows.Clear();

            foreach (var funcionario in funcionarios)
            {
                var indice = _tabela.Rows.Add(
                    funcionario.NomeCompleto,
                    funcionario.Cargo,
                    funcionario.Telefone ?? "",
                    funcionario.Email ?? "",
                    Tema.DataHora(funcionario.DataCadastro).Substring(0, 10),
                    funcionario.Ativo ? "Sim" : "Não");

                _tabela.Rows[indice].Tag = funcionario;

                if (!funcionario.Ativo)
                {
                    _tabela.Rows[indice].DefaultCellStyle.ForeColor = Tema.TextoSuave;
                }
            }

            DefinirStatus(funcionarios.Count + " funcionário(s)"
                + (_mostrarInactivos.Checked ? "" : " activo(s)"));
        }

        private Funcionario Selecionado()
        {
            if (_tabela.SelectedRows.Count == 0)
            {
                Aviso("Seleccione um funcionário.", MessageBoxIcon.Information);
                return null;
            }

            return _tabela.SelectedRows[0].Tag as Funcionario;
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
