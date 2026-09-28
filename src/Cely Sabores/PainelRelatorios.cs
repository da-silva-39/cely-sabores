using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Dtos;

namespace Cely_Sabores
{
    public sealed class PainelRelatorios : PainelBase
    {
        private readonly RelatorioService _relatorioService;
        private readonly DateTimePicker _de;
        private readonly DateTimePicker _ate;
        private readonly TabControl _abas;
        private readonly DataGridView _tabelaDia;
        private readonly DataGridView _tabelaFuncionario;
        private readonly DataGridView _tabelaPrato;
        private readonly FlowLayoutPanel _cartoes;
        private RelatorioVendas _relatorio;

        public PainelRelatorios(RelatorioService relatorioService)
            : base("Relatórios", "Carregando...")
        {
            _relatorioService = relatorioService;

            _de = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today.AddDays(-6)
            };
            _de.ValueChanged += (s, ev) => Executar(Recarregar);

            _ate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today
            };
            _ate.ValueChanged += (s, ev) => Executar(Recarregar);

            var filtros = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 46,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Tema.Fundo
            };
            filtros.Controls.Add(new Label
            {
                Text = "De:",
                AutoSize = true,
                ForeColor = Tema.TextoSuave,
                Font = new Font("Segoe UI", 9.5F),
                Margin = new Padding(0, 7, 6, 0)
            });
            filtros.Controls.Add(_de);
            filtros.Controls.Add(new Label
            {
                Text = "até:",
                AutoSize = true,
                ForeColor = Tema.TextoSuave,
                Font = new Font("Segoe UI", 9.5F),
                Margin = new Padding(14, 7, 6, 0)
            });
            filtros.Controls.Add(_ate);

            _cartoes = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 108,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Tema.Fundo,
                Padding = new Padding(0, 4, 0, 8)
            };

            _tabelaDia = Tema.Tabela("Dia", "Pedidos", "Faturamento", "Ticket médio");
            PreencherPesos(_tabelaDia, 30, 18, 28, 24);

            _tabelaFuncionario = Tema.Tabela("Funcionário", "Pedidos", "Faturamento", "Recebido", "Troco");
            PreencherPesos(_tabelaFuncionario, 34, 14, 20, 18, 14);

            _tabelaPrato = Tema.Tabela("Prato", "Quantidade", "Faturamento");
            PreencherPesos(_tabelaPrato, 50, 20, 30);

            _abas = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5F),
                Padding = new Point(12, 6)
            };

            var abaDia = new TabPage("Por dia");
            abaDia.BackColor = Tema.Fundo;
            abaDia.Controls.Add(_tabelaDia);

            var abaFunc = new TabPage("Por funcionário");
            abaFunc.BackColor = Tema.Fundo;
            abaFunc.Controls.Add(_tabelaFuncionario);

            var abaPrato = new TabPage("Por prato");
            abaPrato.BackColor = Tema.Fundo;
            abaPrato.Controls.Add(_tabelaPrato);

            _abas.TabPages.Add(abaDia);
            _abas.TabPages.Add(abaFunc);
            _abas.TabPages.Add(abaPrato);

            Conteudo.Controls.Add(_abas);
            Conteudo.Controls.Add(_cartoes);
            Conteudo.Controls.Add(filtros);

            AdicionarAcao("Actualizar", false, Recarregar);
            AdicionarAcao("Exportar CSV", false, ExportarCsv);

            Recarregar();
        }

        public override void Recarregar()
        {
            _relatorio = _relatorioService.Gerar(_de.Value, _ate.Value);

            DesenharCartoes();
            DesenharDia();
            DesenharFuncionario();
            DesenharPrato();

            DefinirStatus("De " + _relatorio.De.ToString("dd/MM/yyyy")
                + " até " + _relatorio.Ate.ToString("dd/MM/yyyy")
                + "  ·  " + _relatorio.PedidosFechados + " pedido(s) fechado(s)");
        }

        private void DesenharCartoes()
        {
            _cartoes.Controls.Clear();

            _cartoes.Controls.Add(Tema.Cartao("Faturamento", Tema.Moeda(_relatorio.Faturamento), Tema.LaranjaEscura));
            _cartoes.Controls.Add(Tema.Cartao("Pedidos fechados",
                _relatorio.PedidosFechados.ToString(), Tema.Texto));
            _cartoes.Controls.Add(Tema.Cartao("Ticket médio",
                Tema.Moeda(_relatorio.TicketMedio), Tema.Verde));
            _cartoes.Controls.Add(Tema.Cartao("Itens vendidos",
                _relatorio.ItensVendidos.ToString(), Tema.Texto));
            _cartoes.Controls.Add(Tema.Cartao("Valor médio por prato",
                Tema.Moeda(_relatorio.ValorMedioPrato), Tema.Texto));
            _cartoes.Controls.Add(Tema.Cartao("Cancelados",
                _relatorio.PedidosCancelados.ToString(),
                _relatorio.PedidosCancelados > 0 ? Tema.Perigo : Tema.Texto));
        }

        private void DesenharDia()
        {
            _tabelaDia.Rows.Clear();

            foreach (var linha in _relatorio.PorDia)
            {
                _tabelaDia.Rows.Add(
                    linha.Dia.ToString("dd/MM/yyyy"),
                    linha.PedidosFechados.ToString(),
                    Tema.Moeda(linha.Faturamento),
                    Tema.Moeda(linha.TicketMedio));
            }

            if (_relatorio.PorDia.Count == 0)
            {
                _tabelaDia.Rows.Add("(sem vendas no intervalo)");
            }
        }

        private void DesenharFuncionario()
        {
            _tabelaFuncionario.Rows.Clear();

            foreach (var linha in _relatorio.PorFuncionario)
            {
                _tabelaFuncionario.Rows.Add(
                    linha.Nome,
                    linha.PedidosFechados.ToString(),
                    Tema.Moeda(linha.Faturamento),
                    Tema.Moeda(linha.TotalRecebido),
                    Tema.Moeda(linha.TotalTroco));
            }

            if (_relatorio.PorFuncionario.Count == 0)
            {
                _tabelaFuncionario.Rows.Add("(sem vendas no intervalo)");
            }
        }

        private void DesenharPrato()
        {
            _tabelaPrato.Rows.Clear();

            foreach (var linha in _relatorio.PorPrato)
            {
                _tabelaPrato.Rows.Add(
                    linha.Nome,
                    linha.Quantidade.ToString(),
                    Tema.Moeda(linha.Faturamento));
            }

            if (_relatorio.PorPrato.Count == 0)
            {
                _tabelaPrato.Rows.Add("(sem vendas no intervalo)");
            }
        }

        private void ExportarCsv()
        {
            if (_relatorio == null || _relatorio.PedidosFechados == 0)
            {
                Aviso("Não há vendas no intervalo para exportar.", MessageBoxIcon.Information);
                return;
            }

            using (var dialogo = new SaveFileDialog
            {
                Filter = "CSV (*.csv)|*.csv|Texto (*.txt)|*.txt",
                FileName = "relatorio_" + _relatorio.De.ToString("yyyyMMdd") + "_"
                    + _relatorio.Ate.ToString("yyyyMMdd") + ".csv"
            })
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    using (var writer = new System.IO.StreamWriter(
                        dialogo.FileName, false, System.Text.Encoding.UTF8))
                    {
                        writer.WriteLine("Relatório de vendas");
                        writer.WriteLine("De;{0:dd/MM/yyyy}", _relatorio.De);
                        writer.WriteLine("Até;{0:dd/MM/yyyy}", _relatorio.Ate);
                        writer.WriteLine("Pedidos fechados;" + _relatorio.PedidosFechados);
                        writer.WriteLine("Faturamento;" + _relatorio.Faturamento.ToString("F2"));
                        writer.WriteLine("Ticket médio;" + _relatorio.TicketMedio.ToString("F2"));
                        writer.WriteLine();
                        writer.WriteLine("Por dia");
                        writer.WriteLine("Dia;Pedidos;Faturamento;Ticket medio");

                        foreach (var l in _relatorio.PorDia)
                        {
                            writer.WriteLine("{0:dd/MM/yyyy};{1};{2};{3}",
                                l.Dia, l.PedidosFechados, l.Faturamento.ToString("F2"),
                                l.TicketMedio.ToString("F2"));
                        }

                        writer.WriteLine();
                        writer.WriteLine("Por funcionario");
                        writer.WriteLine("Funcionario;Pedidos;Faturamento;Recebido;Troco");

                        foreach (var l in _relatorio.PorFuncionario)
                        {
                            writer.WriteLine("{0};{1};{2};{3};{4}", l.Nome, l.PedidosFechados,
                                l.Faturamento.ToString("F2"), l.TotalRecebido.ToString("F2"),
                                l.TotalTroco.ToString("F2"));
                        }

                        writer.WriteLine();
                        writer.WriteLine("Por prato");
                        writer.WriteLine("Prato;Quantidade;Faturamento");

                        foreach (var l in _relatorio.PorPrato)
                        {
                            writer.WriteLine("{0};{1};{2}", l.Nome, l.Quantidade,
                                l.Faturamento.ToString("F2"));
                        }
                    }

                    Aviso("Relatório guardado em:\n" + dialogo.FileName, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Aviso("Não foi possível gravar o ficheiro:\n" + ex.Message, MessageBoxIcon.Error);
                }
            }
        }

        private static void PreencherPesos(DataGridView tabela, params int[] pesos)
        {
            for (var i = 0; i < pesos.Length && i < tabela.Columns.Count; i++)
            {
                tabela.Columns[i].FillWeight = pesos[i];
            }
        }
    }
}
